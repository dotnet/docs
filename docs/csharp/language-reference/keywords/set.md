---
description: "The C# set keyword declares a set accessor in a property or indexer. It defines the code to set the value of the property or indexed property."
title: "set keyword: property accessor"
ms.date: 08/15/2024
f1_keywords: 
  - "set"
  - "set_CSharpKeyword"
helpviewer_keywords: 
  - "set keyword [C#]"
---
# set (C# Reference)

The `set` keyword defines an *accessor* method in a property or indexer that assigns a value to the property or the indexer element. For more information and examples, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../programming-guide/indexers/index.md).

The following example defines both a `get` and a `set` accessor for a property named `Seconds`. It uses a private field named `_seconds` to back the property value.

:::code language="csharp" source="./snippets/PropertyAccessors" id="GetSetAccessors":::

Often, the `set` accessor consists of a single statement that assigns a value, as it did in the previous example. You can implement the `set` accessor as an expression-bodied member. The following example implements both the `get` and the `set` accessors as expression-bodied members.

:::code language="csharp" source="./snippets/PropertyAccessors" id="GetSetExpressions":::
  
For simple cases in which a property's `get` and `set` accessors perform no other operation than setting or retrieving a value in a private backing field, you can take advantage of the C# compiler's support for auto-implemented properties. The following example implements `Hours` as an auto-implemented property.

:::code language="csharp" source="./snippets/PropertyAccessors" id="AutoImplementedProperties":::

> [!IMPORTANT]
> Auto-implemented properties aren't allowed for [interface property declarations](../../programming-guide/classes-and-structs/interface-properties.md) or [partial property declarations](./partial-member.md). In both cases, the compiler interprets syntax matching an auto-implemented property as the declaring declaration, not an implementing declaration.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
