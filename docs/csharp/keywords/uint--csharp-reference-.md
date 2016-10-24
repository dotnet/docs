---
title: "uint (C# Reference)"
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
  - "uint"
  - "uint_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "uint keyword [C#]"
ms.assetid: e93e42c6-ec72-4b0b-89df-2fd8d36f7a7b
caps.latest.revision: 18
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
# uint (C# Reference)
The `uint` keyword signifies an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`uint`|0 to 4,294,967,295|Unsigned 32-bit integer|<xref:System.UInt32?displayProperty=fullName>|  
  
 **Note** The `uint` type is not CLS-compliant. Use `int` whenever possible.  
  
## Literals  
 You can declare and initialize a variable of the type `uint` like this example:  
  
```  
  
uint myUint = 4294967290;  
```  
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](../keywords/int--csharp-reference-.md), `uint`, [long](../keywords/long--csharp-reference-.md), [ulong](../keywords/ulong--csharp-reference-.md). In this example, it is `uint`:  
  
```  
  
uint uInt1 = 123;  
```  
  
 You can also use the suffix u or U, such as this:  
  
```  
  
uint uInt2 = 123U;  
```  
  
 When you use the suffix `U` or `u`, the type of the literal is determined to be either `uint` or `ulong` according to the numeric value of the literal. For example:  
  
```  
Console.WriteLine(44U.GetType());  
Console.WriteLine(323442434344U.GetType());  
```  
  
 This code displays `System.UInt32`, followed by `System.UInt64` -- the underlying types for `uint` and `ulong` respectively -- because the second literal is too large to be stored by the `uint` type.  
  
## Conversions  
 There is a predefined implicit conversion from `uint` to [long](../keywords/long--csharp-reference-.md), [ulong](../keywords/ulong--csharp-reference-.md), [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md). For example:  
  
```  
float myFloat = 4294967290;   // OK: implicit conversion to float  
```  
  
 There is a predefined implicit conversion from [byte](../keywords/byte--csharp-reference-.md), [ushort](../keywords/ushort--csharp-reference-.md), or [char](../keywords/char--csharp-reference-.md) to `uint`. Otherwise you must use a cast. For example, the following assignment statement will produce a compilation error without a cast:  
  
```  
long aLong = 22;  
// Error -- no implicit conversion from long:  
uint uInt1 = aLong;   
// OK -- explicit conversion:  
uint uInt2 = (uint)aLong;  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `uint`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
// Error -- no implicit conversion from double:  
uint x = 3.0;  
// OK -- explicit conversion:  
uint y = (uint)3.0;   
```  
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../keywords/float--csharp-reference-.md) and [double](../keywords/double--csharp-reference-.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.UInt32>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)