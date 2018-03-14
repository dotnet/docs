---
title: Statically Resolved Type Parameters (F#)
description: Learn how to use an F# statically resolved type parameter, which is replaced with an actual type at compile time instead of at run time.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: b3797415-3e49-4f8a-a8ee-fa614c5721aa 
---

# Statically Resolved Type Parameters

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

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-3/snippet401.fs)]

The resolved type of `(+@)` is based on the use of both `(+)` and `(*)`, both of which cause type inference to infer member constraints on the statically resolved type parameters. The resolved type, as shown in the F# interpreter, is as follows.

```fsharp
^a -> ^c -> ^d
when (^a or ^b) : (static member ( + ) : ^a * ^b -> ^d) and
(^a or ^c) : (static member ( * ) : ^a * ^c -> ^b)
```

The output is as follows.

```
2
1.500000
```

Starting with F# 4.1, you can also specify concrete type names in statically resolved type parameter signatures.  In previous versions of the language, the type name could actually be inferred by the compiler, but could not actually be specified in the signature.  As of F# 4.1, you may also specify concrete type names in statically resolved type parameter signatures. Here's an example:

```fsharp
type CFunctor() = 
      static member inline fmap (f: ^a -> ^b, a: ^a list) = List.map f a
      static member inline fmap (f: ^a -> ^b, a: ^a option) =
        match a with
        | None -> None
        | Some x -> Some (f x)

      // default implementation of replace
      static member inline replace< ^a, ^b, ^c, ^d, ^e when ^a :> CFunctor and (^a or ^d): (static member fmap: (^b -> ^c) * ^d -> ^e) > (a, f) =
        ((^a or ^d) : (static member fmap : (^b -> ^c) * ^d -> ^e) (konst a, f))

      // call overridden replace if present
      static member inline replace< ^a, ^b, ^c when ^b: (static member replace: ^a * ^b -> ^c)>(a: ^a, f: ^b) =
        (^b : (static member replace: ^a * ^b -> ^c) (a, f))

let inline replace_instance< ^a, ^b, ^c, ^d when (^a or ^c): (static member replace: ^b * ^c -> ^d)> (a: ^b, f: ^c) =
      ((^a or ^c): (static member replace: ^b * ^c -> ^d) (a, f))

// Note the concrete type 'CFunctor' specified in the signature
let inline replace (a: ^a) (f: ^b): ^a0 when (CFunctor or  ^b): (static member replace: ^a *  ^b ->  ^a0) =
    replace_instance<CFunctor, _, _, _> (a, f)
```

## See Also
[Generics](index.md)

[Type Inference](../type-inference.md)

[Automatic Generalization](automatic-generalization.md)

[Constraints](constraints.md)

[Inline Functions](../functions/inline-functions.md)
