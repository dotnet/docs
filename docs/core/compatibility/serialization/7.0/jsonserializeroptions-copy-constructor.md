---
title: "Breaking change: JsonSerializerOptions copy constructor includes JsonSerializerContext"
description: Learn about the .NET 7 breaking change in serialization where the JsonSerializerOptions copy constructor now includes JsonSerializerContext.
ms.date: 09/12/2022
---
# JsonSerializerOptions copy constructor includes JsonSerializerContext

With the release of source generation in .NET 6, the <xref:System.Text.Json.JsonSerializerOptions> copy constructor was intentionally made to ignore its <xref:System.Text.Json.Serialization.JsonSerializerContext> state. This made sense at the time since <xref:System.Text.Json.Serialization.JsonSerializerContext> was designed to have a 1:1 relationship with <xref:System.Text.Json.JsonSerializerOptions> instances. In .NET 7, <xref:System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver> replaces <xref:System.Text.Json.Serialization.JsonSerializerContext> to generalize the context, which removes the need for tight coupling between <xref:System.Text.Json.JsonSerializerOptions> and <xref:System.Text.Json.Serialization.JsonSerializerContext>. The copy constructor now includes the <xref:System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver>/<xref:System.Text.Json.Serialization.JsonSerializerContext> information, which could manifest as a breaking change for some scenarios.

## Previous behavior

In .NET 6, the following code serializes successfully. The `MyContext` configuration (which doesn't support `Poco2`) is discarded by the copy constructor, and serialization succeeds because the new options instance defaults to using reflection-based serialization.

```csharp
var options = new JsonSerializerOptions(MyContext.Default.Options);
JsonSerializer.Serialize(new Poco2(), options);

[JsonSerializable(typeof(Poco1))]
public partial class MyContext : JsonSerializerContext {}

public class Poco1 {}
public class Poco2 {}
```

## New behavior

Starting in .NET 7, the same code as shown in the [Previous behavior](#previous-behavior) section throws an <xref:System.InvalidOperationException>. That's because the copy constructor now incorporates `MyContext` metadata, which doesn't support `Poco2` contracts.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

<xref:System.Text.Json.Serialization.JsonSerializerContext> was the only setting ignored by the copy constructor. This behavior was surprising for some users.

## Recommended action

If you depend on the .NET 6 behavior, you can manually unset the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> property to get back reflection-based contract resolution:

```csharp
var options = new JsonSerializerOptions(MyContext.Default.Options);
options.TypeInfoResolver = null; // Unset `MyContext.Default` as the resolver for the options instance.
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializerOptions.%23ctor(System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
