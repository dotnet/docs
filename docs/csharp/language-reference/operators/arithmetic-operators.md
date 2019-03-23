---
title: "Arithmetic operators - C# Reference"
description: "Learn about C# operators for arithmetic operations with numbers such as addition, subtraction, multiplication, division, and remainder."
ms.date: 03/24/2019
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
  - "increment operator (++) [C#]"
  - "++ operator [C#]"
  - "decrement operator (--) [C#]"
  - "-- operator [C#]"
  - "multiplication operator (*) [C#]"
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
# Arithmetic operators (C# Reference)

You can use the following operators to perform arithmetic operations with numeric types:

- Unary `++` (increment), `--` (decrement), `+` (plus), and `-` (minus) operators.
- Binary `*` (multiplication), `/` (division), `%` (remainder), `+` (addition), and `-` (subtraction) operators.

Those operators support all [integral](../keywords/integral-types-table.md) and [floating-point](../keywords/floating-point-types-table.md) numeric types. The `++`, `--`, `+`, and `-` operators also support operands of an [enum](../keywords/enum.md) type.

## Increment operator ++

The unary increment operator `++` increments its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../../csharp/programming-guide/indexers/index.md) access.

The increment operator is supported in two forms: the postfix increment operator, `x++`, and the prefix increment operator, `++x`.

### Postfix increment operator

The result of `x++` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix increment](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#PostfixIncrement)]

### Prefix increment operator

The result of `++x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix increment](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#PrefixIncrement)]

## Decrement operator --

The unary decrement operator `--` decrements its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../../csharp/programming-guide/indexers/index.md) access.

The decrement operator is supported in two forms: the postfix decrement operator, `x--`, and the prefix decrement operator, `--x`.

### Postfix decrement operator

The result of `x--` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix decrement](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#PostfixDecrement)]

### Prefix decrement operator

The result of `--x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix decrement](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#PrefixDecrement)]

## Unary plus and minus operators

The unary `+` operator returns the value of its operand. The unary `-` operator computes the numeric negation of its operand.

[!code-csharp-interactive[unary plus and minus](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#UnaryPlusAndMinus)]

The unary `-` operator doesn't support the [ulong](../keywords/ulong.md) type.

## Multiplication operator *

The multiplication operator `*` computes the product of its operands:

[!code-csharp-interactive[multiplication operator](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#Multiplication)]

The unary `*` operator is a [pointer indirection operator](multiplication-operator.md#pointer-indirection-operator).

## Division operator /

The division operator `/` divides its first operand by its second operand.

### Integer division

For the operands of integer types, the result of the `/` operator is of an integer type and equals the quotient of the two operands rounded towards zero:

[!code-csharp-interactive[integer division](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerDivision)]

To obtain the quotient of the two operands as a floating-point number, use the `float`, `double`, or `decimal` type:

[!code-csharp-interactive[integer as floating-point division](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerAsFloatingPointDivision)]

### Floating-point division

For the `float`, `double`, and `decimal` types, the result of the `/` operator is the quotient of the two operands:

[!code-csharp-interactive[floating-point division](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#FloatingPointDivision)]

If one of the operands is `decimal`, another operand can be neither `float` nor `double`, because neither `float` nor `double` is implicitly convertible to `decimal`. You must explicitly convert the `float` or `double` operand to the `decimal` type. For more information about implicit conversions between numeric types, see [Implicit numeric conversions table](../keywords/implicit-numeric-conversions-table.md).

## Remainder operator %

The remainder operator `%` computes the remainder after dividing its first operand by its second operand.

### Integer remainder
  
For the operands of integer types, the result of `a % b` is the value produced by `a - (a / b) * b`. The sign of the non-zero remainder is the same as that of the first operand, as the following example shows:

[!code-csharp-interactive[integer remainder](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#IntegerRemainder)]

Use the <xref:System.Math.DivRem%2A?displayProperty=nameWithType> method to compute both integer division and remainder results.

### Floating-point remainder

For the `float` and `double` operands, the result of `x % y` for the finite `x` and `y` is the value `z` such that

- The sign of `z`, if non-zero, is the same as the sign of `x`.
- The absolute value of `z` is the value produced by `|x| - n * |y|` where `n` is the largest possible integer that is less than or equal to `|x| / |y|` and `|x|` and `|y|` are the absolute values of `x` and `y`, respectively.

> [!NOTE]
> This method of computing the remainder is analogous to that used for integer operands, but differs from the IEEE 754. If you need the remainder operation that complies with the IEEE 754, use the <xref:System.Math.IEEERemainder%2A?displayProperty=nameWithType> method.

For information about the behavior of the `%` operator with non-finite operands, see the [Remainder operator](~/_csharplang/spec/expressions.md#remainder-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

The following example demonstrates the behavior of the remainder operator for `float` and `double` operands:

[!code-csharp-interactive[float and double remainder](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#FloatingPointRemainder)]

Note the round-off errors that can be associated with the floating-point types.

For the `decimal` operands, the remainder operator `%` is equivalent to the [remainder operator](<xref:System.Decimal.op_Modulus(System.Decimal,System.Decimal)>) of the <xref:System.Decimal?displayProperty=nameWithType> type.

## Addition operator +

The addition operator `+` computes the sum of its operands:

[!code-csharp-interactive[addition operator](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#Addition)]

You also can use the `+` operator for string concatenation and delegate combination. For more information, see the [`+` operator](addition-operator.md) article.

## Subtraction operator -

The subtraction operator `-` subtracts its second operand from its first operand:

[!code-csharp-interactive[subtraction operator](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#Subtraction)]

You also can use the `-` operator for delegate removal. For more information, see the [`-` operator](subtraction-operator.md) article.

## Operator precedence and associativity

The following list orders arithmetic operators starting from the highest precedence to the lowest:

- Postfix increment `x++` and decrement `x--` operators.
- Prefix increment `++x` and decrement `--x` and unary `+` and `-` operators.
- Multiplicative operators `*`, `/`, and `%`.
- Additive operators `+` and `-`.

Binary operators are left-associative. That is, operators with the same precedence level are evaluated from left to right.

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence and associativity.

[!code-csharp-interactive[precedence and associativity](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#PrecedenceAndAssociativity)]

For the full list of operators ordered by precedence level, see [C# operators](index.md).

## Compound assignment

A compound assignment expression of the form

```csharp
x op= y
```

is equivalent to

```csharp
x = x op y
```

except that `x` is only evaluated once. The `op` operation can be `*`, `/`, `%`, `+`, or `-`.

The following example demonstrates the usage of compound assignment:

[!code-csharp-interactive[compound assignment](~/samples/snippets/csharp/language-reference/operators/ArithmeticOperators.cs#CompoundAssignment)]

You also use the `+=` and `-=` operators to subscribe to and unsubscribe from [events](../keywords/event.md). For more information, see [How to: subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Arithmetic overflow

Integer (checked/unchecked). Floating-point (NaN, Infinity). Decimal.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the unary `++`, `--`, `+`, `-` and binary `*`, `/`, `%`, `+`, and `-` operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type cannot explicitly overload a compound assignment operator.

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

## See also

- <xref:System.Math?displayProperty=nameWithType>
- <xref:System.MathF?displayProperty=nameWithType>
- [Numerics in .NET](../../../standard/numerics.md)