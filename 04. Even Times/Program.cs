using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(curNum))
                {
                    numbers.Add(curNum, 0);
                }
                numbers[curNum]++;
            }
            foreach (var number in numbers.Where(x => x.Value% 2 == 0))
            {
                Console.WriteLine($"{number.Key}");
            }
        }
    }
}
