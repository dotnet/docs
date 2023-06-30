---
title: How to instantiate JsonSerializerOptions with System.Text.Json
description: "Learn about constructors for JsonSerializerOptions instances and how to reuse JsonSerializerOptions instances."
ms.date: 05/18/2023
no-loc: [System.Text.Json]
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

::: zone pivot="dotnet-6-0"

The following code demonstrates the performance penalty for using new options instances.

:::code language="csharp" source="snippets/configure-options/csharp/ReuseOptionsInstances.cs":::

The preceding code serializes a small object 100,000 times using the same options instance. Then it serializes the same object the same number of times and creates a new options instance each time. A typical run time difference is 190 compared to 40,140 milliseconds. The difference is even greater if you increase the number of iterations.

The serializer undergoes a warm-up phase during the first serialization of each type in the object graph when a new options instance is passed to it. This warm-up includes creating a cache of metadata that is needed for serialization. The metadata includes delegates to property getters, setters, constructor arguments, specified attributes, and so forth. This metadata cache is stored in the options instance. The same warm-up process and cache applies to deserialization.

The size of the metadata cache in a `JsonSerializerOptions` instance depends on the number of types to be serialized. If you pass numerous types—for example, dynamically generated types—to the serializer, the cache size will continue to grow and can end up causing an `OutOfMemoryException`.

::: zone-end

::: zone pivot="dotnet-7-0"

## The `JsonSerializerOptions.Default` property

If the instance of `JsonSerializerOptions` that you need to use is the default instance (has all of the default settings and the default converters), use the <xref:System.Text.Json.JsonSerializerOptions.Default?displayProperty=nameWithType> property rather than creating an options instance. For more information, see [Use default system converter](converters-how-to.md#use-default-system-converter).

::: zone-end

## Copy JsonSerializerOptions

There is a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerOptions)) that lets you create a new instance with the same options as an existing instance, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/CopyOptions.cs" highlight="28":::
:::code language="vb" source="snippets/how-to-5-0/vb/CopyOptions.vb" :::

The metadata cache of the existing `JsonSerializerOptions` instance isn't copied to the new instance. So using this constructor is not the same as reusing an existing instance of `JsonSerializerOptions`.

## Web defaults for JsonSerializerOptions

The following options have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>
* <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A> = <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>

The [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerDefaults)) lets you create a new instance with the default options that ASP.NET Core uses for web apps, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/OptionsDefaults.cs" highlight="23":::
:::code language="vb" source="snippets/how-to-5-0/vb/OptionsDefaults.vb" :::
