using System;
using System.Globalization;
using Localization.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using static System.Console;
using static System.Text.Encoding;

[assembly: RootNamespace("Localization.Example")]

OutputEncoding = Unicode;

if (args is { Length: 1 })
{
    CultureInfo.CurrentCulture =
        CultureInfo.CurrentUICulture =
            CultureInfo.GetCultureInfo(args[0]);
}

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddLocalization();
        services.AddTransient<MessageService>();
        services.AddTransient<ParameterizedMessageService>();
    })
    .ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Warning))
    .Build();

var services = host.Services;

MessageService messageService =
    services.GetRequiredService<MessageService>();
ParameterizedMessageService parameterizedMessageService =
    services.GetRequiredService<ParameterizedMessageService>();
ILogger logger =
    services.GetRequiredService<ILoggerFactory>()
        .CreateLogger("Localization.Example");

logger.LogWarning(messageService.GetGreetingMessage());
logger.LogWarning(parameterizedMessageService.GetFormattedMessage(DateTime.Today.AddDays(-3), 37.63));

await host.RunAsync();
