---
title: "ulong (C# Reference)"
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
  - "ulong_CSharpKeyword"
  - "ulong"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "ulong keyword [C#]"
ms.assetid: f2ece624-837a-40cf-92c5-343e7f33397c
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
# ulong (C# Reference)
The `ulong` keyword denotes an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`ulong`|0 to 18,446,744,073,709,551,615|Unsigned 64-bit integer|<xref:System.UInt64?displayProperty=fullName>|  
  
## Literals  
 You can declare and initialize a `ulong` variable like this example:  
  
```  
  
ulong uLong = 9223372036854775808;  
```  
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), `ulong`. In the example above, it is of the type `ulong`.  
  
 You can also use suffixes to specify the type of the literal according to the following rules:  
  
-   If you use L or l, the type of the literal integer will be either [long](../keywords/long--csharp-reference-.md) or `ulong` according to its size.  
  
    > [!NOTE]
    >  You can use the lowercase letter "l" as a suffix. However, this generates a compiler warning because the letter "l" is easily confused with the digit "1." Use "L" for clarity.  
  
-   If you use `U` or `u`, the type of the literal integer will be either [uint](../keywords/uint--csharp-reference-.md) or `ulong` according to its size.  
  
-   If you use UL, ul, Ul, uL, LU, lu, Lu, or lU, the type of the literal integer will be `ulong`.  
  
     For example, the output of the following three statements will be the system type `UInt64`, which corresponds to the alias `ulong`:  
  
    ```  
    Console.WriteLine(9223372036854775808L.GetType());  
    Console.WriteLine(123UL.GetType());  
    Console.WriteLine((123UL + 456).GetType());  
    ```  
  
 A common use of the suffix is with calling overloaded methods. Consider, for example, the following overloaded methods that use `ulong` and [int](../keywords/int--csharp-reference-.md) parameters:  
  
```  
public static void SampleMethod(int i) {}  
public static void SampleMethod(ulong l) {}  
```  
  
 Using a suffix with the `ulong` parameter guarantees that the correct type is called, for example:  
  
```  
SampleMethod(5);    // Calling the method with the int parameter  
SampleMethod(5UL);  // Calling the method with the ulong parameter  
```  
  
## Conversions  
 There is a predefined implicit conversion from `ulong` to [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md).  
  
 There is no implicit conversion from `ulong` to any integral type. For example, the following statement will produce a compilation error without an explicit cast:  
  
```  
long long1 = 8UL;   // Error: no implicit conversion from ulong  
```  
  
 There is a predefined implicit conversion from [byte](../keywords/byte--csharp-reference-.md), [ushort](../keywords/ushort--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), or [char](../keywords/char--csharp-reference-.md) to `ulong`.  
  
 Also, there is no implicit conversion from floating-point types to `ulong`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
// Error -- no implicit conversion from double:  
ulong x = 3.0;  
// OK -- explicit conversion:  
ulong y = (ulong)3.0;    
```  
  
 For information on arithmetic expressions with mixed floating-point types and integral types, see [float](../keywords/float--csharp-reference-.md) and [double](../keywords/double--csharp-reference-.md).  
  
 For more information on implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.UInt64>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)