---
title: "true and false operators - C# Reference"
ms.custom: seodec18

ms.date: 12/10/2018
helpviewer_keywords: 
  - "false operator [C#]"
  - "true operator [C#]"
ms.assetid: 81a888fd-011e-4589-b242-6c261fea505e
---
# true and false operators (C# Reference)

The `true` operator returns the [bool](bool.md) value `true` to indicate that an operand is definitely true. The `false` operator returns the `bool` value `true` to indicate that an operand is definitely false. The `true` and `false` operators are not guaranteed to complement each other. That is, both the `true` and `false` operator might return the `bool` value `false` for the same operand. If a type defines one of the two operators, it must also define another operator.

If a type with the defined `true` and `false` operators [overloads](operator.md) the [logical OR operator](../operators/or-operator.md) `|` or the [logical AND operator](../operators/and-operator.md) `&` in a certain way, the [conditional logical OR operator](../operators/conditional-or-operator.md) `||` or [conditional logical AND operator](../operators/conditional-and-operator.md) `&&`, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

A type with the defined `true` operator can be the type of a result of a controlling conditional expression in the [if](if-else.md), [do](do.md), [while](while.md), and [for](for.md) statements and in the [conditional operator `?:`](../operators/conditional-operator.md). For more information, see the [Boolean expressions](~/_csharplang/spec/expressions.md#boolean-expressions) section of the [C# language specification](../language-specification/index.md).

> [!TIP]
> Use the `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued logical type. For more information, see [The bool? type](../../programming-guide/nullable-types/using-nullable-types.md#the-bool-type) section of the [Using nullable types](../../programming-guide/nullable-types/using-nullable-types.md) article.

The following example presents the type that defines both `true` and `false` operators. Moreover, it overloads the logical AND operator `&` in such a way that the operator `&&` also can be evaluated for the operands of that type.

[!code-csharp-interactive[true and false operators example](~/samples/snippets/csharp/keywords/TrueFalseOperatorsExample.cs)]

Notice the short-circuiting behavior of the `&&` operator. When the `GetFuelLaunchStatus` method returns `LaunchStatus.Red`, the second operand of the `&&` operator is not evaluated. That is because `LaunchStatus.Red` is definitely false. Then the result of the logical AND doesn't depend on the value of the second operand. The output of the example is as follows:

```console
Getting fuel launch status...
Wait!
```

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [C# Operators](../operators/index.md)
- [`true` literal](true-literal.md)
- [`false` literal](false-literal.md)