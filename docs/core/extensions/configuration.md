---
title: Configuration in .NET
description: Learn how to use the Configuration API to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
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

## Configure console apps

New .NET console applications created using [dotnet new](../tools/dotnet-new.md) or Visual Studio by default *do not* expose configuration capabilities. To add configuration in a new .NET console application, [add a package reference](../tools/dotnet-add-package.md) to `Microsoft.Extensions.Hosting`. Modify the *Program.cs* file to match the following code:

:::code language="csharp" source="snippets/configuration/console/Program.cs" highlight="17":::

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(System.String[])?displayProperty=nameWithType> method provides default configuration for the app in the following order:

1. [ChainedConfigurationProvider](xref:Microsoft.Extensions.Configuration.ChainedConfigurationSource) : Adds an existing `IConfiguration` as a source.
1. *appsettings.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider).
1. *appsettings.*`Environment`*.json* using the [JSON configuration provider](configuration-providers.md#file-configuration-provider). For example, *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json*.
1. [App secrets](/aspnet/core/security/app-secrets) when the app runs in the `Development` environment.
1. Environment variables using the [Environment Variables configuration provider](configuration-providers.md#environment-variable-configuration-provider).
1. Command-line arguments using the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider).

Configuration providers that are added later override previous key settings. For example, if `SomeKey` is set in both *appsettings.json* and the environment, the environment value is used. Using the default configuration providers, the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider) overrides all other providers.

### Binding

One of the key advantages to configuration in .NET is the ability to bind configuration values to instances of .NET objects. For example, the JSON configuration provider can be used to map *appsettings.json* files to .NET objects and is used with dependency injection. This enables the options pattern, the options pattern uses classes to provide strongly typed access to groups of related settings.

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
