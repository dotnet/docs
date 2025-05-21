---
title: "BinaryFormatter migration guide: Migrate to DataContractSerializer (XML)"
description: "Migrate from BinaryFormatter to DataContractSerializer for XML serialization."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
helpviewer_keywords:
  - "BinaryFormatter"
  - "serialization [WCF]"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: upgrade-and-migration-article
---

# Migrate to DataContractSerializer (XML)

The .NET base class libraries provide two XML serializers: [XmlSerializer](../introducing-xml-serialization.md) and [DataContractSerializer](../../../fundamentals/runtime-libraries/system-runtime-serialization-datacontractserializer.md). There are some subtle differences between these two, but for the purpose of the migration, this section focuses only on `DataContractSerializer`. Why? Because it **fully supports the serialization programming model that was used by `BinaryFormatter`**. All the types that are already marked as `[Serializable]` or implement `ISerializable` can be serialized with `DataContractSerializer`. Where is the catch? Known types must be specified up front. You need to know them and be able to get the `Type`, **even for private types**.

It's not required to specify most popular collections or primitive types like `string` or `DateTime` (the serializer has its own default allow-list), but there are exceptions like `DateTimeOffset`. For more information about the supported types, see [Types supported by the data contract serializer](../../../framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md).

[Partial trust](../../../framework/wcf/feature-details/partial-trust.md) is a .NET Framework feature that wasn't ported to .NET (Core). If your code runs on .NET Framework and uses this feature, read about the [limitations](../../../framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md#limitations-of-using-certain-types-in-partial-trust-mode) that might apply to such a scenario.

## Step by step migration

1. Find all the usages of `BinaryFormatter`.
2. Ensure that the serialization code paths are covered with tests, so you can verify your changes and avoid introducing bugs.
3. You don't need to install any packages, as `DataContractSerializer` is part of the .NET core libraries.
4. Find all the types that are being serialized with `BinaryFormatter`. You don't need to modify any of them, but you may need to list them via `knownTypes` argument of the `DataContractSerializer` constructor.
5. Replace the usage of `BinaryFormatter` with `DataContractSerializer`.

```csharp
DataContractSerializer serializer = new(
    type: input.GetType(),
    knownTypes: new Type[]
    {
        typeof(MyType1),
        typeof(MyType2)
    });
```
