using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> teams = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                bool splitByLine = false;
                bool splitByArrow = false;
                var cmdSplitByLine = input.Split(" | ");
                var cmdSplitByArrow = input.Split(" -> ");

                if (cmdSplitByLine.Length == 2)
                    splitByLine = true;
                else if (cmdSplitByArrow.Length == 2)
                    splitByArrow = true;

                if (splitByLine)
                {
                    bool containsUser = false;
                    foreach (var team in teams)
                    {
                        if (team.Value.Contains(cmdSplitByLine[1]))
                            containsUser = true;
                    }

                    if (teams.ContainsKey(cmdSplitByLine[0]))
                    {

                        if (containsUser == false)
                        {
                            teams[cmdSplitByLine[0]].Add(cmdSplitByLine[1]);
                        }
                    }
                    else
                    {
                        teams.Add(cmdSplitByLine[0], new List<string>());
                        if (containsUser == false)
                        {
                            teams[cmdSplitByLine[0]].Add(cmdSplitByLine[1]);
                        }
                    }
                }

                else if (splitByArrow)
                {

                    foreach (var team in teams)
                    {
                        if (team.Value.Contains(cmdSplitByArrow[0]))
                            team.Value.Remove(cmdSplitByArrow[0]);

                    }
                    if (!teams.ContainsKey(cmdSplitByArrow[1]))
                    {
                        teams.Add(cmdSplitByArrow[1], new List<string>());
                    }

                    teams[cmdSplitByArrow[1]].Add(cmdSplitByArrow[0]);
                    Console.WriteLine($"{cmdSplitByArrow[0]} joins the {cmdSplitByArrow[1]} side!");
                }
                else continue;
                input = Console.ReadLine();
            }
            
            foreach (var kvp in teams.Where(x => x.Value.Count >= 1).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
