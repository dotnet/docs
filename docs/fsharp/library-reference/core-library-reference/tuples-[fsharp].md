---
title: Tuples (F#)
description: Tuples (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 35069073-9a82-410f-8dea-912e2a152e6d
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/tuples 
---

# Tuples (F#)

A *tuple* is a grouping of unnamed but ordered values, possibly of different types.


## Syntax

```fsharp
( element , ... , element )
```

## Remarks
Each *element* in the previous syntax can be any expression.


## Examples
Examples of tuples include pairs, triples, and so on, of the same or different types. Some examples are illustrated in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet1201.fs)]
    
## Obtaining Individual Values
You can use pattern matching to access and assign names for tuple elements, as shown in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet1204.fs)]

You can use tuple patterns in `let` bindings as follows.

```fsharp
let (a, b) = (1, 2)
```

This binds values `a` and `b` at the same time. If you need only one element of the tuple, the wildcard character (the underscore) can be used to avoid creating a new name for a variable that you do not need.

```fsharp
let (a, _) = (1, 2)
```

The functions `fst` and `snd` return the first and second elements of a tuple, respectively.

[!code-fsharp[Main](snippets/fslangref1/snippet1209.fs)]

There is no built-in function that returns the third element of a triple, but you can easily write one as follows.

[!code-fsharp[Main](snippets/fslangref1/snippet1202.fs)]

Generally, it is better to use pattern matching to access individual tuple elements.


## Using Tuples
Tuples provide a convenient way to return multiple values from a function, as shown in the following example. This example performs integer division and returns the rounded result of the operation as a first member of a tuple pair and the remainder as a second member of the pair.

[!code-fsharp[Main](snippets/fslangref1/snippet1205.fs)]

Tuples can also be used as function arguments when you want to avoid the implicit currying of function arguments that is implied by the usual function syntax.

[!code-fsharp[Main](snippets/fslangref1/snippet1206.fs)]

The usual syntax for defining the function `let sum a b = a + b` enables you to define a function that is the partial application of the first argument of the function, as shown in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet1208.fs)]

Using a tuple as the parameter disables currying. For more information, see "Partial Application of Arguments" in [Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md).


## Names of Tuple Types
When you write out the name of a type that is a tuple, you use the &#42; symbol to separate elements. For a tuple that consists of an `int`, a `float`, and a `string`, such as `(10, 10.0, "ten")`, the type would be written as follows.

```fsharp
int * float * string
```

## Compiled Form of Tuples
If you are only using tuples from F# and not exposing them to other languages, and if you are not targeting a version of the .NET Framework that preceded version 4, you can ignore this section.

Tuples are compiled into objects of one of several generic types, all named `System.Tuple`, that are overloaded on the arity, or number of type parameters. Tuple types appear in this form when you view them from another language, such as C# or Visual Basic, or when you are using a tool that is not aware of F# constructs. The `Tuple` types were introduced in .NET Framework 4. If you are targeting an earlier version of the .NET Framework, the compiler uses versions of [System.Tuple](https://msdn.microsoft.com/library/5ac7953d-acdc-4a58-bfb7-c1f6406c0fa3) from the 2.0 version of the F# Core Library. The types in this library are used only for applications that target the 2.0, 3.0, and 3.5 versions of the .NET Framework. Type forwarding is used to ensure binary compatibility between .NET Framework 2.0 and .NET Framework 4 F# components.

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[F&#35; Types](FSharp-Types.md)