---
title: The Fixed Keyword (F#)
description: The Fixed Keyword
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

F# 4.1 introduces the `fixed` keyword, which allows you to "pin" a local onto the stack to prevent it from being garbage-collected.  It is used for low-level programming scenarios.

## Syntax

```fsharp
use ptr = fixed expression
```

## Remarks

As you can see in the syntax example, something which is fixed via the `fixed` keyword is bound to an identifier via the `use` keyword.  The semantics of this are similar to resource management via the `use` keyword.  The pointer is fixed while it is in scope, and once it is out of scope, it is no longer fixed.  `fixed` cannot be used outside the context of a `use` binding.  You must bind the pointer to a name with `use`.

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

// Fix the Y value
use ptr = fixed &pnt.Y

// Square the Y value
squareWithPointer ptr
printfn "pnt after - X: %d Y: %d" pnt.X pnt.Y // prints 1 and 4
```

## See Also

[NativePtr Module](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/nativeinterop.nativeptr-module-%5Bfsharp%5D)