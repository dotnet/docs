---
title: "Migrate from Newtonsoft.Json to System.Text.Json - .NET"
description: "Learn about the differences between Newtonsoft.Json and System.Text.Json and how to migrate to System.Text.Json."
no-loc: [System.Text.Json, Newtonsoft.Json]
ms.date: 02/11/2025
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
zone_pivot_groups: dotnet-version
ms.custom: copilot-scenario-highlight
---

# Migrate from Newtonsoft.Json to System.Text.Json

This article shows how to migrate from [Newtonsoft.Json](https://www.newtonsoft.com/json) to <xref:System.Text.Json?displayProperty=fullName>.

The `System.Text.Json` namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON). The `System.Text.Json` library is included in the runtime for .NET Core 3.1 and later versions. For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

* .NET Standard 2.0 and later versions
* .NET Framework 4.6.2 and later versions
* .NET Core 2.0, 2.1, and 2.2

> [!TIP]
> You can use AI assistance to [migrate from `Newtonsoft.Json`](#use-github-copilot-to-migrate).

`System.Text.Json` focuses primarily on performance, security, and standards compliance. It has some key differences in default behavior and doesn't aim to have feature parity with `Newtonsoft.Json`. For some scenarios, `System.Text.Json` currently has no built-in functionality, but there are recommended workarounds. For other scenarios, workarounds are impractical.

The `System.Text.Json` team is investing in adding the features that are most often requested. If your application depends on a missing feature, consider [filing an issue](https://github.com/dotnet/runtime/issues/new) in the dotnet/runtime GitHub repository to find out if support for your scenario can be added.

Most of this article is about how to use the <xref:System.Text.Json.JsonSerializer> API, but it also includes guidance on how to use the <xref:System.Text.Json.JsonDocument> (which represents the Document Object Model or DOM), <xref:System.Text.Json.Utf8JsonReader>, and <xref:System.Text.Json.Utf8JsonWriter> types.

In Visual Basic, you can't use <xref:System.Text.Json.Utf8JsonReader>, which also means you can't write custom converters. Most of the workarounds presented here require that you write custom converters. You can write a custom converter in C# and register it in a Visual Basic project. For more information, see [Visual Basic support](visual-basic-support.md).

## Table of differences

The following table lists `Newtonsoft.Json` features and `System.Text.Json` equivalents. The equivalents fall into the following categories:

* ✔️ Supported by built-in functionality. Getting similar behavior from `System.Text.Json` might require the use of an attribute or global option.
* ⚠️ Not supported, but workaround is possible. The workarounds are [custom converters](converters-how-to.md), which might not provide complete parity with `Newtonsoft.Json` functionality. For some of these, sample code is provided as examples. If you rely on these `Newtonsoft.Json` features, migration will require modifications to your .NET object models or other code changes.
* ❌ Not supported, and workaround is not practical or possible. If you rely on these `Newtonsoft.Json` features, migration will not be possible without significant changes.

| Newtonsoft.Json feature                               | System.Text.Json equivalent |
|-------------------------------------------------------|-----------------------------|
| Case-insensitive deserialization by default           | ✔️ [PropertyNameCaseInsensitive global setting](#case-insensitive-deserialization) |
| Camel-case property names                             | ✔️ [PropertyNamingPolicy global setting](customize-properties.md#use-a-built-in-naming-policy) |
| Snake-case property names                             | ✔️ [Snake case naming policy](#snake-case-naming-policy)|
| Minimal character escaping                            | ✔️ [Strict character escaping, configurable](#minimal-character-escaping) |
| `NullValueHandling.Ignore` global setting             | ✔️ [DefaultIgnoreCondition global option](ignore-properties.md#ignore-all-null-value-properties) |
| Allow comments                                        | ✔️ [ReadCommentHandling global setting](#comments) |
| Allow trailing commas                                 | ✔️ [AllowTrailingCommas global setting](#trailing-commas) |
| Custom converter registration                         | ✔️ [Order of precedence differs](#converter-registration-precedence) |
| Default maximum depth 64, configurable                | ✔️ [Default maximum depth 64, configurable](#maximum-depth) |
| `PreserveReferencesHandling` global setting           | ✔️ [ReferenceHandling global setting](#preserve-object-references-and-handle-loops) |
| Serialize or deserialize numbers in quotes            | ✔️ [NumberHandling global setting, [JsonNumberHandling] attribute](#allow-or-write-numbers-in-quotes) |
| Deserialize to immutable classes and structs          | ✔️ [JsonConstructor, C# 9 Records](#deserialize-to-immutable-classes-and-structs) |
| Support for fields                                    | ✔️ [IncludeFields global setting, [JsonInclude] attribute](#public-and-non-public-fields) |
| `DefaultValueHandling` global setting                 | ✔️ [DefaultIgnoreCondition global setting](#conditionally-ignore-a-property) |
| `NullValueHandling` setting on `[JsonProperty]`       | ✔️ [JsonIgnore attribute](#conditionally-ignore-a-property)  |
| `DefaultValueHandling` setting on `[JsonProperty]`    | ✔️ [JsonIgnore attribute](#conditionally-ignore-a-property)  |
| Deserialize `Dictionary` with non-string key          | ✔️ [Supported](#dictionary-with-non-string-key) |
| Support for non-public property setters and getters   | ✔️ [JsonInclude attribute](#non-public-property-setters-and-getters) |
| `[JsonConstructor]` attribute                         | ✔️ [[JsonConstructor] attribute](#specify-constructor-to-use-when-deserializing) |
| `ReferenceLoopHandling` global setting                | ✔️ [ReferenceHandling global setting](#preserve-object-references-and-handle-loops) |
| Callbacks                                             | ✔️ [Callbacks](#callbacks) |
| NaN, Infinity, -Infinity                              | ✔️ [Supported](#nan-infinity--infinity) |
| `Required` setting on `[JsonProperty]` attribute      | ✔️ [[JsonRequired] attribute and C# required modifier](#required-properties) |
| `DefaultContractResolver` to ignore properties        | ✔️ [DefaultJsonTypeInfoResolver class](#conditionally-ignore-a-property) |
| Polymorphic serialization                             | ✔️ [[JsonDerivedType] attribute](#polymorphic-serialization) |
| Polymorphic deserialization                           | ✔️ [Type discriminator on [JsonDerivedType] attribute](#polymorphic-deserialization) |
| Deserialize string enum value                         | ✔️ [Deserialize string enum values](#deserialize-string-enum-values) |
| `MissingMemberHandling` global setting                | ✔️ [Handle missing members](#handle-missing-members) |
| Populate properties without setters                   | ✔️ [Populate properties without setters](#populate-properties-without-setters) |
| `ObjectCreationHandling` global setting               | ✔️ [Reuse rather than replace properties](#reuse-rather-than-replace-properties) |
| Support for a broad range of types                    | ⚠️ [Some types require custom converters](#types-without-built-in-support) |
| Deserialize inferred type to `object` properties      | ⚠️ [Not supported, workaround, sample](#deserialization-of-object-properties) |
| Deserialize JSON `null` literal to non-nullable value types | ⚠️ [Not supported, workaround, sample](#deserialize-null-to-non-nullable-type) |
| `DateTimeZoneHandling`, `DateFormatString` settings   | ⚠️ [Not supported, workaround, sample](#specify-date-format) |
| `JsonConvert.PopulateObject` method                   | ⚠️ [Not supported, workaround](#populate-existing-objects) |
| Support for `System.Runtime.Serialization` attributes | ⚠️ [Not supported, workaround, sample](#systemruntimeserialization-attributes) |
| `JsonObjectAttribute`                                 | ⚠️ [Not supported, workaround](#jsonobjectattribute) |
| Allow property names without quotes                   | ❌ [Not supported by design](#json-strings-property-names-and-string-values) |
| Allow single quotes around string values              | ❌ [Not supported by design](#json-strings-property-names-and-string-values) |
| Allow non-string JSON values for string properties    | ❌ [Not supported by design](#non-string-values-for-string-properties) |
| `TypeNameHandling.All` global setting                 | ❌ [Not supported by design](#typenamehandlingall-not-supported) |
| Support for `JsonPath` queries                        | ❌ [Not supported](#json-path-queries-not-supported) |
| Configurable limits                                   | ❌ [Not supported](#some-limits-not-configurable) |

This is not an exhaustive list of `Newtonsoft.Json` features. The list includes many of the scenarios that have been requested in [GitHub issues](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json) or [StackOverflow](https://stackoverflow.com/questions/tagged/system.text.json) posts. If you implement a workaround for one of the scenarios listed here that doesn't currently have sample code, and if you want to share your solution, select **This page** in the **Feedback** section at the bottom of this page. That creates an issue in this documentation's GitHub repo and lists it in the **Feedback** section on this page too.

## Differences in default behavior

<xref:System.Text.Json?displayProperty=fullName> is strict by default and avoids any guessing or interpretation on the caller's behalf, emphasizing deterministic behavior. The library is intentionally designed this way for performance and security. `Newtonsoft.Json` is flexible by default. This fundamental difference in design is behind many of the following specific differences in default behavior.

### Case-insensitive deserialization

During deserialization, `Newtonsoft.Json` does case-insensitive property name matching by default. The <xref:System.Text.Json?displayProperty=fullName> default is case-sensitive, which gives better performance since it's doing an exact match. For information about how to do case-insensitive matching, see [Case-insensitive property matching](character-casing.md).

If you're using `System.Text.Json` indirectly by using ASP.NET Core, you don't need to do anything to get behavior like `Newtonsoft.Json`. ASP.NET Core specifies the settings for camel-casing property names and case-insensitive matching when it uses `System.Text.Json`.

ASP.NET Core also enables deserializing [quoted numbers](#allow-or-write-numbers-in-quotes) by default.

### Minimal character escaping

During serialization, `Newtonsoft.Json` is relatively permissive about letting characters through without escaping them. That is, it doesn't replace them with `\uxxxx` where `xxxx` is the character's code point. Where it does escape them, it does so by emitting a `\` before the character (for example, `"` becomes `\"`). <xref:System.Text.Json?displayProperty=fullName> escapes more characters by default to provide defense-in-depth protections against cross-site scripting (XSS) or information-disclosure attacks and does so by using the six-character sequence. `System.Text.Json` escapes all non-ASCII characters by default, so you don't need to do anything if you're using `StringEscapeHandling.EscapeNonAscii` in `Newtonsoft.Json`. `System.Text.Json` also escapes HTML-sensitive characters, by default. For information about how to override the default `System.Text.Json` behavior, see [Customize character encoding](character-encoding.md).

### Comments

During deserialization, `Newtonsoft.Json` ignores comments in the JSON by default. The <xref:System.Text.Json?displayProperty=fullName> default is to throw exceptions for comments because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't include them. For information about how to allow comments, see [Allow comments and trailing commas](invalid-json.md).

### Trailing commas

During deserialization, `Newtonsoft.Json` ignores trailing commas by default. It also ignores multiple trailing commas (for example, `[{"Color":"Red"},{"Color":"Green"},,]`). The <xref:System.Text.Json?displayProperty=fullName> default is to throw exceptions for trailing commas because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't allow them. For information about how to make `System.Text.Json` accept them, see [Allow comments and trailing commas](invalid-json.md). There's no way to allow multiple trailing commas.

### Converter registration precedence

The `Newtonsoft.Json` registration precedence for custom converters is as follows:

* Attribute on property
* Attribute on type
* [Converters](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonSerializerSettings_Converters.htm) collection

This order means that a custom converter in the `Converters` collection is overridden by a converter that is registered by applying an attribute at the type level. Both of those registrations are overridden by an attribute at the property level.

The <xref:System.Text.Json?displayProperty=fullName> registration precedence for custom converters is different:

* Attribute on property
* <xref:System.Text.Json.JsonSerializerOptions.Converters> collection
* Attribute on type

The difference here is that a custom converter in the `Converters` collection overrides an attribute at the type level. The intention behind this order of precedence is to make run-time changes override design-time choices. There's no way to change the precedence.

For more information about custom converter registration, see [Register a custom converter](converters-how-to.md#register-a-custom-converter).

### Maximum depth

The latest version of `Newtonsoft.Json` has a maximum depth limit of 64 by default. <xref:System.Text.Json?displayProperty=fullName> also has a default limit of 64, and it's configurable by setting <xref:System.Text.Json.JsonSerializerOptions.MaxDepth?displayProperty=nameWithType>.

If you're using `System.Text.Json` indirectly by using ASP.NET Core, the default maximum depth limit is 32. The default value is the same as for model binding and is set in the [JsonOptions class](https://github.com/dotnet/aspnetcore/blob/1f56888ea03f6a113587a6c4ac4d8b2ded326ffa/src/Mvc/Mvc.Core/src/JsonOptions.cs#L17-L20).

### JSON strings (property names and string values)

During deserialization, `Newtonsoft.Json` accepts property names surrounded by double quotes, single quotes, or without quotes. It accepts string values surrounded by double quotes or single quotes. For example, `Newtonsoft.Json` accepts the following JSON:

```json
{
  "name1": "value",
  'name2': "value",
  name3: 'value'
}
```

`System.Text.Json` only accepts property names and string values in double quotes because that format is required by the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification and is the only format considered valid JSON.

A value enclosed in single quotes results in a [JsonException](xref:System.Text.Json.JsonException) with the following message:

```output
''' is an invalid start of a value.
```

### Non-string values for string properties

`Newtonsoft.Json` accepts non-string values, such as a number or the literals `true` and `false`, for deserialization to properties of type string. Here's an example of JSON that `Newtonsoft.Json` successfully deserializes to the following class:

```json
{
  "String1": 1,
  "String2": true,
  "String3": false
}
```

```csharp
public class ExampleClass
{
    public string String1 { get; set; }
    public string String2 { get; set; }
    public string String3 { get; set; }
}
```

`System.Text.Json` doesn't deserialize non-string values into string properties. A non-string value received for a string field results in a [JsonException](xref:System.Text.Json.JsonException) with the following message:

```output
The JSON value could not be converted to System.String.
```

## Scenarios using JsonSerializer

Some of the following scenarios aren't supported by built-in functionality, but workarounds are possible. The workarounds are [custom converters](converters-how-to.md), which may not provide complete parity with `Newtonsoft.Json` functionality. For some of these, sample code is provided as examples. If you rely on these `Newtonsoft.Json` features, migration will require modifications to your .NET object models or other code changes.

For some of the following scenarios, workarounds are not practical or possible. If you rely on these `Newtonsoft.Json` features, migration will not be possible without significant changes.

### Allow or write numbers in quotes

`Newtonsoft.Json` can serialize or deserialize numbers represented by JSON strings (surrounded by quotes). For example, it can accept: `{"DegreesCelsius":"23"}` instead of `{"DegreesCelsius":23}`. To enable that behavior in <xref:System.Text.Json?displayProperty=fullName>, set <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.JsonNumberHandling.WriteAsString> or <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>, or use the [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute) attribute.

If you're using `System.Text.Json` indirectly by using ASP.NET Core, you don't need to do anything to get behavior like `Newtonsoft.Json`. ASP.NET Core specifies [web defaults](configure-options.md#web-defaults-for-jsonserializeroptions) when it uses `System.Text.Json`, and web defaults allow quoted numbers.

For more information, see [Allow or write numbers in quotes](invalid-json.md).

### Specify constructor to use when deserializing

The `Newtonsoft.Json` `[JsonConstructor]` attribute lets you specify which constructor to call when deserializing to a POCO.

`System.Text.Json` also has a [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute. For more information, see [Immutable types and Records](immutability.md).

### Conditionally ignore a property

`Newtonsoft.Json` has several ways to conditionally ignore a property on serialization or deserialization:

* `DefaultContractResolver` lets you select properties to include or ignore, based on arbitrary criteria.
* The `NullValueHandling` and `DefaultValueHandling` settings on `JsonSerializerSettings` let you specify that all null-value or default-value properties should be ignored.
* The `NullValueHandling` and `DefaultValueHandling` settings on the `[JsonProperty]` attribute let you specify individual properties that should be ignored when set to null or the default value.

<xref:System.Text.Json?displayProperty=fullName> provides the following ways to ignore properties or fields while serializing:

* The [[JsonIgnore]](ignore-properties.md#ignore-individual-properties) attribute on a property causes the property to be omitted from the JSON during serialization.
* The [IgnoreReadOnlyProperties](ignore-properties.md#ignore-all-read-only-properties) global option lets you ignore all read-only properties.
* If you're [including fields](fields.md), the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields%2A?displayProperty=nameWithType> global option lets you ignore all read-only fields.
* The `DefaultIgnoreCondition` global option lets you [ignore all value type properties that have default values](ignore-properties.md#ignore-all-default-value-properties), or [ignore all reference type properties that have null values](ignore-properties.md#ignore-all-null-value-properties).

In addition, in .NET 7 and later versions, you can customize the JSON contract to ignore properties based on arbitrary criteria. For more information, see [Custom contracts](custom-contracts.md).

### Public and non-public fields

`Newtonsoft.Json` can serialize and deserialize fields as well as properties.

In <xref:System.Text.Json>, use the <xref:System.Text.Json.JsonSerializerOptions.IncludeFields?displayProperty=nameWithType> global setting or the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to include public fields when serializing or deserializing. For an example, see [Include fields](fields.md).

### Preserve object references and handle loops

By default, `Newtonsoft.Json` serializes by value. For example, if an object contains two properties that contain a reference to the same `Person` object, the values of that `Person` object's properties are duplicated in the JSON.

`Newtonsoft.Json` has a `PreserveReferencesHandling` setting on `JsonSerializerSettings` that lets you serialize by reference:

* An identifier metadata is added to the JSON created for the first `Person` object.
* The JSON that is created for the second `Person` object contains a reference to that identifier instead of property values.

`Newtonsoft.Json` also has a `ReferenceLoopHandling` setting that lets you ignore circular references rather than throw an exception.

To preserve references and handle circular references in <xref:System.Text.Json?displayProperty=fullName>, set <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A>. The `ReferenceHandler.Preserve` setting is equivalent to `PreserveReferencesHandling` = `PreserveReferencesHandling.All` in `Newtonsoft.Json`.

The `ReferenceHandler.IgnoreCycles` option has behavior similar to Newtonsoft.Json `ReferenceLoopHandling.Ignore`. One difference is that the System.Text.Json implementation replaces reference loops with the `null` JSON token instead of ignoring the object reference. For more information, see [Ignore circular references](preserve-references.md#ignore-circular-references).

Like the Newtonsoft.Json [ReferenceResolver](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonSerializer_ReferenceResolver.htm), the <xref:System.Text.Json.Serialization.ReferenceResolver?displayProperty=fullName> class defines the behavior of preserving references on serialization and deserialization. Create a derived class to specify custom behavior. For an example, see [GuidReferenceResolver](https://github.com/dotnet/docs/blob/main/docs/standard/serialization/system-text-json/snippets/how-to-contd/csharp/GuidReferenceResolverExample.cs).

Some related `Newtonsoft.Json` features aren't supported:

* [JsonPropertyAttribute.IsReference](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_IsReference.htm)
* [JsonPropertyAttribute.ReferenceLoopHandling](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_ReferenceLoopHandling.htm)

For more information, see [Preserve references and handle circular references](preserve-references.md).

### Dictionary with non-string key

Both `Newtonsoft.Json` and `System.Text.Json` support collections of type `Dictionary<TKey, TValue>`. For information about supported key types, see [Supported key types](supported-types.md#supported-key-types).

> [!CAUTION]
> Deserializing to a `Dictionary<TKey, TValue>` where `TKey` is typed as anything other than `string` could introduce a security vulnerability in the consuming application. For more information, see [dotnet/runtime#4761](https://github.com/dotnet/runtime/issues/4761).

### Types without built-in support

<xref:System.Text.Json?displayProperty=fullName> doesn't provide built-in support for the following types:

* <xref:System.Data.DataTable> and related types (for more information, see [Supported types](supported-types.md#systemdata-namespace))
* <xref:System.Dynamic.ExpandoObject>
* <xref:System.TimeZoneInfo>
* <xref:System.Numerics.BigInteger>
* <xref:System.DBNull>
* <xref:System.Type>
* <xref:System.ValueTuple> and its associated generic types

Custom converters can be implemented for types that don't have built-in support.

### Polymorphic serialization

`Newtonsoft.Json` automatically does polymorphic serialization. Starting in .NET 7, <xref:System.Text.Json?displayProperty=fullName> supports polymorphic serialization through the <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> attribute. For more information, see [Serialize properties of derived classes](polymorphism.md).

### Polymorphic deserialization

`Newtonsoft.Json` has a `TypeNameHandling` setting that adds type-name metadata to the JSON while serializing. It uses the metadata while deserializing to do polymorphic deserialization. Starting in .NET 7, <xref:System.Text.Json?displayProperty=fullName> relies on type discriminator information to perform polymorphic deserialization. This metadata is emitted in the JSON and then used during deserialization to determine whether to deserialize to the base type or a derived type. For more information, see [Serialize properties of derived classes](polymorphism.md).

To support polymorphic deserialization in older .NET versions, create a converter like the example in [How to write custom converters](converters-how-to.md#support-polymorphic-deserialization).

### Deserialize string enum values

By default, System.Text.Json doesn't support deserializing string enum values, whereas `Newtonsoft.Json` does. For example, the following code throws a <xref:System.Text.Json.JsonException>:

```csharp
string json = "{ \"Text\": \"Hello\", \"Enum\": \"Two\" }";
var _ = JsonSerializer.Deserialize<MyObj>(json); // Throws exception.

class MyObj
{
    public string Text { get; set; } = "";
    public MyEnum Enum { get; set; }
}

enum MyEnum
{
    One,
    Two,
    Three
}
```

However, you can enable deserialization of string enum values by using the <xref:System.Text.Json.Serialization.JsonStringEnumConverter> converter. For more information, see [Enums as strings](customize-properties.md#enums-as-strings).

### Deserialization of object properties

When `Newtonsoft.Json` deserializes to <xref:System.Object>, it:

* Infers the type of primitive values in the JSON payload (other than `null`) and returns the stored `string`, `long`, `double`, `boolean`, or `DateTime` as a boxed object. *Primitive values* are single JSON values such as a JSON number, string, `true`, `false`, or `null`.
* Returns a `JObject` or `JArray` for complex values in the JSON payload. *Complex values* are collections of JSON key-value pairs within braces (`{}`) or lists of values within brackets (`[]`). The properties and values within the braces or brackets can have additional properties or values.
* Returns a null reference when the payload has the `null` JSON literal.

<xref:System.Text.Json?displayProperty=fullName> stores a boxed `JsonElement` for both primitive and complex values whenever deserializing to <xref:System.Object>, for example:

* An `object` property.
* An `object` dictionary value.
* An `object` array value.
* A root `object`.

However, `System.Text.Json` treats `null` the same as `Newtonsoft.Json` and returns a null reference when the payload has the `null` JSON literal in it.

To implement type inference for `object` properties, create a converter like the example in [How to write custom converters](converters-how-to.md#deserialize-inferred-types-to-object-properties).

### Deserialize null to non-nullable type

`Newtonsoft.Json` doesn't throw an exception in the following scenario:

* `NullValueHandling` is set to `Ignore`, and
* During deserialization, the JSON contains a null value for a non-nullable value type.

In the same scenario, <xref:System.Text.Json?displayProperty=fullName> does throw an exception. (The corresponding null-handling setting in `System.Text.Json` is <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> = `true`.)

If you own the target type, the best workaround is to make the property in question nullable (for example, change `int` to `int?`).

Another workaround is to make a converter for the type, such as the following example that handles null values for `DateTimeOffset` types:

:::code language="csharp" source="snippets/how-to/csharp/DateTimeOffsetNullHandlingConverter.cs":::

Register this custom converter by [using an attribute on the property](converters-how-to.md#registration-sample---jsonconverter-on-a-property) or by [adding the converter](converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.

**Note:** The preceding converter **handles null values differently** than `Newtonsoft.Json` does for POCOs that specify default values. For example, suppose the following code represents your target object:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithDefault":::

And suppose the following JSON is deserialized by using the preceding converter:

```json
{
  "Date": null,
  "TemperatureCelsius": 25,
  "Summary": null
}
```

After deserialization, the `Date` property has 1/1/0001 (`default(DateTimeOffset)`), that is, the value set in the constructor is overwritten. Given the same POCO and JSON, `Newtonsoft.Json` deserialization would leave 1/1/2001 in the `Date` property.

### Deserialize to immutable classes and structs

`Newtonsoft.Json` can deserialize to immutable classes and structs because it can use constructors that have parameters.

In <xref:System.Text.Json?displayProperty=fullName>, use the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute to specify use of a parameterized constructor. Records in C# 9 are also immutable and are supported as deserialization targets. For more information, see [Immutable types and Records](immutability.md).

### Required properties

In `Newtonsoft.Json`, you specify that a property is required by setting `Required` on the `[JsonProperty]` attribute. `Newtonsoft.Json` throws an exception if no value is received in the JSON for a property marked as required.

Starting in .NET 7, you can use the C# `required` modifier or the <xref:System.Text.Json.Serialization.JsonRequiredAttribute> attribute on a required property. System.Text.Json throws an exception if the JSON payload doesn't contain a value for the marked property. For more information, see [Required properties](required-properties.md).

### Specify date format

`Newtonsoft.Json` provides several ways to control how properties of `DateTime` and `DateTimeOffset` types are serialized and deserialized:

* The `DateTimeZoneHandling` setting can be used to serialize all `DateTime` values as UTC dates.
* The `DateFormatString` setting and `DateTime` converters can be used to customize the format of date strings.

<xref:System.Text.Json> supports ISO 8601-1:2019, including the RFC 3339 profile. This format is widely adopted, unambiguous, and makes round trips precisely. To use any other format, create a custom converter. For example, the following converters serialize and deserialize JSON that uses Unix epoch format with or without a time zone offset (values such as `/Date(1590863400000-0700)/` or `/Date(1590863400000)/`):

:::code language="csharp" source="snippets/how-to-contd/csharp/CustomConverterUnixEpochDate.cs" id="ConverterOnly":::

:::code language="csharp" source="snippets/how-to-contd/csharp/CustomConverterUnixEpochDateNoZone.cs" id="ConverterOnly":::

For more information, see [DateTime and DateTimeOffset support in System.Text.Json](../../datetime/system-text-json-support.md).

### Callbacks

`Newtonsoft.Json` lets you execute custom code at several points in the serialization or deserialization process:

* OnDeserializing (when beginning to deserialize an object)
* OnDeserialized (when finished deserializing an object)
* OnSerializing (when beginning to serialize an object)
* OnSerialized (when finished serializing an object)

System.Text.Json exposes the same notifications during serialization and deserialization. To use them, implement one or more of the following interfaces from the <xref:System.Text.Json.Serialization> namespace:

* <xref:System.Text.Json.Serialization.IJsonOnDeserializing>
* <xref:System.Text.Json.Serialization.IJsonOnDeserialized>
* <xref:System.Text.Json.Serialization.IJsonOnSerializing>
* <xref:System.Text.Json.Serialization.IJsonOnSerialized>

Here's an example that checks for a null property and writes messages at start and end of serialization and deserialization:

:::code language="csharp" source="snippets/how-to-6-0/csharp/Callbacks.cs":::

The `OnDeserializing` code doesn't have access to the new POCO instance. To manipulate the new POCO instance at the start of deserialization, put that code in the POCO constructor.

### Non-public property setters and getters

`Newtonsoft.Json` can use private and internal property setters and getters via the `JsonProperty` attribute.

<xref:System.Text.Json?displayProperty=fullName> supports private and internal property setters and getters via the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute. For sample code, see [Non-public property accessors](immutability.md#non-public-members-and-property-accessors).

### Populate existing objects

The `JsonConvert.PopulateObject` method in `Newtonsoft.Json` deserializes a JSON document to an existing instance of a class, instead of creating a new instance. <xref:System.Text.Json?displayProperty=fullName> always creates a new instance of the target type by using the default public parameterless constructor. Custom converters can deserialize to an existing instance.

### Reuse rather than replace properties

Starting in .NET 8, System.Text.Json supports reusing initialized properties rather than replacing them. There are some differences in behavior, which you can read about in the [API proposal](https://github.com/dotnet/runtime/issues/78556).

For more information, see [Populate initialized properties](populate-properties.md).

### Populate properties without setters

Starting in .NET 8, System.Text.Json supports populating properties, including those that don't have a setter. For more information, see [Populate initialized properties](populate-properties.md).

### Snake case naming policy

System.Text.Json includes a built-in naming policy for snake case. However, there are some behavior differences with `Newtonsoft.Json` for some inputs. The following table shows some of these differences when converting input using the <xref:System.Text.Json.JsonNamingPolicy.SnakeCaseLower?displayProperty=nameWithType> policy.

| Input           | Newtonsoft.Json result | System.Text.Json result |
|-----------------|------------------------|-------------------------|
| "AB1"           | "a_b1"                 | "ab1"                   |
| "SHA512Managed" | "sh_a512_managed"      | "sha512_managed"        |
| "abc123DEF456"  | "abc123_de_f456"       | "abc123_def456"         |
| "KEBAB-CASE"    | "keba_b-_case"         | "kebab-case"            |

### System.Runtime.Serialization attributes

<xref:System.Runtime.Serialization> attributes such as <xref:System.Runtime.Serialization.DataContractAttribute>, <xref:System.Runtime.Serialization.DataMemberAttribute>, and <xref:System.Runtime.Serialization.IgnoreDataMemberAttribute> let you define a *data contract*. A data contract is a formal agreement between a service and a client that abstractly describes the data to be exchanged. The data contract precisely defines which properties are serialized for exchange.

System.Text.Json doesn't have built-in support for these attributes. However, starting in .NET 7, you can use a [custom type resolver](custom-contracts.md) to add support. For a sample, see [ZCS.DataContractResolver](https://github.com/zcsizmadia/ZCS.DataContractResolver).

### Octal numbers

`Newtonsoft.Json` treats numbers with a leading zero as octal numbers. <xref:System.Text.Json?displayProperty=fullName> doesn't allow leading zeroes because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't allow them.

### Handle missing members

If the JSON that's being deserialized includes properties that are missing in the target type, `Newtonsoft.Json` can be configured to throw exceptions. By default, <xref:System.Text.Json?displayProperty=fullName> ignores extra properties in the JSON, except when you use the [[JsonExtensionData] attribute](handle-overflow.md).

In .NET 8 and later versions, you can set your preference for whether to skip or disallow unmapped JSON properties using one of the following means:

* Apply the <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandlingAttribute> attribute to the type you're deserializing to.
* To set your preference globally, set the <xref:System.Text.Json.JsonSerializerOptions.UnmappedMemberHandling?displayProperty=nameWithType> property. Or, for source generation, set the <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.UnmappedMemberHandling?displayProperty=nameWithType> property and apply the attribute to your <xref:System.Text.Json.Serialization.JsonSerializerContext> class.
* Customize the <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.UnmappedMemberHandling?displayProperty=nameWithType> property.

### JsonObjectAttribute

`Newtonsoft.Json` has an attribute, `JsonObjectAttribute`, that can be applied at the *type level* to control which members are serialized, how `null` values are handled, and whether all members are required. System.Text.Json has no equivalent attribute that can be applied on a type. For some behaviors, such as `null` value handling, you can either configure the same behavior on the global <xref:System.Text.Json.JsonSerializerOptions> or individually on each property.

Consider the following example that uses `Newtonsoft.Json.JsonObjectAttribute` to specify that all `null` properties should be ignored:

```csharp
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Person { ... }
```

In System.Text.Json, you can set the behavior [for all types and properties](ignore-properties.md#ignore-all-null-value-properties):

```csharp
JsonSerializerOptions options = new()
{
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};

string json = JsonSerializer.Serialize<Person>(person, options);
```

Or you can set the behavior [on each property separately](ignore-properties.md#ignore-individual-properties):

```csharp
public class Person
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Age { get; set; }
}
```

Next, consider the following example that uses `Newtonsoft.Json.JsonObjectAttribute` to specify that all member properties must be present in the JSON:

```csharp
[JsonObject(ItemRequired = Required.Always)]
public class Person { ... }
```

You can achieve the same behavior in System.Text.Json by adding the C# `required` modifier or the <xref:System.Text.Json.Serialization.JsonRequiredAttribute> *to each property*. For more information, see [Required properties](required-properties.md).

```csharp
public class Person
{
    [JsonRequired]
    public string? Name { get; set; }

    public required int? Age { get; set; }
}
```

### TraceWriter

`Newtonsoft.Json` lets you debug by using a `TraceWriter` to view logs that are generated by serialization or deserialization. <xref:System.Text.Json?displayProperty=fullName> doesn't do logging.

## JsonDocument and JsonElement compared to JToken (like JObject, JArray)

<xref:System.Text.Json.JsonDocument?displayProperty=fullName> provides the ability to parse and build a **read-only** Document Object Model (DOM) from existing JSON payloads. The DOM provides random access to data in a JSON payload. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.JsonElement> type. The `JsonElement` type provides APIs to convert JSON text to common .NET types. `JsonDocument` exposes a <xref:System.Text.Json.JsonDocument.RootElement> property.

Starting in .NET 6, you can parse and build a **mutable** DOM from existing JSON payloads by using the <xref:System.Text.Json.Nodes.JsonNode> type and other types in the <xref:System.Text.Json.Nodes> namespace. For more information, see [Use `JsonNode`](use-dom.md#use-jsonnode).

### JsonDocument is IDisposable

`JsonDocument` builds an in-memory view of the data into a pooled buffer. Therefore, unlike `JObject` or `JArray` from `Newtonsoft.Json`, the `JsonDocument` type implements `IDisposable` and needs to be used inside a using block. For more information, see [JsonDocument is IDisposable](use-dom.md#jsondocument-is-idisposable).

### JsonDocument is read-only

The <xref:System.Text.Json?displayProperty=fullName> DOM can't add, remove, or modify JSON elements. It's designed this way for performance and to reduce allocations for parsing common JSON payload sizes (that is, < 1 MB).

### JsonElement is a union struct

`JsonDocument` exposes the `RootElement` as a property of type <xref:System.Text.Json.JsonElement>, which is a union struct type that encompasses any JSON element. `Newtonsoft.Json` uses dedicated hierarchical types like `JObject`, `JArray`, `JToken`, and so forth. `JsonElement` is what you can search and enumerate over, and you can use `JsonElement` to materialize JSON elements into .NET types.

Starting in .NET 6, you can use <xref:System.Text.Json.Nodes.JsonNode> type and types in the <xref:System.Text.Json.Nodes> namespace that correspond to `JObject`, `JArray`, and `JToken`. For more information, see [Use `JsonNode`](use-dom.md#use-jsonnode).

### How to search a JsonDocument and JsonElement for sub-elements

Searches for JSON tokens using `JObject` or `JArray` from `Newtonsoft.Json` tend to be relatively fast because they're lookups in some dictionary. By comparison, searches on `JsonElement` require a sequential search of the properties and hence are relatively slow (for example when using `TryGetProperty`). <xref:System.Text.Json?displayProperty=fullName> is designed to minimize initial parse time rather than lookup time. For more information, see [How to search a JsonDocument and JsonElement for sub-elements](use-dom.md#how-to-search-a-jsondocument-and-jsonelement-for-sub-elements).

## Utf8JsonReader vs. JsonTextReader

<xref:System.Text.Json.Utf8JsonReader?displayProperty=fullName> is a high-performance, low allocation, forward-only reader for UTF-8 encoded JSON text, read from a [ReadOnlySpan\<byte>](xref:System.ReadOnlySpan%601) or [ReadOnlySequence\<byte>](xref:System.Buffers.ReadOnlySequence%601). The `Utf8JsonReader` is a low-level type that can be used to build custom parsers and deserializers.

### Utf8JsonReader is a ref struct

The `JsonTextReader` in `Newtonsoft.Json` is a class. The `Utf8JsonReader` type differs in that it's a *ref struct*. For more information, see [ref struct limitations for Utf8JsonReader](use-utf8jsonreader.md#ref-struct-limitations).

### Read null values into nullable value types

`Newtonsoft.Json` provides APIs that return <xref:System.Nullable%601>, such as `ReadAsBoolean`, which handles a `Null` `TokenType` for you by returning a `bool?`. The built-in `System.Text.Json` APIs return only non-nullable value types. For more information, see [Read null values into nullable value types](use-utf8jsonreader.md#read-null-values-into-nullable-value-types).

### Multi-target for reading JSON

If you need to continue to use `Newtonsoft.Json` for certain target frameworks, you can multi-target and have two implementations. However, this is not trivial and would require some `#ifdefs` and source duplication. One way to share as much code as possible is to create a `ref struct` wrapper around <xref:System.Text.Json.Utf8JsonReader> and `Newtonsoft.Json.JsonTextReader`. This wrapper would unify the public surface area while isolating the behavioral differences. This lets you isolate the changes mainly to the construction of the type, along with passing the new type around by reference. This is the pattern that the [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel) library follows:

* [UnifiedJsonReader.JsonTextReader.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonReader.JsonTextReader.cs)
* [UnifiedJsonReader.Utf8JsonReader.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonReader.Utf8JsonReader.cs)

## Utf8JsonWriter vs. JsonTextWriter

<xref:System.Text.Json.Utf8JsonWriter?displayProperty=fullName> is a high-performance way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. The writer is a low-level type that can be used to build custom serializers.

### Write raw values

`Newtonsoft.Json` has a `WriteRawValue` method that writes raw JSON where a value is expected. <xref:System.Text.Json?displayProperty=fullName> has a direct equivalent: <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType>. For more information, see [Write raw JSON](use-utf8jsonwriter.md#write-raw-json).

### Customize JSON format

::: zone pivot="dotnet-9-0"

`JsonTextWriter` includes the following settings, for which <xref:System.Text.Json.Utf8JsonWriter> has no equivalent:

* [QuoteChar](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteChar.htm) - Specifies the character to use to surround string values. `Utf8JsonWriter` always uses double quotes.
* [QuoteName](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteName.htm) - Specifies whether or not to surround property names with quotes. `Utf8JsonWriter` always surrounds them with quotes.

Starting in .NET 9, you can customize the indentation character and size for <xref:System.Text.Json.Utf8JsonWriter> using options exposed by the <xref:System.Text.Json.JsonWriterOptions> struct:

* <xref:System.Text.Json.JsonWriterOptions.IndentCharacter?displayProperty=nameWithType>
* <xref:System.Text.Json.JsonWriterOptions.IndentSize?displayProperty=nameWithType>

::: zone-end

::: zone pivot="dotnet-8-0"

`JsonTextWriter` includes the following settings, for which `Utf8JsonWriter` has no equivalent:

* [Indentation](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_Indentation.htm) - Specifies how many characters to indent. `Utf8JsonWriter` always indents by 2 characters.
* [IndentChar](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_IndentChar.htm) - Specifies the character to use for indentation. `Utf8JsonWriter` always uses whitespace.
* [QuoteChar](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteChar.htm) - Specifies the character to use to surround string values. `Utf8JsonWriter` always uses double quotes.
* [QuoteName](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteName.htm) - Specifies whether or not to surround property names with quotes. `Utf8JsonWriter` always surrounds them with quotes.

::: zone-end

There are no workarounds that would let you customize the JSON produced by `Utf8JsonWriter` in these ways.

### Write Timespan, Uri, or char values

`JsonTextWriter` provides `WriteValue` methods for [TimeSpan](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_18.htm), [Uri](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_22.htm), and [char](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_3.htm) values. `Utf8JsonWriter` doesn't have equivalent methods. Instead, format these values as strings (by calling `ToString()`, for example) and call <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A>.

### Multi-target for writing JSON

If you need to continue to use `Newtonsoft.Json` for certain target frameworks, you can multi-target and have two implementations. However, this is not trivial and would require some `#ifdefs` and source duplication. One way to share as much code as possible is to create a wrapper around <xref:System.Text.Json.Utf8JsonWriter> and `Newtonsoft.Json.JsonTextWriter`. This wrapper would unify the public surface area while isolating the behavioral differences. This lets you isolate the changes mainly to the construction of the type. [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel) library follows:

* [UnifiedJsonWriter.JsonTextWriter.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonWriter.JsonTextWriter.cs)
* [UnifiedJsonWriter.Utf8JsonWriter.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonWriter.Utf8JsonWriter.cs)

## TypeNameHandling.All not supported

The decision to exclude `TypeNameHandling.All`-equivalent functionality from `System.Text.Json` was intentional. Allowing a JSON payload to specify its own type information is a common source of vulnerabilities in web applications. In particular, configuring `Newtonsoft.Json` with `TypeNameHandling.All` allows the remote client to embed an entire executable application within the JSON payload itself, so that during deserialization the web application extracts and runs the embedded code. For more information, see [Friday the 13th JSON attacks PowerPoint](https://www.blackhat.com/docs/us-17/thursday/us-17-Munoz-Friday-The-13th-Json-Attacks.pdf) and [Friday the 13th JSON attacks details](https://www.blackhat.com/docs/us-17/thursday/us-17-Munoz-Friday-The-13th-JSON-Attacks-wp.pdf).

## JSON Path queries not supported

The `JsonDocument` DOM doesn't support querying by using [JSON Path](https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenJsonPath.htm).

In a <xref:System.Text.Json.Nodes.JsonNode> DOM, each `JsonNode` instance has a `GetPath` method that returns a path to that node. But there is no built-in API to handle queries based on JSON Path query strings.

For more information, see the [dotnet/runtime #31068 GitHub issue](https://github.com/dotnet/runtime/issues/31068).

## Some limits not configurable

System.Text.Json sets limits that can't be changed for some values, such as the maximum token size in characters (166 MB) and in base 64 (125 MB). For more information, see [`JsonConstants` in the source code](https://github.com/dotnet/runtime/blob/e5f3fa0ed0f52b5073dbfcc7fa800246b9e17adf/src/libraries/System.Text.Json/src/System/Text/Json/JsonConstants.cs#L75-L78) and GitHub issue [dotnet/runtime #39953](https://github.com/dotnet/runtime/issues/39953).

## NaN, Infinity, -Infinity

Newtonsoft parses `NaN`, `Infinity`, and `-Infinity` JSON string tokens. With System.Text.Json, use <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals?displayProperty=nameWithType>. For information about how to use this setting, see [Allow or write numbers in quotes](invalid-json.md#allow-or-write-numbers-in-quotes).

## Use GitHub Copilot to migrate

You can get coding help from GitHub Copilot to migrate your code from `Newtonsoft.Json` to `System.Text.Json` within your IDE. You can customize the prompt per your requirements.

**Example prompt for Copilot Chat**

```copilot-prompt
convert the following code to use System.Text.Json
Product product = new Product();

product.Name = "Apple";
product.ExpiryDate = new DateTime(2024, 08, 08);
product.Price = 3.99M;
product.Sizes = new string[] { "Small", "Medium", "Large" };

string output = JsonConvert.SerializeObject(product);
Console.WriteLine(output);
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).

## Additional resources

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
