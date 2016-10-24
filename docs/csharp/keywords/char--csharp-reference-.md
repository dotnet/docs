---
title: "char (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "char"
  - "char_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "char data type [C#]"
ms.assetid: b51cf4fb-124c-4067-af48-afbac122b228
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# char (C# Reference)
The `char` keyword is used to declare an instance of the <xref:System.Char?displayProperty=fullName> structure that the .NET Framework uses to represent a Unicode character. The value of a `Char` object is a 16-bit numeric (ordinal) value.  
  
 Unicode characters are used to represent most of the written languages throughout the world.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`char`|U+0000 to U+FFFF|Unicode 16-bit character|<xref:System.Char?displayProperty=fullName>|  
  
## Literals  
 Constants of the `char` type can be written as character literals, hexadecimal escape sequence, or Unicode representation. You can also cast the integral character codes. In the following example four `char` variables are initialized with the same character `X`:  
  
 [!code[csrefKeywordsTypes#19](../keywords/codesnippet/CSharp/char--csharp-reference-_1.cs)]  
  
## Conversions  
 A `char` can be implicitly converted to [ushort](../keywords/ushort--csharp-reference-.md), [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), [ulong](../keywords/ulong--csharp-reference-.md), [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md). However, there are no implicit conversions from other types to the `char` type.  
  
 The <xref:System.Char?displayProperty=fullName> type provides several static methods for working with `char` values.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Char>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)   
 [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md)   
 [Strings](../strings/strings--csharp-programming-guide-.md)