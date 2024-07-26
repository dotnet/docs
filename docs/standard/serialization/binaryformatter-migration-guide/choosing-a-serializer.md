---
title: "BinaryFormatter Migration Guide: Choosing a serializer"
description: "Compare the capabilities and trade-offs of serializers to choose a replacement for BinaryFormatter."
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

# Choose a serializer

Choosing a serializer format boils down to two questions:

- Is compact binary representation important for your scenario? If so, you need to switch to a different binary serializer. .NET open-source ecosystem provides many great binary serializers and we recommend two of them: [MessagePack](./migration-to-message-pack.md) and [protobuf-net](./migration-to-protobuf-net.md). If compact binary representation is not a must have, you can consider using JSON and XML serialization. For XML, we recommend [DataContractSerializer](./migration-to-data-contract-serializer.md) and for JSON the [System.Text.Json](./migration-to-system-text-json.md).
- Can you modify the types that are being serialized by annotating them with attributes, adding new constructors, making the types public and changing fields to properties? If not, using the modern serializers might require more work (like implementing custom converters or resolvers).

| Feature                                        | BinaryFormatter | DataContractSerializer | System.Text.Json        | MessagePack              | protobuf-net                      |
|------------------------------------------------|-----------------|------------------------|-------------------------|--------------------------|-----------------------------------|
| Compact binary representation                  | ✔️              | ❌                      | ❌                      |  ✔️                       |  ✔️                               |
| Human readable                                 | ❌️              | ✔️                      | ✔️                      |  ❌️                       |  ❌️                               |
| Performance                                    | ❌️              | ❌                      | ✔️                      |  ✔️                       |  ✔️                               |
| `[Serializable]` support                       | ✔️              | ✔️                      | ❌                      |  ❌                       |  ❌                               |
| Serializing public types                       | ✔️              | ✔️                      | ✔️                      |  ✔️                       |  ✔️                               |
| Serializing non-public types                   | ✔️              | ✔️                      | ✔️                      |  ✔️ (resolver required)   |  ✔️                               |
| Serializing fields                             | ✔️              | ✔️                      | ✔️ (opt in)             |  ✔️ (attribute required)  |  ✔️ (attribute required)          |
| Serializing non-public fields                  | ✔️              | ✔️                      | ✔️ (resolver required)  |  ✔️ (resolver required)   |  ✔️ (attribute required)          |
| Serializing properties                         | ✔️<sup>*</sup>  | ✔️                      | ✔️                      |  ✔️ (attribute required)  |  ✔️ (attribute required)          |
| Deserializing readonly members                 | ✔️              | ✔️                      | ✔️ (attribute required) |  ✔️                       |  ✔️ (parameterless ctor required) |
| Polymorphic type hierarchy                     | ✔️              | ✔️                      | ✔️ (attribute required) |  ✔️ (attribute required)  |  ✔️ (attribute required)          |
| AOT support                                    | ❌️              | ❌                      | ✔️                      |  ✔️                       |  ❌ (planned)                     |
