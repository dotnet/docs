---
title: "Addition operators - + and +="
description: "The C# addition operators (`+`, and `+=`) work with operands of numeric, string, or delegate types."
ms.date: 06/11/2025
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

The built-in [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types, the [string](../builtin-types/reference-types.md#the-string-type) type, and [delegate](../builtin-types/reference-types.md#the-delegate-type) types all support the `+` and `+=` operators.

For information about the arithmetic `+` operator, see the [Unary plus and minus operators](arithmetic-operators.md#unary-plus-and-minus-operators) and [Addition operator +](arithmetic-operators.md#addition-operator-) sections of the [Arithmetic operators](arithmetic-operators.md) article.

## String concatenation

When one or both operands are of type [string](../builtin-types/reference-types.md#the-string-type), the `+` operator concatenates the string representations of its operands (the string representation of `null` is an empty string):

:::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/AdditionOperator.cs" id="AddStrings":::

[String interpolation](../tokens/interpolated.md) provides a more convenient way to format strings:

:::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/AdditionOperator.cs" id="UseStringInterpolation":::

You can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

Beginning with C# 11, the `+` operator performs string concatenation for UTF-8 literal strings. This operator concatenates two `ReadOnlySpan<byte>` objects.

## Delegate combination

For operands of the same [delegate](../builtin-types/reference-types.md#the-delegate-type) type, the `+` operator returns a new delegate instance that, when invoked, invokes the left-hand operand and then invokes the right-hand operand. If any of the operands is `null`, the `+` operator returns the value of another operand (which also might be `null`). The following example shows how delegates can be combined with the `+` operator:

:::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/AdditionOperator.cs" id="AddDelegates":::

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

:::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/AdditionOperator.cs" id="AddAndAssign":::

You also use the `+=` operator to specify an event handler method when you subscribe to an [event](../keywords/event.md). For more information, see [How to: subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `+` operator. When a binary `+` operator is overloaded, the `+=` operator is also implicitly overloaded. Beginning with C# 14, a user-defined type can explicitly overload the `+=` operator to provide a more efficient implementation. Typically, a type overloads the `+=` operator because the value can be updated in place, rather than allocating performing the addition and return a new instance. If a type doesn't provide an explicit overload, the compiler generates the implicit overload.

## C# language specification

For more information, see the [Unary plus operator](~/_csharpstandard/standard/expressions.md#1292-unary-plus-operator) and [Addition operator](~/_csharpstandard/standard/expressions.md#12105-addition-operator) sections of the [C# language specification](~/_csharpstandard/standard/README.md). For more information on overloading the compound assignment operators in C# 14 and later, see the [user defined compound assignment](~/_csharplang/proposals/user-defined-compound-assignment.md) feature specification.

## See also

- [C# operators and expressions](index.md)
- [How to concatenate multiple strings](../../how-to/concatenate-multiple-strings.md)
- [Events](../../programming-guide/events/index.md)
- [Arithmetic operators](arithmetic-operators.md)
- [- and -= operators](subtraction-operator.md)
