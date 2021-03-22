---
description: "partial method - C# Reference"
title: "partial method - C# Reference"
ms.date: 03/22/2021
f1_keywords: 
  - "partialmethod_CSharpKeyword"
helpviewer_keywords: 
  - "partial methods [C#]"
ms.assetid: 43f40242-17e0-4452-8573-090503ad3137
---
# partial method (C# Reference)

A partial method has its signature defined in one part of a partial type, and its implementation defined in another part of the type. Partial methods enable class designers to provide method hooks, similar to event handlers, that developers may decide to implement or not. If the developer does not supply an implementation, the compiler removes the signature at compile time. The following conditions apply to partial methods:

- Signatures in both parts of the partial type must match.

Partial method must have an implementation part in following cases:

- It has any accessibility modifiers (even [private](../../language-reference/keywords/private.md)).

- It has any return type other than [void](../../language-reference/builtin-types/void.md).

- It has [out](../../language-reference/keywords/out-parameter-modifier.md) parameters.

- It has a [virtual](../../language-reference/keywords/virtual.md), [override](../../language-reference/keywords/override.md), [sealed](../../language-reference/keywords/sealed.md), [new](../../language-reference/keywords/new-modifier.md), or [extern](../../language-reference/keywords/extern.md) modifier.

The following example shows a partial method defined in two parts of a partial class:

[!code-csharp[csrefKeywordsContextual#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#9)]

For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## See also

- [C# Reference](../index.md)
- [partial type](partial-type.md)
