---
title: "BinaryFormatter Migration Guide: Migration to MessagePack"
description: "Describe the capabilities and limitations of MessagePack serializer."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Migration to MessagePack

MessagePack provides a highly efficient binary serialization format, resulting in smaller message sizes compared to JSON and XML. It's [performant](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#performance) and ships with built-in support for LZ4 compression and a full set of general-purpose expressive data types:

- By default, only public types are serializable. Private and internal structs and classes can be serialized only when `StandardResolverAllowPrivate.Options` is provided as an argument to `MessagePackSerializer.Serialize` and `MessagePackSerializer.Deserialize` methods.
- MessagePack requires each serializable type to be annotated with the `[MessagePackObject]` attribute. It's possible to avoid that by using the [ContractlessStandardResolver](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization), but it might cause issues with versioning in the future.
- Every serializable non-static field and a property needs to be annotated with the `[Key]` attribute. If you annotate the type with the `[MessagePackObject(keyAsPropertyName: true)]` attribute, then members don't require explicit annotations. In such case, to ignore certain public members, use the `[IgnoreMember]` attribute.
- To serialize private members, use [DynamicObjectResolverAllowPrivate](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization).
- `System.Runtime.Serialization` annotations can be used instead of MessagePack annotations: `[DataContract]` instead of`[MessagePackObject]`, `[DataMember]` instead of `[Key]`, and `[IgnoreDataMember]` instead of `[IgnoreMember]`. These annotations can be useful if you want to avoid a dependency on MessagePack in the library that defines serializable types.
- It supports readonly/immutable types and members. The serializer will try to use the public constructor with the best matched argument list. The constructor can be specified in an explicit way by using `[SerializationConstructor]` attribute.
- The serializer supports most frequently used built-in types and collections provided by the .NET base class libraries. You can find the full list in [official docs](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#built-in-supported-types). It has [extension points](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#extensions) that allow for customization.

> [!WARNING]
> MessagePack has APIs to allow for deserializing data without type restrictions. Per [MessagePack Security Notes](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#security), these APIs should be avoided.
