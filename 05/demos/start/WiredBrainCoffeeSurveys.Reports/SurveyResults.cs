using System;
using System.Collections.Generic;
using System.Text;

namespace WiredBrainCoffeeSurveys.Reports
{
    public static class Q1Results
    {
        // Aggregate ratings
        public static double ServiceScore { get; set; }

        public static double CoffeeScore { get; set; }

        public static double PriceScore { get; set; }

        public static double FoodScore { get; set; }

        public static double WouldRecommend { get; set; } 

        public static string FavoriteProduct { get; set; } 

        public static string LeastFavoriteProduct { get; set; } 

        public static string AreaToImprove { get; set; } 

        // Aggregate counts
        public static double NumberSurveyed { get; set; }

        public static double NumberResponded { get; set; } 

        public static double NumberRewardsMembers { get; set; } 

        // Individual survey responses
        public static List<SurveyResponse> Responses { get; set; }      
      }
}
