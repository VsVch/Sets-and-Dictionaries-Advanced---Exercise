
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSet = numElements[0];
            int secondSet = numElements[1];
            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();

            for (int i = 0; i < firstSet; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                firstNumbers.Add(curNum);
            }
            for (int j = 0; j < secondSet; j++)
            {
                int curNum = int.Parse(Console.ReadLine());
                secondNumbers.Add(curNum);
            }
            firstNumbers.IntersectWith(secondNumbers);

            Console.WriteLine(string.Join(" ", firstNumbers));
        }
    }
}

