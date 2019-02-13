---
title: "<< operator - C# Reference"
ms.custom: seodec18
ms.date: 02/12/2019
f1_keywords: 
  - "<<_CSharpKeyword"
helpviewer_keywords: 
  - "left shift operator (<<) [C#]"
  - "<< operator [C#]"
ms.assetid: a654eb56-1ff7-4bf3-9064-b631be0cdccc
---
# \<\< operator (C# Reference)

The left-shift operator `<<` shifts its first operand left by the number of bits defined by its second operand. All integer types support the `<<` operator. However, the type of the second operand must be [int](../keywords/int.md) or a type that has a [predefined implicit numeric conversion](../keywords/implicit-numeric-conversions-table.md) to `int`.

The high-order bits that are outside the range of the result type are discarded, and the low-order empty bit positions are set to zero, as the following example shows:

[!code-csharp-interactive[left shift example](~/samples/snippets/csharp/language-reference/operators/ShiftOperatorsExamples.cs#LeftShift)]

## Shift count

For the expression `x << count`, the actual shift count depends on the type of `x` as follows:

- If the type of `x` is [int](../keywords/int.md) or [uint](../keywords/uint.md), the shift count is given by the low-order *five* bits of the second operand. That is, the shift count is computed from `count & 0x1F` (or `count & 0b_1_1111`).

- If the type of `x` is [long](../keywords/long.md) or [ulong](../keywords/ulong.md), the shift count is given by the low-order *six* bits of the second operand. That is, the shift count is computed from `count & 0x3F` (or `count & 0b_11_1111`).

The following example demonstrates that behavior:

[!code-csharp-interactive[shift count example](~/samples/snippets/csharp/language-reference/operators/ShiftOperatorsExamples.cs#LeftShiftByLargeCount)]

## Remarks

Shift operations never cause overflows and produce the same results in [checked and unchecked](../keywords/checked-and-unchecked.md) contexts.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `<<` operator. If a user-defined type `T` overloads the `<<` operator, the type of the first operand must be `T` and the type of the second operand must be `int`. When the `<<` operator is overloaded, the [left-shift assignment operator](left-shift-assignment-operator.md) `<<=` is also implicitly overloaded.

## C# language specification

For more information, see the [Shift operators](~/_csharplang/spec/expressions.md#shift-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [>> operator](right-shift-operator.md)
