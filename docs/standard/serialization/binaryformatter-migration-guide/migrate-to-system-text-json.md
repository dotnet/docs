---
title: "BinaryFormatter migration guide: Migrate to System.Text.Json (JSON)"
description: "Migrate from BinaryFormatter to System.Text.Json for JSON serialization."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization, System.Text.Json]
dev_langs:
  - CSharp
helpviewer_keywords:
  - "BinaryFormatter"
  - "System.Text.Json"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Migrate to System.Text.Json (JSON)

[System.Text.Json](../system-text-json/overview.md) defaults to emphasizing literal, deterministic behavior and avoids any guessing or interpretation on the caller's behalf. The library is intentionally designed this way for security and performance. From the migration perspective, it's crucial to know the following facts:

- By default, **fields are not serialized or deserialized**, but they can be [annotated for serialization](../system-text-json/fields.md), or `JsonSerializerOptions.IncludeFields` can be cautiously set to `true` to include all fields.

  ```csharp
  JsonSerializerOptions options = new()
  {
      IncludeFields = true
  };
  ```

- By default, System.Text.Json **ignores private fields and properties**. You can enable use of a non-public accessor on a property by using the `[JsonInclude]` attribute. Including private fields requires some [non-trivial extra work](../system-text-json/custom-contracts.md#example-serialize-private-fields).

- System.Text.Json **[cannot deserialize read-only fields](/dotnet/api/system.text.json.jsonserializeroptions.ignorereadonlyfields?view#remarks)** or properties, but the `[JsonConstructor]` attribute can be used to indicate that the specified constructor should be used to create instances of the type on deserialization. The constructor can set the read-only fields and properties.

- It [supports serialization and deserialization of most built-in collections](../system-text-json/supported-collection-types.md). The exceptions:
  - multi-dimensional arrays,
  - `BitArray`,
  - `LinkedList<T>`,
  - `Dictionary<TKey, TValue>`, where `TKey` is not a primitive type,
  - `BlockingCollection<T>` and `ConcurrentBag<T>`,
  - most of the collections from [System.Collections.Specialized](../system-text-json/supported-collection-types.md#systemcollectionsspecialized-namespace) and [System.Collections.ObjectModel](../system-text-json/supported-collection-types.md#systemcollectionsobjectmodel-namespace) namespaces.

- Under [certain conditions](../system-text-json/supported-collection-types.md#custom-collections-with-deserialization-support), it supports serialization and deserialization of custom generic collections.

- Other types [without built-in support](../system-text-json/migrate-from-newtonsoft.md#types-without-built-in-support) are: `DataSet`, `DataTable`, `DBNull`, `TimeZoneInfo`, `Type`, `ValueTuple`. However, you can write a custom converter to support these types.

- It [supports polymorphic type hierarchy serialization and deserialization](../system-text-json/polymorphism.md) where the types have been explicitly opted in via the `[JsonDerivedType]` attribute or custom converter.

- The `[JsonIgnore]` attribute on a property causes the property to be omitted from the JSON during serialization.

- To preserve references and handle circular references in System.Text.Json, set `JsonSerializerOptions.ReferenceHandler` to `ReferenceHandler.Preserve`.

- To override the default behavior, you can [write custom converters](../system-text-json/converters-how-to.md).
