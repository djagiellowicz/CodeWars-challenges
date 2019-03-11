using System;
using System.Linq;


namespace Does_my_number_look_big_in_this
{
    class Program
    {
        // https://www.codewars.com/kata/5287e858c6b5a9678200083c
        /*
        A Narcissistic Number is a number which is the sum of its own digits, each raised to the power of the number of digits in a given base. In this Kata, we will restrict ourselves to decimal (base 10).

        For example, take 153 (3 digits):

        1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
        and 1634 (4 digits):

        1^4 + 6^4 + 3^4 + 4^4 = 1 + 1296 + 81 + 256 = 1634
        The Challenge:

        Your code must return true or false depending upon whether the given number is a Narcissistic number in base 10.

        Error checking for text strings or other invalid inputs is not required, only valid integers will be passed into the function.
        */

        static void Main(string[] args)
        {
            Console.WriteLine($"Is 2 narcissistic? {Narcissistic(2)}");
            Console.WriteLine($"Is 121 narcissistic? {Narcissistic(121)}");
            Console.WriteLine($"Is 152 narcissistic? {Narcissistic(152)}");
            Console.WriteLine($"Is 153 narcissistic? {Narcissistic(153)}");
            Console.WriteLine($"Is 154 narcissistic? {Narcissistic(154)}");
            Console.WriteLine($"Is 534494835 narcissistic? {Narcissistic(534494835)}");
            Console.WriteLine($"Is 534494836 narcissistic? {Narcissistic(534494836)}");
            Console.WriteLine($"Is 534494837 narcissistic? {Narcissistic(534494837)}");
            Console.WriteLine($"Is 93083 narcissistic? {Narcissistic(93083)}");
            Console.WriteLine($"Is 93084 narcissistic? {Narcissistic(93084)}");
            Console.WriteLine($"Is 93085 narcissistic? {Narcissistic(93085)}");
            Console.ReadKey();
        }

        public static bool Narcissistic(int value)
        {
            var sum = value.ToString()
                           .Select(x => Int32.Parse(x.ToString()))
                           .Sum(x => Math.Pow(x, value.ToString().Length));

            if (sum == value) return true;
            return false;
        }
    }
}
