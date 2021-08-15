using System;
using System.Collections.Generic;

namespace WiredBrainCoffeeSurveys.Reports
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<string>();

            // Calculated Values
            double responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed;
            double unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;
            double overallScore = (Q1Results.CoffeeScore + Q1Results.FoodScore + Q1Results.PriceScore + Q1Results.ServiceScore) / 4;

            if (Q1Results.CoffeeScore < Q1Results.FoodScore)
            {
                tasks.Add("Investigate coffee recipes and ingredients"); 
             }

            if (overallScore > 8)
            {
                tasks.Add("Work with leadership to reward staff");
            }
            else
            {
                tasks.Add("Work with staff on ways to improve");
            }

            if (responseRate < 0.33)
            {
                tasks.Add("Work to improve response rate");
            }
            else if (responseRate > 0.33 && responseRate < 0.66)
            {
                tasks.Add("Send out free coffee coupon");
            }
            else
            {
                tasks.Add("Send out discount coffee coupon"); 
            }
        }
    }
}
