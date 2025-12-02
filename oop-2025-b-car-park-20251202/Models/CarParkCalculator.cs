using System;
using System.Collections.Generic;
using System.Text;

namespace oop_2025_b_car_park_20251202.Models;

public static class CarParkCalculator
{
    public static decimal CalculateTotalForCarPark(List<int> stays, char carPark)
    {
        decimal total = 0;

        foreach (var hours in stays)
        {
            total += CalculateCharge(hours, carPark);
        }

        return total;
    }

    public static decimal CalculateCharge(int hours, char carPark)
    {
        switch (carPark)
        {
            case 'A':
                return CalculateCarParkA(hours);

            case 'B':
                return CalculateCarParkB(hours);

            case 'C':
                return CalculateCarParkC(hours);

            default:
                throw new ArgumentException("Invalid car park identifier");
        }
    }

    public static decimal CalculateCarParkA(int hours)
    {
        decimal charge = hours * 2m;
        return Math.Min(charge, 12m);
    }

    public static decimal CalculateCarParkB(int hours)
    {
        if (hours <= 2)
        {
            return hours * 3m;
        }

        decimal charge = (2 * 3m) + ((hours - 2) * 1.5m);
        return Math.Min(charge, 15m);
    }

    // Car Park C: €1.80/hour, no max
    public static decimal CalculateCarParkC(int hours)
    {
        return hours * 1.8m;
    }


}