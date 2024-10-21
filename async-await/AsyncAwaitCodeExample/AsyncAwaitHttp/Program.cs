// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information

namespace AsyncAwaitHttp;

internal static class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        Console.WriteLine("Get Google!");
        var task1 = client.GetStringAsync("https://google.com");
        
        Console.WriteLine(await task1);
        Console.WriteLine("Get Bing!");
        var task2 = client.GetStringAsync("https://bing.com");
    
        Console.WriteLine(await task2);
        Console.WriteLine("Done!");
    }
}