---
title: "false operator (C# Reference)"
ms.date: 12/03/2018
helpviewer_keywords: 
  - "false operator keyword [C#]"
ms.assetid: 81a888fd-011e-4589-b242-6c261fea505e
---
# false operator (C# Reference)

Returns the [bool](bool.md) value `true` to indicate that an operand is definitely false. If a type defines the `false` operator, it must also define the [true operator](true-operator.md). The `true` and `false` operators are not guaranteed to complement each other.

> [!TIP]
> Use the `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued logical type. For more information, see [The bool? type](../../programming-guide/nullable-types/using-nullable-types.md#the-bool-type) section of the [Using nullable types](../../programming-guide/nullable-types/using-nullable-types.md) article.

If a type with the defined `false` operator [overloads](operator.md) the [logical AND operator](../operators/and-operator.md) `&` in a certain way, the [conditional logical AND operator](../operators/conditional-and-operator.md) `&&`, which is short-circuiting, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

The following example presents the type that defines both `true` and `false` operators. Moreover, it overloads the logical AND operator `&` in such a way that the operator `&&` also can be evaluated for the operands of that type.

[!code-csharp-interactive[true and false operators example](~/samples/snippets/csharp/keywords/TrueFalseOperatorsExample.cs)]

Notice the short-circuiting behavior of the `&&` operator. When the `GetFuelLaunchStatus` method returns `LaunchStatus.Red`, the second operand of the `&&` operator is not evaluated. That is because `LaunchStatus.Red` is definitely false. Then the result of the logical AND doesn't depend on the value of the second operand. The output of the example is as follows:

```console
Getting fuel launch status...
Wait!
```

Also notice that the conditional expression in the [conditional operator `?:`](../operators/conditional-operator.md) is of the `LaunchStatus` type. That is possible, because `LaunchStatus` defines the `true` operator. For more information, see the [Boolean expressions](~/_csharplang/spec/expressions.md#boolean-expressions) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [C# Operators](../operators/index.md)
- [`false` literal](false-literal.md)