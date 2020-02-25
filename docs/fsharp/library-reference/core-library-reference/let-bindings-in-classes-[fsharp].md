---
title: let Bindings in Classes (F#)
description: let Bindings in Classes (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9d3710f5-68b1-4e4c-b02b-27fe018f20e8
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/members/let-bindings-in-classes 
---

# let Bindings in Classes (F#)

You can define private fields and private functions for F# classes by using `let` bindings in the class definition.


## Syntax

```fsharp
// Field.
[static] let [ mutable ] binding1 [ and ... binding-n ]

// Function.
[static] let [ rec ] binding1 [ and ... binding-n ]
```

## Remarks
The previous syntax appears after the class heading and inheritance declarations but before any member definitions. The syntax is like that of `let` bindings outside of classes, but the names defined in a class have a scope that is limited to the class. A `let` binding creates a private field or function; to expose data or functions publicly, declare a property or a member method.

A `let` binding that is not static is called an instance `let` binding. Instance `let` bindings execute when objects are created. Static `let` bindings are part of the static initializer for the class, which is guaranteed to execute before the type is first used.

The code within instance `let` bindings can use the primary constructor's parameters.

Attributes and accessibility modifiers are not permitted on `let` bindings in classes.

The following code examples illustrate several types of `let` bindings in classes.

[!code-fsharp[Main](snippets/fslangref1/snippet3001.fs)]

The output is as follows.

```
10 52 1 204
```

## Alternative Ways to Create Fields
You can also use the `val` keyword to create a private field. When using the `val` keyword, the field is not given a value when the object is created, but instead is initialized with a default value. For more information, see [Explicit Fields: The val Keyword &#40;F&#35;&#41;](Explicit-Fields-The-val-Keyword-%5BFSharp%5D.md).

You can also define private fields in a class by using a member definition and adding the keyword `private` to the definition. This can be useful if you expect to change the accessibility of a member without rewriting your code. For more information, see [Access Control &#40;F&#35;&#41;](Access-Control-%5BFSharp%5D.md).

## See Also
[Members &#40;F&#35;&#41;](Members-%5BFSharp%5D.md)

[do Bindings in Classes &#40;F&#35;&#41;](do-Bindings-in-Classes-%5BFSharp%5D.md)

[let Bindings &#40;F&#35;&#41;](let-Bindings-%5BFSharp%5D.md)