using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (input != "Statistics")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstVloger = inputArray[0];

                if (inputArray[1] == "joined") 
                {

                    if (!vloggers.ContainsKey(firstVloger))
                    {
                        vloggers.Add(firstVloger, new Dictionary<string, SortedSet<string>>());
                        vloggers[firstVloger].Add("joining", new SortedSet<string>());
                        vloggers[firstVloger].Add("following", new SortedSet<string>());
                    }

                }
                else if (inputArray[1] == "followed")
                {

                    string secondVloger = inputArray[2];

                    if (vloggers.ContainsKey(firstVloger) && vloggers.ContainsKey(secondVloger) && firstVloger != secondVloger)
                    {
                        vloggers[secondVloger]["following"].Add(firstVloger);
                        vloggers[firstVloger]["joining"].Add(secondVloger);
                    }
                }

                input = Console.ReadLine();
            }
            
            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDictVlogers = vloggers.OrderByDescending(v => v.Value["following"].Count)
                .ThenBy(v => v.Value["joining"].Count).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int vloggersCounter = 0;

            foreach (var vlogger in sortedDictVlogers)
            {
                Console.WriteLine($"{++vloggersCounter}" +
                    $". {vlogger.Key} : " +
                    $"{vlogger.Value["following"].Count} followers, " +
                    $"{vlogger.Value["joining"].Count} following");

                if (vloggersCounter == 1)
                {
                    foreach (var item in vlogger.Value["following"])
                    {
                        Console.WriteLine($"*  {item}");
                    }

                }

            }

        }
    }
}
