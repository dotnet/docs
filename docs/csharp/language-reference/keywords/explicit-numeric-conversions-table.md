---
title: "Explicit Numeric Conversions Table (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
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
---
# Explicit Numeric Conversions Table (C# Reference)
Explicit numeric conversion is used to convert any numeric type to any other numeric type, for which there is no implicit conversion, by using a cast expression. The following table shows these conversions.  
  
 For more information about conversions, see [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md).  
  
|From|To|  
|----------|--------|  
|[sbyte](../../../csharp/language-reference/keywords/sbyte.md)|`byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[byte](../../../csharp/language-reference/keywords/byte.md)|`Sbyte` or `char`|  
|[short](../../../csharp/language-reference/keywords/short.md)|`sbyte`, `byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[ushort](../../../csharp/language-reference/keywords/ushort.md)|`sbyte`, `byte`, `short`, or `char`|  
|[int](../../../csharp/language-reference/keywords/int.md)|`sbyte`, `byte`, `short`, `ushort`, `uint`, `ulong`,or `char`|  
|[uint](../../../csharp/language-reference/keywords/uint.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, or `char`|  
|[long](../../../csharp/language-reference/keywords/long.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `ulong`, or `char`|  
|[ulong](../../../csharp/language-reference/keywords/ulong.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, or `char`|  
|[char](../../../csharp/language-reference/keywords/char.md)|`sbyte`, `byte`, or `short`|  
|[float](../../../csharp/language-reference/keywords/float.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`,or `decimal`|  
|[double](../../../csharp/language-reference/keywords/double.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`,or `decimal`|  
|[decimal](../../../csharp/language-reference/keywords/decimal.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, or `double`|  
  
## Remarks  
  
-   The explicit numeric conversion may cause loss of precision or result in throwing exceptions.  
  
-   When you convert a `decimal` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, an <xref:System.OverflowException> is thrown.  
  
-   When you convert from a `double` or `float` value to an integral type, the value is truncated. If the resulting integral value is outside the range of the destination value, the result depends on the overflow checking context. In a checked context, an `OverflowException` is thrown, while in an unchecked context, the result is an unspecified value of the destination type.  
  
-   When you convert `double` to `float`, the `double` value is rounded to the nearest `float` value. If the `double` value is too small or too large to fit into the destination type, the result will be zero or infinity.  
  
-   When you convert `float` or `double` to `decimal`, the source value is converted to `decimal` representation and rounded to the nearest number after the 28th decimal place if required. Depending on the value of the source value, one of the following results may occur:  
  
    -   If the source value is too small to be represented as a `decimal`, the result becomes zero.  
  
    -   If the source value is NaN (not a number), infinity, or too large to be represented as a `decimal`, an `OverflowException` is thrown.  
  
-   When you convert `decimal` to `float` or `double`, the `decimal` value is rounded to the nearest `double` or `float` value.  
  
 For more information on explicit conversion, see Explicit in the C# Language Specification. For more information on how to access the spec, see [C# Language Specification](../../../csharp/language-reference/language-specification/index.md).  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md)  
 [() Operator](../../../csharp/language-reference/operators/invocation-operator.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)
