---
title: Exception Types
description: Learn how to define and use F# exception types.
ms.date: 05/16/2016
---
# Exception Types

There are two categories of exceptions in F#: .NET exception types and F# exception types. This topic describes how to define and use F# exception types.

## Syntax

```fsharp
exception exception-type of argument-type
```

## Remarks

In the previous syntax, *exception-type* is the name of a new F# exception type, and *argument-type* represents the type of an argument that can be supplied when you raise an exception of this type. You can specify multiple arguments by using a tuple type for *argument-type*.

A typical definition for an F# exception resembles the following.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5501.fs)]

You can generate an exception of this type by using the `raise` function, as follows.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5502.fs)]

You can use an F# exception type directly in the filters in a `try...with` expression, as shown in the following example.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5503.fs)]

The exception type that you define with the `exception` keyword in F# is a new type that inherits from `System.Exception`.

## See also

- [Exception Handling](index.md)
- [Exceptions: the `raise` Function](the-raise-function.md)
- [Exception Hierarchy](../../../standard/exceptions/index.md)
