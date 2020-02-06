---
title: Statically Resolved Type Parameters (F#)
description: Statically Resolved Type Parameters (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b3797415-3e49-4f8a-a8ee-fa614c5721aa
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/generics/statically-resolved-type-parameters 
---

# Statically Resolved Type Parameters (F#)

A *statically resolved type parameter* is a type parameter that is replaced with an actual type at compile time instead of at run time. They are preceded by a caret (^) symbol.


## Syntax

```
ˆtype-parameter
```

## Remarks
In the F# language, there are two distinct kinds of type parameters. The first kind is the standard generic type parameter. These are indicated by an apostrophe ('), as in `'T` and `'U`. They are equivalent to generic type parameters in other .NET Framework languages. The other kind is statically resolved and is indicated by a caret symbol, as in `^T` and `^U`.

Statically resolved type parameters are primarily useful in conjunction with member constraints, which are constraints that allow you to specify that a type argument must have a particular member or members in order to be used. There is no way to create this kind of constraint by using a regular generic type parameter.

The following table summarizes the similarities and differences between the two kinds of type parameters.



|Feature|Generic|Statically resolved|
|-------|-------|-------------------|
|Syntax|`'T`, `'U`|`^T`, `^U`|
|Resolution time|Run time|Compile time|
|Member constraints|Cannot be used with member constraints.|Can be used with member constraints.|
|Code generation|A type (or method) with standard generic type parameters results in the generation of a single generic type or method.|Multiple instantiations of types and methods are generated, one for each type that is needed.|
|Use with types|Can be used on types.|Cannot be used on types.|
|Use with inline functions|No. An inline function cannot be parameterized with a standard generic type parameter.|Yes. Statically resolved type parameters cannot be used on functions or methods that are not inline.|
Many F# core library functions, especially operators, have statically resolved type parameters. These functions and operators are inline, and result in efficient code generation for numeric computations.

Inline methods and functions that use operators, or use other functions that have statically resolved type parameters, can also use statically resolved type parameters themselves. Often, type inference infers such inline functions to have statically resolved type parameters. The following example illustrates an operator definition that is inferred to have a statically resolved type parameter.

[!code-fsharp[Main](snippets/fslangref3/snippet401.fs)]

The resolved type of `(+@)` is based on the use of both `(+)` and `(*)`, both of which cause type inference to infer member constraints on the statically resolved type parameters. The resolved type, as shown in the F# interpreter, is as follows.

```fsharp
^a -> ^c -> ^d
when (^a or ^b) : (static member (+) : ^a * ^b -> ^d) and
(^a or ^c) : (static member (+) : ^a * ^c -> ^b)
```

The output is as follows.

```
2
1.500000
```

## See Also
[Generics &#40;F&#35;&#41;](Generics-%5BFSharp%5D.md)

[Type Inference &#40;F&#35;&#41;](Type-Inference-%5BFSharp%5D.md)

[Automatic Generalization &#40;F&#35;&#41;](Automatic-Generalization-%5BFSharp%5D.md)

[Constraints &#40;F&#35;&#41;](Constraints-%5BFSharp%5D.md)

[Inline Functions &#40;F&#35;&#41;](Inline-Functions-%5BFSharp%5D.md)