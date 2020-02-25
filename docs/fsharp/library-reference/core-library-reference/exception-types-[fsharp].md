---
title: Exception Types (F#)
description: Exception Types (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e850205a-b8da-459e-8f6d-cb3510f8f173
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/exception-types 
---

# Exception Types (F#)

There are two categories of exceptions in F#: .NET exception types and F# exception types. This topic describes how to define and use F# exception types.


## Syntax

```fsharp
exception exception-type of argument-type
```

## Remarks
In the previous syntax, *exception-type* is the name of a new F# exception type, and *argument-type* represents the type of an argument that can be supplied when you raise an exception of this type. You can specify multiple arguments by using a tuple type for *argument-type*.

A typical definition for an F# exception resembles the following.

[!code-fsharp[Main](snippets/fslangref2/snippet5501.fs)]

You can generate an exception of this type by using the `raise` function, as follows.

[!code-fsharp[Main](snippets/fslangref2/snippet5502.fs)]

You can use an F# exception type directly in the filters in a `try...with` expression, as shown in the following example.

[!code-fsharp[Main](snippets/fslangref2/snippet5503.fs)]

The exception type that you define with the `exception` keyword in F# is a new type that inherits from `System.Exception`.


## See Also
[Exception Handling &#40;F&#35;&#41;](Exception-Handling-%5BFSharp%5D.md)

[Exceptions: the raise Function &#40;F&#35;&#41;](Exceptions-the-raise-Function-%5BFSharp%5D.md)

[Exception Hierarchy](https://msdn.microsoft.com/library/z4c5tckx.aspx)