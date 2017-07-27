---
title: "Recursive Functions: The rec Keyword (F#)"
description: Learn how the F# 'rec' keyword is used with the 'let' keyword to define a recursive function.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 1a95639f-9bfe-4f1d-a5e2-246d1d37776e
---

# Recursive Functions: The rec Keyword

The `rec` keyword is used together with the `let` keyword to define a recursive function.


## Syntax

```fsharp
// Recursive function:
let rec function-nameparameter-list =
function-body

// Mutually recursive functions:
let rec function1-nameparameter-list =
function1-body
and function2-nameparameter-list =
function2-body
...
```

## Remarks
Recursive functions, functions that call themselves, are identified explicitly in the F# language. This makes the identifer that is being defined available in the scope of the function.

The following code illustrates a recursive function that computes the *n*th Fibonacci number.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet4001.fs)]

>[!NOTE]
In practice, code like that above is wasteful of memory and processor time because it involves the recomputation of previously computed values.


Methods are implicitly recursive within the type; there is no need to add the `rec` keyword. Let bindings within classes are not implicitly recursive.


## Mutually Recursive Functions
Sometimes functions are *mutually recursive*, meaning that calls form a circle, where one function calls another which in turn calls the first, with any number of calls in between. You must define such functions together in the one `let` binding, using the `and` keyword to link them together.

The following example shows two mutually recursive functions.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet4002.fs)]

## See Also
[Functions](index.md)
