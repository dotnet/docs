// <TracingConfiguration>
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Tracing;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Tracing:EnabledTracing:Default"] = "false",
        ["Tracing:EnabledTracing:Contoso.Orders:Default"] = "true",
        ["Tracing:EnabledTracing:Contoso.Orders:DisabledOperation"] = "false",
    })
    .Build();

ServiceCollection services = new();
services.AddTracing(tracing =>
{
    tracing.AddListener("Console", listener =>
    {
        listener.Sample = static (ref ActivityCreationOptions<ActivityContext> _) =>
            ActivitySamplingResult.AllData;
        listener.SampleUsingParentId = static (ref ActivityCreationOptions<string> _) =>
            ActivitySamplingResult.AllData;
        listener.ActivityStarted = activity =>
            Console.WriteLine($"Listener started: {activity.OperationName}");
    });
    tracing.AddConfiguration(configuration.GetSection("Tracing"));
});

using ServiceProvider serviceProvider = services.BuildServiceProvider();
ActivitySourceFactory factory =
    serviceProvider.GetRequiredService<ActivitySourceFactory>();
using ActivitySource source = factory.Create("Contoso.Orders");

Console.WriteLine("Before reload:");
WriteResult(source, "EnabledOperation");
WriteResult(source, "DisabledOperation");

configuration["Tracing:EnabledTracing:Contoso.Orders:DisabledOperation"] = "true";
configuration.Reload();

Console.WriteLine("After reload:");
WriteResult(source, "DisabledOperation");

static void WriteResult(ActivitySource source, string operationName)
{
    using Activity? activity = source.StartActivity(operationName);
    string state = activity is null ? "disabled" : "enabled";
    Console.WriteLine($"{operationName}: {state}");
}
// </TracingConfiguration>
