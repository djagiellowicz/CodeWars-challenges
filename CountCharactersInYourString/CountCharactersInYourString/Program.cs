using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharactersInYourString
{
    // https://www.codewars.com/kata/count-characters-in-your-string
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static Dictionary<char, int> Count(string str)
        {
            return str.GroupBy(character => character)
                      .ToDictionary(character => character.Key, value => value.Count());
        }
    }
}
