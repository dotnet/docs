---
title: Configuration in .NET
description: Learn how to use the Configuration API to configure .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/11/2020
ms.topic: overview
---

<!-- TODO:

- Overview of Microsoft.Extensions article
- Generic Host article
- Dependency injection article
- Logging article
- Options pattern article
- Configuration / Config providers

-->

# Configuration in .NET

Configuration in .NET is performed using one or more [configuration providers](#configuration-providers). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

* Settings files, such as *appsettings.json*
* Environment variables
* [Azure Key Vault](/azure/key-vault/general/overview)
* [Azure App Configuration](/azure/azure-app-configuration/overview)
* Command-line arguments
* Custom providers, installed or created
* Directory files
* In-memory .NET objects

## Configure console apps

New .NET console applications created using [dotnet new](../tools/dotnet-new.md) or Visual Studio by default *do not* expose configuration capabilities. To add configuration in a new .NET console application, [add a package reference](../tools/dotnet-add-package.md) to `Microsoft.Extensions.Hosting`. Then modify the *Program.cs* file to match the following code:

:::code language="csharp" source="snippets/configuration/console/Program.cs":::

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(System.String[])?displayProperty=nameWithType> method provides default configuration for the app in the following order:

1. [ChainedConfigurationProvider](xref:Microsoft.Extensions.Configuration.ChainedConfigurationSource) : Adds an existing `IConfiguration` as a source. In the default configuration case, adds the host configuration and setting it as the first source for the _app_ configuration.
1. [appsettings.json](#appsettingsjson) using the [JSON configuration provider](#file-configuration-provider).
1. *appsettings.*`Environment`*.json* using the [JSON configuration provider](#file-configuration-provider). For example, *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json*.
1. [App secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
1. Environment variables using the [Environment Variables configuration provider](configuration-providers.md#environment-variable-configuration-provider).
1. Command-line arguments using the [Command-line configuration provider](#command-line).

Configuration providers that are added later override previous key settings. For example, if `MyKey` is set in both *appsettings.json* and the environment, the environment value is used. Using the default configuration providers, the [Command-line configuration provider](configuration-providers.md#command-line-configuration-provider) overrides all other providers.

<!-- For more information on `CreateDefaultBuilder`, see [Default builder settings](xref:fundamentals/host/generic-host#default-builder-settings). -->

## Configure worker service apps

## Configuration providers

The following table shows the configuration providers available to .NET Core apps.

| Provider                                                                                      | Provides configuration from        |
|-----------------------------------------------------------------------------------------------|------------------------------------|
| [Azure App configuration provider](/azure/azure-app-configuration/quickstart-aspnet-core-app) | Azure App Configuration            |
| [Azure Key Vault configuration provider](xref:security/key-vault-configuration)               | Azure Key Vault                    |
| [Command-line configuration provider](#clcp)                                                  | Command-line parameters            |
| [Custom configuration provider](#custom-configuration-provider)                               | Custom source                      |
| [Environment Variables configuration provider](#evcp)                                         | Environment variables              |
| [File configuration provider](#file-configuration-provider)                                   | INI, JSON, and XML files           |
| [Key-per-file configuration provider](#key-per-file-configuration-provider)                   | Directory files                    |
| [Memory configuration provider](#memory-configuration-provider)                               | In-memory collections              |
| [Secret Manager](xref:security/app-secrets)                                                   | File in the user profile directory |

For more information on various configuration providers, see [Configuration providers in .NET](configuration-providers.md).
