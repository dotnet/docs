---
title: "unchecked keyword - C# Reference"
ms.date: 07/20/2015
f1_keywords:
  - "unchecked_CSharpKeyword"
  - "unchecked"
helpviewer_keywords:
  - "unchecked keyword [C#]"
ms.assetid: 0c021f7c-923f-4b3d-a58f-55336f5ac27e
---
# unchecked (C# Reference)

The `unchecked` keyword is used to suppress overflow-checking for integral-type arithmetic operations and conversions.

In an unchecked context, if an expression produces a value that is outside the range of the destination type, the overflow is not flagged. For example, because the calculation in the following example is performed in an `unchecked` block or expression, the fact that the result is too large for an integer is ignored, and `int1` is assigned the value -2,147,483,639.

[!code-csharp[csrefKeywordsChecked#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsChecked/CS/csrefKeywordsChecked.cs#5)]

If the `unchecked` environment is removed, a compilation error occurs. The overflow can be detected at compile time because all the terms of the expression are constants.

Expressions that contain non-constant terms are unchecked by default at compile time and run time. See [checked](checked.md) for information about enabling a checked environment.

Because checking for overflow takes time, the use of unchecked code in situations where there is no danger of overflow might improve performance. However, if overflow is a possibility, a checked environment should be used.

## Example

This sample shows how to use the `unchecked` keyword.

[!code-csharp[csrefKeywordsChecked#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsChecked/CS/csrefKeywordsChecked.cs#2)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Checked and Unchecked](checked-and-unchecked.md)
- [checked](checked.md)
