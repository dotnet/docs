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

Beginning with C# 11, you can use a `nameof` expression with a method parameter inside an [attribute](../../programming-guide/concepts/attributes/index.md) on a method or its parameter. The following code shows how to do that for an attribute on a method, a local function, and the parameter of a lambda expression:

:::code language="csharp" source="snippets/shared/NameOfOperator.cs" id="SnippetNameOfParameter":::

A `nameof` expression with a parameter is useful when you use the [nullable analysis attributes](../attributes/nullable-analysis.md) or the [CallerArgumentExpression attribute](../attributes/caller-information.md#argument-expressions).

## C# language specification

For more information, see the [Nameof expressions](~/_csharpstandard/standard/expressions.md#11720-nameof-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md), and the [C# 11 - Extended `nameof` scope](~/_csharplang/proposals/csharp-11.0/extended-nameof-scope.md) feature specification.

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Convert `typeof` to `nameof` (style rule IDE0082)](../../../fundamentals/code-analysis/style-rules/ide0082.md)
