using ConsoleJson.Example;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddOptions<SettingsOptions>()
    .Bind(builder.Configuration.GetSection(SettingsOptions.ConfigurationSectionName));

builder.Services
    .AddSingleton<IValidateOptions<SettingsOptions>, ValidateSettingsOptions>();

using IHost app = builder.Build();

var settingsOptions =
    app.Services.GetRequiredService<IOptions<SettingsOptions>>().Value;

await app.RunAsync();
