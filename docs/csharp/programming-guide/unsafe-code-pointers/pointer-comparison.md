---
title: "Pointer Comparison (C# Programming Guide) | Microsoft Docs"
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
---
# Pointer Comparison (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

You can apply the following operators to compare pointers of any type:  
  
 **==   !=   \<   >   \<=   >=**  
  
 The comparison operators compare the addresses of the two operands as if they are unsigned integers.  
  
## Example  
 [!code-csharp[csProgGuidePointers#16](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers2.cs#16)]  
  
 [!code-csharp[csProgGuidePointers#17](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#17)]  
  
## Sample Output  
 `True`  
  
 `False`  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [Manipulating Pointers](../../../csharp/programming-guide/unsafe-code-pointers/manipulating-pointers.md)   
 [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)   
 [Types](../../../csharp/language-reference/keywords/types.md)   
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)   
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)   
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)