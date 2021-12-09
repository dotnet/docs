---
title: "default value expressions - C# reference"
description: "Use the default value expressions to obtain the default value of a type."
ms.date: 03/13/2020
f1_keywords:
  - "default_CSharpKeyword"
helpviewer_keywords: 
  - "default keyword [C#]"
---
# default value expressions (C# reference)

A default value expression produces the [default value](../builtin-types/default-values.md) of a type. There are two kinds of default value expressions: the [default operator](#default-operator) call and a [default literal](#default-literal).

You also use the `default` keyword as the default case label within a [`switch` statement](../statements/selection-statements.md#the-switch-statement).

## default operator

The argument to the `default` operator must be the name of a type or a type parameter, as the following example shows:

[!code-csharp-interactive[default of T](snippets/shared/DefaultOperator.cs#WithOperand)]

## default literal

Beginning with C# 7.1, you can use the `default` literal to produce the default value of a type when the compiler can infer the expression type. The `default` literal expression produces the same value as the `default(T)` expression where `T` is the inferred type. You can use the `default` literal in any of the following cases:

- In the assignment or initialization of a variable.
- In the declaration of the default value for an [optional method parameter](../../methods.md#optional-parameters-and-arguments).
- In a method call to provide an argument value.
- In a [`return` statement](../statements/jump-statements.md#the-return-statement) or as an expression in an [expression-bodied member](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

The following example shows the usage of the `default` literal:

[!code-csharp-interactive[default literal](snippets/shared/DefaultOperator.cs#DefaultLiteral)]

## C# language specification

For more information, see the [Default value expressions](~/_csharplang/spec/expressions.md#default-value-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about the `default` literal, see the [feature proposal note](~/_csharplang/proposals/csharp-7.1/target-typed-default.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Default values of C# types](../builtin-types/default-values.md)
- [Generics in .NET](../../../standard/generics/index.md)
