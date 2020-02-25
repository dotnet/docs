---
title: "partial type - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "partialtype"
  - "partialtype_CSharpKeyword"
helpviewer_keywords: 
  - "partial types [C#]"
ms.assetid: 27320743-a22e-4c7b-b0b3-53afe3607334
---
# partial type (C# Reference)

Partial type definitions allow for the definition of a class, struct, or interface to be split into multiple files.

In *File1.cs*:

[!code-csharp[csrefKeywordsContextual#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#3)]  

In *File2.cs* the declaration:

[!code-csharp[csrefKeywordsContextual#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#4)]  

## Remarks

Splitting a class, struct or interface type over several files can be useful when you are working with large projects, or with automatically generated code such as that provided by the [Windows Forms Designer](../../../framework/winforms/controls/developing-windows-forms-controls-at-design-time.md). A partial type may contain a [partial method](partial-method.md). For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Modifiers](index.md)
- [Introduction to Generics](../../programming-guide/generics/index.md)
