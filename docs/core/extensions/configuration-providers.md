---
Enabled: Configuration providers in .NET
description: Learn how the Configuration provider API is used to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/14/2020
ms.topic: overview
---

# Configuration providers in .NET

Configuration in .NET is possible with configuration providers. There are several types of providers that rely on various configuration sources. This article details all of the different configuration providers and their corresponding sources.

> [!div class="checklist"]
>
> - [File configuration provider](#file-configuration-provider)
> - [Key-per-file configuration provider](#key-per-file-configuration-provider)
> - [Memory configuration provider](#memory-configuration-provider)
> - [Environment variable configuration provider](#environment-variable-configuration-provider)
> - [Command-line configuration provider](#command-line-configuration-provider)

## File configuration provider

The <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> is the base class for loading configuration from the file system. The following configuration providers derive from `FileConfigurationProvider`:

- [INI configuration provider](#ini-configuration-provider)
- [JSON configuration provider](#json-configuration-provider)
- [XML configuration provider](#xml-configuration-provider)

### INI configuration provider

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> loads configuration from an INI file at runtime, and relies on the `Microsoft.Extensions.Configuration.Ini` NuGet package.

The following code clears all the configuration providers and adds the `IniConfigurationProvider` with two INI files as the source:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" highlight="18-24":::

An example *appsettings.ini* file with various configuration settings follows:

:::code language="ini" source="snippets/configuration/console-ini/appsettings.ini":::

The following code displays the preceding configuration settings by writing them to the console window:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" range="26-30":::

### JSON configuration provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration from a JSON file, and relies on the `Microsoft.Extensions.Configuration.Json` NuGet package.

Overloads can specify:

- Whether the file is optional.
- Whether the configuration is reloaded if the file changes.

Consider the following code:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" highlight="18-24":::

The preceding code:

- Clears all existing configuration providers that were added by default in the <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(System.String[])> method.
- Configures the JSON configuration provider to load the *appsettings.json* and  *appsettings*.`Environment`.*json* files with the following options:
  - `optional: true`: The file is optional.
  - `reloadOnChange: true` : The file is reloaded when changes are saved.
- The JSON settings are overridden by settings in the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

An example *appsettings.json* file with various configuration settings follows:

:::code language="json" source="snippets/configuration/console-json/appsettings.json":::

From the <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> instance, after configuration providers have been added you can call <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Build?displayProperty=nameWithType> to get the <xref:Microsoft.Extensions.Configuration.IConfigurationRoot> object. The configuration root represents the root of a configuration hierarchy. Sections from the configuration can be bound to instances of option objects, and later provided as <xref:Microsoft.Extensions.Options.IOptions%601> through dependency injection.

The following code builds the root, binds a configuration section to a [record type](../../csharp/whats-new/csharp-9.md#record-types), and prints the bound values to the console window:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" range="26-33":::

The `TransientFaultHandlingOptions` record is defined as follows:

:::code language="csharp" source="snippets/configuration/console-json/TransientFaultHandlingOptions.cs":::

### XML configuration provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> loads configuration from an XML file at runtime, and relies on the `Microsoft.Extensions.Configuration.Xml` NuGet package.

The following code clears all the existing configuration providers, and then adds several configuration providers:

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" range="18-29":::

- Clears all existing configuration providers that were added by default in the <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(System.String[])> method.
- Configures the XML configuration provider to load the *appsettings.xml* and *repeating-example.xml* files with the following options:
  - `optional: true`: The file is optional.
  - `reloadOnChange: true` : The file is reloaded when changes are saved.
- Configures the environment variables configuration provider.
- Configures the command-line configuration provider if the given `args` contains arguments.
- The XML settings are overridden by settings in the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

An example *appsettings.xml* file with various configuration settings follows:

:::code language="xml" source="snippets/configuration/console-xml/appsettings.xml":::

Repeating elements that use the same element name work if the `name` attribute is used to distinguish the elements:

:::code language="xml" source="snippets/configuration/console-xml/repeating-example.xml":::

The following code reads the previous configuration file and displays the keys and values:

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" range="31-46":::

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

- key:attribute
- section:key:attribute

## Key-per-file configuration provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value contains the file's contents. The Key-per-file configuration provider is used in Docker hosting scenarios.

To activate key-per-file configuration, call the <xref:Microsoft.Extensions.Configuration.KeyPerFileConfigurationBuilderExtensions.AddKeyPerFile> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>. The `directoryPath` to the files must be an absolute path.

Overloads permit specifying:

- An `Action<KeyPerFileConfigurationSource>` delegate that configures the source.
- Whether the directory is optional and the path to the directory.

The double-underscore (`__`) is used as a configuration key delimiter in file names. For example, the file name `Logging__LogLevel__System` produces the configuration key `Logging:LogLevel:System`.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    var path = Path.Combine(
        Directory.GetCurrentDirectory(), "path/to/files");
    config.AddKeyPerFile(directoryPath: path, optional: true);
})
```

## Memory configuration provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

The following code adds a memory collection to the configuration system:

:::code language="csharp" source="snippets/configuration/console-memory/Program.cs" highlight="16-23":::

In the preceding code, `configuration.AddInMemoryCollection(IEnumerable<KeyValuePair<string, string>>)` is added after the [default configuration providers](#default). For an example of ordering the configuration providers, see [XML configuration provider](#xml-configuration-provider).

## Environment variable configuration provider

Using the default configuration, the <xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider> loads configuration from environment variable key-value pairs after reading *appsettings.json*, *appsettings.*`Environment`*.json*, and [Secret manager](xref:security/app-secrets). Therefore, key values read from the environment override values read from *appsettings.json*, *appsettings.*`Environment`*.json*, and Secret manager.

The `:` separator doesn't work with environment variable hierarchical keys on all platforms. `__`, the double underscore, is:

- Supported by all platforms. For example, the `:` separator is not supported by [Bash](https://linuxhint.com/bash-environment-variables), but `__` is.
- Automatically replaced by a `:`

The following `set` commands:

- Set the environment keys and values of the [preceding example](#appsettingsjson) on Windows.
- Test the settings by changing them from their default values. The `dotnet run` command must be run in the project directory.

```dotnetcli
set SecretKey="Secret key from environment"
set TransientFaultHandlingOptions__Enabled=true
set TransientFaultHandlingOptions__AutoRetryDelay=00:00:13

dotnet run
```

The preceding environment settings:

- Are only set in processes launched from the command window they were set in.
- Won't be read by browsers launched with Visual Studio.

The following [setx](/windows-server/administration/windows-commands/setx) commands can be used to set the environment keys and values on Windows. Unlike `set`, `setx` settings are persisted. `/M` sets the variable in the system environment. If the `/M` switch isn't used, a user environment variable is set.

```cmd
setx SecretKey "Secret key from setx environment" /M
setx TransientFaultHandlingOptions__Enabled true /M
setx TransientFaultHandlingOptions__AutoRetryDelay 00:00:05 /M
```

To test that the preceding commands override *appsettings.json* and *appsettings.*`Environment`*.json*:

- With Visual Studio: Exit and restart Visual Studio.
- With the CLI: Start a new command window and enter `dotnet run`.

Call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables> with a string to specify a prefix for environment variables:

:::code language="csharp" source="snippets/configuration/console-env/Program.cs" highlight="16-17":::

In the preceding code:

- `config.AddEnvironmentVariables(prefix: "CustomPrefix_")` is added after the default configuration providers. For an example of ordering the configuration providers, see [XML configuration provider](#xml-configuration-provider).
- Environment variables set with the `CustomPrefix_` prefix override the default configuration providers. This includes environment variables without the prefix.

The prefix is stripped off when the configuration key-value pairs are read.

The following commands test the custom prefix:

```dotnetcli
set CustomPrefix__SecretKey="Secret key with CustomPrefix_ environment"
set CustomPrefix_TransientFaultHandlingOptions__Enabled=true
set CustomPrefix_TransientFaultHandlingOptions__AutoRetryDelay=00:00:21

dotnet run
```

The default configuration loads environment variables and command line arguments prefixed with `DOTNET_` and `ASPNETCORE_`. The `DOTNET_` and `ASPNETCORE_` prefixes are used by .NET for host and app configuration, but not for user configuration.
<!-- For more information on host and app configuration, see .NET Generic Host. -->

On [Azure App Service](https://azure.microsoft.com/services/app-service), select **New application setting** on the **Settings > Configuration** page. Azure App Service application settings are:

- Encrypted at rest and transmitted over an encrypted channel.
- Exposed as environment variables.

<!-- For more information, see [Azure Apps: Override app configuration using the Azure Portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal). -->

See [Connection string prefixes](#constr) for information on Azure database connection strings.

### Environment variables set in launchSettings.json

Environment variables set in *launchSettings.json* override those set in the system environment.

## Command-line configuration provider

Using the default configuration, the <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs after the following configuration sources:

- *appsettings.json* and *appsettings*.`Environment`.*json* files.
- App secrets (Secret Manager) in the **Development** environment.
- Environment variables.

By default, configuration values set on the command-line override configuration values set with all the other configuration providers.

### Command-line arguments

The following command sets keys and values using `=`:

```dotnetcli
dotnet run SecretKey="Secret key from command line" TransientFaultHandlingOptions:Enabled=Cmd TransientFaultHandlingOptions:AutoRetryDelay=Cmd_Rick
```

The following command sets keys and values using `/`:

```dotnetcli
dotnet run /SecretKey "Using /" /TransientFaultHandlingOptions:Enabled=Cmd_true /TransientFaultHandlingOptions:AutoRetryDelay=Cmd_00:00:02
```

The following command sets keys and values using `--`:

```dotnetcli
dotnet run --SecretKey "Using --" --TransientFaultHandlingOptions:Enabled=Cmd--true --TransientFaultHandlingOptions:AutoRetryDelay=Cmd--00:00:04
```

The key value:

- Must follow `=`, or the key must have a prefix of `--` or `/` when the value follows a space.
- Isn't required if `=` is used. For example, `SomeKey=`.

Within the same command, don't mix command-line argument key-value pairs that use `=` with key-value pairs that use a space.
