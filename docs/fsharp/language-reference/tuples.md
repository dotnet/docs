---
title: Tuples (F#)
description: Learn about the F# tuple, a grouping of unnamed but ordered values, possibly of different types.
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

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L27-L29)]

You can also deconstruct a tuple via pattern matching outside of a `match` expression via  `let` binding:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L34-L37)]

Or you can pattern match on tuples as inputs to functions:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L43-L47)]

If you need only one element of the tuple, the wildcard character (the underscore) can be used to avoid creating a new name for a value that you do not need.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L53-L54)]

Copying elements from a reference tuple into a struct tuple is also simple:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L62-L66)]

The functions `fst` and `snd` (reference tuples only) return the first and second elements of a tuple, respectively.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L72-L73)]

There is no built-in function that returns the third element of a triple, but you can easily write one as follows.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L78-L78)]

Generally, it is better to use pattern matching to access individual tuple elements.

## Using Tuples
Tuples provide a convenient way to return multiple values from a function, as shown in the following example. This example performs integer division and returns the rounded result of the operation as a first member of a tuple pair and the remainder as a second member of the pair.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L83-L86)]

Tuples can also be used as function arguments when you want to avoid the implicit currying of function arguments that is implied by the usual function syntax.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L88-L88)]

The usual syntax for defining the function `let sum a b = a + b` enables you to define a function that is the partial application of the first argument of the function, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/basic-examples.fsx#L90-L94)]

Using a tuple as the parameter disables currying. For more information, see "Partial Application of Arguments" in [Functions](functions/index.md).

## Names of Tuple Types
When you write out the name of a type that is a tuple, you use the `*` symbol to separate elements. For a tuple that consists of an `int`, a `float`, and a `string`, such as `(10, 10.0, "ten")`, the type would be written as follows.

```fsharp
int * float * string
```

## Interoperation with C# Tuples

C# 7 introduced tuples to the language.  Tuples in C# are structs, and are equivalent to struct tuples in F#.  If you need to interoperate with C#, you must use struct tuples.

This is easy to do.  For example, imagine you have to pass a tuple to a C# class and then consume its result, which is also a tuple:

```csharp
namespace CSharpTupleInterop
{
    public static class Example
    {
        public static (int, int) AddOneToXAndY((int x, int y) a) =>
            (a.x + 1, a.y + 1);
    }
}
```

In your F# code, you can then pass a struct tuple as the parameter and consume the result as a struct tuple.

```fsharp
open TupleInterop

let struct (newX, newY) = Example.AddOneToXAndY(struct (1, 2))
// newX is now 2, and newY is now 3
```

### Converting between Reference Tuples and Struct Tuples

Because Reference Tuples and Struct Tuples have a completely different underlying representation, they are not implicitly convertible.  That is, code such as the following won't compile:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/interop.fsx#L5-L12)]

You must pattern match on one tuple and construct the other with the constituent parts.  For example:

[!code-fsharp[Main](../../../samples/snippets/fsharp/tuples/interop.fsx#L18-L22)]

## Compiled Form of Reference Tuples
This section explains the form of tuples when they're compiled.  The information here isn't necessary to read unless you are targeting .NET Framework 3.5 or lower.

Tuples are compiled into objects of one of several generic types, all named `System.Tuple`, that are overloaded on the arity, or number of type parameters. Tuple types appear in this form when you view them from another language, such as C# or Visual Basic, or when you are using a tool that is not aware of F# constructs. The `Tuple` types were introduced in .NET Framework 4. If you are targeting an earlier version of the .NET Framework, the compiler uses versions of [System.Tuple](https://msdn.microsoft.com/library/5ac7953d-acdc-4a58-bfb7-c1f6406c0fa3) from the 2.0 version of the F# Core Library. The types in this library are used only for applications that target the 2.0, 3.0, and 3.5 versions of the .NET Framework. Type forwarding is used to ensure binary compatibility between .NET Framework 2.0 and .NET Framework 4 F# components.

### Compiled Form of Struct Tuples

Struct tuples (for example, `struct (x, y)`), are fundamentally different from reference tuples.  They are compiled into the <xref:System.ValueTuple> type, overloaded by arity, or the number of type parameters.  They are equivalent to [C# 7 Tuples](../../csharp/tuples.md) and [Visual Basic 2017 Tuples](../../visual-basic/programming-guide/language-features/data-types/tuples.md), and interoperate bidirectionally.

## See Also
[F# Language Reference](index.md)

[F# Types](fsharp-types.md)
