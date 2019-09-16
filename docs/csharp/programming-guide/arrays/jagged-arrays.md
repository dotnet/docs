---
title: "Jagged Arrays - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "jagged arrays [C#]"
  - "arrays [C#], jagged"
ms.assetid: 537c65a6-0e0a-4a00-a2b8-086f38519c70
---
# Jagged Arrays (C# Programming Guide)

A jagged array is an array whose elements are arrays. The elements of a jagged array can be of different dimensions and sizes. A jagged array is sometimes called an "array of arrays." The following examples show how to declare, initialize, and access jagged arrays.  
  
 The following is a declaration of a single-dimensional array that has three elements, each of which is a single-dimensional array of integers:  
  
 [!code-csharp[csProgGuideArrays#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#19)]  
  
 Before you can use `jaggedArray`, its elements must be initialized. You can initialize the elements like this:  
  
 [!code-csharp[csProgGuideArrays#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#20)]  
  
 Each of the elements is a single-dimensional array of integers. The first element is an array of 5 integers, the second is an array of 4 integers, and the third is an array of 2 integers.  
  
 It is also possible to use initializers to fill the array elements with values, in which case you do not need the array size. For example:  
  
 [!code-csharp[csProgGuideArrays#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#21)]  
  
 You can also initialize the array upon declaration like this:  
  
 [!code-csharp[csProgGuideArrays#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#22)]  
  
 You can use the following shorthand form. Notice that you cannot omit the `new` operator from the elements initialization because there is no default initialization for the elements:  
  
 [!code-csharp[csProgGuideArrays#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#23)]  
  
 A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to `null`.  
  
 You can access individual array elements like these examples:  
  
 [!code-csharp[csProgGuideArrays#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#24)]  
  
 It is possible to mix jagged and multidimensional arrays. The following is a declaration and initialization of a single-dimensional jagged array that contains three two-dimensional array elements of different sizes. For more information about two-dimensional arrays, see [Multidimensional Arrays](./multidimensional-arrays.md).  
  
 [!code-csharp[csProgGuideArrays#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#25)]  
  
 You can access individual elements as shown in this example, which displays the value of the element `[1,0]` of the first array (value `5`):  
  
 [!code-csharp[csProgGuideArrays#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#26)]  
  
 The method `Length` returns the number of arrays contained in the jagged array. For example, assuming you have declared the previous array, this line:  
  
 [!code-csharp[csProgGuideArrays#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#27)]  
  
 returns a value of 3.  
  
## Example

 This example builds an array whose elements are themselves arrays. Each one of the array elements has a different size.  
  
 [!code-csharp[csProgGuideArrays#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#18)]  
  
## See also

- <xref:System.Array>
- [C# Programming Guide](../index.md)
- [Arrays](./index.md)
- [Single-Dimensional Arrays](./single-dimensional-arrays.md)
- [Multidimensional Arrays](./multidimensional-arrays.md)
