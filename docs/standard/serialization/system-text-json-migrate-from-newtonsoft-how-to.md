---
title: "Migrate from Newtonsoft.Json to System.Text.Json - .NET"
description: "Learn how to migrate from Newtonsoft.Json to System.Text.Json. Includes sample code."
author: tdykstra
ms.author: tdykstra
no-loc: [System.Text.Json, Newtonsoft.Json]
ms.date: 11/30/2021
zone_pivot_groups: dotnet-version
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to migrate from Newtonsoft.Json to System.Text.Json

This article shows how to migrate from [Newtonsoft.Json](https://www.newtonsoft.com/json) to <xref:System.Text.Json>.

The `System.Text.Json` namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON). The `System.Text.Json` library is included in the runtime for [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1) and later versions. For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

* .NET Standard 2.0 and later versions
* .NET Framework 4.7.2 and later versions
* .NET Core 2.0, 2.1, and 2.2

`System.Text.Json` focuses primarily on performance, security, and standards compliance. It has some key differences in default behavior and doesn't aim to have feature parity with `Newtonsoft.Json`. For some scenarios, `System.Text.Json` currently has no built-in functionality, but there are recommended workarounds. For other scenarios, workarounds are impractical.

We're investing in adding the features that have most often been requested. If your application depends on a missing feature, consider [filing an issue](https://github.com/dotnet/runtime/issues/new) in the dotnet/runtime GitHub repository to find out if support for your scenario can be added. See [epic issue #43620](https://github.com/dotnet/runtime/issues/43620) to find out what is already planned.

Most of this article is about how to use the <xref:System.Text.Json.JsonSerializer> API, but it also includes guidance on how to use the <xref:System.Text.Json.JsonDocument> (which represents the Document Object Model or DOM), <xref:System.Text.Json.Utf8JsonReader>, and <xref:System.Text.Json.Utf8JsonWriter> types.

In Visual Basic, you can't use <xref:System.Text.Json.Utf8JsonReader>, which also means you can't write custom converters. Most of the workarounds presented here require that you write custom converters. You can write a custom converter in C# and register it in a Visual Basic project. For more information, see [Visual Basic support](system-text-json-how-to.md#visual-basic-support).

## Table of differences between Newtonsoft.Json and System.Text.Json

The following table lists `Newtonsoft.Json` features and `System.Text.Json` equivalents. The equivalents fall into the following categories:

* Supported by built-in functionality. Getting similar behavior from `System.Text.Json` may require the use of an attribute or global option.
* Not supported, workaround is possible. The workarounds are [custom converters](system-text-json-converters-how-to.md), which may not provide complete parity with `Newtonsoft.Json` functionality. For some of these, sample code is provided as examples. If you rely on these `Newtonsoft.Json` features, migration will require modifications to your .NET object models or other code changes.
* Not supported, workaround is not practical or possible. If you rely on these `Newtonsoft.Json` features, migration will not be possible without significant changes.

::: zone pivot="dotnet-6-0"

| Newtonsoft.Json feature                               | System.Text.Json equivalent |
|-------------------------------------------------------|-----------------------------|
| Case-insensitive deserialization by default           | ✔️ [PropertyNameCaseInsensitive global setting](#case-insensitive-deserialization) |
| Camel-case property names                             | ✔️ [PropertyNamingPolicy global setting](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) |
| Minimal character escaping                            | ✔️ [Strict character escaping, configurable](#minimal-character-escaping) |
| `NullValueHandling.Ignore` global setting             | ✔️ [DefaultIgnoreCondition global option](system-text-json-ignore-properties.md#ignore-all-null-value-properties) |
| Allow comments                                        | ✔️ [ReadCommentHandling global setting](#comments) |
| Allow trailing commas                                 | ✔️ [AllowTrailingCommas global setting](#trailing-commas) |
| Custom converter registration                         | ✔️ [Order of precedence differs](#converter-registration-precedence) |
| No maximum depth by default                           | ✔️ [Default maximum depth 64, configurable](#maximum-depth) |
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
| Support for a broad range of types                    | ⚠️ [Some types require custom converters](#types-without-built-in-support) |
| Polymorphic serialization                             | ⚠️ [Not supported, workaround, sample](#polymorphic-serialization) |
| Polymorphic deserialization                           | ⚠️ [Not supported, workaround, sample](#polymorphic-deserialization) |
| Deserialize inferred type to `object` properties      | ⚠️ [Not supported, workaround, sample](#deserialization-of-object-properties) |
| Deserialize JSON `null` literal to non-nullable value types | ⚠️ [Not supported, workaround, sample](#deserialize-null-to-non-nullable-type) |
| `Required` setting on `[JsonProperty]` attribute        | ⚠️ [Not supported, workaround, sample](#required-properties) |
| `DefaultContractResolver` to ignore properties       | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property) |
| `DateTimeZoneHandling`, `DateFormatString` settings   | ⚠️ [Not supported, workaround, sample](#specify-date-format) |
| `JsonConvert.PopulateObject` method                   | ⚠️ [Not supported, workaround](#populate-existing-objects) |
| `ObjectCreationHandling` global setting               | ⚠️ [Not supported, workaround](#reuse-rather-than-replace-properties) |
| Add to collections without setters                    | ⚠️ [Not supported, workaround](#add-to-collections-without-setters) |
| Snake-case property names                             | ⚠️ [Not supported, workaround](#snake-case-naming-policy)|
| Support for `System.Runtime.Serialization` attributes | ❌ [Not supported](#systemruntimeserialization-attributes) |
| `MissingMemberHandling` global setting                | ❌ [Not supported](#missingmemberhandling) |
| Allow property names without quotes                   | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow single quotes around string values              | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow non-string JSON values for string properties    | ❌ [Not supported](#non-string-values-for-string-properties) |
| `TypeNameHandling.All` global setting                 | ❌ [Not supported](#typenamehandlingall-not-supported) |
| Support for `JsonPath` queries                        | ❌ [Not supported](#json-path-queries-not-supported) |
| Configurable limits                                   | ❌ [Not supported](#some-limits-not-configurable) |
::: zone-end

::: zone pivot="dotnet-5-0"

| Newtonsoft.Json feature                               | System.Text.Json equivalent |
|-------------------------------------------------------|-----------------------------|
| Case-insensitive deserialization by default           | ✔️ [PropertyNameCaseInsensitive global setting](#case-insensitive-deserialization) |
| Camel-case property names                             | ✔️ [PropertyNamingPolicy global setting](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) |
| Minimal character escaping                            | ✔️ [Strict character escaping, configurable](#minimal-character-escaping) |
| `NullValueHandling.Ignore` global setting             | ✔️ [DefaultIgnoreCondition global option](system-text-json-ignore-properties.md#ignore-all-null-value-properties) |
| Allow comments                                        | ✔️ [ReadCommentHandling global setting](#comments) |
| Allow trailing commas                                 | ✔️ [AllowTrailingCommas global setting](#trailing-commas) |
| Custom converter registration                         | ✔️ [Order of precedence differs](#converter-registration-precedence) |
| No maximum depth by default                           | ✔️ [Default maximum depth 64, configurable](#maximum-depth) |
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
| NaN, Infinity, -Infinity                              | ✔️ [Supported](#nan-infinity--infinity) |
| Support for a broad range of types                    | ⚠️ [Some types require custom converters](#types-without-built-in-support) |
| Polymorphic serialization                             | ⚠️ [Not supported, workaround, sample](#polymorphic-serialization) |
| Polymorphic deserialization                           | ⚠️ [Not supported, workaround, sample](#polymorphic-deserialization) |
| Deserialize inferred type to `object` properties      | ⚠️ [Not supported, workaround, sample](#deserialization-of-object-properties) |
| Deserialize JSON `null` literal to non-nullable value types | ⚠️ [Not supported, workaround, sample](#deserialize-null-to-non-nullable-type) |
| `Required` setting on `[JsonProperty]` attribute        | ⚠️ [Not supported, workaround, sample](#required-properties) |
| `DefaultContractResolver` to ignore properties       | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property) |
| `DateTimeZoneHandling`, `DateFormatString` settings   | ⚠️ [Not supported, workaround, sample](#specify-date-format) |
| Callbacks                                             | ⚠️ [Not supported, workaround, sample](#callbacks) |
| `JsonConvert.PopulateObject` method                   | ⚠️ [Not supported, workaround](#populate-existing-objects) |
| `ObjectCreationHandling` global setting               | ⚠️ [Not supported, workaround](#reuse-rather-than-replace-properties) |
| Add to collections without setters                    | ⚠️ [Not supported, workaround](#add-to-collections-without-setters) |
| Snake-case property names                             | ⚠️ [Not supported, workaround](#snake-case-naming-policy)|
| `ReferenceLoopHandling` global setting                | ❌ [Not supported](#preserve-object-references-and-handle-loops) |
| Support for `System.Runtime.Serialization` attributes | ❌ [Not supported](#systemruntimeserialization-attributes) |
| `MissingMemberHandling` global setting                | ❌ [Not supported](#missingmemberhandling) |
| Allow property names without quotes                   | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow single quotes around string values              | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow non-string JSON values for string properties    | ❌ [Not supported](#non-string-values-for-string-properties) |
| `TypeNameHandling.All` global setting                 | ❌ [Not supported](#typenamehandlingall-not-supported) |
| Support for `JsonPath` queries                        | ❌ [Not supported](#json-path-queries-not-supported) |
| Configurable limits                                   | ❌ [Not supported](#some-limits-not-configurable) |
::: zone-end

::: zone pivot="dotnet-core-3-1"

| Newtonsoft.Json feature                               | System.Text.Json equivalent |
|-------------------------------------------------------|-----------------------------|
| Case-insensitive deserialization by default           | ✔️ [PropertyNameCaseInsensitive global setting](#case-insensitive-deserialization) |
| Camel-case property names                             | ✔️ [PropertyNamingPolicy global setting](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) |
| Minimal character escaping                            | ✔️ [Strict character escaping, configurable](#minimal-character-escaping) |
| `NullValueHandling.Ignore` global setting             | ✔️ [IgnoreNullValues global option](system-text-json-ignore-properties.md#ignore-all-null-value-properties) |
| Allow comments                                        | ✔️ [ReadCommentHandling global setting](#comments) |
| Allow trailing commas                                 | ✔️ [AllowTrailingCommas global setting](#trailing-commas) |
| Custom converter registration                         | ✔️ [Order of precedence differs](#converter-registration-precedence) |
| No maximum depth by default                           | ✔️ [Default maximum depth 64, configurable](#maximum-depth) |
| Support for a broad range of types                    | ⚠️ [Some types require custom converters](#types-without-built-in-support) |
| Deserialize strings as numbers                        | ⚠️ [Not supported, workaround, sample](#allow-or-write-numbers-in-quotes) |
| Deserialize `Dictionary` with non-string key          | ⚠️ [Not supported, workaround, sample](#dictionary-with-non-string-key) |
| Polymorphic serialization                             | ⚠️ [Not supported, workaround, sample](#polymorphic-serialization) |
| Polymorphic deserialization                           | ⚠️ [Not supported, workaround, sample](#polymorphic-deserialization) |
| Deserialize inferred type to `object` properties      | ⚠️ [Not supported, workaround, sample](#deserialization-of-object-properties) |
| Deserialize JSON `null` literal to non-nullable value types | ⚠️ [Not supported, workaround, sample](#deserialize-null-to-non-nullable-type) |
| Deserialize to immutable classes and structs          | ⚠️ [Not supported, workaround, sample](#deserialize-to-immutable-classes-and-structs) |
| `[JsonConstructor]` attribute                         | ⚠️ [Not supported, workaround, sample](#specify-constructor-to-use-when-deserializing) |
| `Required` setting on `[JsonProperty]` attribute        | ⚠️ [Not supported, workaround, sample](#required-properties) |
| `NullValueHandling` setting on `[JsonProperty]` attribute | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property)  |
| `DefaultValueHandling` setting on `[JsonProperty]` attribute | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property)  |
| `DefaultValueHandling` global setting                 | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property) |
| `DefaultContractResolver` to ignore properties       | ⚠️ [Not supported, workaround, sample](#conditionally-ignore-a-property) |
| `DateTimeZoneHandling`, `DateFormatString` settings   | ⚠️ [Not supported, workaround, sample](#specify-date-format) |
| Callbacks                                             | ⚠️ [Not supported, workaround, sample](#callbacks) |
| Support for public and non-public fields              | ⚠️ [Not supported, workaround](#public-and-non-public-fields) |
| Support for non-public property setters and getters   | ⚠️ [Not supported, workaround](#non-public-property-setters-and-getters) |
| `JsonConvert.PopulateObject` method                   | ⚠️ [Not supported, workaround](#populate-existing-objects) |
| `ObjectCreationHandling` global setting               | ⚠️ [Not supported, workaround](#reuse-rather-than-replace-properties) |
| Add to collections without setters                    | ⚠️ [Not supported, workaround](#add-to-collections-without-setters) |
| Snake-case property names                             | ⚠️ [Not supported, workaround](#snake-case-naming-policy)|
| NaN, Infinity, -Infinity                              | ⚠️ [Not supported, workaround](#nan-infinity--infinity) |
| `PreserveReferencesHandling` global setting           | ❌ [Not supported](#preserve-object-references-and-handle-loops) |
| `ReferenceLoopHandling` global setting                | ❌ [Not supported](#preserve-object-references-and-handle-loops) |
| Support for `System.Runtime.Serialization` attributes | ❌ [Not supported](#systemruntimeserialization-attributes) |
| `MissingMemberHandling` global setting                | ❌ [Not supported](#missingmemberhandling) |
| Allow property names without quotes                   | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow single quotes around string values              | ❌ [Not supported](#json-strings-property-names-and-string-values) |
| Allow non-string JSON values for string properties    | ❌ [Not supported](#non-string-values-for-string-properties) |
| `TypeNameHandling.All` global setting                 | ❌ [Not supported](#typenamehandlingall-not-supported) |
| Support for `JsonPath` queries                        | ❌ [Not supported](#json-path-queries-not-supported) |
| Configurable limits                                   | ❌ [Not supported](#some-limits-not-configurable) |
::: zone-end

This is not an exhaustive list of `Newtonsoft.Json` features. The list includes many of the scenarios that have been requested in [GitHub issues](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json) or [StackOverflow](https://stackoverflow.com/questions/tagged/system.text.json) posts. If you implement a workaround for one of the scenarios listed here that doesn't currently have sample code, and if you want to share your solution, select **This page** in the **Feedback** section at the bottom of this page. That creates an issue in this documentation's GitHub repo and lists it in the **Feedback** section on this page too.

## Differences in default JsonSerializer behavior compared to Newtonsoft.Json

<xref:System.Text.Json> is strict by default and avoids any guessing or interpretation on the caller's behalf, emphasizing deterministic behavior. The library is intentionally designed this way for performance and security. `Newtonsoft.Json` is flexible by default. This fundamental difference in design is behind many of the following specific differences in default behavior.

### Case-insensitive deserialization

During deserialization, `Newtonsoft.Json` does case-insensitive property name matching by default. The <xref:System.Text.Json> default is case-sensitive, which gives better performance since it's doing an exact match. For information about how to do case-insensitive matching, see [Case-insensitive property matching](system-text-json-character-casing.md).

If you're using `System.Text.Json` indirectly by using ASP.NET Core, you don't need to do anything to get behavior like `Newtonsoft.Json`. ASP.NET Core specifies the settings for [camel-casing property names](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) and case-insensitive matching when it uses `System.Text.Json`.

::: zone pivot="dotnet-5-0,dotnet-6-0"
ASP.NET Core also enables deserializing [quoted numbers](#allow-or-write-numbers-in-quotes) by default.
::: zone-end

### Minimal character escaping

During serialization, `Newtonsoft.Json` is relatively permissive about letting characters through without escaping them. That is, it doesn't replace them with `\uxxxx` where `xxxx` is the character's code point. Where it does escape them, it does so by emitting a `\` before the character (for example, `"` becomes `\"`). <xref:System.Text.Json> escapes more characters by default to provide defense-in-depth protections against cross-site scripting (XSS) or information-disclosure attacks and does so by using the six-character sequence. `System.Text.Json` escapes all non-ASCII characters by default, so you don't need to do anything if you're using `StringEscapeHandling.EscapeNonAscii` in `Newtonsoft.Json`. `System.Text.Json` also escapes HTML-sensitive characters, by default. For information about how to override the default `System.Text.Json` behavior, see [Customize character encoding](system-text-json-character-encoding.md).

### Comments

During deserialization, `Newtonsoft.Json` ignores comments in the JSON by default. The <xref:System.Text.Json> default is to throw exceptions for comments because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't include them. For information about how to allow comments, see [Allow comments and trailing commas](system-text-json-invalid-json.md).

### Trailing commas

During deserialization, `Newtonsoft.Json` ignores trailing commas by default. It also ignores multiple trailing commas (for example, `[{"Color":"Red"},{"Color":"Green"},,]`). The <xref:System.Text.Json> default is to throw exceptions for trailing commas because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't allow them. For information about how to make `System.Text.Json` accept them, see [Allow comments and trailing commas](system-text-json-invalid-json.md). There's no way to allow multiple trailing commas.

### Converter registration precedence

The `Newtonsoft.Json` registration precedence for custom converters is as follows:

* Attribute on property
* Attribute on type
* [Converters](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonSerializerSettings_Converters.htm) collection

This order means that a custom converter in the `Converters` collection is overridden by a converter that is registered by applying an attribute at the type level. Both of those registrations are overridden by an attribute at the property level.

The <xref:System.Text.Json> registration precedence for custom converters is different:

* Attribute on property
* <xref:System.Text.Json.JsonSerializerOptions.Converters> collection
* Attribute on type

The difference here is that a custom converter in the `Converters` collection overrides an attribute at the type level. The intention behind this order of precedence is to make run-time changes override design-time choices. There's no way to change the precedence.

For more information about custom converter registration, see [Register a custom converter](system-text-json-converters-how-to.md#register-a-custom-converter).

### Maximum depth

The latest version of `Newtonsoft.Json` has a maximum depth limit of 64 by default. <xref:System.Text.Json> also has a default limit of 64, and it's configurable by setting <xref:System.Text.Json.JsonSerializerOptions.MaxDepth?displayProperty=nameWithType>.

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

Some of the following scenarios aren't supported by built-in functionality, but workarounds are possible. The workarounds are [custom converters](system-text-json-converters-how-to.md), which may not provide complete parity with `Newtonsoft.Json` functionality. For some of these, sample code is provided as examples. If you rely on these `Newtonsoft.Json` features, migration will require modifications to your .NET object models or other code changes.

For some of the following scenarios, workarounds are not practical or possible. If you rely on these `Newtonsoft.Json` features, migration will not be possible without significant changes.

### Allow or write numbers in quotes

::: zone pivot="dotnet-5-0,dotnet-6-0"
`Newtonsoft.Json` can serialize or deserialize numbers represented by JSON strings (surrounded by quotes). For example, it can accept: `{"DegreesCelsius":"23"}` instead of `{"DegreesCelsius":23}`. To enable that behavior in <xref:System.Text.Json>, set <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.JsonNumberHandling.WriteAsString> or <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString>, or use the [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute) attribute.

If you're using `System.Text.Json` indirectly by using ASP.NET Core, you don't need to do anything to get behavior like `Newtonsoft.Json`. ASP.NET Core specifies [web defaults](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions) when it uses `System.Text.Json`, and web defaults allow quoted numbers.

For more information, see [Allow or write numbers in quotes](system-text-json-invalid-json.md).
::: zone-end

::: zone pivot="dotnet-core-3-1"
`Newtonsoft.Json` can serialize or deserialize numbers represented by JSON strings (surrounded by quotes). For example, it can accept: `{"DegreesCelsius":"23"}` instead of `{"DegreesCelsius":23}`. To enable that behavior in <xref:System.Text.Json> in .NET Core 3.1, implement a custom converter like the following example. The converter handles properties defined as `long`:

* It serializes them as JSON strings.
* It accepts JSON numbers and numbers within quotes while deserializing.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/LongToStringConverter.cs":::

Register this custom converter by [using an attribute](system-text-json-converters-how-to.md#registration-sample---jsonconverter-on-a-property) on individual `long` properties or by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.
::: zone-end

### Specify constructor to use when deserializing

The `Newtonsoft.Json` `[JsonConstructor]` attribute lets you specify which constructor to call when deserializing to a POCO.

::: zone pivot="dotnet-5-0,dotnet-6-0"
`System.Text.Json` also has a [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute. For more information, see [Immutable types and Records](system-text-json-immutability.md).
::: zone-end

::: zone pivot="dotnet-core-3-1"
<xref:System.Text.Json> in .NET Core 3.1 supports only parameterless constructors. As a workaround, you can call whichever constructor you need in a custom converter. See the example for [Deserialize to immutable classes and structs](#deserialize-to-immutable-classes-and-structs).
::: zone-end

### Conditionally ignore a property

`Newtonsoft.Json` has several ways to conditionally ignore a property on serialization or deserialization:

* `DefaultContractResolver` lets you select properties to include or ignore, based on arbitrary criteria.
* The `NullValueHandling` and `DefaultValueHandling` settings on `JsonSerializerSettings` let you specify that all null-value or default-value properties should be ignored.
* The `NullValueHandling` and `DefaultValueHandling` settings on the `[JsonProperty]` attribute let you specify individual properties that should be ignored when set to null or the default value.

::: zone pivot="dotnet-5-0,dotnet-6-0"

<xref:System.Text.Json> provides the following ways to ignore properties or fields while serializing:

* The [[JsonIgnore]](system-text-json-ignore-properties.md#ignore-individual-properties) attribute on a property causes the property to be omitted from the JSON during serialization.
* The [IgnoreReadOnlyProperties](system-text-json-ignore-properties.md#ignore-all-read-only-properties) global option lets you ignore all read-only properties.
* If you're [Including fields](system-text-json-how-to.md#include-fields), the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields%2A?displayProperty=nameWithType> global option lets you ignore all read-only fields.
* The `DefaultIgnoreCondition` global option lets you [ignore all value type properties that have default values](system-text-json-ignore-properties.md#ignore-all-default-value-properties), or [ignore all reference type properties that have null values](system-text-json-ignore-properties.md#ignore-all-null-value-properties).

::: zone-end

::: zone pivot="dotnet-core-3-1"

<xref:System.Text.Json> in .NET Core 3.1 provides the following ways to ignore properties while serializing:

* The [[JsonIgnore]](system-text-json-ignore-properties.md#ignore-individual-properties) attribute on a property causes the property to be omitted from the JSON during serialization.
* The [IgnoreNullValues](system-text-json-ignore-properties.md#ignore-all-null-value-properties) global option lets you ignore all null-value properties. `IgnoreNullValues` is deprecated in .NET 5 and later versions, so it isn't shown by IntelliSense. For the current way to ignore null values, see [how to ignore all null-value properties in .NET 5 and later](system-text-json-ignore-properties.md?pivots=dotnet-5-0#ignore-all-null-value-properties).
* The [IgnoreReadOnlyProperties](system-text-json-ignore-properties.md#ignore-all-read-only-properties) global option lets you ignore all read-only properties.
::: zone-end

These options **don't** let you:

::: zone pivot="dotnet-5-0,dotnet-6-0"

* Ignore selected properties based on arbitrary criteria evaluated at run time.

::: zone-end

::: zone pivot="dotnet-core-3-1"

* Ignore all properties that have the default value for the type.
* Ignore selected properties that have the default value for the type.
* Ignore selected properties if their value is null.
* Ignore selected properties based on arbitrary criteria evaluated at run time.

::: zone-end

For that functionality, you can write a custom converter. Here's a sample POCO and a custom converter for it that illustrates this approach:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecastRuntimeIgnoreConverter.cs":::

The converter causes the `Summary` property to be omitted from serialization if its value is null, an empty string, or "N/A".

Register this custom converter by [using an attribute on the class](system-text-json-converters-how-to.md#registration-sample---jsonconverter-on-a-type) or by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.

This approach requires additional logic if:

* The POCO includes complex properties.
* You need to handle attributes such as `[JsonIgnore]` or options such as custom encoders.

### Public and non-public fields

`Newtonsoft.Json` can serialize and deserialize fields as well as properties.

::: zone pivot="dotnet-5-0,dotnet-6-0"
In <xref:System.Text.Json>, use the <xref:System.Text.Json.JsonSerializerOptions.IncludeFields?displayProperty=nameWithType> global setting or the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to include public fields when serializing or deserializing. For an example, see [Include fields](system-text-json-how-to.md#include-fields).
::: zone-end

::: zone pivot="dotnet-core-3-1"
<xref:System.Text.Json> in .NET Core 3.1 only works with public properties. Custom converters can provide this functionality.
::: zone-end

### Preserve object references and handle loops

By default, `Newtonsoft.Json` serializes by value. For example, if an object contains two properties that contain a reference to the same `Person` object, the values of that `Person` object's properties are duplicated in the JSON.

`Newtonsoft.Json` has a `PreserveReferencesHandling` setting on `JsonSerializerSettings` that lets you serialize by reference:

* An identifier metadata is added to the JSON created for the first `Person` object.
* The JSON that is created for the second `Person` object contains a reference to that identifier instead of property values.

`Newtonsoft.Json` also has a `ReferenceLoopHandling` setting that lets you ignore circular references rather than throw an exception.

::: zone pivot="dotnet-5-0,dotnet-6-0"
To preserve references and handle circular references in <xref:System.Text.Json>, set <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A>. The `ReferenceHandler.Preserve` setting is equivalent to `PreserveReferencesHandling` = `PreserveReferencesHandling.All` in `Newtonsoft.Json`.

::: zone-end
::: zone pivot="dotnet-6-0"
The `ReferenceHandler.IgnoreCycles` option has behavior similar to Newtonsoft.Json `ReferenceLoopHandling.Ignore`. One difference is that the System.Text.Json implementation replaces reference loops with the `null` JSON token instead of ignoring the object reference. For more information, see [Ignore circular references](system-text-json-preserve-references.md#ignore-circular-references).
::: zone-end
::: zone pivot="dotnet-5-0,dotnet-6-0"

Like the Newtonsoft.Json [ReferenceResolver](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonSerializer_ReferenceResolver.htm), the <xref:System.Text.Json.Serialization.ReferenceResolver?displayProperty=fullName> class defines the behavior of preserving references on serialization and deserialization. Create a derived class to specify custom behavior. For an example, see [GuidReferenceResolver](https://github.com/dotnet/docs/blob/9d5e88edbd7f12be463775ffebbf07ac8415fe18/docs/standard/serialization/snippets/system-text-json-how-to-5-0/csharp/GuidReferenceResolverExample.cs).

Some related `Newtonsoft.Json` features are not supported:

::: zone-end
::: zone pivot="dotnet-6-0"

* [JsonPropertyAttribute.IsReference](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_IsReference.htm)
* [JsonPropertyAttribute.ReferenceLoopHandling](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_ReferenceLoopHandling.htm)

For more information, see [Preserve references and handle circular references](system-text-json-preserve-references.md).
::: zone-end
::: zone pivot="dotnet-5-0"

* [JsonPropertyAttribute.IsReference](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_IsReference.htm)
* [JsonPropertyAttribute.ReferenceLoopHandling](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonPropertyAttribute_ReferenceLoopHandling.htm)
* [JsonSerializerSettings.ReferenceLoopHandling](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonSerializerSettings_ReferenceLoopHandling.htm)

For more information, see [Preserve references and handle circular references](system-text-json-preserve-references.md).
::: zone-end

::: zone pivot="dotnet-core-3-1"
<xref:System.Text.Json> in .NET Core 3.1 only supports serialization by value and throws an exception for circular references.
::: zone-end

### Dictionary with non-string key

::: zone pivot="dotnet-5-0,dotnet-6-0"
Both `Newtonsoft.Json` and `System.Text.Json` support collections of type `Dictionary<TKey, TValue>`. However, in `System.Text.Json`, `TKey` must be a primitive type, not a custom type. For more information, see [Supported key types](system-text-json-supported-collection-types.md#supported-key-types).

> [!CAUTION]
> Deserializing to a `Dictionary<TKey, TValue>` where `TKey` is typed as anything other than `string` could introduce a security vulnerability in the consuming application. For more information, see [dotnet/runtime#4761](https://github.com/dotnet/runtime/issues/4761).

::: zone-end

::: zone pivot="dotnet-core-3-1"
`Newtonsoft.Json` supports collections of type `Dictionary<TKey, TValue>`. The built-in support for dictionary collections in <xref:System.Text.Json> in .NET Core 3.1 is limited to `Dictionary<string, TValue>`. That is, the key must be a string.

To support a dictionary with an integer or some other type as the key in .NET Core 3.1, create a converter like the example in [How to write custom converters](system-text-json-converters-how-to.md#support-dictionary-with-non-string-key).
::: zone-end

### Types without built-in support

<xref:System.Text.Json> doesn't provide built-in support for the following types:

* <xref:System.Data.DataTable> and related types (for more information, see [Supported collection types](system-text-json-supported-collection-types.md#systemdata-namespace))
::: zone pivot="dotnet-5-0"

* F# types, such as [discriminated unions](../../fsharp/language-reference/discriminated-unions.md). [Record types](../../fsharp/language-reference/records.md) and [anonymous record types](../../fsharp/language-reference/anonymous-records.md) are treated as immutable POCOs and thus are supported.
::: zone-end
::: zone pivot="dotnet-core-3-1"

* F# types, such as [discriminated unions](../../fsharp/language-reference/discriminated-unions.md), [record types](../../fsharp/language-reference/records.md), and [anonymous record types](../../fsharp/language-reference/anonymous-records.md).
::: zone-end
* <xref:System.Dynamic.ExpandoObject>
* <xref:System.TimeZoneInfo>
* <xref:System.Numerics.BigInteger>
* <xref:System.TimeSpan>
* <xref:System.DBNull>
* <xref:System.Type>
* <xref:System.ValueTuple> and its associated generic types

Custom converters can be implemented for types that don't have built-in support.

### Polymorphic serialization

`Newtonsoft.Json` automatically does polymorphic serialization. For information about the limited polymorphic serialization capabilities of <xref:System.Text.Json>, see [Serialize properties of derived classes](system-text-json-polymorphism.md).

The workaround described there is to define properties that may contain derived classes as type `object`. If that isn't possible, another option is to create a converter with a `Write` method for the whole inheritance type hierarchy like the example in [How to write custom converters](system-text-json-converters-how-to.md#support-polymorphic-deserialization).

### Polymorphic deserialization

`Newtonsoft.Json` has a `TypeNameHandling` setting that adds type name metadata to the JSON while serializing. It uses the metadata while deserializing to do polymorphic deserialization. <xref:System.Text.Json> can do a limited range of [polymorphic serialization](system-text-json-polymorphism.md) but not polymorphic deserialization.

To support polymorphic deserialization, create a converter like the example in [How to write custom converters](system-text-json-converters-how-to.md#support-polymorphic-deserialization).

### Deserialization of object properties

When `Newtonsoft.Json` deserializes to <xref:System.Object>, it:

* Infers the type of primitive values in the JSON payload (other than `null`) and returns the stored `string`, `long`, `double`, `boolean`, or `DateTime` as a boxed object. *Primitive values* are single JSON values such as a JSON number, string, `true`, `false`, or `null`.
* Returns a `JObject` or `JArray` for complex values in the JSON payload. *Complex values* are collections of JSON key-value pairs within braces (`{}`) or lists of values within brackets (`[]`). The properties and values within the braces or brackets can have additional properties or values.
* Returns a null reference when the payload has the `null` JSON literal.

<xref:System.Text.Json> stores a boxed `JsonElement` for both primitive and complex values whenever deserializing to <xref:System.Object>, for example:

* An `object` property.
* An `object` dictionary value.
* An `object` array value.
* A root `object`.

However, `System.Text.Json` treats `null` the same as `Newtonsoft.Json` and returns a null reference when the payload has the `null` JSON literal in it.

To implement type inference for `object` properties, create a converter like the example in [How to write custom converters](system-text-json-converters-how-to.md#deserialize-inferred-types-to-object-properties).

### Deserialize null to non-nullable type

`Newtonsoft.Json` doesn't throw an exception in the following scenario:

* `NullValueHandling` is set to `Ignore`, and
* During deserialization, the JSON contains a null value for a non-nullable value type.

In the same scenario, <xref:System.Text.Json> does throw an exception. (The corresponding null-handling setting in `System.Text.Json` is <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> = `true`.)

If you own the target type, the best workaround is to make the property in question nullable (for example, change `int` to `int?`).

Another workaround is to make a converter for the type, such as the following example that handles null values for `DateTimeOffset` types:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DateTimeOffsetNullHandlingConverter.cs":::

Register this custom converter by [using an attribute on the property](system-text-json-converters-how-to.md#registration-sample---jsonconverter-on-a-property) or by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.

**Note:** The preceding converter **handles null values differently** than `Newtonsoft.Json` does for POCOs that specify default values. For example, suppose the following code represents your target object:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithDefault":::

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

::: zone pivot="dotnet-5-0,dotnet-6-0"
In <xref:System.Text.Json>, use the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute to specify use of a parameterized constructor. Records in C# 9 are also immutable and are supported as deserialization targets. For more information, see [Immutable types and Records](system-text-json-immutability.md).
::: zone-end

::: zone pivot="dotnet-core-3-1"
<xref:System.Text.Json> in .NET Core 3.1 supports only public parameterless constructors. As a workaround, you can call a constructor with parameters in a custom converter.

Here's an immutable struct with multiple constructor parameters:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/ImmutablePoint.cs" id="ImmutablePoint":::

And here's a converter that serializes and deserializes this struct:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/ImmutablePointConverter.cs":::

Register this custom converter by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.

For an example of a similar converter that handles open generic properties, see the [built-in converter for key-value pairs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/JsonValueConverterKeyValuePair.cs).
::: zone-end

### Required properties

In `Newtonsoft.Json`, you specify that a property is required by setting `Required` on the `[JsonProperty]` attribute. `Newtonsoft.Json` throws an exception if no value is received in the JSON for a property marked as required.

<xref:System.Text.Json> doesn't throw an exception if no value is received for one of the properties of the target type. For example, if you have a `WeatherForecast` class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::

The following JSON is deserialized without error:

```json
{
    "TemperatureCelsius": 25,
    "Summary": "Hot"
}
```

To make deserialization fail if no `Date` property is in the JSON, choose one of the following options:

* Implement a custom converter.
* Implement an [`OnDeserialized` callback (.NET 6 and later)](system-text-json-migrate-from-newtonsoft-how-to.md?pivots=dotnet-6-0#callbacks).

The following sample converter code throws an exception if the `Date` property isn't set after deserialization is complete:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecastRequiredPropertyConverter.cs":::

Register this custom converter by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters?displayProperty=nameWithType> collection.

This pattern of recursively calling the converter requires that you register the converter by using <xref:System.Text.Json.JsonSerializerOptions>, not by using an attribute. If you register the converter by using an attribute, the custom converter recursively calls into itself. The result is an infinite loop that ends in a stack overflow exception.

When you register the converter by using the options object, avoid an infinite loop by not passing in the options object when recursively calling <xref:System.Text.Json.JsonSerializer.Serialize%2A> or <xref:System.Text.Json.JsonSerializer.Deserialize%2A>. The options object contains the <xref:System.Text.Json.JsonSerializerOptions.Converters%2A> collection. If you pass it in to `Serialize` or `Deserialize`, the custom converter calls into itself, making an infinite loop that results in a stack overflow exception. If the default options are not feasible, create a new instance of the options with the settings that you need. This approach will be slow since each new instance caches independently.

There is an alternative pattern that can use `JsonConverterAttribute` registration on the class to be converted. In this approach, the converter code calls `Serialize` or `Deserialize` on a class that derives from the class to be converted. The derived class doesn't have a `JsonConverterAttribute` applied to it. In the following example of this alternative:

* `WeatherForecastWithRequiredPropertyConverterAttribute` is the class to be deserialized and has the `JsonConverterAttribute` applied to it.
* `WeatherForecastWithoutRequiredPropertyConverterAttribute` is the derived class that doesn't have the converter attribute.
* The code in the converter calls `Serialize`and `Deserialize` on `WeatherForecastWithoutRequiredPropertyConverterAttribute` to avoid an infinite loop. There is a performance cost to this approach on serialization due to an extra object instantiation and copying of property values.

Here are the `WeatherForecast*` types:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithReqPptyConverterAttr":::

And here is the converter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecastRequiredPropertyConverterForAttributeRegistration.cs":::

The required properties converter would require additional logic if you need to handle attributes such as [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) or different options, such as custom encoders. Also, the example code doesn't handle properties for which a default value is set in the constructor. And this approach doesn't differentiate between the following scenarios:

* A property is missing from the JSON.
* A property for a non-nullable type is present in the JSON, but the value is the default for the type, such as zero for an `int`.
* A property for a nullable value type is present in the JSON, but the value is null.

**Note:** If you're using System.Text.Json from an ASP.NET Core controller, you might be able to use a [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) attribute on properties of the model class instead of implementing a System.Text.Json converter.

### Specify date format

`Newtonsoft.Json` provides several ways to control how properties of `DateTime` and `DateTimeOffset` types are serialized and deserialized:

* The `DateTimeZoneHandling` setting can be used to serialize all `DateTime` values as UTC dates.
* The `DateFormatString` setting and `DateTime` converters can be used to customize the format of date strings.

<xref:System.Text.Json> supports ISO 8601-1:2019, including the RFC 3339 profile. This format is widely adopted, unambiguous, and makes round trips precisely. To use any other format, create a custom converter. For example, the following converters serialize and deserialize JSON that uses Unix epoch format with or without a time zone offset (values such as `/Date(1590863400000-0700)/` or `/Date(1590863400000)/`):

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterUnixEpochDate.cs" id="ConverterOnly":::

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/CustomConverterUnixEpochDateNoZone.cs" id="ConverterOnly":::

For more information, see [DateTime and DateTimeOffset support in System.Text.Json](../datetime/system-text-json-support.md).

### Callbacks

`Newtonsoft.Json` lets you execute custom code at several points in the serialization or deserialization process:

* OnDeserializing (when beginning to deserialize an object)
* OnDeserialized (when finished deserializing an object)
* OnSerializing (when beginning to serialize an object)
* OnSerialized (when finished serializing an object)

::: zone pivot="dotnet-6-0"

System.Text.Json exposes the same notifications during serialization and deserialization. To use them, implement one or more of the following interfaces from the <xref:System.Text.Json.Serialization> namespace:

* <xref:System.Text.Json.Serialization.IJsonOnDeserializing>
* <xref:System.Text.Json.Serialization.IJsonOnDeserialized>
* <xref:System.Text.Json.Serialization.IJsonOnSerializing>
* <xref:System.Text.Json.Serialization.IJsonOnSerialized>

Here's an example that checks for a null property and writes messages at start and end of serialization and deserialization:

:::code language="csharp" source="snippets/system-text-json-how-to-6-0/csharp/Callbacks.cs":::

The `OnDeserializing` code doesn't have access to the new POCO instance. To manipulate the new POCO instance at the start of deserialization, put that code in the POCO constructor.

::: zone-end

::: zone pivot="dotnet-core-3-1,dotnet-5-0"
In <xref:System.Text.Json>, you can simulate callbacks by writing a custom converter. The following example shows a custom converter for a POCO. The converter includes code that displays a message at each point that corresponds to a `Newtonsoft.Json` callback.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecastCallbacksConverter.cs":::

Register this custom converter by [adding the converter](system-text-json-converters-how-to.md#registration-sample---converters-collection) to the <xref:System.Text.Json.JsonSerializerOptions.Converters> collection.

If you use a custom converter that follows the preceding sample:

* The `OnDeserializing` code doesn't have access to the new POCO instance. To manipulate the new POCO instance at the start of deserialization, put that code in the POCO constructor.
* Avoid an infinite loop by registering the converter in the options object and not passing in the options object when recursively calling `Serialize` or `Deserialize`.

For more information about custom converters that recursively call `Serialize` or `Deserialize`, see the [Required properties](#required-properties) section earlier in this article.

::: zone-end

### Non-public property setters and getters

`Newtonsoft.Json` can use private and internal property setters and getters via the `JsonProperty` attribute.

::: zone pivot="dotnet-5-0,dotnet-6-0"
<xref:System.Text.Json> supports private and internal property setters and getters via the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute. For sample code, see [Non-public property accessors](system-text-json-immutability.md).
::: zone-end

::: zone pivot="dotnet-core-3-1"
<xref:System.Text.Json> in .NET Core 3.1 supports only public setters. Custom converters can provide this functionality.
::: zone-end

### Populate existing objects

The `JsonConvert.PopulateObject` method in `Newtonsoft.Json` deserializes a JSON document to an existing instance of a class, instead of creating a new instance. <xref:System.Text.Json> always creates a new instance of the target type by using the default public parameterless constructor. Custom converters can deserialize to an existing instance.

### Reuse rather than replace properties

The `Newtonsoft.Json` `ObjectCreationHandling` setting lets you specify that objects in properties should be reused rather than replaced during deserialization. <xref:System.Text.Json> always replaces objects in properties.  Custom converters can provide this functionality.

### Add to collections without setters

During deserialization, `Newtonsoft.Json` adds objects to a collection even if the property has no setter. <xref:System.Text.Json> ignores properties that don't have setters. Custom converters can provide this functionality.

### Snake case naming policy

The only built-in property naming policy in System.Text.Json is for [camel case](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names). `Newtonsoft.Json` can convert property names to snake case. A [custom naming policy](system-text-json-customize-properties.md#use-a-custom-json-property-naming-policy) can provide this functionality. For more information, see GitHub issue [dotnet/runtime #782](https://github.com/dotnet/runtime/issues/782).

### System.Runtime.Serialization attributes

<xref:System.Text.Json> doesn't support attributes from the `System.Runtime.Serialization` namespace, such as `DataMemberAttribute` and `IgnoreDataMemberAttribute`.

### Octal numbers

`Newtonsoft.Json` treats numbers with a leading zero as octal numbers. <xref:System.Text.Json> doesn't allow leading zeroes because the [RFC 8259](https://tools.ietf.org/html/rfc8259) specification doesn't allow them.

### MissingMemberHandling

`Newtonsoft.Json` can be configured to throw exceptions during deserialization if the JSON includes properties that are missing in the target type. <xref:System.Text.Json> ignores extra properties in the JSON, except when you use the [[JsonExtensionData] attribute](system-text-json-handle-overflow.md). There's no workaround for the missing member feature.

### TraceWriter

`Newtonsoft.Json` lets you debug by using a `TraceWriter` to view logs that are generated by serialization or deserialization. <xref:System.Text.Json> doesn't do logging.

## JsonDocument and JsonElement compared to JToken (like JObject, JArray)

<xref:System.Text.Json.JsonDocument?displayProperty=fullName> provides the ability to parse and build a **read-only** Document Object Model (DOM) from existing JSON payloads. The DOM provides random access to data in a JSON payload. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.JsonElement> type. The `JsonElement` type provides APIs to convert JSON text to common .NET types. `JsonDocument` exposes a <xref:System.Text.Json.JsonDocument.RootElement> property.

Starting in .NET 6, you can parse and build a **mutable** DOM from existing JSON payloads by using the <xref:System.Text.Json.Nodes.JsonNode> type and other types in the <xref:System.Text.Json.Nodes> namespace. For more information, see [Use `JsonNode`](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#use-jsonnode).

### JsonDocument is IDisposable

`JsonDocument` builds an in-memory view of the data into a pooled buffer. Therefore, unlike `JObject` or `JArray` from `Newtonsoft.Json`, the `JsonDocument` type implements `IDisposable` and needs to be used inside a using block. For more information, see [JsonDocument is IDisposable](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md?pivots=dotnet-6-0#jsondocument-is-idisposable).

### JsonDocument is read-only

The <xref:System.Text.Json> DOM can't add, remove, or modify JSON elements. It's designed this way for performance and to reduce allocations for parsing common JSON payload sizes (that is, < 1 MB).

:::zone pivot="dotnet-core-3-1,dotnet-5-0"
If your scenario currently uses a modifiable DOM, one of the following workarounds might be feasible:

* To build a `JsonDocument` from scratch (that is, without passing in an existing JSON payload to the `Parse` method), write the JSON text by using the `Utf8JsonWriter` and parse the output from that to make a new `JsonDocument`.
* To modify an existing `JsonDocument`, use it to write JSON text, making changes while you write, and parse the output from that to make a new `JsonDocument`.
* To merge existing JSON documents, equivalent to the `JObject.Merge` or `JContainer.Merge` APIs from `Newtonsoft.Json`, see [this GitHub issue](https://github.com/dotnet/corefx/issues/42466#issuecomment-570475853).

These workarounds are necessary only for versions of System.Text.Json earlier than 6.0. In 6.0 you can use [JsonNode](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md?pivots=dotnet-6-0#use-jsonnode) to work with a mutable DOM.
:::zone-end

### JsonElement is a union struct

`JsonDocument` exposes the `RootElement` as a property of type <xref:System.Text.Json.JsonElement>, which is a union struct type that encompasses any JSON element. `Newtonsoft.Json` uses dedicated hierarchical types like `JObject`,`JArray`, `JToken`, and so forth. `JsonElement` is what you can search and enumerate over, and you can use `JsonElement` to materialize JSON elements into .NET types.

Starting in .NET 6, you can use <xref:System.Text.Json.Nodes.JsonNode> type and types in the <xref:System.Text.Json.Nodes> namespace that correspond to `JObject`,`JArray`, and `JToken`. For more information, see [Use `JsonNode`](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#use-jsonnode).

### How to search a JsonDocument and JsonElement for sub-elements

Searches for JSON tokens using `JObject` or `JArray` from `Newtonsoft.Json` tend to be relatively fast because they're lookups in some dictionary. By comparison, searches on `JsonElement` require a sequential search of the properties and hence are relatively slow (for example when using `TryGetProperty`). <xref:System.Text.Json> is designed to minimize initial parse time rather than lookup time. For more information, see [How to search a JsonDocument and JsonElement for sub-elements](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#how-to-search-a-jsondocument-and-jsonelement-for-sub-elements).

## Utf8JsonReader compared to JsonTextReader

<xref:System.Text.Json.Utf8JsonReader?displayProperty=fullName> is a high-performance, low allocation, forward-only reader for UTF-8 encoded JSON text, read from a [ReadOnlySpan\<byte>](xref:System.ReadOnlySpan%601) or [ReadOnlySequence\<byte>](xref:System.Buffers.ReadOnlySequence%601). The `Utf8JsonReader` is a low-level type that can be used to build custom parsers and deserializers.

### Utf8JsonReader is a ref struct

The `JsonTextReader` in `Newtonsoft.Json` is a class. The `Utf8JsonReader` type differs in that it's a *ref struct*. For more information, see [Utf8JsonReader is a ref struct](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#utf8jsonreader-is-a-ref-struct).

### Read null values into nullable value types

`Newtonsoft.Json` provides APIs that return <xref:System.Nullable%601>, such as `ReadAsBoolean`, which handles a `Null` `TokenType` for you by returning a `bool?`. The built-in `System.Text.Json` APIs return only non-nullable value types. For more information, see [Read null values into nullable value types](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#read-null-values-into-nullable-value-types).

### Multi-targeting

If you need to continue to use `Newtonsoft.Json` for certain target frameworks, you can multi-target and have two implementations. However, this is not trivial and would require some `#ifdefs` and source duplication. One way to share as much code as possible is to create a `ref struct` wrapper around `Utf8JsonReader` and `Newtonsoft.Json` `JsonTextReader`. This wrapper would unify the public surface area while isolating the behavioral differences. This lets you isolate the changes mainly to the construction of the type, along with passing the new type around by reference. This is the pattern that the [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel/3.1.0/) library follows:

* [UnifiedJsonReader.JsonTextReader.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonReader.JsonTextReader.cs)
* [UnifiedJsonReader.Utf8JsonReader.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonReader.Utf8JsonReader.cs)

## Utf8JsonWriter compared to JsonTextWriter

<xref:System.Text.Json.Utf8JsonWriter?displayProperty=fullName> is a high-performance way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. The writer is a low-level type that can be used to build custom serializers.

### Write raw values

::: zone pivot="dotnet-6-0"

The `Newtonsoft.Json` `WriteRawValue` method writes raw JSON where a value is expected. <xref:System.Text.Json> has a direct equivalent: <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType>. For more information, see [Write raw JSON](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#write-raw-json).

::: zone-end

::: zone pivot="dotnet-5-0,dotnet-core-3-1"

The `Newtonsoft.Json` `WriteRawValue` method writes raw JSON where a value is expected. There is an equivalent method, <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType>, in .NET 6. For more information, see [Write raw JSON](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md?pivots=dotnet-6-0#write-raw-json).

For versions earlier than 6.0, <xref:System.Text.Json?displayProperty=fullName> has no equivalent method for writing raw JSON. However, the following workaround ensures only valid JSON is written:

```csharp
using JsonDocument doc = JsonDocument.Parse(string);
doc.WriteTo(writer);
```

::: zone-end

### Customize JSON format

`JsonTextWriter` includes the following settings, for which `Utf8JsonWriter` has no equivalent:

* [Indentation](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_Indentation.htm) - Specifies how many characters to indent. `Utf8JsonWriter` always does 2-character indentation.
* [IndentChar](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_IndentChar.htm) - Specifies the character to use for indentation.  `Utf8JsonWriter` always uses whitespace.
* [QuoteChar](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteChar.htm) - Specifies the character to use to surround string values.  `Utf8JsonWriter` always uses double quotes.
* [QuoteName](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_JsonTextWriter_QuoteName.htm) - Specifies whether or not to surround property names with quotes.  `Utf8JsonWriter` always surrounds them with quotes.

There are no workarounds that would let you customize the JSON produced by `Utf8JsonWriter` in these ways.

### Write Timespan, Uri, or char values

`JsonTextWriter` provides `WriteValue` methods for [TimeSpan](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_18.htm), [Uri](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_22.htm), and [char](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonTextWriter_WriteValue_3.htm) values. `Utf8JsonWriter` doesn't have equivalent methods. Instead, format these values as strings (by calling `ToString()`, for example) and call <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A>.

### Multi-targeting

If you need to continue to use `Newtonsoft.Json` for certain target frameworks, you can multi-target and have two implementations. However, this is not trivial and would require some `#ifdefs` and source duplication. One way to share as much code as possible is to create a wrapper around `Utf8JsonWriter` and `Newtonsoft` `JsonTextWriter`. This wrapper would unify the public surface area while isolating the behavioral differences. This lets you isolate the changes mainly to the construction of the type. [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel/3.1.0/) library follows:

* [UnifiedJsonWriter.JsonTextWriter.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonWriter.JsonTextWriter.cs)
* [UnifiedJsonWriter.Utf8JsonWriter.cs](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/installer/managed/Microsoft.Extensions.DependencyModel/UnifiedJsonWriter.Utf8JsonWriter.cs)

## TypeNameHandling.All not supported

The decision to exclude `TypeNameHandling.All`-equivalent functionality from `System.Text.Json` was intentional. Allowing a JSON payload to specify its own type information is a common source of vulnerabilities in web applications. In particular, configuring `Newtonsoft.Json` with `TypeNameHandling.All` allows the remote client to embed an entire executable application within the JSON payload itself, so that during deserialization the web application extracts and runs the embedded code. For more information, see [Friday the 13th JSON attacks PowerPoint](https://www.blackhat.com/docs/us-17/thursday/us-17-Munoz-Friday-The-13th-Json-Attacks.pdf) and [Friday the 13th JSON attacks details](https://www.blackhat.com/docs/us-17/thursday/us-17-Munoz-Friday-The-13th-JSON-Attacks-wp.pdf).

## JSON Path queries not supported

The `JsonDocument` DOM doesn't support querying by using [JSON Path](https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenJsonPath.htm).

::: zone pivot="dotnet-6-0"
In a <xref:System.Text.Json.Nodes.JsonNode> DOM, each `JsonNode` instance has a `GetPath` method that returns a path to that node. But there is no built-in API to handle queries based on JSON Path query strings.
::: zone-end

For more information, see the [dotnet/runtime #31068 GitHub issue](https://github.com/dotnet/runtime/issues/31068).

## Some limits not configurable

System.Text.Json sets limits that can't be changed for some values, such as the maximum token size in characters (166 MB) and in base 64 (125 MB). For more information, see [`JsonConstants` in the source code](https://github.com/dotnet/runtime/blob/e5f3fa0ed0f52b5073dbfcc7fa800246b9e17adf/src/libraries/System.Text.Json/src/System/Text/Json/JsonConstants.cs#L75-L78) and GitHub issue [dotnet/runtime #39953](https://github.com/dotnet/runtime/issues/39953).

## NaN, Infinity, -Infinity

Newtonsoft parses `NaN`, `Infinity`, and `-Infinity` JSON string tokens. In .NET Core 3.1, System.Text.Json doesn't support these tokens but you can write a custom converter to handle them. In .NET 5 and later versions, use <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals?displayProperty=nameWithType>. For information about how to use this setting, see [Allow or write numbers in quotes](system-text-json-invalid-json.md#allow-or-write-numbers-in-quotes).

## Additional resources

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
* [Customize character encoding](system-text-json-character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
