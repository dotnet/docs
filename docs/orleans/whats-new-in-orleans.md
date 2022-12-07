---
title: What's new in Orleans
description: Learn about the various new features introduced in Orleans 7.0.
ms.date: 12/07/2022
---

# What's new in Orleans 7.0

Orleans 7.0 introduces several beneficial changes, including improvements to hosting, custom serialization, immutability, and grain abstractions.

## Migration

Existing applications using reminders, streams, or grain persistence cannot be easily migrated to Orleans 7.0 due to changes in how Orleans identifies grains and streams. We plan to incrementally offer a migration path for these applications.

Applications running previous versions of Orleans cannot be smoothly upgraded via a rolling upgrade to Orleans 7.0. Therefore, a different upgrade strategy must be used, such as deploying a new cluster and decommissioning the previous cluster. Orleans 7.0 changes the wire protocol in an incompatible fashion, meaning that clusters cannot contain a mix of Orleans 7.0 hosts and hosts running previous versions of Orleans.

We have avoided such breaking changes for many years, even across major releases, so why now? There are two major reasons: identities and serialization. Regarding identities, Grain and stream identities are now comprised of strings, allowing grains to encode generic type information properly and allowing streams to map more easily to the application domain. Grain types were previously identified using a complex data structure which could not represent generic grains, leading to corner cases. Streams were identified by a `string` namespace and a <xref:System.Guid> key, which was difficult for developers to map to their application domain, however efficient. Serialization is now version-tolerant, meaning that you can modify your types in certain compatible ways, following a set of rules, and be confident that you can upgrade your application without serialization errors. This was especially problematic when application types were persisted in streams or grain storage. The following sections detail the major changes and discuss them in more detail.

### Packaging changes

If you're upgrading a project to Orleans 7.0, you'll need to perform the following actions:

- All clients should reference [Microsoft.Orleans.Client](https://nuget.org/packages/Microsoft.Orleans.Client).
- All silos (servers) should reference [Microsoft.Orleans.Server](https://nuget.org/packages/Microsoft.Orleans.Server).
- All other packages should reference [Microsoft.Orleans.Sdk](https://nuget.org/packages/Microsoft.Orleans.Sdk).
  - Both _client_ and _server_ packages include a reference to [Microsoft.Orleans.Sdk](https://nuget.org/packages/Microsoft.Orleans.Sdk).
- Remove all references to `Microsoft.Orleans.CodeGenerator.MSBuild` and `Microsoft.Orleans.OrleansCodeGenerator.Build`.
  - Replace usages of `KnownAssembly` with <xref:Orleans.GenerateCodeForDeclaringAssemblyAttribute>.
  - The `Microsoft.Orleans.Sdk` package references the C# Source Generator package (`Microsoft.Orleans.CodeGenerator`).
- Remove all references to `Microsoft.Orleans.OrleansRuntime`.
  - The [Microsoft.Orleans.Server](https://nuget.org/packages/Microsoft.Orleans.Server) packages references its replacement, `Microsoft.Orleans.Runtime`.
- Remove calls to `ConfigureApplicationParts`.
  - Application parts has been removed. The C# Source Generator for Orleans is added to all packages (including the client and server) and will generate the equivalent of application parts automatically.
- Replace references to `Microsoft.Orleans.OrleansServiceBus` with [Microsoft.Orleans.Streaming.EventHubs](https://nuget.org/packages/Microsoft.Orleans.Streaming.EventHubs)
- If you are using reminders, add a reference to [Microsoft.Orleans.Reminders](https://nuget.org/packages/Microsoft.Orleans.Reminders)
- If you are using streams, add a reference to [Microsoft.Orleans.Streaming](https://nuget.org/packages/Microsoft.Orleans.Streaming)

> [!TIP]
> All of the Orleans samples have been upgraded to Orleans 7.0 and can be used as a reference for what changes were made. For more information, see [Orleans issue #8035](https://github.com/dotnet/orleans/issues/8035) that itemizes the changes made to each sample.

## Orleans `global using` directives

All Orleans projects either directly or indirectly reference the `Microsoft.Orleans.Sdk` NuGet package. When an Orleans project has configured to _enable_ implicit usings (for example `<ImplicitUsings>enable</ImplicitUsings>`), the `Orleans` and `Orleans.Hosting` namespaces are both implicitly used. This means that your app code doesn't need these directives.

<!-- markdownlint-disable MD044 -->
For more information, see [ImplicitUsings](../core/project-sdk/msbuild-props.md#implicitusings) and [dotnet/orleans/src/Orleans.Sdk/build/Microsoft.Orleans.Sdk.targets](https://github.com/dotnet/orleans/blob/main/src/Orleans.Sdk/build/Microsoft.Orleans.Sdk.targets#L4-L5).
<!-- markdownlint-enable MD044 -->

## Hosting

The <xref:Orleans.ClientBuilder> type has been replaced with a <xref:Microsoft.Extensions.Hosting.OrleansClientGenericHostExtensions.UseOrleansClient%2A> extension method on <xref:Microsoft.Extensions.Hosting.IHostBuilder>. The `IHostBuilder` type comes from the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package. This means that you can add an Orleans client to an existing host without having to create a separate dependency injection container. The client connects to the cluster during startup. Once <xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A?displayProperty=nameWithType> has completed, the client will be connected automatically. Services added to the `IHostBuilder` are started in the order of registration, so calling `UseOrleansClient` before calling <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> will ensure Orleans is started before ASP.NET Core starts for example, allowing you to access the client from your ASP.NET Core application immediately.

If you wish to emulate the previous `ClientBuilder` behavior, you can create a separate `HostBuilder` and configure it with an Orleans client. `IHostBuilder` can have either an Orleans client or an Orleans silo configured. All silos register an instance of <xref:Orleans.IGrainFactory> and <xref:Orleans.IClusterClient> which the application can use, so configuring a client separately is unnecessary and unsupported.

## `OnActivateAsync` and `OnDeactivateAsync` signature change

Orleans allows grains to execute code during activation and deactivation. This can be used to perform tasks such as read state from storage or log lifecycle messages. In Orleans 7.0, the signature of these lifecycle methods changed:

- <xref:Orleans.Grain.OnActivateAsync> now accepts a <xref:System.Threading.CancellationToken> parameter. When the <xref:System.Threading.CancellationToken> is canceled, the activation process should be abandoned.
- <xref:Orleans.Grain.OnDeactivateAsync> now accepts a <xref:Orleans.DeactivationReason> parameter and a `CancellationToken` parameter. The `DeactivationReason` indicates why the activation is being deactivated. Developers are expected to use this information for logging and diagnostics purposes. When the `CancellationToken` is canceled, the deactivation process should be completed promptly. Note that since any host can fail at any time, it is not recommended to rely on `OnDeactivateAsync` to perform important actions such as persisting critical state.

Consider the following example of a grain overriding these new methods:

```csharp
public sealed class PingGrain : Grain, IPingGrain
{
    private readonly ILogger<PingGrain> _logger;

    public PingGrain(ILogger<PingGrain> logger) =>
        _logger = logger;

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("OnActivateAsync()");
        return Task.CompletedTask;
    }

    public override Task OnDeactivateAsync(DeactivationReason reason, CancellationToken token)
    {
        _logger.LogInformation("OnDeactivateAsync({Reason})", reason);
        return Task.CompletedTask;
    }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

## POCO Grains and `IGrainBase`

Grains in Orleans no longer need to inherit from the <xref:Orleans.Grain> base class or any other class. This functionality is referred to as [POCO](../standard/glossary.md#poco) grains. To access extension methods such as any of the following:

- <xref:Orleans.GrainBaseExtensions.DeactivateOnIdle%2A>
- <xref:Orleans.GrainExtensions.AsReference%2A>
- <xref:Orleans.GrainExtensions.Cast%2A>
- <xref:Orleans.GrainExtensions.GetPrimaryKey%2A>
- <xref:Orleans.GrainReminderExtensions.GetReminder%2A>
- <xref:Orleans.GrainReminderExtensions.GetReminders%2A>
- <xref:Orleans.GrainReminderExtensions.RegisterOrUpdateReminder%2A>
- <xref:Orleans.GrainReminderExtensions.UnregisterReminder%2A>
- <xref:Orleans.GrainStreamingExtensions.GetStreamProvider%2A>

Your grain must either implement <xref:Orleans.IGrainBase> or inherit from <xref:Orleans.Grain>. Here is an example of implementing `IGrainBase` on a grain class:

```csharp
public sealed class PingGrain : IGrainBase, IPingGrain
{
    public PingGrain(IGrainContext context) => GrainContext = context;

    public IGrainContext GrainContext { get; }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

`IGrainBase` also defines `OnActivateAsync` and `OnDeactivateAsync` with default implementations, allowing your grain to participate in its lifecycle if desired:

```csharp
public sealed class PingGrain : IGrainBase, IPingGrain
{
    private readonly ILogger<PingGrain> _logger;

    public PingGrain(IGrainContext context, ILogger<PingGrain> logger)
    {
        _logger = logger;
        GrainContext = context;
    }

    public IGrainContext GrainContext { get; }

    public Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("OnActivateAsync()");
        return Task.CompletedTask;
    }

    public Task OnDeactivateAsync(DeactivationReason reason, CancellationToken token)
    {
        _logger.LogInformation("OnDeactivateAsync({Reason})", reason);
        return Task.CompletedTask;
    }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

## Serialization

The most burdensome change in Orleans 7.0 is the introduction of the version-tolerant serializer. This change was made because applications tend to evolve over time and this led to a significant pitfall for developers, since the previous serializer couldn't tolerate adding properties to existing types. On the other hand, the serializer was flexible, allowing developers to represent most .NET types without modification, including features such as generics, polymorphism, and reference tracking. A replacement was long overdue, but users still need high-fidelity representation of their types. Therefore, a replacement serializer was introduced in Orleans 7.0 which supports high-fidelity representation of .NET types while also allowing types to evolve over time. The new serializer is much more efficient than the previous serializer, resulting in up to 170% higher end-to-end throughput.

The new serializer requires that you are explicit about which types and members are serialized. We have tried to make this as pain-free as possible. You must mark all serializable types with <xref:Orleans.CodeGeneration.GenerateSerializerAttribute?displayProperty=nameWithType> to instruct Orleans to generate serializer code for your type. Once you have done this, you can use the included code-fix to add the required <xref:Orleans.IdAttribute?displayProperty=nameWithType> to the serializable members on your types, as demonstrated here:

![orleans_analyzer](https://user-images.githubusercontent.com/203839/154169861-7c5547d0-e489-4af9-8aba-1e2f71c50211.gif)

By default, Orleans will serialize your type by encoding its full name. You can override this by adding an <xref:Orleans.AliasAttribute?displayProperty=nameWithType>. Doing so will result in your type being serialized using a name which is resistant to renaming the underlying class or moving it between assemblies. Type aliases are globally scoped and you cannot have two aliases with the same value in an application. For generic types, the alias value must include the number of generic parameters preceded by a backtick, for example, `MyGenericType<T, U>` could have the alias <code>[Alias("mytype\`2")]</code>.

### Serializing `record` types

Members defined in a record's primary constructor have implicit ids by default. In other words, Orleans supports serializing `record` types. This means that you cannot change the parameter order for an already deployed type, since that will break compatibility with previous versions of your application (in the case of a rolling upgrade) and with serialized instances of that type in storage and streams. Members defined in the body of a record type don't share identities with the primary constructor parameters.

### Serialization best practices

- ✅ **Do** give your types aliases using the `[Alias("my-type")]` attribute. Types with aliases can be renamed without breaking compatibility.
- ❌ **Do not** change a `record` to a regular `class` or vice-versa. Records and classes are not represented in an identical fashion since records have primary constructor members in addition to regular members and therefore the two are not interchangeable.
- ❌ **Do not** add new types to an existing type hierarchy for a serializable type. You must not add a new base class to an existing type. You can safely add a new subclass to an existing type.
- ✅ **Do** replace usages of <xref:System.SerializableAttribute> with <xref:Orleans.GenerateSerializerAttribute> and corresponding <xref:Orleans.IdAttribute> declarations.
- ✅ **Do** start all member ids at zero for each type. Ids in a subclass and its base class can safely overlap. Both properties in the following example have ids equal to `0`.

    ```csharp
    [GenerateSerializer]
    public sealed class MyBaseClass
    {
        [Id(0)]
        public int MyBaseInt { get; set; }
    }
    
    [GenerateSerializer]
    public sealed class MySubClass : MyBaseClass
    {
        [Id(0)]
        public int MyBaseInt { get; set; }
    }
    ```

- ✅ **Do** widen numeric member types as needed. You can widen `sbyte` to `short` to `int` to `long`.
  - You can narrow numeric member types but it will result in a runtime exception if observed values cannot be represented correctly by the narrowed type. For example, `int.MaxValue` cannot be represented by a `short` field, so narrowing an `int` field to `short` can result in a runtime exception if such a value were encountered.
- ❌ **Do not** change the signedness of a numeric type member. You must not change a member's type from `uint` to `int` or an `int` to a `uint`, for example.

#### Surrogates for serializing foreign types

Sometimes you may need to pass types between grains which you don't have full control over. In these cases, it may be impractical to convert to and from some custom-defined type in your application code manually. Orleans offers a solution for these situations in the form of surrogate types. Surrogates are serialized in place of their target type and have functionality to convert to and from the target type. Consider the following example of a foreign type and a corresponding surrogate and converter:

``` csharp
// This is the foreign type, which you do not have control over.
public struct MyForeignLibraryValueType
{
    public MyForeignLibraryValueType(int num, string str, DateTimeOffset dto)
    {
        Num = num;
        String = str;
        DateTimeOffset = dto;
    }

    public int Num { get; }
    public string String { get; }
    public DateTimeOffset DateTimeOffset { get; }
}

// This is the surrogate which will act as a stand-in for the foreign type.
// Surrogates should use plain fields instead of properties for better performance.
[GenerateSerializer]
public struct MyForeignLibraryValueTypeSurrogate
{
    [Id(0)]
    public int Num;

    [Id(1)]
    public string String;

    [Id(2)]
    public DateTimeOffset DateTimeOffset;
}

// This is a converter which converts between the surrogate and the foreign type.
[RegisterConverter]
public sealed class MyForeignLibraryValueTypeSurrogateConverter :
  IConverter<MyForeignLibraryValueType, MyForeignLibraryValueTypeSurrogate>
{
    public MyForeignLibraryValueType ConvertFromSurrogate(
        in MyForeignLibraryValueTypeSurrogate surrogate) =>
        new(surrogate.Num, surrogate.String, surrogate.DateTimeOffset);

    public MyForeignLibraryValueTypeSurrogate ConvertToSurrogate(
        in MyForeignLibraryValueType value) =>
        new() { Num = value.Num, String = value.String, DateTimeOffset = value.DateTimeOffset };
}
```

In the preceding code:

- The `MyForeignLibraryValueType` is a type outside of your control, defined in a consuming library.
- The `MyForeignLibraryValueTypeSurrogate` is a surrogate type that maps to `MyForeignLibraryValueType`.
- The <xref:Orleans.RegisterConverterAttribute> specifies that the `MyForeignLibraryValueTypeSurrogateConverter` acts as a converter to map to and from the two types. The class is an implementation of <xref:Orleans.IConverter%602> interface.

Orleans supports serialization of types in type hierarchies (types which derive from other types). In the event that a foreign type might appear in a type hierarchy (for example as the base class for one of your own types), you must additionally implement the <xref:Orleans.IPopulator%602?displayProperty=nameWithType> interface. Consider the following example:

``` csharp
// The foreign type is not sealed, allowing other types to inherit from it.
public sealed class MyForeignLibraryType
{
    public MyForeignLibraryType() { }

    public MyForeignLibraryType(int num, string str, DateTimeOffset dto)
    {
        Num = num;
        String = str;
        DateTimeOffset = dto;
    }

    public int Num { get; set; }
    public string String { get; set; }
    public DateTimeOffset DateTimeOffset { get; set; }
}

// The surrogate is defined as it was in the previous example.
[GenerateSerializer]
public struct MyForeignLibraryTypeSurrogate
{
    [Id(0)]
    public int Num;

    [Id(1)]
    public string String;

    [Id(2)]
    public DateTimeOffset DateTimeOffset;
}

// Implement the IConverter and IPopulator interfaces on the converter.
[RegisterConverter]
public sealed class MyForeignLibraryTypeSurrogateConverter :
    IConverter<MyForeignLibraryType, MyForeignLibraryTypeSurrogate>,
    IPopulator<MyForeignLibraryType, MyForeignLibraryTypeSurrogate>
{
    public MyForeignLibraryType ConvertFromSurrogate(
        in MyForeignLibraryTypeSurrogate surrogate) =>
        new(surrogate.Num, surrogate.String, surrogate.DateTimeOffset);

    public MyForeignLibraryTypeSurrogate ConvertToSurrogate(
        in MyForeignLibraryType value) =>
        new()
    {
        Num = value.Num,
        String = value.String,
        DateTimeOffset = value.DateTimeOffset
    };

    public void Populate(
        in MyForeignLibraryTypeSurrogate surrogate, MyForeignLibraryType value)
    {
        value.Num = surrogate.Num;
        value.String = surrogate.String;
        value.DateTimeOffset = surrogate.DateTimeOffset;
    }
}

// Application types can inherit from the foreign type, assuming they're not sealed
// since Orleans knows how to serialize it.
[GenerateSerializer]
public sealed class DerivedFromMyForeignLibraryType : MyForeignLibraryType
{
    public DerivedFromMyForeignLibraryType() { }

    public DerivedFromMyForeignLibraryType(
        int intValue, int num, string str, DateTimeOffset dto) : base(num, str, dto)
    {
        IntValue = intValue;
    }

    [Id(0)]
    public int IntValue { get; set; }
}
```

#### Custom serialization

For sending data between hosts, <xref:Orleans.Serialization?displayProperty=fullName> supports delegating to other serializers, such as [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) and [System.Text.Json](https://www.nuget.org/packages/System.Text.Json). You can add support for other serializers by following the pattern set by those implementations. For grain storage it is preferential to use <xref:Orleans.Storage.IGrainStorageSerializer> to configure a custom serializer.

##### Configure Orleans to use `System.Text.Json`

Configuring Orleans to use `System.Text.Json` to serialize a subset of types is similar to configuring Orleans to serialize types using `Newtonsoft.Json`, except that the package and configuration methods are different:

- Install the [Microsoft.Orleans.Serialization.SystemTextJson](https://nuget.org/packages/Microsoft.Orleans.Serialization.SystemTextJson) NuGet package.
- Configure the serializer using the <xref:Orleans.Serialization.SerializationHostingExtensions.AddJsonSerializer%2A> method.

Consider the following example when interacting with the <xref:Orleans.Hosting.ISiloBuilder>:

```csharp
siloBuilder.Services.AddSerializer(serializerBuilder =>
{
    serializerBuilder.AddJsonSerializer(
        isSupported: type => type.Namespace.StartsWith("Example.Namespace"));
});
```

##### Configure Orleans to use `Newtonsoft.Json`

To configure Orleans to serialize certain types using `Newtonsoft.Json`, you must first reference the [Microsoft.Orleans.Serialization.NewtonsoftJson](https://nuget.org/packages/Microsoft.Orleans.Serialization.NewtonsoftJson) NuGet package. Then, configure the serializer, specifying which types it will be responsible for. In the following example, we will specify that the `Newtonsoft.Json` serializer will be responsible for all types in the `Example.Namespace` namespace.

``` csharp
siloBuilder.Services.AddSerializer(serializerBuilder =>
{
    serializerBuilder.AddNewtonsoftJsonSerializer(
        isSupported: type => type.Namespace.StartsWith("Example.Namespace"));
});
```

In the preceding example, the call to <xref:Orleans.Serialization.SerializationHostingExtensions.AddNewtonsoftJsonSerializer%2A> adds support for serializing and deserializing values using `Newtonsoft.Json.JsonSerializer`. Similar configuration must be performed on all client which need to handle those types.

For types which Orleans has generated a serializer (types marked with <xref:Orleans.GenerateSerializerAttribute>), Orleans will prefer the generated serializer over the `Newtonsoft.Json` serializer.

#### Immutability enhancements

Orleans opts for safety by default. To ensure that values sent between grains are not modified after the call site or during transmission, these values are copied immediately when making a grain call or returning a response from a grain.
In cases where a developer knows that a type will not be modified, Orleans can be instructed to skip this copy process.
In previous version of Orleans, there were two ways to do this:

1. Wrapping your value in <xref:Orleans.Concurrency.Immutable%601>, using `new Immutable<T>(myValue)`. This requires that your grain interface method parameters and return types are `Immutable<T>`, where `T` is the underlying type, so it can be quite invasive and it is extra ceremony.
1. Marking your type with the <xref:Orleans.ImmutableAttribute>. This informs Orleans' code generator to emit code which avoids copying any object of that type.

Sometimes, you may not have control over the object, for example, it may be a `List<int>` that you are sending between grains. Other times, perhaps parts of your objects are immutable and other parts are not. For these cases, Orleans 7.0 introduces additional options.

1. Method signatures can include <xref:Orleans.ImmutableAttribute> on a per-parameter basis:

    ```csharp
    public interface ISummerGrain : IGrain
    {
      // `values` will not be copied.
      ValueTask<int> Sum([Immutable] List<int> values);
    }
    ```

1. Individual properties and fields can be marked as <xref:Orleans.ImmutableAttribute> to prevent copies being made when instances of the containing type are copied.

```csharp
[GenerateSerializer]
public sealed class MyType
{
    [Id(0), Immutable]
    public List<int> ReferenceData { get; set; }
    
    [Id(1)]
    public List<int> RunningTotals { get; set; }
}
```

### Grain storage serializers

Orleans includes a provider-backed persistence model for grains, accessed via the <xref:Orleans.Grain%601.State?displayName=nameWithType> property or by injecting one or more <xref:Orleans.Runtime.IPersistentState%601> values into your grain. Before Orleans 7.0, each provider had a different mechanism for configuring serialization. In Orleans 7.0, there is now a general-purpose grain state serializer interface, <xref:Orleans.Storage.IGrainStorageSerializer>, which offers a consistent way to customize state serialization for each provider. Supported storage providers implement a pattern which involves setting the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer%2A?displayProperty=nameWithType> property on the provider's options class, for example:

- <xref:Orleans.Configuration.DynamoDBStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AzureBlobStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AzureTableStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AdoNetGrainStorageOptions.GrainStorageSerializer>

This currently defaults to an implementation which uses `Newtonsoft.Json` to serialize state. You can replace this by modifying that property at configuration time. The following example demonstrates this, using [OptionsBuilder\<TOptions\>](../core/extensions/options.md#optionsbuilder-api):

```csharp
siloBuilder.AddAzureBlobGrainStorage(
    "MyGrainStorage",
    (OptionsBuilder<AzureBlobStorageOptions> optionsBuilder) =>
    {
        optionsBuilder.Configure<IMySerializer>(
            (options, serializer) => options.GrainStorageSerializer = serializer);
    });
```

For more information, see [OptionsBuilder API](../core/extensions/options.md#optionsbuilder-api).

## Grain identities

Grains each have a unique identity which is comprised of the grain's type and its key. Previous versions of Orleans used a compound type for `GrainId`s to support grain keys of either:

- <xref:System.Guid>
- [`long`](xref:System.Int64)
- [string](xref:System.String)
- <xref:System.Guid>+ [string](xref:System.String)
- [`long`](xref:System.Int64) + [string](xref:System.String)

This involves some complexity when it comes to dealing with grain keys. Grain identities consist of two components: a type and a key. The type component previously consisted of a numeric type code, a category, and 3 bytes of generic type information.

Grain identities now take the form `type/key` where both `type` and `key` are strings. The most commonly used grain key interface is the <xref:Orleans.IGrainWithStringKey>. This greatly simplifies how grain identity works and improves support for generic grain types.

Grain interfaces are also now represented using a human-readable name, rather than a combination of a hash code and a string representation of any generic type parameters.

The new system is more customizable and these customizations can be driven by attributes.

- <xref:Orleans.GrainTypeAttribute.%23ctor(System.String)> on a grain `class` specifies the *Type* portion of its grain id.
- <xref:Orleans.Metadata.DefaultGrainTypeAttribute.%23ctor(System.String)> on a grain `interface` specifies the *Type* of the grain which <xref:Orleans.IGrainFactory> should resolve by default when getting a grain reference. For example, when calling `IGrainFactory.GetGrain<IMyGrain>("my-key")`, the grain factory will return a reference to the grain `"my-type/my-key"` if `IMyGrain` has the aforementioned attribute specified.
- <xref:Orleans.Runtime.GrainInterfaceTypeAttribute.%23ctor(System.String)> allows overriding the interface name. Specifying a name explicitly using this mechanism allows renaming of the interface type without breaking compatibility with existing grain references. Note that your interface should also have the <xref:Orleans.AliasAttribute> in this case, since its identity may be serialized. For more information on specifying a type alias, see the section on serialization.

As mentioned above, overriding the default grain class and interface names for your types allows you to rename the underlying types without breaking compatibility with existing deployments.

## Stream identities

When Orleans streams was first released, streams could only be identified using a <xref:System.Guid>. This was efficient in terms of memory allocation, but it was difficult for users to create meaningful stream identities, often requiring some encoding or indirection to determine the appropriate stream identity for a given purpose.

In Orleans 7.0, streams are now identified using strings. The <xref:Orleans.Runtime.StreamId?displayProperty=fullName> `struct` contains three properties: a <xref:Orleans.Runtime.StreamId.Namespace?displayProperty=nameWithType>, a <xref:Orleans.Runtime.StreamId.Key?displayProperty=nameWithType>, and a <xref:Orleans.Runtime.StreamId.FullKey?displayProperty=nameWithType>. These property values are encoded UTF-8 strings. For example, <xref:Orleans.Runtime.StreamId.Create(System.String,System.String)?displayProperty=nameWithType>.

### Replacement of SimpleMessageStreams with BroadcastChannel

`SimpleMessageStreams` (also called SMS) was removed in 7.0. SMS had the same interface as <xref:Orleans.Providers.Streams.PersistentStreams?displayProperty=fullName>, but its behavior was very different, since it relied on direct grain-to-grain calls. To avoid confusion, SMS was removed, and a new replacement called <xref:Orleans.BroadcastChannel?displayProperty=fullName> was introduced.

`BroadcastChannel` only supports implicit subscription and can be a direct replacement in this case. If you need explicit subscriptions or need to use the `PersistentStream` interface (for example you were using SMS in tests while using `EventHub` in production), then `MemoryStream` is the best candidate for you.

`BroadcastChannel` will have the same behaviors as SMS, while `MemoryStream` will behave like other stream providers. Consider the following Broadcast Channel usage example:

```csharp
// Configuration
builder.AddBroadcastChannel(
    "my-provider",
    options => options.FireAndForgetDelivery = false);

// Publishing
var grainKey = Guid.NewGuid().ToString("N");
var channelId = ChannelId.Create("some-namespace", grainKey);
var stream = provider.GetChannelWriter<int>(channelId);

await stream.Publish(1);
await stream.Publish(2);
await stream.Publish(3);

// Simple implicit subscriber example
[ImplicitChannelSubscription]
public sealed class SimpleSubscriberGrain : Grain, ISubscriberGrain, IOnBroadcastChannelSubscribed
{
    // Called when a subscription is added to the grain
    public Task OnSubscribed(IBroadcastChannelSubscription streamSubscription)
    {
        streamSubscription.Attach<int>(
          item => OnPublished(streamSubscription.ChannelId, item),
          ex => OnError(streamSubscription.ChannelId, ex));

        return Task.CompletedTask;

        // Called when an item is published to the channel
        static Task OnPublished(ChannelId id, int item)
        {
            // Do something
            return Task.CompletedTask;
        }

        // Called when an error occurs
        static Task OnError(ChannelId id, Exception ex)
        {
            // Do something
            return Task.CompletedTask;
        }
    }
}
```

Migration to `MemoryStream` will be easier, since only the configuration needs to change. Consider the following `MemoryStream` configuration:

```csharp
builder.AddMemoryStreams<DefaultMemoryMessageBodySerializer>(
    "in-mem-provider",
    _ =>
    {
        // Number of pulling agent to start.
        // DO NOT CHANGE this value once deployed, if you do rolling deployment
        _.ConfigurePartitioning(partitionCount: 8);
    });
```

## OpenTelemetry

The telemetry system has been updated in Orleans 7.0 and the previous system has been removed in favor of standardized .NET APIs such as .NET Metrics for metrics and <xref:System.Diagnostics.ActivitySource> for tracing.

As a part of this, the existing `Microsoft.Orleans.TelemetryConsumers.*` packages have been removed. We are considering introducing a new set of packages to streamline the process of integrating the metrics emitted by Orleans into your monitoring solution of choice. As always, feedback and contributions are welcome.

The `dotnet-counters` tool features performance monitoring for ad-hoc health monitoring and first-level performance investigation. For Orleans counters, the [dotnet-counters](../core/diagnostics/dotnet-counters.md) tool can be used to monitor them:

```dotnetcli
dotnet counters monitor -n MyApp --counters Microsoft.Orleans
```

Similarly, OpenTelemetry metrics can add the `Microsoft.Orleans` meters, as shown in the following code:

```csharp
builder.Services.AddOpenTelemetryMetrics(metrics =>
{
    metrics
        .AddPrometheusExporter()
        .AddMeter("Microsoft.Orleans");
});
```

To enable distributed tracing, you configure OpenTelemetry as shown in the following code:

```csharp
builder.Services.AddOpenTelemetryTracing(tracing =>
{
    // Set a service name
    tracing.SetResourceBuilder(
        ResourceBuilder.CreateDefault()
            .AddService(serviceName: "ExampleService", serviceVersion: "1.0"));

    tracing.AddAspNetCoreInstrumentation();
    tracing.AddSource("Microsoft.Orleans.Runtime");
    tracing.AddSource("Microsoft.Orleans.Application");

    tracing.AddZipkinExporter(zipkin =>
    {
        zipkin.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
    });
});
```

In the preceding code, OpenTelemetry is configured to monitor:

- `Microsoft.Orleans.Runtime`
- `Microsoft.Orleans.Application`

To propagate activity, call <xref:Orleans.Hosting.ClientBuilderExtensions.AddActivityPropagation%2A>:

```csharp
builder.Host.UseOrleans((_, clientBuilder) =>
{
    clientBuilder.AddActivityPropagation();
});
```

## Refactor features from core package into separate packages

In Orleans 7.0, we have made an effort to factor extensions into separate packages which don't rely on <xref:Orleans.Core?displayName=fullName>. Namely, <xref:Orleans.Streaming?displayName=fullName>, <xref:Orleans.Reminders?displayName=fullName>, and <xref:Orleans.Transactions?displayName=fullName> have been separated from the core. This means that these packages are entirely *pay for what you use* and there is no code in the core of Orleans which is dedicated to these features. This slims down the core API surface and assembly size, simplifies the core, and improves performance. Regarding performance, Transactions in Orleans previously required some code which was executed for every method to coordinate potential transactions. That has since been moved to per-method.

This is a compilation breaking change. You may have existing code which interacts with reminders or streams by calling into methods which were previously defined on the <xref:Orleans.Grain> base class but are now extension methods. Such calls which do not specify `this` (for example <xref:Orleans.GrainReminderExtensions.GetReminders%2A>) will need to be updated to include `this` (for example `this.GetReminders()`) because extension methods must be qualified. There will be a compilation error if you do not update those calls and the required code change may not be obvious if you do not know what has changed.

## Transaction client

Orleans 7.0 introduces a new abstraction for coordinating transactions, <xref:Orleans.ITransactionClient?displayProperty=fullName>. Previously, transactions could only be coordinated by grains. With `ITransactionClient`, which is available via dependency injection, clients can also coordinate transactions without needing an intermediary grain. The following example withdraws credits from one account and deposits them into another within a single transaction. This code can be called from within a grain or from an external client which has retrieved the `ITransactionClient` from the dependency injection container.

```csharp
await transactionClient.RunTransaction(
  TransactionOption.Create,
  () => Task.WhenAll(from.Withdraw(100), to.Deposit(100)));
```

For transactions coordinated by the client, the client must add the required services during configuration time:

``` csharp
clientBuilder.UseTransactions();
```

The [BankAccount](https://github.com/dotnet/samples/tree/main/orleans/BankAccount) sample demonstrates the usage of `ITransactionClient`. For more information, see [Orleans transactions](grains/transactions.md).

## Call chain reentrancy

Grains are single-threaded and process requests one-by-one from beginning to completion by default. In other words, grains are not reentrant by default. Adding the <xref:Orleans.Concurrency.ReentrantAttribute> to a grain class allows for multiple requests  be processed concurrently, in an interleaving fashion, while still being single-threaded. This can be useful for grains which hold no internal state or perform a lot of asynchronous operations, such as issuing HTTP calls or writing to a database. Extra care needs to be taken when requests can interleave: it's possible that the state of a grain observed before an `await` statement has changed by the time the asynchronous operation completes and the method resumes execution.

For example, the following grain represents a counter. It has been marked `Reentrant`, allowing multiple calls to interleave. The `Increment()` method should increment the internal counter and return the observed value. However, since the `Increment()` method body observes the grain's state before an `await` point and updates it afterwards, it is possible that multiple interleaving executions of `Increment()` can result in a `_value` less than the total number of `Increment()` calls received. This is an error introduced by improper use of reentrancy.

Removing the <xref:Orleans.Concurrency.ReentrantAttribute> is enough to fix the problem.

```csharp
[Reentrant]
public sealed class CounterGrain : Grain, ICounterGrain
{
    int _value;
    
    /// <summary>
    /// Increments the grain's value and returns the previous value.
    /// </summary>
    public Task<int> Increment()
    {
        // Do not copy this code, it contains an error.
        var currentVal = _value;
        await Task.Delay(TimeSpan.FromMilliseconds(1_000));
        _value = currentVal + 1;
        return currentValue;
    }
}
```

To prevent such errors, grains are non-reentrant by default. The downside to this is reduced throughput for grains which perform asynchronous operations in their implementation, since other requests cannot be processed while the grain is waiting for an asynchronous operation to complete. To alleviate this, Orleans offers several options to allow reentrancy in certain cases:

- For an entire class: placing the <xref:Orleans.Concurrency.ReentrantAttribute> on the grain allows any request to the grain to interleave with any other request.
- For a subset of methods: placing the <xref:Orleans.Concurrency.AlwaysInterleaveAttribute> on the grain *interface* method allows requests to that method to interleave with any other request and for requests to that method to be interleaved by any other request.
- For a subset of methods: placing the <xref:Orleans.Concurrency.ReadOnlyAttribute> on the grain *interface* method allows requests to that method to interleave with any other `ReadOnly` request and for requests to that method to be interleaved by any other `ReadOnly` request. In this sense, it is a more restricted form of `AlwaysInterleave`.
- For any request within a call chain: <xref:Orleans.Runtime.RequestContext.AllowCallChainReentrancy?displayProperty=nameWithType> and <xref:Orleans.Runtime.RequestContext.SuppressCallChainReentrancy?displayProperty=nameWithType> allow opting in and out of allowing downstream requests to reenter back into the grain. The calls both return a value which *must* be disposed on exiting the request. Therefore, the proper usage is as follows:

``` csharp
public Task<int> OuterCall(IMyGrain other)
{
    // Allow call-chain reentrancy for this grain, for the duration of the method.
    using var _ = RequestContext.AllowCallChainReentrancy();
    await other.CallMeBack(this.AsReference<IMyGrain>());
}

public Task CallMeBack(IMyGrain grain)
{
    // Because OuterCall allowed reentrancy back into that grain, this method 
    // will be able to call grain.InnerCall() without deadlocking.
    await grain.InnerCall();
}

public Task InnerCall() => Task.CompletedTask;
```

Call-chain reentrancy must be opted-in per-grain, per-call-chain. For example, consider two grains, grain A & grain B. If grain A enables call chain reentrancy before calling grain B, grain B can call back into grain A in that call. However, grain A cannot call back into grain B if grain B has not *also* enabled call chain reentrancy. It is per-grain, per-call-chain.

Grains can also suppress call chain reentrancy information from flowing down a call chain using `using var _ = RequestContext.SuppressCallChainReentrancy()`. This prevents subsequent calls from reentry.

### ADO.NET migration scripts

To ensure forward compatibility with Orleans clustering, persistence, and reminders that rely on ADO.NET, you'll need the appropriate SQL migration script:

* [Clustering](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Clustering.AdoNet/Migrations)
* [Persistence](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Persistence.AdoNet/Migrations)
* [Reminders](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Reminders.AdoNet/Migrations)

Select the files for the database used and apply them in order.
