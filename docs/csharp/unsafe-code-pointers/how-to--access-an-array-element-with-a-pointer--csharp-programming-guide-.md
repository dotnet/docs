---
title: "How to: Access an Array Element with a Pointer (C# Programming Guide)"
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
  - "pointers [C#], array access"
ms.assetid: 6c46f2af-a730-4855-8638-f136d9abaa12
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
# How to: Access an Array Element with a Pointer (C# Programming Guide)
In an unsafe context, you can access an element in memory by using pointer element access, as shown in the following example:  
  
```  
 char* charPointer = stackalloc char[123];  
for (int i = 65; i < 123; i++)  
{  
    charPointer[i] = (char)i; //access array elements  
}  
```  
  
 The expression in square brackets must be implicitly convertible to `int`, `uint`, `long`, or `ulong`. The operation p[e] is equivalent to *(p+e). Like C and C++, the pointer element access does not check for out-of-bounds errors.  
  
## Example  
 In this example, 123 memory locations are allocated to a character array, `charPointer`. The array is used to display the lowercase letters and the uppercase letters in two [for](../keywords/for--csharp-reference-.md) loops.  
  
 Notice that the expression `charPointer[i]` is equivalent to the expression `*(charPointer + i)`, and you can obtain the same result by using either of the two expressions.  
  
 [!code[csProgGuidePointers#11](../unsafe-code-pointers/codesnippet/CSharp/how-to--access-an-array-element-with-a-pointer--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#12](../unsafe-code-pointers/codesnippet/CSharp/how-to--access-an-array-element-with-a-pointer--csharp-programming-guide-_2.cs)]  
  
 **Uppercase letters:**  
**ABCDEFGHIJKLMNOPQRSTUVWXYZ**  
**Lowercase letters:**  
**abcdefghijklmnopqrstuvwxyz**   
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)