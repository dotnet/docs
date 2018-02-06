---
title: "ushort (C# Reference)"
ms.date: 03/14/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "ushort"
  - "ushort_CSharpKeyword"
helpviewer_keywords: 
  - "ushort keyword [C#]"
ms.assetid: 1a7dbaae-b7a0-4111-872a-c88a6d3981ac
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# ushort (C# Reference)

The `ushort` keyword indicates an integral data type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`ushort`|0 to 65,535|Unsigned 16-bit integer|<xref:System.UInt16?displayProperty=nameWithType>|  
  
## Literals  

You can declare and initialize a `ushort` variable by assigning a decimal literal, a hexadecimal literal, or (starting with C# 7) a binary literal to it. If the integer literal is outside the range of `ushort` (that is, if it is less than <xref:System.UInt16.MinValue?displayProperty=nameWithType> or greater than <xref:System.UInt16.MaxValue?displayProperty=nameWithType>), a compilation error occurs.

In the following example, integers equal to 65,034 that are represented as decimal, hexadecimal, and binary literals are implicitly converted from [int](../../../csharp/language-reference/keywords/int.md) to `ushort` values.    
  
[!code-csharp[UShort](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#UShort)]  

> [!NOTE] 
> You use the prefix `0x` or `0X` to denote a hexadecimal literal and the prefix `0b` or `0B` to denote a binary literal. Decimal literals have no prefix.

Starting with C# 7, a couple of features have been added to enhance readability. 
 - C# 7.0 allows the usage of the underscore character, `_`, as a digit separator.
 - C# 7.2 allows `_` to be used as a digit separator for a binary or hexadecimal literal, after the prefix. A decimal literal isn't permitted to have a leading underscore.

Some examples are shown below.

[!code-csharp[UShort](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#UShortS)]  
 
## Compiler overload resolution
  
 A cast must be used when you call overloaded methods. Consider, for example, the following overloaded methods that use `ushort` and [int](../../../csharp/language-reference/keywords/int.md) parameters:  
  
```csharp  
public static void SampleMethod(int i) {}  
public static void SampleMethod(ushort s) {}  
```  
 
 Using the `ushort` cast guarantees that the correct type is called, for example:  
  
```csharp  
// Calls the method with the int parameter:  
SampleMethod(5);  
// Calls the method with the ushort parameter:  
SampleMethod((ushort)5);    
```  
  
## Conversions  
 There is a predefined implicit conversion from `ushort` to [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md).  
  
 There is a predefined implicit conversion from [byte](../../../csharp/language-reference/keywords/byte.md) or [char](../../../csharp/language-reference/keywords/char.md) to `ushort`. Otherwise a cast must be used to perform an explicit conversion. Consider, for example, the following two `ushort` variables `x` and `y`:  
  
```csharp 
ushort x = 5, y = 12;  
```  
  
 The following assignment statement will produce a compilation error, because the arithmetic expression on the right side of the assignment operator evaluates to `int` by default.  
  
```csharp  
ushort z = x + y;   // Error: conversion from int to ushort  
```  
  
 To fix this problem, use a cast:  
  
```csharp 
ushort z = (ushort)(x + y);   // OK: explicit conversion   
```  
  
 It is possible though to use the following statements, where the destination variable has the same storage size or a larger storage size:  
  
```csharp
int m = x + y;  
long n = x + y;  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `ushort`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```csharp  
// Error -- no implicit conversion from double:  
ushort x = 3.0;   
// OK -- explicit conversion:  
ushort y = (ushort)3.0;  
```  
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.UInt16>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)
