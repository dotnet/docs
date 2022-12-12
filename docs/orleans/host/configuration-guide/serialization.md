---
title: Serialization and custom serializers
description: Learn about serialization and custom serializers in .NET Orleans.
ms.date: 12/12/2022
uid: serialization
zone_pivot_groups: orleans-version
---

# Serialization and custom serializers

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

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

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Orleans has an advanced and extensible serialization framework. Orleans serializes data types passed in grain request and response messages as well as grain persistent state objects. As part of this framework, Orleans automatically generates serialization code for those data types. In addition to generating a more efficient serialization/deserialization for types that are already .NET-serializable, Orleans also tries to generate serializers for types used in grain interfaces that are not .NET-serializable. The framework also includes a set of efficient built-in serializers for frequently used types: lists, dictionaries, strings, primitives, arrays, etc.

Two important features of Orleans's serializer set it apart from a lot of other third-party serialization frameworks: dynamic types/arbitrary polymorphism and object identity.

1. **Dynamic types and arbitrary polymorphism**: Orleans does not put any restrictions on the types that can be passed in grain calls and maintain the dynamic nature of the actual data type. That means, for example, that if the method in the grain interfaces is declared to accept <xref:System.Collections.IDictionary> but at runtime, the sender passes <xref:System.Collections.Generic.SortedDictionary%602>, the receiver will indeed get `SortedDictionary` (although the "static contract"/grain interface did not specify this behavior).

1. **Maintaining object identity**: If the same object is passed multiple types in the arguments of a grain call or is indirectly pointed more than once from the arguments, Orleans will serialize it only once. On the receiver side, Orleans will restore all references correctly so that two pointers to the same object still point to the same object after deserialization as well. Object identity is important to preserve in scenarios like the following. Imagine actor A is sending a dictionary with 100 entries to actor B, and 10 of the keys in the dictionary point to the same object, obj, on A's side. Without preserving object identity, B would receive a dictionary of 100 entries with those 10 keys pointing to 10 different clones of obj. With object identity-preserved, the dictionary on B's side looks exactly like on A's side with those 10 keys pointing to a single object obj.

The above two behaviors are provided by the standard .NET binary serializer and it was therefore important for us to support this standard and familiar behavior in Orleans as well.

## Generated serializers

Orleans uses the following rules to decide which serializers to generate.
The rules are:

1. Scan all types in all assemblies which reference the core Orleans library.
1. Out of those assemblies: generate serializers for types that are directly referenced in grain interfaces method signatures or state class signature or for any type that is marked with  <xref:System.SerializableAttribute>.
1. In addition, a grain interface or implementation project can point to arbitrary types for serialization generation by adding a `[KnownType]` or <xref:Orleans.CodeGeneration.KnownAssemblyAttribute> assembly-level attributes to tell code generator to generate serializers for specific types or all eligible types within an assembly. For more information on assembly-level attributes, see [Apply attributes at the assembly level](../../../standard/attributes/applying-attributes.md#apply-attributes-at-the-assembly-level).

## Serialization providers

Orleans supports integration with third-party serializers using a provider model. This requires an implementation of the <xref:Orleans.Serialization.IExternalSerializer> type described in the custom serialization section of this document. Integrations for some common serializers are maintained alongside Orleans, for example:

* [Protocol Buffers](https://developers.google.com/protocol-buffers/): <xref:Orleans.Serialization.ProtobufSerializer?displayProperty=fullName> from the [Microsoft.Orleans.OrleansGoogleUtils](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGoogleUtils/) NuGet package.
* [Bond](https://github.com/microsoft/bond/): <xref:Orleans.Serialization.BondSerializer?displayProperty=fullName> from the [Microsoft.Orleans.Serialization.Bond](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Bond/) NuGet package.
* [Newtonsoft.Json AKA Json.NET](https://www.newtonsoft.com/json): <xref:Orleans.Serialization.OrleansJsonSerializer?displayProperty=fullName> from the core Orleans library.

Custom implementation of `IExternalSerializer` is described in the Writing Custom Serializers section below.

### Configuration

It is important to ensure that serialization configuration is identical on all clients and silos. If configurations are not consistent, serialization errors may occur.

Serialization providers, which implement `IExternalSerializer`, can be specified using the <xref:Orleans.Configuration.SerializationProviderOptions.SerializationProviders?displayProperty=nameWithType> property of `ClientConfiguration` and `GlobalConfiguration` in code:

```csharp
// Client configuration
var clientConfiguration = new ClientConfiguration();
clientConfiguration.SerializationProviders.Add(
    typeof(FantasticSerializer).GetTypeInfo());

// Global configuration
var globalConfiguration = new GlobalConfiguration();
globalConfiguration.SerializationProviders.Add(
    typeof(FantasticSerializer).GetTypeInfo());
```

Alternatively, they can be specified in XML configuration under the `<SerializationProviders />` property of `<Messaging>`:

```xml
<Messaging>
    <SerializationProviders>
        <Provider type="GreatCompany.FantasticSerializer, GreatCompany.SerializerAssembly" />
    </SerializationProviders>
</Messaging>
```

In both cases, multiple providers can be configured. The collection is ordered, meaning that if a provider which can serialize types `A` and `B` is specified before a provider which can only serialize type `B`, then the latter provider will not be used.

## Custom serializers

In addition to automatic serialization generation, application code can provide custom serialization for the types it chooses. Orleans recommends using the automatic serialization generation for the majority of your application types and only writing custom serializers in rare cases when you believe it is possible to get improved performance by hand-coding serializers. This note describes how to do so, and identifies some specific cases when it might be helpful.

There are three ways in which applications can customize serialization:

1. Add serialization methods to your type and mark them with appropriate attributes (<xref:Orleans.CodeGeneration.CopierMethodAttribute>, <xref:Orleans.CodeGeneration.SerializerMethodAttribute>, <xref:Orleans.CodeGeneration.DeserializerMethodAttribute>). This method is preferable for types that your application owns, that is, the types that you can add new methods to.
1. Implement `IExternalSerializer` and register it during configuration time. This method is useful for integrating an external serialization library.
1. Write a separate static class annotated with an `[Serializer(typeof(YourType))]` with the 3 serialization methods in it and the same attributes as above. This method is useful for types that the application does not own, for example, types defined in other libraries your application has no control over.

Each of these serialization methods is detailed later.

### Custom serialization introduction

Orleans serialization happens in three stages: objects are immediately deep copied to ensure isolation; before being put on the wire; objects are serialized to a message byte stream; and when delivered to the target activation, objects are recreated (deserialized) from the received byte stream. Data types that may be sent in messages&mdash;that is, types that may be passed as method arguments or return values&mdash;must have associated routines that perform these three steps. We refer to these routines collectively as the serializers for a data type.

The copier for a type stands alone, while the serializer and deserializer are a pair that work together. You can provide just a custom copier, or just a custom serializer and a custom deserializer, or you can provide custom implementations of all three.

Serializers are registered for each supported data type at silo start-up and whenever an assembly is loaded. Registration is necessary for custom serializer routines for a type to be used. Serializer selection is based on the dynamic type of the object to be copied or serialized. For this reason, there is no need to create serializers for abstract classes or interfaces, because they will never be used.

### When to write a custom serializer

A hand-crafted serializer routine will rarely perform meaningfully better than the generated versions. If you are tempted to do so, you should first consider the following options:

- If there are fields or properties within your data types that don't have to be serialized or copied, you can mark them with the <xref:System.NonSerializedAttribute>. This will cause the generated code to skip these fields when copying and serializing. Use <xref:Orleans.Concurrency.ImmutableAttribute> and <xref:Orleans.Concurrency.Immutable%601> where possible to avoid copying immutable data. The section on *Optimizing Copying* below for details. If you're avoiding using the standard generic collection types, don't. The Orleans runtime contains custom serializers for the generic collections that use the semantics of the collections to optimize copying, serializing, and deserializing. These collections also have special "abbreviated" representations in the serialized byte stream, resulting in even more performance advantages. For instance, a `Dictionary<string, string>` will be faster than a `List<Tuple<string, string>>`.

- The most common case where a custom serializer can provide a noticeable performance gain is when there is significant semantic information encoded in the data type that is not available by simply copying field values. For instance, arrays that are sparsely populated may often be more efficiently serialized by treating the array as a collection of index/value pairs, even if the application keeps the data as a fully realized array for speed of operation.

- A key thing to do before writing a custom serializer is to make sure that the generated serializer is hurting your performance. Profiling will help a bit here, but even more valuable is running end-to-end stress tests of your application with varying serialization loads to gauge the system-level impact, rather than the micro-impact of serialization. For instance, building a test version that passes no parameters to or results from grain methods, simply using canned values at either end, will zoom in on the impact of serialization and copying on system performance.

### Add serialization methods to a type

All serializer routines should be implemented as static members of the class or struct they operate on. The names shown here are not required; registration is based on the presence of the respective attributes, not on method names. Note that serializer methods need not be public.

Unless you implement all three serialization routines, you should mark your type with the <xref:System.SerializableAttribute>so that the missing methods will be generated for you.

#### Copier

Copier methods are flagged with the <xref:Orleans.CodeGeneration.CopierMethodAttribute?displayProperty=fullName>:

```csharp
[CopierMethod]
static private object Copy(object input, ICopyContext context)
{
    // ...
}
```

Copiers are usually the simplest serializer routines to write. They take an object, guaranteed to be of the same type as the type the copier is defined in, and must return a semantically-equivalent copy of the object.

If, as part of copying the object, a sub-object needs to be copied, the best way to do so is to use the <xref:Orleans.Serialization.SerializationManager.DeepCopyInner%2A?displayProperty=nameWithType> routine:

```csharp
var fooCopy = SerializationManager.DeepCopyInner(foo, context);
```

> [!IMPORTANT]
> It is important to use <xref:Orleans.Serialization.SerializationManager.DeepCopyInner%2A?displayProperty=nameWithType>, instead of <xref:Orleans.Serialization.SerializationManager.DeepCopy%2A?displayProperty=nameWithType>`DeepCopy`, to maintain the object identity context for the full copy operation.

#### Maintain object identity

An important responsibility of a copy routine is to maintain object identity. The Orleans runtime provides a helper class for this purpose. Before copying a sub-object "by hand" (not by calling `DeepCopyInner`), check to see if it has already been referenced as follows:

```csharp
var fooCopy = context.CheckObjectWhileCopying(foo);
if (fooCopy is null)
{
    // Actually make a copy of foo
    context.RecordObject(foo, fooCopy);
}
```

The last line, the call to <xref:Orleans.Serialization.SerializationContext.RecordObject%2A>, is required so that possible future references to the same object as foo references will get found properly by <xref:Orleans.Serialization.SerializationContext.CheckObjectWhileCopying%2A>.

> [!NOTE]
> This should only be done for class instances, _not_ `struct` instances or .NET primitives such as `string`, `Uri`, and `enum`.

If you use `DeepCopyInner` to copy sub-objects, then object identity is handled for you.

### Serializer

Serialization methods are flagged with the <xref:Orleans.CodeGeneration.SerializerMethodAttribute?displayProperty=fullName>:

```csharp
[SerializerMethod]
static private void Serialize(
    object input,
    ISerializationContext context,
    Type expected)
{
    // ...
}
```

As with copiers, the "input" object passed to a serializer is guaranteed to be an instance of the defining type. The "expected" type may be ignored; it is based on compile-time type information about the data item, and is used at a higher level to form the type prefix in the byte stream.

To serialize sub-objects, use the <xref:Orleans.Serialization.SerializationManager.SerializeInner%2A?displayProperty=nameWithType> routine:

```csharp
SerializationManager.SerializeInner(foo, context, typeof(FooType));
```

If there is no particular expected type for foo, then you can pass null for the expected type.

The <xref:Orleans.Serialization.BinaryTokenStreamWriter> class provides a wide variety of methods for writing data to the byte stream. An instance of the class can be obtained via the `context.StreamWriter` property. See the class for documentation.

### Deserializer

Deserialization methods are flagged with the <xref:Orleans.CodeGeneration.DeserializerMethodAttribute?displayProperty=fullName>:

```csharp
[DeserializerMethod]
static private object Deserialize(
    Type expected,
    IDeserializationContext context)
{
    //...
}
```

The "expected" type may be ignored; it is based on compile-time type information about the data item and is used at a higher level to form the type prefix in the byte stream. The actual type of the object to be created will always be the type of class in which the deserializer is defined.

To deserialize sub-objects, use the <xref:Orleans.Serialization.SerializationManager.DeserializeInner%2A?displayProperty=nameWithType> routine:

```csharp
var foo = SerializationManager.DeserializeInner(typeof(FooType), context);
```

Or, alternatively:

```csharp
var foo = SerializationManager.DeserializeInner<FooType>(context);
```

If there is no particular expected type for foo, use the non-generic `DeserializeInner` variant and pass `null` for the expected type.

The <xref:Orleans.Serialization.BinaryTokenStreamReader> class provides a wide variety of methods for reading data from the byte stream. An instance of the class can be obtained via the `context.StreamReader` property. See the class for documentation.

## Write a serializer provider

In this method, you implement <xref:Orleans.Serialization.IExternalSerializer?displayProperty=fullName> and add it to the <xref:Orleans.Configuration.SerializationProviderOptions.SerializationProviders?displayProperty=nameWithType> property on both <xref:Orleans.Runtime.Configuration.ClientConfiguration> on the client and <xref:Orleans.Runtime.Configuration.GlobalConfiguration> on the silos. Configuration is detailed in the Serialization Providers section above.

Implementation of `IExternalSerializer` follows the pattern described for serialization methods from `Method 1` above with the addition of an `Initialize` method and an `IsSupportedType` method which Orleans uses to determine if the serializer supports a given type. This is the interface definition:

```csharp
public interface IExternalSerializer
{
    /// <summary>
    /// Initializes the external serializer. Called once when the serialization manager creates
    /// an instance of this type
    /// </summary>
    void Initialize(Logger logger);

    /// <summary>
    /// Informs the serialization manager whether this serializer supports the type for serialization.
    /// </summary>
    /// <param name="itemType">The type of the item to be serialized</param>
    /// <returns>A value indicating whether the item can be serialized.</returns>
    bool IsSupportedType(Type itemType);

    /// <summary>
    /// Tries to create a copy of source.
    /// </summary>
    /// <param name="source">The item to create a copy of</param>
    /// <param name="context">The context in which the object is being copied.</param>
    /// <returns>The copy</returns>
    object DeepCopy(object source, ICopyContext context);

    /// <summary>
    /// Tries to serialize an item.
    /// </summary>
    /// <param name="item">The instance of the object being serialized</param>
    /// <param name="context">The context in which the object is being serialized.</param>
    /// <param name="expectedType">The type that the deserializer will expect</param>
    void Serialize(object item, ISerializationContext context, Type expectedType);

    /// <summary>
    /// Tries to deserialize an item.
    /// </summary>
    /// <param name="context">The context in which the object is being deserialized.</param>
    /// <param name="expectedType">The type that should be deserialized</param>
    /// <returns>The deserialized object</returns>
    object Deserialize(Type expectedType, IDeserializationContext context);
}
```

## Write a serializer for an individual type

In this method, you write a new class annotated with an attribute `[SerializerAttribute(typeof(TargetType))]`, where `TargetType` is the type that is being serialized, and implement the 3 serialization routines. The rules for how to write those routines are identical to method 1. Orleans uses the `[SerializerAttribute(typeof(TargetType))]` to determine that this class is a serializer for `TargetType` and this attribute can be specified multiple times on the same class if it's able to serialize multiple types. Below is an example for such a class:

```csharp
public class User
{
    public User BestFriend { get; set; }
    public string NickName { get; set; }
    public int FavoriteNumber { get; set; }
    public DateTimeOffset BirthDate { get; set; }
}

[Orleans.CodeGeneration.SerializerAttribute(typeof(User))]
internal class UserSerializer
{
    [CopierMethod]
    public static object DeepCopier(
        object original, ICopyContext context)
    {
        var input = (User)original;
        var result = new User();

        // Record 'result' as a copy of 'input'. Doing this
        // immediately after construction allows for data
        // structures that have cyclic references or duplicate
        // references. For example, imagine that 'input.BestFriend'
        // is set to 'input'. In that case, failing to record
        // the copy before trying to copy the 'BestFriend' field
        // would result in infinite recursion.
        context.RecordCopy(original, result);

        // Deep-copy each of the fields.
        result.BestFriend =
            (User)context.SerializationManager.DeepCopy(input.BestFriend);

        // strings in .NET are immutable, so they can be shallow-copied.
        result.NickName = input.NickName;
        // ints are primitive value types, so they can be shallow-copied.
        result.FavoriteNumber = input.FavoriteNumber;
        result.BirthDate =
            (DateTimeOffset)context.SerializationManager.DeepCopy(input.BirthDate);

        return result;
    }

    [SerializerMethod]
    public static void Serializer(
        object untypedInput, ISerializationContext context, Type expected)
    {
        var input = (User) untypedInput;

        // Serialize each field.
        SerializationManager.SerializeInner(input.BestFriend, context);
        SerializationManager.SerializeInner(input.NickName, context);
        SerializationManager.SerializeInner(input.FavoriteNumber, context);
        SerializationManager.SerializeInner(input.BirthDate, context);
    }

    [DeserializerMethod]
    public static object Deserializer(
        Type expected, IDeserializationContext context)
    {
        var result = new User();

        // Record 'result' immediately after constructing it.
        // As with the deep copier, this
        // allows for cyclic references and de-duplication.
        context.RecordObject(result);

        // Deserialize each field in the order that they were serialized.
        result.BestFriend =
            SerializationManager.DeserializeInner<User>(context);
        result.NickName =
            SerializationManager.DeserializeInner<string>(context);
        result.FavoriteNumber =
            SerializationManager.DeserializeInner<int>(context);
        result.BirthDate =
            SerializationManager.DeserializeInner<DateTimeOffset>(context);

        return result;
    }
}
```

### Serialize generic types

The `TargetType` parameter of `[Serializer(typeof(TargetType))]` can be an open-generic type, for example, `MyGenericType<>`. In that case, the serializer class must have the same generic parameters as the target type. Orleans will create a concrete version of the serializer at runtime for every concrete `MyGenericType<T>` type which is serialized, for example, one for each of `MyGenericType<int>` and `MyGenericType<string>`.

## Hints for writing serializers and deserializers

Often the simplest way to write a serializer/deserializer pair is to serialize by constructing a byte array and writing the array length to the stream, followed by the array itself, and then deserialize by reversing the process. If the array is fixed-length, you can omit it from the stream. This works well when you have a data type that you can represent compactly and that doesn't have sub-objects that might be duplicated (so you don't have to worry about object identity).

Another approach, which is the approach the Orleans runtime takes for collections such as dictionaries, works well for classes with significant and complex internal structure: use instance methods to access the semantic content of the object, serialize that content, and deserialize by setting the semantic contents rather than the complex internal state. In this approach, inner objects are written using SerializeInner and read using DeserializeInner. In this case, it is common to write a custom copier, as well.

If you write a custom serializer, and it winds up looking like a sequence of calls to SerializeInner for each field in the class, you don't need a custom serializer for that class.

## Fallback serialization

Orleans supports transmission of arbitrary types at runtime and therefore the in-built code generator cannot determine the entire set of types that will be transmitted ahead of time. Additionally, certain types cannot have serializers generated for them because they are inaccessible (for example, `private`) or have inaccessible fields (for example, `readonly`). Therefore, there is a need for just-in-time serialization of types that were unexpected or could not have serializers generated ahead of time. The serializer responsible for these types is called the *fallback serializer*. Orleans ships with two fallback serializers:

* <xref:Orleans.Serialization.BinaryFormatterSerializer?displayProperty=fullName> which uses .NET's <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>; and
* <xref:Orleans.Serialization.ILBasedSerializer?displayProperty=fullName> which emits [CIL](../../../standard/glossary.md#il) instructions at runtime to create serializers that leverage Orleans' serialization framework to serialize each field. This means that if an inaccessible type `MyPrivateType` contains a field `MyType` which has a custom serializer, that custom serializer will be used to serialize it.

The fallback serializer can be configured using the <xref:Orleans.Configuration.SerializationProviderOptions.FallbackSerializationProvider> property on both <xref:Orleans.Runtime.Configuration.ClientConfiguration> on the client and <xref:Orleans.Runtime.Configuration.GlobalConfiguration> on the silos.

```csharp
// Client configuration
var clientConfiguration = new ClientConfiguration();
clientConfiguration.FallbackSerializationProvider =
    typeof(FantasticSerializer).GetTypeInfo();

// Global configuration
var globalConfiguration = new GlobalConfiguration();
globalConfiguration.FallbackSerializationProvider =
    typeof(FantasticSerializer).GetTypeInfo();
```

Alternatively, the fallback serialization provider can be specified in XML configuration:

```xml
<Messaging>
    <FallbackSerializationProvider
        Type="GreatCompany.FantasticFallbackSerializer, GreatCompany.SerializerAssembly"/>
</Messaging>
```

The <xref:Orleans.Serialization.BinaryFormatterSerializer> is the default fallback serializer.

## Exception serialization

Exceptions are serialized using the [fallback serializer](serialization.md#fallback-serialization). Using the default configuration, `BinaryFormatter` is the fallback serializer and so the [ISerializable pattern](../../../standard/serialization/custom-serialization.md) must be followed in order to ensure correct serialization of all properties in an exception type.

Here is an example of an exception type with correctly implemented serialization:

```csharp
[Serializable]
public class MyCustomException : Exception
{
    public string MyProperty { get; }

    public MyCustomException(string myProperty, string message)
        : base(message)
    {
        MyProperty = myProperty;
    }

    public MyCustomException(string transactionId, string message, Exception innerException)
        : base(message, innerException)
    {
        MyProperty = transactionId;
    }

    // Note: This is the constructor called by BinaryFormatter during deserialization
    public MyCustomException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        MyProperty = info.GetString(nameof(MyProperty));
    }

    // Note: This method is called by BinaryFormatter during serialization
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(MyProperty), MyProperty);
    }
}
```

## Optimize copying using immutable types

Orleans has a feature that can be used to avoid some of the overhead associated with serializing messages containing immutable types. This section describes the feature and its application, starting with context on where it is relevant.

### Serialization in Orleans

When a grain method is invoked, the Orleans runtime makes a deep copy of the method arguments and forms the request out of the copies. This protects against the calling code modifying the argument objects before the data is passed to the called grain.

If the called grain is on a different silo, then the copies are eventually serialized into a byte stream and sent over the network to the target silo, where they are deserialized back into objects. If the called grain is on the same silo, then the copies are handed directly to the called method.

Return values are handled the same way: first copied, then possibly serialized and deserialized.

Note that all 3 processes, copying, serializing, and deserializing, respect object identity. In other words, if you pass a list that has the same object in it twice, on the receiving side you'll get a list with the same object in it twice, rather than with two objects with the same values in them.

### Optimize copying

In many cases, deep copying is unnecessary. For instance, a possible scenario is a web front-end that receives a byte array from its client and passes that request, including the byte array, onto a grain for processing. The front-end process doesn't do anything with the array once it has passed it on to the grain; in particular, it doesn't reuse the array to receive a future request. Inside the grain, the byte array is parsed to fetch the input data, but not modified. The grain returns another byte array that it has created to get passed back to the web client; it discards the array as soon as it returns it. The web front-end passes the result byte array back to its client, without modification.

In such a scenario, there is no need to copy either the request or response byte arrays. Unfortunately, the Orleans runtime can't figure this out by itself, since it can't tell whether or not the arrays are modified later on by the web front-end or by the grain. In the best of all possible worlds, we'd have some sort of .NET mechanism for indicating that a value is no longer modified; lacking that, we've added Orleans-specific mechanisms for this: the <xref:Orleans.Concurrency.Immutable%601> wrapper class and the <xref:Orleans.Concurrency.ImmutableAttribute>.

#### Use `Immutable<T>`

The <xref:Orleans.Concurrency.Immutable%601> wrapper class is used to indicate that a value may be considered immutable; that is, the underlying value will not be modified, so no copying is required for safe sharing. Note that using `Immutable<T>` implies that neither the provider of the value nor the recipient of the value will modify it in the future; it is not a one-sided commitment, but rather a mutual dual-side commitment.

To use `Immutable<T>` in your grain interface, instead of passing `T`, pass `Immutable<T>`. For instance, in the above-described scenario, the grain method was:

```csharp
Task<byte[]> ProcessRequest(byte[] request);
```

Which would then become:

```csharp
Task<Immutable<byte[]>> ProcessRequest(Immutable<byte[]> request);
```

To create an `Immutable<T>`, simply use the constructor:

```csharp
Immutable<byte[]> immutable = new(buffer);
```

To get the values inside the immutable, use the `.Value` property:

```csharp
byte[] buffer = immutable.Value;
```

### Use `[Immutable]`

For user-defined types, the <xref:Orleans.Concurrency.ImmutableAttribute> can be added to the type. This instructs Orleans' serializer to avoid copying instances of this type.
The following code snippet demonstrates using `[Immutable]` to denote an immutable type. This type will not be copied during transmission.

```csharp
[Immutable]
public class MyImmutableType
{
    public int MyValue { get; }

    public MyImmutableType(int value)
    {
        MyValue = value;
    }
}
```

### Immutability in Orleans

For Orleans' purposes, immutability is a rather strict statement: the contents of the data item will not be modified in any way that could change the item's semantic meaning, or that would interfere with another thread simultaneously accessing the item. The safest way to ensure this is to simply not modify the item at all: bitwise immutability, rather than logical immutability.

In some cases, it is safe to relax this to logical immutability, but care must be taken to ensure that the mutating code is properly thread-safe; because dealing with multithreading is complex, and uncommon in an Orleans context, we strongly recommend against this approach and recommend sticking to bitwise immutability.

## Serialization best practices

Serialization serves two primary purposes in Orleans:

1. As a wire format for transmitting data between grains and clients at runtime.
1. As a storage format for persisting long-lived data for later retrieval.

The serializers generated by Orleans are suitable for the first purpose due to their flexibility, performance, and versatility. They are not as suitable for the second purpose, since they are not explicitly version-tolerant. It is recommended that users configure a version-tolerant serializer such as [Protocol Buffers](https://developers.google.com/protocol-buffers/) for persistent data. Protocol Buffers is supported via `Orleans.Serialization.ProtobufSerializer` from the [Microsoft.Orleans.OrleansGoogleUtils](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGoogleUtils/) NuGet package. The best practices for the particular serializer of choice should be used to ensure version tolerance. Third-party serializers can be configured using the `SerializationProviders` configuration property as described above.

:::zone-end
