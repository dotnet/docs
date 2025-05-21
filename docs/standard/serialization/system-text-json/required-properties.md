---
title: Require properties for deserialization
description: "Learn how to mark properties as required for deserialization to succeed."
ms.date: 10/22/2024
no-loc: [System.Text.Json, Newtonsoft.Json]
ms.topic: how-to
---
# Required properties

You can mark certain properties to signify that they must be present in the JSON payload for deserialization to succeed. Similarly, you can set an option to specify that all non-optional constructor parameters are present in the JSON payload. If one or more of these required properties is not present, the <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> methods throw a <xref:System.Text.Json.JsonException>.

There are three ways to mark a property or field as required for JSON deserialization:

- By adding the [`required` modifier](../../../csharp/language-reference/keywords/required.md).
- By annotating it with <xref:System.Text.Json.Serialization.JsonRequiredAttribute>.
- By modifying the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType> property of the contract model.

To specify that all non-optional constructor parameters are required for JSON deserialization, set the <xref:System.Text.Json.JsonSerializerOptions.RespectRequiredConstructorParameters?displayProperty=nameWithType> option (or, for source generation, <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.RespectRequiredConstructorParameters> property) to `true`. For more information, see the [Non-optional constructor parameters](#non-optional-constructor-parameters) section.

From the serializer's perspective, the C# `required` modifier and [`[JsonRequired]`](xref:System.Text.Json.Serialization.JsonRequiredAttribute) attribute are equivalent, and both map to the same piece of metadata, which is <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType>. In most cases, you'd simply use the built-in C# keyword. However, in the following cases, you should use <xref:System.Text.Json.Serialization.JsonRequiredAttribute> instead:

- If you're using a programming language other than C# or a down-level version of C#.
- If you only want the requirement to apply to JSON deserialization.
- If you're using `System.Text.Json` serialization in [source generation](source-generation-modes.md#metadata-based-mode) mode. In this case, your code won't compile if you use the `required` modifier, as source generation occurs at compile time.

The following code snippet shows an example of a property modified with the `required` keyword. This property must be present in the JSON payload for deserialization to succeed.

:::code language="csharp" source="snippets/required-properties/RequiredProperties.cs" id="Keyword":::

Alternatively, you can use <xref:System.Text.Json.Serialization.JsonRequiredAttribute>:

:::code language="csharp" source="snippets/required-properties/RequiredProperties.cs" id="Attribute":::

It's also possible to control whether a property is required via the contract model using the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType> property:

:::code language="csharp" source="snippets/required-properties/RequiredProperties.cs" id="ContractModel":::

## Non-optional constructor parameters

Prior to .NET 9, constructor-based deserialization treated all constructor parameters as optional, as the following example shows:

```csharp
var result = JsonSerializer.Deserialize<Person>("{}");
Console.WriteLine(result); // Person { Name = , Age = 0 }

record Person(string Name, int Age);
```

Starting in .NET 9, you can set the <xref:System.Text.Json.JsonSerializerOptions.RespectRequiredConstructorParameters> flag to treat non-optional constructor parameters as required.

:::code language="csharp" source="snippets/required-properties/RequiredProperties.cs" id="RequiredConstrParams":::

### Feature switch

You can turn on the `RespectRequiredConstructorParameters` setting globally using the `System.Text.Json.Serialization.RespectRequiredConstructorParametersDefault` feature switch. Add the following MSBuild item to your project file (for example, *.csproj* file):

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Text.Json.Serialization.RespectRequiredConstructorParametersDefault" Value="true" />
</ItemGroup>
```

The `RespectRequiredConstructorParametersDefault` API was implemented as an opt-in flag in .NET 9 to avoid breaking existing applications. If you're writing a new application, it's highly recommended that you enable this flag in your code.

## See also

- [Respect nullable annotations](nullable-annotations.md)
