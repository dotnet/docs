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

This article shows how to use the <xref:System.Text.Json> namespace to serialize and deserialize to and from JavaScript Object Notation (JSON). The directions and sample code use the library directly, not through a framework such as ASP.NET Core.

## How to get the library

* For apps and libraries that target .NET Core 3.0, `System.Text.Json` is included in the shared framework.
* For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package:
  * .NET Standard
  * .NET Framework
  * .NET Core 2.x

## Using directive

The code examples in this article require a `using` directive for `System.Text.Json`:

```csharp
using System.Text.Json;
```

## How to serialize

Call [JsonSerialization.Serialize(Object)](xref:System.Text.Json.JsonSerializer.Serialize*).

```csharp
string json = JsonSerializer.Serialize(weatherForecast);
```

Example type and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public string SummaryField;
}
```

```json
{"Date":"2019-08-01T00:00:00-07:00","TemperatureC":25,"Summary":"Hot"}
```

Notes:

* The JSON is minified by default. [How to write formatted JSON](#serialize-to-formatted-json) is shown later in this article.
* Fields are excluded.

## How to deserialize

Call [JsonSerialization.Deserialize\<T>(String)](xref:System.Text.Json.JsonSerializer.Deserialize*).

```csharp
WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);
```

Example JSON input:

```json
{
  "Date":"2019-08-01T00:00:00-07:00",
  "temperatureC":25,
  "Summary":"Hot",
  "SummaryField":"Hot"
}
```

Resulting property and field values:

|Property |Value  |Notes  |
|---------|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00||
| TemperatureC| 0 |Property name matching is case-sensitive.|
| Summary| Hot||
| SummaryField| null |Fields are excluded.|

Comments or trailing commas in the json trigger exceptions.

## Serialize to UTF8

Call [JsonSerialization.SerializeToUTF8Bytes\<T>(String)](xref:System.Text.Json.JsonSerializer.SerializeToUTF8Bytes*).

```csharp
string json = JsonSerializer.SerializeToUTF8Bytes<WeatherForecast>((weatherForecast));
```

A JSON output example is in the [How to serialize](#how-to-serialize) section earlier in this article.

Serializing to UTF-8 is about 5-10% faster than using the string-based methods because the bytes (as UTF-8) don't need to be converted to or from strings (UTF-16).

## Serialize to formatted JSON

Set [JsonSerializerOptions.WriteIndented](xref:System.Text.Json.JsonSerializerOptions.WriteIndented) to true:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example type and JSON output:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public string SummaryField;
}
```

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

## Allow comments

Set [JsonSerializerOptions.ReadCommentHandling](xref:System.Text.Json.JsonSerializerOptions.WriteIndented) to `Skip`:

```csharp
var options = new JsonSerializerOptions
{
    ReadCommentHandling = JsonCommentHandling.Skip,
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example JSON with comments:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25, // Fahrenheit 77
  "Summary": "Hot" /* Zharko */
}
```

## Allow trailing commas

Set [JsonSerializerOptions.AllowTrailingCommas](xref:System.Text.Json.JsonSerializerOptions.WriteIndented) to true:

```csharp
var options = new JsonSerializerOptions
{
    AllowTrailingCommas = true,
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example JSON with trailing commas:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
}
```

## Specify JSON property names

To set the name in JSON of individual properties, use [[JsonPropertyNameAttribute]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute). For example:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}

JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "Wind": 35
}
```

The property name set by this attribute:

* Works in both directions, for serialization and deserialization.
* Takes precedence over property naming policies.

## camelCase JSON property names

To set all JSON property names to camel case, set <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=fullName> to `JsonNamingPolicy.CamelCase`:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}

JSON output:

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureC": 25,
  "summary": "Hot",
  "Wind": 35
}
```

The camel case property naming policy:

* Works in both directions, for serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes.

## Use custom JSON naming policy

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

Set <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=fullName> to an instance of your naming policy class:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = new UpperCaseNamingPolicy()
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class to serialize:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}

JSON output:

```json
{
  "DATE": "2019-08-01T00:00:00-07:00",
  "TEMPERATUREC": 25,
  "SUMMARY": "Hot",
  "Wind": 35
}
```

The JSON property naming policy:

* Works in both directions, for serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes.

## Exclude selected properties

To exclude individual properties from serialization and deserialization, use [[JsonIgnoreAttribute]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute). For example:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    [JsonIgnore]
    public int WindSpeed { get; set; }
}

JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

## Exclude read-only properties

Set <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties?displayProperty=fullName> to true:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    IgnoreReadOnlyProperties = true
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example class to serialize:

```csharp
class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public int WindSpeed { get; private set; }
}

JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
}
```

## Exclude null value properties

Set <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=fullName> to true:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    IgnoreNullValues = true
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example object to serialize:

|Property |Value  |
|---------|---------|
| Date    | 8/1/2019 12:00:00 AM -07:00|
| TemperatureC| 0 |
| Summary| null|

JSON output:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25
}
```

## Case-insensitive property matching

Set [JsonSerializerOptions.PropertyNameCaseInsensitive](xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive) to true:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
json = JsonSerializer.Serialize(weatherForecast, options);
```

Example of camel case JSON:

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

### Exclude properties of derived classes

Include a type parameter when calling the [Serialize](xref:System.Text.Json.JsonSerializer.Serialize*) method:

```csharp
string json = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
```

Suppose you have a `WeatherForecast` class and a derived class `WeatherForecastWithWind`:

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

If the type of the `weatherForecast` object is `WeatherForecastWithWind`, Serialize(weatherForecast) produces JSON with the extra property:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot",
  "WindSpeed": 35
}
```

Serialize<WeatherForecast>(weatherForecast) omits the extra property:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureC": 25,
  "Summary": "Hot"
}
```

## Additional resources

* [System.Text.Json overview](json-serialization-overview.md)
