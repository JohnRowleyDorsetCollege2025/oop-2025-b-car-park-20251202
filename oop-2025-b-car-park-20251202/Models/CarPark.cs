using System;
using System.Collections.Generic;
using System.Linq;

abstract class CarPark
{
    public string Name { get; }

    protected CarPark(string name)
    {
        Name = name;
    }

    // Each car park will implement its own charging rules
    public abstract decimal CalculateCharge(int hours);

    // Helper method to calculate total for a list of stays
    public decimal CalculateTotal(List<int> stays)
    {
        decimal total = 0;

        foreach (var hours in stays)
        {
            total += CalculateCharge(hours);
        }

        return total;
    }
}

class CarParkA : CarPark
{
    public CarParkA() : base("Car Park A")
    {
    }

    // €2 per hour, max €12 per day
    public override decimal CalculateCharge(int hours)
    {
        decimal charge = hours * 2m;
        return Math.Min(charge, 12m);
    }
}

class CarParkB : CarPark
{
    public CarParkB() : base("Car Park B")
    {
    }

    // First 2 hours €3/hour, then €1.50/hour, max €15 per day
    public override decimal CalculateCharge(int hours)
    {
        if (hours <= 2)
        {
            return hours * 3m;
        }

        decimal charge = (2 * 3m) + ((hours - 2) * 1.5m);
        return Math.Min(charge, 15m);
    }
}

class CarParkC : CarPark
{
    public CarParkC() : base("Car Park C")
    {
    }

    // €1.80 per hour, no maximum
    public override decimal CalculateCharge(int hours)
    {
        return hours * 1.8m;
    }
}

public static class CarParkCalculatorApp
{
    public static void Run()
    {
        // Create car park objects
        var carParkA = new CarParkA();
        var carParkB = new CarParkB();
        var carParkC = new CarParkC();

        // Sample input data: list of stays (in hours) per car park
        var staysForA = new List<int> { 2, 5, 10 };
        var staysForB = new List<int> { 1, 3, 9 };
        var staysForC = new List<int> { 4, 8 };

        // Store them in a list to make looping easier
        var carParks = new List<(CarPark carPark, List<int> stays)>
        {
            (carParkA, staysForA),
            (carParkB, staysForB),
            (carParkC, staysForC)
        };

        decimal grandTotal = 0;

        foreach (var entry in carParks)
        {
            CarPark carPark = entry.carPark;
            List<int> stays = entry.stays;

            decimal total = carPark.CalculateTotal(stays);
            grandTotal += total;

            Console.WriteLine($"{carPark.Name} total: €{total:F2}");
        }

        Console.WriteLine($"Grand total for all car parks: €{grandTotal:F2}");
    }
}
