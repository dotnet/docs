---
description: "value contextual keyword - C# Reference"
title: "value contextual keyword - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "value_CSharpKeyword"
helpviewer_keywords: 
  - "value keyword [C#]"
ms.assetid: c99d6468-687f-4a46-89b4-a95e1b00bf6d
---
# value (C# Reference)

The contextual keyword `value` is used in the `set` accessor in [property](../../programming-guide/classes-and-structs/properties.md) and [indexer](../../programming-guide/indexers/index.md) declarations. It is similar to an input parameter of a method. The word `value` references the value that client code is attempting to assign to the property or indexer. In the following example, `MyDerivedClass` has a property called `Name` that uses the `value` parameter to assign a new string to the backing field `name`. From the point of view of client code, the operation is written as a simple assignment.

[!code-csharp[csrefKeywordsModifiers#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#26)]

For more information, see the [Properties](../../programming-guide/classes-and-structs/properties.md) and [Indexers](../../programming-guide/indexers/index.md) articles.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Keywords](index.md)
