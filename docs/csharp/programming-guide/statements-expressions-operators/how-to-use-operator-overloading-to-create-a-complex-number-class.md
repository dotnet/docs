---
title: "How to: Use Operator Overloading to Create a Complex Number Class (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "complex numbers [C#]"
  - "classes [C#], operator overloading"
  - "operator overloading [C#], complex numbers"
  - "operator overloading [C#], using to create classes"
  - "operators [C#], overloading to create a complex number class"
ms.assetid: c9b8d982-5112-413f-bae3-b42ae3248ddf
caps.latest.revision: 15
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
# How to: Use Operator Overloading to Create a Complex Number Class (C# Programming Guide)
This example shows how you can use operator overloading to create a complex number class `Complex` that defines complex addition. The program displays the imaginary and the real parts of the numbers and the addition result using an override of the `ToString` method.  
  
## Example  
 [!code-cs[csProgGuideStatements#16](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-operator-overloading-to-create-a-complex-number-class_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [operator (C# Reference)](../../../csharp/language-reference/keywords/operator.md)   
 [Why are overloaded operators always static in C#?](http://go.microsoft.com/fwlink/?LinkId=112383)