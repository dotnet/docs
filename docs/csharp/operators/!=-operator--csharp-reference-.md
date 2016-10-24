---
title: "!= Operator (C# Reference)"
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
  - "!=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "inequality operator (!=) [C#]"
  - "not equals operator (!=) [C#]"
  - "!= operator [C#]"
ms.assetid: eeff7a4e-ad6f-462d-9f8d-49e9b91c6c97
caps.latest.revision: 14
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
# != Operator (C# Reference)
The inequality operator (`!=`) returns false if its operands are equal, true otherwise. Inequality operators are predefined for all types, including string and object. User-defined types can overload the `!=` operator.  
  
## Remarks  
 For predefined value types, the inequality operator (`!=`) returns true if the values of its operands are different, false otherwise. For reference types other than `string`, `!=` returns true if its two operands refer to different objects. For the `string` type, `!=` compares the values of the strings.  
  
 User-defined value types can overload the `!=` operator (see [operator](../keywords/operator--csharp-reference-2.md)). So can user-defined reference types, although by default `!=` behaves as described above for both predefined and user-defined reference types. If `!=` is overloaded, [==](../operators/==-operator--csharp-reference-.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code[csRefOperators#33](../operators/codesnippet/CSharp/!=-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)