---
title: The Fixed Keyword (F#)
description: Learn how you can 'pin' a local onto the stack to prevent collection with the F# 'fixed' keyword.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 04/24/2017
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 5795ce1f-11bf-4798-9f1f-6e44ffa1477e 
---

# The Fixed Keyword

F# 4.1 introduces the `fixed` keyword, which allows you to "pin" a local onto the stack to prevent it from being collected or moved during garbage-collection.  It is used for low-level programming scenarios.

## Syntax

```fsharp
use ptr = fixed expression
```

## Remarks

This extends the syntax of expressions to allow extracting a pointer and binding it to a name which is prevented from being collected or moved during garbage-collection.  

A pointer from an expression is fixed via the `fixed` keyword is bound to an identifier via the `use` keyword.  The semantics of this are similar to resource management via the `use` keyword.  The pointer is fixed while it is in scope, and once it is out of scope, it is no longer fixed.  `fixed` cannot be used outside the context of a `use` binding.  You must bind the pointer to a name with `use`.

Use of `fixed` must occur within an expression in a function or a method.  It cannot be used at a script-level or module-level scope.

Like all pointer code, this is an unsafe feature and will emit a warning when used.

## Example

```fsharp
open Microsoft.FSharp.NativeInterop

type Point = { mutable X: int; mutable Y: int}

let squareWithPointer (p: nativeptr<int>) =
    // Dereference the pointer at the 0th address.
    let mutable value = NativePtr.get p 0

    // Perform some work
    value <- value * value

    // Set the value in the pointer at the 0th address.
    NativePtr.set p 0 value

let pnt = { X = 1; Y = 2 }
printfn "pnt before - X: %d Y: %d" pnt.X pnt.Y // prints 1 and 2

// Note that the use of 'fixed' is inside a function.
// You cannot fix a pointer at a script-level or module-level scope.
let doPointerWork() =
    use ptr = fixed &pnt.Y

    // Square the Y value
    squareWithPointer ptr
    printfn "pnt after - X: %d Y: %d" pnt.X pnt.Y // prints 1 and 4

doPointerWork()
```

## See Also

[NativePtr Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/nativeinterop.nativeptr-module-%5Bfsharp%5D)
