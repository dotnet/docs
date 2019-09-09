---
title: "How to serialize JSON in .NET"
ms.date: "09/02/2019"
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.assetid: 4d1111c0-9447-4231-a997-96a2b74b3453
---

# How to serialize JSON in .NET

This article shows how to use the <xref:System.Text.Json> namespace to serialize and deserialize to and from JavaScript Object Notation (JSON). The directions and sample code use the library directly, not through a framework such as [ASP.NET Core](/aspnet/core/).

## Using directive

The code examples in this article require a `using` directive for `System.Text.Json`:

```csharp
using System.Text.Json;
```

## How to serialize

Call [JsonSerializer.Serialize](xref:System.Text.Json.JsonSerializer.Serialize*), using a generic type parameter or generic type inference:

```csharp
string json = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
```

```csharp
WeatherForecast weatherForecast = ... ;
//...
string json = JsonSerializer.Serialize(weatherForecast);
```

Example types to be serialized, with collections and nested classes:

```csharp
class WeatherForecast1
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public IList<DateTimeOffset> DatesAvailable { get; set;}
    public Dictionary<string, HighLowTemperatures> TemperatureRanges { get; set; }
    public string [] SummaryWords { get; set; }
}

public class HighLowTemperatures
{
    public Temperature High { get; set; }
    public Temperature Low { get; set; }
}

public class Temperature
{
    public int DegreesCelsius { get; set; }
}
```

The JSON output is minified by default: 

```json
{"Date":"2019-08-01T00:00:00-07:00","TemperatureC":25,"Summary":"Hot","DatesAvailable":["2019-08-01T00:00:00-07:00","2019-08-02T00:00:00-07:00"],"TemperatureRanges":{"Cold":{"High":{"DegreesCelsius":20},"Low":{"DegreesCelsius":-10}},"Hot":{"High":{"DegreesCelsius":60},"Low":{"DegreesCelsius":20}}},"SummaryWords":["Cool","Windy","Humid"]}
```

The following example shows the same JSON formatted:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "DatesAvailable": [
    "2019-08-01T00:00:00-07:00",
    "2019-08-02T00:00:00-07:00"
  ],
  "TemperatureRanges": {
    "Cold": {
      "High": {
        "DegreesCelsius": 20
      },
      "Low": {
        "DegreesCelsius": -10
      }
    },
    "Hot": {
      "High": {
        "DegreesCelsius": 60
      },
      "Low": {
        "DegreesCelsius": 20
      }
    }
  },
  "SummaryWords": [
    "Cool",
    "Windy",
    "Humid"
  ]
}
```

Overloads of <xref:System.Text.Json.JsonSerializer.Serialize*> let you serialize to a `Stream`.  Async versions of the `Stream` overloads are available.

### Default serialization behavior

* All public properties are serialized. You can exclude [selected](#exclude-selected-properties), [read-only](#exclude-read-only-properties), and [null value](#exclude-null-value-properties) properties.
* Fields are excluded.
* Supported types include:
  * .NET primitives that map to JavaScript primitives.
  * User-defined [Plain Old CLR Objects (POCOs)](https://stackoverflow.com/questions/250001/poco-definition).
  * One-dimensional and jagged arrays (`ArrayName[][]`).
  * Types that implement `IList` or `IEnumerable`.
  * `Dictionary<string,TValue>`
* The [default maximum depth](xref:System.Text.Json.JsonReaderOptions.MaxDepth) is 64.

### Serialize to UTF-8

Call [JsonSerializer.SerializeToUtf8Bytes)](xref:System.Text.Json.JsonSerializer.SerializeToUtf8Bytes*):

```csharp
string json = JsonSerializer.SerializeToUtf8Bytes<WeatherForecast>(weatherForecast);
```

As an alternative, a <xref:System.Text.Json.JsonSerializer.Serialize*> overload that takes a <xref:System.Text.Json.Utf8JsonWriter> is available.

Serializing to UTF-8 is about 5-10% faster than using the string-based methods. The difference is because the bytes (as UTF-8) don't need to be converted to strings (UTF-16).

## How to deserialize

Call [JsonSerializer.Deserialize](xref:System.Text.Json.JsonSerializer.Deserialize*):

```csharp
var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);
```

Example JSON input:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "DatesAvailable": [
    "2019-08-01T00:00:00-07:00",
    "2019-08-02T00:00:00-07:00"
  ],
  "TemperatureRanges": {
    "Cold": {
      "High": {
        "DegreesCelsius": 20
      },
      "Low": {
        "DegreesCelsius": -10
      }
    },
    "Hot": {
      "High": {
        "DegreesCelsius": 60
      },
      "Low": {
        "DegreesCelsius": 20
      }
    }
  },
  "SummaryWords": [
    "Cool",
    "Windy",
    "Humid"
  ]
}
```

Resulting property and field values:

|Property |Value  |Notes  |
|---------|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00||
| TemperatureC| 0 | Not set because property name matching is case-sensitive.|
| Summary| Hot||
| SummaryField| null | Not set because it's a field, not a property.|
| DatesAvailable | 8/1/2019 12:00:00 AM -07:00<br>8/2/2019 12:00:00 AM -07:00 | `IList<T>` and `IEnumerable<T>` implementations are supported. |
| TemperatureRanges | Cold, 20 High -10 Low<br>Hot, 60 High 20 Low| `Dictionary<string,TValue>` is supported. |
| SummaryWords | Cool<br>Windy<br>Humid | Arrays are supported. |

### Default deserialization behavior

* If the JSON contains a value for a read-only property, the value is ignored and no exception is thrown.
* Deserialization of reference types without a parameterless constructor isn't supported.
* Comments or trailing commas in the JSON trigger exceptions.

## Serialize to formatted JSON

Set <xref:System.Text.Json.JsonSerializerOptions.WriteIndented> to true:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example type to be serialized and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}
```

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

## Allow comments and trailing commas

Set <xref:System.Text.Json.JsonSerializerOptions.ReadCommentHandling> to `JsonCommentHandling.Skip`, and set <xref:System.Text.Json.JsonSerializerOptions.AllowTrailingCommas> to true:

```csharp
var options = new JsonSerializerOptions
{
    ReadCommentHandling = JsonCommentHandling.Skip,
    AllowTrailingCommas = true
};
var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);
```

Example JSON with comments and a trailing comma:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25, // Fahrenheit 77
  "Summary": "Hot", /* Zharko */
}
```

## Customize JSON names

This section explains how to:

* Customize individual property names
* Convert all property names to camel case
* Implement a custom property naming policy
* Convert dictionary keys to camel case

### Customize individual property names

To set the name of individual properties, use the [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) attribute:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}
```

Example JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "Wind": 35
}
```

The property name set by this attribute:

* Applies in both directions, for serialization and deserialization.
* Takes precedence over property naming policies.

### Use camel case for all JSON property names

Set <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy> to `JsonNamingPolicy.CamelCase`:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class to be serialized and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}
```

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureC": 25,
  "summary": "Hot",
  "Wind": 35
}
```

The camel case property naming policy:

* Applies to serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes.

### Use a custom JSON property naming policy

Derive from <xref:System.Text.Json.JsonNamingPolicy> and override <xref:System.Text.Json.JsonNamingPolicy.ConvertName*>:

```csharp
class UpperCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToUpper();
    }
}
```

Set <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy> to an instance of your naming policy class:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = new UpperCaseNamingPolicy()
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class to serialize and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}
```

```json
{
  "DATE": "2019-08-01T00:00:00-07:00",
  "TEMPERATUREC": 25,
  "SUMMARY": "Hot",
  "Wind": 35
}
```

The JSON property naming policy:

* Applies to serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes.

### Camel case dictionary keys

IF a property of an object to be serialized is of type `Dictionary<string,Tvalue>`, the `string` keys can be converted to camel case. To do that, set <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy> to `JsonNamingPolicy.CamelCase`:

```csharp
var options = new JsonSerializerOptions
{
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example object to serialize and JSON output:

|Property |Value  |
|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00|
| TemperatureC| 25 |
| Summary| Hot|
| TemperatureRanges | Cold, 20<br>Hot, 40|

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "TemperatureRanges": {
    "cold": 20,
    "hot": 40
  }
}
```

The camel case naming policy applies to serialization only.

## Exclude properties

This section explains how to exclude:

* Individual properties
* All read-only properties
* All null-value properties 

### Exclude individual properties

Use the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonIgnore]
    public int WindSpeed { get; set; }
}
```

Example JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

### Exclude all read-only properties

Set <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties> to true:

```csharp
var options = new JsonSerializerOptions
{
    IgnoreReadOnlyProperties = true
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class to serialize and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public int WindSpeed { get; private set; }
}
```

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
}
```

This option applies only to serialization. During deserialization, read-only properties are ignored by default. A property is read-only if it contains a public getter but not a public setter.

### Exclude all null value properties

Set <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues> to true:

```csharp
var options = new JsonSerializerOptions
{
    IgnoreNullValues = true
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example object to serialize:

|Property |Value  |
|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00|
| TemperatureC| 25 |
| Summary| null|

`Summary` is omitted from the JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25
}
```

This setting applies to serialization and deserialization.


## Case-insensitive property matching

Set <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive> to true:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(weatherForecast, options);
```

Example JSON with camel case property names:

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureC": 25,
  "summary": "Hot",
}
```

Resulting object property values after matching camel case to Pascal case property names:

|Property |Value  |
|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00|
| TemperatureC| 25 |
| Summary| Hot|

## Include properties of derived classes

Call an overload of `Serialize` that lets you specify the type at runtime:

```csharp
json = JsonSerializer.Serialize(weatherForecast, weatherForecast.GetType());
```

To explain why this overload is necessary, suppose you have a `WeatherForecast` class and a derived class `WeatherForecastWithWind`:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}
class WeatherForecastWithWind : WeatherForecast
{
    public int WindSpeed { get; set; }
}
```

And suppose the type passed to, or inferred by, the `Serialize` method at compile time is `WeatherForecast`:

```csharp
json = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
```

```csharp
WeatherForecast weatherForecast;
//...
json = JsonSerializer.Serialize(weatherForecast);
```

In this scenario, the `WindSpeed` property is not serialized even if the weatherForecast object is actually a `WeatherForecastWithWind` object. Only the base class properties are serialized:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

This behavior is intended to help prevent accidental exposure of data in a derived runtime-created type.

When you call a `Serialize` overload with `GetType()`, the `WindSpeed` property is included:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "Wind": 35
}
```

## Use Utf8JsonWriter directly

The following example shows how to use the <xref:System.Text.Json.Utf8JsonWriter> class directly.

```csharp
var options = new JsonWriterOptions
{
    Indented = true
};

using (var stream = new MemoryStream())
{
    using (var writer = new Utf8JsonWriter(stream, options))
    {
        writer.WriteStartObject();
        writer.WriteString("date", DateTimeOffset.UtcNow);
        writer.WriteNumber("temp", 42);
        writer.WriteEndObject();
    }

    string json = Encoding.UTF8.GetString(stream.ToArray());
    Console.WriteLine(json);
}
```

## Use Utf8JsonReader directly

The following example shows how to use the <xref:System.Text.Json.Utf8JsonReader> class directly. The code assumes that the `jsonUtf8` variable is a byte array that contains valid JSON.

```csharp
Utf8JsonReader reader = new Utf8JsonReader(jsonUtf8, isFinalBlock: true, state: default);

while (reader.Read())
{
    Console.Write(reader.TokenType);

    switch (reader.TokenType)
    {
        case JsonTokenType.PropertyName:
        case JsonTokenType.String:
            {
                string text = reader.GetString();
                Console.Write(" ");
                Console.Write(text);
                break;
            }

        case JsonTokenType.Number:
            {
                int value = reader.GetInt32();
                Console.Write(" ");
                Console.Write(value);
                break;
            }

            // Other token types elided for brevity
    }

    Console.WriteLine();
}
```

## Additional resources

* [System.Text.Json overview](json-serialization-overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [DateTime and DateTimeOffset support in System.Text.Json](../datetime/system-text-json-support.md)
