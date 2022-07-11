---
description: "checked keyword - C# Reference"
title: "checked keyword - C# Reference"
ms.date: 06/10/2022
f1_keywords: 
  - "checked_CSharpKeyword"
  - "checked"
helpviewer_keywords: 
  - "checked keyword [C#]"
ms.assetid: 718a1194-988d-48a3-b089-d6ee8bd1608d
---
# checked (C# Reference)

The `checked` keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions. Beginning with C# 11, the `checked` keyword declares an operator specific to a checked context. For more information on checked and unchecked operations, see the article on [Arithmetic operators](../operators/arithmetic-operators.md).

By default, an expression that contains only constant values causes a compiler error if the expression produces a value that is outside the range of the destination type. If the expression contains one or more non-constant values, the compiler doesn't detect the overflow. Evaluating the expression assigned to `i2` in the following example doesn't cause a compiler error.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsChecked/CS/csrefKeywordsChecked.cs" id="Snippet3":::

By default, these non-constant expressions aren't checked for overflow at run time either, and they don't raise overflow exceptions. The previous example displays -2,147,483,639 as the sum of two positive integers.

Overflow checking can be enabled by compiler options, environment configuration, or use of the `checked` keyword. The following examples demonstrate how to use a `checked` expression or a `checked` block to detect the overflow that is produced by the previous sum at run time. Both examples raise an overflow exception.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsChecked/CS/csrefKeywordsChecked.cs" id="Snippet4":::

The [unchecked](./unchecked.md) keyword can be used to prevent overflow checking.

Beginning with C# 11, you can define `checked` and unchecked variants for operators that are affected by overflow checking. For more information on checked and unchecked operators, see the article on [Arithmetic operators](../operators/arithmetic-operators.md).

## Example

This sample shows how to use `checked` to enable overflow checking at run time.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsChecked/CS/csrefKeywordsChecked.cs" id="Snippet1":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [Checked and Unchecked](./checked-and-unchecked.md)
- [unchecked](./unchecked.md)
