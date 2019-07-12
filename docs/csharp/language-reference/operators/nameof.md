---
title: "nameof operator - C# reference"
ms.custom: seodec18
ms.date: 07/12/2019
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
ms.assetid: 33601bf3-cc2c-4496-846d-f9679bccf2a7
---
# nameof operator (C# reference)

The `nameof` operator obtains the simple name of a variable, type, or member as the string constant:

[!code-csharp-interactive[nameof operator](~/samples/csharp/language-reference/operators/NameOfOperator.cs#Examples)]

The `nameof` operator is evaluated at compile time, and has no effect at run time.

You can use the `nameof` operator to make the argument-checking code more maintainable:

[!code-csharp[nameof and argument check](~/samples/csharp/language-reference/operators/NameOfOperator.cs#ExceptionMessage)]

## C# language specification

For more information, see the [Nameof expressions](~/_csharplang/spec/expressions.md#nameof-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
