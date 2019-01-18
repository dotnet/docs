---
title: "- operator - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "-_CSharpKeyword"
helpviewer_keywords: 
  - "- operator [C#]"
  - "subtraction operator (-) [C#]"
ms.assetid: 4de7a4fa-c69d-48e6-aff1-3130af970b2d
---
# - operator (C# Reference)

The `-` operator can function as either a unary or a binary operator.

## Remarks

Unary `-` operators are predefined for all numeric types. The result of a unary `-` operation on a numeric type is the numeric negation of the operand.

Binary `-` operators are predefined for all numeric and enumeration types to subtract the second operand from the first.

Delegate types also provide a binary `-` operator, which performs delegate removal.

User-defined types can overload the unary `-` and binary `-` operators. For more information, see [operator keyword](../keywords/operator.md).

## Example

[!code-csharp[csRefOperators#40](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#40)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)