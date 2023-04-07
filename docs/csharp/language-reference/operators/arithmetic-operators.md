---
title: "Arithmetic operators - C# reference"
description: "Learn about C# operators that perform multiplication, division, remainder, addition, and subtraction operations with numeric types."
ms.date: 07/25/2022
author: pkulikov
f1_keywords: 
  - "++_CSharpKeyword"
  - "--_CSharpKeyword"
  - "*_CSharpKeyword"
  - "/_CSharpKeyword"
  - "%_CSharpKeyword"
  - "+_CSharpKeyword"
  - "-_CSharpKeyword"
  - "%=_CSharpKeyword"
  - "*=_CSharpKeyword"
helpviewer_keywords: 
  - "arithmetic operators [C#]"
  - "checked operators [C#]"
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

The following operators perform arithmetic operations with operands of numeric types:

- Unary [`++` (increment)](#increment-operator-), [`--` (decrement)](#decrement-operator---), [`+` (plus)](#unary-plus-and-minus-operators), and [`-` (minus)](#unary-plus-and-minus-operators) operators
- Binary [`*` (multiplication)](#multiplication-operator-), [`/` (division)](#division-operator-), [`%` (remainder)](#remainder-operator-), [`+` (addition)](#addition-operator-), and [`-` (subtraction)](#subtraction-operator--) operators

Those operators are supported by all [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types.

In the case of integral types, those operators (except the `++` and `--` operators) are defined for the `int`, `uint`, `long`, and `ulong` types. When operands are of other integral types (`sbyte`, `byte`, `short`, `ushort`, or `char`), their values are converted to the `int` type, which is also the result type of an operation. When operands are of different integral or floating-point types, their values are converted to the closest containing type, if such a type exists. For more information, see the [Numeric promotions](~/_csharpstandard/standard/expressions.md#1147-numeric-promotions) section of the [C# language specification](~/_csharpstandard/standard/README.md). The `++` and `--` operators are defined for all integral and floating-point numeric types and the [char](../builtin-types/char.md) type. The result type of a [compound assignment expression](#compound-assignment) is the type of the left-hand operand.

## Increment operator ++

The unary increment operator `++` increments its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../programming-guide/indexers/index.md) access.

The increment operator is supported in two forms: the postfix increment operator, `x++`, and the prefix increment operator, `++x`.

### Postfix increment operator

The result of `x++` is the value of `x` *before* the operation, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="PostfixIncrement":::

### Prefix increment operator

The result of `++x` is the value of `x` *after* the operation, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="PrefixIncrement":::

## Decrement operator --

The unary decrement operator `--` decrements its operand by 1. The operand must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../programming-guide/indexers/index.md) access.

The decrement operator is supported in two forms: the postfix decrement operator, `x--`, and the prefix decrement operator, `--x`.

### Postfix decrement operator

The result of `x--` is the value of `x` *before* the operation, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="PostfixDecrement":::

### Prefix decrement operator

The result of `--x` is the value of `x` *after* the operation, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="PrefixDecrement":::

## Unary plus and minus operators

The unary `+` operator returns the value of its operand. The unary `-` operator computes the numeric negation of its operand.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="UnaryPlusAndMinus":::

The [ulong](../builtin-types/integral-numeric-types.md) type doesn't support the unary `-` operator.

## Multiplication operator *

The multiplication operator `*` computes the product of its operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="Multiplication":::

The unary `*` operator is the [pointer indirection operator](pointer-related-operators.md#pointer-indirection-operator-).

## Division operator /

The division operator `/` divides its left-hand operand by its right-hand operand.

### Integer division

For the operands of integer types, the result of the `/` operator is of an integer type and equals the quotient of the two operands rounded towards zero:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="IntegerDivision":::

To obtain the quotient of the two operands as a floating-point number, use the `float`, `double`, or `decimal` type:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="IntegerAsFloatingPointDivision":::

### Floating-point division

For the `float`, `double`, and `decimal` types, the result of the `/` operator is the quotient of the two operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="FloatingPointDivision":::

If one of the operands is `decimal`, another operand can be neither `float` nor `double`, because neither `float` nor `double` is implicitly convertible to `decimal`. You must explicitly convert the `float` or `double` operand to the `decimal` type. For more information about conversions between numeric types, see [Built-in numeric conversions](../builtin-types/numeric-conversions.md).

## Remainder operator %

The remainder operator `%` computes the remainder after dividing its left-hand operand by its right-hand operand.

### Integer remainder

For the operands of integer types, the result of `a % b` is the value produced by `a - (a / b) * b`. The sign of the non-zero remainder is the same as the sign of the left-hand operand, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="IntegerRemainder":::

Use the <xref:System.Math.DivRem%2A?displayProperty=nameWithType> method to compute both integer division and remainder results.

### Floating-point remainder

For the `float` and `double` operands, the result of `x % y` for the finite `x` and `y` is the value `z` such that

- The sign of `z`, if non-zero, is the same as the sign of `x`.
- The absolute value of `z` is the value produced by `|x| - n * |y|` where `n` is the largest possible integer that is less than or equal to `|x| / |y|` and `|x|` and `|y|` are the absolute values of `x` and `y`, respectively.

> [!NOTE]
> This method of computing the remainder is analogous to that used for integer operands, but different from the IEEE 754 specification. If you need the remainder operation that complies with the IEEE 754 specification, use the <xref:System.Math.IEEERemainder%2A?displayProperty=nameWithType> method.

For information about the behavior of the `%` operator with non-finite operands, see the [Remainder operator](~/_csharpstandard/standard/expressions.md#11104-remainder-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For the `decimal` operands, the remainder operator `%` is equivalent to the [remainder operator](<xref:System.Decimal.op_Modulus(System.Decimal,System.Decimal)>) of the <xref:System.Decimal?displayProperty=nameWithType> type.

The following example demonstrates the behavior of the remainder operator with floating-point operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="FloatingPointRemainder":::

## Addition operator +

The addition operator `+` computes the sum of its operands:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="Addition":::

You can also use the `+` operator for string concatenation and delegate combination. For more information, see the [`+` and `+=` operators](addition-operator.md) article.

## Subtraction operator -

The subtraction operator `-` subtracts its right-hand operand from its left-hand operand:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="Subtraction":::

You can also use the `-` operator for delegate removal. For more information, see the [`-` and `-=` operators](subtraction-operator.md) article.

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

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="CompoundAssignment":::

Because of [numeric promotions](~/_csharpstandard/standard/expressions.md#1147-numeric-promotions), the result of the `op` operation might be not implicitly convertible to the type `T` of `x`. In such a case, if `op` is a predefined operator and the result of the operation is explicitly convertible to the type `T` of `x`, a compound assignment expression of the form `x op= y` is equivalent to `x = (T)(x op y)`, except that `x` is only evaluated once. The following example demonstrates that behavior:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="CompoundAssignmentWithCast":::

You also use the `+=` and `-=` operators to subscribe to and unsubscribe from an [event](../keywords/event.md), respectively. For more information, see [How to subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator precedence and associativity

The following list orders arithmetic operators starting from the highest precedence to the lowest:

- Postfix increment `x++` and decrement `x--` operators
- Prefix increment `++x` and decrement `--x` and unary `+` and `-` operators
- Multiplicative `*`, `/`, and `%` operators
- Additive `+` and `-` operators

Binary arithmetic operators are left-associative. That is, operators with the same precedence level are evaluated from left to right.

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence and associativity.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="PrecedenceAndAssociativity":::

For the complete list of C# operators ordered by precedence level, see the [Operator precedence](index.md#operator-precedence) section of the [C# operators](index.md) article.

## Arithmetic overflow and division by zero

When the result of an arithmetic operation is outside the range of possible finite values of the involved numeric type, the behavior of an arithmetic operator depends on the type of its operands.

### Integer arithmetic overflow

Integer division by zero always throws a <xref:System.DivideByZeroException>.

If integer arithmetic overflow occurs, the overflow-checking context, which can be [checked or unchecked](../statements/checked-and-unchecked.md), controls the resulting behavior:

- In a checked context, if overflow happens in a constant expression, a compile-time error occurs. Otherwise, when the operation is performed at run time, an <xref:System.OverflowException> is thrown.
- In an unchecked context, the result is truncated by discarding any high-order bits that don't fit in the destination type.

Along with the [checked and unchecked](../statements/checked-and-unchecked.md) statements, you can use the `checked` and `unchecked` operators to control the overflow-checking context, in which an expression is evaluated:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="CheckedUnchecked":::

By default, arithmetic operations occur in an *unchecked* context.

### Floating-point arithmetic overflow

Arithmetic operations with the `float` and `double` types never throw an exception. The result of arithmetic operations with those types can be one of special values that represent infinity and not-a-number:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="FloatingPointOverflow":::

For the operands of the `decimal` type, arithmetic overflow always throws an <xref:System.OverflowException>. Division by zero always throws a <xref:System.DivideByZeroException>.

## Round-off errors

Because of general limitations of the floating-point representation of real numbers and floating-point arithmetic, round-off errors might occur in calculations with floating-point types. That is, the produced result of an expression might differ from the expected mathematical result. The following example demonstrates several such cases:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ArithmeticOperators.cs" id="RoundOffErrors":::

For more information, see remarks at the [System.Double](/dotnet/api/system.double#remarks), [System.Single](/dotnet/api/system.single#remarks), or [System.Decimal](/dotnet/api/system.decimal#remarks) reference pages.

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the unary (`++`, `--`, `+`, and `-`) and binary (`*`, `/`, `%`, `+`, and `-`) arithmetic operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type can't explicitly overload a compound assignment operator.

### User-defined checked operators

Beginning with C# 11, when you overload an arithmetic operator, you can use the `checked` keyword to define the *checked* version of that operator. The following example shows how to do that:

:::code language="csharp" source="snippets/shared/ArithmeticOperators.cs" id="CheckedOperator":::

When you define a checked operator, you must also define the corresponding operator without the `checked` modifier. The checked operator is called in a [checked context](../statements/checked-and-unchecked.md); the operator without the `checked` modifier is called in an [unchecked context](../statements/checked-and-unchecked.md). If you only provide the operator without the `checked` modifier, it's called in both a `checked` and `unchecked` context.

When you define both versions of an operator, it's expected that their behavior differs only when the result of an operation is too large to represent in the result type as follows:

- A checked operator throws an <xref:System.OverflowException>.
- An operator without the `checked` modifier returns an instance representing a *truncated* result.

For information about the difference in behavior of the built-in arithmetic operators, see the [Arithmetic overflow and division by zero](#arithmetic-overflow-and-division-by-zero) section.

You can use the `checked` modifier only when you overload any of the following operators:

- Unary `++`, `--`, and `-` operators
- Binary `*`, `/`, `+`, and `-` operators
- [Explicit conversion operators](user-defined-conversion-operators.md)

> [!NOTE]
> The overflow-checking context within the body of a checked operator is not affected by the presence of the `checked` modifier. The default context is defined by the value of the [**CheckForOverflowUnderflow**](../compiler-options/language.md#checkforoverflowunderflow) compiler option. Use the [`checked` and `unchecked` statements](../statements/checked-and-unchecked.md) to explicitly specify the overflow-checking context, as the example at the beginning of this section demonstrates.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Postfix increment and decrement operators](~/_csharpstandard/standard/expressions.md#11815-postfix-increment-and-decrement-operators)
- [Prefix increment and decrement operators](~/_csharpstandard/standard/expressions.md#1196-prefix-increment-and-decrement-operators)
- [Unary plus operator](~/_csharpstandard/standard/expressions.md#1192-unary-plus-operator)
- [Unary minus operator](~/_csharpstandard/standard/expressions.md#1193-unary-minus-operator)
- [Multiplication operator](~/_csharpstandard/standard/expressions.md#11102-multiplication-operator)
- [Division operator](~/_csharpstandard/standard/expressions.md#11103-division-operator)
- [Remainder operator](~/_csharpstandard/standard/expressions.md#11104-remainder-operator)
- [Addition operator](~/_csharpstandard/standard/expressions.md#11105-addition-operator)
- [Subtraction operator](~/_csharpstandard/standard/expressions.md#11106-subtraction-operator)
- [Compound assignment](~/_csharpstandard/standard/expressions.md#11213-compound-assignment)
- [The checked and unchecked operators](~/_csharpstandard/standard/expressions.md#11819-the-checked-and-unchecked-operators)
- [Numeric promotions](~/_csharpstandard/standard/expressions.md#1147-numeric-promotions)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- <xref:System.Math?displayProperty=nameWithType>
- <xref:System.MathF?displayProperty=nameWithType>
- [Numerics in .NET](../../../standard/numerics.md)
