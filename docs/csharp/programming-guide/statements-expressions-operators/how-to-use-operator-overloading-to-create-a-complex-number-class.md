---
title: "How to: Use Operator Overloading to Create a Complex Number Class (C# Programming Guide) | Microsoft Docs"
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
  - "complex numbers [C#]"
  - "classes [C#], operator overloading"
  - "operator overloading [C#], complex numbers"
  - "operator overloading [C#], using to create classes"
  - "operators [C#], overloading to create a complex number class"
ms.assetid: c9b8d982-5112-413f-bae3-b42ae3248ddf
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Use Operator Overloading to Create a Complex Number Class (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This example shows how you can use operator overloading to create a complex number class `Complex` that defines complex addition. The program displays the imaginary and the real parts of the numbers and the addition result using an override of the `ToString` method.  
  
## Example  
 [!code-csharp[csProgGuideStatements#16](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#16)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [operator (C# Reference)](../../../csharp/language-reference/keywords/operator-csharp-reference.md)   
 [Why are overloaded operators always static in C#?](http://go.microsoft.com/fwlink/?LinkId=112383)