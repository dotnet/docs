---
title: "Generics and Arrays - C# Programming Guide"
description: Learn about generics and arrays in C# programming. See code examples and view additional available resources.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "generics [C#], arrays"
  - "arrays [C#], generics"
ms.assetid: 7d956536-3851-41b5-94ad-3e7c0a5fe485
---
# Generics and Arrays (C# Programming Guide)

In C# 2.0 and later, single-dimensional arrays that have a lower bound of zero automatically implement <xref:System.Collections.Generic.IList%601>. This enables you to create generic methods that can use the same code to iterate through arrays and other collection types. This technique is primarily useful for reading data in collections. The <xref:System.Collections.Generic.IList%601> interface cannot be used to add or remove elements from an array. An exception will be thrown if you try to call an <xref:System.Collections.Generic.IList%601> method such as <xref:System.Collections.Generic.IList%601.RemoveAt%2A> on an array in this context.  
  
 The following code example demonstrates how a single generic method that takes an <xref:System.Collections.Generic.IList%601> input parameter can iterate through both a list and an array, in this case an array of integers.  
  
 [!code-csharp[csProgGuideGenerics#35](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#35)]  
  
## See also

- <xref:System.Collections.Generic>
- [C# Programming Guide](../index.md)
- [Generics](../../fundamentals/types/generics.md)
- [Arrays](../arrays/index.md)
- [Generics](../../../standard/generics/index.md)
