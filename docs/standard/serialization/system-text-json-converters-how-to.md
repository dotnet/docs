---
title: "How to write custom converters for JSON serialization - .NET"
description: "Learn how to create custom converters for the JSON serialization classes that are provided in the System.Text.Json namespace."
ms.date: 12/04/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
  - "converters"
ms.topic: how-to
---

# How to write custom converters for JSON serialization (marshalling) in .NET

This article shows how to create custom converters for the JSON serialization classes that are provided in the <xref:System.Text.Json> namespace. For an introduction to `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](system-text-json-how-to.md).

A *converter* is a class that converts an object or a value to and from JSON. The `System.Text.Json` namespace has built-in converters for most primitive types that map to JavaScript primitives. You can write custom converters:

* To override the default behavior of a built-in converter. For example, you might want `DateTime` values to be represented by mm/dd/yyyy format. By default, ISO 8601-1:2019 is supported, including the RFC 3339 profile. For more information, see [DateTime and DateTimeOffset support in System.Text.Json](../datetime/system-text-json-support.md).
* To support a custom value type. For example, a `PhoneNumber` struct.

You can also write custom converters to customize or extend `System.Text.Json` with functionality not included in the current release. The following scenarios are covered later in this article:

::: zone pivot="dotnet-5-0,dotnet-6-0"

* [Deserialize inferred types to object properties](#deserialize-inferred-types-to-object-properties).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).
* [Support round-trip for Stack\<T>](#support-round-trip-for-stackt).
* [Support enum string value deserialization](#support-enum-string-value-deserialization).
::: zone-end

::: zone pivot="dotnet-core-3-1"

* [Deserialize inferred types to object properties](#deserialize-inferred-types-to-object-properties).
* [Support Dictionary with non-string key](#support-dictionary-with-non-string-key).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).
* [Support round-trip for Stack\<T>](#support-round-trip-for-stackt).
::: zone-end

In the code you write for a custom converter, be aware of the substantial performance penalty for using new <xref:System.Text.Json.JsonSerializerOptions> instances. For more information, see [Reuse JsonSerializerOptions instances](system-text-json-configure-options.md#reuse-jsonserializeroptions-instances).

Visual Basic can't be used to write custom converters but can call converters that are implemented in C# libraries. For more information, see [Visual Basic support](system-text-json-how-to.md#visual-basic-support).

## Custom converter patterns

There are two patterns for creating a custom converter: the basic pattern and the factory pattern. The factory pattern is for converters that handle type `Enum` or open generics. The basic pattern is for non-generic and closed generic types.  For example, converters for the following types require the factory pattern:

* <xref:System.Collections.Generic.Dictionary%602>
* <xref:System.Enum>
* <xref:System.Collections.Generic.List%601>

Some examples of types that can be handled by the basic pattern include:

* `Dictionary<int, string>`
* `WeekdaysEnum`
* `List<DateTimeOffset>`
* <xref:System.DateTime>
* <xref:System.Int32>

The basic pattern creates a class that can handle one type. The factory pattern creates a class that determines, at run time, which specific type is required and dynamically creates the appropriate converter.

## Sample basic converter

The following sample is a converter that overrides default serialization for an existing data type. The converter uses mm/dd/yyyy format for `DateTimeOffset` properties.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DateTimeOffsetConverter.cs":::

## Sample factory pattern converter

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`. The code follows the factory pattern because the first generic type parameter is `Enum` and the second is open. The `CanConvert` method returns `true` only for a `Dictionary` with two generic parameters, the first of which is an `Enum` type. The inner converter gets an existing converter to handle whichever type is provided at run time for `TValue`.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DictionaryTKeyEnumTValueConverter.cs":::

The preceding code is the same as what is shown in the [Support Dictionary with non-string key](#support-dictionary-with-non-string-key) later in this article.

## Steps to follow the basic pattern

The following steps explain how to create a converter by following the basic pattern:

* Create a class that derives from <xref:System.Text.Json.Serialization.JsonConverter%601> where `T` is the type to be serialized and deserialized.
* Override the `Read` method to deserialize the incoming JSON and convert it to type `T`. Use the <xref:System.Text.Json.Utf8JsonReader> that is passed to the method to read the JSON. You don't have to worry about handling partial data, as the serializer passes all the data for the current JSON scope. So it isn't necessary to call <xref:System.Text.Json.Utf8JsonReader.Skip%2A> or <xref:System.Text.Json.Utf8JsonReader.TrySkip%2A> or to validate that <xref:System.Text.Json.Utf8JsonReader.Read%2A> returns `true`.
* Override the `Write` method to serialize the incoming object of type `T`. Use the <xref:System.Text.Json.Utf8JsonWriter> that is passed to the method to write the JSON.
* Override the `CanConvert` method only if necessary. The default implementation returns `true` when the type to convert is of type `T`. Therefore, converters that support only type `T` don't need to override this method. For an example of a converter that does need to override this method, see the [polymorphic deserialization](#support-polymorphic-deserialization) section later in this article.

You can refer to the [built-in converters source code](https://github.com/dotnet/runtime/tree/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/) as reference implementations for writing custom converters.

## Steps to follow the factory pattern

The following steps explain how to create a converter by following the factory pattern:

* Create a class that derives from <xref:System.Text.Json.Serialization.JsonConverterFactory>.
* Override the `CanConvert` method to return true when the type to convert is one that the converter can handle. For example, if the converter is for `List<T>` it might only handle `List<int>`, `List<string>`, and `List<DateTime>`.
* Override the `CreateConverter` method to return an instance of a converter class that will handle the type-to-convert that is provided at run time.
* Create the converter class that the `CreateConverter` method instantiates.

The factory pattern is required for open generics because the code to convert an object to and from a string isn't the same for all types. A converter for an open generic type (`List<T>`, for example) has to create a converter for a closed generic type (`List<DateTime>`, for example) behind the scenes. Code must be written to handle each closed-generic type that the converter can handle.

The `Enum` type is similar to an open generic type: a converter for `Enum` has to create a converter for a specific `Enum` (`WeekdaysEnum`, for example) behind the scenes.

## The use of `Utf8JsonReader` in the `Read` method

If your converter is converting a JSON object, the `Utf8JsonReader` will be positioned on the begin object token when the `Read` method begins. You must then read through all the tokens in that object and exit the method with the reader positioned on **the corresponding end object token**.  If you read beyond the end of the object, or if you stop before reaching the corresponding end token, you get a `JsonException` exception indicating that:

> The converter 'ConverterName' read too much or not enough.

For an example, see the preceding factory pattern sample converter. The `Read` method starts by verifying that the reader is positioned on a start object token. It reads until it finds that it is positioned on the next end object token. It stops on the next end object token because there are no intervening start object tokens that would indicate an object within the object. The same rule about begin token and end token applies if you are converting an array. For an example, see the [`Stack<T>`](#support-round-trip-for-stackt) sample converter later in this article.

## Error handling

The serializer provides special handling for exception types <xref:System.Text.Json.JsonException> and <xref:System.NotSupportedException>.

### JsonException

If you throw a `JsonException` without a message, the serializer creates a message that includes the path to the part of the JSON that caused the error. For example, the statement `throw new JsonException()` produces an error message like the following example:

```output
Unhandled exception. System.Text.Json.JsonException:
The JSON value could not be converted to System.Object.
Path: $.Date | LineNumber: 1 | BytePositionInLine: 37.
```

If you do provide a message (for example, `throw new JsonException("Error occurred")`, the serializer still sets the <xref:System.Text.Json.JsonException.Path>, <xref:System.Text.Json.JsonException.LineNumber>, and <xref:System.Text.Json.JsonException.BytePositionInLine> properties.

### NotSupportedException

If you throw a `NotSupportedException`, you always get the path information in the message. If you provide a message, the path information is appended to it. For example, the statement `throw new NotSupportedException("Error occurred.")` produces an error message like the following example:

```output
Error occurred. The unsupported member type is located on type
'System.Collections.Generic.Dictionary`2[Samples.SummaryWords,System.Int32]'.
Path: $.TemperatureRanges | LineNumber: 4 | BytePositionInLine: 24
```

### When to throw which exception type

When the JSON payload contains tokens that are not valid for the type being deserialized, throw a `JsonException`.

When you want to disallow certain types, throw a `NotSupportedException`. This exception is what the serializer automatically throws for types that are not supported. For example, `System.Type` is not supported for security reasons, so an attempt to deserialize it results in a `NotSupportedException`.

You can throw other exceptions as needed, but they don't automatically include JSON path information.

## Register a custom converter

*Register* a custom converter to make the `Serialize` and `Deserialize` methods use it. Choose one of the following approaches:

* Add an instance of the converter class to the <xref:System.Text.Json.JsonSerializerOptions.Converters?displayProperty=nameWithType> collection.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to the properties that require the custom converter.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to a class or a struct that represents a custom value type.

## Registration sample - Converters collection

Here's an example that makes the [DateTimeOffsetJsonConverter](#sample-basic-converter) the default for properties of type <xref:System.DateTimeOffset>:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RegisterConverterWithConvertersCollection.cs" id="Serialize":::

Suppose you serialize an instance of the following type:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::

Here's an example of JSON output that shows the custom converter was used:

```json
{
  "Date": "08/01/2019",
  "TemperatureCelsius": 25,
  "Summary": "Hot"
}
```

The following code uses the same approach to deserialize using the custom `DateTimeOffset` converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RegisterConverterWithConvertersCollection.cs" id="Deserialize":::

## Registration sample - [JsonConverter] on a property

The following code selects a custom converter for the `Date` property:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithConverterAttribute":::

The code to serialize `WeatherForecastWithConverterAttribute` doesn't require the use of `JsonSerializeOptions.Converters`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RegisterConverterWithAttributeOnProperty.cs" id="Serialize":::

The code to deserialize also doesn't require the use of `Converters`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RegisterConverterWithAttributeOnProperty.cs" id="Deserialize":::

## Registration sample - [JsonConverter] on a type

Here's code that creates a struct and applies the `[JsonConverter]` attribute to it:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Temperature.cs":::

Here's the custom converter for the preceding struct:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/TemperatureConverter.cs":::

The `[JsonConverter]` attribute on the struct registers the custom converter as the default for properties of type `Temperature`. The converter is automatically used on the `TemperatureCelsius` property of the following type when you serialize or deserialize it:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithTemperatureStruct":::

## Converter registration precedence

During serialization or deserialization, a converter is chosen for each JSON element in the following order, listed from highest priority to lowest:

* `[JsonConverter]` applied to a property.
* A converter added to the `Converters` collection.
* `[JsonConverter]` applied to a custom value type or POCO.

If multiple custom converters for a type are registered in the `Converters` collection, the first converter that returns true for `CanConvert` is used.

A built-in converter is chosen only if no applicable custom converter is registered.

## Converter samples for common scenarios

The following sections provide converter samples that address some common scenarios that built-in functionality doesn't handle.

::: zone pivot="dotnet-5-0,dotnet-6-0"

* [Deserialize inferred types to object properties](#deserialize-inferred-types-to-object-properties).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).
* [Support round-trip for Stack\<T>](#support-round-trip-for-stackt).
* [Support enum string value deserialization](#support-enum-string-value-deserialization)
::: zone-end

::: zone pivot="dotnet-core-3-1"

* [Deserialize inferred types to object properties](#deserialize-inferred-types-to-object-properties).
* [Support Dictionary with non-string key](#support-dictionary-with-non-string-key).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).
* [Support round-trip for Stack\<T>](#support-round-trip-for-stackt).
::: zone-end

For a sample <xref:System.Data.DataTable> converter, see [Supported collection types](system-text-json-supported-collection-types.md#systemdata-namespace).

### Deserialize inferred types to object properties

When deserializing to a property of type `object`, a `JsonElement` object is created. The reason is that the deserializer doesn't know what CLR type to create, and it doesn't try to guess. For example, if a JSON property has "true", the deserializer doesn't infer that the value is a `Boolean`, and if an element has "01/01/2019", the deserializer doesn't infer that it's a `DateTime`.

Type inference can be inaccurate. If the deserializer parses a JSON number that has no decimal point as a `long`, that might result in out-of-range issues if the value was originally serialized as a `ulong` or `BigInteger`. Parsing a number that has a decimal point as a `double` might lose precision if the number was originally serialized as a `decimal`.

For scenarios that require type inference, the following code shows a custom converter for `object` properties. The code converts:

* `true` and `false` to `Boolean`
* Numbers without a decimal to `long`
* Numbers with a decimal to `double`
* Dates to `DateTime`
* Strings to `string`
* Everything else to `JsonElement`

::: zone pivot="dotnet-5-0,dotnet-6-0"

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterInferredTypesToObject.cs":::

The example shows the converter code and a `WeatherForecast` class with `object` properties. The `Main` method deserializes a JSON string into a `WeatherForecast` instance, first without using the converter, and then using the converter. The console output shows that without the converter the run time type for the `Date` property is `JsonElement`; with the converter, the run time type is `DateTime`.

The [unit tests folder](https://github.com/dotnet/runtime/tree/c72b54243ade2e1118ab24476220a2eba6057466/src/libraries/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle deserialization to `object` properties.

:::zone-end

::: zone pivot="dotnet-core-3-1"

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/ObjectToInferredTypesConverter.cs":::

The following code registers the converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DeserializeInferredTypesToObject.cs" id="Register":::

Here's an example type with `object` properties:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithObjectProperties":::

The following example of JSON to deserialize contains values that will be deserialized as `DateTime`, `long`, and `string`:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
}
```

Without the custom converter, deserialization puts a `JsonElement` in each property.

The [unit tests folder](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle deserialization to `object` properties.

:::zone-end

::: zone pivot="dotnet-core-3-1"

### Support Dictionary with non-string key

The built-in support for dictionary collections is for `Dictionary<string, TValue>`. That is, the key must be a string. To support a dictionary with an integer or some other type as the key, a custom converter is required.

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DictionaryTKeyEnumTValueConverter.cs":::

The following code registers the converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripDictionaryTkeyEnumTValue.cs" id="Register":::

The converter can serialize and deserialize the `TemperatureRanges` property of the following class that uses the following `Enum`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithEnumDictionary":::

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

The [unit tests folder](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle non-string-key dictionaries.
::: zone-end

### Support polymorphic deserialization

Built-in features provide a limited range of [polymorphic serialization](system-text-json-polymorphism.md) but no support for deserialization at all. Deserialization requires a custom converter.

Suppose, for example, you have a `Person` abstract base class, with `Employee` and `Customer` derived classes. Polymorphic deserialization means that at design time you can specify `Person` as the deserialization target, and `Customer` and `Employee` objects in the JSON are correctly deserialized at run time. During deserialization, you have to find clues that identify the required type in the JSON. The kinds of clues available vary with each scenario. For example, a discriminator property might be available or you might have to rely on the presence or absence of a particular property. The current release of `System.Text.Json` doesn't provide attributes to specify how to handle polymorphic deserialization scenarios, so custom converters are required.

The following code shows a base class, two derived classes, and a custom converter for them. The converter uses a discriminator property to do polymorphic deserialization. The type discriminator isn't in the class definitions but is created during serialization and is read during deserialization.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Person.cs" id="Person":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/PersonConverterWithTypeDiscriminator.cs":::

The following code registers the converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripPolymorphic.cs" id="Register":::

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

The converter code in the preceding example reads and writes each property manually. An alternative is to call `Deserialize` or `Serialize` to do some of the work. For an example, see [this StackOverflow post](https://stackoverflow.com/a/59744873/12509023).

### An alternative way to do polymorphic deserialization

You can call `Deserialize` in the `Read` method:

* Make a clone of the `Utf8JsonReader` instance. Since `Utf8JsonReader` is a struct, this just requires an assignment statement.
* Use the clone to read through the discriminator tokens.
* Call `Deserialize` using the original `Reader` instance once you know the type you need. You can call `Deserialize` because the original `Reader` instance is still positioned to read the begin object token.

A disadvantage of this method is you can't pass in the original options instance that registers the converter to `Deserialize`. Doing so would cause a stack overflow, as explained in [Required properties](system-text-json-migrate-from-newtonsoft-how-to.md#required-properties). The following example shows a `Read` method that uses this alternative:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/PersonConverterWithTypeDiscriminatorAlt.cs" id="ReadMethod":::

### Support round trip for Stack\<T>

If you deserialize a JSON string into a <xref:System.Collections.Generic.Stack%601> object and then serialize that object, the contents of the stack are in reverse order. This behavior applies to the following types and interface, and user-defined types that derive from them:

* <xref:System.Collections.Stack>
* <xref:System.Collections.Generic.Stack%601>
* <xref:System.Collections.Concurrent.ConcurrentStack%601>
* <xref:System.Collections.Immutable.ImmutableStack%601>
* <xref:System.Collections.Immutable.IImmutableStack%601>

To support serialization and deserialization that retains the original order in the stack, a custom converter is required.

The following code shows a custom converter that enables round-tripping to and from `Stack<T>` objects:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonConverterFactoryForStackOfT.cs":::

The following code registers the converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripStackOfT.cs" id="Register":::

::: zone pivot="dotnet-5-0,dotnet-6-0"

### Support enum string value deserialization

By default, the built-in <xref:System.Text.Json.Serialization.JsonStringEnumConverter> can serialize and deserialize string values for enums. It works without a specified naming policy or with the <xref:System.Text.Json.JsonNamingPolicy.CamelCase> naming policy. It doesn't support other naming policies, such as snake case. For information about custom converter code that can support round-tripping to and from enum string values while using a snake case naming policy, see GitHub issue [dotnet/runtime #31619](https://github.com/dotnet/runtime/issues/31619#issuecomment-891994805).

::: zone-end

## Handle null values

By default, the serializer handles null values as follows:

* For reference types and <xref:System.Nullable%601> types:

  * It does not pass `null` to custom converters on serialization.
  * It does not pass `JsonTokenType.Null` to custom converters on deserialization.
  * It returns a `null` instance on deserialization.
  * It writes `null` directly with the writer on serialization.

* For non-nullable value types:

  * It passes `JsonTokenType.Null` to custom converters on deserialization. (If no custom converter is available, a `JsonException` exception is thrown by the internal converter for the type.)

This null-handling behavior is primarily to optimize performance by skipping an extra call to the converter. In addition, it avoids forcing converters for nullable types to check for `null` at the start of every `Read` and `Write` method override.

::: zone pivot="dotnet-5-0,dotnet-6-0"
To enable a custom converter to handle `null` for a reference or value type, override <xref:System.Text.Json.Serialization.JsonConverter%601.HandleNull%2A?displayProperty=nameWithType> to return `true`, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterHandleNull.cs" highlight="18":::
::: zone-end

## Preserve references

::: zone pivot="dotnet-5-0,dotnet-6-0"

By default, reference data is only cached for each call to <xref:System.Text.Json.JsonSerializer.Serialize%2A> or <xref:System.Text.Json.JsonSerializer.Deserialize%2A>. To persist references from one `Serialize`/`Deserialize` call to another one, root the <xref:System.Text.Json.Serialization.ReferenceResolver> instance in the call site of `Serialize`/`Deserialize`. The following code shows an example for this scenario:

* You write a custom converter for the `Company` type.
* You don't want to manually serialize the `Supervisor` property, which is an `Employee`. You want to delegate that to the serializer and you also want to preserve the references that you have already saved.

Here are the `Employee` and `Company` classes:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterPreserveReferences.cs" id="EmployeeAndCompany":::

The converter looks like this:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterPreserveReferences.cs" id="CompanyConverter":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceResolver> stores the references in a dictionary:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterPreserveReferences.cs" id="MyReferenceResolver":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceHandler> holds an instance of `MyReferenceResolver` and creates a new instance only when needed (in a method named `Reset` in this example):

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterPreserveReferences.cs" id="MyReferenceHandler":::

When the sample code calls the serializer, it uses a <xref:System.Text.Json.JsonSerializerOptions> instance in which the <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler> property is set to an instance of `MyReferenceHandler`. When you follow this pattern, be sure to reset the `ReferenceResolver` dictionary when you're finished serializing, to keep it from growing forever.

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterPreserveReferences.cs" id="CallSerializer" highlight = "4-5,12":::

The preceding example only does serialization, but a similar approach can be adopted for deserialization.

::: zone-end
::: zone pivot="dotnet-core-3-1"

For information about how to preserve references, see [the .NET 5 version of this page](system-text-json-converters-how-to.md?pivots=dotnet-5-0#preserve-references).

::: zone-end

## Other custom converter samples

The [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md) article contains additional samples of custom converters.

The [unit tests folder](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` source code includes other custom converter samples, such as:

* [Int32 converter that converts null to 0 on deserialize](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/CustomConverterTests.NullValueType.cs)
* [Int32 converter that allows both string and number values on deserialize](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/CustomConverterTests.Int32.cs)
* [Enum converter](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/CustomConverterTests.Enum.cs)
* [List\<T> converter that accepts external data](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/CustomConverterTests.List.cs)
* [Long[] converter that works with a comma-delimited list of numbers](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/tests/Serialization/CustomConverterTests.Array.cs)

If you need to make a converter that modifies the behavior of an existing built-in converter, you can get [the source code of the existing converter](https://github.com/dotnet/runtime/tree/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters) to serve as a starting point for customization.

## Additional resources

* [Source code for built-in converters](https://github.com/dotnet/runtime/tree/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters)
* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
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
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
