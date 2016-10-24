---
title: "Pointer Comparison (C# Programming Guide)"
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
  - "pointers [C#], comparison"
ms.assetid: fcafd514-7405-4deb-8490-cc58efda5495
caps.latest.revision: 14
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
# Pointer Comparison (C# Programming Guide)
You can apply the following operators to compare pointers of any type:  
  
 **==   !=   \<   >   \<=   >=**  
  
 The comparison operators compare the addresses of the two operands as if they are unsigned integers.  
  
## Example  
 [!code[csProgGuidePointers#16](../unsafe-code-pointers/codesnippet/CSharp/pointer-comparison--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#17](../unsafe-code-pointers/codesnippet/CSharp/pointer-comparison--csharp-programming-guide-_2.cs)]  
  
## Sample Output  
 `True`  
  
 `False`  
  
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