---
title: "Arrays as Objects (C# Programming Guide)"
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
  - "arrays [C#], as objects"
ms.assetid: f76d4403-bd0a-42a0-9bc8-694c55b2c926
caps.latest.revision: 17
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
# Arrays as Objects (C# Programming Guide)
In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++. <xref:System.Array> is the abstract base type of all array types. You can use the properties, and other class members, that <xref:System.Array> has. An example of this would be using the <xref:System.Array.Length*> property to get the length of an array. The following code assigns the length of the `numbers` array, which is `5`, to a variable called `lengthOfNumbers`:  
  
 [!code[csProgGuideArrays#3](../arrays/codesnippet/CSharp/arrays-as-objects--csharp-programming-guide-_1.cs)]  
  
 The <xref:System.Array> class provides many other useful methods and properties for sorting, searching, and copying arrays.  
  
## Example  
 This example uses the <xref:System.Array.Rank*> property to display the number of dimensions of an array.  
  
 [!code[csProgGuideArrays#2](../arrays/codesnippet/CSharp/arrays-as-objects--csharp-programming-guide-_2.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Single-Dimensional Arrays](../arrays/single-dimensional-arrays--csharp-programming-guide-.md)   
 [Multidimensional Arrays](../arrays/multidimensional-arrays--csharp-programming-guide-.md)   
 [Jagged Arrays](../arrays/jagged-arrays--csharp-programming-guide-.md)