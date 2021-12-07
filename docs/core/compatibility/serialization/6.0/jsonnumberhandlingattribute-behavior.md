---
title: "Breaking change: JsonNumberHandlingAttribute on non-number collection properties"
description: Learn about the .NET 6 breaking change where JsonNumberHandlingAttribute can now only be applied to properties that are collections of numbers.
ms.date: 11/05/2021
---
# JsonNumberHandlingAttribute on collection properties

A minor breaking change was introduced in .NET 6 with regard to the <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> attribute. If you apply the attribute to a property that's a collection of non-number values and attempt to serialize or deserialize the property, an <xref:System.InvalidOperationException> is thrown. The attribute is only valid for properties that are collections of number types, for example:

```csharp
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
public List<int> MyList { get; set; }
```

## Previous behavior

Although it was ignored during serialization, <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> could be applied to properties that were collections of non-number types. For example:

```csharp
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
public List<MyClass> MyList { get; set; }
```

## New behavior

Starting in .NET 6, if you apply <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> to a property that's a collection of non-number values and attempt to serialize or deserialize the property, an <xref:System.InvalidOperationException> is thrown.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was a side effect of a performance optimization for the number handling feature.

## Recommended action

Remove the <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> attribute from incompatible collection properties.

## Affected APIs

All of the <xref:System.Text.Json.JsonSerializer?displayProperty=fullName> serialization and deserialization methods.
