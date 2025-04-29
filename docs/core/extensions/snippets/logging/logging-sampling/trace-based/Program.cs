// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace LogSamplingTraceBased;

internal static class Program
{
    private static readonly ActivitySource DemoSource = new("LogSamplingTraceBased");

    public static void Main()
    {
        var hostBuilder = Host.CreateApplicationBuilder();
        hostBuilder.Logging.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "hh:mm:ss";
        });

        // Add the Random probabilistic sampler to the logging pipeline.
        hostBuilder.Logging.AddTraceBasedSampler();

        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            // enable Tracing sampling configured with 50% probability:
            .SetSampler(new TraceIdRatioBasedSampler(0.5))
            .AddSource("LogSamplingTraceBased")
            .AddConsoleExporter()
            .Build();

        var app = hostBuilder.Build();
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("SamplingDemo");

        // on average, 50% of Activities and logs will be sampled:
        for (int i = 0; i < 10; i++)
        {
            using var activity = DemoSource.StartActivity("SayHello");
            activity?.SetTag("foo", "bar");
            activity?.SetStatus(ActivityStatusCode.Ok);

            // the parent activity is sampled with 50% probability,
            // and the same sampling decision will be used for logging
            logger.NoisyMessage(i);
        }

        tracerProvider.Dispose();
    }
}
