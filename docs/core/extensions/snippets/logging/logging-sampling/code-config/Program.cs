// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Sampling;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogSamplingCodeConfig;

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
        hostBuilder.Logging.AddRandomProbabilisticSampler(options =>
        {
            options.Rules.Add(
                new RandomProbabilisticSamplerFilterRule(
                    probability: .05d,
                    eventId : 1001));
        });

        var app = hostBuilder.Build();
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("SamplingDemo");

        for (int i = 0; i < 1_000_000; i++)
        {
            Log.NoisyMessage(logger);
        }
    }
}
