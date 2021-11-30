---
title: Configuration in .NET
description: Learn how to use the Configuration API to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 11/19/2021
ms.topic: overview
---

# Configuration in .NET

Configuration in .NET is performed using one or more [configuration providers](#configuration-providers). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

- Settings files, such as *appsettings.json*
- Environment variables
- [Azure Key Vault](/azure/key-vault/general/overview)
- [Azure App Configuration](/azure/azure-app-configuration/overview)
- Command-line arguments
- Custom providers, installed or created
- Directory files
- In-memory .NET objects
- Third-party providers

## Configure console apps

New .NET console applications created using [dotnet new](../tools/dotnet-new.md) or Visual Studio by default *do not* expose configuration capabilities. To add configuration in a new .NET console application, [add a package reference](../tools/dotnet-add-package.md) to [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/Microsoft.Extensions.Hosting). Modify the *Program.cs* file to match the following code:

:::code language="csharp" source="snippets/configuration/console/Program.cs" highlight="3":::

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(System.String[])?displayProperty=nameWithType> method provides default configuration for the app in the following order:

1. [ChainedConfigurationProvider](xref:Microsoft.Extensions.Configuration.ChainedConfigurationSource) : Adds an existing `IConfiguration` as a source.
1. *appsettings.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider).
1. *appsettings.*`Environment`*.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider). For example, *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json*.
1. [App secrets](/aspnet/core/security/app-secrets) when the app runs in the `Development` environment.
1. Environment variables using the [Environment Variables configuration provider](configuration-providers.md#environment-variable-configuration-provider).
1. Command-line arguments using the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider).

Configuration providers that are added later override previous key settings. For example, if `SomeKey` is set in both *appsettings.json* and the environment, the environment value is used. Using the default configuration providers, the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider) overrides all other providers.

### Binding

One of the key advantages of using the .NET configuration abstractions is the ability to bind configuration values to instances of .NET objects. For example, the JSON configuration provider can be used to map *appsettings.json* files to .NET objects and is used with [dependency injection](dependency-injection.md). This enables the [options pattern](options.md), which uses classes to provide strongly typed access to groups of related settings. .NET configuration provides various abstractions. Consider the following interfaces:

- <xref:Microsoft.Extensions.Configuration.IConfiguration>: Represents a set of key/value application configuration properties.
- <xref:Microsoft.Extensions.Configuration.IConfigurationRoot>: Represents the root of an IConfiguration hierarchy.
- <xref:Microsoft.Extensions.Configuration.IConfigurationSection>: Represents a section of application configuration values.

These abstractions are agnostic to their underlying configuration provider (<xref:Microsoft.Extensions.Configuration.IConfigurationProvider>). In other words, you can use an `IConfiguration` instance to access any configuration value from multiple providers.

### Basic example

To access configuration values in their basic form, without the assistance of the _generic host_ approach, use the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> directly.

> [!TIP]
> The <xref:System.Configuration.ConfigurationBuilder?displayProperty=fullName> is different than the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder?displayProperty=fullName>. All of this content is specific to the `Microsoft.Extensions.*` NuGet packages and namespaces.

Consider the following C# project:

:::code language="xml" source="snippets/configuration/console-raw/console-raw.csproj" highlight="17-19":::

The preceding project file references several configuration NuGet packages:

- [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder): Functionality to bind an object to data in configuration providers for `Microsoft.Extensions.Configuration`.
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json): JSON configuration provider implementation for `Microsoft.Extensions.Configuration`.
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables): Environment variables configuration provider implementation for `Microsoft.Extensions.Configuration`.

Consider an example _appsettings.json_ file:

:::code language="json" source="snippets/configuration/console-raw/appsettings.json":::

Now, given this JSON file here is an example consumption pattern using the configuration builder directly:

:::code language="csharp" source="snippets/configuration/console-raw/Program.cs" highlight="4-7,10":::

The preceding C# code:

- Instantiates a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.
- Adds the `"appsettings.json"` file to be recognized by the JSON configuration provider.
- Adds environment variables as being recognized by the Environment Variable configuration provider.
- The `config` instance is used to get the required `"Settings"` section and get the corresponding `Settings` instance.

The `Settings` object is shaped as follows:

:::code language="csharp" source="snippets/configuration/console-raw/Settings.cs":::

:::code language="csharp" source="snippets/configuration/console-raw/NestedSettings.cs":::

### Basic example with hosting

To access the `IConfiguration` value, you can rely again on the [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package. Create a new console application, and paste the following project file contents into it:

:::code language="xml" source="snippets/configuration/console-basic/console-basic.csproj" highlight="4,11-13,17":::

The preceding project file defines:

- That the application is an executable.
- That an _appsettings.json_ file is to be copied to the output directory when the project is compiled.
- That the `Microsoft.Extensions.Hosting` NuGet package reference is added.

Add the _appsettings.json_ file at the root of the project with the following contents:

:::code language="json" source="snippets/configuration/console-basic/appsettings.json":::

Replace the contents of the _Program.cs_ file with the following C# code:

:::code language="csharp" source="snippets/configuration/console-basic/Program.cs" highlight="5,8,11-13,16-18":::

When you run this application, the `Host.CreateDefaultBuilder` defines the behavior to discover the JSON configuration and expose it through the `IConfiguration` instance. From the `host` instance, you can ask the service provider for the `IConfiguration` instance and then ask it for values.

> [!TIP]
> Using the raw `IConfiguration` instance in this way, while convenient, doesn't scale very well. When applications grow in complexity, and their corresponding configurations become more complex, we recommend that you use the [_options pattern_](options.md) as an alternative.

## Configuration providers

The following table shows the configuration providers available to .NET Core apps.

| Provider                                                                                                               | Provides configuration from        |
|------------------------------------------------------------------------------------------------------------------------|------------------------------------|
| [Azure App configuration provider](/azure/azure-app-configuration/quickstart-aspnet-core-app)                          | Azure App Configuration            |
| [Azure Key Vault configuration provider](/azure/key-vault/general/tutorial-net-virtual-machine)                        | Azure Key Vault                    |
| [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider)                  | Command-line parameters            |
| [Custom configuration provider](custom-configuration-provider.md)                                                      | Custom source                      |
| [Environment Variables configuration provider](configuration-providers.md#environment-variable-configuration-provider) | Environment variables              |
| [File configuration provider](configuration-providers.md#file-configuration-provider)                                  | JSON, XML, and INI files           |
| [Key-per-file configuration provider](configuration-providers.md#key-per-file-configuration-provider)                  | Directory files                    |
| [Memory configuration provider](configuration-providers.md#memory-configuration-provider)                              | In-memory collections              |
| [App secrets (Secret Manager)](/aspnet/core/security/app-secrets)                                                      | File in the user profile directory |

For more information on various configuration providers, see [Configuration providers in .NET](configuration-providers.md).

## See also

- [Configuration providers in .NET](configuration-providers.md)
- [Implement a custom configuration provider](custom-configuration-provider.md)
- Configuration bugs should be created in the [github.com/dotnet/extensions](https://github.com/dotnet/extensions/issues) repo
