---
title: "- Operator (C# Reference)1"
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
  - "/_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/ operator [C#]"
  - "division operator [C#]"
ms.assetid: d155e496-678f-4efa-bebe-2bd08da2c5af
caps.latest.revision: 21
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
# / Operator (C# Reference)
The division operator (`/`) divides its first operand by its second operand. All numeric types have predefined division operators.  
  
## Remarks  
 User-defined types can overload the `/` operator (see [operator](../keywords/operator--csharp-reference-2.md)). An overload of the `/` operator implicitly overloads the [/= operator](../operators/-=-operator--csharp-reference-1.md).  
  
 When you divide two integers, the result is always an integer. For example, the result of 7 / 3 is 2. To determine the remainder of 7 / 3, use the remainder operator ([%](../operators/--operator--csharp-reference-.md)). To obtain a quotient as a rational number or fraction, give the dividend or divisor type `float` or type `double`. You can assign the type implicitly if you express the dividend or divisor as a decimal by putting a digit to the right side of the decimal point, as the following example shows.  
  
## Example  
 [!code[csRefOperators#42](../operators/codesnippet/CSharp/--operator--csharp-reference-1_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)