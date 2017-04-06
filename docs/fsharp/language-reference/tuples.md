---
title: Tuples (F#)
description: Tuples (F#)
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 35069073-9a82-410f-8dea-912e2a152e6d 
---

# Tuples

A *tuple* is a grouping of unnamed but ordered values, possibly of different types.  Tuples can either be reference types or structs.

## Syntax

```fsharp
(element, ... , element)
struct(element, ... ,element )
```
## Remarks
Each *element* in the previous syntax can be any valid F# expression.

## Examples
Examples of tuples include pairs, triples, and so on, of the same or different types. Some examples are illustrated in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L6-L21)]
    
## Obtaining Individual Values
You can use pattern matching to access and assign names for tuple elements, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#27-L29)]

You can also deconstruct a tuple via pattern matching outside of a `match` expression via  `let` binding:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#34-L37)]

Or you can pattern match on tuples as inputs to functions:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#43-L47)]

If you need only one element of the tuple, the wildcard character (the underscore) can be used to avoid creating a new name for a value that you do not need.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#53-L54)]

Copying elements from a reference tuple into a struct tuple is also simple:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#62-L66)]

The functions `fst` and `snd` return the first and second elements of a tuple, respectively.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fs#L72-L73)]

There is no built-in function that returns the third element of a triple, but you can easily write one as follows.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fs#L78)]

Generally, it is better to use pattern matching to access individual tuple elements.

## Using Tuples
Tuples provide a convenient way to return multiple values from a function, as shown in the following example. This example performs integer division and returns the rounded result of the operation as a first member of a tuple pair and the remainder as a second member of the pair.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/using-tuples.fsx#L1-L4)]

Tuples can also be used as function arguments when you want to avoid the implicit currying of function arguments that is implied by the usual function syntax.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/using-tuples.fsx#L6)]

The usual syntax for defining the function `let sum a b = a + b` enables you to define a function that is the partial application of the first argument of the function, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/using-tuples.fsx#L8-L12)]

Using a tuple as the parameter disables currying. For more information, see "Partial Application of Arguments" in [Functions](functions/index.md).

## Names of Tuple Types
When you write out the name of a type that is a tuple, you use the `*` symbol to separate elements. For a tuple that consists of an `int`, a `float`, and a `string`, such as `(10, 10.0, "ten")`, the type would be written as follows.

```fsharp
int * float * string
```

## Compiled Form of Tuples
If you are only using tuples from F# and not exposing them to other languages, and if you are not targeting a version of the .NET Framework that preceded version 4, you can ignore this section.

Tuples are compiled into objects of one of several generic types, all named `System.Tuple`, that are overloaded on the arity, or number of type parameters. Tuple types appear in this form when you view them from another language, such as C# or Visual Basic, or when you are using a tool that is not aware of F# constructs. The `Tuple` types were introduced in .NET Framework 4. If you are targeting an earlier version of the .NET Framework, the compiler uses versions of [System.Tuple](https://msdn.microsoft.com/library/5ac7953d-acdc-4a58-bfb7-c1f6406c0fa3) from the 2.0 version of the F# Core Library. The types in this library are used only for applications that target the 2.0, 3.0, and 3.5 versions of the .NET Framework. Type forwarding is used to ensure binary compatibility between .NET Framework 2.0 and .NET Framework 4 F# components.

### Struct Tuple Compiled Form

blurb

## See Also
[F# Language Reference](index.md)

[F# Types](fsharp-types.md)