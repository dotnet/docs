---
title: "Passing Arrays Using ref and out (C# Programming Guide)"
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
# Passing Arrays Using ref and out (C# Programming Guide)
Like all [out](../keywords/out--csharp-reference-.md) parameters, an `out` parameter of an array type must be assigned before it is used; that is, it must be assigned by the callee. For example:  
  
 [!code[csProgGuideArrays#39](../arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out--csharp-programming-guide-_1.cs)]  
  
 Like all [ref](../keywords/ref--csharp-reference-.md) parameters, a `ref` parameter of an array type must be definitely assigned by the caller. Therefore, there is no need to be definitely assigned by the callee. A `ref` parameter of an array type may be altered as a result of the call. For example, the array can be assigned the [null](../keywords/null--csharp-reference-.md) value or can be initialized to a different array. For example:  
  
 [!code[csProgGuideArrays#40](../arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out--csharp-programming-guide-_2.cs)]  
  
 The following two examples demonstrate the difference between `out` and `ref` when used in passing arrays to methods.  
  
## Example  
 In this example, the array `theArray` is declared in the caller (the `Main` method), and initialized in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code[csProgGuideArrays#37](../arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out--csharp-programming-guide-_3.cs)]  
  
## Example  
 In this example, the array `theArray` is initialized in the caller (the `Main` method), and passed to the `FillArray` method by using the `ref` parameter. Some of the array elements are updated in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code[csProgGuideArrays#38](../arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out--csharp-programming-guide-_4.cs)]  
  
## See Also  
 [ref](../keywords/ref--csharp-reference-.md)   
 [out parameter modifier](../keywords/out-parameter-modifier--csharp-reference-.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Single-Dimensional Arrays](../arrays/single-dimensional-arrays--csharp-programming-guide-.md)   
 [Multidimensional Arrays](../arrays/multidimensional-arrays--csharp-programming-guide-.md)   
 [Jagged Arrays](../arrays/jagged-arrays--csharp-programming-guide-.md)