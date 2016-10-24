---
title: "How to: Obtain the Value of a Pointer Variable (C# Programming Guide)"
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
  - "pointer expressions [C#], indirection"
  - "pointers [C#], indirection"
  - "variables [C#], pointers"
  - "pointers [C#], * operator"
ms.assetid: 460a813a-4995-44c1-9de2-213b91dc7668
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
# How to: Obtain the Value of a Pointer Variable (C# Programming Guide)
Use the pointer indirection operator to obtain the variable at the location pointed to by a pointer. The expression takes the following form, where `p` is a pointer type:  
  
```  
*p;  
```  
  
 You cannot use the unary indirection operator on an expression of any type other than the pointer type. Also, you cannot apply it to a [void](../keywords/void--csharp-reference-.md) pointer.  
  
 When you apply the indirection operator to a [null](../keywords/null--csharp-reference-.md) pointer, the result depends on the implementation.  
  
## Example  
 In the following example, a variable of the type `char` is accessed by using pointers of different types. Note that the address of `theChar` will vary from run to run, because the physical address allocated to a variable can change.  
  
 [!code[csProgGuidePointers#5](../unsafe-code-pointers/codesnippet/CSharp/how-to--obtain-the-value-of-a-pointer-variable--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#6](../unsafe-code-pointers/codesnippet/CSharp/how-to--obtain-the-value-of-a-pointer-variable--csharp-programming-guide-_2.cs)]  
  
 **Value of theChar = Z**   
**Address of theChar = 12F718**  
**Value of pChar = Z**   
**Value of pInt = 90**    
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)