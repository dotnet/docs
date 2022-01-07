---
description: "partial method - C# Reference"
title: "partial method - C# Reference"
ms.date: 03/23/2021
f1_keywords: 
  - "partialmethod_CSharpKeyword"
helpviewer_keywords: 
  - "partial methods [C#]"
ms.assetid: 43f40242-17e0-4452-8573-090503ad3137
---
# partial method (C# Reference)

A partial method has its signature defined in one part of a partial type, and its implementation defined in another part of the type. Partial methods enable class designers to provide method hooks, similar to event handlers, that developers may decide to implement or not. If the developer does not supply an implementation, the compiler removes the signature at compile time. The following conditions apply to partial methods:

- Declarations must begin with the contextual keyword [partial](../../language-reference/keywords/partial-type.md).

- Signatures in both parts of the partial type must match.

The `partial` keyword isn't allowed on constructors, finalizers, overloaded operators, property declarations, or event declarations.

A partial method isn't required to have an implementation in the following cases:

- It doesn't have any accessibility modifiers (including the default [private](../../language-reference/keywords/private.md)).

- It returns [void](../../language-reference/builtin-types/void.md).

- It doesn't have any [out](../../language-reference/keywords/out-parameter-modifier.md) parameters.

- It doesn't have any of the following modifiers [virtual](../../language-reference/keywords/virtual.md), [override](../../language-reference/keywords/override.md), [sealed](../../language-reference/keywords/sealed.md), [new](../../language-reference/keywords/new-modifier.md), or [extern](../../language-reference/keywords/extern.md).

Any method that doesn't conform to all those restrictions (for example, `public virtual partial void` method), must provide an implementation.

The following example shows a partial method defined in two parts of a partial class:

[!code-csharp[csrefKeywordsContextual#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#9)]

Partial methods can also be useful in combination with source generators. For example a regex could be defined using the following pattern:

```csharp
[RegexGenerated("(dog|cat|fish)")]
partial bool IsPetMatch(string input);
```

For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## See also

- [C# Reference](../index.md)
- [partial type](partial-type.md)
