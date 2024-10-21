// See https://aka.ms/new-console-template for more information

namespace AsyncAwaitTea;

internal static class Program
{
    private static void Main(string[] args)
    {
        BrewWater();
        CleanCup();
        AddTeaToCup();
        AddWaterToCup();
    }

    private static void BrewWater()
    {
        Console.WriteLine("Beginne das Wasser zu kochen");
        Task.Delay(2000).Wait();
        Console.WriteLine("Wasser ist fertig");
    }

    private static void CleanCup()
    {
        Console.WriteLine("Reinige die Tasse");
        Task.Delay(1000).Wait();
    }

    private static void AddTeaToCup()
    {
        Console.WriteLine("Füge Tee zur Tasse hinzu");
        Task.Delay(1000).Wait();
    }

    private static void AddWaterToCup()
    {
        Console.WriteLine("Füge Wasser zur Tasse hinzu");
        Task.Delay(1000).Wait();
    }
}