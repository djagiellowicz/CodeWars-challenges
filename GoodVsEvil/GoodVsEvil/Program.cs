using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    //https://www.codewars.com/kata/good-vs-evil/train/csharp

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
            Console.WriteLine(Kata.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
            Console.WriteLine(Kata.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
            Console.ReadKey();
        }
    }
}
