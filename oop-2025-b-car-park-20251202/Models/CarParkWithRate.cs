using System;
using System.Collections.Generic;
using System.Text;

namespace oop_2025_b_car_park_20251202.Models;

public abstract class CarPark
{
    public string Name { get; }
    public Rate Pricing { get; }

    protected CarPark(string name, Rate rate)
    {
        Name = name;
        Pricing = rate;
    }

    public abstract decimal CalculateCharge(int hours);

    public decimal CalculateTotal(List<int> stays)
    {
        decimal total = 0;

        foreach (var h in stays)
        {
            total += CalculateCharge(h);
        }

        return total;
    }
}

public class CarParkA : CarPark
{
    public CarParkA(Rate rate) : base("Car Park A", rate) { }

    public override decimal CalculateCharge(int hours)
    {
        decimal charge = hours * Pricing.FirstTierRate;

        if (Pricing.DailyMaximum.HasValue)
            charge = Math.Min(charge, Pricing.DailyMaximum.Value);

        return charge;
    }
}

public class CarParkB : CarPark
{
    public CarParkB(Rate rate) : base("Car Park B", rate) { }

    public override decimal CalculateCharge(int hours)
    {
        decimal charge;

        if (hours <= Pricing.FirstTierHours)
        {
            charge = hours * Pricing.FirstTierRate;
        }
        else
        {
            charge =
                (Pricing.FirstTierHours * Pricing.FirstTierRate) +
                ((hours - Pricing.FirstTierHours) * Pricing.AdditionalRate);
        }

        if (Pricing.DailyMaximum.HasValue)
            charge = Math.Min(charge, Pricing.DailyMaximum.Value);

        return charge;
    }
}

public class CarParkC : CarPark
{
    public CarParkC(Rate rate) : base("Car Park C", rate) { }

    public override decimal CalculateCharge(int hours)
    {
        return hours * Pricing.FirstTierRate;
    }
}

public static class CarParkCalculatorAppWithRate
{
    public static void Run()
    {
        var carParkA = new CarParkA(new Rate(flatRate: 2m, dailyMaximum: 12m));
        var carParkB = new CarParkB(new Rate(firstTierRate: 3m, firstTierHours: 2, additionalRate: 1.5m, dailyMaximum: 15m));
        var carParkC = new CarParkC(new Rate(flatRate: 1.8m));


        var staysA = new List<int> { 2, 5, 10 };
        var staysB = new List<int> { 1, 3, 9 };
        var staysC = new List<int> { 4, 8 };

        var carParks = new List<CarPark> { carParkA, carParkB, carParkC };

        decimal grandTotal = 0;

        foreach (var cp in carParks)
        {
            decimal total = cp.CalculateTotal(
                cp == carParkA ? staysA :
                cp == carParkB ? staysB : staysC);

            grandTotal += total;

            Console.WriteLine($"{cp.Name} total: €{total:F2}");
        }

        Console.WriteLine($"Grand Total: €{grandTotal:F2}");

    }
}




