---
title: "Boolean logical operators - C# Reference"
description: "Learn about C# operators that perform logical negation, conjunction (AND), and inclusive and exclusive disjunction (OR) operations with Boolean operands."
ms.date: 04/08/2019
author: pkulikov
f1_keywords: 
  - "!_CSharpKeyword"
  - "&_CSharpKeyword"
  - "^_CSharpKeyword"
  - "|_CSharpKeyword"
  - "&&_CSharpKeyword"
  - "||_CSharpKeyword"
helpviewer_keywords: 
  - "logical operators [C#]"
  - "short-circuiting operators [C#]"
  - "logical negation operator [C#]"
  - "NOT operator [C#]"
  - "! operator [C#]"
  - "AND operator [C#]"
  - "ampersand operator [C#]"
  - "conjunction operator [C#]"
  - "& operator [C#]"
  - "exclusive OR operator [C#]"
  - "XOR operator [C#]"
  - "^ operator [C#]"
  - "OR operator [C#]"
  - "disjunction operator [C#]"
  - "| operator [C#]"
  - "conditional logical AND operator [C#]"
  - "short-circuiting logical AND operator [C#]"
  - "&& operator [C#]"
  - "conditional logical OR operator [C#]"
  - "short-circuiting logical OR operator [C#]"
  - "|| operator [C#]"
---
# Boolean logical operators (C# Reference)

The following operators perform logical operations with [bool](../keywords/bool.md) operands:

- Unary [`!` (logical negation)](#logical-negation-operator-) operator.
- Binary [`&` (logical AND)](#logical-and-operator-), [`|` (logical OR)](#logical-or-operator-), and [`^` (logical exclusive OR)](#logical-exclusive-or-operator-) operators. Those operators always evaluate both operands.
- Binary [`&&` (conditional logical AND)](#conditional-logical-and-operator-) and [`||` (conditional logical OR)](#conditional-logical-or-operator-) operators. Those operators evaluate the second operand only if it's necessary.

The `&` and `|` operators are also defined for `bool?` operands. For more information, see [The bool? type](../../programming-guide/nullable-types/using-nullable-types.md#the-bool-type) section of the [Using nullable types](../../programming-guide/nullable-types/using-nullable-types.md) article.

For the operands of [integral](../keywords/integral-types-table.md) types, the `&`, `|`, and `^` operators perform bitwise logical operations.

## Logical negation operator !

The unary `!` operator computes logical negation of its operand. That is, it produces `true`, if the operand evaluates to `false`, and `false`, if the operand evaluates to `true`:

[!code-csharp-interactive[logical negation](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#Negation)]

## Logical AND operator &amp;

The `&` operator computes the logical AND of its operands. The result of `x & y` is `true` if both `x` and `y` evaluate to `true`. Otherwise, the result is `false`.

The `&` operator evaluates both operands even if the first operand evaluates to `false`, so that the result must be `false` regardless of the value of the second operand. The following example demonstrates that behavior:

[!code-csharp-interactive[logical AND](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#And)]

The [conditional logical AND operator](#conditional-logical-and-operator-) `&&` also computes the logical AND of its operands, but doesn't evaluate the second operand if the first operand evaluates to `false`.

For the operands of integral types, the `&` operator computes [bitwise logical AND](and-operator.md#integer-logical-bitwise-and-operator) of its operands. The unary `&` operator is the [address-of operator](and-operator.md#unary-address-of-operator).

## Logical exclusive OR operator ^

The `^` operator computes the logical exclusive OR, also known as the logical XOR, of its operands. The result of `x ^ y` is `true` if `x` evaluates to `true` and `y` evaluates to `false`, or `x` evaluates to `false` and `y` evaluates to `true`. Otherwise, the result is `false`. That is, for Boolean operands, the `^` operator computes the same result as the [inequality operator](equality-operators.md#inequality-operator-) `!=`.

[!code-csharp-interactive[logical exclusive-OR](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#Xor)]

For the operands of integral types, the `^` operator computes [bitwise logical exclusive OR](xor-operator.md) of its operands.

## Logical OR operator |

The `|` operator computes the logical OR of its operands. The result of `x | y` is `true` if either `x` or `y` evaluates to `true`. Otherwise, the result is `false`.

The `|` operator evaluates both operands even if the first operand evaluates to `true`, so that the result must be `true` regardless of the value of the second operand. The following example demonstrates that behavior:

[!code-csharp-interactive[logical OR](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#Or)]

The [conditional logical OR operator](#conditional-logical-or-operator-) `||` also computes the logical OR of its operands, but doesn't evaluate the second operand if the first operand evaluates to `true`.

For the operands of integral types, the `|` operator computes [bitwise logical OR](or-operator.md) of its operands.

## Conditional logical AND operator &amp;&amp;

The conditional logical AND operator `&&`, also known as the "short-circuiting" logical AND operator, computes the logical AND of its operands. The result of `x && y` is `true` if both `x` and `y` evaluate to `true`. Otherwise, the result is `false`. If the first operand evaluates to `false`, the second operand is not evaluated. The following example demonstrates that behavior:

[!code-csharp-interactive[conditional logical AND](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#ConditionalAnd)]

The [logical AND operator](#logical-and-operator-) `&` also computes the logical AND of its operands, but always evaluates both operands.

## Conditional logical OR operator ||

The conditional logical OR operator `||`, also known as the "short-circuiting" logical OR operator, computes the logical OR of its operands. The result of `x || y` is `true` if either `x` or `y` evaluates to `true`. Otherwise, the result is `false`. If the first operand evaluates to `true`, the second operand is not evaluated. The following example demonstrates that behavior:

[!code-csharp-interactive[conditional logical OR](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#ConditionalOr)]

The [logical OR operator](#logical-or-operator-) `|` also computes the logical OR of its operands, but always evaluates both operands.

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

The `&`, `|`, and `^` operators support compound assignment, as the following example shows:

[!code-csharp-interactive[compound assignment](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#CompoundAssignment)]

The conditional logical operators `&&` and `||` don't support compound assignment.

## Operator precedence

The following list orders logical operators starting from the highest precedence to the lowest:

- Logical negation operator `!`
- Logical AND operator `&`
- Logical exclusive OR operator `^`
- Logical OR operator `|`
- Conditional logical AND operator `&&`
- Conditional logical OR operator `||`

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence:

[!code-csharp-interactive[operator precedence](~/samples/snippets/csharp/language-reference/operators/LogicalOperators.cs#Precedence)]

For the complete list of C# operators ordered by precedence level, see [C# operators](index.md).

## Operator overloadability

A user-defined type can [overload](../keywords/operator.md) the `!`, `&`, `|`, and `^` operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type cannot explicitly overload a compound assignment operator.

A user-defined type cannot overload the conditional logical operators `&&` and `||`. However, if a user-defined type overloads the [true and false operators](../keywords/true-false-operators.md) and the `&` or `|` operator in a certain way, the `&&` or `||` operation, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Logical negation operator](~/_csharplang/spec/expressions.md#logical-negation-operator)
- [Logical operators](~/_csharplang/spec/expressions.md#logical-operators)
- [Conditional logical operators](~/_csharplang/spec/expressions.md#conditional-logical-operators)

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)