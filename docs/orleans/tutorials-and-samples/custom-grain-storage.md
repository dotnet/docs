---
title: Custom grain storage sample project
description: Explore a custom grain storage sample project written with .NET Orleans.
ms.date: 07/03/2024
zone_pivot_groups: orleans-version
ms.topic: article
---

# Custom grain storage

In the tutorial on declarative actor storage, we looked at allowing grains to store their state in an Azure table using one of the built-in storage providers. While Azure is a great place to squirrel away your data, there are many alternatives. There are so many that there was no way to support them all. Instead, Orleans is designed to let you easily add support for your form of storage by writing a grain storage.

In this tutorial, we'll walk through how to write simple file-based grain storage. A file system is not the best place to store grains states as it is local, there can be issues with file locks and the last update date is not sufficient to prevent inconsistency. But it's an easy example to help us illustrate the implementation of a _grain storage_.

## Get started

An Orleans grain storage is a class that implements `IGrainStorage`, which is included in [Microsoft.Orleans.Core](https://www.nuget.org/packages/Microsoft.Orleans.Core) NuGet package. It will also inherit from `ILifecycleParticipant<ISiloLifecycle>`, which will allow you to subscribe to a particular event in the lifecycle of the silo. You start by creating a class named `FileGrainStorage`.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
using Microsoft.Extensions.Options;
using Orleans.Configuration;
using Orleans.Runtime;
using Orleans.Storage;

namespace GrainStorage;

public sealed class FileGrainStorage : IGrainStorage, ILifecycleParticipant<ISiloLifecycle>
{
    private readonly string _storageName;
    private readonly FileGrainStorageOptions _options;
    private readonly ClusterOptions _clusterOptions;

    public FileGrainStorage(
        string storageName,
        FileGrainStorageOptions options,
        IOptions<ClusterOptions> clusterOptions)
    {
        _storageName = storageName;
        _options = options;
        _clusterOptions = clusterOptions.Value;
    }

    public Task ClearStateAsync<T>(
        string stateName,
        GrainId grainId,
        IGrainState<T> grainState)
    {
        throw new NotImplementedException();
    }

    public Task ReadStateAsync<T>(
        string stateName,
        GrainId grainId,
        IGrainState<T> grainState)
    {
        throw new NotImplementedException();
    }

    public Task WriteStateAsync<T>(
        string stateName,
        GrainId grainId,
        IGrainState<T> grainState)
    {
        throw new NotImplementedException();
    }

    public void Participate(ISiloLifecycle lifecycle) =>
        throw new NotImplementedException();
}
```

Each method implements the corresponding method in the [IGrainStorage](xref:Orleans.Storage.IGrainStorage) interface, accepting a generic-type parameter for the underlying state type. The methods are:

- <xref:Orleans.Storage.IGrainStorage.ReadStateAsync%2A?displayProperty=nameWithType>: to read the state of a grain.
- <xref:Orleans.Storage.IGrainStorage.WriteStateAsync%2A?displayProperty=nameWithType>: to write the state of a grain.
- <xref:Orleans.Storage.IGrainStorage.ClearStateAsync%2A?displayProperty=nameWithType>: to clear the state of a grain.

The <xref:Orleans.ILifecycleParticipant%601.Participate%2A?displayProperty=nameWithType> method is used to subscribe to the lifecycle of the silo.

Before starting the implementation, you'll create an options class containing the root directory where the grain state files are persisted. For that you'll create an options file named `FileGrainStorageOptions` containing the following:

:::code source="snippets/custom-grain-storage/FileGrainStorageOptions.cs":::

With the options class created, you'll explore the constructor parameters of the `FileGrainStorage` class:

- `storageName`: to specify which grains should write using this storage, for example `[StorageProvider(ProviderName = "File")]`.
- `options`: the options class we just created.
- `clusterOptions`: the cluster options used for retrieving the `ServiceId`.

## Initialize the storage

To initialize the storage, you subscribe to the <xref:Orleans.ServiceLifecycleStage.ApplicationServices?displayProperty=nameWithType> stage with an `onStart` function. Consider the following <xref:Orleans.ILifecycleParticipant%601.Participate%2A?displayProperty=nameWithType> implementation:

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="participate":::

The `onStart` function is used to conditionally create the root directory to store the grains states when it doesn't already exist.

You'll also provide a common function to construct the filename ensuring uniqueness per service, grain id, and grain type:

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="getkeystring":::

## Read state

To read a grain state, you get the filename using the `GetKeyString` function and combine it with the root directory coming from the `_options` instance.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="readstateasync":::

We use the `fileInfo.LastWriteTimeUtc` as an `ETag` which will be used by other functions for inconsistency checks to prevent data loss.

For the deserialization, you use the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer?displayProperty=nameWithType>. This is important to be able to serialize/deserialize properly the state.

## Write state

Writing the state is similar to reading the state.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="writestateasync":::

Similar to reading state, you use the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer?displayProperty=nameWithType> to write the state. The current `ETag` is used to check against the last updated time in the UTC of the file. If the date is different, it means that another activation of the same grain changed the state concurrently. In this situation, you'll throw an `InconsistentStateException`, which will result in the current activation being killed to prevent overwriting the state previously saved by the other activated grain.

## Clear state

Clearing the state would be deleting the file if the file exists.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="clearstateasync":::

For the same reason as `WriteState`, you check for inconsistency. Before proceeding to delete the file and reset the `ETag`, you check if the current `ETag` is the same as the last write time UTC.

## Put it all together

After that, you will create a factory that will allow you to scope the options to the provider name and at the same time create an instance of the `FileGrainStorage` to ease the registration to the service collection.

:::code source="snippets/custom-grain-storage/FileGrainStorageFactory.cs":::

Lastly, to register the grain storage, you create an extension on the `ISiloBuilder` which internally registers the grain storage as a named service using <xref:Orleans.Runtime.KeyedServiceExtensions.AddSingletonNamedService%2A>, an extension provided by `Orleans.Core`.

:::code source="snippets/custom-grain-storage/FileSiloBuilderExtensions.cs":::

Our `FileGrainStorage` implements two interfaces, `IGrainStorage` and `ILifecycleParticipant<ISiloLifecycle>`, therefore we need to register two named services for each interface:

```csharp
return services.AddSingletonNamedService(providerName, FileGrainStorageFactory.Create)
    .AddSingletonNamedService(providerName,
        (p, n) => (ILifecycleParticipant<ISiloLifecycle>)p.GetRequiredServiceByName<IGrainStorage>(n));
```

This enables you to add the file storage using the extension on the `ISiloBuilder`:

:::code source="snippets/custom-grain-storage/Program.cs":::

Now you will be able to decorate your grains with the provider `[StorageProvider(ProviderName = "File")]` and it will store in the grain state in the root directory set in the options. Consider the full implementation of the `FileGrainStorage`:

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs":::

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Storage;
using Orleans.Runtime;

namespace GrainStorage;

public class FileGrainStorage
    : IGrainStorage, ILifecycleParticipant<ISiloLifecycle>
{
    private readonly string _storageName;
    private readonly FileGrainStorageOptions _options;
    private readonly ClusterOptions _clusterOptions;
    private readonly IGrainFactory _grainFactory;
    private readonly ITypeResolver _typeResolver;
    private JsonSerializerSettings _jsonSettings;

    public FileGrainStorage(
        string storageName,
        FileGrainStorageOptions options,
        IOptions<ClusterOptions> clusterOptions,
        IGrainFactory grainFactory,
        ITypeResolver typeResolver)
    {
        _storageName = storageName;
        _options = options;
        _clusterOptions = clusterOptions.Value;
        _grainFactory = grainFactory;
        _typeResolver = typeResolver;
    }

    public Task ClearStateAsync(
        string grainType,
        GrainReference grainReference,
        IGrainState grainState)
    {
        throw new NotImplementedException();
    }

    public Task ReadStateAsync(
        string grainType,
        GrainReference grainReference,
        IGrainState grainState)
    {
        throw new NotImplementedException();
    }

    public Task WriteStateAsync(
        string grainType,
        GrainReference grainReference,
        IGrainState grainState)
    {
        throw new NotImplementedException();
    }

    public void Participate(
        ISiloLifecycle lifecycle)
    {
        throw new NotImplementedException();
    }
}
```

Before starting the implementation, we create an option class containing the root directory where the grains states files will be stored. For that we will create an options file `FileGrainStorageOptions`:

```csharp
public class FileGrainStorageOptions
{
    public string RootDirectory { get; set; }
}
```

The create a constructor containing two fields, `storageName` to specify which grains should write using this storage `[StorageProvider(ProviderName = "File")]` and `directory` which would be the directory where the grain states will be saved.

`IGrainFactory`, `ITypeResolver` will be used in the next section where we will initialize the storage.

We also take two options as an argument, our own `FileGrainStorageOptions` and the `ClusterOptions`. Those will be needed for the implementation of the storage functionalities.

We also need `JsonSerializerSettings` as we are serializing and deserializing in JSON format.

> [!IMPORTANT]
> JSON is an implementation detail, it is up to the developer to decide what serialization/deserialization protocol would fit the application. Another common format is binary.

## Initialize the storage

To initialize the storage, we register an `Init` function on the `ApplicationServices` lifecycle.

```csharp
public void Participate(ISiloLifecycle lifecycle)
{
    lifecycle.Subscribe(
        OptionFormattingUtilities.Name<FileGrainStorage>(_storageName),
        ServiceLifecycleStage.ApplicationServices,
        Init);
}
```

The `Init` function is used to set the `_jsonSettings` which will be used to configure the `Json` serializer. At the same time, we create the folder to store the grains states if it does not exist yet.

```csharp
private Task Init(CancellationToken ct)
{
    // Settings could be made configurable from Options.
    _jsonSettings =
        OrleansJsonSerializer.UpdateSerializerSettings(
            OrleansJsonSerializer.GetDefaultSerializerSettings(
                _typeResolver,
                _grainFactory),
            false,
            false,
            null);

    var directory = new System.IO.DirectoryInfo(_rootDirectory);
    if (!directory.Exists)
        directory.Create();

    return Task.CompletedTask;
}
```

We also provide a common function to construct the filename ensuring uniqueness per service, grain id, and grain type.

```csharp
private string GetKeyString(string grainType, GrainReference grainReference)
{
    return $"{_clusterOptions.ServiceId}.{grainReference.ToKeyString()}.{grainType}";
}
```

## Read state

To read a grain state, we get the filename using the function we previously defined and combine it to the root directory coming from the options.

```csharp
public async Task ReadStateAsync(
    string grainType,
    GrainReference grainReference,
    IGrainState grainState)
{
    var fName = GetKeyString(grainType, grainReference);
    var path = Path.Combine(_options.RootDirectory, fName);

    var fileInfo = new FileInfo(path);
    if (!fileInfo.Exists)
    {
        grainState.State = Activator.CreateInstance(grainState.State.GetType());
        return;
    }

    using (var stream = fileInfo.OpenText())
    {
        var storedData = await stream.ReadToEndAsync();
        grainState.State = JsonConvert.DeserializeObject(storedData, _jsonSettings);
    }

    grainState.ETag = fileInfo.LastWriteTimeUtc.ToString();
}
```

We use the `fileInfo.LastWriteTimeUtc` as an ETag which will be used by other functions for inconsistency checks to prevent data loss.

Note that for the deserialization, we use the `_jsonSettings` which was set on the `Init` function. This is important to be able to serialize/deserialize properly the state.

## Write state

Writing the state is similar to reading the state.

```csharp
public async Task WriteStateAsync(
    string grainType,
    GrainReference grainReference,
    IGrainState grainState)
{
    var storedData = JsonConvert.SerializeObject(grainState.State, _jsonSettings);

    var fName = GetKeyString(grainType, grainReference);
    var path = Path.Combine(_options.RootDirectory, fName);

    var fileInfo = new FileInfo(path);

    if (fileInfo.Exists && fileInfo.LastWriteTimeUtc.ToString() != grainState.ETag)
    {
        throw new InconsistentStateException(
            $"Version conflict (WriteState): ServiceId={_clusterOptions.ServiceId} " +
            $"ProviderName={_storageName} GrainType={grainType} " +
            $"GrainReference={grainReference.ToKeyString()}.");
    }

    using (var stream = new StreamWriter(fileInfo.Open(FileMode.Create, FileAccess.Write)))
    {
        await stream.WriteAsync(storedData);
    }

    fileInfo.Refresh();
    grainState.ETag = fileInfo.LastWriteTimeUtc.ToString();
}
```

Similar to reading state, we use `_jsonSettings` to write the state. The current ETag is used to check against the last updated time in the UTC of the file. If the date is different, it means that another activation of the same grain changed the state concurrently. In this situation, we throw an `InconsistentStateException` which will result in the current activation being killed to prevent overwriting the state previously saved by the other activated grain.

## Clear state

Clearing the state would be deleting the file if the file exists.

```csharp
public Task ClearStateAsync(
    string grainType,
    GrainReference grainReference,
    IGrainState grainState)
{
    var fName = GetKeyString(grainType, grainReference);
    var path = Path.Combine(_options.RootDirectory, fName);

    var fileInfo = new FileInfo(path);
    if (fileInfo.Exists)
    {
        if (fileInfo.LastWriteTimeUtc.ToString() != grainState.ETag)
        {
            throw new InconsistentStateException(
                $"Version conflict (ClearState): ServiceId={_clusterOptions.ServiceId} " +
                $"ProviderName={_storageName} GrainType={grainType} " +
                $"GrainReference={grainReference.ToKeyString()}.");
        }

        grainState.ETag = null;
        grainState.State = Activator.CreateInstance(grainState.State.GetType());
        fileInfo.Delete();
    }

    return Task.CompletedTask;
}
```

For the same reason as `WriteState`, we check for inconsistency before proceeding to delete the file and reset the ETag, we check if the current ETag is the same as the last write time UTC.

## Put it all together

After that, we will create a factory that will allow us to scope the options to the provider name and at the same time create an instance of the `FileGrainStorage` to ease the registration to the service collection.

```csharp
public static class FileGrainStorageFactory
{
    internal static IGrainStorage Create(
        IServiceProvider services, string name)
    {
        IOptionsSnapshot<FileGrainStorageOptions> optionsSnapshot =
            services.GetRequiredService<IOptionsSnapshot<FileGrainStorageOptions>>();

        return ActivatorUtilities.CreateInstance<FileGrainStorage>(
            services,
            name,
            optionsSnapshot.Get(name),
            services.GetProviderClusterOptions(name));
    }
}
```

Lastly, to register the grain storage, we create an extension on the `ISiloHostBuilder` which internally registers the grain storage as a named service using `.AddSingletonNamedService(...)`, an extension provided by `Orleans.Core`.

```csharp
public static class FileSiloBuilderExtensions
{
    public static ISiloHostBuilder AddFileGrainStorage(
        this ISiloHostBuilder builder,
        string providerName,
        Action<FileGrainStorageOptions> options)
    {
        return builder.ConfigureServices(
            services => services.AddFileGrainStorage(providerName, options));
    }

    public static IServiceCollection AddFileGrainStorage(
        this IServiceCollection services,
        string providerName,
        Action<FileGrainStorageOptions> options)
    {
        services.AddOptions<FileGrainStorageOptions>(providerName).Configure(options);

        return services.AddSingletonNamedService(providerName, FileGrainStorageFactory.Create)
            .AddSingletonNamedService(
                providerName,
                (s, n) => (ILifecycleParticipant<ISiloLifecycle>)s.GetRequiredServiceByName<IGrainStorage>(n));
    }
}
```

Our `FileGrainStorage` implements two interfaces, `IGrainStorage` and `ILifecycleParticipant<ISiloLifecycle>` therefore we need to register two named services for each interfaces:

```csharp
return services.AddSingletonNamedService(providerName, FileGrainStorageFactory.Create)
    .AddSingletonNamedService(
        providerName,
        (s, n) => (ILifecycleParticipant<ISiloLifecycle>)s.GetRequiredServiceByName<IGrainStorage>(n));
```

This enables us to add the file storage using the extension on the `ISiloHostBuilder`:

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering()
            .AddFileGrainStorage("File", opts =>
            {
                opts.RootDirectory = "C:/TestFiles";
            });
    })
    .Build();
```

Now we will be able to decorate our grains with the provider `[StorageProvider(ProviderName = "File")]` and it will store in the grain state in the root directory set in the options.

:::zone-end
