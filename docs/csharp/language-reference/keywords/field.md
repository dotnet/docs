---
description: "The `field` contextual keyword - access the compiler synthesized backing field for a property"
title: "The `field` contextual keyword"
ms.date: 01/21/2026
f1_keywords: 
  - "field_CSharpKeyword"
helpviewer_keywords: 
  - "field keyword [C#]"
---
# `field` - Field backed property declarations

Use the contextual keyword `field`, introduced in C# 14, in a property accessor to access the compiler-synthesized backing field of a property. By using this syntax, you can define the body of a `get` or `set` accessor and let the compiler generate the other accessor as it would in an automatically implemented property.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The addition of the `field` contextual keyword provides a smooth path to add benefits such as range checking to an automatically implemented property. This practice is shown in the following example:

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="FieldBackedProperty":::

You might implement the `Hours` property as an automatically implemented property. Then, you discover that you want to protect against a negative value. Use `field` and provide range checking in the `set` accessor. You don't need to declare the backing field by hand or provide a body for the `get` accessor.

For more information, see the [Properties](../../programming-guide/classes-and-structs/properties.md) and [Indexers](../../programming-guide/indexers/index.md) articles.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
