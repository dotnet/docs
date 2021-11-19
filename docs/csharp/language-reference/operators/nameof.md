---
title: "nameof expression - C# reference"
description: "Learn about the C# nameof expression that produces the name of its operand."
ms.date: 04/23/2020
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
helpviewer_keywords:
  - "nameof expression [C#]"
ms.assetid: 33601bf3-cc2c-4496-846d-f9679bccf2a7
---
# nameof expression (C# reference)

A `nameof` expression produces the name of a variable, type, or member as the string constant:

[!code-csharp-interactive[nameof expression](snippets/shared/NameOfOperator.cs#Examples)]

As the preceding example shows, in the case of a type and a namespace, the produced name is not [fully qualified](~/_csharplang/spec/basic-concepts.md#fully-qualified-names).

In the case of [verbatim identifiers](../tokens/verbatim.md), the `@` character is not the part of a name, as the following example shows:

[!code-csharp-interactive[nameof verbatim](snippets/shared/NameOfOperator.cs#Verbatim)]

A `nameof` expression is evaluated at compile time and has no effect at run time.

You can use a `nameof` expression to make the argument-checking code more maintainable:

[!code-csharp[nameof and argument check](snippets/shared/NameOfOperator.cs#ExceptionMessage)]

A `nameof` expression is available in C# 6 and later.

## C# language specification

For more information, see the [Nameof expressions](~/_csharplang/spec/expressions.md#nameof-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [CallerArgumentExpression](../attributes/caller-information.md#argument-expressions)
