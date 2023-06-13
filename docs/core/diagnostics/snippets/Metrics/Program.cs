#define ML  // FIRST // ML
#if NEVER
#elif FIRST
// <snippet_1>
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
            // Simulate selling hats.
            Thread.Sleep(rand.Next(100, 2500));
            s_hatsSold.Add(rand.Next(0,1000));
        }
    }
}
// </snippet_1>
#elif ML
// </snippet_ml>
using System.Diagnostics.Metrics;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold =
               s_meter.CreateCounter<int>(name: "hats-sold",
                                          unit: "Hats",
                                   description: "The number of ats sold in our store");

    static void Main(string[] args)
    {
        using MeterListener meterListener = new MeterListener();
        meterListener.InstrumentPublished = (instrument, listener) =>
        {
            if (instrument.Meter.Name == "HatCo.HatStore")
            {
                listener.EnableMeasurementEvents(instrument);
            }
        };
        meterListener.SetMeasurementEventCallback<int>(OnMeasurementRecorded);
        meterListener.Start();

        var rand = new Random();
        Console.WriteLine("Press any key to exit");
        while (!Console.KeyAvailable)
        {
            // Simulate selling hats.
            Thread.Sleep(rand.Next(100, 2500));
            s_hatsSold.Add(rand.Next(0, 1000));
        }
    }

    static void OnMeasurementRecorded<T>(Instrument instrument, T measurement,
                       ReadOnlySpan<KeyValuePair<string, object>> tags, object state)
    {
        Console.WriteLine($"{instrument.Name} recorded measurement {measurement}");
    }
}
// </snippet_ml>
#endif
