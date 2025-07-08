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

The [`System.Text.Json`](../system-text-json/overview.md) library defaults to emphasizing literal, deterministic behavior and avoids any guessing or interpretation on the caller's behalf. The library is intentionally designed this way for security and performance. While `System.Text.Json` is highly configurable and its features can be used to minimize changes needed to serialized types, it's important to consider the trade-offs between handling existing types with as few changes as possible vs. refactoring types to enable idiomatic and secure serialization.

When migrating from BinaryFormatter to `System.Text.Json`, it's crucial to note the following behaviors and options:

- By default, **fields are not serialized or deserialized** by `System.Text.Json`, but they can be [annotated for serialization](../system-text-json/fields.md). Alternatively, `JsonSerializerOptions.IncludeFields` can be cautiously set to `true` to include all public fields for the types being serialized.

  ```csharp
  JsonSerializerOptions options = new()
  {
      IncludeFields = true
  };
  ```

- By default, System.Text.Json **ignores private fields and properties**. You can enable use of a non-public accessor on a property by using the `[JsonInclude]` attribute. Including private fields requires some [non-trivial extra work](../system-text-json/custom-contracts.md#example-serialize-private-fields).

- System.Text.Json **[cannot deserialize read-only fields](/dotnet/api/system.text.json.jsonserializeroptions.ignorereadonlyfields?view#remarks)** or properties, but the `[JsonConstructor]` attribute can be used to indicate that the specified constructor should be used to create instances of the type on deserialization. The constructor can set the read-only fields and properties.

- To override the default serialization behavior for a specific type, you can [write custom converters](../system-text-json/converters-how-to.md).

- It supports serialization and deserialization of many collections, but there are limitations. See the [supported types](../system-text-json/supported-types.md) documentation for details on which types and collections are supported for serialization and deserialization.

- Under [certain conditions](../system-text-json/supported-types.md#deserialization-support), it supports serialization and deserialization of custom generic collections.

- Other types [without built-in support](../system-text-json/migrate-from-newtonsoft.md#types-without-built-in-support) are: `DataSet`, `DataTable`, `DBNull`, `TimeZoneInfo`, `Type`, `ValueTuple`. However, you can write a custom converter to support these types.

- It [supports polymorphic type hierarchy serialization and deserialization](../system-text-json/polymorphism.md) where the types have been explicitly opted in via the `[JsonDerivedType]` attribute or custom converter. Open inheritance hierarchies are not supported, and round-tripping with polymorphism requires type discriminator identifiers for all known derived types.

- The `[JsonIgnore]` attribute on a property causes the property to be omitted from the JSON during serialization.

- To preserve references and handle circular references in `System.Text.Json`, set `JsonSerializerOptions.ReferenceHandler` to `ReferenceHandler.Preserve`.

- Serialization can be extensively customized with [custom contracts](../system-text-json/custom-contracts.md), unblocking many scenarios while minimizing changes to serialized types.
