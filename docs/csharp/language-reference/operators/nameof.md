---
title: "The nameof expression - evaluate the text name of a symbol"
description: "The C# `nameof` expression produces the name of its operand. You use it whenever you need to use the nam of a symbol as text"
ms.date: 11/28/2022
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
helpviewer_keywords:
  - "nameof expression [C#]"
---
# nameof expression (C# reference)

<!-- Note that all remaining acrolinx issues are because acrolinx things "nameof" is mis-spelled. -->

A `nameof` expression produces the name of a variable, type, or member as the string constant. A `nameof` expression is evaluated at compile time and has no effect at run time. When the operand is a type or a namespace, the produced name isn't [fully qualified](~/_csharpstandard/standard/basic-concepts.md#783-fully-qualified-names). The following example shows the use of a `nameof` expression:

[!code-csharp-interactive[nameof expression](snippets/shared/NameOfOperator.cs#Examples)]

When the operand is a [verbatim identifier](../tokens/verbatim.md), the `@` character isn't the part of a name, as the following example shows:

[!code-csharp-interactive[nameof verbatim](snippets/shared/NameOfOperator.cs#Verbatim)]

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
