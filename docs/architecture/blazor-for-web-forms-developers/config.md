---
title: App configuration
description: Learn how to configure Blazor apps without using ConfigurationManager.
author: csharpfritz
ms.author: jefritz
ms.date: 03/09/2020
---
# App configuration

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Web Forms applications have a single primary way to load application configuration: entries in the web.config file on the server or a related configuration file referenced by web.config.  You can easily use the static `ConfigurationManager` object to interact with application settings, data repository connection strings, and other extended configuration providers that are added into the application.  It's typical to see interactions with application configuration as seen in the following code:

```csharp
var configurationValue = ConfigurationManager.AppSettings["ConfigurationSettingName"];
var connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionName"].ConnectionString;
```

With ASP.NET Core and server-side Blazor, the web.config file MAY be present if your application is hosted on a Windows IIS server.  However, there is no `ConfigurationManager` interaction with this configuration and you can receive more structured application configuration from other sources.  Let's take a look at how configuration is gathered and how you can still access configuration information from a web.config file.

## Configuration Sources

ASP.NET Core recognizes that there are many configuration sources that you may want to use for your application, and attempts to offer you the best of these features by default.  Configuration is read from these various sources by ASP.NET Core and the values are aggregated from these sources with later loaded values for the same configuration key taking precedence over earlier values.

Clever ASP.NET Core was designed to be cloud-aware and make configuration of applications easier for operators and developers.  ASP.NET Core is environment-aware, and knows if it is running in your `Production` or `Development` environment.  The definition of which environment is made by setting the `ASPNETCORE_ENVIRONMENT` system environment variable.  If no value is configured, the application defaults to running in the `Production` environment.

With the environment name set, your application can trigger and add configuration from several different sources based on the name of that environment.  Configuration is by-default loaded from these resources in this order:

1. `appsettings.json` file if present  
1. `appsettings.ENVIRONMENTNAME.json` file if present
1. User-Secrets file on disk if present
1. Environment variables
1. Command-line arguments

## AppSettings.json format and access

The `appsettings.json` file can be hierarchical with values structured something like the following JSON content:

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

When these values are presented by the configuration system, child values are flattened and referenced by their entire hierarchical path separated by colon `:` characters.  For example, to access the section 1 key 0 value you would request the configuration key `section1:key0`.

## User Secrets

User Secrets are configuration values that are stored outside the typical application development folder that are only loaded in the `Development` environment.  This design prevents developers from accidentally checking into a shared source control repository secret configuration values like passwords and API keys.  Secrets are normally stored in a JSON file elsewhere on a developer's workstation and managed with the `user-secrets` command-line tool.  

You can configure your application to interact with user secrets by executing the `user-secrets` command as follows:

```dotnetcli
dotnet user-secrets init
```

You can then set various values in your user secrets with commands similar to the following dotnet command:

```dotnetcli
dotnet user-secrets set "Parent:ApiKey" "12345"
```

This command will make the `Parent:ApiKey` configuration value available on a developer's workstation with the value `12345`.

More information about creating, storing, and managing user secrets values can be found in the documentation about [Safe Storage of App Secrets for ASP.NET Core article](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1).

## Environment variables

The next set of values loaded into your application configuration is the system's environment variables. All of your system's environment variable settings are now accessible to you through the configuration API.  Hierarchical values are flattened and separated by color `:` characters when read inside your application, but on some operating systems the colon character is not allowed in the name of an environment variable.  

ASP.NET Core gets around this limitation by converting values that have double underscores `__` into a colon `:` when they are accessed.  The `Parent:ApiKey` value from the user secrets section above can be overridden with the environment variable `Parent__ApiKey`

## Command-line arguments

Configuration can also be passed in on the command line as arguments when your application is started. Use the double-dash `--` or forward-slash `/` notation to indicate the name of the configuration value to set and the value to be configured.  Syntax is similar to the following commands:

```dotnetcli
dotnet run CommandLineKey1=value1 --CommandLineKey2=value2 /CommandLineKey3=value3
dotnet run --CommandLineKey1 value1 /CommandLineKey2 value2
dotnet run Parent:ApiKey=67890
```

## The return of web.config

If you have deployed your application to Windows and the IIS web server, you will still be using the `web.config` file to configure IIS to manage your application.  By default, IIS will add a reference to the ASP.NET Core Module that hosts your application in place of the Kestrel web server.  This section of `web.config` looks like the following XML markup:

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

Configuration specific to your application can be defined by nesting an `environmentVariables` element inside of the `aspNetCore` element.  The values defined in this section are presented to the ASP.NET Core application as environment variables, and load appropriately during that segment of the application startup.

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

## Reading configuration in the application

ASP.NET Core provides application configuration through an interface at `Microsoft.Extensions.Configuration.IConfiguration`.  This configuration interface should be requested by your Blazor components, Blazor pages, and any other ASP.NET Core managed class that needs access to configuration.  The ASP.NET Core framework will automatically populate this interface with the resolved configuration configured earlier.  On a Blazor page or component's razor markup you can inject the IConfiguration object with an `@inject` statement at the top of the `.razor` file like this:

```cshtml
@inject IConfiguration Configuration
```

This statement will make the `IConfiguration` object available as the `Configuration` variable through the rest of the razor template.

Individual configuration settings can be read by specifying the entire hierarchy of the configuration setting sought as an indexer parameter:

```csharp
var mySetting = Configuration["section1:key0"];
```

You can fetch entire sections of the configuration by using the `IConfiguration.GetSection` command to retrieve a collection of keys at a specific location with a syntax similar to: `GetSection("section1")` to retrieve the configuration for section1 from the earlier example.

## Strongly-Typed Configuration

With Web Forms, it was possible to create a strongly-typed configuration type that inherited from the <xref:System.Configuration.ConfigurationSection> type and associated types.  A ConfigurationSection would allow you to configure some business rules and processing for those configuration values.  

In ASP.NET Core, you can specify a plain class hierarchy that will receive the configuration values. These classes don't need to inherit from a parent-class and should be composed of simple public properties that match the properties and type references for the structure of the configuration you wish to capture.  For the appsettings sample earlier, you could define these classes to capture the values:

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

This class hierarchy can be populated by adding the following line to the `Startup.ConfigureServices` method:

```csharp
services.Configure<MyConfig>(Configuration);
```

In the rest of the application, you can add an input parameter to classes or an `@inject` directive in razor templates of type `IOptions<MyConfig>` to receive the strongly-typed configuration settings.  The `IOptions<MyConfig>.Value` property will yield the `MyConfig` value populated from the configuration settings.

```cshtml
@inject IOptions<MyConfig> options
@code {
 var MyConfiguration = options.Value;
 var theSetting = MyConfiguration.section1.key0;
}
```

More information about the Options feature can be found in the [Options Pattern in ASP.NET Core](/aspnet/core/fundamentals/configuration/options#options-interfaces) article.

>[!div class="step-by-step"]
>[Previous](middleware.md)
>[Next](security-authentication-authorization.md)
