---
title: "partial method - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "partialmethod_CSharpKeyword"
helpviewer_keywords: 
  - "partial methods [C#]"
ms.assetid: 43f40242-17e0-4452-8573-090503ad3137
---
# partial method (C# Reference)

A partial method has its signature defined in one part of a partial type, and its implementation defined in another part of the type. Partial methods enable class designers to provide method hooks, similar to event handlers, that developers may decide to implement or not. If the developer does not supply an implementation, the compiler removes the signature at compile time. The following conditions apply to partial methods:

- Signatures in both parts of the partial type must match.

- The method must return void.

- No access modifiers are allowed. Partial methods are implicitly private.

The following example shows a partial method defined in two parts of a partial class:

[!code-csharp[csrefKeywordsContextual#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#9)]

For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## See also

- [C# Reference](../index.md)
- [partial type](partial-type.md)