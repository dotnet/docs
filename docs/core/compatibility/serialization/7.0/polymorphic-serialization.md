---
title: "Breaking change: Polymorphic serialization for object types"
description: Learn about the .NET 7 breaking change in serialization where System.Text.Json no longer hardcodes polymorphism for root-level object types.
ms.date: 09/12/2022
---
# Polymorphic serialization for object types

Using default configuration, <xref:System.Text.Json?displayProperty=fullName> serializes values of type `object` [using polymorphism](../../../../standard/serialization/system-text-json/polymorphism.md). This behavior becomes less consistent if you register a custom converter for `object`. `System.Text.Json` has historically hardcoded polymorphism for root-level object values but not for nested object values. Starting with .NET 7, this behavior has changed so that custom converters never use polymorphism.

## Previous behavior

Consider the following custom object converter:

```csharp
public class CustomObjectConverter : JsonConverter<object>
{
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        => writer.WriteNumberValue(42);

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();
}
```

In previous versions, the following code serialized as 0. That's because the serializer used polymorphism and ignored the custom converter.

```csharp
var options = new JsonSerializerOptions { Converters = { new CustomObjectConverter() } };
JsonSerializer.Serialize<object>(0, options);
```

However, the following code serialized as 42 because the serializer honored the custom converter.

```csharp
var options = new JsonSerializerOptions { Converters = { new CustomObjectConverter() } };
JsonSerializer.Serialize<object[]>(new object[] { 0 }, options);
```

## New behavior

Starting in .NET 7, using the custom object converter defined in the [Previous behavior](#previous-behavior) section, the following code serializes as 42. That's because the serializer will always consult the custom converter and not use polymorphism.

```csharp
var options = new JsonSerializerOptions { Converters = { new CustomObjectConverter() } };
JsonSerializer.Serialize<object>(0, options);
```

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was made due to inconsistent serialization contracts for a type, depending on whether it was being serialized as a root-level value or a nested value.

## Recommended action

If desired, you can get back polymorphism for root-level values by invoking one of the untyped serialization methods:

```csharp
var options = new JsonSerializerOptions { Converters = { new CustomObjectConverter() } };
JsonSerializer.Serialize(0, inputType: typeof(int), options); // Serializes as 0.
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.IO.Stream,%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.Text.Json.Utf8JsonWriter,%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.SerializeAsync%60%601(System.IO.Stream,%60%600,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=fullName>
