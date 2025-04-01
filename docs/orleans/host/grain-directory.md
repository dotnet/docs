---
title: Grain directory
description: Learn about the grain directory in .NET Orleans.
ms.date: 07/03/2024
---

# Orleans grain directory

Grains have stable logical identities and may get activated (instantiated) and deactivated many times over the life of the application, but at most one activation of grain exist at any point in time. Each time a grain gets activated, it may be placed on a different silo in the cluster. When a grain gets activated in the cluster, it registers itself in the _grain directory_. This ensures that subsequent invocations of that grain will be delivered to that activation of the grain and that no other activations (instances) of that grain will be created. The grain directory is responsible for keeping a mapping between a grain identity and where (which silo) its current activation is at.

By default, Orleans uses a built-in distributed in-memory directory. This directory is eventually consistent and partitioned across all silos in the cluster in a form of a distributed hash table.

Starting with 3.2.0, Orleans also supports pluggable implementations of grain directory.

Two such plugins are included in the 3.2.0 release:

- An Azure Table implementation: [Microsoft.Orleans.GrainDirectory.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.AzureStorage)
- A Redis store implementation: [Microsoft.Orleans.GrainDirectory.Redis](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.Redis)

You can configure which grain directory implementation to use on a per-grain type basis, and you can even inject your implementation.

## Which grain directory should you use?

We recommend always starting with the default one (built-in in-memory distributed directory). Even though it is eventually consistent and allows for occasional duplicate activation when the cluster is unstable, the built-in directory is self-sufficient with no external dependencies, doesn't require any configuration, and has been used in production the whole time.

When you have some experience with Orleans and have a use case for a grain directory with stronger single-activation guarantee and/or want to minimize the number of grain that gets deactivated when a silo in the cluster shuts down, consider using a storage-based implementation of grain directory, such as the Redis implementation. Try using it for one or a few grain types first, starting with those that are long-lived and have a significant amount of state or an expensive initialization process.

## Configuration

By default, you don't have to do anything; the in-memory grain directory will be automatically used and partitioned across the cluster. If you'd like to use a non-default grain directory configuration, you need to specify the name of the directory plugin to use. This can be done via an attribute on the grain class and with dependency injection and the directory plugin with that name during the silo configuration.

### Grain configuration

Specifying the grain directory plugin name with the <xref:Orleans.GrainDirectory.GrainDirectoryAttribute>:

```csharp
[GrainDirectory(GrainDirectoryName = "my-grain-directory")]
public class MyGrain : Grain, IMyGrain
{
    // ...
}
```

#### Silo configuration

Here we configure the Redis grain directory implementation:

```csharp
siloBuilder.AddRedisGrainDirectory(
    "my-grain-directory",
    options => options.ConfigurationOptions = redisConfiguration);
```

The Azure grain directory is configured like this:

```csharp
siloBuilder.AddAzureTableGrainDirectory(
    "my-grain-directory",
    options => options.ConnectionString = azureConnectionString);
```

You can configure multiple directories with different names to use for different grain classes:

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
