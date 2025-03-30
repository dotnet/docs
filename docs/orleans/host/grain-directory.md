---
title: Grain directory
description: Learn about the grain directory in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
---

# Orleans grain directory

Grains have stable logical identities. They can activate (instantiate) and deactivate many times over the application's life, but at most one activation of a grain exists at any point in time. Each time a grain activates, it might be placed on a different silo in the cluster. When a grain activates in the cluster, it registers itself in the _grain directory_. This ensures subsequent invocations of that grain are delivered to that activation and prevents the creation of other activations (instances) of that grain. The grain directory is responsible for maintaining a mapping between a grain identity and the location (which silo) of its current activation.

By default, Orleans uses a built-in distributed in-memory directory. This directory is eventually consistent and partitioned across all silos in the cluster in the form of a distributed hash table.

Starting with version 3.2.0, Orleans also supports pluggable grain directory implementations.

Two such plugins are included in the 3.2.0 release:

- An Azure Table implementation: [Microsoft.Orleans.GrainDirectory.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.AzureStorage)
- A Redis store implementation: [Microsoft.Orleans.GrainDirectory.Redis](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.Redis)

You can configure which grain directory implementation to use on a per-grain type basis, and you can even inject your implementation.

## Which grain directory should you use?

We recommend always starting with the default directory (the built-in in-memory distributed directory). Although it's eventually consistent and allows occasional duplicate activations when the cluster is unstable, the built-in directory is self-sufficient, has no external dependencies, requires no configuration, and has been used successfully in production since the beginning.

When you have some experience with Orleans and have a use case requiring a stronger single-activation guarantee, or if you want to minimize the number of grains deactivated when a silo shuts down, consider using a storage-based grain directory implementation, such as the Redis implementation. Try using it for one or a few grain types first, starting with those that are long-lived, have significant state, or have an expensive initialization process.

## Configuration

By default, you don't need to do anything; Orleans automatically uses the in-memory grain directory and partitions it across the cluster. If you want to use a non-default grain directory configuration, you need to specify the name of the directory plugin to use. You can do this via an attribute on the grain class and by configuring the directory plugin with that name using dependency injection during silo configuration.

### Grain configuration

Specify the grain directory plugin name using the <xref:Orleans.GrainDirectory.GrainDirectoryAttribute>:

```csharp
[GrainDirectory(GrainDirectoryName = "my-grain-directory")]
public class MyGrain : Grain, IMyGrain
{
    // ...
}
```

#### Silo configuration

Here's how you configure the Redis grain directory implementation:

```csharp
siloBuilder.AddRedisGrainDirectory(
    "my-grain-directory",
    options => options.ConfigurationOptions = redisConfiguration);
```

Configure the Azure grain directory like this:

```csharp
siloBuilder.AddAzureTableGrainDirectory(
    "my-grain-directory",
    options => options.ConnectionString = azureConnectionString);
```

You can configure multiple directories with different names for use with different grain classes:

```csharp
siloBuilder
    .AddRedisGrainDirectory(
        "redis-directory-1",
        options => options.ConfigurationOptions = redisConfiguration1)
    .AddRedisGrainDirectory(
        "redis-directory-2",
        options => options.ConfigurationOptions = redisConfiguration2)
    .AddAzureTableGrainDirectory(
        "azure-directory",
        options => options.ConnectionString = azureConnectionString);
```
