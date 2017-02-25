using System;
using System.Collections.Generic;

namespace CoinChange
{
    internal static class Program
    {
        public static int[] coinTypes = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 }; //British coin values in pence

        public static void Main(string[] args) //code entry point
        {
            int pence = (int)(Utils.ReadDecimal("Enter amount (£):") * 100); //get user input in £ but convert to pence (integer)
            foreach (var pair in CalcCoins(pence)) //invoke calculation method and ennumerate through result
            {
                if (pair.Value > 0) //if amount of this coin is more than 0
                {
                    Console.WriteLine(pair.Key + " x" + pair.Value); //print
                }
            }
        }

        public static Dictionary<int, int> CalcCoins(int pence)
        {
            Dictionary<int, int> ret = Utils.InitDict(coinTypes); //initialise return value
            for (int i = 0; i < coinTypes.Length; ++i) //ennumerate through coinTypes
            {
                ret[coinTypes[i]] = pence / coinTypes[i]; //perform integer division on "pence" and add the result to the dictionary
                pence %= coinTypes[i]; //set "pence" to be the remainder of the integer division - how much change is left to be made.
            }
            return ret;
        }
    }
}
