---
title: "byte (C# Reference)"
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
  - "byte"
  - "byte_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "byte keyword [C#]"
ms.assetid: 111f1db9-ca32-4f0e-b497-4783517eda47
caps.latest.revision: 19
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
# byte (C# Reference)
The `byte` keyword denotes an integral type that stores values as indicated in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`byte`|0 to 255|Unsigned 8-bit integer|<xref:System.Byte?displayProperty=fullName>|  
  
## Literals  
 You can declare and initialize a `byte` variable like this example:  
  
```  
byte myByte = 255;  
```  
  
 In the preceding declaration, the integer literal `255` is implicitly converted from [int](../keywords/int--csharp-reference-.md) to `byte`. If the integer literal exceeds the range of `byte`, a compilation error will occur.  
  
## Conversions  
 There is a predefined implicit conversion from `byte` to [short](../keywords/short--csharp-reference-.md), [ushort](../keywords/ushort--csharp-reference-.md), [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), [ulong](../keywords/ulong--csharp-reference-.md), [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md).  
  
 You cannot implicitly convert non-literal numeric types of larger storage size to `byte`. For more information on the storage sizes of integral types, see [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md). Consider, for example, the following two `byte` variables `x` and `y`:  
  
```  
  
byte x = 10, y = 20;  
```  
  
 The following assignment statement will produce a compilation error, because the arithmetic expression on the right-hand side of the assignment operator evaluates to `int` by default.  
  
```  
// Error: conversion from int to byte:  
byte z = x + y;  
```  
  
 To fix this problem, use a cast:  
  
```  
// OK: explicit conversion:  
byte z = (byte)(x + y);  
```  
  
 It is possible though, to use the following statements where the destination variable has the same storage size or a larger storage size:  
  
```  
int x = 10, y = 20;  
int m = x + y;  
long n = x + y;  
```  
  
 Also, there is no implicit conversion from floating-point types to `byte`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
// Error: no implicit conversion from double:  
byte x = 3.0;   
// OK: explicit conversion:  
byte y = (byte)3.0;  
```  
  
 When calling overloaded methods, a cast must be used. Consider, for example, the following overloaded methods that use `byte` and [int](../keywords/int--csharp-reference-.md) parameters:  
  
```  
public static void SampleMethod(int i) {}  
public static void SampleMethod(byte b) {}  
```  
  
 Using the `byte` cast guarantees that the correct type is called, for example:  
  
```  
// Calling the method with the int parameter:  
SampleMethod(5);  
// Calling the method with the byte parameter:  
SampleMethod((byte)5);  
```  
  
 For information on arithmetic expressions with mixed floating-point types and integral types, see [float](../keywords/float--csharp-reference-.md) and [double](../keywords/double--csharp-reference-.md).  
  
 For more information on implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Byte>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)