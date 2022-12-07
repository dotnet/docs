---
title: Grain persistence
description: Learn about persistence in .NET Orleans.
ms.date: 12/07/2022
---

# Grain persistence

Grains can have multiple named persistent data objects associated with them. These state objects are loaded from storage during grain activation so that they are available during requests. Grain persistence uses an extensible plugin model so that storage providers for any database can be used. This persistence model is designed for simplicity, and is not intended to cover all data access patterns. Grains can also access databases directly, without using the grain persistence model.

:::image type="content" source="media/grain-state-diagram.png" alt-text="Grain persistence diagram" lightbox="media/grain-state-diagram.png":::

In the above diagram, UserGrain has a *Profile- state and a*Cart- state, each of which is stored in a separate storage system.

## Goals

1. Multiple named persistent data objects per grain.
1. Multiple configured storage providers, each of which can have a different configuration and be backed by a different storage system.
1. Storage providers can be developed and published by the community.
1. Storage providers have complete control over how they store grain state data in the persistent backing store. Corollary: Orleans is not providing a comprehensive ORM storage solution, but instead allows custom storage providers to support specific ORM requirements as and when required.

## Packages

Orleans grain storage providers can be found on [NuGet](https://www.nuget.org/packages?q=Orleans+Persistence). Officially maintained packages include:

- [Microsoft.Orleans.Persistence.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet) is for SQL databases and other storage systems supported by ADO.NET. For more information, see [ADO.NET Grain Persistence](relational-storage.md).
- [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) is for Azure Storage, including Azure Blob Storage, Azure Table Storage, and Azure CosmosDB, via the Azure Table Storage API. For more information, see [Azure Storage Grain Persistence](azure-storage.md).
- [Microsoft.Orleans.Persistence.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB) is for Amazon DynamoDB. For more information, see [Amazon DynamoDB Grain Persistence](dynamodb-storage.md).

## API

Grains interact with their persistent state using <xref:Orleans.Runtime.IPersistentState%601> where `TState` is the serializable state type:

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

Instances of `IPersistentState<TState>` are injected into the grain as constructor parameters. These parameters can be annotated with a <xref:Orleans.Runtime.PersistentStateAttribute> attribute to identify the name of the state being injected and the name of the storage provider which provides it. The following example demonstrates this by injecting two named states into the `UserGrain` constructor:

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

Different grain types can use different configured storage providers, even if both are the same type; for example, two different Azure Table Storage provider instances, connected to different Azure Storage accounts.

### Read state

Grain state will automatically be read when the grain is activated, but grains are responsible for explicitly triggering the write for any changed grain state when necessary.

If a grain wishes to explicitly re-read the latest state for this grain from the backing store, the grain should call the <xref:Orleans.Grain%601.ReadStateAsync%2A> method. This will reload the grain state from the persistent store via the storage provider, and the previous in-memory copy of the grain state will be overwritten and replaced when the `Task` from `ReadStateAsync()` completes.

The value of the state is accessed using the `State` property. For example, the following method accesses the profile state declared in the code above:

```csharp
public Task<string> GetNameAsync() => Task.FromResult(_profile.State.Name);
```

There is no need to call `ReadStateAsync()` during normal operation; the state is loaded automatically during activation. However, `ReadStateAsync()` can be used to refresh state which is modified externally.

See the [Failure Modes](#FailureModes) section below for details of error-handling mechanisms.

### Write state

The state can be modified via the `State` property. The modified state is not automatically persisted. Instead, the developer decides when to persist state by calling the <xref:Orleans.Grain%601.WriteStateAsync%2A> method. For example, the following method updates a property on `State` and persists the updated state:

```csharp
public async Task SetNameAsync(string name)
{
    _profile.State.Name = name;
    await _profile.WriteStateAsync();
}
```

Conceptually, the Orleans Runtime will take a deep copy of the grain state data object for its use during any write operations. Under the covers, the runtime *may- use optimization rules and heuristics to avoid performing some or all of the deep copy in some circumstances, provided that the expected logical isolation semantics are preserved.

See the [Failure Modes](#FailureModes) section below for details of error handling mechanisms.

### Clear state

The <xref:Orleans.Grain%601.ClearStateAsync%2A> method clears the grain's state in storage. Depending on the provider, this operation may optionally delete the grain state entirely.

## Get started

Before a grain can use persistence, a storage provider must be configured on the silo.

First, configure storage providers, one for profile state and one for cart state:

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

Now that a storage provider has been configured with the name `"profileStore"`, we can access this provider from a grain.

The persistent state can be added to a grain in two primary ways:

1. By injecting `IPersistentState<TState>` into the grain's constructor.
2. By inheriting from <xref:Orleans.Grain%601>.

The recommended way to add storage to a grain is by injecting `IPersistentState<TState>` into the grain's constructor with an associated `[PersistentState("stateName", "providerName")]` attribute. For details on [`Grain<TState>`, see below](#using-graintstate-to-add-storage-to-a-grain). This is still supported but is considered a legacy approach.

Declare a class to hold our grain's state:

```csharp
[Serializable]
public class ProfileState
{
    public string Name { get; set; }

    public Date DateOfBirth
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

> [!NOTE]
> The profile state will not be loaded at the time it is injected into the constructor, so accessing it is invalid at that time. The state will be loaded before <xref:Orleans.Grain.OnActivateAsync%2A> is called.

Now that the grain has a persistent state, we can add methods to read and write the state:

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

## Failure modes for persistence operations <a name="FailureModes"></a>

### Failure modes for read operations

Failures returned by the storage provider during the initial read of state data for that particular grain will fail the activate operation for that grain; in such case, there will *not- be any call to that grain's `OnActivateAsync()` life cycle callback method. The original request to the grain which caused the activation will be faulted back to the caller, the same way as any other failure during grain activation. Failures encountered by the storage provider when reading state data for a particular grain will result in an exception from `ReadStateAsync()` `Task`. The grain can choose to handle or ignore the `Task` exception, just like any other `Task` in Orleans.

Any attempt to send a message to a grain that failed to load at silo startup time due to a missing/bad storage provider config will return the permanent error <xref:Orleans.Storage.BadProviderConfigException>.

### Failure modes for write operations

Failures encountered by the storage provider when writing state data for a particular grain will result in an exception thrown by `WriteStateAsync()` `Task`. Usually, this means that the grain call exception will be thrown back to the client caller, provided the `WriteStateAsync()` `Task` is correctly chained into the final return `Task` for this grain method. However, it is possible in certain advanced scenarios to write grain code to specifically handle such write errors, just like they can handle any other faulted `Task`.

Grains that execute error-handling / recovery code *must- catch exceptions / faulted `WriteStateAsync()` `Task`s and not re-throw them, to signify that they have successfully handled the write error.

## Recommendations

### Use JSON serialization or another version-tolerant serialization format

Code evolves and this often includes storage types, too. To accommodate these changes, an appropriate serializer should be configured. For most storage providers, a `UseJson` option or similar is available to use JSON as a serialization format. Ensure that when evolving data contracts that already-stored data will still be loadable.

## Using Grain&lt;TState&gt; to add storage to a grain

> [!IMPORTANT]
> Using `Grain<T>` to add storage to a grain is considered *legacy- functionality: grain storage should be added using `IPersistentState<T>` as previously described.

Grain classes that inherit from `Grain<T>` (where `T` is an application-specific state data type that needs to be persisted) will have their state loaded automatically from specified storage.

Such grains are marked with a <xref:Orleans.Providers.StorageProviderAttribute> that specifies a named instance of a storage provider to use for reading / writing the state data for this grain.

```csharp
[StorageProvider(ProviderName="store1")]
public class MyGrain : Grain<MyGrainState>, /*...*/
{
  /*...*/
}
```

The `Grain<T>` base class defined the following methods for subclasses to call:

```csharp
protected virtual Task ReadStateAsync() { /*...*/ }
protected virtual Task WriteStateAsync() { /*...*/ }
protected virtual Task ClearStateAsync() { /*...*/ }
```

The behavior of these methods corresponds to their counterparts on `IPersistentState<TState>` defined earlier.

## Create a storage provider

There are two parts to the state persistence APIs: the API exposed to the grain via `IPersistentState<T>` or `Grain<T>`, and the storage provider API, which is centered around `IGrainStorage` — the interface which storage providers must implement:

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

Create a custom storage provider by implementing this interface and [registering](#register-a-storage-provider) that implementation. For an example of an existing storage provider implementation, see [`AzureBlobGrainStorage`](https://github.com/dotnet/orleans/blob/af974d37864f85bfde5dc02f2f60bba997f2162d/src/Azure/Orleans.Persistence.AzureStorage/Providers/Storage/AzureBlobStorage.cs).

### Storage provider semantics

An opaque provider-specific <xref:Orleans.GrainState.Etag%2A> value (`string`) *may- be set by a storage provider as part of the grain state metadata populated when the state was read. Some providers may choose to leave this as `null` if they do not use `Etag`s.

Any attempt to perform a write operation when the storage provider detects an `Etag` constraint violation *should- cause the write `Task` to be faulted with transient error <xref:Orleans.Storage.InconsistentStateException> and wrapping the underlying storage exception.

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

Any other failure conditions from a storage operation *must- cause the returned `Task` to be broken with an exception indicating the underlying storage issue. In many cases, this exception may be thrown back to the caller which triggered the storage operation by calling a method on the grain. It is important to consider whether or not the caller will be able to deserialize this exception. For example, the client might not have loaded the specific persistence library containing the exception type. For this reason, it is advisable to convert exceptions into exceptions that can be propagated back to the caller.

### Data mapping

Individual storage providers should decide how best to store grain state – blob (various formats / serialized forms) or column-per-field are obvious choices.

### Register a storage provider

The Orleans runtime will resolve a storage provider from the service provider (<xref:System.IServiceProvider>) when a grain is created. The runtime will resolve an instance of <xref:Orleans.Storage.IGrainStorage>. If the storage provider is named, for example via the `[PersistentState(stateName, storageName)]` attribute, then a named instance of `IGrainStorage` will be resolved.

To register a named instance of `IGrainStorage`, use the <xref:Orleans.Runtime.KeyedServiceExtensions.AddSingletonNamedService%2A> extension method following the example of the [AzureTableGrainStorage provider here](https://github.com/dotnet/orleans/blob/af974d37864f85bfde5dc02f2f60bba997f2162d/src/Azure/Orleans.Persistence.AzureStorage/Hosting/AzureTableSiloBuilderExtensions.cs#L78).
