---
title: How to instantiate JsonSerializerOptions with System.Text.Json
description: "Learn about constructors for JsonSerializerOptions instances and how to reuse JsonSerializerOptions instances."
ms.date: 02/07/2024
no-loc: [System.Text.Json]
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

## The `JsonSerializerOptions.Default` property

If the instance of `JsonSerializerOptions` that you need to use is the default instance (has all of the default settings and the default converters), use the <xref:System.Text.Json.JsonSerializerOptions.Default?displayProperty=nameWithType> property rather than creating an options instance. For more information, see [Use default system converter](converters-how-to.md#use-default-system-converter).

## Copy JsonSerializerOptions

There is a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerOptions)) that lets you create a new instance with the same options as an existing instance, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/CopyOptions.cs" highlight="28":::
:::code language="vb" source="snippets/how-to-contd/vb/CopyOptions.vb" :::

The metadata cache of the existing `JsonSerializerOptions` instance isn't copied to the new instance. So using this constructor is not the same as reusing an existing instance of `JsonSerializerOptions`.

## Web defaults for JsonSerializerOptions

The following options have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>
* <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A> = <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>

In .NET 9 and later versions, you can use the <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton to serialize with the default options that ASP.NET Core uses for web apps. In earlier versions, call the [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerDefaults)) to create a new instance with the web defaults, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/OptionsDefaults.cs" highlight="23":::
:::code language="vb" source="snippets/how-to-contd/vb/OptionsDefaults.vb" :::
