---
title: "How to: Obtain the Address of a Variable (C# Programming Guide)"
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
  - "variables [C#], address of"
  - "pointers [C#], & operator"
  - "pointer expressions [C#], address-of operator"
ms.assetid: 44fe2cd9-a64f-4ef5-be2a-09ce807c0182
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
# How to: Obtain the Address of a Variable (C# Programming Guide)
To obtain the address of a unary expression, which evaluates to a fixed variable, use the address-of operator:  
  
```  
int number;  
int* p = &number; //address-of operator &  
```  
  
 The address-of operator can only be applied to a variable. If the variable is a moveable variable, you can use the [fixed statement](../keywords/fixed-statement--csharp-reference-.md) to temporarily fix the variable before obtaining its address.  
  
 It is your responsibility to ensure that the variable is initialized. The compiler will not issue an error message if the variable is not initialized.  
  
 You cannot get the address of a constant or a value.  
  
## Example  
 In this example, a pointer to `int`, `p`, is declared and assigned the address of an integer variable, `number`. The variable `number` is initialized as a result of the assignment to *p. If you make this assignment statement a comment, the initialization of the variable `number` will be removed, but no compile-time error is issued. Notice the use of the [Member Access](../unsafe-code-pointers/how-to--access-a-member-with-a-pointer--csharp-programming-guide-.md) operator `->` to obtain and display the address stored in the pointer.  
  
 [!code[csProgGuidePointers#7](../unsafe-code-pointers/codesnippet/CSharp/how-to--obtain-the-address-of-a-variable--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#8](../unsafe-code-pointers/codesnippet/CSharp/how-to--obtain-the-address-of-a-variable--csharp-programming-guide-_2.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)