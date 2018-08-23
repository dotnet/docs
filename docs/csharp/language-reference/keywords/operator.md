---
title: "operator keyword (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "operator_CSharpKeyword"
  - "operator"
helpviewer_keywords: 
  - "operator keyword [C#]"
ms.assetid: 59218cce-e90e-42f6-a6bb-30300981b86a
---
# operator (C# Reference)

Use the `operator` keyword to overload a built-in operator or to provide a user-defined conversion in a class or struct declaration.

## Example

The following is a very simplified class for fractional numbers. It overloads the `+` and `*` operators to perform fractional addition and multiplication, and also provides a conversion operator that converts a `Fraction` type to a `double` type.

[!code-csharp[csrefKeywordsConversion#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#6)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [implicit](implicit.md)
- [explicit](explicit.md)
- [How to: Implement User-Defined Conversions Between Structs](../../programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)
