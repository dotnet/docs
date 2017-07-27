---
title: Unit Type (F#)
description: Learn how the F# 'unit' type is often used to hold the place where a value is required by the language syntax when no value is needed or desired.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: eabbb6d7-80f3-4fa5-80b4-0f48982466a7 
---

# Unit Type

The `unit` type is a type that indicates the absence of a specific value; the `unit` type has only a single value, which acts as a placeholder when no other value exists or is needed.


## Syntax

```fsharp
// The value of the unit type.
()
```

## Remarks
Every F# expression must evaluate to a value. For expressions that do not generate a value that is of interest, the value of type `unit` is used. The `unit` type resembles the `void` type in languages such as C# and C++.

The `unit` type has a single value, and that value is indicated by the token `()`.

The value of the `unit` type is often used in F# programming to hold the place where a value is required by the language syntax, but when no value is needed or desired. An example might be the return value of a `printf` function. Because the important actions of the `printf` operation occur in the function, the function does not have to return an actual value. Therefore, the return value is of type `unit`.

Some constructs expect a `unit` value. For example, a `do` binding or any code at the top level of a module is expected to evaluate to a `unit` value. The compiler reports a warning when a `do` binding or code at the top level of a module produces a result other than the `unit` value that is not used, as shown in the following example.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet901.fs)]

This warning is a characteristic of functional programming; it does not appear in other .NET programming languages. In a purely functional program, in which functions do not have any side effects, the final return value is the only result of a function call. Therefore, when the result is ignored, it is a possible programming error. Although F# is not a purely functional programming language, it is a good practice to follow functional programming style whenever possible.

## See Also
[Primitive](primitive-types.md)

[F# Language Reference](index.md)
