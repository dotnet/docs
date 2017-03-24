---
title: "int (C# Reference) | Microsoft Docs"
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
  - "int_CSharpKeyword"
  - "int"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "int keyword [C#]"
ms.assetid: 212447b4-5d2a-41aa-88ab-84fe710bdb52
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# int (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `int` keyword denotes an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|Default Value|  
|----------|-----------|----------|-------------------------|-------------------|  
|`int`|-2,147,483,648 to 2,147,483,647|Signed 32-bit integer|<xref:System.Int32?displayProperty=fullName>|0|  
  
## Literals  
 You can declare and initialize a variable of the type `int` like this example:  
  
```  
  
int i = 123;  
```  
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: `int`, [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md). In this example, it is of the type `int`.  
  
## Conversions  
 There is a predefined implicit conversion from `int` to [long](../../../csharp/language-reference/keywords/long.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). For example:  
  
```  
// '123' is an int, so an implicit conversion takes place here:  
float f = 123;  
```  
  
 There is a predefined implicit conversion from [sbyte](../../../csharp/language-reference/keywords/sbyte.md), [byte](../../../csharp/language-reference/keywords/byte.md), [short](../../../csharp/language-reference/keywords/short.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), or [char](../../../csharp/language-reference/keywords/char.md) to `int`. For example, the following assignment statement will produce a compilation error without a cast:  
  
```  
long aLong = 22;  
int i1 = aLong;       // Error: no implicit conversion from long.  
int i2 = (int)aLong;  // OK: explicit conversion.  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `int`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
  
      int x = 3.0;         // Error: no implicit conversion from double.  
int y = (int)3.0;    // OK: explicit conversion.  
```  
  
 For more information on arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Int32>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)   
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)   
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)   
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)