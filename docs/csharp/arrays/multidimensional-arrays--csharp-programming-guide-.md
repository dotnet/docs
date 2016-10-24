---
title: "Multidimensional Arrays (C# Programming Guide)"
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
# Multidimensional Arrays (C# Programming Guide)
Arrays can have more than one dimension. For example, the following declaration creates a two-dimensional array of four rows and two columns.  
  
 [!code[csProgGuideArrays#11](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_1.cs)]  
  
 The following declaration creates an array of three dimensions, 4, 2, and 3.  
  
 [!code[csProgGuideArrays#12](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_2.cs)]  
  
## Array Initialization  
 You can initialize the array upon declaration, as is shown in the following example.  
  
 [!code[csProgGuideArrays#13](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_3.cs)]  
  
 You also can initialize the array without specifying the rank.  
  
 [!code[csProgGuideArrays#14](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_4.cs)]  
  
 If you choose to declare an array variable without initialization, you must use the `new` operator to assign an array to the variable. The use of `new` is shown in the following example.  
  
 [!code[csProgGuideArrays#15](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_5.cs)]  
  
 The following example assigns a value to a particular array element.  
  
 [!code[csProgGuideArrays#16](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_6.cs)]  
  
 Similarly, the following example gets the value of a particular array element and assigns it to variable `elementValue`.  
  
 [!code[csProgGuideArrays#42](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_7.cs)]  
  
 The following code example initializes the array elements to default values (except for jagged arrays).  
  
 [!code[csProgGuideArrays#17](../arrays/codesnippet/CSharp/multidimensional-arrays--csharp-programming-guide-_8.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Single-Dimensional Arrays](../arrays/single-dimensional-arrays--csharp-programming-guide-.md)   
 [Jagged Arrays](../arrays/jagged-arrays--csharp-programming-guide-.md)