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

> [!IMPORTANT]
> The JSON serialization documentation is under construction. This article doesn't cover all scenarios. For more information, examine [System.Text.Json issues](https://github.com/dotnet/corefx/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json) in the dotnet/corefx repository on GitHub, especially those labeled [json-functionality-doc](https://github.com/dotnet/corefx/labels/json-functionality-doc).

This article shows how to create custom converters for the JSON serialization classes that are provided in the <xref:System.Text.Json> namespace. For an introduction to `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](system-text-json-how-to.md).

A *converter* is a class that converts an object or a value to and from JSON. The `System.Text.Json` namespace has built-in converters for most primitive types that map to JavaScript primitives. You can write custom converters:

* To override the default behavior of a built-in converter. For example, you might want `DateTime` values to be represented by mm/dd/yyyy format instead of the default  ISO 8601-1:2019 format.
* To support a custom data type. For example, a `PhoneNumber` struct.

You can also write custom converters to extend `System.Text.Json` with functionality not included in the current release. The following scenarios are covered later in this article:

* [Deserialize inferred types to Object properties](#deserialize-inferred-types-to-object-properties).
* [Support Dictionary with non-string key](#support-dictionary-with-non-string-key).
* [Support polymorphic deserialization](#support-polymorphic-deserialization).

## Create a custom converter

To create a custom converter:

* Create a class that derives from `JsonConverter<T>` where `T` is the type to be serialized and deserialized.
* Override the `Read` method to deserialize the incoming JSON and convert it to type `T`. Use the `Utf8JsonReader` that is passed to the method to read the JSON.
* Override the `Write` method to serialize the incoming object of type `T`. Use the `Utf8JsonWriter` that is passed to the method to write the JSON.
* Override the `CanConvert` method only if necessary. The default implementation returns `true` when the type to convert is type `T`. Therefore, converters that support only type `T` don't need to override this method. For an example of a converter that does need to override this method, see the [polymorphic deserialization](#support-polymorphic-deserialization) section later in this article.

### Sample converter

The following sample is a converter that overrides default serialization for an existing data type. The converter uses mm/dd/yyyy format for `DateTimeOffset` properties.

```csharp
private class ExampleDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(DateTimeOffset));
        return DateTimeOffset.ParseExact(reader.GetString(), 
            "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }

    public override void Write(
        Utf8JsonWriter writer, 
        DateTimeOffset value, 
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("MM/dd/yyyy"));
    }
}
```

## Register a custom converter

*Register* a custom converter to make the `Serialize` and `Deserialize` methods use it. Choose one of the following approaches:

* Add an instance of the converter class to the <xref:System.Text.Json.JsonSerializerOptions.Converters?displayProperty=nameWithType> collection.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to the properties that require the custom converter.
* Apply the [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute) attribute to a class or struct that represents a custom data type.

### Converter registration precedence

During serialization or deserialization, a converter is chosen for each JSON element in the following order, listed from highest priority to lowest:

* `[JsonConverter]` applied to a property.
* A converter added to the `Converters` collection.
* `[JsonConverter]` applied to a custom data type or POCO.

If multiple custom converters for a type are registered in the `Converters` collection, the first converter that returns true to `CanConvert` is used.

A built-in converter is chosen only if no applicable custom converter is registered.

### Registration sample - Converters collection 

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

### Sample registration - [JsonConverter] on a property

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

### Sample registration - [JsonConverter] on a type

Here's code that creates a struct and applies the `[JsonConverter]` attribute to it:

```csharp
[JsonConverter(typeof(TemperatureConverter))]
public struct Temperature
{
    public Temperature(int celsius)
    {
        temp = celsius.ToString();
    }
    private string temp;
    public override string ToString()
    {
        return temp;
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
        return new Temperature(int.Parse(reader.GetString()));
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

## Samples for common scenarios

The following sections provide converter samples that address some common scenarios that built-in functionality doesn't handle.

### Deserialize inferred types to Object properties

When deserializing to a property of type `Object`, a `JsonElement` object is created. The reason is that the deserializer doesn't know what CLR type to create, and it doesn't try to guess. For example, if a JSON element has "true", the deserializer doesn't infer that the value is a `Boolean`, and if an element has "01/01/2019", the deserializer doesn't infer that it's a `DateTime`. You can implement type inference in a custom converter.

The following code shows a converter that converts `true` or `false` values in JSON to Boolean in an Object property, numbers to `long`, dates to `DateTime`, and strings to `string`. For other values, the code falls back to `JsonElement`.

```csharp
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ConverterInferredTypesToObject
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
options.Converters.Add(new ConverterInferredTypesToObject());
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

The following code shows a custom converter that works with `Dictionary<int,string>`:

```csharp
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonConverters
{
    internal class DictionaryInt32StringConverter : JsonConverter<Dictionary<int, string>>
    {
        public override Dictionary<int, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var value = new Dictionary<int, string>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return value;
                }

                string keyAsString = reader.GetString();
                if (!int.TryParse(keyAsString, out int keyAsInt))
                {
                    throw new JsonException($"Unable to convert \"{keyAsString}\" to System.Int32.");
                }

                reader.Read();
                string itemValue = reader.GetString();

                value.Add(keyAsInt, itemValue);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<int, string> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<int, string> item in value)
            {
                writer.WriteString(item.Key.ToString(), item.Value);
            }

            writer.WriteEndObject();
        }
    }
}
```

The following code registers the converter:

```csharp
options = new JsonSerializerOptions();
options.Converters.Add(new DictionaryInt32StringConverter());
```

The converter can serialize and deserialize the `TemperatureRanges` property of the following class:

```csharp
class WeatherForecastDictIntString
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public Dictionary<int, string> TemperatureRanges { get; set; }
}
```

The JSON output from serialization looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "TemperatureRanges": {
    "20": "Cold",
    "30": "Hot"
  }
}
```

The [unit tests folder](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/tests/Serialization/) in the `System.Text.Json.Serialization` namespace has more examples of custom converters that handle non-string-key dictionaries.

### Support polymorphic deserialization

[Polymorphic serialization](system-text-json-how-to.md#serialize-properties-of-derived-classes) is supported, but a custom converter is required for deserialization.

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

namespace SystemTextJsonConverters
{
    public class PersonConverterWithTypeDiscriminator : JsonConverter<Person> JsonConverterFactory
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

            if (value is Customer)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Customer);
                writer.WriteNumber("CreditLimit", ((Customer)value).CreditLimit);
            }
            else if (value is Employee)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Employee);
                writer.WriteString("OfficeNumber", ((Employee)value).OfficeNumber);
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
