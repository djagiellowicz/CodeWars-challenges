using System;
using System.Collections.Generic;

namespace Rectangle_into_Squares
{
    // https://www.codewars.com/kata/rectangle-into-squares/csharp
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var line in sqInRect(120, 300))
            {
                Console.Write(line + " ");    
            }
            Console.ReadKey();
        }

        public static List<int> sqInRect(int lng, int wdth)
        {
            if (lng == wdth) return null;
            List<int> list = new List<int>();
            GetSquare(lng, wdth, list);
            return list;
        }

        public static void GetSquare(int lng, int wdth, List<int> list)
        {
            if (lng == 0 || wdth == 0)
            {
                return;
            }
            else if (lng == wdth && lng == 1)
            {
                list.Add(1);
            }
            else if (lng > wdth)
            {
                lng -= wdth;
                list.Add(wdth);
                GetSquare(lng, wdth, list);
            }
            else
            {
                wdth -= lng;
                list.Add(lng);
                GetSquare(lng, wdth, list);
            }
        }
    }
}
