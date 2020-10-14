---
title: Configuration differences between ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Configuration differences between ASP.NET MVC and ASP.NET Core

How configuration values are stored and read changed dramatically between ASP.NET and ASP.NET Core.

## ASP.NET MVC configuration

In ASP.NET apps, configuration uses the built-in .NET configuration files, web.config in the app folder and machine.config on the server. Most ASP.NET MVC and Web API apps store any settings they need in the configuration file's appsettings or connection strings elements. Some also use custom configuration sections that can be mapped to a settings class.

Configuration in .NET applications is accessed using the `System.Configuration.ConfigurationManager` class. Unfortunately, this class provides static access to the config elements, and as a result very few ASP.NET MVC apps tend to abstract access to their configuration settings or inject them where needed. Instead, most .NET apps tend to directly access the configuration system anywhere the app needs to use a setting.

Typical ASP.NET MVC configuration access:

```csharp
string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"]
    .ConnectionString;
```

## ASP.NET Core configuration

In ASP.NET Core apps, configuration is, itself, configurable. However, most apps use a set of defaults provided as part of the standard project templates and the `ConfigureWebHostDefaults` method used in them. The default settings use JSON formatted files, with the ability to override settings in the base `appsettings.json` file with environment-specific files like `appsettings.Development.json`. Additionally, the default configuration system further overrides all file-based settings with any environment variable that exists for the same named setting. This is useful in a number of scenarios, and is especially useful when deploying to a hosting environment, since it eliminates the need to worry about whether deploying configuration files will accidentally overwrite important production configuration settings.

Accessing configuration values can be done in a number of ways in .NET Core. Because dependency injection is built into .NET Core, configuration values are generally accessed through an interface that is injected into classes that need them. This can involve passing a large interface like IConfiguration, but usually it's better to pass just the settings required by the class using the [options pattern](https://docs.microsoft.com/aspnet/core/fundamentals/configuration/options).

Figure 2-2 shows how to pass `IConfiguration` into a Razor Page and access configuration settings from it:

```csharp
public class TestModel : PageModel
{
    // requires using Microsoft.Extensions.Configuration;
    private readonly IConfiguration Configuration;

    public TestModel(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ContentResult OnGet()
    {
        var myKeyValue = Configuration["MyKey"];
    }
}
```

**Figure 2-2. Accessing configuration values with IConfiguration.**

Using the options pattern, settings access is similar but is strongly typed and more specific to the setting(s) needed by the consuming class, as Figure 2-3 demonstrates.

```csharp
public class PositionOptions
{
    public const string Position = "Position";

    public string Title { get; set; }
    public string Name { get; set; }
}

public class Test2Model : PageModel
{
    private readonly PositionOptions _options;

    public Test2Model(IOptions<PositionOptions> options)
    {
        _options = options.Value;
    }

    public ContentResult OnGet()
    {
        return Content($"Title: {_options.Title} \n" +
                       $"Name: {_options.Name}");
    }
}
```

**Figure 2-3. Using the options pattern in ASP.NET Core.**

For the options pattern to work, the options type must be configured in `ConfigureServices` when the app starts up:

```csharp
// required in ConfigureServices
services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));
```

## Migrating configuration

When considering how to port an app's configuration settings from .NET to .NET Core, the first step is to identify all of the configuration settings that are being used. Most of these will be in the web.config file in the app's root folder, but some apps expect settings to be found in the shared machine.config file as well.

Once all settings in the config files have been cataloged, the next step should be to identify where and how the settings are used in the app itself. If some settings aren't being used, these can probably be omitted from the migration. For each setting, note all of the places it's being used so you can be sure you don't miss any when you migrate the code.

If you're still maintaining the ASP.NET app, it may be helpful to avoid static references to `ConfigurationManager` and replace them with access through interfaces. This will ease the transition to ASP.NET Core's configuration system. In general, static access to external resources makes code harder to test and maintain, so be on the lookout for anywhere else the app may be following this pattern.

## References

- [Configuration in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/configuration/)
- [Options pattern in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/configuration/options)
- [Migrate configuration to ASP.NET Core](https://docs.microsoft.com/aspnet/core/migration/configuration)
- [Refactoring Static Config Access](https://ardalis.com/refactoring-static-config-access/)

>[!div class="step-by-step"]
>[Previous](middleware-modules-handlers.md)
>[Next](routing-differences.md)
