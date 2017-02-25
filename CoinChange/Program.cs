using System;
using System.Collections.Generic;

namespace CoinChange
{
    internal static class Program
    {
        public static int[] coinTypes = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 };

        public static void Main(string[] args)
        {
            int pence = (int)(Utils.ReadDecimal("Enter amount (£):") * 100);
            foreach (var pair in CalcCoins(pence))
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine(pair.Key + " x" + pair.Value);
                }
            }
        }

        public static Dictionary<int, int> CalcCoins(int pence)
        {
            Dictionary<int, int> ret = Utils.InitDict(coinTypes);
            for (int i = 0; i < coinTypes.Length; ++i)
            {
                ret[coinTypes[i]] = pence / coinTypes[i];
                pence %= coinTypes[i];
            }
            return ret;
        }
    }
}
