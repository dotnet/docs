---
title: "Breaking change: New JsonSerializer source generator overloads"
description: Learn about the .NET 6 breaking change where new JsonSerializer source generator overloads were added that might affect source compatibility.
ms.date: 09/10/2021
---
# New JsonSerializer source generator overloads

The `System.Text.Json` source generator feature added new overloads to <xref:System.Text.Json.JsonSerializer> that accept pre-generated type information via <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo%601> or <xref:System.Text.Json.Serialization.JsonSerializerContext>. These overloads provide a performance optimization over pre-existing overloads that take <xref:System.Text.Json.JsonSerializerOptions> instances and perform run-time reflection. All of these parameter types are reference types for which you can pass `null`. The following example shows the method-signature patterns for both approaches:

Pre-existing reflection/`JsonSerializerOptions`-based overloads:

```csharp
public static string JsonSerializer.Serialize<T>(T value, JsonSerializerOptions? options = null);
public static string JsonSerializer.Serialize(object value, Type type, JsonSerializerOptions? options = null);
public static T JsonSerializer.Deserialize<T>(string json, JsonSerializerOptions? options = null);
public static T JsonSerializer.Deserialize(string json, Type type, JsonSerializerOptions? options = null);
```

New source-generator/`JsonTypeInfo`/`JsonSerializerContext`-based overloads:

```csharp
public static string JsonSerializer.Serialize<T>(T value, JsonTypeInfo<T> jsonTypeInfo);
public static string JsonSerializer.Serialize(object value, Type type, JsonSerializerContext jsonSerializerContext);
public static T JsonSerializer.Deserialize<T>(string json, JsonTypeInfo<T> jsonTypeInfo);
public static object JsonSerializer.Deserialize(string json, Type type, JsonSerializerContext jsonSerializerContext);
```

## Previous behavior

You could write code that passed `null` as the value for the <xref:System.Text.Json.JsonSerializerOptions> parameter, and it compiled and ran successfully.

```csharp
entity.Property(e => e.Value).HasConversion(v => JsonSerializer.Serialize(v,null), v => JsonSerializer.Deserialize(v, null));
```

## New behavior

The new source-generator methods in .NET 6 can introduce compiler ambiguity if you pass `null` for the <xref:System.Text.Json.JsonSerializerOptions> parameter. For example, you might see the following error message:

**The call is ambiguous between the following methods or properties: 'JsonSerializer.Serialize(TValue, JsonSerializerOptions?)' and 'JsonSerializer.Serialize(TValue, JsonTypeInfo)**

## Version introduced

.NET 6

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

New overloads were added to the serializer as a performance optimization. For more information, see [Try the new System.Text.Json source generator](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/).

## Recommended action

Update your code in a manner that disambiguates the intended overload, such as performing an explicit cast to the intended target. For example, you can change the example in the [Previous behavior](#previous-behavior) section as follows:

```csharp
entity.Property(e => e.Value).HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), v => JsonSerializer.Deserialize(v, (JsonSerializerOptions)null));
```

Other workarounds include:

- Omitting the optional parameter `JsonSerializerOptions? options = null`.
- Using named arguments.

However, you can't omit optional parameters or use named arguments in a lambda expression.

## Affected APIs

All of the <xref:System.Text.Json.JsonSerializer?displayProperty=fullName> methods.
