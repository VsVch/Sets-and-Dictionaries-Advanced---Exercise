using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            Dictionary<string, int> submishions = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, double>> userData = new Dictionary<string, Dictionary<string, double>>();
            while (input != "exam finished")
            {
                string[] inputArray = input.Split("-");
                string username = inputArray[0];
                string language = inputArray[1];
                if (language == "banned")
                {
                    userPoints.Remove(username);
                    input = Console.ReadLine();
                    continue;
                }
                int points = int.Parse(inputArray[2]);
                if (!userPoints.ContainsKey(username))
                {
                    userPoints[username] = 0;
                }
                userPoints[username] = Math.Max(userPoints[username], points);
                if (!submishions.ContainsKey(language))
                {
                    submishions[language] = 0;
                }
                submishions[language] += 1;

                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key + " | " + kvp.Value);
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in submishions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }
}
