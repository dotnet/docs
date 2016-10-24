---
title: "Integral Types Table (C# Reference)"
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
  - "integral types, C#"
  - "Visual C#, integral types"
  - "types [C#], integral types"
  - "ranges of integral types [C#]"
ms.assetid: 62e86126-46ff-40b0-9028-e61d7558268c
caps.latest.revision: 9
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
# Integral Types Table (C# Reference)
The following table shows the sizes and ranges of the integral types, which constitute a subset of simple types.  
  
|Type|Range|Size|  
|----------|-----------|----------|  
|[sbyte](../keywords/sbyte--csharp-reference-.md)|-128 to 127|Signed 8-bit integer|  
|[byte](../keywords/byte--csharp-reference-.md)|0 to 255|Unsigned 8-bit integer|  
|[char](../keywords/char--csharp-reference-.md)|U+0000 to U+ffff|Unicode 16-bit character|  
|[short](../keywords/short--csharp-reference-.md)|-32,768 to 32,767|Signed 16-bit integer|  
|[ushort](../keywords/ushort--csharp-reference-.md)|0 to 65,535|Unsigned 16-bit integer|  
|[int](../keywords/int--csharp-reference-.md)|-2,147,483,648 to 2,147,483,647|Signed 32-bit integer|  
|[uint](../keywords/uint--csharp-reference-.md)|0 to 4,294,967,295|Unsigned 32-bit integer|  
|[long](../keywords/long--csharp-reference-.md)|-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|  
|[ulong](../keywords/ulong--csharp-reference-.md)|0 to 18,446,744,073,709,551,615|Unsigned 64-bit integer|  
  
 If the value represented by an integer literal exceeds the range of `ulong`, a compilation error will occur.  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Floating-Point Types Table](../keywords/floating-point-types-table--csharp-reference-.md)   
 [Default Values Table](../keywords/default-values-table--csharp-reference-.md)   
 [Formatting Numeric Results Table](../keywords/formatting-numeric-results-table--csharp-reference-.md)   
 [Reference Tables for Types](../keywords/reference-tables-for-types--csharp-reference-.md)