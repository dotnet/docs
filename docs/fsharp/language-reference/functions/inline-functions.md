---
title: Inline Functions
description: Learn how to use F# inline functions that are integrated directly into the calling code.
ms.date: 05/16/2016
---
# Inline Functions

*Inline functions* are functions that are integrated directly into the calling code.

## Using Inline Functions

When you use static type parameters, any functions that are parameterized by type parameters must be inline. This guarantees that the compiler can resolve these type parameters. When you use ordinary generic type parameters, there is no such restriction.

Other than enabling the use of member constraints, inline functions can be helpful in optimizing code. However, overuse of inline functions can cause your code to be less resistant to changes in compiler optimizations and the implementation of library functions. For this reason, you should avoid using inline functions for optimization unless you have tried all other optimization techniques. Making a function or method inline can sometimes improve performance, but that is not always the case. Therefore, you should also use performance measurements to verify that making any given function inline does in fact have a positive effect.

The `inline` modifier can be applied to functions at the top level, at the module level, or at the method level in a class.

The following code example illustrates an inline function at the top level, an inline instance method, and an inline static method.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-3/snippet201.fs)]

## Inline Functions and Type Inference

The presence of `inline` affects type inference. This is because inline functions can have statically resolved type parameters, whereas non-inline functions cannot. The following code example shows a case where `inline` is helpful because you are using a function that has a statically resolved type parameter, the `float` conversion operator.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-3/snippet202.fs)]

Without the `inline` modifier, type inference forces the function to take a specific type, in this case `int`. But with the `inline` modifier, the function is also inferred to have a statically resolved type parameter. With the `inline` modifier, the type is inferred to be the following:

```fsharp
^a -> unit when ^a : (static member op_Explicit : ^a -> float)
```

This means that the function accepts any type that supports a conversion to **float**.

## InlineIfLambda

The F# compiler includes an optimizer that performs inlining of code. The `InlineIfLambda` attribute allows code to optionally indicate that, if an argument is determined to be a lambda function, then that argument should itself always be inlined at call sites. For more information, see [F# RFC FS-1098](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1098-inline-if-lambda.md).

For example, consider the following `iterateTwice` function to traverse an array:

```fsharp
let inline iterateTwice ([<InlineIfLambda>] action) (array: 'T[]) =
    for j = 0 to array.Length-1 do
        action array[j]
    for j = 0 to array.Length-1 do
        action array[j]
```

If the call site is:

```fsharp
let arr = [| 1.. 100 |]
let mutable sum = 0
arr  |> iterateTwice (fun x ->
    sum <- sum + x)
```

Then after inlining and other optimizations, the code becomes:

```fsharp
let arr = [| 1.. 100 |]
let mutable sum = 0
for j = 0 to array.Length-1 do
    sum <- array[i] + x
for j = 0 to array.Length-1 do
    sum <- array[i] + x
```

This optimization is applied regardless of the size of the lambda expression involved. This feature can also be used to implement loop unrolling and similar transformations more reliably.

An opt-in warning (`/warnon:3517` or property `<WarnOn>3517</WarnOn>`) can be turned on to indicate places in your code where `InlineIfLambda` arguments are not bound to lambda expressions at call sites. In normal situations, this warning should not be enabled. However, in certain kinds of high-performance programming, it can be useful to ensure all code is inlined and flattened.

## See also

- [Functions](index.md)
- [Constraints](../generics/constraints.md)
- [Statically Resolved Type Parameters](../generics/statically-resolved-type-parameters.md)
