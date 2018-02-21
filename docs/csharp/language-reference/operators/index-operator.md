---
title: "[] Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "[]_CSharpKeyword"
helpviewer_keywords: 
  - "subscript operator [C#]"
  - "square brackets [ ] operator [C#]"
  - "[] operator [C#]"
  - "indexing operator [C#]"
ms.assetid: 5c16bb45-88f7-45ff-b42c-1af1972b042c
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# [] Operator (C# Reference)
Square brackets (`[]`) are used for arrays, indexers, and attributes. They can also be used with pointers.  
  
## Remarks  
 An array type is a type followed by `[]`:  
  
 [!code-csharp[csRefOperators#43](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_1.cs)]  
  
 To access an element of an array, the index of the desired element is enclosed in brackets:  
  
 [!code-csharp[csRefOperators#44](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_2.cs)]  
  
 An exception is thrown if an array index is out of range.  
  
 The array indexing operator cannot be overloaded; however, types can define indexers, and properties that take one or more parameters. Indexer parameters are enclosed in square brackets, just like array indexes, but indexer parameters can be declared to be of any type, unlike array indexes, which must be integral.  
  
 For example, the .NET Framework defines a `Hashtable` type that associates keys and values of arbitrary type:  
  
 [!code-csharp[csRefOperators#45](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_3.cs)]  
  
 Square brackets are also used to specify [Attributes](../../../csharp/programming-guide/concepts/attributes/index.md):  
  
 [!code-csharp[csRefOperators#46](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_4.cs)]  
  
 You can use square brackets to index off a pointer:  
  
 [!code-csharp[csRefOperators#47](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_5.cs)]  
  
 No bounds checking is performed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [Arrays](../../../csharp/programming-guide/arrays/index.md)  
 [Indexers](../../../csharp/programming-guide/indexers/index.md)  
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)
