---
title: "Lambda Expressions: The fun Keyword"
description: Learn how to use the F# 'fun' keyword to define a lambda expression, which is an anonymous function.
ms.date: 05/16/2016
---
# Lambda Expressions: The fun Keyword (F#)

The `fun` keyword is used to define a lambda expression, that is, an anonymous function.

## Syntax

```fsharp
fun parameter-list -> expression
```

Or using the `_.Property` shorthand notation:

```fsharp
_.
```

`fun`, *parameter-list*, and lambda arrow (`->`) are omitted, and the `_.` is a part of *expression* where `_` replaces the parameter symbol.

The following snippets are equivalent:

`(fun x -> x.Property)`
`_.Property`

## Remarks

The *parameter-list* typically consists of names and, optionally, types of parameters. More generally, the *parameter-list* can be composed of any F# patterns. For a full list of possible patterns, see [Pattern Matching](../pattern-matching.md). Lists of valid parameters include the following examples.

```fsharp
// Lambda expressions with parameter lists.
fun a b c -> ...
fun (a: int) b c -> ...
fun (a : int) (b : string) (c:float) -> ...

// A lambda expression with a tuple pattern.
fun (a, b) -> …

// A lambda expression with a cons pattern.
// (note that this will generate an incomplete pattern match warning)
fun (head :: tail) -> …

// A lambda expression with a list pattern.
// (note that this will generate an incomplete pattern match warning)
fun [_; rest] -> …
```

The *expression* is the body of the function, the last expression of which generates a return value. Examples of valid lambda expressions include the following:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet301.fs)]

## Using Lambda Expressions

Lambda expressions are especially useful when you want to perform operations on a list or other collection and want to avoid the extra work of defining a function. Many F# library functions take function values as arguments, and it can be especially convenient to use a lambda expression in those cases. The following code applies a lambda expression to elements of a list. In this case, the anonymous function checks if an element is text that ends with specified characters.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet302.fs)]

The previous code snippet shows both notations: using the `fun` keyword, and the shorthand `_.Property` notation.

## See also

- [Functions](index.md)
