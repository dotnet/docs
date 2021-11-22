---
title: How to instantiate JsonSerializerOptions with System.Text.Json
description: "Learn how to avoid performance issues and how to use available constructors for JsonSerializerOptions instances."
ms.date: 01/19/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to instantiate JsonSerializerOptions instances with System.Text.Json

This article explains how to avoid performance problems when you use <xref:System.Text.Json.JsonSerializerOptions>. It also shows how to use the parameterized constructors that are available.

## Reuse JsonSerializerOptions instances

If you use `JsonSerializerOptions` repeatedly with the same options, don't create a new `JsonSerializerOptions` instance each time you use it. Reuse the same instance for every call. This guidance applies to code you write for custom converters and when you call <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> or <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType>. It's safe to use the same instance across multiple threads. The metadata caches on the options instance are thread-safe, and the instance is immutable after the first serialization or deserialization.

The following code demonstrates the performance penalty for using new options instances.

:::code language="csharp" source="snippets/system-text-json-configure-options/csharp/ReuseOptionsInstances.cs":::

The preceding code serializes a small object 100,000 times using the same options instance. Then it serializes the same object the same number of times and creates a new options instance each time. A typical run time difference is 190 compared to 40,140 milliseconds. The difference is even greater if you increase the number of iterations.

The serializer undergoes a warm-up phase during the first serialization of each type in the object graph when a new options instance is passed to it. This warm-up includes creating a cache of metadata that is needed for serialization. The metadata includes delegates to property getters, setters, constructor arguments, specified attributes, and so forth. This metadata cache is stored in the options instance. The same warm-up process and cache applies to deserialization.

The size of the metadata cache in a `JsonSerializerOptions` instance depends on the number of types to be serialized. If you pass numerous types—for example, dynamically generated types—to the serializer, the cache size will continue to grow and can end up causing an `OutOfMemoryException`.

## Copy JsonSerializerOptions

::: zone pivot="dotnet-5-0,dotnet-6-0"
There is a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerOptions)) that lets you create a new instance with the same options as an existing instance, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CopyOptions.cs" highlight="29":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/CopyOptions.vb" :::
::: zone-end

::: zone pivot="dotnet-core-3-1"
A `JsonSerializerOptions` constructor that takes an existing instance is not available in .NET Core 3.1.
::: zone-end

## Web defaults for JsonSerializerOptions

::: zone pivot="dotnet-5-0,dotnet-6-0"
Here are the options that have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>
* <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A> = <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>

There's a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerDefaults)) that lets you create a new instance with the default options that ASP.NET Core uses for web apps, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/OptionsDefaults.cs" highlight="24":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/OptionsDefaults.vb" :::
::: zone-end

::: zone pivot="dotnet-core-3-1"
Here are the options that have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>

A `JsonSerializerOptions` constructor that specifies a set of defaults is not available in .NET Core 3.1.
::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](system-text-json-handle-overflow.md)
* [Preserve references and handle circular references](system-text-json-preserve-references.md)
* [Deserialize to immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
