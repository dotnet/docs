---
title: "^ operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "^_CSharpKeyword"
helpviewer_keywords: 
  - "^ operator [C#]"
  - "bitwise exclusive OR operator [C#]"
ms.assetid: b09bc815-570f-4db6-a637-5b4ed99d014a
---
# ^ operator (C# Reference)

Binary `^` operators are predefined for the integral types and `bool`. For integral types, `^` computes the bitwise exclusive-OR of its operands. For `bool` operands, `^` computes the logical exclusive-or of its operands; that is, the result is `true` if and only if exactly one of its operands is `true`.

## Remarks

User-defined types can overload the `^` operator (see [operator](../keywords/operator.md)). Operations on integral types are generally allowed on enumeration.

## Example

[!code-csharp[csRefOperators#30](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#30)]

The computation of `0xf8 ^ 0x3f` in the previous example performs a bitwise exclusive-OR of the following two binary values, which correspond to the hexadecimal values F8 and 3F:

`1111 1000`

`0011 1111`

The result of the exclusive-OR is `1100 0111`, which is C7 in hexadecimal.

## See Also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)
