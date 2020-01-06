---
title: "default operator - C# reference"
description: "Use the default operator to produce the default value of a type"
ms.date: 08/01/2019
helpviewer_keywords: 
  - "default keyword [C#]"
---
# default operator (C# reference)

The `default` operator produces the [default value](../keywords/default-values-table.md) of a type. The argument to the `default` operator must be the name of a type or a type parameter.

The following example shows the usage of the `default` operator:

[!code-csharp-interactive[default of T](~/samples/csharp/language-reference/operators/DefaultOperator.cs#WithOperand)]

You also use the `default` keyword as the default case label within a [`switch` statement](../keywords/switch.md).

## default literal

Beginning with C# 7.1, you can use the `default` literal to produce the default value of a type when the compiler can infer the expression type. The `default` literal expression produces the same value as the `default(T)` expression where `T` is the inferred type. You can use the `default` literal in any of the following cases:

- In the assignment or initialization of a variable.
- In the declaration of the default value for an [optional method parameter](../../methods.md#optional-parameters-and-arguments).
- In a method call to provide an argument value.
- In a [`return` statement](../keywords/return.md) or as an expression in an [expression-bodied member](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

The following example shows the usage of the `default` literal:

[!code-csharp-interactive[default literal](~/samples/csharp/language-reference/operators/DefaultOperator.cs#DefaultLiteral)]

## C# language specification

For more information, see the [Default value expressions](~/_csharplang/spec/expressions.md#default-value-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about the `default` literal, see the [feature proposal note](~/_csharplang/proposals/csharp-7.1/target-typed-default.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Default values table](../keywords/default-values-table.md)
- [Generics in .NET](../../../standard/generics/index.md)
