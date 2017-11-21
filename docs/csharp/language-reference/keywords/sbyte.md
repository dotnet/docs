---
title: "sbyte (C# Reference)"
ms.date: 03/14/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "sbyte_CSharpKeyword"
  - "sbyte"
helpviewer_keywords: 
  - "sbyte keyword [C#]"
ms.assetid: 1a9c7b48-73d1-4d33-b485-c4faf0a816bc
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# sbyte (C# Reference)

`sbyte` denotes an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`sbyte`|-128 to 127|Signed 8-bit integer|<xref:System.SByte?displayProperty=nameWithType>|  
  
## Literals  

You can declare and initialize an `sbyte` variable by assigning a decimal literal, a hexadecimal literal, or (starting with C# 7) a binary literal to it. 

In the following example, integers equal to -102 that are represented as decimal, hexadecimal, and binary literals are converted from [int](../../../csharp/language-reference/keywords/int.md) to `sbyte` values.    
  
[!code-csharp[SByte](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#SByte)]  

> [!NOTE] 
> You use the prefix `0x` or `0X` to denote a hexadecimal literal and the prefix `0b` or `0B` to denote a binary literal. Decimal literals have no prefix.

Starting with C# 7, a couple of features have been added to enhance readability. 
 - C# 7.0 allows the usage of the underscore character, `_`, as a digit separator.
 - C# 7.2 allows `_` to be used as a digit separator for a binary or hexadecimal literal, after the prefix. A decimal literal isn't permitted to have a leading underscore.

 Some examples are shown below.

[!code-csharp[SByteSeparator](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#SByteS)]  

If the integer literal is outside the range of `sbyte` (that is, if it is less than <xref:System.SByte.MinValue?displayProperty=nameWithType> or greater than <xref:System.SByte.MaxValue?displayProperty=nameWithType>, a compilation error occurs. When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](int.md), [uint](uint.md), [long](long.md), [ulong](ulong.md). This means that, in this example, the numeric literals `0x9A` and `0b10011010` are interpreted as 32-bit signed integers with a value of 156, which exceeds <xref:System.SByte.MaxValue?displayProperty=nameWithType>. Because of this, the casting operator is needed, and the assignment must occur in an [unchecked](unchecked.md) context. 

## Compiler overload resolution

 A cast must be used when calling overloaded methods. Consider, for example, the following overloaded methods that use `sbyte` and [int](../../../csharp/language-reference/keywords/int.md) parameters:  
  
```csharp  
public static void SampleMethod(int i) {}  
public static void SampleMethod(sbyte b) {}  
```  
  
 Using the `sbyte` cast guarantees that the correct type is called, for example:  
  
```csharp 
// Calling the method with the int parameter:  
SampleMethod(5);  
// Calling the method with the sbyte parameter:  
SampleMethod((sbyte)5);  
```  
  
## Conversions  
 There is a predefined implicit conversion from `sbyte` to [short](../../../csharp/language-reference/keywords/short.md), [int](../../../csharp/language-reference/keywords/int.md), [long](../../../csharp/language-reference/keywords/long.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md).  
  
 You cannot implicitly convert nonliteral numeric types of larger storage size to `sbyte` (see [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md) for the storage sizes of integral types). Consider, for example, the following two `sbyte` variables `x` and `y`:  
  
```csharp  
sbyte x = 10, y = 20;  
```  
  
 The following assignment statement will produce a compilation error, because the arithmetic expression on the right side of the assignment operator evaluates to [int](../../../csharp/language-reference/keywords/int.md) by default.  
  
```csharp  
sbyte z = x + y;   // Error: conversion from int to sbyte  
```  
  
 To fix this problem, cast the expression as in the following example:  
  
```csharp  
sbyte z = (sbyte)(x + y);   // OK: explicit conversion  
```  
  
 It is possible though to use the following statements, where the destination variable has the same storage size or a larger storage size:  
  
```csharp
sbyte x = 10, y = 20;  
int m = x + y;  
long n = x + y;  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `sbyte`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```csharp  
sbyte x = 3.0;         // Error: no implicit conversion from double  
sbyte y = (sbyte)3.0;  // OK: explicit conversion  
```  
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.SByte>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)
