---
title: "true and false operators - treat objects as Boolean values"
description: "Learn about the C# `true` and `false` operators. Overload these operators to treat your type as a Boolean value"
ms.date: 11/28/2022
helpviewer_keywords: 
  - "false operator [C#]"
  - "true operator [C#]"
---
# true and false operators - treat your objects as a Boolean value

The `true` operator returns the [bool](../builtin-types/bool.md) value `true` to indicate that its operand is definitely true, while the `false` operator returns the `bool` value `true` to indicate that its operand is definitely false.
<br/>Note that a type implementing both `true` and `false` operators has to follow these semantics:

* "Is this object true?" resolves to operator `true`. Operator `true` returns `true` if the object is `true`. The answer is "Yes, this object is true".
* "Is this object false?" resolves to operator `false`. Operator `false` returns `true` if the object is `false`. The answer is "Yes, this object is false"

The `true` and `false` operators aren't guaranteed to complement each other. That is, both the `true` and `false` operator might return the `bool` value `false` for the same operand. If a type defines one of these two operators, it must also define the other operator.

> [!TIP]
> Use the `bool?` type, if you need to support the three-valued logic (for example, when you work with databases that support a three-valued Boolean type). C# provides the `&` and `|` operators that support the three-valued logic with the `bool?` operands. For more information, see the [Nullable Boolean logical operators](boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](boolean-logical-operators.md) article.

## Boolean expressions

A type with the defined `true` operator can be the type of a result of a controlling conditional expression in the [if](../statements/selection-statements.md#the-if-statement), [do](../statements/iteration-statements.md#the-do-statement), [while](../statements/iteration-statements.md#the-while-statement), and [for](../statements/iteration-statements.md#the-for-statement) statements and in the [conditional operator `?:`](conditional-operator.md). For more information, see the [Boolean expressions](~/_csharpstandard/standard/expressions.md#1224-boolean-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## User-defined conditional logical operators

If a type with the defined `true` and `false` operators [overloads](operator-overloading.md) the [logical OR operator](boolean-logical-operators.md#logical-or-operator-) `|` or the [logical AND operator](boolean-logical-operators.md#logical-and-operator-) `&` in a certain way, the [conditional logical OR operator](boolean-logical-operators.md#conditional-logical-or-operator-) `||` or [conditional logical AND operator](boolean-logical-operators.md#conditional-logical-and-operator-) `&&`, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12143-user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## Example

The following example presents the type that defines both `true` and `false` operators. The type also overloads the logical AND operator `&` in such a way that the `&&` operator also can be evaluated for the operands of that type.

[!code-csharp[true and false operators example](snippets/shared/TrueFalseOperators.cs)]

Notice the short-circuiting behavior of the `&&` operator. When the `GetFuelLaunchStatus` method returns `LaunchStatus.Red`, the right-hand operand of the `&&` operator isn't evaluated. That is because `LaunchStatus.Red` is definitely false. Then the result of the logical AND doesn't depend on the value of the right-hand operand. The output of the example is as follows:

```console
Getting fuel launch status...
Wait!
```

## See also

- [C# operators and expressions](index.md)
