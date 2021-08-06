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
    })
    .ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Warning))
    .Build();

(MessageService messageService, ILogger<MessageService> logger) =
    GetRequiredServices<MessageService, ILogger<MessageService>>(host.Services);

logger.LogWarning(messageService.GetGreetingMessage());
logger.LogWarning(messageService.GetFormattedMessage(DateTime.Today.AddDays(-3), 37.63));

await host.RunAsync();

static (TServiceOne one, TServiceTwo two) GetRequiredServices<TServiceOne, TServiceTwo>(
    IServiceProvider services)
    where TServiceOne : notnull
    where TServiceTwo : notnull =>
    (services.GetRequiredService<TServiceOne>(), services.GetRequiredService<TServiceTwo>());
