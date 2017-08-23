---
title: "Lambda Expressions: The fun Keyword (F#)"
description: Learn how to use the F# 'fun' keyword to define a lambda expression, which is an anonymous function.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: e5d3565c-d7cc-433f-a619-886ed92523a7 
---

# Lambda Expressions: The fun Keyword (F#)

The `fun` keyword is used to define a lambda expression, that is, an anonymous function.


## Syntax

```fsharp
fun parameter-list -> expression
```

## Remarks
The *parameter-list* typically consists of names and, optionally, types of parameters. More generally, the *parameter-list* can be composed of any F# patterns. For a full list of possible patterns, see [Pattern Matching](../pattern-matching.md). Lists of valid parameters include the following examples.

```fsharp
// Lambda expressions with parameter lists.
fun a b c -> ...
fun (a: int) b c -> ...
fun (a : int) (b : string) (c:float) -> ...

// A lambda expression with a tuple pattern.
fun (a, b) -> …

// A lambda expression with a list pattern.
fun head :: tail -> …
```

The *expression* is the body of the function, the last expression of which generates a return value. Examples of valid lambda expressions include the following:

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet301.fs)]
    
## Using Lambda Expressions
Lambda expressions are especially useful when you want to perform operations on a list or other collection and want to avoid the extra work of defining a function. Many F# library functions take function values as arguments, and it can be especially convenient to use a lambda expression in those cases. The following code applies a lambda expression to elements of a list. In this case, the anonymous function adds 1 to every element of a list.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet302.fs)]
    
## See Also
[Functions](index.md)
