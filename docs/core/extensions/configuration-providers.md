---
title: Configuration providers in .NET
description: Learn how the Configuration provider API is used to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/11/2020
ms.topic: overview
---

# Configuration providers in .NET

Configuration in .NET is possible with configuration providers. There are several types of providers that rely on various configuration sources. This article details all of the different configuration providers.

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

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> loads configuration from INI file key-value pairs at runtime.

The following code clears all the configuration providers and adds several configuration providers:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs":::

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramINI.cs?name=snippet&highlight=10-30)]

In the preceding code, settings in the *MyIniConfig.ini* and  *MyIniConfig*.`Environment`.*ini* files are overridden by settings in the:

* [Environment variables configuration provider](#environment-variable-configuration-provider)
* [Command-line configuration provider](#command-line-configuration-provider).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following *MyIniConfig.ini* file:

:::code language="ini" source="snippets/configuration/console-ini/appsettings.ini":::

The following code displays the preceding configurations settings by writing them to the console window:

:::code language="csharp" source="snippets/configuration/console-ini/Program.cs" range="26-30":::

### JSON configuration provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration from JSON file key-value pairs.

Overloads can specify:

* Whether the file is optional.
* Whether the configuration is reloaded if the file changes.

Consider the following code:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSON.cs?name=snippet&highlight=12-14)]

The preceding code:

* Configures the JSON configuration provider to load the *MyConfig.json* file with the following options:
  * `optional: true`: The file is optional.
  * `reloadOnChange: true` : The file is reloaded when changes are saved.
* Reads the [default configuration providers](#default) before the *MyConfig.json* file. Settings in the *MyConfig.json* file override setting in the default configuration providers, including the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

You typically ***don't*** want a custom JSON file overriding values set in the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

The following code clears all the configuration providers and adds several configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSON2.cs?name=snippet)]

In the preceding code, settings in the *MyConfig.json* and  *MyConfig*.`Environment`.*json* files:

* Override settings in the *appsettings.json* and *appsettings*.`Environment`.*json* files.
* Are overridden by settings in the [Environment variables configuration provider](#environment-variable-configuration-provider) and the [Command-line configuration provider](#command-line-configuration-provider).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following  *MyConfig.json* file:

:::code language="json" source="snippets/configuration/console-json/appsettings.json":::

The following code displays the preceding configurations settings by writing them to the console window:

:::code language="csharp" source="snippets/configuration/console-json/Program.cs" range="26-30":::

### XML configuration provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> loads configuration from XML file key-value pairs at runtime.

The following code clears all the configuration providers and adds several configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramXML.cs?name=snippet)]

In the preceding code, settings in the *MyXMLFile.xml* and  *MyXMLFile*.`Environment`.*xml* files are overridden by settings in the:

* [Environment variables configuration provider](#environment-variable-configuration-provider)
* [Command-line configuration provider](#command-line-configuration-provider).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following *MyXMLFile.xml* file:

:::code language="xml" source="snippets/configuration/console-xml/appsettings.xml":::

The following code displays the preceding configurations settings by writing them to the console window:

:::code language="csharp" source="snippets/configuration/console-xml/Program.cs" range="26-30":::

Repeating elements that use the same element name work if the `name` attribute is used to distinguish the elements:

[!code-xml[](index/samples/3.x/ConfigSample/MyXMLFile3.xml)]

The following code reads the previous configuration file and displays the keys and values:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/XML/Index.cshtml.cs?name=snippet)]

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

* key:attribute
* section:key:attribute

## Key-per-file configuration provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value contains the file's contents. The Key-per-file configuration provider is used in Docker hosting scenarios.

To activate key-per-file configuration, call the <xref:Microsoft.Extensions.Configuration.KeyPerFileConfigurationBuilderExtensions.AddKeyPerFile> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>. The `directoryPath` to the files must be an absolute path.

Overloads permit specifying:

* An `Action<KeyPerFileConfigurationSource>` delegate that configures the source.
* Whether the directory is optional and the path to the directory.

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

<a name="mcp"></a>

## Memory configuration provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

The following code adds a memory collection to the configuration system:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet6)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

In the preceding code, `config.AddInMemoryCollection(Dict)` is added after the [default configuration providers](#default). For an example of ordering the configuration providers, see [JSON configuration provider](#jcp).

See [Bind an array](#boa) for another example using `MemoryConfigurationProvider`.

## Environment variable configuration provider

Using the [default](#default) configuration, the <xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider> loads configuration from environment variable key-value pairs after reading *appsettings.json*, *appsettings.*`Environment`*.json*, and [Secret manager](xref:security/app-secrets). Therefore, key values read from the environment override values read from *appsettings.json*, *appsettings.*`Environment`*.json*, and Secret manager.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

The following `set` commands:

* Set the environment keys and values of the [preceding example](#appsettingsjson) on Windows.
* Test the settings when using the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample). The `dotnet run` command must be run in the project directory.

```dotnetcli
set MyKey="My key from Environment"
set Position__Title=Environment_Editor
set Position__Name=Environment_Rick
dotnet run
```

The preceding environment settings:

* Are only set in processes launched from the command window they were set in.
* Won't be read by browsers launched with Visual Studio.

The following [setx](/windows-server/administration/windows-commands/setx) commands can be used to set the environment keys and values on Windows. Unlike `set`, `setx` settings are persisted. `/M` sets the variable in the system environment. If the `/M` switch isn't used, a user environment variable is set.

```cmd
setx MyKey "My key from setx Environment" /M
setx Position__Title Setx_Environment_Editor /M
setx Position__Name Environment_Rick /M
```

To test that the preceding commands override *appsettings.json* and *appsettings.*`Environment`*.json*:

* With Visual Studio: Exit and restart Visual Studio.
* With the CLI: Start a new command window and enter `dotnet run`.

Call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables> with a string to specify a prefix for environment variables:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Program.cs?name=snippet4&highlight=12)]

In the preceding code:

* `config.AddEnvironmentVariables(prefix: "MyCustomPrefix_")` is added after the default configuration providers. For an example of ordering the configuration providers, see [JSON configuration provider](#json-configuration-provider).
* Environment variables set with the `MyCustomPrefix_` prefix override the default configuration providers. This includes environment variables without the prefix.

The prefix is stripped off when the configuration key-value pairs are read.

The following commands test the custom prefix:

```dotnetcli
set MyCustomPrefix_MyKey="My key with MyCustomPrefix_ Environment"
set MyCustomPrefix_Position__Title=Editor_with_customPrefix
set MyCustomPrefix_Position__Name=Environment_Rick_cp
dotnet run
```

The [default configuration](#default) loads environment variables and command line arguments prefixed with `DOTNET_` and `ASPNETCORE_`. The `DOTNET_` and `ASPNETCORE_` prefixes are used by ASP.NET Core for [host and app configuration](xref:fundamentals/host/generic-host#host-configuration), but not for user configuration. For more information on host and app configuration, see [.NET Generic Host](xref:fundamentals/host/generic-host).

On [Azure App Service](https://azure.microsoft.com/services/app-service/), select **New application setting** on the **Settings > Configuration** page. Azure App Service application settings are:

- Encrypted at rest and transmitted over an encrypted channel.
- Exposed as environment variables.

<!-- For more information, see [Azure Apps: Override app configuration using the Azure Portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal). -->

See [Connection string prefixes](#constr) for information on Azure database connection strings.

### Environment variables set in launchSettings.json

Environment variables set in *launchSettings.json* override those set in the system environment.

<a name="clcp"></a>

## Command-line configuration provider

Using the default configuration, the <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs after the following configuration sources:

- *appsettings.json* and *appsettings*.`Environment`.*json* files.
- [App secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
- Environment variables.

By default, configuration values set on the command-line override configuration values set with all the other configuration providers.

### Command-line arguments

The following command sets keys and values using `=`:

```dotnetcli
dotnet run MyKey="My key from command line" Position:Title=Cmd Position:Name=Cmd_Rick
```

The following command sets keys and values using `/`:

```dotnetcli
dotnet run /MyKey "Using /" /Position:Title=Cmd_ /Position:Name=Cmd_Rick
```

The following command sets keys and values using `--`:

```dotnetcli
dotnet run --MyKey "Using --" --Position:Title=Cmd-- --Position:Name=Cmd--Rick
```

The key value:

- Must follow `=`, or the key must have a prefix of `--` or `/` when the value follows a space.
- Isn't required if `=` is used. For example, `MySetting=`.

Within the same command, don't mix command-line argument key-value pairs that use `=` with key-value pairs that use a space.
