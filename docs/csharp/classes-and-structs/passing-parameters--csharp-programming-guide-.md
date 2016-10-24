---
title: "Passing Parameters (C# Programming Guide)"
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
  - "parameters [C#], passing"
  - "passing parameters [C#]"
  - "arguments [C#]"
  - "methods [C#], passing parameters"
  - "C# language, method parameters"
ms.assetid: a5c3003f-7441-4710-b8b1-c79de77e0b77
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
# Passing Parameters (C# Programming Guide)
In C#, arguments can be passed to parameters either by value or by reference. Passing by reference enables function members, methods, properties, indexers, operators, and constructors to change the value of the parameters and have that change persist in the calling environment. To pass a parameter by reference, use the `ref` or `out` keyword. For simplicity, only the `ref` keyword is used in the examples in this topic. For more information about the difference between `ref` and `out`, see [ref](../keywords/ref--csharp-reference-.md), [out](../keywords/out--csharp-reference-.md), and [Passing Arrays Using ref and out](../arrays/passing-arrays-using-ref-and-out--csharp-programming-guide-.md).  
  
 The following example illustrates the difference between value and reference parameters.  
  
 [!code[csProgGuideParameters#10](../classes-and-structs/codesnippet/CSharp/passing-parameters--csharp-programming-guide-_1.cs)]  
  
 For more information, see the following topics:  
  
-   [Passing Value-Type Parameters](../classes-and-structs/passing-value-type-parameters--csharp-programming-guide-.md)  
  
-   [Passing Reference-Type Parameters](../classes-and-structs/passing-reference-type-parameters--csharp-programming-guide-.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)