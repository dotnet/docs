---
title: Inline Functions (F#)
description: Learn how to use F# inline functions that are integrated directly into the calling code.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 3fa31178-08f8-463d-9d41-d29220a90027 
---

# Inline Functions

*Inline functions* are functions that are integrated directly into the calling code.


## Using Inline Functions
When you use static type parameters, any functions that are parameterized by type parameters must be inline. This guarantees that the compiler can resolve these type parameters. When you use ordinary generic type parameters, there is no such restriction.

Other than enabling the use of member constraints, inline functions can be helpful in optimizing code. However, overuse of inline functions can cause your code to be less resistant to changes in compiler optimizations and the implementation of library functions. For this reason, you should avoid using inline functions for optimization unless you have tried all other optimization techniques. Making a function or method inline can sometimes improve performance, but that is not always the case. Therefore, you should also use performance measurements to verify that making any given function inline does in fact have a positive effect.

The `inline` modifier can be applied to functions at the top level, at the module level, or at the method level in a class.

The following code example illustrates an inline function at the top level, an inline instance method, and an inline static method.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet201.fs)]
    
## Inline Functions and Type Inference
The presence of `inline` affects type inference. This is because inline functions can have statically resolved type parameters, whereas non-inline functions cannot. The following code example shows a case where `inline` is helpful because you are using a function that has a statically resolved type parameter, the `float` conversion operator.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet202.fs)]

Without the `inline` modifier, type inference forces the function to take a specific type, in this case `int`. But with the `inline` modifier, the function is also inferred to have a statically resolved type parameter. With the `inline` modifier, the type is inferred to be the following:

```fsharp
^a -> unit when ^a : (static member op_Explicit : ^a -> float)
```

This means that the function accepts any type that supports a conversion to **float**.


## See Also
[Functions](index.md)

[Constraints](../generics/constraints.md)

[Statically Resolved Type Parameters](../generics/statically-resolved-type-parameters.md)
