---
title: "Recursive Functions: The rec Keyword"
description: Learn how the F# 'rec' keyword is used with the 'let' keyword to define a recursive function.
ms.date: 08/12/2020
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

Recursive functions - functions that call themselves - are identified explicitly in the F# language with the `rec` keyword. The `rec` keyword makes the name of the `let` binding available in its body.

The following example shows a recursive function that computes the *n*<sup>th</sup> Fibonacci number using the mathematical definition.

```fsharp
let fib n =
    match n with
    | 0 | 1 -> 1
    | n -> fib (n-1) + fib (n-2)
```

> [!NOTE]
> In practice, code like the previous sample is not ideal because it unecessarily recomputes values that have already been computed. This is because it is not tail recursive, which is explained further in this article.

Methods are implicitly recursive within the type they are defined in, meaning there is no need to add the `rec` keyword. For example:

```fsharp
type MyClass() =
    member this.Fib(n) =
        match n with
        | 0 | 1 -> 1
        | n -> this.Fib(n-1) + this.Fib(n-2)
```

Let bindings within classes are not implicitly recursive, though. All `let`-bound functions require the `rec` keyword.

## Tail recursion

For some recursive functions, it is necessary to refactor a more "pure" definition to one that is [tail recursive](https://cs.stackexchange.com/questions/6230/what-is-tail-recursion). This prevents unnecessary recomputations. For example, the previous fibonacci number generator can be rewritten like this:

```fsharp
let fib n =
    let rec loop acc1 acc2 n =
        match n with
        | 0 -> acc1
        | 1 -> acc2
        | _ ->
            loop acc2 (acc1 + acc2) (n - 1)
    loop 0 1 n
```

This is a more complicated implementation. Generating a fibonacci number is a great example of a "naive" algorithm that's mathematically pure but inefficient in practice. Several aspects make it efficient in F# while still remaining recursively defined:

* A recursive inner function named `loop`, which is an idiomatic F# pattern.
* Two accumulator parameters, which pass accumulate values to recursive calls.
* A check on the value of `n` to return a specific accumulate.

If this example were written iteratively with a loop, the code would look similar with two different values accumulating numbers until a particular condition was met.

The reason why this is tail-recursive is because the recursive call does not need to save any values on the call stack. All intermediate values being calculated are accumulated via inputs to the inner function. This also allows the F# compiler to optimize the code to be just as fast as if you had written something like a `while` loop.

It's common to write F# code that recursively processes something with an inner and outer function, as the previous example shows. The inner function uses tail recursion, while the outer function has a better interface for callers.

## Mutually Recursive Functions

Sometimes functions are *mutually recursive*, meaning that calls form a circle, where one function calls another which in turn calls the first, with any number of calls in between. You must define such functions together in the one `let` binding, using the `and` keyword to link them together.

The following example shows two mutually recursive functions.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet4002.fs)]

## Recursive values

You can also define a `let`-bound value to be recursive. This is sometimes done for logging. With F# 5 and the `nameof` function, you can do this:

```fsharp
let rec nameDoubles = nameof nameDoubles + nameof nameDoubles
```

## See also

- [Functions](index.md)
