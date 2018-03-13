---
title: "Passing Arrays Using ref and out (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "arrays [C#], passing using ref and out"
ms.assetid: 6a2b261e-a1cc-49a6-b4f0-6cacae385a1e
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# Passing Arrays Using ref and out (C# Programming Guide)
Like all [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameters, an `out` parameter of an array type must be assigned before it is used; that is, it must be assigned by the callee. For example:  
  
 [!code-csharp[csProgGuideArrays#39](../../../csharp/programming-guide/arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out_1.cs)]  
  
 Like all [ref](../../../csharp/language-reference/keywords/ref.md) parameters, a `ref` parameter of an array type must be definitely assigned by the caller. Therefore, there is no need to be definitely assigned by the callee. A `ref` parameter of an array type may be altered as a result of the call. For example, the array can be assigned the [null](../../../csharp/language-reference/keywords/null.md) value or can be initialized to a different array. For example:  
  
 [!code-csharp[csProgGuideArrays#40](../../../csharp/programming-guide/arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out_2.cs)]  
  
 The following two examples demonstrate the difference between `out` and `ref` when used in passing arrays to methods.  
  
## Example  
 In this example, the array `theArray` is declared in the caller (the `Main` method), and initialized in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code-csharp[csProgGuideArrays#37](../../../csharp/programming-guide/arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out_3.cs)]  
  
## Example  
 In this example, the array `theArray` is initialized in the caller (the `Main` method), and passed to the `FillArray` method by using the `ref` parameter. Some of the array elements are updated in the `FillArray` method. Then, the array elements are returned to the caller and displayed.  
  
 [!code-csharp[csProgGuideArrays#38](../../../csharp/programming-guide/arrays/codesnippet/CSharp/passing-arrays-using-ref-and-out_4.cs)]  
  
## See Also  
 [ref](../../../csharp/language-reference/keywords/ref.md)  
 [out parameter modifier](../../../csharp/language-reference/keywords/out-parameter-modifier.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Arrays](../../../csharp/programming-guide/arrays/index.md)  
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)  
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)  
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)
