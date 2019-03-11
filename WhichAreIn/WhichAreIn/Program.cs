using System;
using System.Collections.Generic;

namespace WhichAreIn
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a1 = new string[] { "arp", "live", "strong" };
            string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
            string[] r = new string[] { "arp", "live", "strong" };

            foreach (var line in inArray(a1, a2))
            {
                Console.Write(line + " ");
            }
            Console.ReadKey();
        }

        public static string[] inArray(string[] array1, string[] array2)
        {
            string[] stringsToReturn = new string[0];

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array2[j].Contains(array1[i]))
                    {
                        stringsToReturn = AddToStringArray(stringsToReturn, array1[i]);
                        break;
                    }
                }
            }
            Array.Sort(stringsToReturn);
            return stringsToReturn;
        }

        private static string[] AddToStringArray(string[] array, string stringToAdd)
        {
            string[] temporaryArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }

            temporaryArray[array.Length] = stringToAdd;

            return temporaryArray;
        }
    }
}
