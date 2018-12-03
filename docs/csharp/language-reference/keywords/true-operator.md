---
title: "true operator (C# Reference)"
ms.date: 12/03/2018
helpviewer_keywords: 
  - "true operator [C#]"
ms.assetid: acaba817-5da5-4364-b3b2-2e5c75ec1839
---
# true operator (C# Reference)

Returns the [bool](bool.md) value `true` to indicate that an operand is definitely true. If a type defines the `true` operator, it must also define the [false operator](false-operator.md). The `true` and `false` operators are not guaranteed to complement each other.

For the example that defines both `true` and `false` operators, see the [false operator](false-operator.md) article.

> [!TIP]
> Use the `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued logical type. For more information, see [The bool? type](../../programming-guide/nullable-types/using-nullable-types.md#the-bool-type) section of the [Using nullable types](../../programming-guide/nullable-types/using-nullable-types.md) article.

If a type with the defined `true` operator [overloads](operator.md) the [logical OR operator](../operators/or-operator.md) `|` in a certain way, the [conditional logical OR operator](../operators/conditional-or-operator.md) `||`, which is short-circuiting, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

A type with the defined `true` operator can be the type of a result of a controlling conditional expression in the [if](if-else.md), [do](do.md), [while](while.md), and [for](for.md) statements and in the [conditional operator `?:`](../operators/conditional-operator.md). For more information, see the [Boolean expressions](~/_csharplang/spec/expressions.md#boolean-expressions) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [C# Operators](../operators/index.md)
- [`true` literal](true-literal.md)