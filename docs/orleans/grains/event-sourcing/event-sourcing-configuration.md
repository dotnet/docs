---
title: Event sourcing configuration
description: Learn about event sourcing configuration in .NET Orleans.
ms.date: 01/31/2022
---

# Event sourcing configuration

In this article, you'll learn about various event sourcing configuration options for .NET Orleans.

## Configure project references

### Grain Interfaces

As before, interfaces depend only on the `Microsoft.Orleans.Core` package, because the grain interface is independent of the implementation.

### Grain implementations

JournaledGrains need to derive from `JournaledGrain<S,E>` or `JournaledGrain<S>`, which is defined in the `Microsoft.Orleans.EventSourcing` package.

### Log-consistency providers

We currently include three log-consistency providers (for state storage, log storage, and custom storage). All three are contained in the `Microsoft.Orleans.EventSourcing` package as well. Therefore, all Journaled Grains already have access to those. For a description of what these providers do and how they differ, see [Included Log-Consistency Providers](log-consistency-providers.md).

## Cluster configuration

Log-consistency providers are configured just like any other Orleans providers.
For example, to include all three providers (of course, you probably won't need all three), add this to the `<Globals>` element of the configuration file:

```xml
<LogConsistencyProviders>
    <Provider Name="StateStorage"
        Type="Orleans.EventSourcing.StateStorage.LogConsistencyProvider" />
    <Provider Name="LogStorage"
        Type="Orleans.EventSourcing.LogStorage.LogConsistencyProvider" />
    <Provider Name="CustomStorage"
        Type="Orleans.EventSourcing.CustomStorage.LogConsistencyProvider" />
</LogConsistencyProviders>
```

The same can be achieved programmatically. Moving forward to 2.0.0 stable, ClientConfiguration and ClusterConfiguration no longer exist! It has now been replaced by a ClientBuilder and a SiloBuilder (notice there is no cluster builder).

```csharp
builder.AddLogStorageBasedLogConsistencyProvider("LogStorage")
```

## Grain class attributes

Each journaled grain class must have a `LogConsistencyProvider` attribute to specify the log-consistency provider. Some providers additionally require a `StorageProvider` attribute, for example:

```csharp
[StorageProvider(ProviderName = "OrleansLocalStorage")]
[LogConsistencyProvider(ProviderName = "LogStorage")]
public class EventSourcedBankAccountGrain :
    JournaledGrain<BankAccountState>, IEventSourcedBankAccountGrain
{
    //...
}
```

So here "`OrleansLocalStorage`" is being used for storing the grain state, where was "`LogStorage`" is the in-memory storage provider for EventSourcing events.

### `LogConsistencyProvider` attributes

To specify the log-consistency provider, add a `[LogConsistencyProvider(ProviderName=...)]` attribute to the grain class, and give the name of the provider as configured by the cluster configuration, for example:

```csharp
[LogConsistencyProvider(ProviderName = "CustomStorage")]
public class ChatGrain :
    JournaledGrain<XDocument, IChatEvent>, IChatGrain, ICustomStorage
{
    // ...
}
```

### `StorageProvider` attributes

Some log-consistency providers (including `LogStorage` and `StateStorage`) use a standard StorageProvider to communicate with storage. This provider is specified using a separate `StorageProvider` attribute, as follows:

```csharp
[LogConsistencyProvider(ProviderName = "LogStorage")]
[StorageProvider(ProviderName = "AzureBlobStorage")]
public class ChatGrain :
    JournaledGrain<XDocument, IChatEvent>, IChatGrain
{
    // ...
}
```

## Default providers

It is possible to omit the `LogConsistencyProvider` and/or the `StorageProvider` attributes, if a default is specified in the configuration. This is done by using the special name `Default` for the respective provider. For example:

```xml
<LogConsistencyProviders>
    <Provider Name="Default"
        Type="Orleans.EventSourcing.LogStorage.LogConsistencyProvider"/>
</LogConsistencyProviders>
<StorageProviders>
    <Provider Name="Default"
        Type="Orleans.Storage.MemoryStorage" />
</StorageProviders>
```
