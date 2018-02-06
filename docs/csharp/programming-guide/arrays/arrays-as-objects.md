---
title: "Arrays as Objects (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "arrays [C#], as objects"
ms.assetid: f76d4403-bd0a-42a0-9bc8-694c55b2c926
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# Arrays as Objects (C# Programming Guide)
In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++. <xref:System.Array> is the abstract base type of all array types. You can use the properties, and other class members, that <xref:System.Array> has. An example of this would be using the <xref:System.Array.Length%2A> property to get the length of an array. The following code assigns the length of the `numbers` array, which is `5`, to a variable called `lengthOfNumbers`:  
  
 [!code-csharp[csProgGuideArrays#3](../../../csharp/programming-guide/arrays/codesnippet/CSharp/arrays-as-objects_1.cs)]  
  
 The <xref:System.Array> class provides many other useful methods and properties for sorting, searching, and copying arrays.  
  
## Example  
 This example uses the <xref:System.Array.Rank%2A> property to display the number of dimensions of an array.  
  
 [!code-csharp[csProgGuideArrays#2](../../../csharp/programming-guide/arrays/codesnippet/CSharp/arrays-as-objects_2.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Arrays](../../../csharp/programming-guide/arrays/index.md)  
 [Single-Dimensional Arrays](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md)  
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)  
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)
