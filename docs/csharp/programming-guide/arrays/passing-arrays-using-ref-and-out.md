---
title: "Passing Arrays Using ref and out (C# Programming Guide) | Microsoft Docs"
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
  - "arrays [C#], passing using ref and out"
ms.assetid: 6a2b261e-a1cc-49a6-b4f0-6cacae385a1e
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Passing Arrays Using ref and out (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Like all [out](../../../csharp/language-reference/keywords/out.md) parameters, an `out` parameter of an array type must be assigned before it is used; that is, it must be assigned by the callee. For example:  
  
 [!code-csharp[csProgGuideArrays#39](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#39)]  
  
 Like all [ref](../../../csharp/language-reference/keywords/ref.md) parameters, a `ref` parameter of an array type must be definitely assigned by the caller. Therefore, there is no need to be definitely assigned by the callee. A `ref` parameter of an array type may be altered as a result of the call. For example, the array can be assigned the [null](../../../csharp/language-reference/keywords/null.md) value or can be initialized to a different array. For example:  
  
 [!code-csharp[csProgGuideArrays#40](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#40)]  
  
 The following two examples demonstrate the difference between `out` and `ref` when used in passing arrays to methods.  
  
## Example  
 In this example, the array `theArray` is declared in the caller (the `Main` method), and initialized in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code-csharp[csProgGuideArrays#37](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#37)]  
  
## Example  
 In this example, the array `theArray` is initialized in the caller (the `Main` method), and passed to the `FillArray` method by using the `ref` parameter. Some of the array elements are updated in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code-csharp[csProgGuideArrays#38](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#38)]  
  
## See Also  
 [ref](../../../csharp/language-reference/keywords/ref.md)   
 [out parameter modifier](../../../csharp/language-reference/keywords/out-parameter-modifier.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Arrays](../../../csharp/programming-guide/arrays/index.md)   
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)   
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)   
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)