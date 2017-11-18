---
title: "char (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "char"
  - "char_CSharpKeyword"
helpviewer_keywords: 
  - "char data type [C#]"
ms.assetid: b51cf4fb-124c-4067-af48-afbac122b228
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
---
# char (C# Reference)
The `char` keyword is used to declare an instance of the <xref:System.Char?displayProperty=nameWithType> structure that the .NET Framework uses to represent a Unicode character. The value of a `Char` object is a 16-bit numeric (ordinal) value.  
  
 Unicode characters are used to represent most of the written languages throughout the world.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`char`|U+0000 to U+FFFF|Unicode 16-bit character|<xref:System.Char?displayProperty=nameWithType>|  
  
## Literals  
 Constants of the `char` type can be written as character literals, hexadecimal escape sequence, or Unicode representation. You can also cast the integral character codes. In the following example four `char` variables are initialized with the same character `X`:  
  
 [!code-csharp[csrefKeywordsTypes#19](../../../csharp/language-reference/keywords/codesnippet/CSharp/char_1.cs)]  
  
## Conversions  
 A `char` can be implicitly converted to [ushort](../../../csharp/language-reference/keywords/ushort.md), [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). However, there are no implicit conversions from other types to the `char` type.  
  
 The <xref:System.Char?displayProperty=nameWithType> type provides several static methods for working with `char` values.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Char>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
 [Strings](../../../csharp/programming-guide/strings/index.md)
