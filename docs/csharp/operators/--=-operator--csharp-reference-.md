---
title: "&lt;&lt;= Operator (C# Reference)"
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
  - "<<=_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<<= operator (left-shift assignment) [C#]"
  - "left shift assignment operator (<<=) [C#]"
ms.assetid: 3bc99c78-1edb-4827-86fc-bce6c3048871
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
# &lt;&lt;= Operator (C# Reference)
The left-shift assignment operator.  
  
## Remarks  
 An expression of the form  
  
```  
x <<= y  
```  
  
 is evaluated as  
  
```  
x = x << y  
```  
  
 except that `x` is only evaluated once. The [<< operator](../operators/---operator--csharp-reference-.md) shifts `x` left by the number of bits specified by `y`.  
  
 The `<<=` operator cannot be overloaded directly, but user-defined types can overload the [<< operator](../operators/---operator--csharp-reference-.md) (see [operator](../keywords/operator--csharp-reference-2.md)).  
  
## Example  
 [!code[csRefOperators#12](../operators/codesnippet/CSharp/--=-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)