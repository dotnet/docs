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

```csharp
public class ExampleDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        return DateTimeOffset.ParseExact(reader.GetString(), 
            "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }

    public override void Write(
        Utf8JsonWriter writer, 
        DateTimeOffset value, 
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(
            "MM/dd/yyyy", CultureInfo.InvariantCulture));
    }
}
```

## Sample factory pattern converter

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`. The code follows the factory pattern because the first generic type parameter is `Enum` and the second is open. The `CanConvert` method returns `true` only for a `Dictionary` with two generic parameters, the first of which is an `Enum` type. The inner converter gets an existing converter to handle whichever type is provided at runtime for `TValue`. 

```csharp
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ConverterDictionaryTKeyEnumTValue : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(Dictionary<,>))
            {
                return false;
            }

            return typeToConvert.GetGenericArguments()[0].IsEnum;
        }

        public override JsonConverter CreateConverter(
            Type type, 
            JsonSerializerOptions options)
        {
            Type keyType = type.GetGenericArguments()[0];
            Type valueType = type.GetGenericArguments()[1];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(DictionaryEnumConverterInner<,>).MakeGenericType(
                    new Type[] { keyType, valueType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class DictionaryEnumConverterInner<TKey, TValue> : 
            JsonConverter<Dictionary<TKey, TValue>> where TKey : struct, Enum
        {
            private readonly JsonConverter<TValue> _valueConverter;
            private Type _keyType;
            private Type _valueType;

            public DictionaryEnumConverterInner(JsonSerializerOptions options)
            {
                // For performance, use the existing converter if available.
                _valueConverter = (JsonConverter<TValue>)options
                    .GetConverter(typeof(TValue));

                // Cache the key and value types.
                _keyType = typeof(TKey);
                _valueType = typeof(TValue);
            }

            public override Dictionary<TKey, TValue> Read(
                ref Utf8JsonReader reader, 
                Type typeToConvert, 
                JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                Dictionary<TKey, TValue> value = new Dictionary<TKey, TValue>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return value;
                    }

                    // Get the key.
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new JsonException();
                    }

                    string propertyName = reader.GetString();

                    // For performance, parse with ignoreCase:false first.
                    if (!Enum.TryParse(propertyName, ignoreCase: false, out TKey key) &&
                        !Enum.TryParse(propertyName, ignoreCase: true, out key))
                    {
                        throw new JsonException(
                            $"Unable to convert \"{propertyName}\" to Enum \"{_keyType}\".");
                    }

                    // Get the value.
                    TValue v;
                    if (_valueConverter != null)
                    {
                        reader.Read();
                        v = _valueConverter.Read(ref reader, _valueType, options);
                    }
                    else
                    {
                        v = JsonSerializer.Deserialize<TValue>(ref reader, options);
                    }

                    // Add to dictionary.
                    value.Add(key, v);
                }

                throw new JsonException();
            }

            public override void Write(
                Utf8JsonWriter writer, 
                Dictionary<TKey, TValue> value, 
                JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach (KeyValuePair<TKey, TValue> kvp in value)
                {
                    writer.WritePropertyName(kvp.Key.ToString());

                    if (_valueConverter != null)
                    {
                        _valueConverter.Write(writer, kvp.Value, options);
                    }
                    else
                    {
                        JsonSerializer.Serialize(writer, kvp.Value, options);
                    }
                }

                writer.WriteEndObject();
            }
        }
    }
}
```

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

```text
Unhandled exception. System.Text.Json.JsonException: 
The JSON value could not be converted to System.Object. 
Path: $.Date | LineNumber: 1 | BytePositionInLine: 37.
```

If you do provide a message (for example, `throw new JsonException("Error occurred)`, the exception still provides the path in the <xref:System.Text.Json.JsonException.Path> property.

## Register a custom converter

*Register* a custom converter to make the `Serialize` and `Deserialize` methods use it. Choose one of the following approaches:

* Add an instance of the converter class to the <xref:System.Text.Json.JsonSerializerOptions.Converters?displayProperty=nameWithType> collection.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to the properties that require the custom converter.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to a class or a struct that represents a custom value type.

## Registration sample - Converters collection 

Here's an example that makes the `ExampleDateTimeOffsetConverter` the default for properties of type `DateTimeOffset`:

```csharp
//...
JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ExampleDateTimeOffsetConverter());
string json = JsonSerializer.Serialize(weatherForecast, options);
```

Suppose you serialize the following type:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}
```

Here's an example of JSON output that shows the custom converter was used:

```json
{
  "Date": "08/01/2019",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

The following code uses the same approach to deserialize using the custom `DateTimeOffset` converter:

```csharp
//...
JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ExampleDateTimeOffsetConverter());
weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json, options);
```

## Registration sample - [JsonConverter] on a property

The following code selects a custom converter for the `Date` property:

```csharp
class WeatherForecastWithConverter
{
    [JsonConverter(typeof(ExampleDateTimeOffsetConverter))]
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}
```

The code to serialize and deserialize `WeatherForecastWithConverter` doesn't require the use of `JsonSerializeOptions.Converters`:

```csharp
string json = JsonSerializer.Serialize(weatherForecastWithConverter);
```

```csharp
weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithConverter>(json);
```

## Registration sample - [JsonConverter] on a type

Here's code that creates a struct and applies the `[JsonConverter]` attribute to it:

```csharp
[JsonConverter(typeof(TemperatureConverter))]
public struct Temperature
{
    public Temperature(int degrees, bool celsius)
    {
        _degrees = degrees;
        _isCelsius = celsius;
    }
    private bool _isCelsius;
    private int _degrees;
    public int Degrees => _degrees;
    public bool IsCelsius => _isCelsius; 
    public bool IsFahrenheit => !_isCelsius;
    public override string ToString() =>
        $"{_degrees.ToString()}{(_isCelsius ? "C" : "F")}";
    public static Temperature Parse(string input)
    {
        int degrees = int.Parse(input.Substring(0, input.Length - 1));
        bool celsius = (input.Substring(input.Length - 1) == "C");
        return new Temperature(degrees, celsius);
    }
}
```

Here's the custom converter for the preceding struct:

```csharp
public class TemperatureConverter : JsonConverter<Temperature>
{
    public override Temperature Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(Temperature));
        return Temperature.Parse(reader.GetString());
    }

    public override void Write(
        Utf8JsonWriter writer,
        Temperature value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
```

The `[JsonConvert]` attribute on the struct registers the custom converter as the default for properties of type `Temperature`. The converter is automatically used on the `TemperatureC` property of the following type when you serialize or deserialize it:

```csharp
class WeatherForecastWithTemperatureStruct
{
    public DateTimeOffset Date { get; set; }
    public Temperature TemperatureC { get; set; }
    public string Summary { get; set; }
}
```

## Converter registration precedence

During serialization or deserialization, a converter is chosen for each JSON element in the following order, listed from highest priority to lowest:

* `[JsonConverter]` applied to a property.
* A converter added to the `Converters` collection.
* `[JsonConverter]` applied to a custom value type or POCO.

If multiple custom converters for a type are registered in the `Converters` collection, the first converter that returns true for `CanConvert` is used.

A built-in converter is chosen only if no applicable custom converter is registered.

## Converter samples for common scenarios

The following sections provide converter samples that address some common scenarios that built-in functionality doesn't handle.

### Deserialize inferred types to Object properties

When deserializing to a property of type `Object`, a `JsonElement` object is created. The reason is that the deserializer doesn't know what CLR type to create, and it doesn't try to guess. For example, if a JSON property has "true", the deserializer doesn't infer that the value is a `Boolean`, and if an element has "01/01/2019", the deserializer doesn't infer that it's a `DateTime`.

Type inference can be inaccurate. If the deserializer parses a JSON number that has no decimal point as a `long`, that might result in out-of-range issues if the value was originally serialized as a `ulong` or `BigInteger`. Parsing a number that has a decimal point as a `double` might lose precision if the number was originally serialized as a `decimal`.

For scenarios that require type inference, the following code shows a custom converter for `Object` properties. The code converts:

* `true` and `false` to `Boolean`
* Numbers to `long` or `double`
* Dates to `DateTime`
* Strings to `string`
* Everything else to `JsonElement`

```csharp
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ObjectToInferredTypesConverter
        : JsonConverter<object>
    {
        public override object Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.True)
            {
                return true;
            }

            if (reader.TokenType == JsonTokenType.False)
            {
                return false;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt64(out long l))
                {
                    return l;
                }

                return reader.GetDouble();
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                if (reader.TryGetDateTime(out DateTime datetime))
                {
                    return datetime;
                }

                return reader.GetString();
            }

            // Use JsonElement as fallback.
            // Newtonsoft uses JArray or JObject.
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                return document.RootElement.Clone();
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            object value,
            JsonSerializerOptions options)
        {
            throw new InvalidOperationException("Should not get here.");
        }
    }
}
```

The following code registers the converter:

```csharp
options = new JsonSerializerOptions();
options.Converters.Add(new ObjectToInferredTypesConverter());
```

Here's an example type with an Object property:

```csharp
public class WeatherForecastWithObjectProperties
{
    public object Date { get; set; }
    public object TemperatureC { get; set; }
    public object Summary { get; set; }
}
```

The following example of JSON to deserialize contains values that will be deserialized as `DateTime`, `long`, and `string`:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
}
```

Without the custom converter, deserialization puts a `JsonElement` in each property.

The [unit tests folder](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle deserialization to Object properties.

### Support Dictionary with non-string key

The built-in support for dictionary collections is for `Dictionary<string, TValue>`. That is, the key must be a string. To support a dictionary with an integer or some other type as the key, a custom converter is required.

The following code shows a custom converter that works with `Dictionary<Enum,TValue>`:

```csharp
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ConverterDictionaryTKeyEnumTValue : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(Dictionary<,>))
            {
                return false;
            }

            return typeToConvert.GetGenericArguments()[0].IsEnum;
        }

        public override JsonConverter CreateConverter(
            Type type, 
            JsonSerializerOptions options)
        {
            Type keyType = type.GetGenericArguments()[0];
            Type valueType = type.GetGenericArguments()[1];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(DictionaryEnumConverterInner<,>).MakeGenericType(
                    new Type[] { keyType, valueType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class DictionaryEnumConverterInner<TKey, TValue> : 
            JsonConverter<Dictionary<TKey, TValue>> where TKey : struct, Enum
        {
            private readonly JsonConverter<TValue> _valueConverter;
            private Type _keyType;
            private Type _valueType;

            public DictionaryEnumConverterInner(JsonSerializerOptions options)
            {
                // For performance, use the existing converter if available.
                _valueConverter = (JsonConverter<TValue>)options
                    .GetConverter(typeof(TValue));

                // Cache the key and value types.
                _keyType = typeof(TKey);
                _valueType = typeof(TValue);
            }

            public override Dictionary<TKey, TValue> Read(
                ref Utf8JsonReader reader, 
                Type typeToConvert, 
                JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                Dictionary<TKey, TValue> value = new Dictionary<TKey, TValue>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return value;
                    }

                    // Get the key.
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new JsonException();
                    }

                    string propertyName = reader.GetString();

                    // For performance, parse with ignoreCase:false first.
                    if (!Enum.TryParse(propertyName, ignoreCase: false, out TKey key) &&
                        !Enum.TryParse(propertyName, ignoreCase: true, out key))
                    {
                        throw new JsonException(
                            $"Unable to convert \"{propertyName}\" to Enum \"{_keyType}\".");
                    }

                    // Get the value.
                    TValue v;
                    if (_valueConverter != null)
                    {
                        reader.Read();
                        v = _valueConverter.Read(ref reader, _valueType, options);
                    }
                    else
                    {
                        v = JsonSerializer.Deserialize<TValue>(ref reader, options);
                    }

                    // Add to dictionary.
                    value.Add(key, v);
                }

                throw new JsonException();
            }

            public override void Write(
                Utf8JsonWriter writer, 
                Dictionary<TKey, TValue> value, 
                JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach (KeyValuePair<TKey, TValue> kvp in value)
                {
                    writer.WritePropertyName(kvp.Key.ToString());

                    if (_valueConverter != null)
                    {
                        _valueConverter.Write(writer, kvp.Value, options);
                    }
                    else
                    {
                        JsonSerializer.Serialize(writer, kvp.Value, options);
                    }
                }

                writer.WriteEndObject();
            }
        }
    }
}
```

The following code registers the converter:

```csharp
var serializeOptions = new JsonSerializerOptions();
serializeOptions.Converters.Add(new ConverterDictionaryTKeyEnumTValue());
```

The converter can serialize and deserialize the `TemperatureRanges` property of the following class that uses the following `Enum`:

```csharp
public class WeatherForecastWithEnumDictionary
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public Dictionary<SummaryWordsEnum, int> TemperatureRanges { get; set; }
}

public enum SummaryWordsEnum
{
    Cold, Hot
}
```

The JSON output from serialization looks like the following example:

```json
{

  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
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

```csharp
public class Person
{
    public string Name { get; set; }
}

public class Customer : Person
{
    public decimal CreditLimit { get; set; }
}

public class Employee : Person
{
    public string OfficeNumber { get; set; }
}
```

```csharp
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class PersonConverterWithTypeDiscriminator : JsonConverter<Person>
    {
        enum TypeDiscriminator
        {
            Customer = 1,
            Employee = 2
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Person).IsAssignableFrom(typeToConvert);
        }

        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string propertyName = reader.GetString();
            if (propertyName != "TypeDiscriminator")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            Person value;
            TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
            switch (typeDiscriminator)
            {
                case TypeDiscriminator.Customer:
                    value = new Customer();
                    break;

                case TypeDiscriminator.Employee:
                    value = new Employee();
                    break;

                default:
                    throw new JsonException();
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return value;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "CreditLimit":
                            decimal creditLimit = reader.GetDecimal();
                            ((Customer)value).CreditLimit = creditLimit;
                            break;
                        case "OfficeNumber":
                            string officeNumber = reader.GetString();
                            ((Employee)value).OfficeNumber = officeNumber;
                            break;
                        case "Name":
                            string name = reader.GetString();
                            value.Name = name;
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is Customer customer)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Customer);
                writer.WriteNumber("CreditLimit", customer.CreditLimit);
            }
            else if (value is Employee employee)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Employee);
                writer.WriteString("OfficeNumber", employee.OfficeNumber);
            }

            writer.WriteString("Name", value.Name);

            writer.WriteEndObject();
        }
    }
}
```

The following code registers the converter:

```csharp
options = new JsonSerializerOptions();
options.Converters.Add(new PersonConverterWithTypeDiscriminator());
```

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
