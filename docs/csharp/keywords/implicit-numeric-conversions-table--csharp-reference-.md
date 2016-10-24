---
title: "Implicit Numeric Conversions Table (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "conversions [C#], implicit numeric"
  - "implicit numeric conversions [C#]"
  - "numeric conversions [C#], implicit"
  - "types [C#], implicit numeric conversions"
ms.assetid: 72eb5a94-0491-48bf-8032-d7ebfdfeb8d8
caps.latest.revision: 12
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
# Implicit Numeric Conversions Table (C# Reference)
The following table shows the predefined implicit numeric conversions. Implicit conversions might occur in many situations, including method invoking and assignment statements.  
  
|From|To|  
|----------|--------|  
|[sbyte](../keywords/sbyte--csharp-reference-.md)|`short`, `int`, `long`, `float`, `double`, or `decimal`|  
|[byte](../keywords/byte--csharp-reference-.md)|`short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[short](../keywords/short--csharp-reference-.md)|`int`, `long`, `float`, `double`, or `decimal`|  
|[ushort](../keywords/ushort--csharp-reference-.md)|`int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[int](../keywords/int--csharp-reference-.md)|`long`, `float`, `double`, or `decimal`|  
|[uint](../keywords/uint--csharp-reference-.md)|`long`, `ulong`, `float`, `double`, or `decimal`|  
|[long](../keywords/long--csharp-reference-.md)|`float`, `double`, or `decimal`|  
|[char](../keywords/char--csharp-reference-.md)|`ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[float](../keywords/float--csharp-reference-.md)|`double`|  
|[ulong](../keywords/ulong--csharp-reference-.md)|`float`, `double`, or `decimal`|  
  
## Remarks  
  
-   Precision but not magnitude might be lost in the conversions from `int`, `uint`,  `long`, or `ulong` to `float` and from `long` or `ulong` to `double`.  
  
-   There are no implicit conversions to the `char` type.  
  
-   There are no implicit conversions between floating-point types and the `decimal` type.  
  
-   A constant expression of type `int` can be converted to `sbyte`, `byte`, `short`, `ushort`, `uint`, or `ulong`, provided the value of the constant expression is within the range of the destination type.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)   
 [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md)