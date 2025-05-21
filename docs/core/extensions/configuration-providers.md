---
title: Configuration providers
description: Discover how to configure .NET apps using the configuration provider API and the available configuration providers.
author: IEvangelist
ms.author: dapine
ms.date: 12/16/2024
ms.topic: article
---

# Configuration providers in .NET

Configuration in .NET is possible with configuration providers. Several types of providers rely on various configuration sources. This article details all of the different configuration providers and their corresponding sources.

- [File configuration provider](#file-configuration-provider)
- [Environment variable configuration provider](#environment-variable-configuration-provider)
- [Command-line configuration provider](#command-line-configuration-provider)
- [Key-per-file configuration provider](#key-per-file-configuration-provider)
- [Memory configuration provider](#memory-configuration-provider)

## File configuration provider

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> is the base class for loading configuration from the file system. The following configuration providers derive from `FileConfigurationProvider`:

- [JSON configuration provider](#json-configuration-provider)
- [XML configuration provider](#xml-configuration-provider)
- [INI configuration provider](#ini-configuration-provider)

Keys are case-insensitive. All of the file configuration providers throw the <xref:System.FormatException> when duplicate keys are found in a single provider.

### JSON configuration provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> class loads configuration from a JSON file. Install the [`Microsoft.Extensions.Configuration.Json`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) NuGet package.

Overloads can specify:

- Whether the file is optional.
- Whether the configuration is reloaded if the file changes.

Consider the following code:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" range="1-26" highlight="9-13":::

The preceding code:

- Clears all existing configuration providers that were added by default in the <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(System.String[])> method.
- Configures the JSON configuration provider to load the *appsettings.json* and  *appsettings*.`Environment`.*json* files with the following options:
  - `optional: true`: The file is optional.
  - `reloadOnChange: true`: The file is reloaded when changes are saved.

> [!IMPORTANT]
> When [adding configuration providers](https://github.com/dotnet/runtime/blob/main/src%2Flibraries%2FMicrosoft.Extensions.Configuration%2Fsrc%2FConfigurationBuilder.cs#L30-L34) with <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Add%2A?displayProperty=nameWithType>, the added configuration provider is added to the end of the end of the `IConfigurationSource` list. When keys are found by multiple providers, the last provider to read the key overrides previous providers.

An example *appsettings.json* file with various configuration settings follows:

:::code language="json" source="snippets/configuration/console-json/appsettings.json":::

From the <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> instance, after configuration providers have been added, you can call <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Build?displayProperty=nameWithType> to get the <xref:Microsoft.Extensions.Configuration.IConfigurationRoot> object. The configuration root represents the root of a configuration hierarchy. Sections from the configuration can be bound to instances of .NET objects and later provided as <xref:Microsoft.Extensions.Options.IOptions%601> through dependency injection.

> [!NOTE]
> The *Build Action* and *Copy to Output Directory* properties of the JSON file must be set to *Content* and *Copy if newer (or Copy always)*, respectively.

Consider the `TransientFaultHandlingOptions` class defined as follows:

:::code language="csharp" source="snippets/configuration/console-json/TransientFaultHandlingOptions.cs":::

The following code builds the configuration root, binds a section to the `TransientFaultHandlingOptions` class type, and prints the bound values to the console window:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" range="15-20":::

The application writes the following sample output:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" id="Output":::

### XML configuration provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> class loads configuration from an XML file at run time. Install the [`Microsoft.Extensions.Configuration.Xml`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Xml) NuGet package.

The following code demonstrates the configuration of XML files using the XML configuration provider.

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" range="1-18,36-40" highlight="6-17":::

The preceding code:

- Clears all existing configuration providers that were added by default in the <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(System.String[])> method.
- Configures the XML configuration provider to load the *appsettings.xml* and *repeating-example.xml* files with the following options:
  - `optional: true`: The file is optional.
  - `reloadOnChange: true`: The file is reloaded when changes are saved.
- Configures the environment variables configuration provider.
- Configures the command-line configuration provider if the given `args` contain arguments.

The XML settings are overridden by settings in the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

An example *appsettings.xml* file with various configuration settings follows:

:::code language="xml" source="snippets/configuration/console-xml/appsettings.xml":::

> [!TIP]
> To use the `IConfiguration` type in WinForms apps, add a reference to the [Microsoft.Extensions.Configuration.Xml](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Xml) NuGet package. Instantiate the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> and chain calls to <xref:Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile%2A> and <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder.Build>. For more information, see [.NET Docs Issue #29679](https://github.com/dotnet/docs/issues/29679#issuecomment-1169017078).

In .NET 5 and earlier versions, add the `name` attribute to distinguish repeating elements that use the same element name. In .NET 6 and later versions, the XML configuration provider automatically indexes repeating elements. That means you don't have to specify the `name` attribute, except if you want the "0" index in the key and there's only one element. (If you're upgrading to .NET 6 or later, you may encounter a break resulting from this change in behavior. For more information, see [Repeated XML elements include index](../compatibility/extensions/6.0/repeated-xml-elements.md).)

:::code language="xml" source="snippets/configuration/console-xml/repeating-example.xml":::

The following code reads the previous configuration file and displays the keys and values:

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" range="19-34":::

The application would write the following sample output:

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" id="Output":::

Attributes can be used to supply values:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <key attribute="value" />
  <section>
    <key attribute="value" />
  </section>
</configuration>
```

The previous configuration file loads the following keys with `value`:

- `key:attribute`
- `section:key:attribute`

### INI configuration provider

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> class loads configuration from an INI file at run time. Install the [`Microsoft.Extensions.Configuration.Ini`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Ini)  NuGet package.

The following code clears all the configuration providers and adds the `IniConfigurationProvider` with two INI files as the source:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" range="1-12,19-23" highlight="7-11":::

An example *appsettings.ini* file with various configuration settings follows:

:::code language="ini" source="snippets/configuration/console-ini/appsettings.ini":::

The following code displays the preceding configuration settings by writing them to the console window:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" range="13-17":::

The application would write the following sample output:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" id="Output":::

## Environment variable configuration provider

Using the default configuration, the <xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider> loads configuration from environment variable key-value pairs after reading *appsettings.json*, *appsettings.*`Environment`*.json*, and Secret manager. Therefore, key values read from the environment override values read from *appsettings.json*, *appsettings.*`Environment`*.json*, and Secret manager.

The `:` delimiter doesn't work with environment variable hierarchical keys on all platforms. For example, the `:` delimiter is not supported by [Bash](https://linuxhint.com/bash-environment-variables). The double underscore (`__`), which is supported on all platforms, automatically replaces any `:` delimiters in environment variables.

Consider the `TransientFaultHandlingOptions` class:

```csharp
public class TransientFaultHandlingOptions
{
    public bool Enabled { get; set; }
    public TimeSpan AutoRetryDelay { get; set; }
}
```

The following `set` commands set the environment keys and values of `SecretKey` and `TransientFaultHandlingOptions`.

```dotnetcli
set SecretKey="Secret key from environment"
set TransientFaultHandlingOptions__Enabled="true"
set TransientFaultHandlingOptions__AutoRetryDelay="00:00:13"
```

These environment settings are only set in processes launched from the command window they were set in. They aren't read by web apps launched with Visual Studio.

With Visual Studio 2019 and later, you can specify environment variables using the **Launch Profiles** dialog.

:::image type="content" source="media/launch-profiles-env-vars.png" alt-text="Launch Profiles dialog showing environment variables" lightbox="media/launch-profiles-env-vars.png":::

The following [setx](/windows-server/administration/windows-commands/setx) commands can be used to set the environment keys and values on Windows. Unlike `set`, `setx` settings are persisted. `/M` sets the variable in the system environment. If the `/M` switch isn't used, a user environment variable is set.

```dotnetcli
setx SecretKey "Secret key from setx environment" /M
setx TransientFaultHandlingOptions__Enabled "true" /M
setx TransientFaultHandlingOptions__AutoRetryDelay "00:00:05" /M
```

To test that the preceding commands override any *appsettings.json* and *appsettings.*`Environment`*.json* settings:

- With Visual Studio: Exit and restart Visual Studio.
- With the CLI: Start a new command window and enter `dotnet run`.

### Prefixes

To specify a prefix for environment variables, call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables%2A> with a string:

:::code language="csharp" source="snippets/configuration/console-env/Program.cs" highlight="6-7":::

In the preceding code:

- `config.AddEnvironmentVariables(prefix: "CustomPrefix_")` is added after the default configuration providers. For an example of ordering the configuration providers, see [XML configuration provider](#xml-configuration-provider).
- Environment variables set with the `CustomPrefix_` prefix override the default configuration providers. This includes environment variables without the prefix.

The prefix is stripped off when the configuration key-value pairs are read.

The default configuration loads environment variables and command-line arguments prefixed with `DOTNET_`. The `DOTNET_` prefix is used by .NET for [host](generic-host.md#host-configuration) and [app configuration](generic-host.md#app-configuration), but not for user configuration.

For more information on host and app configuration, see [.NET Generic Host](generic-host.md).

### Connection string prefixes

The Configuration API has special processing rules for four connection string environment variables. These connection strings are involved in configuring Azure connection strings for the app environment. Environment variables with the prefixes shown in the table are loaded into the app with the default configuration or when no prefix is supplied to `AddEnvironmentVariables`.

| Connection string prefix | Provider                                                                |
|--------------------------|-------------------------------------------------------------------------|
| `CUSTOMCONNSTR_`         | Custom provider                                                         |
| `MYSQLCONNSTR_`          | [MySQL](https://www.mysql.com)                                          |
| `SQLAZURECONNSTR_`       | [Azure SQL Database](https://azure.microsoft.com/services/sql-database) |
| `SQLCONNSTR_`            | [SQL Server](https://www.microsoft.com/sql-server)                      |

When an environment variable is discovered and loaded into configuration with any of the four prefixes shown in the table:

- The configuration key is created by removing the environment variable prefix and adding a configuration key section (`ConnectionStrings`).
- A new configuration key-value pair is created that represents the database connection provider (except for `CUSTOMCONNSTR_`, which has no stated provider).

| Environment variable key | Converted configuration key | Provider configuration entry                                                    |
|--------------------------|-----------------------------|---------------------------------------------------------------------------------|
| `CUSTOMCONNSTR_{KEY}`    | `ConnectionStrings:{KEY}`   | Configuration entry not created.                                                |
| `MYSQLCONNSTR_{KEY}`     | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `MySql.Data.MySqlClient` |
| `SQLAZURECONNSTR_{KEY}`  | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |
| `SQLCONNSTR_{KEY}`       | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |

[!INCLUDE [managed-identities](../../includes/managed-identities.md)]

### Environment variables set in launchSettings.json

Environment variables set in *launchSettings.json* override those set in the system environment.

### Azure App Service settings

On [Azure App Service](https://azure.microsoft.com/services/app-service), select **Add** on the **Settings** > **Environment variables** page. Azure App Service application settings are:

- Encrypted at rest and transmitted over an encrypted channel.
- Exposed as environment variables.

## Command-line configuration provider

Using the default configuration, the <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs after the following configuration sources:

- *appsettings.json* and *appsettings*.`Environment`.*json* files.
- App secrets (Secret Manager) in the `Development` environment.
- Environment variables.

By default, configuration values set on the command line override configuration values set with all the other configuration providers.

With Visual Studio 2019 and later, you can specify command-line arguments using the **Launch Profiles** dialog.

:::image type="content" source="media/launch-profiles-cmd-line-args.png" alt-text="Launch Profiles dialog showing command-line arguments" lightbox="media/launch-profiles-cmd-line-args.png":::

### Command-line arguments

The following command sets keys and values using `=`:

```dotnetcli
dotnet run SecretKey="Secret key from command line"
```

The following command sets keys and values using `/`:

```dotnetcli
dotnet run /SecretKey "Secret key set from forward slash"
```

The following command sets keys and values using `--`:

```dotnetcli
dotnet run --SecretKey "Secret key set from double hyphen"
```

The key value:

- Must follow `=`, or the key must have a prefix of `--` or `/` when the value follows a space.
- Isn't required if `=` is used. For example, `SomeKey=`.

Within the same command, don't mix command-line argument key-value pairs that use `=` with key-value pairs that use a space.

## Key-per-file configuration provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value is the file's contents. The Key-per-file configuration provider is used in Docker hosting scenarios.

To activate key-per-file configuration, call the <xref:Microsoft.Extensions.Configuration.KeyPerFileConfigurationBuilderExtensions.AddKeyPerFile%2A> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>. The `directoryPath` to the files must be an absolute path.

Overloads permit specifying:

- An `Action<KeyPerFileConfigurationSource>` delegate that configures the source.
- Whether the directory is optional and the path to the directory.

The double-underscore (`__`) is used as a configuration key delimiter in file names. For example, the file name `Logging__LogLevel__System` produces the configuration key `Logging:LogLevel:System`.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration:

```csharp
.ConfigureAppConfiguration((_, configuration) =>
{
    var path = Path.Combine(
        Directory.GetCurrentDirectory(), "path/to/files");

    configuration.AddKeyPerFile(directoryPath: path, optional: true);
})
```

## Memory configuration provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

The following code adds a memory collection to the configuration system:

:::code language="csharp" source="snippets/configuration/console-memory/Program.cs" highlight="6-13":::

In the preceding code, <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}})?displayProperty=nameWithType> adds the memory provider after the default configuration providers. For an example of ordering the configuration providers, see [XML configuration provider](#xml-configuration-provider).

## See also

- [Configuration in .NET](configuration.md)
- [.NET Generic Host](generic-host.md)
- [Implement a custom configuration provider](custom-configuration-provider.md)
