---
title: "Passing Arrays as Arguments (C# Programming Guide)"
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
# Passing Arrays as Arguments (C# Programming Guide)
Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.  
  
## Passing Single-Dimensional Arrays As Arguments  
 You can pass an initialized single-dimensional array to a method. For example, the following statement sends an array to a print method.  
  
 [!code[csProgGuideArrays#34](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_1.cs)]  
  
 The following code shows a partial implementation of the print method.  
  
 [!code[csProgGuideArrays#33](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_2.cs)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code[CsProgGuideArrays#35](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_3.cs)]  
  
## Example  
  
### Description  
 In the following example, an array of strings is initialized and passed as an argument to a `PrintArray` method for strings. The method displays the elements of the array. Next, methods `ChangeArray` and `ChangeArrayElement` are called to demonstrate that sending an array argument by value does not prevent changes to the array elements.  
  
### Code  
 [!code[csProgGuideArrays#30](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_4.cs)]  
  
## Passing Multidimensional Arrays As Arguments  
 You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array.  
  
 [!code[csProgGuideArrays#41](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_5.cs)]  
  
 The following code shows a partial declaration of a print method that accepts a two-dimensional array as its argument.  
  
 [!code[csProgGuideArrays#36](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_6.cs)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code[csProgGuideArrays#32](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_7.cs)]  
  
## Example  
  
### Description  
 In the following example, a two-dimensional array of integers is initialized and passed to the `Print2DArray` method. The method displays the elements of the array.  
  
### Code  
 [!code[csProgGuideArrays#31](../arrays/codesnippet/CSharp/passing-arrays-as-arguments--csharp-programming-guide-_8.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Single-Dimensional Arrays](../arrays/single-dimensional-arrays--csharp-programming-guide-.md)   
 [Multidimensional Arrays](../arrays/multidimensional-arrays--csharp-programming-guide-.md)   
 [Jagged Arrays](../arrays/jagged-arrays--csharp-programming-guide-.md)