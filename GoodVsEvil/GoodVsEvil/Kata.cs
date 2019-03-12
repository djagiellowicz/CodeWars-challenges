using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    class Kata
    {
        // It could be much simpler with LINQ, also I could use just arrays of values not separate integers.

        private static int hobbit = 1;
        private static int men = 2;
        private static int elves = 3;
        private static int dwarves = 3;
        private static int eagles = 4;
        private static int wizards = 10;
        private static int orcs = 1;
        private static int wargs = 2;
        private static int goblins = 2;
        private static int urukHai = 3;
        private static int trolls = 5;

        public static string GoodVsEvil(string good, string evil)
        {
            string[] goods = good.Split(' ');
            string[] evils = evil.Split(' ');

            int goodsValue = SumGoods(goods);
            int evilsValue = SumEvils(evils);

            if (goodsValue > evilsValue)
            {
                return "Battle Result: Good triumphs over Evil";
            }
            else if (evilsValue > goodsValue)
            {
                return "Battle Result: Evil eradicates all trace of Good";
            }
            return "Battle Result: No victor on this battle field";
        }

        private static int SumEvils(string[] evils)
        {
            int sum = 0;
            sum += int.Parse(evils[0]) * orcs;
            sum += int.Parse(evils[1]) * men;
            sum += int.Parse(evils[2]) * wargs;
            sum += int.Parse(evils[3]) * goblins;
            sum += int.Parse(evils[4]) * urukHai;
            sum += int.Parse(evils[5]) * trolls;
            sum += int.Parse(evils[6]) * wizards;

            return sum;
        }

        private static int SumGoods(string[] goods)
        {
            int sum = 0;
            sum += int.Parse(goods[0]) * hobbit;
            sum += int.Parse(goods[1]) * men;
            sum += int.Parse(goods[2]) * elves;
            sum += int.Parse(goods[3]) * dwarves;
            sum += int.Parse(goods[4]) * eagles;
            sum += int.Parse(goods[5]) * wizards;

            return sum;
        }
    }
}
