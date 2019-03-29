---
title: "| operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "|_CSharpKeyword"
helpviewer_keywords: 
  - "bitwise OR operator [C#]"
  - "| operator [C#]"
  - "binary operator (|) [C#]"
ms.assetid: 82d6bb78-54c8-40bf-b679-531180ddaf70
---
# | operator (C# Reference)

Binary `|` operators are predefined for the integral types and `bool`. For integral types, `|` computes the bitwise OR of its operands. For `bool` operands, `|` computes the logical OR of its operands; that is, the result is `false` if and only if both its operands are `false`.

## Remarks

The binary `|` operator evaluates both operands regardless of the first one's value, in contrast to the [conditional-OR operator](conditional-or-operator.md) `||`.

User-defined types can overload the `|` operator (see [operator](../keywords/operator.md)).

## Example

 [!code-csharp[csRefOperators#31](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#31)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)