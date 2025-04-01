---
description: "The `field` contextual keyword - access the compiler synthesized backing field for a property"
title: "The `field` contextual keyword"
ms.date: 10/30/2024
f1_keywords: 
  - "field_CSharpKeyword"
helpviewer_keywords: 
  - "field keyword [C#]"
---
# `field` - Field backed property declarations

[!INCLUDE[field-preview](../../includes/field-preview.md)]

The contextual keyword `field`, added as a preview feature in C# 13, can be used in a property accessor to access the compiler synthesized backing field of a property. This syntax enables you to define the body of a `get` or `set` accessor and let the compiler generate the other accessor as it would in an automatically implemented property.

The addition of the `field` contextual keywords provides a smooth path to add benefits such as range checking to an automatically implemented property. This practice is shown in the following example:

:::code language="csharp" source="./snippets/PropertyAccessors.cs" id="FieldBackedProperty":::

You might implement the `Hours` property as an automatically implemented property. Then, you discover that you want to protect against a negative value. You use `field` and provide range checking in the `set` accessor. You don't need to declare the backing field by hand and provide a body for the `get` accessor.

For more information, see the [Properties](../../programming-guide/classes-and-structs/properties.md) and [Indexers](../../programming-guide/indexers/index.md) articles.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
