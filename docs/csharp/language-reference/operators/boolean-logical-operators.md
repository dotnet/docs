---
title: "Boolean logical operators - C# reference"
description: "Learn about C# operators that perform logical negation, conjunction (AND), and inclusive and exclusive disjunction (OR) operations with Boolean operands."
ms.date: 09/27/2019
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
  - "conditional AND operator [C#]"
  - "short-circuiting AND operator [C#]"
  - "&& operator [C#]"
  - "conditional OR operator [C#]"
  - "short-circuiting OR operator [C#]"
  - "|| operator [C#]"
---
# Boolean logical operators (C# reference)

The following operators perform logical operations with [bool](../builtin-types/bool.md) operands:

- Unary [`!` (logical negation)](#logical-negation-operator-) operator.
- Binary [`&` (logical AND)](#logical-and-operator-), [`|` (logical OR)](#logical-or-operator-), and [`^` (logical exclusive OR)](#logical-exclusive-or-operator-) operators. Those operators always evaluate both operands.
- Binary [`&&` (conditional logical AND)](#conditional-logical-and-operator-) and [`||` (conditional logical OR)](#conditional-logical-or-operator-) operators. Those operators evaluate the right-hand operand only if it's necessary.

For operands of the [integral numeric types](../builtin-types/integral-numeric-types.md), the `&`, `|`, and `^` operators perform bitwise logical operations. For more information, see [Bitwise and shift operators](bitwise-and-shift-operators.md).

## Logical negation operator !

The unary prefix `!` operator computes logical negation of its operand. That is, it produces `true`, if the operand evaluates to `false`, and `false`, if the operand evaluates to `true`:

[!code-csharp-interactive[logical negation](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#Negation)]

Beginning with C# 8.0, the unary postfix `!` operator is the [null-forgiving operator](null-forgiving.md).

## <a name="logical-and-operator-"></a> Logical AND operator &amp;

The `&` operator computes the logical AND of its operands. The result of `x & y` is `true` if both `x` and `y` evaluate to `true`. Otherwise, the result is `false`.

The `&` operator evaluates both operands even if the left-hand operand evaluates to `false`, so that the operation result is `false` regardless of the value of the right-hand operand.

In the following example, the right-hand operand of the `&` operator is a method call, which is performed regardless of the value of the left-hand operand:

[!code-csharp-interactive[logical AND](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#And)]

The [conditional logical AND operator](#conditional-logical-and-operator-) `&&` also computes the logical AND of its operands, but doesn't evaluate the right-hand operand if the left-hand operand evaluates to `false`.

For operands of the [integral numeric types](../builtin-types/integral-numeric-types.md), the `&` operator computes the [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) of its operands. The unary `&` operator is the [address-of operator](pointer-related-operators.md#address-of-operator-).

## Logical exclusive OR operator ^

The `^` operator computes the logical exclusive OR, also known as the logical XOR, of its operands. The result of `x ^ y` is `true` if `x` evaluates to `true` and `y` evaluates to `false`, or `x` evaluates to `false` and `y` evaluates to `true`. Otherwise, the result is `false`. That is, for the `bool` operands, the `^` operator computes the same result as the [inequality operator](equality-operators.md#inequality-operator-) `!=`.

[!code-csharp-interactive[logical exclusive OR](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#Xor)]

For operands of the [integral numeric types](../builtin-types/integral-numeric-types.md), the `^` operator computes the [bitwise logical exclusive OR](bitwise-and-shift-operators.md#logical-exclusive-or-operator-) of its operands.

## Logical OR operator |

The `|` operator computes the logical OR of its operands. The result of `x | y` is `true` if either `x` or `y` evaluates to `true`. Otherwise, the result is `false`.

The `|` operator evaluates both operands even if the left-hand operand evaluates to `true`, so that the operation result is `true` regardless of the value of the right-hand operand.

In the following example, the right-hand operand of the `|` operator is a method call, which is performed regardless of the value of the left-hand operand:

[!code-csharp-interactive[logical OR](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#Or)]

The [conditional logical OR operator](#conditional-logical-or-operator-) `||` also computes the logical OR of its operands, but doesn't evaluate the right-hand operand if the left-hand operand evaluates to `true`.

For operands of the [integral numeric types](../builtin-types/integral-numeric-types.md), the `|` operator computes the [bitwise logical OR](bitwise-and-shift-operators.md#logical-or-operator-) of its operands.

## <a name="conditional-logical-and-operator-"></a> Conditional logical AND operator &amp;&amp;

The conditional logical AND operator `&&`, also known as the "short-circuiting" logical AND operator, computes the logical AND of its operands. The result of `x && y` is `true` if both `x` and `y` evaluate to `true`. Otherwise, the result is `false`. If `x` evaluates to `false`, `y` is not evaluated.

In the following example, the right-hand operand of the `&&` operator is a method call, which isn't performed if the left-hand operand evaluates to `false`:

[!code-csharp-interactive[conditional logical AND](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#ConditionalAnd)]

The [logical AND operator](#logical-and-operator-) `&` also computes the logical AND of its operands, but always evaluates both operands.

## Conditional logical OR operator ||

The conditional logical OR operator `||`, also known as the "short-circuiting" logical OR operator, computes the logical OR of its operands. The result of `x || y` is `true` if either `x` or `y` evaluates to `true`. Otherwise, the result is `false`. If `x` evaluates to `true`, `y` is not evaluated.

In the following example, the right-hand operand of the `||` operator is a method call, which isn't performed if the left-hand operand evaluates to `true`:

[!code-csharp-interactive[conditional logical OR](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#ConditionalOr)]

The [logical OR operator](#logical-or-operator-) `|` also computes the logical OR of its operands, but always evaluates both operands.

## Nullable Boolean logical operators

For `bool?` operands, the `&` and `|` operators support the three-valued logic. The semantics of these operators is defined by the following table:  
  
|x|y|x&y|x&#124;y|  
|----|----|----|----|  
|true|true|true|true|  
|true|false|false|true|  
|true|null|null|true|  
|false|true|false|true|  
|false|false|false|false|  
|false|null|false|null|  
|null|true|null|true|  
|null|false|false|null|  
|null|null|null|null|  

The behavior of those operators differs from the typical operator behavior with nullable value types. Typically, an operator which is defined for operands of a value type can be also used with operands of the corresponding nullable value type. Such an operator produces `null` if any of its operands evaluates to `null`. However, the `&` and `|` operators can produce non-null even if one of the operands evaluates to `null`. For more information about the operator behavior with nullable value types, see the [Lifted operators](../builtin-types/nullable-value-types.md#lifted-operators) section of the [Nullable value types](../builtin-types/nullable-value-types.md) article.

You can also use the `!` and `^` operators with `bool?` operands, as the following example shows:

[!code-csharp-interactive[lifted negation and xor](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#WithNullableBoolean)]

The conditional logical operators `&&` and `||` don't support `bool?` operands.

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

[!code-csharp-interactive[compound assignment](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#CompoundAssignment)]

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

[!code-csharp-interactive[operator precedence](~/samples/csharp/language-reference/operators/BooleanLogicalOperators.cs#Precedence)]

For the complete list of C# operators ordered by precedence level, see the [Operator precedence](index.md#operator-precedence) section of the [C# operators](index.md) article.

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `!`, `&`, `|`, and `^` operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type cannot explicitly overload a compound assignment operator.

A user-defined type cannot overload the conditional logical operators `&&` and `||`. However, if a user-defined type overloads the [true and false operators](true-false-operators.md) and the `&` or `|` operator in a certain way, the `&&` or `||` operation, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Logical negation operator](~/_csharplang/spec/expressions.md#logical-negation-operator)
- [Logical operators](~/_csharplang/spec/expressions.md#logical-operators)
- [Conditional logical operators](~/_csharplang/spec/expressions.md#conditional-logical-operators)
- [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Bitwise and shift operators](bitwise-and-shift-operators.md)
