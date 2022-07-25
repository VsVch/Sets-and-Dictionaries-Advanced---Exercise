using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
       

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols.Add(input[i], 0);
                }
                symbols[input[i]]++;
            }
            foreach (var symbol in symbols.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
