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

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddLocalization();
builder.Services.AddTransient<MessageService>();
builder.Services.AddTransient<ParameterizedMessageService>();
builder.Logging.SetMinimumLevel(LogLevel.Warning);

using IHost host = builder.Build();

IServiceProvider services = host.Services;

ILogger logger =
    services.GetRequiredService<ILoggerFactory>()
        .CreateLogger("Localization.Example");

MessageService messageService =
    services.GetRequiredService<MessageService>();
logger.LogWarning(
    "{Msg}",
    messageService.GetGreetingMessage());

ParameterizedMessageService parameterizedMessageService =
    services.GetRequiredService<ParameterizedMessageService>();
logger.LogWarning(
    "{Msg}",
    parameterizedMessageService.GetFormattedMessage(
        DateTime.Today.AddDays(-3), 37.63));

await host.RunAsync();
