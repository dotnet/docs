---
title: "The nameof expression - evaluate the text name of a symbol"
description: "The C# `nameof` expression produces the name of its operand. You use it whenever you need to use the name of a symbol as text"
ms.date: 02/19/2025
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
helpviewer_keywords:
  - "nameof expression [C#]"
---
# nameof expression (C# reference)

<!-- Note that all remaining acrolinx issues are because acrolinx things "nameof" is mis-spelled. -->

A `nameof` expression produces the name of a variable, type, or member as the string constant. A `nameof` expression is evaluated at compile time and has no effect at run time. When the operand is a type or a namespace, the produced name isn't [fully qualified](~/_csharpstandard/standard/basic-concepts.md#783-fully-qualified-names). The following example shows the use of a `nameof` expression:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/NameOfOperator.cs" id="Examples":::

The preceding example using `List<>` is supported in C# 14 and later. You can use a `nameof` expression to make the argument-checking code more maintainable:

:::code language="csharp" source="snippets/shared/NameOfOperator.cs" id="ExceptionMessage":::

Beginning with C# 11, you can use a `nameof` expression with a method parameter inside an [attribute](../../advanced-topics/reflection-and-attributes/index.md) on a method or its parameter. The following code shows how to do that for an attribute on a method, a local function, and the parameter of a lambda expression:

:::code language="csharp" source="snippets/shared/NameOfOperator.cs" id="SnippetNameOfParameter":::

A `nameof` expression with a parameter is useful when you use the [nullable analysis attributes](../attributes/nullable-analysis.md) or the [CallerArgumentExpression attribute](../attributes/caller-information.md#argument-expressions).

When the operand is a [verbatim identifier](../tokens/verbatim.md), the `@` character isn't part of the name, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/NameOfOperator.cs" id="Verbatim":::

## C# language specification

For more information, see the [Nameof expressions](~/_csharpstandard/standard/expressions.md#12823-the-nameof-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md), and the [C# 11 - Extended `nameof` scope](~/_csharplang/proposals/csharp-11.0/extended-nameof-scope.md) feature specification.

## See also

- [C# operators and expressions](index.md)
- [Convert `typeof` to `nameof` (style rule IDE0082)](../../../fundamentals/code-analysis/style-rules/ide0082.md)
