---
title: Configuration
description: Learn how to use the Configuration API to configure .NET applications. Explore various inbuilt configuration providers.
author: IEvangelist
ms.author: dapine
ms.date: 03/13/2023
ms.topic: overview
---

# Configuration in .NET

Configuration in .NET is performed using one or more [configuration providers](#configuration-providers). Configuration providers read configuration data from key-value pairs using various configuration sources:

- Settings files, such as *appsettings.json*
- Environment variables
- [Azure Key Vault](/azure/key-vault/general/overview)
- [Azure App Configuration](/azure/azure-app-configuration/overview)
- Command-line arguments
- Custom providers, installed or created
- Directory files
- In-memory .NET objects
- Third-party providers

> [!NOTE]
> For information about configuring the .NET runtime itself, see [.NET Runtime configuration settings](../runtime-config/index.md).

## Concepts and abstractions

Given one or more configuration sources, the <xref:Microsoft.Extensions.Configuration.IConfiguration> type provides a unified view of the configuration data. Configuration is read-only, and the configuration pattern isn't designed to be programmatically writable. The `IConfiguration` interface is a single representation of all the configuration sources, as shown in the following diagram:

:::image type="content" source="media/configuration-sources.svg" lightbox="media/configuration-sources.svg" alt-text="The `IConfiguration` interface is a single representation of all the configuration sources.":::

## Configure console apps

.NET console applications created using the [dotnet new](../tools/dotnet-new.md) command template or Visual Studio by default *do not* expose configuration capabilities. To add configuration in a new .NET console application, [add a package reference](../tools/dotnet-add-package.md) to [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting). Modify the *Program.cs* file to match the following code:

:::code language="csharp" source="snippets/configuration/console/Program.cs" highlight="3":::

The <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(System.String[])?displayProperty=nameWithType> method provides default configuration for the app in the following order, from highest to lowest priority:

1. Command-line arguments using the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider).
1. Environment variables using the [Environment Variables configuration provider](configuration-providers.md#environment-variable-configuration-provider).
1. [App secrets](/aspnet/core/security/app-secrets) when the app runs in the `Development` environment.
1. *appsettings.*`Environment`*.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider). For example, *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json*.
1. *appsettings.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider).
1. [ChainedConfigurationProvider](xref:Microsoft.Extensions.Configuration.ChainedConfigurationSource) : Adds an existing `IConfiguration` as a source.

Adding a configuration provider overrides previous configuration values. For example, the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider) overrides all values from other providers because it's added last. If `SomeKey` is set in both *appsettings.json* and the environment, the environment value is used because it was added after *appsettings.json*.

### Binding

One of the key advantages of using the .NET configuration abstractions is the ability to bind configuration values to instances of .NET objects. For example, the JSON configuration provider can be used to map *appsettings.json* files to .NET objects and is used with [dependency injection](dependency-injection.md). This enables the [options pattern](options.md), which uses classes to provide strongly typed access to groups of related settings. .NET configuration provides various abstractions. Consider the following interfaces:

- <xref:Microsoft.Extensions.Configuration.IConfiguration>: Represents a set of key/value application configuration properties.
- <xref:Microsoft.Extensions.Configuration.IConfigurationRoot>: Represents the root of an `IConfiguration` hierarchy.
- <xref:Microsoft.Extensions.Configuration.IConfigurationSection>: Represents a section of application configuration values.

These abstractions are agnostic to their underlying configuration provider (<xref:Microsoft.Extensions.Configuration.IConfigurationProvider>). In other words, you can use an `IConfiguration` instance to access any configuration value from multiple providers.

The binder can use different approaches to process configuration values:​

- Direct deserialization (using built-in converters) for primitive types​.
- The <xref:System.ComponentModel.TypeConverter> for a complex type when the type has one​.
- Reflection for a complex type that has properties.

> [!NOTE]
> The binder has a few limitations:
>
> - Properties are ignored if they have private setters or their type can't be converted.
> - Properties without corresponding configuration keys are ignored.

#### Binding hierarchies

Configuration values can contain hierarchical data. Hierarchical objects are represented with the use of the `:` delimiter in the configuration keys. To access a configuration value, use the `:` character to delimit a hierarchy. For example, consider the following configuration values:

```json
{
  "Parent": {
    "FavoriteNumber": 7,
    "Child": {
      "Name": "Example",
      "GrandChild": {
        "Age": 3
      }
    }
  }
}
```

The following table represents example keys and their corresponding values for the preceding example JSON:

| Key                             | Value       |
|---------------------------------|-------------|
| `"Parent:FavoriteNumber"`       | `7`         |
| `"Parent:Child:Name"`           | `"Example"` |
| `"Parent:Child:GrandChild:Age"` | `3`         |

### Basic example

To access configuration values in their basic form, without the assistance of the _generic host_ approach, use the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> type directly.

> [!TIP]
> The <xref:System.Configuration.ConfigurationBuilder?displayProperty=fullName> type is different to the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder?displayProperty=fullName> type. All of this content is specific to the `Microsoft.Extensions.*` NuGet packages and namespaces.

Consider the following C# project:

:::code language="xml" source="snippets/configuration/console-raw/console-raw.csproj" highlight="17-19":::

The preceding project file references several configuration NuGet packages:

- [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder): Functionality to bind an object to data in configuration providers for `Microsoft.Extensions.Configuration`.
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json): JSON configuration provider implementation for `Microsoft.Extensions.Configuration`.
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables): Environment variables configuration provider implementation for `Microsoft.Extensions.Configuration`.

Consider an example _appsettings.json_ file:

:::code language="json" source="snippets/configuration/console-raw/appsettings.json":::

Now, given this JSON file, here's an example consumption pattern using the configuration builder directly:

:::code language="csharp" source="snippets/configuration/console-raw/Program.cs" highlight="4-7,10":::

The preceding C# code:

- Instantiates a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.
- Adds the `"appsettings.json"` file to be recognized by the JSON configuration provider.
- Adds environment variables as being recognized by the Environment Variable configuration provider.
- Gets the required `"Settings"` section and the corresponding `Settings` instance by using the `config` instance.

The `Settings` object is shaped as follows:

:::code language="csharp" source="snippets/configuration/console-raw/Settings.cs":::

:::code language="csharp" source="snippets/configuration/console-raw/NestedSettings.cs":::

### Basic example with hosting

To access the `IConfiguration` value, you can rely again on the [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package. Create a new console application, and paste the following project file contents into it:

:::code language="xml" source="snippets/configuration/console-basic/console-basic.csproj" highlight="4,11-13,17":::

The preceding project file defines that:

- The application is an executable.
- An _appsettings.json_ file is to be copied to the output directory when the project is compiled.
- The `Microsoft.Extensions.Hosting` NuGet package reference is added.

Add the _appsettings.json_ file at the root of the project with the following contents:

:::code language="json" source="snippets/configuration/console-basic/appsettings.json":::

Replace the contents of the _Program.cs_ file with the following C# code:

:::code language="csharp" source="snippets/configuration/console-basic/Program.cs" highlight="5,8,11-13,16-18":::

When you run this application, the `Host.CreateApplicationBuilder` defines the behavior to discover the JSON configuration and expose it through the `IConfiguration` instance. From the `host` instance, you can ask the service provider for the `IConfiguration` instance and then ask it for values.

> [!TIP]
> Using the raw `IConfiguration` instance in this way, while convenient, doesn't scale very well. When applications grow in complexity, and their corresponding configurations become more complex, we recommend that you use the [_options pattern_](options.md) as an alternative.

### Basic example with hosting and using the indexer API

Consider the same _appsettings.json_ file contents from the previous example:

:::code language="json" source="snippets/configuration/console-indexer/appsettings.json":::

Replace the contents of the _Program.cs_ file with the following C# code:

:::code language="csharp" source="snippets/configuration/console-indexer/Program.cs" highlight="11-15,17-22":::

The values are accessed using the indexer API where each key is a string, and the value is a string. Configuration supports properties, objects, arrays, and dictionaries.

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

> [!TIP]
> The order in which configuration providers are added matters. When multiple configuration providers are used and more than one provider specifies the same key, the last one added is used.

For more information on various configuration providers, see [Configuration providers in .NET](configuration-providers.md).

## See also

- [Configuration providers in .NET](configuration-providers.md)
- [Implement a custom configuration provider](custom-configuration-provider.md)
- Configuration bugs should be created in the [github.com/dotnet/runtime](https://github.com/dotnet/runtime/issues) repo
- [Configuration in ASP.NET Core](/aspnet/core/fundamentals/configuration)
