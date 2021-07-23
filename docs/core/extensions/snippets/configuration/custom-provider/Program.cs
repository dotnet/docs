﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CustomProvider.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var options = host.Services.GetRequiredService<IOptions<WidgetOptions>>().Value;
            Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
            Console.WriteLine($"EndpointId={options.EndpointId}");
            Console.WriteLine($"WidgetRoute={options.WidgetRoute}");

            await host.RunAsync();
        }
        // Sample output:
        //    WidgetRoute=api/widgets
        //    EndpointId=b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67
        //    DisplayLabel=Widgets Incorporated, LLC.

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddEntityConfiguration();
                })
                .ConfigureServices((context, services) =>
                    services.Configure<WidgetOptions>(
                        context.Configuration.GetSection("WidgetOptions")));
    }
}
