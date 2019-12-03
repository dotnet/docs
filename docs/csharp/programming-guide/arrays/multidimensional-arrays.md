---
title: "Multidimensional Arrays - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "arrays [C#], multidimensional"
  - "multidimensional arrays [C#]"
ms.assetid: 020ce02e-7dff-4273-8e53-bf0b33747232
---
# Multidimensional Arrays (C# Programming Guide)

Arrays can have more than one dimension. For example, the following declaration creates a two-dimensional array of four rows and two columns.  
  
 [!code-csharp[csProgGuideArrays#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#11)]  
  
 The following declaration creates an array of three dimensions, 4, 2, and 3.  
  
 [!code-csharp[csProgGuideArrays#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#12)]  
  
## Array Initialization

 You can initialize the array upon declaration, as is shown in the following example.  
  
 [!code-csharp[csProgGuideArrays#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#13)]  
  
 You also can initialize the array without specifying the rank.  
  
 [!code-csharp[csProgGuideArrays#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#14)]  
  
 If you choose to declare an array variable without initialization, you must use the `new` operator to assign an array to the variable. The use of `new` is shown in the following example.  
  
 [!code-csharp[csProgGuideArrays#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#15)]  
  
 The following example assigns a value to a particular array element.  
  
 [!code-csharp[csProgGuideArrays#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#16)]  
  
 Similarly, the following example gets the value of a particular array element and assigns it to variable `elementValue`.  
  
 [!code-csharp[csProgGuideArrays#42](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#42)]  
  
 The following code example initializes the array elements to default values (except for jagged arrays).  
  
 [!code-csharp[csProgGuideArrays#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#17)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Arrays](./index.md)
- [Single-Dimensional Arrays](./single-dimensional-arrays.md)
- [Jagged Arrays](./jagged-arrays.md)
