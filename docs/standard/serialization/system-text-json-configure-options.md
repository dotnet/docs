---
title: How to instantiate JsonSerializerOptions with System.Text.Json
description: "Learn how to instantiate JsonSerializerOptions instances by copying existing instances or with web defaults."
ms.date: 11/30/2020
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# How to instantiate JsonSerializerOptions instances with System.Text.Json

In this article, you'll learn how to instantiate <xref:System.Text.Json.JsonSerializerOptions> instances by copying existing instances or with web defaults.

## Copy JsonSerializerOptions

::: zone pivot="dotnet-5-0"
There is a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerOptions)) that lets you create a new instance with the same options as an existing instance, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CopyOptions.cs" highlight="29":::
::: zone-end

::: zone pivot="dotnet-core-3-1"
A `JsonSerializerOptions` constructor that takes an existing instance is not available in .NET Core 3.1.
::: zone-end

## Web defaults for JsonSerializerOptions

::: zone pivot="dotnet-5-0"
Here are the options that have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>
* <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A> = <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>

There's a [JsonSerializerOptions constructor](xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerDefaults)?view=net-5.0&preserve-view=true) that lets you create a new instance with the default options that ASP.NET Core uses for web apps, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/OptionsDefaults.cs" highlight="24":::
::: zone-end

::: zone pivot="dotnet-core-3-1"
Here are the options that have different defaults for web apps:

* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive%2A> = `true`
* <xref:System.Text.Json.JsonNamingPolicy> = <xref:System.Text.Json.JsonNamingPolicy.CamelCase>

A `JsonSerializerOptions` constructor that specifies a set of defaults is not available in .NET Core 3.1.
::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON](system-text-json-handle-overflow.md)
* [Preserve circular references](system-text-json-preserve-references.md)
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [System.Text.Json API reference](xref:System.Text.Json)
