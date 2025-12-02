using System;
using System.Collections.Generic;
using System.Text;

namespace oop_2025_b_car_park_20251202.Models
{
    public class Rate
    {
        public decimal FirstTierRate { get; }
        public int FirstTierHours { get; }
        public decimal AdditionalRate { get; }
        public decimal? DailyMaximum { get; }

        // Constructor for tiered rates
        public Rate(decimal firstTierRate, int firstTierHours, decimal additionalRate, decimal? dailyMaximum = null)
        {
            FirstTierRate = firstTierRate;
            FirstTierHours = firstTierHours;
            AdditionalRate = additionalRate;
            DailyMaximum = dailyMaximum;
        }

        // Constructor for flat rate (no tier)
        public Rate(decimal flatRate, decimal? dailyMaximum = null)
        {
            FirstTierRate = flatRate;
            FirstTierHours = int.MaxValue; // Entire stay is first tier
            AdditionalRate = flatRate;
            DailyMaximum = dailyMaximum;
        }
    }

}
