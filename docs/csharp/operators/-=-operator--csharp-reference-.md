---
title: "&gt;= Operator (C# Reference)"
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
  - ">=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "greater than or equal to operator (>=) [C#]"
  - ">= operator [C#]"
ms.assetid: 0db4dcaf-56a3-4884-a7ad-35f64978a58d
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
# &gt;= Operator (C# Reference)
All numeric and enumeration types define a "greater than or equal" relational operator, `>=` that returns `true` if the first operand is greater than or equal to the second, `false` otherwise.  
  
## Remarks  
 User-defined types can overload the `>=` operator. For more information, see [operator](../keywords/operator--csharp-reference-2.md). If `>=` is overloaded, [<=](../operators/-=-operator--csharp-reference-.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code[csRefOperators#39](../operators/codesnippet/CSharp/-=-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)