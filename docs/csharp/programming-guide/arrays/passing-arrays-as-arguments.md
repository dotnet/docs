---
title: "Passing Arrays as Arguments (C# Programming Guide)"
ms.date: 07/05/2018
helpviewer_keywords: 
  - "arrays [C#], passing as arguments"
ms.assetid: f3a0971e-c87c-4a1f-8262-bc0a3b712772
---
# Passing Arrays as Arguments (C# Programming Guide)
Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.  
  
## Passing Single-Dimensional Arrays As Arguments  
 You can pass an initialized single-dimensional array to a method. For example, the following statement sends an array to a print method.  
  
 [!code-csharp[csProgGuideArrays#34](codesnippet/CSharp/passing-arrays-as-arguments_1.cs)]  
  
 The following code shows a partial implementation of the print method.  
  
 [!code-csharp[csProgGuideArrays#33](codesnippet/CSharp/passing-arrays-as-arguments_2.cs)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code-csharp[CsProgGuideArrays#35](codesnippet/CSharp/passing-arrays-as-arguments_3.cs)]  
  
## Example  
  
### Description  
 In the following example, an array of strings is initialized and passed as an argument to a `DisplayArray` method for strings. The method displays the elements of the array. Next, the `ChangeArray` method reverses the array elements, and then the `ChangeArrayElements` method modifies the first three elements of the array. After each method returns, the `DisplayArray` method shows that passing an array by value does not prevent changes to the array elements.
  
### Code  
 [!code-csharp[csProgGuideArrays#30](codesnippet/CSharp/passing-arrays-as-arguments_4.cs)]  
  
## Passing Multidimensional Arrays As Arguments  
 You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array.  
  
 [!code-csharp[csProgGuideArrays#41](codesnippet/CSharp/passing-arrays-as-arguments_5.cs)]  
  
 The following code shows a partial declaration of a print method that accepts a two-dimensional array as its argument.  
  
 [!code-csharp[csProgGuideArrays#36](codesnippet/CSharp/passing-arrays-as-arguments_6.cs)]  
  
 You can initialize and pass a new array in one step, as is shown in the following example.  
  
 [!code-csharp[csProgGuideArrays#32](codesnippet/CSharp/passing-arrays-as-arguments_7.cs)]  
  
## Example  
  
### Description  
 In the following example, a two-dimensional array of integers is initialized and passed to the `Print2DArray` method. The method displays the elements of the array.  
  
### Code  
 [!code-csharp[csProgGuideArrays#31](codesnippet/CSharp/passing-arrays-as-arguments_8.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Arrays](index.md)  
 [Single-Dimensional Arrays](single-dimensional-arrays.md)  
 [Multidimensional Arrays](multidimensional-arrays.md)  
 [Jagged Arrays](jagged-arrays.md)
