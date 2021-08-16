﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitApp = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Please specify a report to run (emails, tasks, comments) or exit to quit app: ");
                var selectedReport = Console.ReadLine();

                Console.WriteLine("Please specify which quarter of date (q1, q2)");
                var selectedData = Console.ReadLine();

                var surveryResults = JsonConvert.DeserializeObject<SurveyResults>(File.ReadAllText($"data/{selectedData}.json"));

                switch (selectedReport)
                {
                    case "emails":
                        GenerateWinnerEmails(surveryResults);
                        break;

                    case "tasks":
                        GenerateTasksReport(surveryResults);
                        break;

                    case "comments":
                        GenerateCommentsReport(surveryResults);
                        break;

                    case "exit":
                        quitApp = true;
                        break;

                    default:
                        Console.WriteLine("Please specify a valid report");
                        break;
                }

                Console.WriteLine();
            }
            while (!quitApp);




        }

        public static void GenerateWinnerEmails(SurveyResults results)
        {
            var selectedEmails = new List<string>();
            int counter = 0;

            Console.WriteLine(Environment.NewLine + "Selected Winners Output:");
            while (selectedEmails.Count < 2 && counter < results.Responses.Count)
            {
                var currentItem = results.Responses[counter];

                if (currentItem.FavoriteProduct == results.FavoriteProduct)
                {
                    selectedEmails.Add(currentItem.EmailAddress);
                    Console.WriteLine(currentItem.EmailAddress);
                }

                counter++;
            }

            File.WriteAllLines("WinnersReport.csv", selectedEmails);
        }

        public static void GenerateCommentsReport(SurveyResults results)
        {
            var comments = new List<string>();

            Console.WriteLine(Environment.NewLine + "Comments Output:");
            for (var i = 0; i < results.Responses.Count; i++)
            {
                var currentResponse = results.Responses[i];

                if (currentResponse.WouldRecommend < 7.0)
                {
                    Console.WriteLine(currentResponse.Comments);
                    comments.Add(currentResponse.Comments);
                }
            }

            foreach (var response in results.Responses)
            {
                if (response.AreaToImprove == results.AreaToImprove)
                {
                    Console.WriteLine(response.Comments);
                    comments.Add(response.Comments);
                }
            }

            File.WriteAllLines("CommentsReport.csv", comments);
        }

        public static void GenerateTasksReport(SurveyResults results)
        {
            var tasks = new List<string>();

            double responseRate = results.NumberResponded / results.NumberSurveyed;
            double overallScore = (results.ServiceScore + results.CoffeeScore + results.FoodScore + results.PriceScore) / 4;

            if (results.CoffeeScore < results.FoodScore)
            {
                tasks.Add("Investigate coffee recipes and ingredients.");
            }

            if (overallScore > 8.0)
            {
                tasks.Add("Work with leadership to reward staff");
            }
            else
            {
                tasks.Add("Work with employees for improvement ideas.");
            }

            if (responseRate < .33)
            {
                tasks.Add("Research options to improve response rate.");
            }
            else if (responseRate > .33 && responseRate < .66)
            {
                tasks.Add("Reward participants with free coffee coupon.");
            }
            else
            {
                tasks.Add("Rewards participants with discount coffee coupon.");
            }

            switch (results.AreaToImprove)
            {
                case  "RewardsProgram":
                    tasks.Add("Revisit the rewards deals.");
                    break;
                case "Cleanliness":
                    tasks.Add("Contact the cleaning vendor.");
                    break;
                case "MobileApp":
                    tasks.Add("Contact the consulting firm about app.");
                    break;
                default:
                    tasks.Add("Investigate individual comments for ideas.");
                    break;
            }

            Console.WriteLine(Environment.NewLine + "Tasks Output:");
            foreach(var task in tasks)
            {
                Console.WriteLine(task);
            }

            File.WriteAllLines("TasksReport.csv", tasks);
        }
    }
}
