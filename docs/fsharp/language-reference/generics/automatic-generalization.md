---
title: Automatic Generalization (F#)
description: Learn how F# automatically generalizes the arguments and types of functions so that they work with multiple types when possible.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 14a3554c-3fad-4eba-a93d-8ba07d1245b4 
---

# Automatic Generalization

F# uses type inference to evaluate the types of functions and expressions. This topic describes how F# automatically generalizes the arguments and types of functions so that they work with multiple types when this is possible.


## Automatic Generalization
The F# compiler, when it performs type inference on a function, determines whether a given parameter can be generic. The compiler examines each parameter and determines whether the function has a dependency on the specific type of that parameter. If it does not, the type is inferred to be generic.

The following code example illustrates a function that the compiler infers to be generic.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet101.fs)]

The type is inferred to be `'a -> 'a -> 'a`.

The type indicates that this is a function that takes two arguments of the same unknown type and returns a value of that same type. One of the reasons that the previous function can be generic is that the greater-than operator (`>`) is itself generic. The greater-than operator has the signature `'a -> 'a -> bool`. Not all operators are generic, and if the code in a function uses a parameter type together with a non-generic function or operator, that parameter type cannot be generalized.

Because `max` is generic, it can be used with types such as `int`, `float`, and so on, as shown in the following examples.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet102.fs)]

However, the two arguments must be of the same type. The signature is `'a -> 'a -> 'a`, not `'a -> 'b -> 'a`. Therefore, the following code produces an error because the types do not match.

```fsharp
// Error: type mismatch.
let biggestIntFloat = max 2.0 3
```

The `max` function also works with any type that supports the greater-than operator. Therefore, you could also use it on a string, as shown in the following code.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet104.fs)]
    
## Value Restriction
The compiler performs automatic generalization only on complete function definitions that have explicit arguments, and on simple immutable values.

This means that the compiler issues an error if you try to compile code that is not sufficiently constrained to be a specific type, but is also not generalizable. The error message for this problem refers to this restriction on automatic generalization for values as the *value restriction*.

Typically, the value restriction error occurs either when you want a construct to be generic but the compiler has insufficient information to generalize it, or when you unintentionally omit sufficient type information in a nongeneric construct. The solution to the value restriction error is to provide more explicit information to more fully constrain the type inference problem, in one of the following ways:


- Constrain a type to be nongeneric by adding an explicit type annotation to a value or parameter.

- If the problem is using a nongeneralizable construct to define a generic function, such as a function composition or incompletely applied curried function arguments, try to rewrite the function as an ordinary function definition.

- If the problem is an expression that is too complex to be generalized, make it into a function by adding an extra, unused parameter.

- Add explicit generic type parameters. This option is rarely used.

- The following code examples illustrate each of these scenarios.

Case 1: Too complex an expression. In this example, the list `counter` is intended to be `int option ref`, but it is not defined as a simple immutable value.

```fsharp
let counter = ref None
// Adding a type annotation fixes the problem:
let counter : int option ref = ref None
```

Case 2: Using a nongeneralizable construct to define a generic function. In this example, the construct is nongeneralizable because it involves partial application of function arguments.

```fsharp
let maxhash = max << hash
// The following is acceptable because the argument for maxhash is explicit:
let maxhash obj = (max << hash) obj
```

Case 3: Adding an extra, unused parameter. Because this expression is not simple enough for generalization, the compiler issues the value restriction error.

```fsharp
let emptyList10 = Array.create 10 []
// Adding an extra (unused) parameter makes it a function, which is generalizable.
let emptyList10 () = Array.create 10 []
```

Case 4: Adding type parameters.

```fsharp
let arrayOf10Lists = Array.create 10 []
// Adding a type parameter and type annotation lets you write a generic value.
let arrayOf10Lists<'T> = Array.create 10 ([]:'T list)
```

In the last case, the value becomes a type function, which may be used to create values of many different types, for example as follows:

```fsharp
let intLists = arrayOf10Lists<int>
let floatLists = arrayOf10Lists<float>
```

## See Also
[Type Inference](../type-inference.md)

[Generics](index.md)

[Statically Resolved Type Parameters](statically-resolved-type-parameters.md)

[Constraints](constraints.md)

