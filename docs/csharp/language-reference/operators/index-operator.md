---
title: "[] operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "[]_CSharpKeyword"
helpviewer_keywords: 
  - "subscript operator [C#]"
  - "square brackets [ ] operator [C#]"
  - "[] operator [C#]"
  - "indexing operator [C#]"
ms.assetid: 5c16bb45-88f7-45ff-b42c-1af1972b042c
---
# [] operator (C# Reference)

Square brackets (`[]`) are used for arrays, indexers, and attributes. They can also be used with pointers.

## Remarks

An array type is a type followed by `[]`:

[!code-csharp[csRefOperators#43](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#43)]

To access an element of an array, the index of the desired element is enclosed in brackets:

[!code-csharp[csRefOperators#44](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#44)]

An exception is thrown if an array index is out of range.

The array indexing operator cannot be overloaded; however, types can define indexers that take one or more parameters. Indexer parameters are enclosed in square brackets, just like array indexes, but indexer parameters can be declared to be of any type, unlike array indexes, which must be integral.

For example, the .NET Framework defines a `Hashtable` type that associates keys and values of arbitrary type:

[!code-csharp[csRefOperators#45](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#45)]

Square brackets are also used to specify [Attributes](../../programming-guide/concepts/attributes/index.md):

[!code-csharp[csRefOperators#46](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#46)]

You can use square brackets to index off a pointer:

[!code-csharp[csRefOperators#47](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#47)]

No bounds checking is performed.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Arrays](../../programming-guide/arrays/index.md)
- [Indexers](../../programming-guide/indexers/index.md)
- [unsafe](../keywords/unsafe.md)
- [fixed Statement](../keywords/fixed-statement.md)