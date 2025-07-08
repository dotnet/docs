---
title: Respect nullable annotations
description: "Learn how to configure serialization and deserialization to respect nullable annotations."
ms.date: 10/22/2024
no-loc: [System.Text.Json, Newtonsoft.Json]
---
# Respect nullable annotations

Starting in .NET 9, <xref:System.Text.Json.JsonSerializer> has (limited) support for non-nullable reference type enforcement in both serialization and deserialization. You can toggle this support using the <xref:System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations?displayProperty=nameWithType> flag.

For example, the following code snippet throws a <xref:System.Text.Json.JsonException> during serialization with a message like:

> The property or field 'Name' on type 'Person' doesn't allow getting null values. Consider updating its nullability annotation.

:::code language="csharp" source="snippets/nullable-annotations/Nullable.cs" id="Serialization":::

Similarly, <xref:System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations> enforces nullability on deserialization. The following code snippet throws a <xref:System.Text.Json.JsonException> during serialization with a message like:

> The constructor parameter 'Name' on type 'Person' doesn't allow null values. Consider updating its nullability annotation.

:::code language="csharp" source="snippets/nullable-annotations/Nullable.cs" id="Deserialization":::

> [!TIP]
>
> - You can configure nullability at an individual property level using the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsGetNullable> and <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsSetNullable> properties.
> - The C# compiler uses the [`[NotNull]`](xref:System.Diagnostics.CodeAnalysis.NotNullAttribute), [`[AllowNull]`](xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute), [`[MaybeNull]`](xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute), and [`[DisallowNull]`](xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute) attributes to fine-tune annotations in getters and setters. These attributes are also recognized by this System.Text.Json feature. (For more information about the attributes, see [Attributes for null-state static analysis](../../../csharp/language-reference/attributes/nullable-analysis.md).)

## Limitations

Due to how non-nullable reference types are implemented, this feature comes with some important limitations. Familiarize yourself with these limitations before turning the feature on. The root of the issue is that reference type nullability has no first-class representation in intermediate language (IL). As such, the expressions `MyPoco` and `MyPoco?` are indistinguishable from the perspective of run-time reflection. While the compiler tries to make up for that by emitting attribute metadata (see [sharplab.io example](https://sharplab.io/#v2:D4AQTAjAsAULBOBTAxge3gEwAQFkCeACqmgBQgQAMWAcqgC7UCuANswMp3wCWAdgOYAaLOQoB+Gi2YBDAEbNEHbvwCUAbiA=)), this metadata is restricted to non-generic member annotations that are scoped to a particular type definition. This limitation is the reason that the flag only validates nullability annotations that are present on non-generic properties, fields, and constructor parameters. System.Text.Json does not support nullability enforcement on:

- Top-level types, or the type that's passed when making the first `JsonSerializer.Deserialize()` or `JsonSerializer.Serialize()` call.
- Collection element types&mdash;for example, the `List<string>` and `List<string?>` types are indistinguishable.
- Any properties, fields, or constructor parameters that are generic.

If you want to add nullability enforcement in these cases, either model your type to be a struct (since they don't admit null values), or author a custom converter that overrides its <xref:System.Text.Json.Serialization.JsonConverter`1.HandleNull> property to `true`.

## Feature switch

You can turn on the `RespectNullableAnnotations` setting globally using the `System.Text.Json.Serialization.RespectNullableAnnotationsDefault` feature switch. Add the following MSBuild item to your project file (for example, *.csproj* file):

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Text.Json.Serialization.RespectNullableAnnotationsDefault" Value="true" />
</ItemGroup>
```

The `RespectNullableAnnotationsDefault` API was implemented as an opt-in flag in .NET 9 to avoid breaking existing applications. If you're writing a new application, it's highly recommended that you enable this flag in your code.

## Relationship between nullable and optional parameters

<xref:System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations> doesn't extend enforcement to unspecified JSON values, because System.Text.Json treats required and non-nullable properties as orthogonal concepts. For example, the following code snippet doesn't throw an exception during deserialization:

:::code language="csharp" source="snippets/nullable-annotations/Nullable.cs" id="Unspecified":::

This behavior stems from the C# language itself, where you can have required properties that are nullable:

```csharp
MyPoco poco = new() { Value = null }; // No compiler warnings.

class MyPoco
{
    public required string? Value { get; set; }
}
```

And you can also have optional properties that are non-nullable:

```csharp
class MyPoco
{
    public string Value { get; set; } = "default";
}
```

The same orthogonality applies to constructor parameters:

```csharp
record MyPoco(
    string RequiredNonNullable,
    string? RequiredNullable,
    string OptionalNonNullable = "default",
    string? OptionalNullable = "default"
    );
```

## See also

- [Non-optional constructor parameters](required-properties.md#non-optional-constructor-parameters)
