using System;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculated Values
            double responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed;
            double unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;
            double overallScore = (Q1Results.CoffeeScore + Q1Results.FoodScore + Q1Results.PriceScore + Q1Results.ServiceScore) / 4;

            Console.WriteLine($"Response rate = {responseRate}");
            Console.WriteLine($"Unanswered surveys = {unansweredCount}");
            Console.WriteLine($"Overall score = {overallScore}");

            // Logical Comparisons
            bool higherCoffeScore = Q1Results.CoffeeScore > Q1Results.FoodScore;
            bool customersRecommend = Q1Results.WouldRecommend >= 7;
            bool noGranolaYesCappucinio = Q1Results.LeastFavoriteProduct == "Granola" && Q1Results.FavoriteProduct == "Cappucino"; 


            Console.WriteLine($"Coffee score is higher than food score = {higherCoffeScore}");
            Console.WriteLine($"Customers would recommend us = {customersRecommend}");
            Console.WriteLine($"Hate Granola, Love Cap = {noGranolaYesCappucinio}");
        }
    }
}
