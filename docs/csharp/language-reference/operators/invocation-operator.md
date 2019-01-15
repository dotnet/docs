---
title: "() operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "()_CSharpKeyword"
helpviewer_keywords: 
  - "type conversion [C#], () operator"
  - "cast operator [C#]"
  - "() operator [C#]"
ms.assetid: 846e1f94-8a8c-42fc-a42c-fbd38e70d8cc
---
# () operator (C# Reference)

In addition to being used to specify the order of operations in an expression, parentheses are used to perform the following tasks:

1. Specify casts, or type conversions.

    [!code-csharp[csRefOperators#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#1)]

2. Invoke methods or delegates.

    [!code-csharp[csRefOperators#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#2)]

## Remarks

A cast explicitly invokes the conversion operator from one type to another; the cast fails if no such conversion operator is defined. To define a conversion operator, see [explicit](../keywords/explicit.md) and [implicit](../keywords/implicit.md).

 The `()` operator cannot be overloaded.

 For more information, see [Casting and Type Conversions](../../programming-guide/types/casting-and-type-conversions.md).

 For more information about method invocation, see [Methods](../../programming-guide/classes-and-structs/methods.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)