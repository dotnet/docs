---
title: "BinaryFormatter migration guide: Migrate to protobuf-net"
description: "Migrate from BinaryFormatter to protobuf-net."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Migrate to protobuf-net

[protobuf-net](https://github.com/protobuf-net/protobuf-net) is a contract-based serializer for .NET code that writes data in the _protocol buffers_ serialization format engineered by Google.

- By default, both public and non-public types are serializable. Every type needs to provide a parameterless constructor.
- protobuf-net requires each serializable type to be annotated with `[ProtoContract]` attribute.
- Every serializable non-static field and a property needs to be annotated with `[ProtoMember(int tag)]` attribute. The member names aren't encoded in the data. Instead, the users must pick an integer to identify each member.
- [Inheritance](https://github.com/protobuf-net/protobuf-net?tab=readme-ov-file#inheritance) must be explicitly declared via `[ProtoInclude(...)]` attribute on each type with known subtypes.
- Read-only fields are supported by default.
