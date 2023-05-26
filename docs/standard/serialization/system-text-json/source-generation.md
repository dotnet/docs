---
title: How to use source generation in System.Text.Json
description: "Learn how to use source generation in System.Text.Json."
ms.date: 10/21/2022
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

# How to use source generation in System.Text.Json

Source generation in System.Text.Json is available in .NET 6 and later versions. Source generation consists of two modes: *metadata collection* and *serialization optimization*.

## Use source generation defaults

To use source generation with all defaults (both modes, default options):

1. Create a partial class that derives from <xref:System.Text.Json.Serialization.JsonSerializerContext>.
1. Specify the type to serialize or deserialize by applying <xref:System.Text.Json.Serialization.JsonSerializableAttribute> to the context class.
1. Call a <xref:System.Text.Json.JsonSerializer> method that either:

   - Takes a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601> instance, or
   - Takes a <xref:System.Text.Json.Serialization.JsonSerializerContext> instance, or
   - Takes a <xref:System.Text.Json.JsonSerializerOptions> instance and you've set its <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver?displayProperty=nameWithType> property to the `Default` property of the context type (.NET 7 and later only).

By default, both source generation modes are used if you don't specify one. For information about how to specify the mode to use, see [Specify source generation mode](#specify-source-generation-mode) later in this article.

Here's the type that is used in the following examples:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="WF":::

Here's the context class configured to do source generation for the preceding `WeatherForecast` class:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DefineContext":::

The types of `WeatherForecast` members don't need to be explicitly specified with `[JsonSerializable]` attributes. Members declared as `object` are an exception to this rule. The runtime type for a member declared as `object` needs to be specified. For example, suppose you have the following class:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/ObjectProperties.cs" id="WF":::

And you know that at runtime it may have `boolean` and `int` objects:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/ObjectProperties.cs" id="WFInit":::

Then `boolean` and `int` have to be declared as `[JsonSerializable]`:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/ObjectProperties.cs" id="JsonSerializable":::

To specify source generation for a collection, use `[JsonSerializable]` with the collection type. For example: `[JsonSerializable(typeof(List<WeatherForecast>))]`.

### `JsonSerializer` methods that use source generation

In the following examples, the static `Default` property of the context type provides an instance of the context type with default options. The context instance provides a `WeatherForecast` property that returns a `JsonTypeInfo<WeatherForecast>` instance. You can specify a different name for this property by using the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.TypeInfoPropertyName> property of the `[JsonSerializable]` attribute.

#### Serialization examples

Using <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithTypeInfo":::

Using <xref:System.Text.Json.Serialization.JsonSerializerContext>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithContext":::

Using <xref:System.Text.Json.JsonSerializerOptions>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="SerializeWithOptions":::

#### Deserialization examples

Using <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithTypeInfo":::

Using <xref:System.Text.Json.Serialization.JsonSerializerContext>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithContext":::

Using <xref:System.Text.Json.JsonSerializerOptions>:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="DeserializeWithOptions":::

### Complete program example

Here are the preceding examples in a complete program:

:::code language="csharp" source="snippets/system-text-json-source-generation/csharp/BothModesNoOptions.cs" id="All":::

## Specify source generation mode

You can specify metadata collection mode or serialization optimization mode for an entire context, which may include multiple types. Or you can specify the mode for an individual type. If you do both, the mode specification for a type wins.

* For an entire context, use the <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.GenerationMode?displayProperty=nameWithType> property.
* For an individual type, use the <xref:System.Text.Json.Serialization.JsonSerializableAttribute.GenerationMode?displayProperty=nameWithType> property.

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

Use <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute> to specify options that are supported by serialization optimization mode. You can use these options without causing a fallback to `JsonSerializer` code. For example, `WriteIndented` and `CamelCase` are supported:

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

Some options of <xref:System.Text.Json.JsonSerializerOptions> aren't supported by serialization optimization mode. Such options cause a fallback to the non-source-generated `JsonSerializer` code. For more information, see [Serialization optimization](source-generation-modes.md#serialization-optimization-mode).

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

## See also

* [Try the new System.Text.Json source generator](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
* [JSON serialization and deserialization in .NET - overview](overview.md)
* [How to use the library](how-to.md)
