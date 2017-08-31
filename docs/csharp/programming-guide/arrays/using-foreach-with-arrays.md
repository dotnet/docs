---
title: "Using foreach with Arrays (C# Programming Guide) | Microsoft Docs"
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
  - "arrays [C#], foreach"
  - "foreach statement [C#], using with arrays"
ms.assetid: 5f2da2a9-1f56-4de5-94cc-e07f4f7a0244
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Using foreach with Arrays (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

C# also provides the [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statement. This statement provides a simple, clean way to iterate through the elements of an array or any enumerable collection. The `foreach` statement processes elements in the order returned by the array or collection type’s enumerator, which is usually from the 0th element to the last. For example, the following code creates an array called `numbers` and iterates through it with the `foreach` statement:  
  
 [!code-csharp[csProgGuideArrays#28](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#28)]  
  
 With multidimensional arrays, you can use the same method to iterate through the elements, for example:  
  
 [!code-csharp[csProgGuideArrays#29](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#29)]  
  
 However, with multidimensional arrays, using a nested [for](../../../csharp/language-reference/keywords/for.md) loop gives you more control over the array elements.  
  
## See Also  
 <xref:System.Array>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Arrays](../../../csharp/programming-guide/arrays/index.md)   
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)   
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)   
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)