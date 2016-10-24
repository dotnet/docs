---
title: "long (C# Reference)"
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
  - "long_CSharpKeyword"
  - "long"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "long keyword [C#]"
ms.assetid: f9b24319-1f39-48be-a42b-d528ee28a7fd
caps.latest.revision: 17
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
# long (C# Reference)
The `long` keyword denotes an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`long`|–9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|<xref:System.Int64?displayProperty=fullName>|  
  
## Literals  
 You can declare and initialize a `long` variable like this example:  
  
```  
  
long long1 = 4294967296;  
```  
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), `long`, [ulong](../keywords/ulong--csharp-reference-.md). In the preceding example, it is of the type `long` because it exceeds the range of [uint](../keywords/uint--csharp-reference-.md) (see [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md) for the storage sizes of integral types).  
  
 You can also use the suffix L with the `long` type like this:  
  
```  
  
long long2 = 4294967296L;  
```  
  
 When you use the suffix L, the type of the literal integer is determined to be either `long` or [ulong](../keywords/ulong--csharp-reference-.md) according to its size. In the case it is `long` because it less than the range of [ulong](../keywords/ulong--csharp-reference-.md).  
  
 A common use of the suffix is with calling overloaded methods. Consider, for example, the following overloaded methods that use `long` and [int](../keywords/int--csharp-reference-.md) parameters:  
  
```  
public static void SampleMethod(int i) {}  
public static void SampleMethod(long l) {}  
```  
  
 Using the suffix L guarantees that the correct type is called, for example:  
  
```  
SampleMethod(5);    // Calling the method with the int parameter  
SampleMethod(5L);   // Calling the method with the long parameter  
```  
  
 You can use the `long` type with other numeric integral types in the same expression, in which case the expression is evaluated as `long` (or [bool](../keywords/bool--csharp-reference-.md) in the case of relational or Boolean expressions). For example, the following expression evaluates as `long`:  
  
```  
898L + 88  
```  
  
> [!NOTE]
>  You can also use the lowercase letter "l" as a suffix. However, this generates a compiler warning because the letter "l" is easily confused with the digit "1." Use "L" for clarity.  
  
 For information on arithmetic expressions with mixed floating-point types and integral types, see [float](../keywords/float--csharp-reference-.md) and [double](../keywords/double--csharp-reference-.md).  
  
## Conversions  
 There is a predefined implicit conversion from `long` to [float](../keywords/float--csharp-reference-.md), [double](../keywords/double--csharp-reference-.md), or [decimal](../keywords/decimal--csharp-reference-.md). Otherwise a cast must be used. For example, the following statement will produce a compilation error without an explicit cast:  
  
```  
int x = 8L;        // Error: no implicit conversion from long to int  
int x = (int)8L;   // OK: explicit conversion to int  
```  
  
 There is a predefined implicit conversion from [sbyte](../keywords/sbyte--csharp-reference-.md), [byte](../keywords/byte--csharp-reference-.md), [short](../keywords/short--csharp-reference-.md), [ushort](../keywords/ushort--csharp-reference-.md), [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), or [char](../keywords/char--csharp-reference-.md) to `long`.  
  
 Notice also that there is no implicit conversion from floating-point types to `long`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
  
      long x = 3.0;         // Error: no implicit conversion from double  
long y = (long)3.0;   // OK: explicit conversion  
```  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Int64>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)