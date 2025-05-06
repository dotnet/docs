---
title: How to customize property names and values with System.Text.Json
description: "Learn how to customize property names and values when serializing with System.Text.Json in .NET."
ms.date: 05/06/2025
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
ms.custom: copilot-scenario-highlight
---

# How to customize property names and values with System.Text.Json

By default, property names and dictionary keys are unchanged in the JSON output, including case. Enum values are represented as numbers. And properties are serialized in the order they're defined. However, you can customize these behaviors by:

- Specifying specific serialized property and enum member names.
- Using a built-in [naming policy](xref:System.Text.Json.JsonNamingPolicy), such as camelCase, snake_case, or kebab-case, for property names and dictionary keys.
- Using a custom naming policy for property names and dictionary keys.
- Serializing enum values as strings, with or without a naming policy.
- Configuring the order of serialized properties.

> [!NOTE]
> The [web default](configure-options.md#web-defaults-for-jsonserializeroptions) naming policy is camel case.

> [!TIP]
> You can use AI assistance to [create an object with custom serialization properties with GitHub Copilot](#use-github-copilot-to-customize-how-property-names-are-serialized).

For other scenarios that require special handling of JSON property names and values, you can [implement custom converters](converters-how-to.md).

## Customize individual property names

To set the name of individual properties, use the [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) attribute.

Here's an example type to serialize and resulting JSON:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "Wind": 35
}
```

The property name set by this attribute:

- Applies in both directions, for serialization and deserialization.
- Takes precedence over property naming policies.
- [Doesn't affect parameter name matching for parameterized constructors](immutability.md#parameterized-constructors).

## Use a built-in naming policy

The following table shows the built-in naming policies and how they affect property names.

| Naming policy                                             | Description | Original property name | Converted property name |
|-----------------------------------------------------------|-|-----------------------|-------------------------|
| <xref:System.Text.Json.JsonNamingPolicy.CamelCase>        | First word starts with a lower case character.<br/>Successive words start with an uppercase character. | `TempCelsius`          | `tempCelsius`           |
| <xref:System.Text.Json.JsonNamingPolicy.KebabCaseLower>\* | Words are separated by hyphens.<br/>All characters are lowercase. | `TempCelsius`          | `temp-celsius`          |
| <xref:System.Text.Json.JsonNamingPolicy.KebabCaseUpper>\* | Words are separated by hyphens.<br/>All characters are uppercase. | `TempCelsius`          | `TEMP-CELSIUS`          |
| <xref:System.Text.Json.JsonNamingPolicy.SnakeCaseLower>\* | Words are separated by underscores.<br/>All characters are lowercase. | `TempCelsius`          | `temp_celsius`          |
| <xref:System.Text.Json.JsonNamingPolicy.SnakeCaseUpper>\* | Words are separated by underscores.<br/>All characters are uppercase. |`TempCelsius`          | `TEMP_CELSIUS`          |

\* Available in .NET 8 and later versions.

The following example shows how to use camel case for all JSON property names by setting <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=nameWithType> to <xref:System.Text.Json.JsonNamingPolicy.CamelCase?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/how-to/csharp/RoundTripCamelCasePropertyNames.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/RoundTripCamelCasePropertyNames.vb" id="Serialize":::

Here's an example class to serialize and JSON output:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureCelsius": 25,
  "summary": "Hot",
  "Wind": 35
}
```

The naming policy:

- Applies to serialization and deserialization.
- Is overridden by `[JsonPropertyName]` attributes. This is why the JSON property name `Wind` in the example is not camel case.

> [!NOTE]
> None of the built-in naming policies support letters that are surrogate pairs. For more information, see [dotnet/runtime issue 90352](https://github.com/dotnet/runtime/issues/90352).

## Use a custom JSON property naming policy

To use a custom JSON property naming policy, create a class that derives from <xref:System.Text.Json.JsonNamingPolicy> and override the <xref:System.Text.Json.JsonNamingPolicy.ConvertName%2A> method, as shown in the following example:

:::code language="csharp" source="snippets/how-to/csharp/UpperCaseNamingPolicy.cs":::
:::code language="vb" source="snippets/how-to/vb/UpperCaseNamingPolicy.vb":::

Then set the <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=nameWithType> property to an instance of your naming policy class:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripPropertyNamingPolicy.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/RoundtripPropertyNamingPolicy.vb" id="Serialize":::

Here's an example class to serialize and JSON output:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "DATE": "2019-08-01T00:00:00-07:00",
  "TEMPERATURECELSIUS": 25,
  "SUMMARY": "Hot",
  "Wind": 35
}
```

The JSON property naming policy:

- Applies to serialization and deserialization.
- Is overridden by `[JsonPropertyName]` attributes. This is why the JSON property name `Wind` in the example is not upper case.

## Use a naming policy for dictionary keys

If a property of an object to be serialized is of type `Dictionary<string,TValue>`, the `string` keys can be converted using a naming policy, such as camel case. To do that, set <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy?displayProperty=nameWithType> to your desired naming policy. The following example uses the `CamelCase` naming policy:

:::code language="csharp" source="snippets/how-to/csharp/SerializeCamelCaseDictionaryKeys.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/SerializeCamelCaseDictionaryKeys.vb" id="Serialize":::

Serializing an object with a dictionary named `TemperatureRanges` that has key-value pairs `"ColdMinTemp", 20` and `"HotMinTemp", 40` would result in JSON output like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "TemperatureRanges": {
    "coldMinTemp": 20,
    "hotMinTemp": 40
  }
}
```

Naming policies for dictionary keys apply to serialization only. If you deserialize a dictionary, the keys will match the JSON file even if you set <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy?displayProperty=nameWithType> to a non-default naming policy.

## Enums as strings

By default, enums are serialized as numbers. To serialize enum names as strings, use the <xref:System.Text.Json.Serialization.JsonStringEnumConverter> or <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> converter. Only <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> is supported by the Native AOT runtime.

For example, suppose you need to serialize the following class that has an enum:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithEnum":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithEnum":::

If the Summary is `Hot`, by default the serialized JSON has the numeric value 3:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": 3
}
```

The following sample code serializes the enum names instead of the numeric values, and converts the names to camel case:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumAsString.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/RoundtripEnumAsString.vb" id="Serialize":::

The resulting JSON looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "hot"
}
```

The built-in <xref:System.Text.Json.Serialization.JsonStringEnumConverter> can deserialize string values as well. It works with or without a specified naming policy. The following example shows deserialization using `CamelCase`:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumAsString.cs" id="Deserialize":::
:::code language="vb" source="snippets/how-to/vb/RoundtripEnumAsString.vb" id="Deserialize":::

### JsonConverterAttribute

You can also specify the converter to use by annotating your enum with <xref:System.Text.Json.Serialization.JsonConverterAttribute>. The following example shows how to specify the <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> (available in .NET 8 and later versions) by using the <xref:System.Text.Json.Serialization.JsonConverterAttribute> attribute. For example, suppose you need to serialize the following class that has an enum:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithConverterEnum":::

The following sample code serializes the enum names instead of the numeric values:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumUsingConverterAttribute.cs" id="Serialize":::

The resulting JSON looks like this:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Precipitation": "Sleet"
}
```

### Custom enum member names

Starting in .NET 9, you can customize the names of individual enum members for types that are serialized as strings. To customize an enum member name, annotate it with the [JsonStringEnumMemberName attribute](xref:System.Text.Json.Serialization.JsonStringEnumMemberNameAttribute).

For example, suppose you need to serialize the following class that has an enum with a custom member name:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithEnumCustomName":::

The following sample code serializes the enum names instead of the numeric values:

:::code language="csharp" source="snippets/how-to/csharp/SerializeEnumCustomName.cs" id="Serialize":::

The resulting JSON looks like this:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Sky": "Partly cloudy"
}
```

### Source generation

To use the converter with source generation, see [Serialize enum fields as strings](source-generation.md#serialize-enum-fields-as-strings).

## Configure the order of serialized properties

By default, properties are serialized in the order in which they're defined in their class. The [`[JsonPropertyOrder]`](xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute) attribute lets you specify the order of properties in the JSON output from serialization. The default value of the `Order` property is zero. Set `Order` to a positive number to position a property after those that have the default value. A negative `Order` positions a property before those that have the default value. Properties are written in order from the lowest `Order` value to the highest. Here's an example:

:::code language="csharp" source="snippets/how-to-6-0/csharp/PropertyOrder.cs":::

##  Use GitHub Copilot to customize how property names are serialized

You can use GitHub Copilot with `System.Text.Json` attributes to apply patterns of changes to how your code serializes without having to explicitly specify the change in each one.

Suppose your class declaration has properties that follow `PascalCasing`, and the JSON standard for your project is `snake_casing`. You can use AI to add the necessary `JsonPropertyName` attributes to every property in your class. You can use Copilot to make these changes with a chat prompt like this:

```copilot-prompt
Update #ClassName:
when the property name contains more than one word,
change the serialized property name to use underscores between words.
Use built-in serialization attributes.
```

Here's a more complete version of the example that includes a simple class.

```copilot-prompt 
Take this C# class: 
public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
    public string? Summary { get; set; }
    public int WindSpeed { get; set; }
}
When the property name contains more than one word,
change the serialized property name to use underscores between words.
Use built-in serialization attributes.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).

## See also

- [System.Text.Json overview](overview.md)
- [How to serialize and deserialize JSON](how-to.md)
