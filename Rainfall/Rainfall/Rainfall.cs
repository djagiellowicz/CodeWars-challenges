using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rainfall
{
    class Rainfall
    {
        private readonly static string _regexDoubles = "([0-9.0-9]+)";

        public static double Mean(string town, string strng)
        {
            string townLine = GetLineWithTown(town, strng);
            List<double> listOfDoubles;

            if (townLine == string.Empty) return -1;

            listOfDoubles = GetDoublesFromTownLine(townLine);

            return (listOfDoubles.Sum() / listOfDoubles.Count);
        }

        public static double Variance(string town, string strng)
        {
            double mean = Mean(town, strng);
            string townLine = GetLineWithTown(town, strng);
            List<double> listOfDoubles; 
            double counter = 0;
            double variance = 0;

            if (townLine == string.Empty) return -1;

            listOfDoubles = GetDoublesFromTownLine(townLine);

            for (int i = 0; i < listOfDoubles.Count; i++)
            {
                counter += Math.Pow(listOfDoubles[i] - mean, 2);
            }

            variance = counter / listOfDoubles.Count;
            return variance;
        }

        private static string GetLineWithTown(string town, string strng)
        {
            string[] strings = strng.Split("\n");

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains(town))
                {
                    return strings[i];
                }
            }
            return string.Empty;
        }

        private static List<double> GetDoublesFromTownLine(string townLine)
        {
            MatchCollection matches = Regex.Matches(townLine, _regexDoubles);
            return matches.Select(x => double.Parse(x.Value.Replace('.', ','))).ToList();
        } 
    }
}