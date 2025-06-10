---
title: "Bitwise and shift operators - perform boolean (AND, NOT, OR, XOR) and shift operations on individual bits in integral types"
description: "Learn about C# operators that perform bitwise logical (AND - `&`, NOT - `~`, OR - `|`, XOR - `^`) or shift operations(`<<`, and `>>`) with operands of integral types. "
ms.date: 06/11/2025
author: pkulikov
f1_keywords: 
  - "~_CSharpKeyword"
  - "<<_CSharpKeyword"
  - ">>_CSharpKeyword"
  - ">>>_CSharpKeyword"
  - "&_CSharpKeyword"
  - "^_CSharpKeyword"
  - "|_CSharpKeyword"
  - "<<=_CSharpKeyword"
  - ">>=_CSharpKeyword"
  - ">>>=_CSharpKeyword"
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
  - "unsigned right shift operator [C#]"
  - ">>> operator [C#]"
  - "bitwise logical AND operator [C#]"
  - "ampersand operator [C#]"
  - "& operator [C#]"
  - "bitwise logical exclusive OR operator [C#]"
  - "bitwise logical XOR operator [C#]"
  - "^ operator [C#]"
  - "bitwise logical OR operator [C#]"
  - "| operator [C#]"
---
# Bitwise and shift operators (C# reference)

The bitwise and shift operators include unary bitwise complement, binary left and right shift, unsigned right shift, and the binary logical AND, OR, and exclusive OR operators. These operands take operands of the [integral numeric types](../builtin-types/integral-numeric-types.md) or the [char](../builtin-types/char.md) type.

- Unary [`~` (bitwise complement)](#bitwise-complement-operator-) operator
- Binary [`<<` (left shift)](#left-shift-operator-), [`>>` (right shift)](#right-shift-operator-), and [`>>>` (unsigned right shift)](#unsigned-right-shift-operator-) operators
- Binary [`&` (logical AND)](#logical-and-operator-), [`|` (logical OR)](#logical-or-operator-), and [`^` (logical exclusive OR)](#logical-exclusive-or-operator-) operators

Those operators are defined for the `int`, `uint`, `long`, `ulong`, `nint`, and `nuint` types. When both operands are of other integral types (`sbyte`, `byte`, `short`, `ushort`, or `char`), their values are converted to the `int` type, which is also the result type of an operation. When operands are of different integral types, their values are converted to the closest containing integral type. For more information, see the [Numeric promotions](~/_csharpstandard/standard/expressions.md#1247-numeric-promotions) section of the [C# language specification](~/_csharpstandard/standard/README.md). The compound operators (such as `>>=`) don't convert their arguments to `int` or have the result type as `int`.

The `&`, `|`, and `^` operators are also defined for operands of the `bool` type. For more information, see [Boolean logical operators](boolean-logical-operators.md).

Bitwise and shift operations never cause overflow and produce the same results in [checked and unchecked](../statements/checked-and-unchecked.md) contexts.

## Bitwise complement operator ~

The `~` operator produces a bitwise complement of its operand by reversing each bit:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="BitwiseComplement":::

You can also use the `~` symbol to declare finalizers. For more information, see [Finalizers](../../programming-guide/classes-and-structs/finalizers.md).

## Left-shift operator \<\<

The `<<` operator shifts its left-hand operand left by the number of bits defined by its right-hand operand. For information about how the right-hand operand defines the shift count, see the [Shift count of the shift operators](#shift-count-of-the-shift-operators) section.

The left-shift operation discards the high-order bits that are outside the range of the result type and sets the low-order empty bit positions to zero, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="LeftShift":::

Because the shift operators are defined only for the `int`, `uint`, `long`, and `ulong` types, the result of an operation always contains at least 32 bits. If the left-hand operand is of another integral type (`sbyte`, `byte`, `short`, `ushort`, or `char`), its value is converted to the `int` type, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="LeftShiftPromoted":::

## Right-shift operator >>

The `>>` operator shifts its left-hand operand right by the number of bits defined by its right-hand operand. For information about how the right-hand operand defines the shift count, see the [Shift count of the shift operators](#shift-count-of-the-shift-operators) section.

The right-shift operation discards the low-order bits, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="RightShift":::

The high-order empty bit positions are set based on the type of the left-hand operand as follows:

- If the left-hand operand is of type `int` or `long`, the right-shift operator performs an *arithmetic* shift: the value of the most significant bit (the sign bit) of the left-hand operand is propagated to the high-order empty bit positions. That is, the high-order empty bit positions are set to zero if the left-hand operand is non-negative and set to one if it's negative.

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="ArithmeticRightShift":::

- If the left-hand operand is of type `uint` or `ulong`, the right-shift operator performs a *logical* shift: the high-order empty bit positions are always set to zero.

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="LogicalRightShift":::

> [!NOTE]
> Use the [unsigned right-shift operator](#unsigned-right-shift-operator-) to perform a *logical* shift on operands of signed integer types. The logical shift is preferred to casting a left-hand operand to an unsigned type and then casting the result of a shift operation back to a signed type.

## Unsigned right-shift operator >>>

Available in C# 11 and later, the `>>>` operator shifts its left-hand operand right by the number of bits defined by its right-hand operand. For information about how the right-hand operand defines the shift count, see the [Shift count of the shift operators](#shift-count-of-the-shift-operators) section.

The `>>>` operator always performs a *logical* shift. That is, the high-order empty bit positions are always set to zero, regardless of the type of the left-hand operand. The [`>>` operator](#right-shift-operator-) performs an *arithmetic* shift (that is, the value of the most significant bit is propagated to the high-order empty bit positions) if the left-hand operand is of a signed type. The following example demonstrates the difference between `>>` and `>>>` operators for a negative left-hand operand:

:::code language="csharp" source="./snippets/shared/BitwiseAndShiftOperators.cs" id="SnippetUnsignedRightShift":::

## <a name="logical-and-operator-"></a> Logical AND operator &amp;

The `&` operator computes the bitwise logical AND of its integral operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="BitwiseAnd":::

For `bool` operands, the `&` operator computes the [logical AND](boolean-logical-operators.md#logical-and-operator-) of its operands. The unary `&` operator is the [address-of operator](pointer-related-operators.md#address-of-operator-).

## Logical exclusive OR operator ^

The `^` operator computes the bitwise logical exclusive OR, also known as the bitwise logical XOR, of its integral operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="BitwiseXor":::

For `bool` operands, the `^` operator computes the [logical exclusive OR](boolean-logical-operators.md#logical-exclusive-or-operator-) of its operands.

## Logical OR operator |

The `|` operator computes the bitwise logical OR of its integral operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="BitwiseOr":::

For `bool` operands, the `|` operator computes the [logical OR](boolean-logical-operators.md#logical-or-operator-) of its operands.

## Compound assignment

For a binary operator `op`, a compound assignment expression of the form

```csharp
x op= y
```

Is equivalent to

```csharp
x = x op y
```

Except that `x` is only evaluated once.

The following example demonstrates the usage of compound assignment with bitwise and shift operators:

:::code language="csharp" source="snippets/shared/BitwiseAndShiftOperators.cs" id="CompoundAssignment":::

Because of [numeric promotions](~/_csharpstandard/standard/expressions.md#1247-numeric-promotions), the result of the `op` operation might be not implicitly convertible to the type `T` of `x`. In such a case, if `op` is a predefined operator and the result of the operation is explicitly convertible to the type `T` of `x`, a compound assignment expression of the form `x op= y` is equivalent to `x = (T)(x op y)`, except that `x` is only evaluated once. The following example demonstrates that behavior:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="CompoundAssignmentWithCast":::

## Operator precedence

The following list orders bitwise and shift operators starting from the highest precedence to the lowest:

- Bitwise complement operator `~`
- Shift operators `<<`, `>>`, and `>>>`
- Logical AND operator `&`
- Logical exclusive OR operator `^`
- Logical OR operator `|`

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="Precedence":::

For the complete list of C# operators ordered by precedence level, see the [Operator precedence](index.md#operator-precedence) section of the [C# operators](index.md) article.

## Shift count of the shift operators

For the `x << count`, `x >> count`, and `x >>> count` expressions, the actual shift count depends on the type of `x` as follows:

- If the type of `x` is `int` or `uint`, the low-order *five* bits of the right-hand operand define the shift count. That is, the shift count is computed from `count & 0x1F` (or `count & 0b_1_1111`).

- If the type of `x` is `long` or `ulong`, the low-order *six* bits of the right-hand operand define the shift count. That is, the shift count is computed from `count & 0x3F` (or `count & 0b_11_1111`).

The following example demonstrates that behavior:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/BitwiseAndShiftOperators.cs" id="ShiftCount":::

> [!NOTE]
> As the preceding example shows, the result of a shift operation can be non-zero even if the value of the right-hand operand is greater than the number of bits in the left-hand operand.

## Enumeration logical operators

Every [enumeration](../builtin-types/enum.md) type supports the `~`, `&`, `|`, and `^` operators. For operands of the same enumeration type, a logical operation is performed on the corresponding values of the underlying integral type. For example, for any `x` and `y` of an enumeration type `T` with an underlying type `U`, the `x & y` expression produces the same result as the `(T)((U)x & (U)y)` expression.

You typically use bitwise logical operators with an enumeration type that is defined with the [Flags](xref:System.FlagsAttribute) attribute. For more information, see the [Enumeration types as bit flags](../builtin-types/enum.md#enumeration-types-as-bit-flags) section of the [Enumeration types](../builtin-types/enum.md) article.

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `~`, `<<`, `>>`, `>>>`, `&`, `|`, and `^` operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. Beginning with C# 14, a user-defined type can explicitly overload the compound assignment operators to provide a more efficient implementation. Typically, a type overloads these operators because the value can be updated in place, rather than allocating performing the addition and return a new instance. If a type doesn't provide an explicit overload, the compiler generates the implicit overload.

If a user-defined type `T` overloads the `<<`, `>>`, or `>>>` operator, the type of the left-hand operand must be `T`. In C# 10 and earlier, the type of the right-hand operand must be `int`; beginning with C# 11, the type of the right-hand operand of an overloaded shift operator can be any.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Bitwise complement operator](~/_csharpstandard/standard/expressions.md#1295-bitwise-complement-operator)
- [Shift operators](~/_csharpstandard/standard/expressions.md#1211-shift-operators)
- [Logical operators](~/_csharpstandard/standard/expressions.md#1213-logical-operators)
- [Compound assignment](~/_csharpstandard/standard/expressions.md#12214-compound-assignment)
- [Numeric promotions](~/_csharpstandard/standard/expressions.md#1247-numeric-promotions)
- [C# 11 - Relaxed shift requirements](~/_csharplang/proposals/csharp-11.0/relaxing_shift_operator_requirements.md)
- [C# 11 - Logical right-shift operator](~/_csharplang/proposals/csharp-11.0/unsigned-right-shift-operator.md)
- [User defined compound assignment](~/_csharplang/proposals/user-defined-compound-assignment.md)

## See also

- [C# operators and expressions](index.md)
- [Boolean logical operators](boolean-logical-operators.md)
