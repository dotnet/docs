---
title: "Multidimensional Arrays (C# Programming Guide) | Microsoft Docs"
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
  - "arrays [C#], multidimensional"
  - "multidimensional arrays [C#]"
ms.assetid: 020ce02e-7dff-4273-8e53-bf0b33747232
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Multidimensional Arrays (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Arrays can have more than one dimension. For example, the following declaration creates a two-dimensional array of four rows and two columns.  
  
 [!code-cs[csProgGuideArrays#11](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_1.cs)]  
  
 The following declaration creates an array of three dimensions, 4, 2, and 3.  
  
 [!code-cs[csProgGuideArrays#12](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_2.cs)]  
  
## Array Initialization  
 You can initialize the array upon declaration, as is shown in the following example.  
  
 [!code-cs[csProgGuideArrays#13](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_3.cs)]  
  
 You also can initialize the array without specifying the rank.  
  
 [!code-cs[csProgGuideArrays#14](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_4.cs)]  
  
 If you choose to declare an array variable without initialization, you must use the `new` operator to assign an array to the variable. The use of `new` is shown in the following example.  
  
 [!code-cs[csProgGuideArrays#15](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_5.cs)]  
  
 The following example assigns a value to a particular array element.  
  
 [!code-cs[csProgGuideArrays#16](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_6.cs)]  
  
 Similarly, the following example gets the value of a particular array element and assigns it to variable `elementValue`.  
  
 [!code-cs[csProgGuideArrays#42](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_7.cs)]  
  
 The following code example initializes the array elements to default values (except for jagged arrays).  
  
 [!code-cs[csProgGuideArrays#17](../../../csharp/programming-guide/arrays/codesnippet/csharp/multidimensional-arrays_8.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Arrays](../../../csharp/programming-guide/arrays/index.md)   
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)   
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)