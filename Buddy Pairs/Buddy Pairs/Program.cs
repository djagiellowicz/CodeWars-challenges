using System;
using System.Collections.Generic;

namespace Buddy_Pairs
{
    // https://www.codewars.com/kata/buddy-pairs
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Buddy(10, 50));
            Console.ReadKey();
        }

        public static string Buddy(long start, long limit)
        {

            long firstBuddy;
            long secondBuddy;
            long divisionSum;
            long doubleLimit = limit * 2;

            long[] divisionSums = new long[doubleLimit];


            for (long i = start; i <= doubleLimit; i++)
            {
                divisionSum = SumDivisors(i) - 1;
                divisionSums[i - start] = divisionSum;
            }

            for (long i = start; i <= limit; i++)
            {
                for (long j = start + 1; j <= doubleLimit; j++)
                {
                    if (divisionSums[i - start] == j && divisionSums[j - start] == i)
                    {
                        firstBuddy = i;
                        secondBuddy = j;
                        return $"[{firstBuddy} {secondBuddy}]";
                    }
                }
            }
            return "Nothing";
        }

        private static long SumDivisors(long number)
        {
            long sum = 0;
            long halfNumber = number / 2;

            for (long i = 1; i <= halfNumber; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }


        //public static string Buddy(long start, long limit)
        //{

        //    long firstBuddy;
        //    long secondBuddy;
        //    long divisionSum;
        //    long doubleLimit = limit * 2;

        //    Dictionary<long, long> BuddyDictionary = new Dictionary<long, long>();



        //    for (long i = start; i <= doubleLimit; i++)
        //    {
        //        divisionSum = SumDivisors(i) - 1;
        //        if (!BuddyDictionary.ContainsKey(divisionSum))
        //        {
        //            BuddyDictionary.Add(divisionSum, i);
        //        }
        //    }

        //    for (long i = start; i <= limit; i++)
        //    {
        //        for (long j = start + 1; j <= doubleLimit; j++)
        //        {
        //            if (BuddyDictionary.ContainsKey(i) && BuddyDictionary.ContainsKey(j))
        //            {
        //                if (BuddyDictionary[i] == j && BuddyDictionary[j] == i)
        //                {
        //                    firstBuddy = i;
        //                    secondBuddy = j;
        //                    return $"[{firstBuddy} {secondBuddy}]";
        //                }
        //            }
        //        }
        //    }
        //    return "Nothing";
        //}


        /*
        public static string Buddy(long start, long limit)
        {
            long firstBuddy;
            long secondBuddy;
            HashSet<Tuple<long, long>> firstBuddyList = new HashSet<Tuple<long, long>>();
            HashSet<Tuple<long, long>> secondBuddyList = new HashSet<Tuple<long, long>>();

            for (long i = start; i <= limit * 2; i++)
            {
                if (i <= limit)
                {
                    firstBuddyList.Add(new Tuple<long, long>(SumDivisors(i) - 1, i));
                }
                secondBuddyList.Add(new Tuple<long, long>(SumDivisors(i) - 1, i));
            }

            foreach (var firstPair in firstBuddyList)
            {
                foreach (var secondPair in secondBuddyList)
                {
                    if (secondPair.Item1 == firstPair.Item2 && secondPair.Item2 == firstPair.Item1)
                    {
                        secondBuddy = secondPair.Item2;
                        firstBuddy = firstPair.Item2;
                        if (secondBuddy > firstBuddy)
                        {
                            return $"[{firstBuddy} {secondBuddy}]";
                        }
                    }
                }
            }
            return "Nothing";
        }
        */


        /*
        public static string Buddy(long start, long limit)
        {
            long firstBuddy;
            long secondBuddy;
            Dictionary<long, long> firstPossibleBuddies = new Dictionary<long, long>();
            Dictionary<long, long> secondPossibleBuddies = new Dictionary<long, long>();

            for (long i = start; i <= limit; i++)
            {
                firstPossibleBuddies.TryAdd(SumDivisors(i) - 1, i);
            }

            for (long j = start; j <= limit * 2; j++)
            {
                secondPossibleBuddies.TryAdd(SumDivisors(j) - 1, j);
            }

            foreach (var firstPair in firstPossibleBuddies)
            {
                foreach (var secondPair in secondPossibleBuddies)
                {
                    if (secondPair.Key == firstPair.Value && secondPair.Value == firstPair.Key)
                    {
                        secondBuddy = secondPair.Value;
                        firstBuddy = firstPair.Value;
                        if (secondBuddy > firstBuddy)
                        {
                            return $"[{firstBuddy} {secondBuddy}]";
                        }
                    }
                }
            }
            return "Nothing";
        }
        */
    }
}
