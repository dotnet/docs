---
title: How to customize property names and values with System.Text.Json
description: "Learn how to customize property names and values when serializing with System.Text.Json in .NET."
ms.date: 10/16/2023
zone_pivot_groups: dotnet-version
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
ms.collection: ce-skilling-ai-copilot
ms.custom: vs-copilot-horizontal
---

# How to customize property names and values with System.Text.Json

By default, property names and dictionary keys are unchanged in the JSON output, including case. Enum values are represented as numbers. And properties are serialized in the order they're defined. However, you can customize these behaviors by:

- Specifying specific serialized property names.
- Using a built-in [naming policy](xref:System.Text.Json.JsonNamingPolicy), such as camelCase, snake_case, or kebab-case, for property names and dictionary keys.
- Using a custom naming policy for property names and dictionary keys.
- Serializing enum values as strings, with or without a naming policy.
- Configuring the order of serialized properties.

> [!NOTE]
> The [web default](configure-options.md#web-defaults-for-jsonserializeroptions) naming policy is camel case.

> [!TIP]
> You can use AI assistance to [customize property names and values with GitHub Copilot](#use-github-copilot-to-customize-property-names-and-order).

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

:::zone pivot="dotnet-8-0"

By default, enums are serialized as numbers. To serialize enum names as strings, use the <xref:System.Text.Json.Serialization.JsonStringEnumConverter> or <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> converter. Only <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> is supported by the Native AOT runtime.

:::zone-end

:::zone pivot="dotnet-7-0,dotnet-6-0"

By default, enums are serialized as numbers. To serialize enum names as strings, use the <xref:System.Text.Json.Serialization.JsonStringEnumConverter> converter.

:::zone-end

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

:::zone pivot="dotnet-8-0"

You can also specify the converter to use by annotating your enum with <xref:System.Text.Json.Serialization.JsonConverterAttribute>. The following example shows how to specify the <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> (available in .NET 8 and later versions) by using the <xref:System.Text.Json.Serialization.JsonConverterAttribute> attribute. For example, suppose you need to serialize the following class that has an enum:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithConverterEnum":::

The following sample code serializes the enum names instead of the numeric values:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumUsingConverterAttribute.cs" id="Serialize":::

The resulting JSON looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Precipitation": "Sleet"
}
```

To use the converter with source generation, see [Serialize enum fields as strings](source-generation.md#serialize-enum-fields-as-strings).

:::zone-end

## Configure the order of serialized properties

By default, properties are serialized in the order in which they're defined in their class. The [`[JsonPropertyOrder]`](xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute) attribute lets you specify the order of properties in the JSON output from serialization. The default value of the `Order` property is zero. Set `Order` to a positive number to position a property after those that have the default value. A negative `Order` positions a property before those that have the default value. Properties are written in order from the lowest `Order` value to the highest. Here's an example:

:::code language="csharp" source="snippets/how-to-6-0/csharp/PropertyOrder.cs":::

## Use Github Copilot to customize property names and order 

You can use GitHub Copilot in your IDE to generate code to customzie names and order of serialized properties.

If you're using [Visual Studio 2022 version 17.8 or later](/visualstudio/releases/2022/release-notes), you can try the AI-driven [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) to generate code that uses `System.Text.Json` to customize property names and order in the JSON output from serializtion. Submit your question as a prompt in the Copilot chat window, as in the following example. You can also submit prompts using [inline chat](/visualstudio/ide/visual-studio-github-copilot-chat#ask-questions-in-the-inline-chat-view) in the editor window itself.

> [!NOTE]
> GitHub Copilot is powered by AI, so surprises and mistakes are possible. Make sure to verify any generated code or suggestions. For more information about the general use of GitHub Copilot, product impact, human oversight, and privacy, see [GitHub Copilot FAQs](https://github.com/features/copilot#faq).

The following example shows you how to use Copilot to modify exisitng code to customize property names and order when serializing to JSON.

1. Add the following C# example code to a code file `Example.cs` in your editor.
   In Visual Studio, you can use a C# console application project to try this example.
   
    ```csharp
        using System.Text.Json;

        //Create an instance of the `Person` class and initialize its properties with values.
        public class Person
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public int Age { get; set; }
            public string? Country { get; set; }
        }
        
        public class Program
        {
            public static void Main()
            {
                var person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30,
                    Country = "USA"
                };

                //Serialize the `person` object to a JSON string using `System.Text.Json`
                string jsonString = JsonSerializer.Serialize(person);

                //Print the JSON string to the console
                Console.WriteLine(jsonString);
            }
        }
    ```

    `Example.cs` code does the following:
    - Creates an instance of the `Person` class and initializes its properties with values.
    - Serializes the `person` object to a JSON string using `JsonSerializer.Serialize`.
    - Prints the following JSON string to the console:
      ```json
      {"FirstName":"John","LastName":"Doe","Age":30,"Country":"USA"}
      ```
1. In Copilot Chat, enter the following prompt to modify the code to customize names and order of the JSON serialization output.

> #Example.cs modify code to use System.Text.Json to customize property names and order of JSON output from serializtion. Set property names FirstName to first_name, LastName to last_name. Set order to: Country, FirstName, LastName, Age. Provide customized serialization output.

You can customize the prompt to output a JSON string with property names and values that suit your requirements.

You can use chat features, such as [slash commands, references to files, methods, or classes, and threads](/visualstudio/ide/copilot-chat-context), to set intent and get better answers with scoped context. For an existing class in a project that's open in the IDE, you can prompt GitHub Copilot with `/generate code to serialize #Classname in #Filename to JSON`.

The following output shows an example Copilot Chat response:

```output
To customize the property names and order of the JSON output using System.Text.Json, you can use the JsonPropertyName attribute to rename properties and the JsonPropertyOrder attribute to set the order. Here's how you can modify your code:

using System.Text.Json;
using System.Text.Json.Serialization;

public class Person
{
    [JsonPropertyName("first_name")]
    [JsonPropertyOrder(2)]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [JsonPropertyOrder(3)]
    public string? LastName { get; set; }

    [JsonPropertyOrder(4)]
    public int Age { get; set; }

    [JsonPropertyOrder(1)]
    public string? Country { get; set; }
}

public class Program
{
    public static void Main()
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Country = "USA"
        };

        string jsonString = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonString);
    }
}

**Explanation:**
1.	Renaming Properties: The JsonPropertyName attribute is used to rename FirstName to first_name and LastName to last_name.
2.	Ordering Properties: The JsonPropertyOrder attribute is used to set the order of the properties in the JSON output. The order is set as:
    •	Country (Order 1)
    •	FirstName (Order 2)
    •	LastName (Order 3)
    •	Age (Order 4)
3.	Indented JSON: The JsonSerializerOptions with WriteIndented = true is used to make the JSON output more readable.

**Customized Serialization Output:**
{
  "Country": "USA",
  "first_name": "John",
  "last_name": "Doe",
  "Age": 30
}

This ensures that the JSON output has the customized property names and the specified order.
```

When Copilot returns a code block, the response includes options to copy the code, insert the code into a new file, or preview the code output.

> [!NOTE]
> Your results might be different from what's shown in the example responses. AI models are non-deterministic, which means that they can return different responses when asked the same question. This might be due to additional learning and adaption over time, language variation, changes in context, such as your chat history, and more.
:::image type="content" source="./media/deserialize-json-using-github-copilot.gif" alt-text="Animated screenshot that shows using GitHub Copilot Chat in Visual Studio to deserialize a JSON string to a .NET object." lightbox="./media/deserialize-json-using-github-copilot.gif":::

## See also

- [System.Text.Json overview](overview.md)
- [How to serialize and deserialize JSON](how-to.md)
- [GitHub Copilot Trust Center](https://resources.github.com/copilot-trust-center/)
- [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states)
- [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview)
