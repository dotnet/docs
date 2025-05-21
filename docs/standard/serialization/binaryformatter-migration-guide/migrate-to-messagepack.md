---
title: "BinaryFormatter migration guide: Migrate to MessagePack (binary)"
description: "Migrate from BinaryFormatter to MessagePack for binary serialization."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: upgrade-and-migration-article
---

# Migrate to MessagePack (binary)

[MessagePack](https://msgpack.org/) is a compact binary serialization format, resulting in smaller message sizes compared to JSON and XML. The open source [MessagePack for C#](https://github.com/MessagePack-CSharp/MessagePack-CSharp) library is highly performant and offers built-in super-fast LZ4 compression for an even smaller data size. It works best when data types are annotated with either `DataContractSerializer` or the library's own attributes. It can be configured to support AOT environments, non-public types and members, and read-only types and members.

Some behaviors and features of MessagePack for C# will be notable during migrations from BinaryFormatter, especially if changes to the serialized types' APIs cannot be made or need to be minimized.

- By default, only public types are serializable. Private and internal structs and classes can be serialized only when `StandardResolverAllowPrivate.Options` is provided as an argument to `MessagePackSerializer.Serialize` and `MessagePackSerializer.Deserialize` methods.

- MessagePack requires each serializable type to be annotated with the `[MessagePackObject]` attribute. It's possible to avoid that by using the [ContractlessStandardResolver](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization), but it might cause issues with versioning in the future.

- Every serializable non-static field and a property needs to be annotated with the `[Key]` attribute. If you annotate the type with the `[MessagePackObject(keyAsPropertyName: true)]` attribute, then members don't require explicit annotations. In such case, to ignore certain public members, use the `[IgnoreMember]` attribute.

- To serialize private members, use [StandardResolverAllowPrivate](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#object-serialization).

- `System.Runtime.Serialization` annotations can be used instead of MessagePack annotations: `[DataContract]` instead of `[MessagePackObject]`, `[DataMember]` instead of `[Key]`, and `[IgnoreDataMember]` instead of `[IgnoreMember]`. These annotations can be useful if you want to avoid a dependency on MessagePack in the library that defines serializable types.

- It supports readonly/immutable types and members. The serializer will try to use the public constructor with the best matched argument list. The constructor can be specified in an explicit way by using `[SerializationConstructor]` attribute.

- Serialization of arbitrary types are supported via custom formatters that are simple to author. This removes all requirements for attributes and specific constructor or member patterns.

- The serializer supports most frequently used built-in types and collections provided by the .NET base class libraries. You can find the full list in [official docs](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#built-in-supported-types). It has [extension points](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#extensions) that allow for customization.

> [!WARNING]
> MessagePack has APIs to allow for deserializing data without type restrictions. Per [MessagePack Security Notes](https://github.com/MessagePack-CSharp/MessagePack-CSharp?tab=readme-ov-file#security), these APIs should be avoided.

> [!WARNING]
> Some MessagePack APIs have behavior that is customizable via *mutable statics*, meaning your code may succeed or fail based on what other code in the same process, AssemblyLoadContext or AppDomain might do.
> You can keep your code resilient by also referencing the [MessagePackAnalyzer](https://www.nuget.org/packages/messagepackanalyzer) package and enabling the MsgPack001 and MsgPack002 analyzers, which call out any uses of APIs with changeable behavior.
