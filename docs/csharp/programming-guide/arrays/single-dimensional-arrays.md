---
title: "Single-Dimensional Arrays (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "single-dimensional arrays [C#]"
  - "arrays [C#], single-dimensional"
ms.assetid: 2cec1196-1de0-49d2-baf2-c607c33310e8
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# Single-Dimensional Arrays (C# Programming Guide)
You can declare a single-dimensional array of five integers as shown in the following example:  
  
 [!code-csharp[csProgGuideArrays#4](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_1.cs)]  
  
 This array contains the elements from `array[0]` to `array[4]`. The [new](../../../csharp/language-reference/keywords/new.md) operator is used to create the array and initialize the array elements to their default values. In this example, all the array elements are initialized to zero.  
  
 An array that stores string elements can be declared in the same way. For example:  
  
 [!code-csharp[csProgGuideArrays#5](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_2.cs)]  
  
## Array Initialization  
 It is possible to initialize an array upon declaration, in which case, the rank specifier is not needed because it is already supplied by the number of elements in the initialization list. For example:  
  
 [!code-csharp[csProgGuideArrays#6](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_3.cs)]  
  
 A string array can be initialized in the same way. The following is a declaration of a string array where each array element is initialized by a name of a day:  
  
 [!code-csharp[csProgGuideArrays#7](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_4.cs)]  
  
 When you initialize an array upon declaration, you can use the following shortcuts:  
  
 [!code-csharp[csProgGuideArrays#8](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_5.cs)]  
  
 It is possible to declare an array variable without initialization, but you must use the `new` operator when you assign an array to this variable. For example:  
  
 [!code-csharp[csProgGuideArrays#9](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_6.cs)]  
  
 C# 3.0 introduces implicitly typed arrays. For more information, see [Implicitly Typed Arrays](../../../csharp/programming-guide/arrays/implicitly-typed-arrays.md).  
  
## Value Type and Reference Type Arrays  
 Consider the following array declaration:  
  
 [!code-csharp[csProgGuideArrays#10](../../../csharp/programming-guide/arrays/codesnippet/CSharp/single-dimensional-arrays_7.cs)]  
  
 The result of this statement depends on whether `SomeType` is a value type or a reference type. If it is a value type, the statement creates an array of 10 elements, each of which has the type `SomeType`. If `SomeType` is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference.  
  
 For more information about value types and reference types, see [Types](../../../csharp/language-reference/keywords/types.md).  
  
## See Also  
 <xref:System.Array>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Arrays](../../../csharp/programming-guide/arrays/index.md)  
 [Multidimensional Arrays](../../../csharp/programming-guide/arrays/multidimensional-arrays.md)  
 [Jagged Arrays](../../../csharp/programming-guide/arrays/jagged-arrays.md)
