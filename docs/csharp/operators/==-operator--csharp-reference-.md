---
title: "== Operator (C# Reference)"
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
  - "==_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "== operator [C#]"
  - "equality operator [C#]"
ms.assetid: 34c6b597-caa2-4855-a7cd-38ecdd11bd07
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
# == Operator (C# Reference)
For predefined value types, the equality operator (`==`) returns true if the values of its operands are equal, `false` otherwise. For reference types other than [string](../keywords/string--csharp-reference-.md), `==` returns `true` if its two operands refer to the same object. For the `string` type, `==` compares the values of the strings.  
  
## Remarks  
 User-defined value types can overload the `==` operator (see [operator](../keywords/operator--csharp-reference-2.md)). So can user-defined reference types, although by default `==` behaves as described above for both predefined and user-defined reference types. If `==` is overloaded, [!=](../operators/!=-operator--csharp-reference-.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code[csRefOperators#36](../operators/codesnippet/CSharp/==-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)