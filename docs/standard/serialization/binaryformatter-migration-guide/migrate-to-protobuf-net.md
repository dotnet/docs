---
title: "BinaryFormatter migration guide: Migrate to protobuf-net (binary)"
description: "Migrate from BinaryFormatter to protobuf-net for binary serialization."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: upgrade-and-migration-article
---

# Migrate to protobuf-net (binary)

The [protobuf-net](https://github.com/protobuf-net/protobuf-net) library is a contract-based serializer for .NET that uses the binary [Protocol Buffers](https://protobuf.dev) serialization format. The API follows typical .NET patterns and is broadly comparable to `XmlSerializer` and `DataContractSerializer`.

Some behaviors and features of protobuf-net will be notable during migrations from BinaryFormatter, and many scenarios require applying attributes to members.

- By default, both public and non-public types are serializable, with the serializer expecting a parameterless constructor.
- protobuf-net requires each serializable type to be annotated with `[ProtoContract]` attribute; this attribute can optionally specify the `SkipConstructor = true` property, which *removes* the need for any particular constructor.
- Every serializable non-static field and a property needs to be annotated with `[ProtoMember(int identifier)]` attribute. The member names aren't encoded in the data. Instead, the users must pick a positive integer to identify each member which must be unique within that type.
- [Inheritance](https://github.com/protobuf-net/protobuf-net?tab=readme-ov-file#inheritance) must be explicitly declared via `[ProtoInclude(...)]` attribute on each type with known subtypes.
- Read-only fields are supported by default.
- Alternatively, some non-attributed tuple-like types are recognized by *constructor pattern*; a type with a constructor that has parameters that match (by name) all of the declared public members will be interpreted as a tuple, and the parameter order will be used to infer the identifier for that member.
- The use of the [`protobuf-net.BuildTools`](https://protobuf-net.github.io/protobuf-net/build_tools) design-time package is highly recommended; this offers compile-time warnings of common errors.

## Step by step migration

1. Find all the usages of `BinaryFormatter`.
2. Ensure that the serialization code paths are covered with tests, so you can verify your changes and avoid introducing bugs.
3. Install `protobuf-net` package (and optionally `protobuf-net.BuildTools`).
4. Find all the types that are being serialized with `BinaryFormatter`.
5. For types that you can modify:
   - Annotate with `[ProtoContract]` attribute all types that are marked with `[Serializable]` or implement the `ISerializable` interface. If these types are not exposed to other apps (example: you are writing a library) that may use different serializers like `DataContractSerializer`, you can remove the `[Serializable]` and `ISerializable` annotations.
   - For derived types, apply `[ProtoInclude(...)]` to their base types (see the example below).
   - For every type that declares any constructor that accepts parameters, add a parameterless constructor, or specify `SkipConstructor = true` on the `[ProtoContract]` attribute. Leave a comment that explains the protobuf-net requirement (so nobody removes it by accident).
   - Mark all the members (fields and properties) that you wish to serialize with `[ProtoMember(int identifier)]`. All identifiers must be unique within a single type, but the same numbers can be re-used in sub-types if inheritance is enabled.
6. For types that you can't modify:
   - For types provided by the .NET itself, you can use `ProtoBuf.Meta.RuntimeTypeModel.Default.CanSerialize(Type type)` API to check if they are natively supported by protobuf-net.
   - You can create dedicated data transfer objects (DTO) and map them accordingly (you could use implicit cast operator for that).
   - Use the `RuntimeTypeModel` API to define everything that the attributes allow for.
7. Replace the usage of `BinaryFormatter` with `ProtoBuf.Serializer`.

```diff
-[Serializable]
+[ProtoContract]
+[ProtoInclude(2, typeof(Point2D))]
public class Point1D
{
+   [ProtoMember(1)]
    public int X { get; set; }
}

-[Serializable]
+[ProtoContract]
public class Point2D : Point1D
{
+   [ProtoMember(2)]
    public int Y { get; set; }
}
```
