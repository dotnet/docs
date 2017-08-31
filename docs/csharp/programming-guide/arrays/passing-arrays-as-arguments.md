---
title: "Passing Arrays as Arguments (C# Programming Guide) | Microsoft Docs"
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
  - "arrays [C#], passing as arguments"
ms.assetid: f3a0971e-c87c-4a1f-8262-bc0a3b712772
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Passing Arrays as Arguments (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.  
  
## Passing Single-Dimensional Arrays As Arguments  
 You can pass an initialized single-dimensional array to a method. For example, the following statement sends an array to a print method.  
  
 [!code-csharp[csProgGuideArrays#34](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#34)]  
  
 The following code shows a partial implementation of the print method.  
  
 [!code-csharp[csProgGuideArrays#33](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#33)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code-csharp[CsProgGuideArrays#35](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#35)]  
  
## Example  
  
### Description  
 In the following example, an array of strings is initialized and passed as an argument to a `PrintArray` method for strings. The method displays the elements of the array. Next, methods `ChangeArray` and `ChangeArrayElement` are called to demonstrate that sending an array argument by value does not prevent changes to the array elements.  
  
### Code  
 [!code-csharp[csProgGuideArrays#30](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#30)]  
  
## Passing Multidimensional Arrays As Arguments  
 You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array.  
  
 [!code-csharp[csProgGuideArrays#41](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#41)]  
  
 The following code shows a partial declaration of a print method that accepts a two-dimensional array as its argument.  
  
 [!code-csharp[csProgGuideArrays#36](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#36)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code-csharp[csProgGuideArrays#32](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#32)]  
  
## Example  
  
### Description  
 In the following example, a two-dimensional array of integers is initialized and passed to the `Print2DArray` method. The method displays the elements of the array.  
  
### Code  
 [!code-csharp[csProgGuideArrays#31](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#31)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Arrays](../../../csharp/programming-guide/arrays/index.md)   
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)   
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)   
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)