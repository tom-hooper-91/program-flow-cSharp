using System;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            double responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed;
            double unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;

            Console.WriteLine($"Response rate = {responseRate}");
            Console.WriteLine($"Unanswered surveys = {unansweredCount}");
        }
    }
}
