using OpenTelemetry;
using OpenTelemetry.Metrics;
using System.Diagnostics.Metrics;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold =s_meter.CreateCounter<int>(name: "hats-sold",
                                                               unit: "Hats",
                             description: "The number of hats sold in our store");

    static void Main(string[] args)
    {
        using MeterProvider meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter("HatCo.HatStore")
                .AddPrometheusExporter(opt =>
                {
                    opt.StartHttpListener = true;
                    opt.HttpListenerPrefixes = new string[] { $"http://localhost:9184/" };
                })
                .Build();

        var rand = new Random();
        Console.WriteLine("Press any key to exit");
        while (!Console.KeyAvailable)
        {
            // Pretend our store has a transaction each second that sells 4 hats
            Thread.Sleep(rand.Next(100, 1500));
            s_hatsSold.Add(rand.Next(0,1000));
        }
    }
}