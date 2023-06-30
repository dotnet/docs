﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddColorConsoleLogger(configuration =>
{
    // Replace warning value from appsettings.json of "Cyan"
    configuration.LogLevelToColorMap[LogLevel.Warning] = ConsoleColor.DarkCyan;
    // Replace warning value from appsettings.json of "Red"
    configuration.LogLevelToColorMap[LogLevel.Error] = ConsoleColor.DarkRed;
});

using IHost host = builder.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogDebug(1, "Does this line get hit?");    // Not logged
logger.LogInformation(3, "Nothing to see here."); // Logs in ConsoleColor.DarkGreen
logger.LogWarning(5, "Warning... that was odd."); // Logs in ConsoleColor.DarkCyan
logger.LogError(7, "Oops, there was an error.");  // Logs in ConsoleColor.DarkRed
logger.LogTrace(5, "== 120.");                    // Not logged

await host.RunAsync();
