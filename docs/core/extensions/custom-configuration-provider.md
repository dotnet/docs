---
title: Implement a custom configuration provider in .NET
description: Learn how to implement a custom configuration provider in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 12/04/2020
ms.topic: how-to
---

# Implement a custom configuration provider in .NET

There are many [configuration providers](configuration-providers.md) available for common configuration sources such as JSON, XML, and INI files. You may need to implement a custom configuration provider when one of the available providers doesn't suit your application needs. In this article, you'll learn how to implement a custom configuration provider that relies on a database as its configuration source.

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF) Core](/ef/core).

The provider has the following characteristics:

- The EF in-memory database is used for demonstration purposes. To use a database that requires a connection string, implement a secondary `ConfigurationBuilder` to supply the connection string from another configuration provider.
- The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
- Reload-on-change isn't implemented, so updating the database after the app starts has no effect on the app's configuration.

Define a `Settings` record type entity for storing configuration values in the database. For example, you could add a *Settings.cs* file in your *Models* folder:

:::code language="csharp" source="snippets/configuration/custom-provider/Models/Settings.cs":::

For information on record types, see [Record types in C# 9](../../csharp/whats-new/csharp-9.md#record-types).

Add an `EntityConfigurationContext` to store and access the configured values.

*Providers/EntityConfigurationContext.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationContext.cs":::

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

*Providers/EntityConfigurationSource.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationSource.cs":::

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty. Since configuration keys are case-insensitive, the dictionary used to initialize the database is created with the case-insensitive comparer ([StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase)).

*Providers/EntityConfigurationProvider.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Providers/EntityConfigurationProvider.cs":::

An `AddEntityConfiguration` extension method permits adding the configuration source to a <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> instance.

*Extensions/ConfigurationBuilderExtensions.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Extensions/ConfigurationBuilderExtensions.cs":::

The following code shows how to use the custom `EntityConfigurationProvider` in *Program.cs*:

:::code language="csharp" source="snippets/configuration/custom-provider/Program.cs" highlight="27-28":::

## See also

- [Configuration in .NET](configuration.md)
- [Configuration providers in .NET](configuration-providers.md)
