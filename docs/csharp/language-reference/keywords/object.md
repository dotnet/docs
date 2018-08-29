---
title: "object (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "object_CSharpKeyword"
  - "object"
helpviewer_keywords: 
  - "object keyword [C#]"
ms.assetid: 93f60c0b-e17a-40a9-9362-cca5fb77b0e7
---
# object (C# Reference)

The `object` type is an alias for <xref:System.Object> in .NET. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object>. You can assign values of any type to variables of type `object`. When a variable of a value type is converted to object, it is said to be *boxed*. When a variable of type object is converted to a value type, it is said to be *unboxed*. For more information, see [Boxing and Unboxing](../../../csharp/programming-guide/types/boxing-and-unboxing.md).

## Example

The following sample shows how variables of type `object` can accept values of any data type and how variables of type `object` can use methods on <xref:System.Object> from the .NET Framework.

[!code-csharp[csrefKeywordsTypes#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#16)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Reference Types](reference-types.md)
- [Value Types](value-types.md)