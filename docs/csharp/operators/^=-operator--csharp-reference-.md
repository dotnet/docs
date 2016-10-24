---
title: "^= Operator (C# Reference)"
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
  - "^=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "^= operator [C#]"
ms.assetid: 3658ff9a-61cd-467e-ad6b-8fbf1cfbaae4
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
# ^= Operator (C# Reference)
The exclusive-OR assignment operator.  
  
## Remarks  
 An expression of the form  
  
```  
x ^= y  
```  
  
 is evaluated as  
  
```  
x = x ^ y  
```  
  
 except that `x` is only evaluated once. The [^ operator](../operators/^-operator--csharp-reference-.md) performs a bitwise exclusive-OR operation on integral operands and logical exclusive-OR on [bool](../keywords/bool--csharp-reference-.md) operands.  
  
 The ^= operator cannot be overloaded directly, but user-defined types can overload the [^ operator](../operators/^-operator--csharp-reference-.md) (see [operator](../keywords/operator--csharp-reference-2.md)).  
  
## Example  
 [!code[csRefOperators#23](../operators/codesnippet/CSharp/^=-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)