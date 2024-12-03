---
title: "Addition operators - + and +="
description: "The C# addition operators (`+`, and `+=`) work with operands of numeric, string, or delegate types."
ms.date: 11/22/2024
f1_keywords: 
  - "+_CSharpKeyword"
  - "+=_CSharpKeyword"
helpviewer_keywords: 
  - "addition operator [C#]"
  - "concatenation operator [C#]"
  - "delegate combination [C#]"
  - "+ operator [C#]"
  - "addition assignment operator [C#]"
  - "event subscription [C#]"
  - "+= operator [C#]"
---
# Addition operators - `+` and `+=`

The `+` and `+=` operators are supported by the built-in [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types, the [string](../builtin-types/reference-types.md#the-string-type) type, and [delegate](../builtin-types/reference-types.md#the-delegate-type) types.

For information about the arithmetic `+` operator, see the [Unary plus and minus operators](arithmetic-operators.md#unary-plus-and-minus-operators) and [Addition operator +](arithmetic-operators.md#addition-operator-) sections of the [Arithmetic operators](arithmetic-operators.md) article.

## String concatenation

When one or both operands are of type [string](../builtin-types/reference-types.md#the-string-type), the `+` operator concatenates the string representations of its operands (the string representation of `null` is an empty string):

[!code-csharp-interactive[string concatenation](snippets/shared/AdditionOperator.cs#AddStrings)]

[String interpolation](../tokens/interpolated.md) provides a more convenient way to format strings:

[!code-csharp-interactive[string interpolation](snippets/shared/AdditionOperator.cs#UseStringInterpolation)]

You can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

Beginning with C# 11, the `+` operator performs string concatenation for UTF-8 literal strings. This operator concatenates two `ReadOnlySpan<byte>` objects.

## Delegate combination

For operands of the same [delegate](../builtin-types/reference-types.md#the-delegate-type) type, the `+` operator returns a new delegate instance that, when invoked, invokes the left-hand operand and then invokes the right-hand operand. If any of the operands is `null`, the `+` operator returns the value of another operand (which also might be `null`). The following example shows how delegates can be combined with the `+` operator:

[!code-csharp-interactive[delegate combination](snippets/shared/AdditionOperator.cs#AddDelegates)]

To perform delegate removal, use the [`-` operator](subtraction-operator.md#delegate-removal).

For more information about delegate types, see [Delegates](../../programming-guide/delegates/index.md).

## Addition assignment operator +=

An expression using the `+=` operator, such as

```csharp
x += y
```

Is equivalent to:

```csharp
x = x + y
```

Except that `x` is only evaluated once.

The following example demonstrates the usage of the `+=` operator:

[!code-csharp-interactive[+= examples](snippets/shared/AdditionOperator.cs#AddAndAssign)]

You also use the `+=` operator to specify an event handler method when you subscribe to an [event](../keywords/event.md). For more information, see [How to: subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `+` operator. When a binary `+` operator is overloaded, the `+=` operator is also implicitly overloaded. A user-defined type can't explicitly overload the `+=` operator.

## C# language specification

For more information, see the [Unary plus operator](~/_csharpstandard/standard/expressions.md#1292-unary-plus-operator) and [Addition operator](~/_csharpstandard/standard/expressions.md#12105-addition-operator) sections of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
- [How to concatenate multiple strings](../../how-to/concatenate-multiple-strings.md)
- [Events](../../programming-guide/events/index.md)
- [Arithmetic operators](arithmetic-operators.md)
- [- and -= operators](subtraction-operator.md)
