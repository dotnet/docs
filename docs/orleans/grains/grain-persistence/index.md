---
title: Grain persistence
description: Learn about grain persistence in .NET Orleans.
ms.date: 05/23/2025
ms.topic: overview
zone_pivot_groups: orleans-version
---

# Grain persistence

Grains can have multiple named persistent data objects associated with them. These state objects load from storage during grain activation so they're available during requests. Grain persistence uses an extensible plugin model, allowing you to use storage providers for any database. This persistence model is designed for simplicity and isn't intended to cover all data access patterns. Grains can also access databases directly without using the grain persistence model.

:::image type="content" source="media/grain-state-diagram.png" alt-text="Grain persistence diagram" lightbox="media/grain-state-diagram.png":::

In the preceding diagram, UserGrain has a *Profile* state and a *Cart* state, each stored in a separate storage system.

## Goals

1. Support multiple named persistent data objects per grain.
1. Allow multiple configured storage providers, each potentially having a different configuration and backed by a different storage system.
1. Enable the community to develop and publish storage providers.
1. Give storage providers complete control over how they store grain state data in the persistent backing store. Corollary: Orleans doesn't provide a comprehensive ORM storage solution but allows custom storage providers to support specific ORM requirements as needed.

## Packages

You can find Orleans grain storage providers on [NuGet](https://www.nuget.org/packages?q=Orleans+Persistence). Officially maintained packages include:

- [Microsoft.Orleans.Persistence.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet): For SQL databases and other storage systems supported by ADO.NET. For more information, see [ADO.NET grain persistence](relational-storage.md).
- [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage): For Azure Storage, including Azure Blob Storage and Azure Table Storage (via the Azure Table Storage API). For more information, see [Azure Storage grain persistence](azure-storage.md).
- [Microsoft.Orleans.Persistence.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Cosmos): The Azure Cosmos DB provider. For more information, see [Azure Cosmos DB grain persistence](azure-cosmos-db.md).
- [Microsoft.Orleans.Persistence.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB): For Amazon DynamoDB. For more information, see [Amazon DynamoDB grain persistence](dynamodb-storage.md).

## API

Grains interact with their persistent state using <xref:Orleans.Runtime.IPersistentState%601>, where `TState` is the serializable state type:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
public interface IPersistentState<TState> : IStorage<TState>
{
}

public interface IStorage<TState> : IStorage
{
    TState State { get; set; }
}

public interface IStorage
{
    string Etag { get; }

    bool RecordExists { get; }

    Task ClearStateAsync();

    Task WriteStateAsync();

    Task ReadStateAsync();
}
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
public interface IPersistentState<TState> where TState : new()
{
    TState State { get; set; }

    string Etag { get; }

    Task ClearStateAsync();

    Task WriteStateAsync();

    Task ReadStateAsync();
}
```

:::zone-end

Orleans injects instances of `IPersistentState<TState>` into the grain as constructor parameters. You can annotate these parameters with a <xref:Orleans.Runtime.PersistentStateAttribute> attribute to identify the name of the state being injected and the name of the storage provider supplying it. The following example demonstrates this by injecting two named states into the `UserGrain` constructor:

```csharp
public class UserGrain : Grain, IUserGrain
{
    private readonly IPersistentState<ProfileState> _profile;
    private readonly IPersistentState<CartState> _cart;

    public UserGrain(
        [PersistentState("profile", "profileStore")] IPersistentState<ProfileState> profile,
        [PersistentState("cart", "cartStore")] IPersistentState<CartState> cart)
    {
        _profile = profile;
        _cart = cart;
    }
}
```

Different grain types can use different configured storage providers, even if both are the same type (e.g., two different Azure Table Storage provider instances connected to different Azure Storage accounts).

### Read state

Grain state automatically reads when the grain activates, but grains are responsible for explicitly triggering the write for any changed grain state when necessary.

If a grain wishes to explicitly re-read its latest state from the backing store, it should call the <xref:Orleans.Grain%601.ReadStateAsync%2A> method. This reloads the grain state from the persistent store via the storage provider. The previous in-memory copy of the grain state is overwritten and replaced when the `Task` from `ReadStateAsync()` completes.

Access the value of the state using the `State` property. For example, the following method accesses the profile state declared in the code above:

```csharp
public Task<string> GetNameAsync() => Task.FromResult(_profile.State.Name);
```

There's no need to call `ReadStateAsync()` during normal operation; Orleans loads the state automatically during activation. However, you can use `ReadStateAsync()` to refresh state modified externally.

See the [Failure modes](#failure-modes) section below for details on error-handling mechanisms.

### Write state

You can modify the state via the `State` property. The modified state isn't automatically persisted. Instead, you decide when to persist state by calling the <xref:Orleans.Grain%601.WriteStateAsync%2A> method. For example, the following method updates a property on `State` and persists the updated state:

```csharp
public async Task SetNameAsync(string name)
{
    _profile.State.Name = name;
    await _profile.WriteStateAsync();
}
```

Conceptually, the Orleans Runtime takes a deep copy of the grain state data object for its use during any write operations. Under the covers, the runtime *might* use optimization rules and heuristics to avoid performing some or all of the deep copy in certain circumstances, provided the expected logical isolation semantics are preserved.

See the [Failure modes](#failure-modes) section below for details on error handling mechanisms.

### Clear state

The <xref:Orleans.Grain%601.ClearStateAsync%2A> method clears the grain's state in storage. Depending on the provider, this operation might optionally delete the grain state entirely.

## Get started

Before a grain can use persistence, you must configure a storage provider on the silo.

First, configure storage providers, one for profile state and one for cart state:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
using IHost host = new HostBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.AddAzureTableGrainStorage(
            name: "profileStore",
            configureOptions: options =>
            {
                // Configure the storage connection key
                options.ConfigureTableServiceClient(
                    "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1");
            })
            .AddAzureBlobGrainStorage(
                name: "cartStore",
                configureOptions: options =>
                {
                    // Configure the storage connection key
                    options.ConfigureTableServiceClient(
                        "DefaultEndpointsProtocol=https;AccountName=data2;AccountKey=SOMETHING2");
                });
    })
    .Build();
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
var host = new HostBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.AddAzureTableGrainStorage(
            name: "profileStore",
            configureOptions: options =>
            {
                // Use JSON for serializing the state in storage
                options.UseJson = true;

                // Configure the storage connection key
                options.ConnectionString =
                    "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1";
            })
            .AddAzureBlobGrainStorage(
                name: "cartStore",
                configureOptions: options =>
                {
                    // Use JSON for serializing the state in storage
                    options.UseJson = true;

                    // Configure the storage connection key
                    options.ConnectionString =
                        "DefaultEndpointsProtocol=https;AccountName=data2;AccountKey=SOMETHING2";
                });
    })
    .Build();
```

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

:::zone-end

Now that you've configured a storage provider named `"profileStore"`, you can access this provider from a grain.

You can add persistent state to a grain in two primary ways:

1. By injecting `IPersistentState<TState>` into the grain's constructor.
1. By inheriting from <xref:Orleans.Grain%601>.

The recommended way to add storage to a grain is by injecting `IPersistentState<TState>` into the grain's constructor with an associated `[PersistentState("stateName", "providerName")]` attribute. For details on `Grain<TState>`, see [Using `Grain<TState>` to add storage to a grain](#using-graintstate-to-add-storage-to-a-grain) below. Using `Grain<TState>` is still supported but considered a legacy approach.

Declare a class to hold your grain's state:

```csharp
[Serializable]
public class ProfileState
{
    public string Name { get; set; }

    public Date DateOfBirth { get; set; }
}
```

Inject `IPersistentState<ProfileState>` into the grain's constructor:

```csharp
public class UserGrain : Grain, IUserGrain
{
    private readonly IPersistentState<ProfileState> _profile;

    public UserGrain(
        [PersistentState("profile", "profileStore")]
        IPersistentState<ProfileState> profile)
    {
        _profile = profile;
    }
}
```

> [!IMPORTANT]
> The profile state will not be loaded at the time it is injected into the constructor, so accessing it is invalid at that time. The state will be loaded before <xref:Orleans.Grain.OnActivateAsync%2A> is called.

Now that the grain has a persistent state, you can add methods to read and write the state:

```csharp
public class UserGrain : Grain, IUserGrain
{
    private readonly IPersistentState<ProfileState> _profile;

    public UserGrain(
        [PersistentState("profile", "profileStore")]
        IPersistentState<ProfileState> profile)
    {
        _profile = profile;
    }

    public Task<string> GetNameAsync() => Task.FromResult(_profile.State.Name);

    public async Task SetNameAsync(string name)
    {
        _profile.State.Name = name;
        await _profile.WriteStateAsync();
    }
}
```

## Failure modes for persistence operations <a name="failure-modes"></a>

### Failure modes for read operations

Failures returned by the storage provider during the initial read of state data for a particular grain fail the activation operation for that grain. In such cases, there won't be any call to that grain's `OnActivateAsync` lifecycle callback method. The original request to the grain that caused the activation faults back to the caller, just like any other failure during grain activation. Failures encountered by the storage provider when reading state data for a particular grain result in an exception from the `ReadStateAsync` `Task`. The grain can choose to handle or ignore the `Task` exception, just like any other `Task` in Orleans.

Any attempt to send a message to a grain that failed to load at silo startup due to a missing or bad storage provider configuration returns the permanent error <xref:Orleans.Storage.BadProviderConfigException>.

### Failure modes for write operations

Failures encountered by the storage provider when writing state data for a particular grain result in an exception thrown by the `WriteStateAsync()` `Task`. Usually, this means the grain call exception is thrown back to the client caller, provided the `WriteStateAsync()` `Task` is correctly chained into the final return `Task` for this grain method. However, in certain advanced scenarios, you can write grain code to specifically handle such write errors, just like handling any other faulted `Task`.

Grains executing error-handling or recovery code *must* catch exceptions or faulted `WriteStateAsync()` `Task`s and not rethrow them, signifying they have successfully handled the write error.

## Recommendations

### Use JSON serialization or another version-tolerant serialization format

Code evolves, and this often includes storage types. To accommodate these changes, configure an appropriate serializer. For most storage providers, a `UseJson` option or similar is available to use JSON as the serialization format. Ensure that when evolving data contracts, already-stored data can still be loaded.

## Using `Grain<TState>` to add storage to a grain

> [!IMPORTANT]
> Using `Grain<T>` to add storage to a grain is considered *legacy* functionality. Add grain storage using `IPersistentState<T>` as previously described.

Grain classes inheriting from `Grain<T>` (where `T` is an application-specific state data type needing persistence) have their state loaded automatically from the specified storage.

Mark such grains with a <xref:Orleans.Providers.StorageProviderAttribute> specifying a named instance of a storage provider to use for reading/writing the state data for this grain.

```csharp
[StorageProvider(ProviderName="store1")]
public class MyGrain : Grain<MyGrainState>, /*...*/
{
  /*...*/
}
```

The `Grain<T>` base class defines the following methods for subclasses to call:

```csharp
protected virtual Task ReadStateAsync() { /*...*/ }
protected virtual Task WriteStateAsync() { /*...*/ }
protected virtual Task ClearStateAsync() { /*...*/ }
```

The behavior of these methods corresponds to their counterparts on `IPersistentState<TState>` defined earlier.

## Create a storage provider

There are two parts to the state persistence APIs: the API exposed to the grain via `IPersistentState<T>` or `Grain<T>`, and the storage provider API, centered around `IGrainStorage`—the interface storage providers must implement:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
/// <summary>
/// Interface to be implemented for a storage able to read and write Orleans grain state data.
/// </summary>
public interface IGrainStorage
{
    /// <summary>Read data function for this storage instance.</summary>
    /// <param name="stateName">Name of the state for this grain</param>
    /// <param name="grainId">Grain ID</param>
    /// <param name="grainState">State data object to be populated for this grain.</param>
    /// <typeparam name="T">The grain state type.</typeparam>
    /// <returns>Completion promise for the Read operation on the specified grain.</returns>
    Task ReadStateAsync<T>(
        string stateName, GrainId grainId, IGrainState<T> grainState);

    /// <summary>Write data function for this storage instance.</summary>
    /// <param name="stateName">Name of the state for this grain</param>
    /// <param name="grainId">Grain ID</param>
    /// <param name="grainState">State data object to be written for this grain.</param>
    /// <typeparam name="T">The grain state type.</typeparam>
    /// <returns>Completion promise for the Write operation on the specified grain.</returns>
    Task WriteStateAsync<T>(
        string stateName, GrainId grainId, IGrainState<T> grainState);

    /// <summary>Delete / Clear data function for this storage instance.</summary>
    /// <param name="stateName">Name of the state for this grain</param>
    /// <param name="grainId">Grain ID</param>
    /// <param name="grainState">Copy of last-known state data object for this grain.</param>
    /// <typeparam name="T">The grain state type.</typeparam>
    /// <returns>Completion promise for the Delete operation on the specified grain.</returns>
    Task ClearStateAsync<T>(
        string stateName, GrainId grainId, IGrainState<T> grainState);
}
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
/// <summary>
/// Interface to be implemented for a storage able to read and write Orleans grain state data.
/// </summary>
public interface IGrainStorage
{
    /// <summary>Read data function for this storage instance.</summary>
    /// <param name="grainType">Type of this grain [fully qualified class name]</param>
    /// <param name="grainReference">Grain reference object for this grain.</param>
    /// <param name="grainState">State data object to be populated for this grain.</param>
    /// <returns>Completion promise for the Read operation on the specified grain.</returns>
    Task ReadStateAsync(
        string grainType, GrainReference grainReference, IGrainState grainState);

    /// <summary>Write data function for this storage instance.</summary>
    /// <param name="grainType">Type of this grain [fully qualified class name]</param>
    /// <param name="grainReference">Grain reference object for this grain.</param>
    /// <param name="grainState">State data object to be written for this grain.</param>
    /// <returns>Completion promise for the Write operation on the specified grain.</returns>
    Task WriteStateAsync(
        string grainType, GrainReference grainReference, IGrainState grainState);

    /// <summary>Delete / Clear data function for this storage instance.</summary>
    /// <param name="grainType">Type of this grain [fully qualified class name]</param>
    /// <param name="grainReference">Grain reference object for this grain.</param>
    /// <param name="grainState">Copy of last-known state data object for this grain.</param>
    /// <returns>Completion promise for the Delete operation on the specified grain.</returns>
    Task ClearStateAsync(
        string grainType, GrainReference grainReference, IGrainState grainState);
}
```

:::zone-end

Create a custom storage provider by implementing this interface and [registering](#register-a-storage-provider) that implementation. For an example of an existing storage provider implementation, see [`AzureBlobGrainStorage`](https://github.com/dotnet/orleans/blob/af974d37864f85bfde5dc02f2f60bba997f2162d/src/Azure/Orleans.Persistence.AzureStorage/Providers/Storage/AzureBlobStorage.cs).

### Storage provider semantics

An opaque provider-specific <xref:Orleans.GrainState.Etag%2A> value (`string`) *may* be set by a storage provider as part of the grain state metadata populated when the state was read. Some providers may choose to leave this as `null` if they don't use `Etag`s.

Any attempt to perform a write operation when the storage provider detects an `Etag` constraint violation *should* cause the write `Task` to be faulted with transient error <xref:Orleans.Storage.InconsistentStateException> and wrapping the underlying storage exception.

```csharp
public class InconsistentStateException : OrleansException
{
    public InconsistentStateException(
    string message,
    string storedEtag,
    string currentEtag,
    Exception storageException)
        : base(message, storageException)
    {
        StoredEtag = storedEtag;
        CurrentEtag = currentEtag;
    }

    public InconsistentStateException(
        string storedEtag,
        string currentEtag,
        Exception storageException)
        : this(storageException.Message, storedEtag, currentEtag, storageException)
    {
    }

    /// <summary>The Etag value currently held in persistent storage.</summary>
    public string StoredEtag { get; }

    /// <summary>The Etag value currently held in memory, and attempting to be updated.</summary>
    public string CurrentEtag { get; }
}
```

Any other failure conditions from a storage operation *must* cause the returned `Task` to be broken with an exception indicating the underlying storage issue. In many cases, this exception might be thrown back to the caller who triggered the storage operation by calling a method on the grain. It's important to consider whether the caller can deserialize this exception. For example, the client might not have loaded the specific persistence library containing the exception type. For this reason, it's advisable to convert exceptions into exceptions that can propagate back to the caller.

### Data mapping

Individual storage providers should decide how best to store grain state – blob (various formats / serialized forms) or column-per-field are obvious choices.

### Register a storage provider

The Orleans runtime resolves a storage provider from the service provider (<xref:System.IServiceProvider>) when a grain is created. The runtime resolves an instance of <xref:Orleans.Storage.IGrainStorage>. If the storage provider is named (for example, via the `[PersistentState(stateName, storageName)]` attribute), then a named instance of `IGrainStorage` is resolved.

To register a named instance of `IGrainStorage`, use the <xref:Orleans.Runtime.KeyedServiceExtensions.AddSingletonNamedService%2A> extension method, following the example of the [AzureTableGrainStorage provider here](https://github.com/dotnet/orleans/blob/af974d37864f85bfde5dc02f2f60bba997f2162d/src/Azure/Orleans.Persistence.AzureStorage/Hosting/AzureTableSiloBuilderExtensions.cs#L78).
