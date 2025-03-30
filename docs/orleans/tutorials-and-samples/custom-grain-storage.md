---
title: Custom grain storage sample project
description: Explore a custom grain storage sample project written with .NET Orleans.
ms.date: 03/30/2025
ms.topic: tutorial
ms.service: orleans
zone_pivot_groups: orleans-version
---

# Custom grain storage

In the tutorial on declarative actor storage, you learned how to allow grains to store their state in an Azure table using one of the built-in storage providers. While Azure is a great place to store your data, many alternatives exist. There are so many that supporting them all isn't feasible. Instead, Orleans is designed to let you easily add support for your preferred storage by writing a custom grain storage provider.

In this tutorial, you'll walk through how to write a simple file-based grain storage provider. A file system isn't the best place to store grain states because it's local, can have issues with file locks, and the last update date isn't sufficient to prevent inconsistency. However, it's an easy example to illustrate the implementation of a _grain storage_ provider.

## Get started

An Orleans grain storage provider is a class that implements `IGrainStorage`, included in the [Microsoft.Orleans.Core](https://www.nuget.org/packages/Microsoft.Orleans.Core) NuGet package. It also inherits from `ILifecycleParticipant<ISiloLifecycle>`, allowing you to subscribe to specific events in the silo's lifecycle. Start by creating a class named `FileGrainStorage`.

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

Each method implements the corresponding method in the `IGrainStorage` interface, accepting a generic type parameter for the underlying state type. The methods are:

- <xref:Orleans.Storage.IGrainStorage.ReadStateAsync%2A?displayProperty=nameWithType>: Reads the state of a grain.
- <xref:Orleans.Storage.IGrainStorage.WriteStateAsync%2A?displayProperty=nameWithType>: Writes the state of a grain.
- <xref:Orleans.Storage.IGrainStorage.ClearStateAsync%2A?displayProperty=nameWithType>: Clears the state of a grain.

The <xref:Orleans.ILifecycleParticipant%601.Participate%2A?displayProperty=nameWithType> method subscribes to the silo's lifecycle.

Before starting the implementation, create an options class containing the root directory where grain state files are persisted. Create an options file named `FileGrainStorageOptions` containing the following:

:::code source="snippets/custom-grain-storage/FileGrainStorageOptions.cs":::

With the options class created, explore the constructor parameters of the `FileGrainStorage` class:

- `storageName`: Specifies which grains should use this storage provider, for example, `[StorageProvider(ProviderName = "File")]`.
- `options`: The options class just created.
- `clusterOptions`: The cluster options used for retrieving the `ServiceId`.

## Initialize the storage

To initialize the storage, subscribe to the <xref:Orleans.ServiceLifecycleStage.ApplicationServices?displayProperty=nameWithType> stage with an `onStart` function. Consider the following <xref:Orleans.ILifecycleParticipant%601.Participate%2A?displayProperty=nameWithType> implementation:

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="participate":::

The `onStart` function conditionally creates the root directory to store grain states if it doesn't already exist.

Also, provide a common function to construct the filename, ensuring uniqueness per service, grain ID, and grain type:

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="getkeystring":::

## Read state

To read a grain state, get the filename using the `GetKeyString` function and combine it with the root directory from the `_options` instance.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="readstateasync":::

Use `fileInfo.LastWriteTimeUtc` as an `ETag`, which other functions use for inconsistency checks to prevent data loss.

For deserialization, use the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer?displayProperty=nameWithType>. This is important for correctly serializing and deserializing the state.

## Write state

Writing the state is similar to reading the state.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="writestateasync":::

Similar to reading state, use the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer?displayProperty=nameWithType> to write the state. The current `ETag` checks against the file's last updated UTC time. If the date differs, it means another activation of the same grain changed the state concurrently. In this situation, throw an `InconsistentStateException`. This results in the current activation being killed to prevent overwriting the state previously saved by the other activated grain.

## Clear state

Clearing the state involves deleting the file if it exists.

:::code source="snippets/custom-grain-storage/FileGrainStorage.cs" id="clearstateasync":::

For the same reason as `WriteStateAsync`, check for inconsistency. Before deleting the file and resetting the `ETag`, check if the current `ETag` matches the last write time UTC.

## Put it all together

Next, create a factory that allows scoping the options to the provider name while creating an instance of `FileGrainStorage` to ease registration with the service collection.

:::code source="snippets/custom-grain-storage/FileGrainStorageFactory.cs":::

Lastly, to register the grain storage, create an extension on `ISiloBuilder`. This extension internally registers the grain storage as a named service using <xref:Orleans.Runtime.KeyedServiceExtensions.AddSingletonNamedService%2A>, an extension provided by `Orleans.Core`.

:::code source="snippets/custom-grain-storage/FileSiloBuilderExtensions.cs":::

The `FileGrainStorage` implements two interfaces, `IGrainStorage` and `ILifecycleParticipant<ISiloLifecycle>`. Therefore, register two named services, one for each interface:

```csharp
return services.AddSingletonNamedService(providerName, FileGrainStorageFactory.Create)
    .AddSingletonNamedService(providerName,
        (p, n) => (ILifecycleParticipant<ISiloLifecycle>)p.GetRequiredServiceByName<IGrainStorage>(n));
```

This enables adding the file storage using the extension on `ISiloBuilder`:

:::code source="snippets/custom-grain-storage/Program.cs":::

Now you can decorate your grains with the provider `[StorageProvider(ProviderName = "File")]`, and it stores the grain state in the root directory set in the options. Consider the full implementation of `FileGrainStorage`:

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

Before starting the implementation, create an options class containing the root directory where grain state files are stored. Create an options file named `FileGrainStorageOptions`:

```csharp
public class FileGrainStorageOptions
{
    public string RootDirectory { get; set; }
}
```

Create a constructor containing two fields: `storageName` to specify which grains should use this storage (`[StorageProvider(ProviderName = "File")]`) and `directory`, the directory where grain states are saved.

`IGrainFactory` and `ITypeResolver` are used in the next section to initialize the storage.

Also, take two options as arguments: your own `FileGrainStorageOptions` and the `ClusterOptions`. These are needed for implementing the storage functionalities.

You also need `JsonSerializerSettings` as you are serializing and deserializing in JSON format.

> [!IMPORTANT]
> JSON is an implementation detail. It's up to you to decide which serialization/deserialization protocol fits your application. Another common format is binary.

## Initialize the storage

To initialize the storage, register an `Init` function on the `ApplicationServices` lifecycle.

```csharp
public void Participate(ISiloLifecycle lifecycle)
{
    lifecycle.Subscribe(
        OptionFormattingUtilities.Name<FileGrainStorage>(_storageName),
        ServiceLifecycleStage.ApplicationServices,
        Init);
}
```

The `Init` function sets the `_jsonSettings` used to configure the JSON serializer. At the same time, create the folder to store grain states if it doesn't exist yet.

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

Also, provide a common function to construct the filename, ensuring uniqueness per service, grain ID, and grain type.

```csharp
private string GetKeyString(string grainType, GrainReference grainReference)
{
    return $"{_clusterOptions.ServiceId}.{grainReference.ToKeyString()}.{grainType}";
}
```

## Read state

To read a grain state, get the filename using the previously defined function and combine it with the root directory from the options.

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

Use `fileInfo.LastWriteTimeUtc` as an ETag, which other functions use for inconsistency checks to prevent data loss.

Note that for deserialization, use the `_jsonSettings` set in the `Init` function. This is important for correctly serializing/deserializing the state.

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

Similar to reading state, use `_jsonSettings` to write the state. The current ETag checks against the file's last updated UTC time. If the date differs, it means another activation of the same grain changed the state concurrently. In this situation, throw an `InconsistentStateException`, which results in the current activation being killed to prevent overwriting the state previously saved by the other activated grain.

## Clear state

Clearing the state involves deleting the file if it exists.

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

For the same reason as `WriteStateAsync`, check for inconsistency. Before deleting the file and resetting the ETag, check if the current ETag matches the last write time UTC.

## Put it all together

Next, create a factory that allows scoping the options to the provider name while creating an instance of `FileGrainStorage` to ease registration with the service collection.

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

Lastly, to register the grain storage, create an extension on `ISiloHostBuilder`. This extension internally registers the grain storage as a named service using `.AddSingletonNamedService(...)`, an extension provided by `Orleans.Core`.

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

The `FileGrainStorage` implements two interfaces, `IGrainStorage` and `ILifecycleParticipant<ISiloLifecycle>`. Therefore, register two named services, one for each interface:

```csharp
return services.AddSingletonNamedService(providerName, FileGrainStorageFactory.Create)
    .AddSingletonNamedService(
        providerName,
        (s, n) => (ILifecycleParticipant<ISiloLifecycle>)s.GetRequiredServiceByName<IGrainStorage>(n));
```

This enables adding the file storage using the extension on `ISiloHostBuilder`:

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

Now you can decorate your grains with the provider `[StorageProvider(ProviderName = "File")]`, and it stores the grain state in the root directory set in the options.

:::zone-end
