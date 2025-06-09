// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Buffering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Log = GlobalLogBufferingFileBased.Log;

var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
    options.UseUtcTimestamp = true;
});

// Add the Global buffer to the logging pipeline.
hostBuilder.Logging.AddGlobalBuffer(hostBuilder.Configuration.GetSection("Logging"));

using var app = hostBuilder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("BufferingDemo");
var buffer = app.Services.GetRequiredService<GlobalLogBuffer>();

for (int i = 1; i < 21; i++)
{
    try
    {
        Log.InformationMessage(logger);

        if(i % 10 == 0)
        {
           throw new Exception("Simulated exception");
        }
    }
    catch (Exception ex)
    {
        Log.ErrorMessage(logger, ex.Message);
        buffer.Flush();
    }

    await Task.Delay(1000).ConfigureAwait(false);
}
