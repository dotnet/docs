---
title: "BinaryFormatter Migration Guide: Choosing a serializer"
description: "Compare the capabilities and trade-offs of serializers to choose a replacement for BinaryFormatter."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
  - VB
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Choosing a serializer

Choosing a serializer format boils down to two questions:

- Is compact binary representation important for your scenario? If so, you need to switch to a different binary serializer. If not, you can consider using JSON and XML serialization.
- Can you modify the types that are being serialized by annotating them with attributes, adding new constructors, making the types public and changing fields to properties? If not, using the modern serializers might require more work (like implementing custom converters or resolvers).

| Feature                                        | BinaryFormatter | DataContractSerializer | System.Text.Json        | MessagePack              |
|------------------------------------------------|-----------------|------------------------|-------------------------|--------------------------|
| Compact binary representation                  | ✔️              | ❌                      | ❌                      |  ✔️                       |
| Human readable                                 | ❌️              | ✔                      | ✔                      |  ❌                       |
| Performance                                    | ❌️              | ❌                      | ✔️                      |  ✔️✔️                     |
| `[Serializable]` support                       | ✔️              | ✔️                      | ❌                      |  ❌                       |
| Serializing public types                       | ✔️              | ✔️                      | ✔️                      |  ✔️                       |
| Serializing non-public types                   | ✔️              | ✔️                      | ✔️                      |  ✔️ (resolver required)   |
| Serializing fields                             | ✔️              | ✔️                      | ✔️ (opt in)             |  ✔️ (attribute required)  |
| Serializing properties                         | ✔️<sup>*</sup>  | ✔️                      | ✔️                      |  ✔️ (attribute required)  |
| Deserializing readonly members                 | ✔️              | ✔️                      | ✔️ (attribute required) |  ✔️                       |
| Polymorphic type hierarchy                     | ✔️              | ✔️                      | ✔️ (attribute required) |  ✔️ (attribute required)  |

### XML

The .NET base class libraries provide two XML serializers [XmlSerializer](https://learn.microsoft.com/en-us/dotnet/standard/serialization/introducing-xml-serialization) and [DataContractSerializer](https://learn.microsoft.com/dotnet/fundamentals/runtime-libraries/system-runtime-serialization-datacontractserializer). There are some subtle differences between these two, but for the purpose of the migration we are going to focus only on `DataContractSerializer`. Why? Because it **fully supports the serialization programming model that was used by the `BinaryFormatter`**. So all the types that are already marked as `[Serializable]` and/or implement `ISerializable` can be serialized with `DataContractSerializer`. Where is the catch? Known types must be specified up-front (that is why it's secure). So you need to know them and be able to get the `Type` **even for private types**.

```cs
DataContractSerializer serializer = new(
    type: input.GetType(),
    knownTypes: new Type[]
    {
        typeof(MyType1),
        typeof(MyType2)
    });
```

It's not required to specify most popular collections or primitive types like `string` or `DateTime` (the serializer has it's own default allowlist), but there are exceptions like `DateTimeOffset`. You can read about the supported types in the [dedicated doc](https://learn.microsoft.com/dotnet/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer).

[Partial trust](https://learn.microsoft.com/dotnet/framework/wcf/feature-details/partial-trust) is a Full .NET Framework feature that was not ported to .NET (Core). If your code runs on a Full .NET Framework and uses this feature, please read about the [limitations](https://learn.microsoft.com/dotnet/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer#limitations-of-using-certain-types-in-partial-trust-mode) that may apply to such scenario.

### JSON

[System.Text.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview) is strict by default and avoids any guessing or interpretation on the caller's behalf, emphasizing deterministic behavior. The library is intentionally designed this way for performance and security. From the migration perspective, it's crucial to know the following facts:
- By default, **fields aren't serialized**, but they can be [included on demand](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/fields), which is a must-have for types that use fields that are not exposed by properties. The simplest solution that does not require modifying the types is to use the global setting to include fields.
```cs
JsonSerializerOptions options = new()
{
    IncludeFields = true
};
```
- By default, System.Text.Json **ignores private fields and properties**. You can enable use of a non-public accessor on a property by using the `[JsonInclude]` attribute. Including private fields requires some [non-trivial extra work](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/custom-contracts#example-serialize-private-fields).
- It **[can not deserialize readonly fields](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions.ignorereadonlyfields?view#remarks)** or properties, but `[JsonConstructor]` attribute can be used to indicate that given constructor should be used to create instances of the type on deserialization. And obviously the constructor can set the readonly fields and properties.
- It [supports serialization and deserialization of most built-in collections](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/supported-collection-types). The exceptions:
    - multi-dimensional arrays,
    - `BitArray`,
    - `LinkedList<T>`,
    - `Dictionary<TKey, TValue>`, where `TKey` is not a primitive type,
    - `BlockingCollection<T>` and `ConcurrentBag<T>`,
    - most of the collections from [System.Collections.Specialized](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/supported-collection-types#systemcollectionsspecialized-namespace) and [System.Collections.ObjectModel](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/supported-collection-types#systemcollectionsobjectmodel-namespace) namespaces.
- Under [certain condtions](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/supported-collection-types#custom-collections-with-deserialization-support), it supports serialization and deserialization of custom generic collections.
- Other types [without built-in support](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft?pivots=dotnet-9-0#types-without-built-in-support) are: `DataSet`, `DataTable`, `DBNull`, `TimeZoneInfo`, `Type`, `ValueTuple`. However, you can write a custom converter to support these types.
- It [supports polymorphic type hierarchy serialization and deserialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism) that have been explicitly opted in via the `[JsonDerivedType]` attribute or via custom resolver.
- The `[JsonIgnore]` attribute on a property causes the property to be omitted from the JSON during serialization.
- To preserve references and handle circular references in System.Text.Json, set `JsonSerializerOptions.ReferenceHandler` to `Preserve`.
- To override the default behavior you can [write custom converters](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/converters-how-to).

### Binary

.NET Team is deprecating the `BinaryFormatter`, but at the same time we currently have no plans to implement a new binary serializer. It puts us in a situation, where we can't recommend any serializer that we own. But luckily for all of us, the .NET Open Source Ecosystem provides many great binary serializers. Some of them:

[protobuf-net](https://github.com/protobuf-net/protobuf-net) is "a contract based serializer for .NET code, that happens to write data in the _protocol buffers_ serialization format engineered by Google". Because protobuf-net is a cross-language protocol, it has some subtle issues with .NET-specific concepts like [nulls and empty arrays](https://stackoverflow.com/questions/21631428/protobuf-net-deserializes-empty-collection-to-null-when-the-collection-is-a-prop/21632160#21632160). Since this document is about a migration from `BinaryFormatter`, we can safely assume that we don't need cross-language support and the complexity it brings. That is why in this particular scenario of binary serialization, we recommend MessagePack.

MessagePack provides a highly efficient binary serialization format, resulting in smaller message sizes compared to JSON and XML. It's very [performant](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#performance), ships with built-in support for LZ4 compression and a full set of general-purpose expressive data types:

- By default, only public types are serializable. Private and internal structs and classes can be serialized only when `StandardResolverAllowPrivate.Options` is provided as an argument to `MessagePackSerializer.Serialize` and `MessagePackSerializer.Deserialize` methods.
- MessagePack requires each serializable type to be annotated with `[MessagePackObject]` attribute. It's possible to avoid that by using the [ContractlessStandardResolver](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization), but it may cause issues with versioning in the future.
- Every serializable non-static field and a property needs to be annotated with `[Key]` attribute. If you annotate the type with `[MessagePackObject(keyAsPropertyName: true)]` attribute, then members do not require explicit annotations. In such case, to ignore certain public members the `[IgnoreMember]` attribute needs to be used.
- To serialize private members, use [DynamicObjectResolverAllowPrivate](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization).
- `System.Runtime.Serialization` annotations can be used instead of MessagePack annotations. `[DataContract]` instead of`[MessagePackObject]`, `[DataMember]` instead of `[Key]` and `[IgnoreDataMember]` instead of `[IgnoreMember]`. It can be very useful if you want to avoid having dependency on MessagePack in the library that defines serializable types.
- It supports readonly/immutable types and members. The serializer will try to use the public constructor with the best matched argument list. It can be specified in an explicit way by using `[SerializationConstructor]` attribute.
- The serializer supports most frequently used built-in types and collections provided by the .NET base class libraries. You can find the full list in [official docs](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#built-in-supported-types). It has [extension points](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#extensions) that allow for customization.
- The library provides [Typless API](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#typeless) similar to `BinaryFormatter`, but it should not be used as it's not [secure](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#security) and would defeat the purpose of migrating from `BinaryFormatter`.
