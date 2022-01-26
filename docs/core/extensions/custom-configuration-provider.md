---
title: Implement a custom configuration provider in .NET
description: Learn how to implement a custom configuration provider in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 12/17/2021
ms.topic: how-to
---

# Implement a custom configuration provider in .NET

There are many [configuration providers](configuration-providers.md) available for common configuration sources such as JSON, XML, and INI files. You may need to implement a custom configuration provider when one of the available providers doesn't suit your application needs. In this article, you'll learn how to implement a custom configuration provider that relies on a database as its configuration source.

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF) Core](/ef/core).

The provider has the following characteristics:

- The EF in-memory database is used for demonstration purposes.
  - To use a database that requires a connection string, get a connection string from an interim configuration.
- The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
- Reload-on-change isn't implemented, so updating the database after the app has started will not affect the app's configuration.

Define a `Settings` record type entity for storing configuration values in the database. For example, you could add a *Settings.cs* file in your *Models* folder:

:::code language="csharp" source="snippets/configuration/custom-provider/Models/Settings.cs":::

For information on record types, see [Record types in C# 9](../../csharp/whats-new/csharp-9.md#record-types).

Add an `EntityConfigurationContext` to store and access the configured values.

*Providers/EntityConfigurationContext.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationContext.cs":::

By overriding <xref:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)> you can use the appropriate database connection. For example, if a connection string was provided you could connect to SQL Server, otherwise you could rely on an in-memory database.

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

*Providers/EntityConfigurationSource.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationSource.cs":::

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty. Since configuration keys are case-insensitive, the dictionary used to initialize the database is created with the case-insensitive comparer ([StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase)).

*Providers/EntityConfigurationProvider.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationProvider.cs":::

An `AddEntityConfiguration` extension method permits adding the configuration source to a <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> instance.

*Extensions/ConfigurationBuilderExtensions.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Extensions/ConfigurationBuilderExtensions.cs":::

> [!IMPORTANT]
> The use of a temporary configuration source to acquire the connection string is important. The current `builder` has its configuration constructed temporarily by calling <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Build?displayProperty=nameWithType>, and <xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString%2A>. After obtaining the connection string, the `builder` adds the `EntityConfigurationSource` given the `connectionString`.

The following code shows how to use the custom `EntityConfigurationProvider` in *Program.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Program.cs" highlight="11":::

## Consume provider

To consume the custom configuration provider, you can use the [options pattern](options.md). With the sample app in place, define an options object to represent the widget settings.

:::code language="csharp" source="snippets/configuration/custom-provider/WidgetOptions.cs":::

A call to <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices%2A> configures the mapping of the options.

:::code language="csharp" source="snippets/configuration/custom-provider/Program.cs" highlight="15-15,18-21":::

The preceding code configures the `WidgetOptions` object from the `"WidgetOptions"` section of the configuration. This enables the options pattern, exposing a dependency injection-ready `IOptions<WidgetOptions>` representation of the EF settings. The options are ultimately provided from the custom configuration provider.

## See also

- [Configuration in .NET](configuration.md)
- [Configuration providers in .NET](configuration-providers.md)
- [Options pattern in .NET](options.md)
- [Dependency injection in .NET](dependency-injection.md)
