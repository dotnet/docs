---
title: "true and false operators - C# reference"
ms.custom: seodec18
ms.date: 12/10/2018
helpviewer_keywords: 
  - "false operator [C#]"
  - "true operator [C#]"
ms.assetid: 81a888fd-011e-4589-b242-6c261fea505e
---
# true and false operators (C# reference)

The `true` operator returns the [bool](../keywords/bool.md) value `true` to indicate that an operand is definitely true. The `false` operator returns the `bool` value `true` to indicate that an operand is definitely false. The `true` and `false` operators are not guaranteed to complement each other. That is, both the `true` and `false` operator might return the `bool` value `false` for the same operand. If a type defines one of the two operators, it must also define another operator.

> [!TIP]
> Use the `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued Boolean type. C# provides the `&` and `|` operators that support the three-valued logic with the `bool?` operands. For more information, see the [Nullable Boolean logical operators](boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](boolean-logical-operators.md) article.

## Boolean expressions

A type with the defined `true` operator can be the type of a result of a controlling conditional expression in the [if](../keywords/if-else.md), [do](../keywords/do.md), [while](../keywords/while.md), and [for](../keywords/for.md) statements and in the [conditional operator `?:`](conditional-operator.md). For more information, see the [Boolean expressions](~/_csharplang/spec/expressions.md#boolean-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## User-defined conditional logical operators

If a type with the defined `true` and `false` operators [overloads](operator-overloading.md) the [logical OR operator](boolean-logical-operators.md#logical-or-operator-) `|` or the [logical AND operator](boolean-logical-operators.md#logical-and-operator-) `&` in a certain way, the [conditional logical OR operator](boolean-logical-operators.md#conditional-logical-or-operator-) `||` or [conditional logical AND operator](boolean-logical-operators.md#conditional-logical-and-operator-) `&&`, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## Example

The following example presents the type that defines both `true` and `false` operators. The type also overloads the logical AND operator `&` in such a way that the operator `&&` also can be evaluated for the operands of that type.

[!code-csharp[true and false operators example](~/samples/csharp/language-reference/operators/TrueFalseOperators.cs)]

Notice the short-circuiting behavior of the `&&` operator. When the `GetFuelLaunchStatus` method returns `LaunchStatus.Red`, the right-hand operand of the `&&` operator is not evaluated. That is because `LaunchStatus.Red` is definitely false. Then the result of the logical AND doesn't depend on the value of the right-hand operand. The output of the example is as follows:

```console
Getting fuel launch status...
Wait!
```

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [true literal](../keywords/true-literal.md)
- [false literal](../keywords/false-literal.md)
