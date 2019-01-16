---
title: "&lt;&lt; operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "<<_CSharpKeyword"
helpviewer_keywords: 
  - "left shift operator (<<) [C#]"
  - "<< operator [C#]"
ms.assetid: a654eb56-1ff7-4bf3-9064-b631be0cdccc
---
# &lt;&lt; operator (C# Reference)

The left-shift operator (`<<`) shifts its first operand left by the number of bits specified by its second operand. The type of the second operand must be an [int](../keywords/int.md) or a type that has a predefined implicit numeric conversion to `int`.

## Remarks

If the first operand is an [int](../keywords/int.md) or [uint](../keywords/uint.md) (32-bit quantity), the shift count is given by the low-order five bits of the second operand. That is, the actual shift count is 0 to 31 bits.

If the first operand is a [long](../keywords/long.md) or [ulong](../keywords/ulong.md) (64-bit quantity), the shift count is given by the low-order six bits of the second operand. That is, the actual shift count is 0 to 63 bits.

Any high-order bits that are not within the range of the type of the first operand after the shift are discarded, and the low-order empty bits are zero-filled. Shift operations never cause overflows.

User-defined types can overload the `<<` operator (see [operator](../keywords/operator.md)); the type of the first operand must be the user-defined type, and the type of the second operand must be `int`. When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.

## Example

[!code-csharp[csRefOperators#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#14)]

## Comments

Note that `i<<1` and `i<<33` give the same result, because 1 and 33 have the same low-order five bits.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
