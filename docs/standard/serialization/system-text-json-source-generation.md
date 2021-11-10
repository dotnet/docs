---
title: How to use source generation in System.Text.Json
description: "Learn how to use source generation in System.Text.Json."
ms.date: 10/13/2021
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

This article shows how to use the source generation features of [System.Text.Json](system-text-json-overview.md).
:::zone-end

:::zone pivot="dotnet-5-0,dotnet-core-3-1"
For information about how to use source generation in System.Text.Json, see [the .NET 6 version of this article](system-text-json-source-generation.md?pivots=dotnet-6-0).
:::zone-end

:::zone pivot="dotnet-6-0"

## Use source generation defaults

To use source generation with all defaults (both modes, default options):

* Create a partial class that derives from <xref:System.Text.Json.Serialization.JsonSerializerContext>.
* Specify the type to serialize or deserialize by applying <xref:System.Text.Json.Serialization.JsonSerializableAttribute> to the context class.
* Call a <xref:System.Text.Json.JsonSerializer> method that takes a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601> instance. An alternative is to call a <xref:System.Text.Json.JsonSerializer> method that takes a <xref:System.Text.Json.Serialization.JsonSerializerContext> instance.

By default, both source generation modes are used if you don't specify one. For information about how to specify the mode to use, see [Specify source generation mode](#specify-source-generation-mode) later in this article.

Here's the type that is used in the following examples:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="WF":::

Here's the context class configured to do source generation for the preceding `WeatherForecast` class:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DefineContext":::

### `JsonSerializer` methods that use source generation

The following examples call methods that serialize:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithTypeInfo":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithContext":::

The following examples call methods that deserialize:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithTypeInfo":::

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithContext":::

In the preceding examples, the static `Default` property of the context type provides an instance of the context type with default options. The context instance provides a `WeatherForecast` property that returns a `JsonTypeInfo<WeatherForecast>` instance. You can specify a different name for this property by using the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.TypeInfoPropertyName> property of the `[JsonSerializable]` attribute.

### Complete program example

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="All":::

## Specify source generation mode

You can specify metadata collection mode or serialization optimization mode for an entire context, which may include multiple types. Or you can specify the mode for an individual type. If you do both, the mode specification for a type wins.

* For an entire context, use the [`GenerationMode`](https://github.com/dotnet/runtime/blob/a85d36fed49b8c56d3365417e047fc4306cd74fc/src/libraries/System.Text.Json/Common/JsonSourceGenerationOptionsAttribute.cs#L53-L56) property of `JsonSourceGenerationOptionsAttribute`.
* For an individual type, use the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.GenerationMode> property of <xref:System.Text.Json.Serialization.JsonSerializableAttribute>.

### Serialization optimization mode example

* For an entire context:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="JsonSourceGenerationOptionsGenMode":::

* For an individual type:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyNoOptions.cs" id="JsonSerializableGenMode":::

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

* A `JsonSerializer.Serialize` method that takes a `TypeInfo<TValue>`. Pass it the `Default.<TypeName>` property of your context class:

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="SerializeWithTypeInfo":::

* A `JsonSerializer.Serialize` method that takes a context. Pass it the `Default` static property of your context class.

  :::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="SerializeWithContext":::

If you call a method that lets you pass in your own instance of `Utf8JsonWriter`, the writer's <xref:System.Text.Json.JsonWriterOptions.Indented> setting is honored instead of the `JsonSourceGenerationOptionsAttribute.WriteIndented` option.

If you create and use a context instance by calling the constructor that takes a `JsonSerializerOptions` instance, the supplied instance will be used instead of the options specified by `JsonSourceGenerationOptionsAttribute`.

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/SerializeOnlyWithOptions.cs" id="All":::

## Specify options by using `JsonSerializerOptions`

Some options of <xref:System.Text.Json.JsonSerializerOptions> aren't supported by serialization optimization mode. Such options cause a fallback to the non-source-generated `JsonSerializer` code. For more information, see [Serialization optimization](system-text-json-source-generation-modes.md#serialization-optimization-mode).

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
  services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.AddContext<MyJsonContext>());
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
