---
title: "char keyword (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "char"
  - "char_CSharpKeyword"
helpviewer_keywords: 
  - "char data type [C#]"
ms.assetid: b51cf4fb-124c-4067-af48-afbac122b228
---
# char (C# Reference)

The `char` keyword is used to declare an instance of the <xref:System.Char?displayProperty=nameWithType> structure that the .NET Framework uses to represent a Unicode character. The value of a `Char` object is a 16-bit numeric (ordinal) value.

 Unicode characters are used to represent most of the written languages throughout the world.

|Type|Range|Size|.NET type|
|----------|-----------|----------|-------------------------|
|`char`|U+0000 to U+FFFF|Unicode 16-bit character|<xref:System.Char?displayProperty=nameWithType>|

## Literals

Constants of the `char` type can be written as character literals, hexadecimal escape sequence, or Unicode representation. You can also cast the integral character codes. In the following example four `char` variables are initialized with the same character `X`:

[!code-csharp[csrefKeywordsTypes#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#19)]

## Conversions

A `char` can be implicitly converted to [ushort](../../../csharp/language-reference/keywords/ushort.md), [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). However, there are no implicit conversions from other types to the `char` type.

The <xref:System.Char?displayProperty=nameWithType> type provides several static methods for working with `char` values.

## C# language specification  

For more information, see [Integral types](~/_csharplang/spec/types.md#integral-types) in the [C# Language Specification](../language-specification/index.md). The language specification is the definitive source for C# syntax and usage.

## See also

- <xref:System.Char>  
- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
- [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
- [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
- [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
- [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)  
- [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
- [Strings](../../../csharp/programming-guide/strings/index.md)