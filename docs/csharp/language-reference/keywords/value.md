---
description: "The token `value` is an implicit parameter to the `set` accessor for indexers or properties. It represents the parameter to the set accessor."
title: "The `value` implicit parameter"
ms.date: 10/30/2024
f1_keywords: 
  - "value_CSharpKeyword"
helpviewer_keywords: 
  - "value keyword [C#]"
---
# The `value` implicit parameter

The `set` accessor in [property](../../programming-guide/classes-and-structs/properties.md) and [indexer](../../programming-guide/indexers/index.md) declarations uses the implicit parameter `value`. This parameter acts as an input for the method. The word `value` refers to the value that client code tries to assign to the property or indexer.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

In the following example, `TimePeriod2` has a property named `Seconds` that uses the `value` parameter to assign a new string to the backing field `_seconds`. From the point of view of client code, the operation is written as a simple assignment.

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="GetSetExpressions":::

For more information, see the [Properties](../../programming-guide/classes-and-structs/properties.md) and [Indexers](../../programming-guide/indexers/index.md) articles.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
