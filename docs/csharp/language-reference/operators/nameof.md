---
title: "nameof expression - C# reference"
description: "Learn about the C# nameof expression that produces the name of its operand."
ms.date: 05/20/2022
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
helpviewer_keywords:
  - "nameof expression [C#]"
---
# nameof expression (C# reference)

A `nameof` expression produces the name of a variable, type, or member as the string constant:

[!code-csharp-interactive[nameof expression](snippets/shared/NameOfOperator.cs#Examples)]

As the preceding example shows, in the case of a type and a namespace, the produced name is not [fully qualified](~/_csharpstandard/standard/basic-concepts.md#783-fully-qualified-names).

In the case of [verbatim identifiers](../tokens/verbatim.md), the `@` character is not the part of a name, as the following example shows:

[!code-csharp-interactive[nameof verbatim](snippets/shared/NameOfOperator.cs#Verbatim)]

A `nameof` expression is evaluated at compile time and has no effect at run time.

You can use a `nameof` expression to make the argument-checking code more maintainable:

[!code-csharp[nameof and argument check](snippets/shared/NameOfOperator.cs#ExceptionMessage)]

The argument to the `nameof` operator must be in scope. Beginning with C# 11, parameters and type parameters are in scope inside an attribute for the purpose of the `nameof` operator. The following examples show `nameof` used on parameters for a method, a local function, and a lambda expression:

:::code language="csharp" source="snippets/shared/NameOfOperator.cs" id="SnippetNameOfParameter":::

Using `nameof` on parameters is most useful when using the [Nullable analysis attributes](../attributes/nullable-analysis.md).

## C# language specification

For more information, see the [Nameof expressions](~/_csharpstandard/standard/expressions.md#11720-nameof-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Convert `typeof` to `nameof` (style rule IDE0082)](../../../fundamentals/code-analysis/style-rules/ide0082.md)
- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [CallerArgumentExpression](../attributes/caller-information.md#argument-expressions)
