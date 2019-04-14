---
title: "Bitwise and shift operators - C# Reference"
description: "Learn about C# operators that perform bitwise logical or shift operations with the operands of the integral types."
ms.date: 04/16/2019
author: pkulikov
f1_keywords: 
  - "~_CSharpKeyword"
  - "<<_CSharpKeyword"
  - ">>_CSharpKeyword"
  - "&_CSharpKeyword"
  - "^_CSharpKeyword"
  - "|_CSharpKeyword"
helpviewer_keywords: 
  - "bitwise logical operators [C#]"
  - "shift operators [C#]"
  - "tilde operator [C#]"
  - "one's complement operator [C#]"
  - "bitwise complement operator [C#]"
  - "~ operator [C#]"
  - "left shift operator [C#]"
  - "<< operator [C#]"
  - "right shift operator [C#]"
  - ">> operator [C#]"
  - "bitwise logical AND operator [C#]"
  - "ampersand operator [C#]"
  - "& operator [C#]"
  - "bitwise logical exclusive OR operator [C#]"
  - "bitwise logical XOR operator [C#]"
  - "^ operator [C#]"
  - "bitwise logical OR operator [C#]"
  - "| operator [C#]"
---
# Bitwise and shift operators (C# Reference)

The following operators perform bitwise or shift operations with the operands of the [integral types](../keywords/integral-types-table.md):

- Unary [`~` (bitwise complement)](#bitwise-complement-operator-) operator
- Binary [`<<` (left shift)](#left-shift-operator-) and [`>>` (right shift)](#right-shift-operator-) shift operators
- Binary [`&` (logical AND)](#logical-and-operator-), [`|` (logical OR)](#logical-or-operator-), and [`^` (logical exclusive OR)](#logical-exclusive-or-operator-) operators

The `&`, `|`, and `^` operators are also defined for the operands of the `bool` type. For more information, see [Boolean logical operators](boolean-logical-operators.md).

Bitwise and shift operations never cause overflow and produce the same results in [checked and unchecked](../keywords/checked-and-unchecked.md) contexts.

## Bitwise complement operator ~

The `~` operator produces a bitwise complement of its operand by reversing each bit:

[!code-csharp-interactive[bitwise NOT](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#BitwiseComplement)]

You can also use the `~` symbol to declare finalizers. For more information, see [Finalizers](../../programming-guide/classes-and-structs/destructors.md).

## Left-shift operator \<\<

The `<<` operator shifts its first operand left by the number of bits defined by its second operand.

The left-shift operation discards the high-order bits that are outside the range of the result type and sets the low-order empty bit positions to zero, as the following example shows:

[!code-csharp-interactive[left shift](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#LeftShift)]

For information about how the second operand of the `<<` operator defines the shift count, see the [Shift count of the shift operators](#shift-count-of-the-shift-operators) section.

## Right-shift operator >>

The `>>` operator shifts its first operand right by the number of bits defined by its second operand.

The right-shift operation discards the low-order bits, as the following example shows:

[!code-csharp-interactive[right shift](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#RightShift)]

The high-order empty bit positions are set based on the type of the first operand as follows:

- If the first operand is of type [int](../keywords/int.md) or [long](../keywords/long.md), the right-shift operator performs an *arithmetic* shift: the value of the most significant bit (the sign bit) of the first operand is propagated to the high-order empty bit positions. That is, the high-order empty bit positions are set to zero if the first operand is non-negative and set to one if it's negative.

  [!code-csharp-interactive[arithmetic right shift](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#ArithmeticRightShift)]

- If the first operand is of type [uint](../keywords/uint.md) or [ulong](../keywords/ulong.md), the right-shift operator performs a *logical* shift: the high-order empty bit positions are always set to zero.

  [!code-csharp-interactive[logical right shift](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#LogicalRightShift)]

For information about how the second operand of the `>>` operator defines the shift count, see the [Shift count of the shift operators](#shift-count-of-the-shift-operators) section.

## Logical AND operator &amp;

The `&` operator computes the bitwise logical AND of its operands:

[!code-csharp-interactive[bitwise AND](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#BitwiseAnd)]

For the operands of the `bool` type, the `&` operator computes the [logical AND](boolean-logical-operators.md#logical-and-operator-) of its operands. The unary `&` operator is the [address-of operator](and-operator.md#unary-address-of-operator).

## Logical exclusive OR operator ^

The `^` operator computes the bitwise logical exclusive OR, also known as the bitwise logical XOR, of its operands:

[!code-csharp-interactive[bitwise XOR](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#BitwiseXor)]

For the operands of the `bool` type, the `^` operator computes the [logical exclusive OR](boolean-logical-operators.md#logical-exclusive-or-operator-) of its operands.

## Logical OR operator |

The `|` operator computes the bitwise logical OR of its operands:

[!code-csharp-interactive[bitwise OR](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#BitwiseOr)]

For the operands of the `bool` type, the `|` operator computes the [logical OR](boolean-logical-operators.md#logical-or-operator-) of its operands.

## Compound assignment

For a binary operator `op`, a compound assignment expression of the form

```csharp
x op= y
```

is equivalent to

```csharp
x = x op y
```

except that `x` is only evaluated once.

The following example demonstrates the usage of compound assignment with the bitwise and shift operators:

[!code-csharp-interactive[compound assignment](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#CompoundAssignment)]

## Operator precedence

The following list orders the bitwise and shift operators starting from the highest precedence to the lowest:

- Bitwise complement operator `~`
- Shift operators `<<` and `>>`
- Logical AND operator `&`
- Logical exclusive OR operator `^`
- Logical OR operator `|`

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence:

[!code-csharp-interactive[operator precedence](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#Precedence)]

For the complete list of C# operators ordered by precedence level, see [C# operators](index.md).

## Shift count of the shift operators

For the shift operators `<<` and `>>`, the type of the second operand must be [int](../keywords/int.md) or a type that has a [predefined implicit numeric conversion](../keywords/implicit-numeric-conversions-table.md) to `int`.

For the `x << count` and `x >> count` expressions, the actual shift count depends on the type of `x` as follows:

- If the type of `x` is [int](../keywords/int.md) or [uint](../keywords/uint.md), the shift count is defined by the low-order *five* bits of the second operand. That is, the shift count is computed from `count & 0x1F` (or `count & 0b_1_1111`).

- If the type of `x` is [long](../keywords/long.md) or [ulong](../keywords/ulong.md), the shift count is defined by the low-order *six* bits of the second operand. That is, the shift count is computed from `count & 0x3F` (or `count & 0b_11_1111`).

The following example demonstrates that behavior:

[!code-csharp-interactive[shift count example](~/samples/snippets/csharp/language-reference/operators/BitwiseAndShiftOperators.cs#ShiftCount)]

## Enumeration logical operators

The `~`, `&`, `|`, and `^` operators are also defined for any [enumeration](../keywords/enum.md) type. For the operands of the same enumeration type, a logical operation is performed on the corresponding values of the underlying integral type. For example, for any `x` and `y` of an enumeration type `T` with an underlying type `U`, the `x & y` expression produces the same result as the `(T)((U)x & (U)y)` expression.

You typically use bitwise logical operators with an enumeration type which is defined with the [Flags](xref:System.FlagsAttribute) attribute. For more information, see the [Enumeration types as bit flags](../../programming-guide/enumeration-types.md#enumeration-types-as-bit-flags) section of the [Enumeration types](../../programming-guide/enumeration-types.md) article.

## Operator overloadability

A user-defined type can [overload](../keywords/operator.md) the `~`, `<<`, `>>`, `&`, `|`, and `^` operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type cannot explicitly overload a compound assignment operator.

If a user-defined type `T` overloads the `<<` or `>>` operator, the type of the first operand must be `T` and the type of the second operand must be `int`.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Bitwise complement operator](~/_csharplang/spec/expressions.md#bitwise-complement-operator)
- [Shift operators](~/_csharplang/spec/expressions.md#shift-operators)
- [Logical operators](~/_csharplang/spec/expressions.md#logical-operators)

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Boolean logical operators](boolean-logical-operators.md)