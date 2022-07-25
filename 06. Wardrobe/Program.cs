using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new [] { " -> "}, StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] clothes = input[1].Split(",");
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe.ContainsKey(colour))
                    {
                        wardrobe.Add(colour, new Dictionary<string, int>());
                    }
                    if (!wardrobe[colour].ContainsKey(clothes[j]))
                    {
                        wardrobe[colour].Add(clothes[j], 0);
                    }
                    wardrobe[colour][clothes[j]]++;
                }
            }
            string[] check = Console.ReadLine().Split();
            string colourCheck = check[0];
            string clothesCheck = check[1];
            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");
                foreach (var clothes in colour.Value)
                {
                    if (colour.Key == colourCheck & clothes.Key == clothesCheck)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                    
                }
            }
        }
    }
}
