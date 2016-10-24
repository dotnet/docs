---
title: "How to: Access a Member with a Pointer (C# Programming Guide)"
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
  - "pointers [C#], member access"
ms.assetid: 1e998498-8c85-4a78-8ce2-4d8c20f08342
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
# How to: Access a Member with a Pointer (C# Programming Guide)
To access a member of a struct that is declared in an unsafe context, you can use the member access operator as shown in the following example in which `p` is a pointer to a [struct](../keywords/struct--csharp-reference-.md) that contains a member `x`.  
  
```  
CoOrds* p = &home;  
p -> x = 25; //member access operator ->  
```  
  
## Example  
 In this example, a [struct](../keywords/struct--csharp-reference-.md), `CoOrds`, that contains the two coordinates `x` and `y` is declared and instantiated. By using the member access operator `->` and a pointer to the instance `home`, `x` and `y` are assigned values.  
  
> [!NOTE]
>  Notice that the expression `p->x` is equivalent to the expression `(*p).x`, and you can obtain the same result by using either of the two expressions.  
  
 [!code[csProgGuidePointers#9](../unsafe-code-pointers/codesnippet/CSharp/how-to--access-a-member-with-a-pointer--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#10](../unsafe-code-pointers/codesnippet/CSharp/how-to--access-a-member-with-a-pointer--csharp-programming-guide-_2.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)