// See https://aka.ms/new-console-template for more information
using oop_2025_b_car_park_20251202.Models;
//Ensures the console can display the Euro symbol correctly
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("CarPark Calculator");

var carParkA = new List<int> { 2, 5, 10 };
var carParkB = new List<int> { 1, 3, 9 };
var carParkC = new List<int> { 4, 8 };

decimal totalA = CarParkCalculator.CalculateTotalForCarPark(carParkA, 'A');
decimal totalB = CarParkCalculator.CalculateTotalForCarPark(carParkB, 'B');
decimal totalC = CarParkCalculator.CalculateTotalForCarPark(carParkC, 'C');

decimal grandTotal = totalA + totalB + totalC;

Console.WriteLine($"Total for Car Park A: €{totalA:F2}");
Console.WriteLine($"Total for Car Park B: €{totalB:F2}");
Console.WriteLine($"Total for Car Park C: €{totalC:F2}");
Console.WriteLine($"Grand Total: €{grandTotal:F2}");

Console.WriteLine(new string('-', 40));

CarParkCalculatorApp.Run();

Console.WriteLine(new string('-', 40));

CarParkCalculatorAppWithRate.Run();