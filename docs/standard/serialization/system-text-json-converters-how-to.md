---
title: "How to write custom converters for JSON serialization - .NET"
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

You can also write custom converters to extend `System.Text.Json` with functionality not included in the current release. The following scenarios are covered later in this article:

* [Deserialize inferred types to Object properties](#deserialize-inferred-types-to-object-properties).
* [Support Dictionary with non-string key](#support-dictionary-with-non-string-key).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).

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

The preceding code is the same as what is shown in the [Support Dictionary with non-string key](#support-dictionary-with-non-string-key) later in this article.

## Steps to follow the basic pattern

The following steps explain how to create a converter by following the basic pattern:

* Create a class that derives from <xref:System.Text.Json.Serialization.JsonConverter%601> where `T` is the type to be serialized and deserialized.
* Override the `Read` method to deserialize the incoming JSON and convert it to type `T`. Use the <xref:System.Text.Json.Utf8JsonReader> that is passed to the method to read the JSON.
* Override the `Write` method to serialize the incoming object of type `T`. Use the <xref:System.Text.Json.Utf8JsonWriter> that is passed to the method to write the JSON.
* Override the `CanConvert` method only if necessary. The default implementation returns `true` when the type to convert is type `T`. Therefore, converters that support only type `T` don't need to override this method. For an example of a converter that does need to override this method, see the [polymorphic deserialization](#support-polymorphic-deserialization) section later in this article.

You can refer to the [built-in converters source code](https://github.com/dotnet/corefx/tree/master/src/System.Text.Json/src/System/Text/Json/Serialization/Converters/) as reference implementations for writing custom converters.

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

## Converter samples for common scenarios

The following sections provide converter samples that address some common scenarios that built-in functionality doesn't handle.

* [Deserialize inferred types to Object properties](#deserialize-inferred-types-to-object-properties)
* [Support Dictionary with non-string key](#support-dictionary-with-non-string-key)
* [Support polymorphic deserialization](#support-polymorphic-deserialization)

### Deserialize inferred types to Object properties

When deserializing to a property of type `Object`, a `JsonElement` object is created. The reason is that the deserializer doesn't know what CLR type to create, and it doesn't try to guess. For example, if a JSON property has "true", the deserializer doesn't infer that the value is a `Boolean`, and if an element has "01/01/2019", the deserializer doesn't infer that it's a `DateTime`.

Type inference can be inaccurate. If the deserializer parses a JSON number that has no decimal point as a `long`, that might result in out-of-range issues if the value was originally serialized as a `ulong` or `BigInteger`. Parsing a number that has a decimal point as a `double` might lose precision if the number was originally serialized as a `decimal`.

For scenarios that require type inference, the following code shows a custom converter for `Object` properties. The code converts:

* `true` and `false` to `Boolean`
* Numbers to `long` or `double`
* Dates to `DateTime`
* Strings to `string`
* Everything else to `JsonElement`

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/ObjectToInferredTypesConverter.cs)]

The following code registers the converter:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/ConvertInferredTypesToObject.cs?name=SnippetRegister)]

Here's an example type with `Object` properties:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/WeatherForecast.cs?name=SnippetWFWithObjectProperties)]

The following example of JSON to deserialize contains values that will be deserialized as `DateTime`, `long`, and `string`:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
}
```

Without the custom converter, deserialization puts a `JsonElement` in each property.

The [unit tests folder](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle deserialization to Object properties.

### Support Dictionary with non-string key

The built-in support for dictionary collections is for `Dictionary<string, TValue>`. That is, the key must be a string. To support a dictionary with an integer or some other type as the key, a custom converter is required.

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/DictionaryTKeyEnumTValueConverter.cs)]

The following code registers the converter:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/ConvertDictionaryTkeyEnumTValue.cs?name=SnippetRegister)]

The converter can serialize and deserialize the `TemperatureRanges` property of the following class that uses the following `Enum`:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/WeatherForecast.cs?name=SnippetWFWithEnumDictionary)]

The JSON output from serialization looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "TemperatureRanges": {
    "Cold": 20,
    "Hot": 40
  }
}
```

The [unit tests folder](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle non-string-key dictionaries.

### Support polymorphic deserialization

[Polymorphic serialization](system-text-json-how-to.md#serialize-properties-of-derived-classes) doesn't require a custom converter, but deserialization does require a custom converter.

Suppose, for example, you have a `Person` abstract base class, with `Employee` and `Customer` derived classes. Polymorphic deserialization means that at design time you can specify `Person` as the deserialization target, and `Customer` and `Employee` objects in the JSON are correctly deserialized at runtime. During deserialization, you have to find clues that identify the required type in the JSON. The kinds of clues available vary with each scenario. For example, a discriminator property might be available or you might have to rely on the presence or absence of a particular property. The current release of `System.Text.Json` doesn't provide attributes to specify how to handle polymorphic deserialization scenarios, so custom converters are required.

The following code shows a base class, two derived classes, and a custom converter for them. The converter uses a discriminator property to do polymorphic deserialization. The type discriminator isn't in the class definitions but is created during serialization and is read during deserialization.

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/Person.cs?name=SnippetPerson)]

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/PersonConverterWithTypeDiscriminator.cs)]

The following code registers the converter:

[!code-csharp[](~/samples/snippets/core/system-text-json/csharp/ConvertPolymorphic.cs?name=SnippetRegister)]

The converter can deserialize JSON that was created by using the same converter to serialize, for example:

```json
[
  {
    "TypeDiscriminator": 1,
    "CreditLimit": 10000,
    "Name": "John"
  },
  {
    "TypeDiscriminator": 2,
    "OfficeNumber": "555-1234",
    "Name": "Nancy"
  }
]
```

## Other custom converter samples

The [unit tests folder](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` source code includes other custom converter samples, such as:

* `Int32` converter that converts null to 0 on deserialize
* `Int32` converter that allows both string and number values on deserialize
* `Enum` converter
* `List<T>` converter that accepts external data
* `Long[]` converter that works with a comma-delimited list of numbers 

## Additional resources

* [System.Text.Json overview](system-text-json-overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [How to use System.Text.Json](system-text-json-how-to.md)
* [Source code for built-in converters](https://github.com/dotnet/corefx/tree/master/src/System.Text.Json/src/System/Text/Json/Serialization/Converters/)
* GitHub issues related to custom converters for `System.Text.Json`
  * [36639 Introducing custom converters](https://github.com/dotnet/corefx/issues/36639)
  * [38713 About deserializing to Object](https://github.com/dotnet/corefx/issues/38713)
  * [40120 About non-string-key dictionaries](https://github.com/dotnet/corefx/issues/40120)
  * [37787 About polymorphic deserialization](https://github.com/dotnet/corefx/issues/37787)
