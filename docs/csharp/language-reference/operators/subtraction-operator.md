---
title: "- Operator (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "-_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "- operator [C#]"
  - "subtraction operator (-) [C#]"
ms.assetid: 4de7a4fa-c69d-48e6-aff1-3130af970b2d
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
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
# - Operator (C# Reference)
The `-` operator can function as either a unary or a binary operator.  
  
## Remarks  
 Unary `-` operators are predefined for all numeric types. The result of a unary `-` operation on a numeric type is the numeric negation of the operand.  
  
 Binary `-` operators are predefined for all numeric and enumeration types to subtract the second operand from the first.  
  
 Delegate types also provide a binary `-` operator, which performs delegate removal.  
  
 User-defined types can overload the unary `-` and binary `-` operators. For more information, see [operator (C# Reference)](../../../csharp/language-reference/keywords/operator.md).  
  
## Example  
 [!code-cs[csRefOperators#40](../../../csharp/language-reference/operators/codesnippet/CSharp/subtraction-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)