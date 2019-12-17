---
title: "How to write custom converters for JSON serialization - .NET"
author: tdykstra
ms.author: tdykstra
ms.date: "10/16/2019"
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
  - "converters"
---

# How to write custom converters for JSON serialization in .NET

This article shows how to create custom converters for the JSON serialization classes that are provided in the <xref:System.Text.Json> namespace. For an introduction to `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](system-text-json-how-to.md).

A *converter* is a class that converts an object or a value to and from JSON. The `System.Text.Json` namespace has built-in converters for most primitive types that map to JavaScript primitives. You can write custom converters:

* To override the default behavior of a built-in converter. For example, you might want `DateTime` values to be represented by mm/dd/yyyy format instead of the default  ISO 8601-1:2019 format.
* To support a custom value type. For example, a `PhoneNumber` struct.

You can also write custom converters to extend `System.Text.Json` with functionality not included in the current release. For more information, see [How to migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md).

## Custom converter patterns

There are two patterns for creating a custom converter: the basic pattern and the factory pattern. The factory pattern is for converters that handle type `Enum` or open generics. The basic pattern is for non-generic and closed generic types.  For example, converters for the following types require the factory pattern:

* `Dictionary<TKey, TValue>`
* `Enum`
* `List<T>`

Some examples of types that can be handled by the basic pattern include:

* `Dictionary<int, string>`
* `WeekdaysEnum`
* `List<DateTimeOffset>`
* `DateTime`
* `Int32`

The basic pattern creates a class that can handle one type. The factory pattern creates a class that determines at runtime which specific type is required and dynamically creates the appropriate converter.

## Sample basic converter

The following sample is a converter that overrides default serialization for an existing data type. The converter uses mm/dd/yyyy format for `DateTimeOffset` properties.

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/DateTimeOffsetConverter.cs)]

## Sample factory pattern converter

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`. The code follows the factory pattern because the first generic type parameter is `Enum` and the second is open. The `CanConvert` method returns `true` only for a `Dictionary` with two generic parameters, the first of which is an `Enum` type. The inner converter gets an existing converter to handle whichever type is provided at runtime for `TValue`. 

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/DictionaryTKeyEnumTValueConverter.cs)]

## Steps to follow the basic pattern

The following steps explain how to create a converter by following the basic pattern:

* Create a class that derives from <xref:System.Text.Json.Serialization.JsonConverter%601> where `T` is the type to be serialized and deserialized.
* Override the `Read` method to deserialize the incoming JSON and convert it to type `T`. Use the <xref:System.Text.Json.Utf8JsonReader> that is passed to the method to read the JSON.
* Override the `Write` method to serialize the incoming object of type `T`. Use the <xref:System.Text.Json.Utf8JsonWriter> that is passed to the method to write the JSON.
* Override the `CanConvert` method only if necessary. The default implementation returns `true` when the type to convert is type `T`. Therefore, converters that support only type `T` don't need to override this method. For an example of a converter that does need to override this method, see [Polymorphic deserialization](system-text-json-migrate-from-newtonsoft-how-to.md#polymorphic-deserialization).

You can refer to the [built-in converters source code](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/) as reference implementations for writing custom converters.

## Steps to follow the factory pattern

The following steps explain how to create a converter by following the factory pattern:

* Create a class that derives from <xref:System.Text.Json.Serialization.JsonConverterFactory>.
* Override the `CanConvert` method to return true when the type to convert is one that the converter can handle. For example, if the converter is for `List<T>` it might only handle `List<int>`, `List<string>`, and `List<DateTime>`. 
* Override the `CreateConverter` method to return an instance of a converter class that will handle the type-to-convert that is provided at runtime.
* Create the converter class that the `CreateConverter` method instantiates. 

The factory pattern is required for open generics because the code to convert an object to and from a string isn't the same for all types. A converter for an open generic type (`List<T>`, for example) has to create a converter for a closed generic type (`List<DateTime>`, for example) behind the scenes. Code must be written to handle each closed-generic type that the converter can handle.

The `Enum` type is similar to an open generic type: a converter for `Enum` has to create a converter for a specific `Enum` (`WeekdaysEnum`, for example) behind the scenes. 

## Error handling

If you need to throw an exception in error-handling code, consider throwing a <xref:System.Text.Json.JsonException> without a message. This exception type automatically creates a message that includes the path to the part of the JSON that caused the error. For example, the statement `throw new JsonException();` produces an error message like the following example:

```
Unhandled exception. System.Text.Json.JsonException: 
The JSON value could not be converted to System.Object. 
Path: $.Date | LineNumber: 1 | BytePositionInLine: 37.
```

If you do provide a message (for example, `throw new JsonException("Error occurred")`, the exception still provides the path in the <xref:System.Text.Json.JsonException.Path> property.

## Register a custom converter

*Register* a custom converter to make the `Serialize` and `Deserialize` methods use it. Choose one of the following approaches:

* Add an instance of the converter class to the <xref:System.Text.Json.JsonSerializerOptions.Converters?displayProperty=nameWithType> collection.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to the properties that require the custom converter.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to a class or a struct that represents a custom value type.

## Registration sample - Converters collection 

Here's an example that makes the <xref:System.ComponentModel.DateTimeOffsetConverter> the default for properties of type <xref:System.DateTimeOffset>:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/RegisterConverterWithConvertersCollection.cs?name=SnippetSerialize)]

Suppose you serialize an instance of the following type:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/WeatherForecast.cs?name=SnippetWF)]

Here's an example of JSON output that shows the custom converter was used:

```json
{
  "Date": "08/01/2019",
  "TemperatureCelsius": 25,
  "Summary": "Hot"
}
```

The following code uses the same approach to deserialize using the custom `DateTimeOffset` converter:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/RegisterConverterWithConvertersCollection.cs?name=SnippetDeserialize)]

## Registration sample - [JsonConverter] on a property

The following code selects a custom converter for the `Date` property:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/WeatherForecast.cs?name=SnippetWFWithConverterAttribute)]

The code to serialize `WeatherForecastWithConverterAttribute` doesn't require the use of `JsonSerializeOptions.Converters`:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/RegisterConverterWithAttributeOnProperty.cs?name=SnippetSerialize)]

The code to deserialize also doesn't require the use of `Converters`:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/RegisterConverterWithAttributeOnProperty.cs?name=SnippetDeserialize)]

## Registration sample - [JsonConverter] on a type

Here's code that creates a struct and applies the `[JsonConverter]` attribute to it:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/Temperature.cs)]

Here's the custom converter for the preceding struct:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/TemperatureConverter.cs)]

The `[JsonConvert]` attribute on the struct registers the custom converter as the default for properties of type `Temperature`. The converter is automatically used on the `TemperatureCelsius` property of the following type when you serialize or deserialize it:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/WeatherForecast.cs?name=SnippetWFWithTemperatureStruct)]

## Converter registration precedence

During serialization or deserialization, a converter is chosen for each JSON element in the following order, listed from highest priority to lowest:

* `[JsonConverter]` applied to a property.
* A converter added to the `Converters` collection.
* `[JsonConverter]` applied to a custom value type or POCO.

If multiple custom converters for a type are registered in the `Converters` collection, the first converter that returns true for `CanConvert` is used.

A built-in converter is chosen only if no applicable custom converter is registered.

## Other custom converter samples

The [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md) article contains samples of custom converters.

The [unit tests folder](https://github.com/dotnet/runtime/blob/master/src/libraries/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` source code includes other custom converter samples, such as:

* `Int32` converter that converts null to 0 on deserialize
* `Int32` converter that allows both string and number values on deserialize
* `Enum` converter
* `List<T>` converter that accepts external data
* `Long[]` converter that works with a comma-delimited list of numbers 

If you need to make a converter that modifies the behavior of an existing built-in converter, you can get [the source code of the existing converter](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters) to serve as a starting point for customization.

## Additional resources

* [System.Text.Json overview](system-text-json-overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [How to use System.Text.Json](system-text-json-how-to.md)
* [Source code for built-in converters](https://github.com/dotnet/runtime/tree/master/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/)
* [GitHub issue related to custom converters](https://github.com/dotnet/corefx/issues/36639)
