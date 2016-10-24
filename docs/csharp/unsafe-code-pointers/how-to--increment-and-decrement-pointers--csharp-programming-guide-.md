---
title: "How to: Increment and Decrement Pointers (C# Programming Guide)"
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
  - "pointers [C#], increment and decrement"
  - "pointer expressions [C#], increment and decrement"
ms.assetid: 1b8b9281-44ee-485a-9045-3db38a4b4b89
caps.latest.revision: 20
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
# How to: Increment and Decrement Pointers (C# Programming Guide)
Use the increment and the decrement operators, `++` and `--`, to change the pointer location by [sizeof](../keywords/sizeof--csharp-reference-.md) (`pointer-type`) for a pointer of type pointer-type*. The increment and decrement expressions take the following form:  
  
```  
++p;  
p++;  
--p;  
p--;  
```  
  
 The increment and decrement operators can be applied to pointers of any type except the type `void*`.  
  
 The effect of applying the increment operator to a pointer of the type `pointer-type` is to add [sizeof](../keywords/sizeof--csharp-reference-.md) (`pointer-type`) to the address that is contained in the pointer variable.  
  
 The effect of applying the decrement operator to a pointer of the type `pointer-type` is to subtract `sizeof` (`pointer-type`) from the address that is contained in the pointer variable.  
  
 No exceptions are generated when the operation overflows the domain of the pointer, and the result depends on the implementation.  
  
## Example  
 In this example, you step through an array by incrementing the pointer by the size of `int`. With each step, you display the address and the content of the array element.  
  
 [!code[csProgGuidePointers#3](../unsafe-code-pointers/codesnippet/CSharp/how-to--increment-and-decrement-pointers--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#13](../unsafe-code-pointers/codesnippet/CSharp/how-to--increment-and-decrement-pointers--csharp-programming-guide-_2.cs)]  
  
 **Value:0 @ Address:12860272**  
**Value:1 @ Address:12860276**  
**Value:2 @ Address:12860280**  
**Value:3 @ Address:12860284**  
**Value:4 @ Address:12860288**   
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [Manipulating Pointers](../unsafe-code-pointers/manipulating-pointers--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)