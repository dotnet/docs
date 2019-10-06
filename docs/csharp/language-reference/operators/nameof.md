---
title: "nameof operator - C# reference"
ms.custom: seodec18
ms.date: 07/12/2019
f1_keywords:
  - "nameof_CSharpKeyword"
  - "nameof"
helpviewer_keywords:
  - "nameof operator [C#]"
ms.assetid: 33601bf3-cc2c-4496-846d-f9679bccf2a7
---
# nameof operator (C# reference)

The `nameof` operator obtains the name of a variable, type, or member as the string constant:

[!code-csharp-interactive[nameof operator](~/samples/csharp/language-reference/operators/NameOfOperator.cs#Examples)]

As the preceding example shows, in the case of a type and a namespace, the produced name is usually not [fully qualified](~/_csharplang/spec/basic-concepts.md#fully-qualified-names).

The `nameof` operator is evaluated at compile time, and has no effect at run time.

You can use the `nameof` operator to make the argument-checking code more maintainable:

[!code-csharp[nameof and argument check](~/samples/csharp/language-reference/operators/NameOfOperator.cs#ExceptionMessage)]

The `nameof` operator is available in C# 6 and later.

## C# language specification

For more information, see the [Nameof expressions](~/_csharplang/spec/expressions.md#nameof-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
