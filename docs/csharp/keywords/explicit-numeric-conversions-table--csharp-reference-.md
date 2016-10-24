---
title: "Explicit Numeric Conversions Table (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "conversions [C#], explicit numeric"
  - "numeric conversions [C#], explicit"
  - "explicit numeric conversion [C#]"
  - "numeric data types [C#]"
  - "types [C#], explicit numeric conversions"
  - "type conversion [C#], explicit numeric"
ms.assetid: f3bb9e76-6b92-4df7-bc36-f866c24e1dfd
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Explicit Numeric Conversions Table (C# Reference)
Explicit numeric conversion is used to convert any numeric type to any other numeric type, for which there is no implicit conversion, by using a cast expression. The following table shows these conversions.  
  
 For more information about conversions, see [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md).  
  
|From|To|  
|----------|--------|  
|[sbyte](../keywords/sbyte--csharp-reference-.md)|`byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[byte](../keywords/byte--csharp-reference-.md)|`Sbyte` or `char`|  
|[short](../keywords/short--csharp-reference-.md)|`sbyte`, `byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[ushort](../keywords/ushort--csharp-reference-.md)|`sbyte`, `byte`, `short`, or `char`|  
|[int](../keywords/int--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `uint`, `ulong`,or `char`|  
|[uint](../keywords/uint--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, or `char`|  
|[long](../keywords/long--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `ulong`, or `char`|  
|[ulong](../keywords/ulong--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, or `char`|  
|[char](../keywords/char--csharp-reference-.md)|`sbyte`, `byte`, or `short`|  
|[float](../keywords/float--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`,or `decimal`|  
|[double](../keywords/double--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`,or `decimal`|  
|[decimal](../keywords/decimal--csharp-reference-.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, or `double`|  
  
## Remarks  
  
-   The explicit numeric conversion may cause loss of precision or result in throwing exceptions.  
  
-   When you convert a `decimal` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, an <xref:System.OverflowException> is thrown.  
  
-   When you convert from a `double` or `float` value to an integral type, the value is truncated. If the resulting integral value is outside the range of the destination value, the result depends on the overflow checking context. In a checked context, an `OverflowException` is thrown, while in an unchecked context, the result is an unspecified value of the destination type.  
  
-   When you convert `double` to `float`, the `double` value is rounded to the nearest `float` value. If the `double` value is too small or too large to fit into the destination type, the result will be zero or infinity.  
  
-   When you convert `float` or `double` to `decimal`, the source value is converted to `decimal` representation and rounded to the nearest number after the 28th decimal place if required. Depending on the value of the source value, one of the following results may occur:  
  
    -   If the source value is too small to be represented as a `decimal`, the result becomes zero.  
  
    -   If the source value is NaN (not a number), infinity, or too large to be represented as a `decimal`, an `OverflowException` is thrown.  
  
-   When you convert `decimal` to `float` or `double`, the `decimal` value is rounded to the nearest `double` or `float` value.  
  
 For more information on explicit conversion, see Explicit in the C# Language Specification. For more information on how to access the spec, see [C# Language Specification](../language-reference/csharp-language-specification.md).  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md)   
 [() Operator](../operators/---operator--csharp-reference-.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)