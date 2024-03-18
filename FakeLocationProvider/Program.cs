using FakeLocationProvider.Extensions;
using FakeLocationProvider.Utils;
using LiveSim.Core.Entities;
using System.Diagnostics;

const string API_BASEADDRESS = "https://localhost:7205";
const double STEP = 0.000001;

var initalLocation = new GpsLocation { Latitude = 49.94319, Longitude = 7.44446 };
var soldiers = new EntityLocationFactory(initalLocation).Create(EntityType.Soldier, 20, 30);

var cts = new CancellationTokenSource();
var token = cts.Token;

HttpClient httpClient = new()
{
    BaseAddress = new Uri(API_BASEADDRESS),
};

var task = Task.Factory.StartNew(async () =>
{
    var count = 0;
    while (!token.IsCancellationRequested)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await soldiers.PostAsJsonAsync(httpClient, token);
        Console.WriteLine($"Sending {soldiers.Count()} positions took {stopwatch.ElapsedMilliseconds} ms");

        soldiers = soldiers.Transform(direction: count % 4, STEP);

        count++;
    }

    // Task completed
}, token);

Console.WriteLine("Press Enter to terminate...");
Console.ReadLine();

// Cancel the task
cts.Cancel();