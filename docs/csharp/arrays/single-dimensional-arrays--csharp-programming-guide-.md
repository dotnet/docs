---
title: "Single-Dimensional Arrays (C# Programming Guide)"
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
  - "single-dimensional arrays [C#]"
  - "arrays [C#], single-dimensional"
ms.assetid: 2cec1196-1de0-49d2-baf2-c607c33310e8
caps.latest.revision: 18
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
# Single-Dimensional Arrays (C# Programming Guide)
You can declare a single-dimensional array of five integers as shown in the following example:  
  
 [!code[csProgGuideArrays#4](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_1.cs)]  
  
 This array contains the elements from `array[0]` to `array[4]`. The [new](../keywords/new--csharp-reference-.md) operator is used to create the array and initialize the array elements to their default values. In this example, all the array elements are initialized to zero.  
  
 An array that stores string elements can be declared in the same way. For example:  
  
 [!code[csProgGuideArrays#5](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_2.cs)]  
  
## Array Initialization  
 It is possible to initialize an array upon declaration, in which case, the rank specifier is not needed because it is already supplied by the number of elements in the initialization list. For example:  
  
 [!code[csProgGuideArrays#6](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_3.cs)]  
  
 A string array can be initialized in the same way. The following is a declaration of a string array where each array element is initialized by a name of a day:  
  
 [!code[csProgGuideArrays#7](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_4.cs)]  
  
 When you initialize an array upon declaration, you can use the following shortcuts:  
  
 [!code[csProgGuideArrays#8](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_5.cs)]  
  
 It is possible to declare an array variable without initialization, but you must use the `new` operator when you assign an array to this variable. For example:  
  
 [!code[csProgGuideArrays#9](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_6.cs)]  
  
 C# 3.0 introduces implicitly typed arrays. For more information, see [Implicitly Typed Arrays](../arrays/implicitly-typed-arrays--csharp-programming-guide-.md).  
  
## Value Type and Reference Type Arrays  
 Consider the following array declaration:  
  
 [!code[csProgGuideArrays#10](../arrays/codesnippet/CSharp/single-dimensional-arrays--csharp-programming-guide-_7.cs)]  
  
 The result of this statement depends on whether `SomeType` is a value type or a reference type. If it is a value type, the statement creates an array of 10 elements, each of which has the type `SomeType`. If `SomeType` is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference.  
  
 For more information about value types and reference types, see [Types](../keywords/types--csharp-reference-.md).  
  
## See Also  
 <xref:System.Array>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Multidimensional Arrays](../arrays/multidimensional-arrays--csharp-programming-guide-.md)   
 [Jagged Arrays](../arrays/jagged-arrays--csharp-programming-guide-.md)