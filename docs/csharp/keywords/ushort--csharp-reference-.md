---
title: "ushort (C# Reference)"
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
  - "ushort"
  - "ushort_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "ushort keyword [C#]"
ms.assetid: 1a7dbaae-b7a0-4111-872a-c88a6d3981ac
caps.latest.revision: 16
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
# ushort (C# Reference)
The `ushort` keyword indicates an integral data type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`ushort`|0 to 65,535|Unsigned 16-bit integer|<xref:System.UInt16?displayProperty=fullName>|  
  
## Literals  
 You can declare and initialize a `ushort` variable such as this example:  
  
```  
  
ushort myShort = 65535;  
```  
  
 In the previous declaration, the integer literal `65535` is implicitly converted from [int](../keywords/int--csharp-reference-.md) to `ushort`. If the integer literal exceeds the range of `ushort`, a compilation error will occur.  
  
 A cast must be used when you call overloaded methods. Consider, for example, the following overloaded methods that use `ushort` and [int](../keywords/int--csharp-reference-.md) parameters:  
  
```  
public static void SampleMethod(int i) {}  
public static void SampleMethod(ushort s) {}  
```  
  
 Using the `ushort` cast guarantees that the correct type is called, for example:  
  
```  
// Calls the method with the int parameter:  
SampleMethod(5);  
// Calls the method with the ushort parameter:  
SampleMethod((ushort)5);    
```  
  
## Conversions  
 There is a predefined implicit conversion from `ushort` to [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), [ulong](../keywords/ulong--csharp-reference-.md), [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md).  
  
 There is a predefined implicit conversion from [byte](../keywords/byte--csharp-reference-.md) or [char](../keywords/char--csharp-reference-.md) to `ushort`. Otherwise a cast must be used to perform an explicit conversion. Consider, for example, the following two `ushort` variables `x` and `y`:  
  
```  
  
ushort x = 5, y = 12;  
```  
  
 The following assignment statement will produce a compilation error, because the arithmetic expression on the right side of the assignment operator evaluates to `int` by default.  
  
```  
  
ushort z = x + y;   // Error: conversion from int to ushort  
```  
  
 To fix this problem, use a cast:  
  
```  
  
ushort z = (ushort)(x + y);   // OK: explicit conversion   
```  
  
 It is possible though to use the following statements, where the destination variable has the same storage size or a larger storage size:  
  
```  
int m = x + y;  
long n = x + y;  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `ushort`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
// Error -- no implicit conversion from double:  
ushort x = 3.0;   
// OK -- explicit conversion:  
ushort y = (ushort)3.0;  
```  
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../keywords/float--csharp-reference-.md) and [double](../keywords/double--csharp-reference-.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.UInt16>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)