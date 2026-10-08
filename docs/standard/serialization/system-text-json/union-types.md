---
title: Serialize union types with System.Text.Json
description: Learn how System.Text.Json serializes and deserializes C# union types in .NET 11.
ms.date: 09/24/2026
no-loc: [System.Text.Json]
dev_langs:
  - "csharp"
ms.topic: how-to
ai-usage: ai-assisted
---

# Serialize union types with System.Text.Json

Starting in .NET 11, <xref:System.Text.Json.JsonSerializer> supports [C# 15 union types](../../../csharp/language-reference/builtin-types/union.md). A union holds one of the case types in its declaration. `JsonSerializer` writes the active case value and can read it back.

## Serialize and deserialize union values

Declare a union whose cases have distinct JSON token types:

```csharp
public union Payload(int, string, Message);
public sealed record Message(string Text);
```

Use `JsonSerializer` to serialize and deserialize the union:

```csharp
Payload payload = new Message("Ready");
string json = JsonSerializer.Serialize(payload);
Payload copy = JsonSerializer.Deserialize<Payload>(json);
```

The serialized JSON contains the active case value rather than a wrapper or discriminator:

```json
{"Text":"Ready"}
```

By default, the serializer classifies incoming JSON by token type. In the preceding union, a JSON number selects `int`, a JSON string selects `string`, and a JSON object selects `Message`.

With <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType>, an `int` can also be read from a JSON string. Both the `int` and `string` cases of `Payload` then claim the string token type. Even `"25%"` throws <xref:System.Text.Json.JsonException> for ambiguity before the serializer parses either case. To read strings with web defaults, [provide a custom classifier](#provide-a-custom-classifier) that chooses the case.

## Distinguish cases with the same JSON token type

Token classification can't distinguish two cases that both serialize as JSON objects. Apply <xref:System.Text.Json.Serialization.JsonUnionAttribute> and select <xref:System.Text.Json.Serialization.JsonUnionTypeStructuralClassifier> to classify object cases by their property names:

```csharp
[JsonUnion(TypeClassifier = typeof(JsonUnionTypeStructuralClassifier))]
public union Pet(Dog, Cat);
public sealed record Dog(string Name, string Breed);
public sealed record Cat(string Name, int Lives);
```

Here, `JsonUnionAttribute` selects a classifier for the existing `Pet` union; applying it to an ordinary type doesn't turn that type into a union.

The classifier selects `Dog` when the payload contains `Breed` and selects `Cat` when it contains `Lives`:

```csharp
Pet pet = JsonSerializer.Deserialize<Pet>(
    """{"Name":"Rex","Breed":"Husky"}""");
```

For JSON objects, the structural classifier starts with the compatible object cases and narrows that set as it reads recognized root-level property names. Required properties remove cases when they're absent. <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow?displayProperty=nameWithType> removes a case when the payload contains a property that the case doesn't declare. Classification succeeds only when one case remains.

The structural classifier doesn't inspect property values, nested objects, string contents, or array elements. Keep these consequences in mind:

* A payload that leaves zero or multiple candidates throws <xref:System.Text.Json.JsonException>.
* Overlapping or shadowed object contracts might be rejected when the classifier is created.
* Multiple non-object cases that use the same JSON token type aren't supported. For example, `Guid` and `string` both use JSON strings.
* A plain object case can't be mixed with a dictionary, `JsonObject`, or another non-POCO object-shaped case.
* Nested union cases and polymorphic cases aren't supported.
* <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve?displayProperty=nameWithType> isn't supported.
* A configuration that can't distinguish its cases throws <xref:System.NotSupportedException> when the serializer builds the classifier.

## Choose unions or closed hierarchies

Use a union when you need to preserve a discriminator-free JSON format you don't control, or when the cases have distinct JSON shapes. For example, the `int` and `string` cases of `Payload` are distinguishable by JSON token type. For object cases such as `Pet(Dog, Cat)`, however, changes to property names can affect which case a structural classifier selects.

When you control the types and JSON contract, a [closed hierarchy with inferred polymorphism](polymorphism.md#infer-polymorphism-from-a-closed-hierarchy) can identify object cases with a discriminator instead:

```csharp
[JsonPolymorphic(InferClosedTypePolymorphism = true)]
public closed record Event;
public sealed record Created(int Id) : Event;
public sealed record Deleted(int Id) : Event;
```

`JsonSerializer.Serialize<Event>(new Created(42))` writes `{"$type":"Created","Id":42}`. Both derived types declare `Id`, but the discriminator identifies the case independently of its properties. This makes case selection more stable as the properties evolve. Unlike union cases, the derived types must share a base class, and you must opt in to inferred polymorphism; the `closed` modifier alone doesn't add a discriminator.

## Provide a custom classifier

Derive from <xref:System.Text.Json.Serialization.JsonTypeClassifierFactory> when default token classification or the built-in <xref:System.Text.Json.Serialization.JsonUnionTypeStructuralClassifier> doesn't meet your requirements. A custom classifier can use other structural rules to select a union case. Register the factory in one of these locations:

* Assign a delegate to <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.TypeClassifier?displayProperty=nameWithType> when you customize the contract.
* Set <xref:System.Text.Json.Serialization.JsonUnionAttribute.TypeClassifier?displayProperty=nameWithType> for one union.
* Add the factory to <xref:System.Text.Json.JsonSerializerOptions.TypeClassifiers?displayProperty=nameWithType> for reflection-based serialization.
* Set <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.TypeClassifiers?displayProperty=nameWithType> for a source-generation context.

A classifier reads the current JSON value and returns one of the case types from <xref:System.Text.Json.Serialization.JsonTypeClassifierContext.UnionCases?displayProperty=nameWithType>. The serializer checks the contract delegate first, followed by the per-union factory, the options-level factories, and built-in token classification.

For ambiguous unions, the source generator reports a diagnostic unless a classifier is configured at generation time.

## Handle null and default union values

A union can declare nullable case types. JSON `null` selects the first nullable case. If the union has no nullable case, JSON `null` produces the default union value. For a compiler-generated struct union, the default value has no active case and serializes as JSON `null`.

## Customize a union contract

For advanced scenarios, customize the union metadata through <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo>. A union's <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.Kind?displayProperty=nameWithType> value is <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfoKind.Union?displayProperty=nameWithType>. Its contract exposes:

* <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.UnionCases?displayProperty=nameWithType>, which contains <xref:System.Text.Json.Serialization.Metadata.JsonUnionCaseInfo> entries.
* <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.UnionConstructor?displayProperty=nameWithType>, which creates a union from a case type and value.
* <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.UnionDeconstructor?displayProperty=nameWithType>, which returns the active case type and value.
* <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.TypeClassifier?displayProperty=nameWithType>, which selects a case during deserialization.

For more information about modifying `JsonTypeInfo`, see [Customize a JSON contract](custom-contracts.md).

## See also

* [Union types (C# reference)](../../../csharp/language-reference/builtin-types/union.md)
* [Serialize polymorphic types](polymorphism.md)
* [Use source generation](source-generation.md)
* [Use C# unions and closed hierarchies in ASP.NET Core (.NET Blog)](https://devblogs.microsoft.com/dotnet/unions-and-closed-hierarchies-in-aspnetcore/)
