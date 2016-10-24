---
title: "-= Operator (C# Reference)1"
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
  - "/=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "division assignment operator (/=) [C#]"
  - "/= (division assignment operator) [C#]"
ms.assetid: 50fc02b0-ee9c-4c3e-b58d-d591282caf1c
caps.latest.revision: 17
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
# /= Operator (C# Reference)
The division assignment operator.  
  
## Remarks  
 An expression using the `/=` assignment operator, such as  
  
```  
x /= y  
```  
  
 is equivalent to  
  
```  
x = x / y  
```  
  
 except that `x` is only evaluated once. The [/ operator](../operators/--operator--csharp-reference-1.md) is predefined for numeric types to perform division.  
  
 The `/=` operator cannot be overloaded directly, but user-defined types can overload the [/ operator](../operators/--operator--csharp-reference-1.md) (see [operator](../keywords/operator--csharp-reference-2.md)). On all compound assignment operators, overloading the binary operator implicitly overloads the equivalent compound assignment.  
  
## Example  
 [!code[csRefOperators#5](../operators/codesnippet/CSharp/-=-operator--csharp-reference-1_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)