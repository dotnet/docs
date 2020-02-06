---
title: Values (F#)
description: Values (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5e1e73c3-5adb-4bba-9976-d57f1ff6cd8d
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/values/index 
---

# Values (F#)

Values in F# are quantities that have a specific type; values can be integral or floating point numbers, characters or text, lists, sequences, arrays, tuples, discriminated unions, records, class types, or function values.


## Binding a Value
The term *binding* means associating a name with a definition. The `let` keyword binds a value, as in the following examples:

[!code-fsharp[Main](snippets/fslangref1/snippet601.fs)]

The type of a value is inferred from the definition. For a primitive type, such as an integral or floating point number, the type is determined from the type of the literal. Therefore, in the previous example, the compiler infers the type of `b` to be `unsigned int`, whereas the compiler infers the type of `a` to be `int`. The type of a function value is determined from the return value in the function body. For more information about function value types, see [Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md). For more information about literal types, see [Literals &#40;F&#35;&#41;](Literals-%5BFSharp%5D.md).


## Why Immutable?
Immutable values are values that cannot be changed throughout the course of a program's execution. If you are used to languages such as C++, Visual Basic, or C#, you might find it surprising that F# puts primacy over immutable values rather than variables that can be assigned new values during the execution of a program. Immutable data is an important element of functional programming. In a multithreaded environment, shared mutable variables that can be changed by many different threads are difficult to manage. Also, with mutable variables, it can sometimes be hard to tell if a variable might be changed when it is passed to another function.

In pure functional languages, there are no variables, and functions behave strictly as mathematical functions. Where code in a procedural language uses a variable assignment to alter a value, the equivalent code in a functional language has an immutable value that is the input, an immutable function, and different immutable values as the output. This mathematical strictness allows for tighter reasoning about the behavior of the program. This tighter reasoning is what enables compilers to check code more stringently and to optimize more effectively, and helps make it easier for developers to understand and write correct code. Functional code is therefore likely to be easier to debug than ordinary procedural code.

F# is not a pure functional language, yet it fully supports functional programming. Using immutable values is a good practice because doing this allows your code to benefit from an important aspect of functional programming.


## Mutable Variables
You can use the keyword `mutable` to specify a variable that can be changed. Mutable variables in F# should generally have a limited scope, either as a field of a type or as a local value. Mutable variables with a limited scope are easier to control and are less likely to be modified in incorrect ways.

You can assign an initial value to a mutable variable by using the `let` keyword in the same way as you would define a value. However, the difference is that you can subsequently assign new values to mutable variables by using the `&lt;-` operator, as in the following example.

[!code-fsharp[Main](snippets/fslangref1/snippet602.fs)]
    
## Related Topics


|Title|Description|
|-----|-----------|
|[let Bindings &#40;F&#35;&#41;](let-Bindings-%5BFSharp%5D.md)|Provides information about using the `let`keyword to bind names to values and functions.|
|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|Provides an overview of functions in F#.|

## See Also
[Null Values &#40;F&#35;&#41;](Null-Values-%5BFSharp%5D.md)

[F&#35; Language Reference](FSharp-Language-Reference.md)