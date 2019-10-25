---
title: "Arithmetic operators - C# reference"
description: "Learn about C# operators that perform multiplication, division, remainder, addition, and subtraction operations with numeric types."
ms.date: 03/27/2019
author: pkulikov
f1_keywords: 
  - "++_CSharpKeyword"
  - "--_CSharpKeyword"
  - "*_CSharpKeyword"
  - "/_CSharpKeyword"
  - "%_CSharpKeyword"
  - "+_CSharpKeyword"
  - "-_CSharpKeyword"
helpviewer_keywords: 
  - "arithmetic operators [C#]"
  - "increment operator [C#]"
  - "++ operator [C#]"
  - "decrement operator [C#]"
  - "-- operator [C#]"
  - "multiplication operator [C#]"
  - "* operator [C#]"
  - "division operator [C#]"
  - "/ operator [C#]"
  - "remainder operator [C#]"
  - "% operator [C#]"
  - "addition operator [C#]"
  - "+ operator [C#]"
  - "subtraction operator [C#]"
  - "- operator [C#]"
---
# Arithmetic operators (C# reference)

The following operators perform arithmetic operations with numeric types:

- Unary [`++` (increment)](#increment-operator-), [`--` (decrement)](#decrement-operator---), [`+` (plus)](#unary-plus-and-minus-operators), and [`-` (minus)](#unary-plus-and-minus-operators) operators
- Binary [`*` (multiplication)](#multiplication-operator-), [`/` (division)](#division-operator-), [`%` (remainder)](#remainder-operator-), [`+` (addition)](#addition-operator-), and [`-` (subtraction)](#subtraction-operator--) operators

Those operators support all [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types.

## Increment operator ++

The unary increment operator `++` increments its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../programming-guide/indexers/index.md) access.

The increment operator is supported in two forms: the postfix increment operator, `x++`, and the prefix increment operator, `++x`.

### Postfix increment operator

The result of `x++` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix increment](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#PostfixIncrement)]

### Prefix increment operator

The result of `++x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix increment](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#PrefixIncrement)]

## Decrement operator --

The unary decrement operator `--` decrements its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../programming-guide/indexers/index.md) access.

The decrement operator is supported in two forms: the postfix decrement operator, `x--`, and the prefix decrement operator, `--x`.

### Postfix decrement operator

The result of `x--` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix decrement](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#PostfixDecrement)]

### Prefix decrement operator

The result of `--x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix decrement](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#PrefixDecrement)]

## Unary plus and minus operators

The unary `+` operator returns the value of its operand. The unary `-` operator computes the numeric negation of its operand.

[!code-csharp-interactive[unary plus and minus](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#UnaryPlusAndMinus)]

The unary `-` operator doesn't support the [ulong](../builtin-types/integral-numeric-types.md) type.

## Multiplication operator *

The multiplication operator `*` computes the product of its operands:

[!code-csharp-interactive[multiplication operator](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#Multiplication)]

The unary `*` operator is the [pointer indirection operator](pointer-related-operators.md#pointer-indirection-operator-).

## Division operator /

The division operator `/` divides its left-hand operand by its right-hand operand.

### Integer division

For the operands of integer types, the result of the `/` operator is of an integer type and equals the quotient of the two operands rounded towards zero:

[!code-csharp-interactive[integer division](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerDivision)]

To obtain the quotient of the two operands as a floating-point number, use the `float`, `double`, or `decimal` type:

[!code-csharp-interactive[integer as floating-point division](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerAsFloatingPointDivision)]

### Floating-point division

For the `float`, `double`, and `decimal` types, the result of the `/` operator is the quotient of the two operands:

[!code-csharp-interactive[floating-point division](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#FloatingPointDivision)]

If one of the operands is `decimal`, another operand can be neither `float` nor `double`, because neither `float` nor `double` is implicitly convertible to `decimal`. You must explicitly convert the `float` or `double` operand to the `decimal` type. For more information about conversions between numeric types, see [Built-in numeric conversions](../builtin-types/numeric-conversions.md).

## Remainder operator %

The remainder operator `%` computes the remainder after dividing its left-hand operand by its right-hand operand.

### Integer remainder
  
For the operands of integer types, the result of `a % b` is the value produced by `a - (a / b) * b`. The sign of the non-zero remainder is the same as that of the left-hand operand, as the following example shows:

[!code-csharp-interactive[integer remainder](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerRemainder)]

Use the <xref:System.Math.DivRem%2A?displayProperty=nameWithType> method to compute both integer division and remainder results.

### Floating-point remainder

For the `float` and `double` operands, the result of `x % y` for the finite `x` and `y` is the value `z` such that

- The sign of `z`, if non-zero, is the same as the sign of `x`.
- The absolute value of `z` is the value produced by `|x| - n * |y|` where `n` is the largest possible integer that is less than or equal to `|x| / |y|` and `|x|` and `|y|` are the absolute values of `x` and `y`, respectively.

> [!NOTE]
> This method of computing the remainder is analogous to that used for integer operands, but differs from the IEEE 754. If you need the remainder operation that complies with the IEEE 754, use the <xref:System.Math.IEEERemainder%2A?displayProperty=nameWithType> method.

For information about the behavior of the `%` operator with non-finite operands, see the [Remainder operator](~/_csharplang/spec/expressions.md#remainder-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For the `decimal` operands, the remainder operator `%` is equivalent to the [remainder operator](<xref:System.Decimal.op_Modulus(System.Decimal,System.Decimal)>) of the <xref:System.Decimal?displayProperty=nameWithType> type.

The following example demonstrates the behavior of the remainder operator with floating-point operands:

[!code-csharp-interactive[floating-point remainder](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#FloatingPointRemainder)]

## Addition operator +

The addition operator `+` computes the sum of its operands:

[!code-csharp-interactive[addition operator](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#Addition)]

You also can use the `+` operator for string concatenation and delegate combination. For more information, see the [`+` and `+=` operators](addition-operator.md) article.

## Subtraction operator -

The subtraction operator `-` subtracts its right-hand operand from its left-hand operand:

[!code-csharp-interactive[subtraction operator](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#Subtraction)]

You also can use the `-` operator for delegate removal. For more information, see the [`-` operator](subtraction-operator.md) article.

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

The following example demonstrates the usage of compound assignment with arithmetic operators:

[!code-csharp-interactive[compound assignment](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#CompoundAssignment)]

Because of [numeric promotions](~/_csharplang/spec/expressions.md#numeric-promotions), the result of the `op` operation might be not implicitly convertible to the type `T` of `x`. In such a case, if `op` is a predefined operator and the result of the operation is explicitly convertible to the type `T` of `x`, a compound assignment expression of the form `x op= y` is equivalent to `x = (T)(x op y)`, except that `x` is only evaluated once. The following example demonstrates that behavior:

[!code-csharp-interactive[compound assignment with cast](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#CompoundAssignmentWithCast)]

You also use the `+=` and `-=` operators to subscribe to and unsubscribe from [events](../keywords/event.md). For more information, see [How to: subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator precedence and associativity

The following list orders arithmetic operators starting from the highest precedence to the lowest:

- Postfix increment `x++` and decrement `x--` operators
- Prefix increment `++x` and decrement `--x` and unary `+` and `-` operators
- Multiplicative `*`, `/`, and `%` operators
- Additive `+` and `-` operators

Binary arithmetic operators are left-associative. That is, operators with the same precedence level are evaluated from left to right.

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence and associativity.

[!code-csharp-interactive[precedence and associativity](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#PrecedenceAndAssociativity)]

For the complete list of C# operators ordered by precedence level, see [C# operators](index.md).

## Arithmetic overflow and division by zero

When the result of an arithmetic operation is outside the range of possible finite values of the involved numeric type, the behavior of an arithmetic operator depends on the type of its operands.

### Integer arithmetic overflow

Integer division by zero always throws a <xref:System.DivideByZeroException>.

In case of integer arithmetic overflow, an overflow checking context, which can be [checked or unchecked](../keywords/checked-and-unchecked.md), controls the resulting behavior:

- In a checked context, if overflow happens in a constant expression, a compile-time error occurs. Otherwise, when the operation is performed at run time, an <xref:System.OverflowException> is thrown.
- In an unchecked context, the result is truncated by discarding any high-order bits that don't fit in the destination type.

Along with the [checked and unchecked](../keywords/checked-and-unchecked.md) statements, you can use the `checked` and `unchecked` operators to control the overflow checking context, in which an expression is evaluated:

[!code-csharp-interactive[checked and unchecked](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#CheckedUnchecked)]

By default, arithmetic operations occur in an *unchecked* context.

### Floating-point arithmetic overflow

Arithmetic operations with the `float` and `double` types never throw an exception. The result of arithmetic operations with those types can be one of special values that represent infinity and not-a-number:

[!code-csharp-interactive[double non-finite values](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#FloatingPointOverflow)]

For the operands of the `decimal` type, arithmetic overflow always throws an <xref:System.OverflowException> and division by zero always throws a <xref:System.DivideByZeroException>.

## Round-off errors

Because of general limitations of the floating-point representation of real numbers and floating-point arithmetic, the round-off errors might occur in calculations with floating-point types. That is, the produced result of an expression might differ from the expected mathematical result. The following example demonstrates several such cases:

[!code-csharp-interactive[round-off errors](~/samples/csharp/language-reference/operators/ArithmeticOperators.cs#RoundOffErrors)]

For more information, see remarks at [System.Double](/dotnet/api/system.double#remarks), [System.Single](/dotnet/api/system.single#remarks), or [System.Decimal](/dotnet/api/system.decimal#remarks) reference pages.

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the unary (`++`, `--`, `+`, and `-`) and binary (`*`, `/`, `%`, `+`, and `-`) arithmetic operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type cannot explicitly overload a compound assignment operator.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Postfix increment and decrement operators](~/_csharplang/spec/expressions.md#postfix-increment-and-decrement-operators)
- [Prefix increment and decrement operators](~/_csharplang/spec/expressions.md#prefix-increment-and-decrement-operators)
- [Unary plus operator](~/_csharplang/spec/expressions.md#unary-plus-operator)
- [Unary minus operator](~/_csharplang/spec/expressions.md#unary-minus-operator)
- [Multiplication operator](~/_csharplang/spec/expressions.md#multiplication-operator)
- [Division operator](~/_csharplang/spec/expressions.md#division-operator)
- [Remainder operator](~/_csharplang/spec/expressions.md#remainder-operator)
- [Addition operator](~/_csharplang/spec/expressions.md#addition-operator)
- [Subtraction operator](~/_csharplang/spec/expressions.md#subtraction-operator)
- [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment)
- [The checked and unchecked operators](~/_csharplang/spec/expressions.md#the-checked-and-unchecked-operators)
- [Numeric promotions](~/_csharplang/spec/expressions.md#numeric-promotions)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- <xref:System.Math?displayProperty=nameWithType>
- <xref:System.MathF?displayProperty=nameWithType>
- [Numerics in .NET](../../../standard/numerics.md)
