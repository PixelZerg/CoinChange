using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoinChange
{
    public class Utils
    {
        public static Dictionary<int, int> InitDict(int[] array)
        {
            Dictionary<int, int> ret = new Dictionary<int, int>();
            foreach (int a in array)
            {
                ret.Add(a, 0);
            }
            return ret;
        }

        public static decimal ReadDecimal(string prompt)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            string rawin = string.Empty;
            decimal integer = 0;
            Regex numpattern = new Regex("^.[0-9]*$"); //regular expression for numbers 0-9 with decimal point
            bool done = false;
            while (!done)
            {
                ConsoleKeyInfo k = Console.ReadKey(); //read a key
                if (k.Key == ConsoleKey.Enter) //enter means done
                {
                    done = true;
                }
                if (k.Key == ConsoleKey.Backspace)
                {
                    try
                    {
                        rawin = rawin.Substring(0, rawin.Length - 1);
                    }
                    catch { }
                }
                // if (k.Key != ConsoleKey.Spacebar) //disallow spaces (this if statement is not necessary)
                {
                    if (numpattern.IsMatch(k.KeyChar.ToString())) //only allow numbers due the int32 parse check, this is also not necessary now.
                    {
                        if (Decimal.TryParse(rawin + k.KeyChar, out integer)) //make sure value inputed is not higher than max value and there is no parsing error.
                        {
                            rawin += k.KeyChar;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine(prompt);
                Console.WriteLine(rawin);
            }
            return integer;
        }
    }
}
