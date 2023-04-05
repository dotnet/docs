---
title: Serialization overview in Orleans
description: Learn about serialization and custom serializers in .NET Orleans.
ms.date: 12/15/2022
uid: orleans-serialization
zone_pivot_groups: orleans-version
---

# Serialization overview in Orleans

Orleans has an advanced and extensible serialization framework. Orleans serializes data types passed in grain request and response messages as well as grain persistent state objects. As part of this framework, Orleans automatically generates serialization code for those data types. In addition to generating a more efficient serialization/deserialization for types that are already .NET-serializable, Orleans also tries to generate serializers for types used in grain interfaces that are not .NET-serializable. The framework also includes a set of efficient built-in serializers for frequently used types: lists, dictionaries, strings, primitives, arrays, etc.

Two important features of Orleans's serializer set it apart from a lot of other third-party serialization frameworks: dynamic types/arbitrary polymorphism and object identity.

1. **Dynamic types and arbitrary polymorphism**: Orleans doesn't enforce restrictions on the types that can be passed in grain calls and maintain the dynamic nature of the actual data type. That means, for example, that if the method in the grain interfaces is declared to accept <xref:System.Collections.IDictionary> but at runtime, the sender passes <xref:System.Collections.Generic.SortedDictionary%602>, the receiver will indeed get `SortedDictionary` (although the "static contract"/grain interface did not specify this behavior).

1. **Maintaining object identity**: If the same object is passed multiple types in the arguments of a grain call or is indirectly pointed more than once from the arguments, Orleans will serialize it only once. On the receiver side, Orleans will restore all references correctly so that two pointers to the same object still point to the same object after deserialization as well. Object identity is important to preserve in scenarios like the following. Imagine actor A is sending a dictionary with 100 entries to actor B, and 10 of the keys in the dictionary point to the same object, obj, on A's side. Without preserving object identity, B would receive a dictionary of 100 entries with those 10 keys pointing to 10 different clones of obj. With object identity-preserved, the dictionary on B's side looks exactly like on A's side with those 10 keys pointing to a single object obj.

The above two behaviors are provided by the standard .NET binary serializer and it was therefore important for us to support this standard and familiar behavior in Orleans as well.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

## Generated serializers

Starting with Orleans 7.0 a version-tolerant serializer was introduced. This change was made because applications tend to evolve and this led to a significant pitfall for developers, since the previous serializer couldn't tolerate adding properties to existing types. On the other hand, the serializer was flexible, allowing developers to represent most .NET types without modification, including features such as generics, polymorphism, and reference tracking. A replacement was long overdue, but users still need the high-fidelity representation of their types. Therefore, a replacement serializer was introduced in Orleans 7.0 which supports the high-fidelity representation of .NET types while also allowing types to evolve. The serializer in Orleans 7.0 is much more efficient than the previous serializer, resulting in up to 170% higher end-to-end throughput.

The new serializer requires you to be explicit about which types and members are serialized. We have tried to make this as pain-free as possible. You must mark all serializable types with <xref:Orleans.CodeGeneration.GenerateSerializerAttribute?displayProperty=nameWithType> to instruct Orleans to generate serializer code for your type. Once you have done this, you can use the included code-fix to add the required <xref:Orleans.IdAttribute?displayProperty=nameWithType> to the serializable members on your types, as demonstrated here:

:::image type="content" source="media/generate-serializer-code-fix.gif" alt-text="An animated image of the available code fix being suggested and applied on the GenerateSerializerAttribute when the containing type doesn't contain IdAttribute's on its members." lightbox="media/generate-serializer-code-fix.gif":::

By default, Orleans will serialize your type by encoding its full name. You can override this by adding an <xref:Orleans.AliasAttribute?displayProperty=nameWithType>. Doing so will result in your type being serialized using a name that is resistant to renaming the underlying class or moving it between assemblies. Type aliases are globally scoped, and you cannot have two aliases with the same value in an application. For generic types, the alias value must include the number of generic parameters preceded by a backtick, for example, `MyGenericType<T, U>` could have the alias <code>[Alias("mytype\`2")]</code>.

## Serialize `record` types

Members defined in a record's primary constructor have implicit ids by default. In other words, Orleans supports serializing `record` types. This means that you cannot change the parameter order for an already deployed type, since that breaks compatibility with previous versions of your application (in the case of a rolling upgrade) and with serialized instances of that type in storage and streams. Members defined in the body of a record type don't share identities with the primary constructor parameters.

```csharp
[GenerateSerializer]
public record MyRecord(string A, string B)
{
    // ID 0 won't clash with A in primary constructor as they don't share identities
    [Id(0)]
    public string C { get; init; }
}
```

If you don't want the primary constructor parameters to be automatically included as Serializable fields, you can use `[GenerateSerializer(IncludePrimaryConstructorParameters = false)]`.

## Surrogates for serializing foreign types

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

// This is a converter that converts between the surrogate and the foreign type.
[RegisterConverter]
public sealed class MyForeignLibraryValueTypeSurrogateConverter :
    IConverter<MyForeignLibraryValueType, MyForeignLibraryValueTypeSurrogate>
{
    public MyForeignLibraryValueType ConvertFromSurrogate(
        in MyForeignLibraryValueTypeSurrogate surrogate) =>
        new(surrogate.Num, surrogate.String, surrogate.DateTimeOffset);

    public MyForeignLibraryValueTypeSurrogate ConvertToSurrogate(
        in MyForeignLibraryValueType value) =>
        new()
        {
            Num = value.Num,
            String = value.String,
            DateTimeOffset = value.DateTimeOffset
        };
}
```

In the preceding code:

- The `MyForeignLibraryValueType` is a type outside of your control, defined in a consuming library.
- The `MyForeignLibraryValueTypeSurrogate` is a surrogate type that maps to `MyForeignLibraryValueType`.
- The <xref:Orleans.RegisterConverterAttribute> specifies that the `MyForeignLibraryValueTypeSurrogateConverter` acts as a converter to map to and from the two types. The class is an implementation of the <xref:Orleans.IConverter%602> interface.

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

### Immutability enhancements

Orleans opts for safety by default. To ensure that values sent between grains are not modified after the call site or during transmission, these values are copied immediately when making a grain call or returning a response from a grain.
In cases where a developer knows that a type will not be modified, Orleans can be instructed to skip this copy process.
In previous version of Orleans, there were two ways to do this:

1. Wrapping your value in <xref:Orleans.Concurrency.Immutable%601>, using `new Immutable<T>(myValue)`. This requires that your grain interface method parameters and return types are `Immutable<T>`, where `T` is the underlying type, so it can be quite invasive and it is extra ceremony.
1. Marking your type with the <xref:Orleans.ImmutableAttribute>. This causes Orleans' code generator to emit code that avoids copying any object of that type.

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

## Grain storage serializers

Orleans includes a provider-backed persistence model for grains, accessed via the <xref:Orleans.Grain%601.State?displayName=nameWithType> property or by injecting one or more <xref:Orleans.Runtime.IPersistentState%601> values into your grain. Before Orleans 7.0, each provider had a different mechanism for configuring serialization. In Orleans 7.0, there is now a general-purpose grain state serializer interface, <xref:Orleans.Storage.IGrainStorageSerializer>, which offers a consistent way to customize state serialization for each provider. Supported storage providers implement a pattern that involves setting the <xref:Orleans.Storage.IStorageProviderSerializerOptions.GrainStorageSerializer%2A?displayProperty=nameWithType> property on the provider's options class, for example:

- <xref:Orleans.Configuration.DynamoDBStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AzureBlobStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AzureTableStorageOptions.GrainStorageSerializer?displayProperty=nameWithType>
- <xref:Orleans.Configuration.AdoNetGrainStorageOptions.GrainStorageSerializer>

Grain storage serialization currently defaults to `Newtonsoft.Json` to serialize state. You can replace this by modifying that property at configuration time. The following example demonstrates this, using [OptionsBuilder\<TOptions\>](../../../core/extensions/options.md#optionsbuilder-api):

```csharp
siloBuilder.AddAzureBlobGrainStorage(
    "MyGrainStorage",
    (OptionsBuilder<AzureBlobStorageOptions> optionsBuilder) =>
    {
        optionsBuilder.Configure<IMySerializer>(
            (options, serializer) => options.GrainStorageSerializer = serializer);
    });
```

For more information, see [OptionsBuilder API](../../../core/extensions/options.md#optionsbuilder-api).

## Serialization best practices

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

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## Generated serializers

Orleans uses the following rules to decide which serializers to generate.
The rules are:

1. Scan all types in all assemblies which reference the core Orleans library.
1. Out of those assemblies: generate serializers for types that are directly referenced in grain interfaces method signatures or state class signature or for any type that is marked with  <xref:System.SerializableAttribute>.
1. In addition, a grain interface or implementation project can point to arbitrary types for serialization generation by adding a <xref:Orleans.CodeGeneration.KnownTypeAttribute> or <xref:Orleans.CodeGeneration.KnownAssemblyAttribute> assembly-level attributes to tell code generator to generate serializers for specific types or all eligible types within an assembly. For more information on assembly-level attributes, see [Apply attributes at the assembly level](../../../standard/attributes/applying-attributes.md#apply-attributes-at-the-assembly-level).

## Fallback serialization

Orleans supports transmission of arbitrary types at runtime and therefore the in-built code generator cannot determine the entire set of types that will be transmitted ahead of time. Additionally, certain types cannot have serializers generated for them because they are inaccessible (for example, `private`) or have inaccessible fields (for example, `readonly`). Therefore, there is a need for just-in-time serialization of types that were unexpected or could not have serializers generated ahead of time. The serializer responsible for these types is called the *fallback serializer*. Orleans ships with two fallback serializers:

* <xref:Orleans.Serialization.BinaryFormatterSerializer?displayProperty=fullName>, which uses .NET's <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>; and
* <xref:Orleans.Serialization.ILBasedSerializer?displayProperty=fullName>, which emits [CIL](../../../standard/glossary.md#il) instructions at runtime to create serializers that leverage Orleans' serialization framework to serialize each field. This means that if an inaccessible type `MyPrivateType` contains a field `MyType` which has a custom serializer, that custom serializer will be used to serialize it.

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

Exceptions are serialized using the [fallback serializer](serialization.md#fallback-serialization). Using the default configuration, `BinaryFormatter` is the fallback serializer and so the [ISerializable pattern](/previous-versions/dotnet/fundamentals/serialization/binary/custom-serialization) must be followed in order to ensure correct serialization of all properties in an exception type.

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

## Serialization best practices

Serialization serves two primary purposes in Orleans:

1. As a wire format for transmitting data between grains and clients at runtime.
1. As a storage format for persisting long-lived data for later retrieval.

The serializers generated by Orleans are suitable for the first purpose due to their flexibility, performance, and versatility. They are not as suitable for the second purpose, since they are not explicitly version-tolerant. It is recommended that users configure a version-tolerant serializer such as [Protocol Buffers](https://developers.google.com/protocol-buffers/) for persistent data. Protocol Buffers is supported via `Orleans.Serialization.ProtobufSerializer` from the [Microsoft.Orleans.OrleansGoogleUtils](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGoogleUtils/) NuGet package. The best practices for the particular serializer of choice should be used to ensure version tolerance. Third-party serializers can be configured using the `SerializationProviders` configuration property as described above.

:::zone-end
