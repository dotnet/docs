---
description: "The C# set keyword declares a set accessor in a property or indexer. It defines the code to set the value of the property or indexed property."
title: "The `set` keyword: property accessor"
ms.date: 01/22/2026
f1_keywords: 
  - "set"
  - "set_CSharpKeyword"
helpviewer_keywords: 
  - "set keyword [C#]"
---
# The set keyword (C# Reference)

The `set` keyword defines an *accessor* method in a property or indexer that assigns a value to the property or the indexer element. For more information and examples, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Automatically implemented properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../programming-guide/indexers/index.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

For simple cases where a property's `get` and `set` accessors perform no other operation than setting or retrieving a value in a private backing field, use automatically implemented properties. The following example implements `Hours` as an automatically implemented property.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="AutoImplementedProperties":::

> [!IMPORTANT]
> You can't use automatically implemented properties for [interface property declarations](../../programming-guide/classes-and-structs/interface-properties.md) or the implementing declaration for a [partial property](./partial-member.md). The compiler interprets syntax matching an automatically implemented property as the declaring declaration, not an implementing declaration.

You might need to implement one of the accessor bodies. The `field` keyword, added in C# 14, declares a *field backed property*. Use a field backed property to let the compiler generate one accessor while you write the other by hand. Use the `field` keyword to access the compiler synthesized backing field:

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="FieldBackedProperty":::

Often, the `set` accessor consists of a single statement that assigns a value, as it did in the previous example. You can implement the `set` accessor as an expression-bodied member. The following example implements both the `get` and the `set` accessors as expression-bodied members.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="GetSetExpressions":::

The following example defines both a `get` and a `set` accessor for a property named `Seconds`. It uses a private field named `_seconds` to back the property value.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="GetSetAccessors":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Properties](../../programming-guide/classes-and-structs/properties.md)
