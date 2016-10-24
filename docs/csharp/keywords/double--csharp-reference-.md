---
title: "double (C# Reference)"
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
  - "double"
  - "double_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "double data type [C#]"
ms.assetid: 0980e11b-6004-4102-abcf-cfc280fc6991
caps.latest.revision: 26
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
# double (C# Reference)
The `double` keyword signifies a simple type that stores 64-bit floating-point values. The following table shows the precision and approximate range for the `double` type.  
  
|Type|Approximate range|Precision|.NET Framework type|  
|----------|-----------------------|---------------|-------------------------|  
|`double`|±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup>|15-16 digits|<xref:System.Double?displayProperty=fullName>|  
  
## Literals  
 By default, a real numeric literal on the right side of the assignment operator is treated as `double`. However, if you want an integer number to be treated as `double`, use the suffix d or D, for example:  
  
```  
  
double x = 3D;  
```  
  
## Conversions  
 You can mix numeric integral types and floating-point types in an expression. In this case, the integral types are converted to floating-point types. The evaluation of the expression is performed according to the following rules:  
  
-   If one of the floating-point types is `double`, the expression evaluates to `double`, or [bool](../keywords/bool--csharp-reference-.md) in relational or Boolean expressions.  
  
-   If there is no `double` type in the expression, it evaluates to [float](../keywords/float--csharp-reference-.md), or [bool](../keywords/bool--csharp-reference-.md) in relational or Boolean expressions.  
  
 A floating-point expression can contain the following sets of values:  
  
-   Positive and negative zero.  
  
-   Positive and negative infinity.  
  
-   Not-a-Number value (NaN).  
  
-   The finite set of nonzero values.  
  
 For more information about these values, see IEEE Standard for Binary Floating-Point Arithmetic, available on the [IEEE](http://go.microsoft.com/fwlink/?LinkId=26269) Web site.  
  
## Example  
 In the following example, an [int](../keywords/int--csharp-reference-.md), a [short](../keywords/short--csharp-reference-.md), a [float](../keywords/float--csharp-reference-.md), and a `double` are added together giving a `double` result.  
  
 [!code[csrefKeywordsTypes#9](../keywords/codesnippet/CSharp/double--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Default Values Table](../keywords/default-values-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Floating-Point Types Table](../keywords/floating-point-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)