---
description: "The C# get keyword declares a get accessor in a property or indexer. It defines the code to retrieve the value of the property or indexed property."
title: "The get keyword: property accessor"
ms.date: 10/30/2024
f1_keywords: 
  - "get_CSharpKeyword"
  - "get"
helpviewer_keywords: 
  - "get keyword [C#]"
---
# The `get` keyword

The `get` keyword defines an *accessor* method in a property or indexer that returns the property value or the indexer element. For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Automatically implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../programming-guide/indexers/index.md).

For simple cases in which a property's `get` and `set` accessors perform no other operation than setting or retrieving a value in a private backing field, you can take advantage of the C# compiler's support for automatically implemented properties. The following example implements `Hours` as an automatically implemented property.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="AutoImplementedProperties":::

> [!IMPORTANT]
> Automatically implemented properties aren't allowed for [interface property declarations](../../programming-guide/classes-and-structs/interface-properties.md) or the implementing declaration for a [partial property](./partial-member.md). The compiler interprets syntax matching an automatically implemented property as the declaring declaration, not an implementing declaration.

Often, the `get` accessor consists of a single statement that returns a value, as it did in the previous example. You can implement the `get` accessor as an expression-bodied member. The following example implements both the `get` and the `set` accessor as expression-bodied members.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="GetSetExpressions":::

You might find that you need to implement one of the accessor bodies. You can use a field backed property to let the compiler generate one accessor while you write the other by hand. You use the `field` keyword, added as a preview feature in C# 13, to access the compiler synthesized backing field:

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="FieldBackedProperty":::

[!INCLUDE[field-preview](../../includes/field-preview.md)]

The following example defines both a `get` and a `set` accessor for a property named `Seconds`. It uses a private field named `_seconds` to back the property value.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="GetSetAccessors":::

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
