---
title: "long (C# Reference) | Microsoft Docs"
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
---
# long (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `long` keyword denotes an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`long`|–9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|<xref:System.Int64?displayProperty=fullName>|  
  
## Literals  
 You can declare and initialize a `long` variable like this example:  
  
```  
  
long long1 = 4294967296;  
```  
  
 When an integer literal has no suffix, its type is the first of these types in which its value can be represented: [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), `long`, [ulong](../../../csharp/language-reference/keywords/ulong.md). In the preceding example, it is of the type `long` because it exceeds the range of [uint](../../../csharp/language-reference/keywords/uint.md) (see [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md) for the storage sizes of integral types).  
  
 You can also use the suffix L with the `long` type like this:  
  
```  
  
long long2 = 4294967296L;  
```  
  
 When you use the suffix L, the type of the literal integer is determined to be either `long` or [ulong](../../../csharp/language-reference/keywords/ulong.md) according to its size. In the case it is `long` because it less than the range of [ulong](../../../csharp/language-reference/keywords/ulong.md).  
  
 A common use of the suffix is with calling overloaded methods. Consider, for example, the following overloaded methods that use `long` and [int](../../../csharp/language-reference/keywords/int.md) parameters:  
  
```  
public static void SampleMethod(int i) {}  
public static void SampleMethod(long l) {}  
```  
  
 Using the suffix L guarantees that the correct type is called, for example:  
  
```  
SampleMethod(5);    // Calling the method with the int parameter  
SampleMethod(5L);   // Calling the method with the long parameter  
```  
  
 You can use the `long` type with other numeric integral types in the same expression, in which case the expression is evaluated as `long` (or [bool](../../../csharp/language-reference/keywords/bool.md) in the case of relational or Boolean expressions). For example, the following expression evaluates as `long`:  
  
```  
898L + 88  
```  
  
> [!NOTE]
>  You can also use the lowercase letter "l" as a suffix. However, this generates a compiler warning because the letter "l" is easily confused with the digit "1." Use "L" for clarity.  
  
 For information on arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
## Conversions  
 There is a predefined implicit conversion from `long` to [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). Otherwise a cast must be used. For example, the following statement will produce a compilation error without an explicit cast:  
  
```  
int x = 8L;        // Error: no implicit conversion from long to int  
int x = (int)8L;   // OK: explicit conversion to int  
```  
  
 There is a predefined implicit conversion from [sbyte](../../../csharp/language-reference/keywords/sbyte.md), [byte](../../../csharp/language-reference/keywords/byte.md), [short](../../../csharp/language-reference/keywords/short.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), or [char](../../../csharp/language-reference/keywords/char.md) to `long`.  
  
 Notice also that there is no implicit conversion from floating-point types to `long`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```  
  
      long x = 3.0;         // Error: no implicit conversion from double  
long y = (long)3.0;   // OK: explicit conversion  
```  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Int64>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)   
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)   
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)   
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)