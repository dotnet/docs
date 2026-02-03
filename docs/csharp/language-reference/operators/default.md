---
title: "default value expressions - produce the default value for any type"
description: "Use the default value expressions to obtain the default, uninitialized value of a type. The default value expression can be used with generic type parameters in addition to other types."
ms.date: 01/20/2026
f1_keywords:
  - "default_CSharpKeyword"
helpviewer_keywords:
  - "default keyword [C#]"
---
# Default value expressions

A default value expression produces the [default value](../builtin-types/default-values.md) of a type. Two kinds of default value expressions exist: the [`default` operator](#default-operator) call and a [`default` literal](#default-literal).

You also use the `default` keyword as the default case label within a [`switch` statement](../statements/selection-statements.md#the-switch-statement).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

## `default` operator

The argument to the `default` operator must be the name of a type or a type parameter, as the following example shows:

:::code language="csharp" source="snippets/shared/DefaultOperator.cs" id="WithOperand":::

## `default` literal

You can use the `default` literal to produce the default value of a type when the compiler can infer the expression type. The `default` literal expression produces the same value as the `default(T)` expression where `T` is the inferred type. You can use the `default` literal in any of the following cases:

- In the assignment or initialization of a variable.
- In the declaration of the default value for an [optional method parameter](../../methods.md#optional-parameters-and-arguments).
- In a method call to provide an argument value.
- In a [`return` statement](../statements/jump-statements.md#the-return-statement) or as an expression in an [expression-bodied member](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

The following example shows the usage of the `default` literal:

:::code language="csharp" source="snippets/shared/DefaultOperator.cs" id="DefaultLiteral":::

> [!TIP]
> Use .NET style rule [IDE0034](../../../fundamentals/code-analysis/style-rules/ide0034.md) to specify a preference on the use of the `default` literal in your codebase.

## C# language specification

For more information, see the [Default value expressions](~/_csharpstandard/standard/expressions.md#12821-default-value-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
- [Default values of C# types](../builtin-types/default-values.md)
- [Generics in .NET](../../../standard/generics/index.md)
