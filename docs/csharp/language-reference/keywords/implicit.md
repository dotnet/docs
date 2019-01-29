---
title: "implicit - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "implicit"
  - "implicit_CSharpKeyword"
helpviewer_keywords: 
  - "implicit keyword [C#]"
ms.assetid: 34db590e-eb3a-4f11-88d0-ffb3cd753dab
---
# implicit (C# Reference)

The `implicit` keyword is used to declare an implicit user-defined type conversion operator. Use it to enable implicit conversions between a user-defined type and another type, if the conversion is guaranteed not to cause a loss of data.

## Example

[!code-csharp[csrefKeywordsConversion#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#5)]

By eliminating unnecessary casts, implicit conversions can improve source code readability. However, because implicit conversions do not require programmers to explicitly cast from one type to the other, care must be taken to prevent unexpected results. In general, implicit conversion operators should never throw exceptions and never lose information so that they can be used safely without the programmer's awareness. If a conversion operator cannot meet those criteria, it should be marked `explicit`. For more information, see [Using Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/using-conversion-operators.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [explicit](explicit.md)
- [operator (C# Reference)](operator.md)
- [How to: Implement User-Defined Conversions Between Structs](../../programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)
