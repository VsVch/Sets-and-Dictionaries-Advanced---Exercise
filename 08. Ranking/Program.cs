using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> ranks = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputArray = input.Split(":");
                string contest = inputArray[0];
                string password = inputArray[1];
                if (!ranks.ContainsKey(contest))
                {
                    ranks.Add(contest, password);
                }
                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> examPoints = new Dictionary<string, Dictionary<string, int>>();
            string inputTwo = Console.ReadLine();
            while (inputTwo != "end of submissions")
            {
                string[] inputArray = inputTwo.Split("=>");

                string contest = inputArray[0];
                string password = inputArray[1];
                string username = inputArray[2];
                int points = int.Parse(inputArray[3]);

                if (ranks.ContainsKey(contest) && ranks[contest] == password)
                {

                    if (!examPoints.ContainsKey(username))
                    {
                        examPoints.Add(username, new Dictionary<string, int>());
                    }

                    if (!examPoints[username].ContainsKey(contest))
                    {
                        examPoints[username].Add(contest, points);
                    }

                    if (examPoints[username][contest] < points)
                    {
                        examPoints[username][contest] = points;
                    }
                }

                inputTwo = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = examPoints.OrderByDescending(v => v.Value.Values.Sum()).First();

            int bestCandidatePoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var name in examPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{name.Key}");

                foreach (var item in name.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
