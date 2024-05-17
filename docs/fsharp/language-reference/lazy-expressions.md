---
title: Lazy Expressions
description: Learn how F# lazy expressions can improve the performance of your apps and libraries.
ms.date: 08/15/2020
---
# Lazy Expressions

*Lazy expressions* are expressions that are not evaluated immediately, but are instead evaluated when the result is needed. This can help to improve the performance of your code.

## Syntax

```fsharp
let identifier = lazy ( expression )
```

## Remarks

In the previous syntax, *expression* is code that is evaluated only when a result is required, and *identifier* is a value that stores the result. The value is of type `Lazy<'T>`, where the actual type that is used for `'T` is determined from the result of the expression.

Lazy expressions enable you to improve performance by restricting the execution of an expression to only those situations in which a result is needed.

To force the expressions to be performed, you call the method `Force`. `Force` causes the execution to be performed only one time. Subsequent calls to `Force` return the same result, but do not execute any code.

The following code illustrates the use of lazy expressions and the use of `Force`. In this code, the type of `result` is `Lazy<int>`, and the `Force` method returns an `int`.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet73011.fs)]

Lazy evaluation, but not the `Lazy` type, is also used for sequences. For more information, see [Sequences](sequences.md).

## See also

- [F# Language Reference](index.md)
- [LazyExtensions module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-lazyextensions.html)
