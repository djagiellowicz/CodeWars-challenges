using System;
using System.Collections.Generic;

namespace CountingDuplicates
{
    // https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1
    /* Count the number of Duplicates
         Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets(both uppercase and lowercase) and numeric digits.

         Example
        "abcde" -> 0 # no characters repeats more than once
        "aabbcde" -> 2 # 'a' and 'b'
        "aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
        "indivisibility" -> 1 # 'i' occurs six times
        "Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
        "aA11" -> 2 # 'a' and '1'
        "ABBA" -> 2 # 'A' and 'B' each occur twice
        */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DuplicateCount("aA11"));
            Console.ReadKey();
        }

        public static int DuplicateCount(string str)
        {
            str = str.ToLower();
            int numberOfCharsRepeating = 0;
            HashSet<char> checkedCharactesSet = new HashSet<char>();
            bool wasChecked = false;

            for (int i = 0; i < str.Length; i++)
            {
                wasChecked = false;
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (checkedCharactesSet.Contains(str[i]))
                    {
                        wasChecked = true;
                    }
                    else if (str[i] == str[j] && !wasChecked)
                    {
                        numberOfCharsRepeating++;
                        checkedCharactesSet.Add(str[i]);
                    }
                }
            }
            return numberOfCharsRepeating;
        }
    }
}
