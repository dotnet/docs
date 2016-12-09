---
title: "uint (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
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
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](../../../csharp/language-reference/keywords/int.md), `uint`, [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md). In this example, it is `uint`:  
  
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
 There is a predefined implicit conversion from `uint` to [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). For example:  
  
```  
float myFloat = 4294967290;   // OK: implicit conversion to float  
```  
  
 There is a predefined implicit conversion from [byte](../../../csharp/language-reference/keywords/byte.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), or [char](../../../csharp/language-reference/keywords/char.md) to `uint`. Otherwise you must use a cast. For example, the following assignment statement will produce a compilation error without a cast:  
  
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
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.UInt32>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)   
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)   
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)   
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)