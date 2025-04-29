// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogSamplingFileConfig;

internal static class Program
{
    public static void Main()
    {
        var hostBuilder = Host.CreateApplicationBuilder();
        hostBuilder.Logging.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "hh:mm:ss";
        });

        // Add the Random probabilistic sampler to the logging pipeline.
        hostBuilder.Logging.AddRandomProbabilisticSampler(hostBuilder.Configuration);

        var app = hostBuilder.Build();
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("SamplingDemo");

        while (true)
        {
            Log.EnteredWhileLoop(logger);
            Log.NoisyMessage(logger);
            Log.LeftWhileLoop(logger);

            Thread.Sleep(100);
        }
    }
}
