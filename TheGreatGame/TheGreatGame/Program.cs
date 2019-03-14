using System;

namespace TheGreatGame
{
    class Program
    {
        // https://www.codewars.com/kata/the-great-game/train/csharp
        // Not the best solution, but I wanted to use enums, and split methods. It could be much shorter and better/cleaner done.

        static void Main(string[] args)
        {
            foreach (var VARIABLE in ExtractSymbolsFromString("()[]8<"))
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadKey();
        }

        public static string WhoIsWinner(string team1, string team2)
        {
            int points = 0;
            Symbol[] team1Symbols = ConvertToEnumSymbols(ExtractSymbolsFromString(team1));
            Symbol[] team2Symbols = ConvertToEnumSymbols(ExtractSymbolsFromString(team2));

            for (int i = 0; i < team1Symbols.Length; i++)
            {
                points += WhoWonTheRound(team1Symbols[i], team2Symbols[i]);
            }

            if (points == 0)
            {
                return "TIE";
            }
            else if (points > 0)
            {
                return "TEAM 2 WINS";
            }
            else
            {
                return "TEAM 1 WINS";
            }
        }

        // Should have used switch statement here
        private static int WhoWonTheRound(Symbol team1Symbol, Symbol team2Symbol)
        {
            if (team1Symbol == team2Symbol)
            {
                return 0;
            }
            else if (team1Symbol == Symbol.PAPER && team2Symbol == Symbol.ROCK)
            {
                return -1;
            }
            else if (team2Symbol == Symbol.PAPER && team1Symbol == Symbol.ROCK)
            {
                return 1;
            }
            else if (team1Symbol == Symbol.ROCK && team2Symbol == Symbol.SCISSORS)
            {
                return -1;
            }
            else if (team2Symbol == Symbol.ROCK && team1Symbol == Symbol.SCISSORS)
            {
                return 1;
            }

            else if (team1Symbol == Symbol.SCISSORS && team2Symbol == Symbol.PAPER)
            {
                return -1;
            }
            else if (team2Symbol == Symbol.SCISSORS && team1Symbol == Symbol.PAPER)
            {
                return 1;
            }

            return 0;
        }

        private static string[] ExtractSymbolsFromString(string pairOfChars)
        {
            string[] arrayToReturn = new string[pairOfChars.Length/2];
            int numerator = 0;

            for (int i = 0; i < pairOfChars.Length; i+=2)
            {
                    arrayToReturn[numerator++] = pairOfChars.Substring(i,2);             
            }

            return arrayToReturn;
        }

        private static Symbol[] ConvertToEnumSymbols(string[] teamSymbols)
        {
            Symbol[] enumSymbol = new Symbol[teamSymbols.Length];
            for (int i = 0; i < teamSymbols.Length; i++)
            {
                switch (teamSymbols[i])
                {
                    case "()":
                        enumSymbol[i] = Symbol.ROCK;
                        break;
                    case "[]":
                        enumSymbol[i] = Symbol.PAPER;
                        break;
                    case "8<":
                        enumSymbol[i] = Symbol.SCISSORS;
                        break;
                    default:
                        break;
                }
            }

            return enumSymbol;
        }

        private enum Symbol
        {
            PAPER,
            ROCK,
            SCISSORS
        }
    }
}
