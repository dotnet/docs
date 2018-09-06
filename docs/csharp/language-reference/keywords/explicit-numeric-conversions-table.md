---
title: "Explicit numeric conversions table (C# Reference)"
ms.date: 09/06/2018
helpviewer_keywords: 
  - "conversions [C#], explicit numeric"
  - "numeric conversions [C#], explicit"
  - "explicit numeric conversion [C#]"
  - "numeric data types [C#]"
  - "types [C#], explicit numeric conversions"
  - "type conversion [C#], explicit numeric"
ms.assetid: f3bb9e76-6b92-4df7-bc36-f866c24e1dfd
---
# Explicit numeric conversions table (C# Reference)

The following table shows the predefined explicit conversions between .NET numeric types for which there is no [implicit conversion](implicit-numeric-conversions-table.md).

|From|To|  
|----------|--------|  
|[sbyte](sbyte.md)|`byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[byte](byte.md)|`sbyte` or `char`|  
|[short](short.md)|`sbyte`, `byte`, `ushort`, `uint`, `ulong`, or `char`|  
|[ushort](ushort.md)|`sbyte`, `byte`, `short`, or `char`|  
|[int](int.md)|`sbyte`, `byte`, `short`, `ushort`, `uint`, `ulong`,or `char`|  
|[uint](uint.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, or `char`|  
|[long](long.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `ulong`, or `char`|  
|[ulong](ulong.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, or `char`|  
|[char](char.md)|`sbyte`, `byte`, or `short`|  
|[float](float.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`,or `decimal`|  
|[double](double.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`,or `decimal`|  
|[decimal](decimal.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, or `double`|  
  
## Remarks  
  
- The explicit numeric conversion may cause loss of precision or result in throwing an exception, typically an <xref:System.OverflowException>.  

- When you convert a value of an integral type to another integral type, the result depends on the overflow [checking context](checked-and-unchecked.md). In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an <xref:System.OverflowException> is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:

  - If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.

  - If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it is the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.

  - If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.
  
- When you convert a `decimal` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, an <xref:System.OverflowException> is thrown.  
  
- When you convert a `double` or `float` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, the result depends on the overflow [checking context](checked-and-unchecked.md). In a checked context, an <xref:System.OverflowException> is thrown, while in an unchecked context, the result is an unspecified value of the destination type.  
  
- When you convert `double` to `float`, the `double` value is rounded to the nearest `float` value. If the `double` value is too small or too large to fit into the destination type, the result will be zero or infinity.  
  
- When you convert `float` or `double` to `decimal`, the source value is converted to `decimal` representation and rounded to the nearest number after the 28th decimal place if required. Depending on the value of the source value, one of the following results may occur:  

  - If the source value is too small to be represented as a `decimal`, the result becomes zero.  

  - If the source value is NaN (not a number), infinity, or too large to be represented as a `decimal`, an <xref:System.OverflowException> is thrown.  
  
- When you convert `decimal` to `float` or `double`, the `decimal` value is rounded to the nearest `double` or `float` value.  
  
 For more information about explicit conversions, see the [Explicit conversions](/dotnet/csharp/language-reference/language-specification/conversions#explicit-conversions) section of the [C# language specification](../language-specification/index.md).
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md)
- [() Operator](../operators/invocation-operator.md)
- [Integral types table](integral-types-table.md)
- [Floating-point types table](floating-point-types-table.md)
- [Built-in types table](built-in-types-table.md)
- [Implicit numeric conversions table](implicit-numeric-conversions-table.md)
