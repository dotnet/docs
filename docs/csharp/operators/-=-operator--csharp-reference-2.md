---
title: "-= Operator (C# Reference)2"
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
  - "-=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "subtraction assignment operator (-=) [C#]"
  - "-= operator (subtraction assignment ) [C#]"
ms.assetid: 05c7d68a-423f-4de8-891b-cf24e8fb6ed7
caps.latest.revision: 19
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
# -= Operator (C# Reference)
The subtraction assignment operator.  
  
## Remarks  
 An expression using the `-=` assignment operator, such as  
  
```  
x -= y  
```  
  
 is equivalent to  
  
```  
x = x - y  
```  
  
 except that `x` is only evaluated once. The meaning of the [- operator](../operators/--operator--csharp-reference-2.md) is dependent on the types of `x` and `y` (subtraction for numeric operands, delegate removal for delegate operands, and so forth).  
  
 The `-=` operator cannot be overloaded directly, but user-defined types can overload the [- operator](../operators/--operator--csharp-reference-2.md) (see [operator](../keywords/operator--csharp-reference-2.md)).  
  
 The -= operator is also used in C# to unsubscribe from an event. For more information, see [How to: Subscribe to and Unsubscribe from Events](../events/how-to--subscribe-to-and-unsubscribe-from-events--csharp-programming-guide-.md).  
  
## Example  
 [!code[csRefOperators#6](../operators/codesnippet/CSharp/-=-operator--csharp-reference-2_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)