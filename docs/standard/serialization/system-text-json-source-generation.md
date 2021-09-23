---
title: How to use source generation in System.Text.Json
description: "Learn how to use source generation in System.Text.Json."
ms.date: 08/03/2021
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

# How to use source generation in System.Text.Json

:::zone pivot="dotnet-6-0"
> [!IMPORTANT]
> Some information relates to prerelease product that may be substantially modified before it's released. Microsoft makes no warranties, express or implied, with respect to the information provided here.

[System.Text.Json](system-text-json-overview.md) can use the C# [source generation](../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and improve [assembly trimming](../../core/deploying/trim-self-contained.md) accuracy. This article shows how to use the source generation features of System.Text.Json.
:::zone-end

:::zone pivot="dotnet-5-0,dotnet-core-3-1"
[System.Text.Json](system-text-json-overview.md) version 6.0 and later can use the C# [source generation](../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and improve [assembly trimming](../../core/deploying/trim-self-contained.md) accuracy. For information about how to use source generation in System.Text.Json, see [the .NET 6.0 version of this article](system-text-json-source-generation.md?pivots=dotnet-6-0).
:::zone-end

:::zone pivot="dotnet-6-0"

## Source generation modes

System.Text.Json provides two modes of source generation:

* Metadata collection
* Serialization optimization

You can use either mode by itself or in combination.

### Metadata collection mode

To serialize or deserialize a type, <xref:System.Text.Json.JsonSerializer> needs information about how to access the members of the type. To serialize, `JsonSerializer` needs to know how to access property getters and fields. To deserialize, it needs to know how to access a constructor, property setters, and fields. It also needs to know if any attributes have been used to customize serialization or deserialization. This information is referred to as *metadata*.

By default, `JsonSerializer` collects metadata at run time by using [Reflection](../../csharp/programming-guide/concepts/reflection.md). Whenever `JsonSerializer` has to serialize or deserialize a type for the first time, it collects and caches this metadata. The metadata collection process takes time and uses memory.

You can use source generation to move the metadata collection process from run time to compile time. During compilation, the metadata is collected and source code files are generated. The generated source code files are automatically compiled as an integral part of the application. This compile-time metadata collection eliminates run-time metadata collection, which improves performance of both serialization and deserialization.

### Serialization optimization mode

`JsonSerializer` has many features that customize the output of serialization, such as [camel-casing property names](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) and [preserving references](system-text-json-preserve-references.md#preserve-references-and-handle-circular-references). Support for all those features causes some performance overhead. Source generation can improve serialization performance by generating optimized code that uses [`Utf8JsonWriter`](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#use-utf8jsonwriter) directly. The optimized code doesn't support all of the serialization features that `JsonSerializer` supports. The serializer detects whether the optimized code can be used. For example, reference-handling isn't supported but even if it's selected, the serializer knows that it can call the optimized code for primitives and structs.

The following table shows which options specified by `JsonSerializerOptions` are supported by the optimized serialization code:

| Serialization option                                                   | Supported by optimized code |
|------------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.JsonSerializerOptions.Converters>               | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition>   | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy>      | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.Encoder> \*               | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties> | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IncludeFields>            | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.NumberHandling>           | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.WriteIndented> \*         | ✔️                         |

\* Some `Serialize` methods let you pass in a `Utf8JsonWriter` instance. In that case, you can set the `Encoder` and `WriteIndented` options by using <xref:System.Text.Json.JsonWriterOptions.Encoder?displayProperty=nameWithType> and <xref:System.Text.Json.JsonWriterOptions.Indented?displayProperty=nameWithType>.

The following table shows which attributes are supported by the optimized serialization code:

| Attribute                                                         | Supported by optimized code |
|-------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                         |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                         |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                         |

If a non-supported option or attribute is specified for a type, the serializer falls back to the default `JsonSerializer` code. In that case the optimized code isn't used when serializing that type but may be used for other types.

### Choose a source generation mode

Choose one or both source generation modes based on the following benefits that each one offers:

| Benefit                                   | Metadata collection | Serialization optimization |
|-------------------------------------------|---------------------|----------------------------|
| Reduces start-up time.                    | ✔️                 | ❌                         |
| Reduces private memory usage.             | ✔️                 | ✔️                         |
| Eliminates run-time reflection.           | ✔️                 | ✔️                         |
| Facilitates trim-safe app size reduction. | ✔️                 | ✔️                         |
| Increases serialization throughput.       | ❌                 | ✔️ \*                      |

The performance improvements can be substantial. For example, [test results](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits) have shown up to 40% or more startup time reduction, private memory reduction, throughput speed increase, and app size reduction.

\* As explained in the [preceding section](#serialization-optimization-mode), the optimized code doesn't support some features. Do performance testing with your options and workloads to determine how much benefit you can actually get from serialization optimization mode. Also, the ability to fall back to `JsonSerializer` code requires metadata collection mode. If you select only serialization optimization mode, serialization might fail for types that need to fall back to `JsonSerializer` code.

## Get the source generation functionality

The source generation functionality for System.Text.Json can be used in any .NET C# project, including class libraries and console, web, and Blazor applications. It can be used with .NET 5.0 SDK or later and with the following target frameworks:

* .NET Core 2.1 and later
* .NET 5 and later
* .NET Framework 4.7.2 and later
* .NET Standard 2.0 and later

For .NET 6 Preview 7 SDK and later, with projects that target .NET 6 or later, there's no need to install the [System.Text.Json NuGet package](https://www.nuget.org/packages/System.Text.Json) because source generation is included in the runtime.

For other target frameworks, install the latest preview version of the package.

> [!NOTE]
> While the source generation feature is still in preview, it's best to install the latest version of the package even when the feature is available in the runtime. The package is updated frequently, not only with each new Preview or RC release. To get the latest version, use [this NuGet feed](https://dev.azure.com/dnceng/public/_packaging?_a=package&feed=dotnet6&package=System.Text.Json&protocolType=NuGet&view=versions).

## Use source generation

To use source generation with all defaults (both modes, default options):

* Create a partial class that derives from <xref:System.Text.Json.Serialization.JsonSerializerContext>.
* Specify the type to serialize or deserialize by applying <xref:System.Text.Json.Serialization.JsonSerializableAttribute> to the context class.
* Pass an instance of the context class to a <xref:System.Text.Json.JsonSerializer> method.

Here's the type that is used in the following examples:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="WF":::

Here's the context class configured to do source generation for the preceding `WeatherForecast` class:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DefineContext":::

Here's code that serializes and deserializes a `WeatherForecast` object:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithContext":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithContext":::

By default, both source generation modes are used if you don't specify one. For information about how to specify the mode to use, see [Specify source generation mode](#specify-source-generation-mode) later in this article.

### `JsonSerializer` methods

Call a <xref:System.Text.Json.JsonSerializer> method that takes a <xref:System.Text.Json.Serialization.JsonSerializerContext> or a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601>. The following examples call methods that serialize:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithContext":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithTypeInfo":::

 The following examples call methods that deserialize:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithContext":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithTypeInfo":::

In the preceding examples, the static `Default` property of the context type provides an instance of the context type with default options. The context instance provides a `WeatherForecast` property that returns a `JsonTypeInfo<WeatherForecast>` instance. You can specify a different name for this property by using the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.TypeInfoPropertyName> property of the `[JsonSerializable]` attribute.

### `JsonTypeInfo<TValue>.Serialize`

The preceding examples call `JsonSerializer` methods. These methods use optimized serialization code for types that use only supported options and attributes. For types that use unsupported options or attributes, these methods fall back to default `JsonSerializer` code. If you know you only need supported options and attributes, you can call the optimized serialization code directly by calling the <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601.Serialize%2A> method of a `JsonTypeInfo<TValue>` instance instead of a `JsonSerializer` method:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeDirect":::

This method provides an advantage for assembly trimming, because `JsonSerializer` can be trimmed if you don't use it.

The <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601.Serialize%2A?displayProperty=nameWithType> method is only available when you select serialization optimization mode or both modes. When you select only metadata collection mode, `Serialize` is null.

### Complete program example

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="All":::

## Specify source generation mode

You can specify metadata collection mode or serialization optimization mode for an entire context, which may include multiple types. Or you can specify the mode for a single type.

* For an entire context, use the [`GenerationMode`](https://github.com/dotnet/runtime/blob/a85d36fed49b8c56d3365417e047fc4306cd74fc/src/libraries/System.Text.Json/Common/JsonSourceGenerationOptionsAttribute.cs#L53-L56) property of `JsonSourceGenerationOptionsAttribute`.
* For an individual type, use the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.GenerationMode> property of <xref:System.Text.Json.Serialization.JsonSerializableAttribute>.

### Serialization optimization mode example

* For an entire context:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="JsonSourceGenerationOptionsGenMode":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="SerializeOnlyContext":::

* For an individual type:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="JsonSerializableGenMode":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="SerializeWFContext":::

* Complete program example

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="All":::

### Metadata collection mode example

* For an entire context:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="JsonSourceGenerationOptionsGenMode":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="SerializeMetadataOnlyContext":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="DeserializeMetadataOnlyContext":::

* For an individual type:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="JsonSerializableGenMode":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="SerializeWFContext":::

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="DeserializeWFContext":::

* Complete program example

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/MetadataOnlyNoOptions.cs" id="All":::

## Specify options for serialization optimization mode

Use [`JsonSourceGenerationOptionsAttribute`](https://github.com/dotnet/runtime/blob/a85d36fed49b8c56d3365417e047fc4306cd74fc/src/libraries/System.Text.Json/Common/JsonSourceGenerationOptionsAttribute.cs) to specify options that are supported by serialization optimization mode. You can use these options without causing a fallback to `JsonSerializer` code. For example, `WriteIndented` and `CamelCase` are supported:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="JsonSourceGenerationOptions":::

When using `JsonSourceGenerationOptionsAttribute` to specify serialization options, call one of the following serialization methods:

* A `JsonSerializer.Serialize` method that takes a context. Pass it the `Default` static property of your context class.

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="SerializeWithContext":::

* A `JsonSerializer.Serialize` method that takes a `TypeInfo<TValue>`. Pass it the `Default.<TypeName>` property of your context class:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="SerializeWithTypeInfo":::

* The <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601.Serialize%2A?displayProperty=nameWithType> method. Use the `TypeInfo<TValue>` instance from the context instance provided by the `Default` static property of your context class:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="SerializeDirect":::

If you call a method that lets you pass in your own instance of `Utf8JsonWriter`, the writer's <xref:System.Text.Json.JsonWriterOptions.Indented> setting is honored instead of the `JsonSourceGenerationOptionsAttribute.WriteIndented` option.

If you create and use a context instance by calling its constructor, a `JsonSerializerOptions` instance will be used instead of the options specified by `JsonSourceGenerationOptionsAttribute`. If you call the parameterless constructor of the context type, a `JsonSerializerOptions` instance with default options is created.

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="All":::

## Specify options by using `JsonSerializerOptions`

Some options of <xref:System.Text.Json.JsonSerializerOptions> aren't supported by serialization optimization mode. Such options cause a fallback to the non-source-generated `JsonSerializer` code. For more information, see [Serialization optimization](#serialization-optimization-mode).

To specify options by using <xref:System.Text.Json.JsonSerializerOptions>:

* Create an instance of `JsonSerializerOptions`.
* Create an instance of your class that derives from <xref:System.Text.Json.Serialization.JsonSerializerContext>, and pass the `JsonSerializerOptions` instance to the constructor.
* Call serialization or deserialization methods of `JsonSerializer` that take a context instance or `TypeInfo<TValue>`.

Here's an example context class followed by serialization and deserialization example code:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/JsonSerializerOptionsExample.cs" id="DefineContext":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/JsonSerializerOptionsExample.cs" id="Serialize":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/JsonSerializerOptionsExample.cs" id="Deserialize":::

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/JsonSerializerOptionsExample.cs" id="All":::

## Source generation support in ASP.NET Core

* In Blazor apps:

  Use overloads of <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A?displayProperty=nameWithType> extension methods that take a source generation context or `TypeInfo<TValue>`.

* In Razor Pages, MVC, SignalR, and Web API apps:

  Use the <xref:System.Text.Json.JsonSerializerOptions.AddContext%2A> method of <xref:System.Text.Json.JsonSerializerOptions>, as shown in the following example:

  ```csharp
  [JsonSerializable(typeof(WeatherForecast[]))]
  internal partial class MyJsonContext : JsonSerializerContext { }
  ```

  ```csharp
  services.AddControllers().AddJsonOptions(options => options.AddContext<MyJsonContext>());
  ```

:::zone-end

## See also

* [Try the new System.Text.Json source generator](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
* [JSON serialization and deserialization in .NET - overview](system-text-json-overview.md)
* [How to use the library](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
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
* [Supported collection types in System.Text.Json](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
