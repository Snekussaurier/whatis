using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Text.Json;

BenchmarkSwitcher.FromAssembly(typeof(Tests).Assembly).Run(args);

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public partial class Tests
{
    private IEnumerable<int> _enumerable;

    [Params(500, 5000, 15000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Setup() => _enumerable = Enumerable.Range(0, Count).ToList();

    [Benchmark]
    public int Sum()
    {
        int sum = 0;
        foreach (int item in _enumerable) sum += item;
        return sum;
    }
}

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public partial class Http2Benchmarks
{
    private WebApplication _app;

    [GlobalSetup]
    public async Task Setup()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Logging.SetMinimumLevel(LogLevel.Warning);
        builder.WebHost.ConfigureKestrel(o => o.ListenLocalhost(5000, listen => listen.Protocols = HttpProtocols.Http2));

        _app = builder.Build();
        _app.MapGet("/hello", () => Results.Text("hi from kestrel over h2c\n"));
        var serverTask = _app.RunAsync();
        await Task.Delay(300);
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        await _app.StopAsync();
        await _app.DisposeAsync();
    }

    [Benchmark]
    public async Task Get()
    {
        using var client = new HttpClient()
        {
            DefaultRequestVersion = HttpVersion.Version20,
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
        };

        var response = await client.GetAsync("http://localhost:5000/hello");
    }
}

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public partial class JsonSerializationBenchmarks
{
    private Data _data = new();
    private MemoryStream _stream = new();

    [Benchmark]
    public void Serialize()
    {
        _stream.Position = 0;
        JsonSerializer.Serialize(_stream, _data);
    }

    public class Data
    {
        public int Value1 { get; set; }
    }
}
