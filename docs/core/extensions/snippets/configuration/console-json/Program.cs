using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ConsoleJson.Example;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();

        IHostEnvironment env = hostingContext.HostingEnvironment;

        configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

        IConfigurationRoot configurationRoot = configuration.Build();

        TransientFaultHandlingOptions options = new();
        configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
                         .Bind(options);

        Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
        Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
    })
    .Build();

// Application code should start here.

await host.RunAsync();

// <Output>
// Sample output:
//    TransientFaultHandlingOptions.Enabled=True
//    TransientFaultHandlingOptions.AutoRetryDelay=00:00:07
// </Output>
