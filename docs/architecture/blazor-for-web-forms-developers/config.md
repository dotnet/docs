---
title: App configuration
description: Learn how to configure Blazor apps without using ConfigurationManager.
author: csharpfritz
ms.author: jefritz
no-loc: [Blazor]
ms.date: 12/2/2021
---
# App configuration

The primary way to load app configuration in Web Forms is with entries in the *web.config* file&mdash;either on the server or a related configuration file referenced by *web.config*. You can use the static `ConfigurationManager` object to interact with app settings, data repository connection strings, and other extended configuration providers that are added into the app. It's typical to see interactions with app configuration as seen in the following code:

```csharp
var configurationValue = ConfigurationManager.AppSettings["ConfigurationSettingName"];
var connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionName"].ConnectionString;
```

With ASP.NET Core and server-side Blazor, the *web.config* file MAY be present if your app is hosted on a Windows IIS server. However, there's no `ConfigurationManager` interaction with this configuration, and you can receive more structured app configuration from other sources. Let's take a look at how configuration is gathered and how you can still access configuration information from a *web.config* file.

## Configuration sources

ASP.NET Core recognizes there are many configuration sources you may want to use for your app. The framework attempts to offer you the best of these features by default. Configuration is read and aggregated from these various sources by ASP.NET Core. Later loaded values for the same configuration key take precedence over earlier values.

ASP.NET Core was designed to be cloud-aware and to make the configuration of apps easier for both operators and developers. ASP.NET Core is environment-aware and knows if it's running in your `Production` or `Development` environment. The environment indicator is set in the `ASPNETCORE_ENVIRONMENT` system environment variable. If no value is configured, the app defaults to running in the `Production` environment.

Your app can trigger and add configuration from several sources based on the environment's name. By default, the configuration is loaded from the following resources in the order listed:

1. *appsettings.json* file, if present
1. *appsettings.{ENVIRONMENT_NAME}.json* file, if present
1. User secrets file on disk, if present
1. Environment variables
1. Command-line arguments

## appsettings.json format and access

The *appsettings.json* file can be hierarchical with values structured like the following JSON:

```json
{
  "section0": {
    "key0": "value",
    "key1": "value"
  },
  "section1": {
    "key0": "value",
    "key1": "value"
  }
}
```

When presented with the preceding JSON, the configuration system flattens child values and references their fully qualified hierarchical paths. A colon (`:`) character separates each property in the hierarchy. For example, the configuration key `section1:key0` accesses the `section1` object literal's `key0` value.

## User secrets

User secrets are:

* Configuration values that are stored in a JSON file on the developer's workstation, outside of the app development folder.
* Only loaded when running in the `Development` environment.
* Associated with a specific app.
* Managed with the .NET CLI's `user-secrets` command.

Configure your app for secrets storage by executing the `user-secrets` command:

```dotnetcli
dotnet user-secrets init
```

The preceding command adds a `UserSecretsId` element to the project file. The element contains a GUID, which is used to associate secrets with the app. You can then define a secret with the `set` command. For example:

```dotnetcli
dotnet user-secrets set "Parent:ApiKey" "12345"
```

The preceding command makes the `Parent:ApiKey` configuration key available on a developer's workstation with the value `12345`.

For more information about creating, storing, and managing user secrets, see the [Safe storage of app secrets in development in ASP.NET Core](/aspnet/core/security/app-secrets) document.

## Environment variables

The next set of values loaded into your app configuration is the system's environment variables. All of your system's environment variable settings are now accessible to you through the configuration API. Hierarchical values are flattened and separated by colon characters when read inside your app. However, some operating systems don't allow the colon character environment variable names. ASP.NET Core addresses this limitation by converting values that have double-underscores (`__`) into a colon when they're accessed. The `Parent:ApiKey` value from the user secrets section above can be overridden with the environment variable `Parent__ApiKey`.

## Command-line arguments

Configuration can also be provided as command-line arguments when your app is started. Use the double-dash (`--`) or forward-slash (`/`) notation to indicate the name of the configuration value to set and the value to be configured. The syntax resembles the following commands:

```dotnetcli
dotnet run CommandLineKey1=value1 --CommandLineKey2=value2 /CommandLineKey3=value3
dotnet run --CommandLineKey1 value1 /CommandLineKey2 value2
dotnet run Parent:ApiKey=67890
```

## The return of web.config

If you've deployed your app to Windows on IIS, the *web.config* file still configures IIS to manage your app. By default, IIS adds a reference to the ASP.NET Core Module (ANCM). ANCM is a native IIS module that hosts your app in place of the Kestrel web server. This *web.config* section resembles the following XML markup:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath=".\MyApp.exe"
                  stdoutLogEnabled="false"
                  stdoutLogFile=".\logs\stdout"
                  hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
```

App-specific configuration can be defined by nesting an `environmentVariables` element in the `aspNetCore` element. The values defined in this section are presented to the ASP.NET Core app as environment variables. The environment variables load appropriately during that segment of app startup.

```xml
<aspNetCore processPath="dotnet"
      arguments=".\MyApp.dll"
      stdoutLogEnabled="false"
      stdoutLogFile=".\logs\stdout"
      hostingModel="inprocess">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
    <environmentVariable name="Parent:ApiKey" value="67890" />
  </environmentVariables>
</aspNetCore>
```

## Read configuration in the app

ASP.NET Core provides app configuration through the <xref:Microsoft.Extensions.Configuration.IConfiguration> interface. This configuration interface should be requested by your Blazor components, Blazor pages, and any other ASP.NET Core-managed class that needs access to configuration. The ASP.NET Core framework will automatically populate this interface with the resolved configuration configured earlier. On a Blazor page or a component's Razor markup, you can inject the `IConfiguration` object with an `@inject` directive at the top of the *.razor* file like this:

```razor
@inject IConfiguration Configuration
```

This preceding statement makes the `IConfiguration` object available as the `Configuration` variable throughout the rest of the Razor template.

Individual configuration settings can be read by specifying the configuration setting hierarchy sought as an indexer parameter:

```csharp
var mySetting = Configuration["section1:key0"];
```

You can fetch entire configuration sections by using the <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A> method to retrieve a collection of keys at a specific location with a syntax similar to `GetSection("section1")` to retrieve the configuration for section1 from the earlier example.

## Strongly typed configuration

With Web Forms, it was possible to create a strongly typed configuration type that inherited from the <xref:System.Configuration.ConfigurationSection> type and associated types. A `ConfigurationSection` allowed you to configure some business rules and processing for those configuration values.

In ASP.NET Core, you can specify a class hierarchy that will receive the configuration values. These classes:

* Don't need to inherit from a parent class.
* Should include `public` properties that match the properties and type references for the configuration structure you wish to capture.

For the earlier *appsettings.json* sample, you could define the following classes to capture the values:

```csharp
public class MyConfig
{
    public MyConfigSection section0 { get; set;}

    public MyConfigSection section1 { get; set;}
}

public class MyConfigSection
{
    public string key0 { get; set; }

    public string key1 { get; set; }
}
```

This class hierarchy can be populated by adding the following line to the `Startup.ConfigureServices` method (or appropriate location in *Program.cs* using the `builder.Services` property instead of `services`):

```csharp
services.Configure<MyConfig>(Configuration);
```

In the rest of the app, you can add an input parameter to classes or an `@inject` directive in Razor templates of type `IOptions<MyConfig>` to receive the strongly typed configuration settings. The `IOptions<MyConfig>.Value` property will yield the `MyConfig` value populated from the configuration settings.

```razor
@inject IOptions<MyConfig> options
@code {
    var MyConfiguration = options.Value;
    var theSetting = MyConfiguration.section1.key0;
}
```

More information about the Options feature can be found in the [Options pattern in ASP.NET Core](/aspnet/core/fundamentals/configuration/options#options-interfaces) document.

>[!div class="step-by-step"]
>[Previous](middleware.md)
>[Next](security-authentication-authorization.md)
