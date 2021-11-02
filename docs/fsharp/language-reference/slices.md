---
title: Slices
description: Learn how to use slices for existing F# data types and how to define your own slices for other data types.
ms.date: 11/20/2020
---

# Slices

This article explains how to take slices from existing F# types and how to define your own slices.

In F#, a slice is a subset of any data type.  Slices are similar to [indexers](./members/indexed-properties.md), but instead of yielding a single value from the underlying data structure, they yield multiple ones. Slices use the `..` operator syntax to select the range of specified indices in a data type. For more information, see the [looping expression reference article](./loops-for-in-expression.md).

F# currently has intrinsic support for slicing strings, lists, arrays, and multidimensional (2D, 3D, 4D) arrays. Slicing is most commonly used with F# arrays and lists. You can add slicing to your custom data types by using the `GetSlice` method in your type definition or in an in-scope [type extension](type-extensions.md).

## Slicing F# lists and arrays

The most common data types that are sliced are F# lists and arrays.  The following example demonstrates how to slice lists:

```fsharp
// Generate a list of 100 integers
let fullList = [ 1 .. 100 ]

// Create a slice from indices 1-5 (inclusive)
let smallSlice = fullList[1..5]
printfn $"Small slice: {smallSlice}"

// Create a slice from the beginning to index 5 (inclusive)
let unboundedBeginning = fullList[..5]
printfn $"Unbounded beginning slice: {unboundedBeginning}"

// Create a slice from an index to the end of the list
let unboundedEnd = fullList[94..]
printfn $"Unbounded end slice: {unboundedEnd}"
```

Slicing arrays is just like slicing lists:

```fsharp
// Generate an array of 100 integers
let fullArray = [| 1 .. 100 |]

// Create a slice from indices 1-5 (inclusive)
let smallSlice = fullArray[1..5]
printfn $"Small slice: {smallSlice}"

// Create a slice from the beginning to index 5 (inclusive)
let unboundedBeginning = fullArray[..5]
printfn $"Unbounded beginning slice: {unboundedBeginning}"

// Create a slice from an index to the end of the list
let unboundedEnd = fullArray[94..]
printfn $"Unbounded end slice: {unboundedEnd}"
```

Prior to F# 6, slicing used the syntax `expr.[start..finish]` with the extra `.`. If you choose, you can still use this syntax. For more information, see [RFC FS-1110](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1110-index-syntax.md).

## Slicing multidimensional arrays

F# supports multidimensional arrays in the F# core library. As with one-dimensional arrays, slices of multidimensional arrays can also be useful. However, the introduction of additional dimensions mandates a slightly different syntax so that you can take slices of specific rows and columns.

The following examples demonstrate how to slice a 2D array:

```fsharp
// Generate a 3x3 2D matrix
let A = array2D [[1;2;3];[4;5;6];[7;8;9]]
printfn $"Full matrix:\n {A}"

// Take the first row
let row0 = A[0,*]
printfn $"{row0}"

// Take the first column
let col0 = A[*,0]
printfn $"{col0}"

// Take all rows but only two columns
let subA = A[*,0..1]
printfn $"{subA}"

// Take two rows and all columns
let subA' = A[0..1,*]
printfn $"{subA}"

// Slice a 2x2 matrix out of the full 3x3 matrix
let twoByTwo = A[0..1,0..1]
printfn $"{twoByTwo}"
```

## Defining slices for other data structures

The F# core library defines slices for a limited set of types. If you wish to define slices for more data types, you can do so either in the type definition itself or in a type extension.

For example, here's how you might define slices for the <xref:System.ArraySegment%601> class to allow for convenient data manipulation:

```fsharp
open System

type ArraySegment<'TItem> with
    member segment.GetSlice(start, finish) =
        let start = defaultArg start 0
        let finish = defaultArg finish segment.Count
        ArraySegment(segment.Array, segment.Offset + start, finish - start)

let arr = ArraySegment [| 1 .. 10 |]
let slice = arr[2..5] //[ 3; 4; 5]
```

Another example using the <xref:System.Span%601> and <xref:System.ReadOnlySpan%601> types:

```fsharp
open System

type ReadOnlySpan<'T> with
    member sp.GetSlice(startIdx, endIdx) =
        let s = defaultArg startIdx 0
        let e = defaultArg endIdx sp.Length
        sp.Slice(s, e - s)

type Span<'T> with
    member sp.GetSlice(startIdx, endIdx) =
        let s = defaultArg startIdx 0
        let e = defaultArg endIdx sp.Length
        sp.Slice(s, e - s)

let printSpan (sp: Span<int>) =
    let arr = sp.ToArray()
    printfn $"{arr}"

let sp = [| 1; 2; 3; 4; 5 |].AsSpan()
printSpan sp[0..] // [|1; 2; 3; 4; 5|]
printSpan sp[..5] // [|1; 2; 3; 4; 5|]
printSpan sp[0..3] // [|1; 2; 3|]
printSpan sp[1..3] // |2; 3|]
```

## Built-in F# slices are end-inclusive

All intrinsic slices in F# are end-inclusive; that is, the upper bound is included in the slice. For a given slice with starting index `x` and ending index `y`, the resulting slice will include the *yth* value.

```fsharp
// Define a new list
let xs = [1 .. 10]

printfn $"{xs[2..5]}" // Includes the 5th index
```

## Built-in F# empty slices

F# lists, arrays, sequences, strings, multidimensional (2D, 3D, 4D) arrays will all produce an empty slice if the syntax could produce a slice that doesn't exist.

Consider the following example:

```fsharp
let l = [ 1..10 ]
let a = [| 1..10 |]
let s = "hello!"

let emptyList = l[-2..(-1)]
let emptyArray = a[-2..(-1)]
let emptyString = s[-2..(-1)]
```

> [!IMPORTANT]
> C# developers may expect these to throw an exception rather than produce an empty slice. This is a
> design decision rooted in the fact that empty collections compose in F#. An empty F# list can be
> composed with another F# list, an empty string can be added to an existing string, and so on. It can
> be common to take slices based on values passed in as parameters, and being tolerant of out-of-bounds > by producing an empty collection fits with the compositional nature of F# code.

## Fixed-index slices for 3D and 4D arrays

For F# 3D and 4D arrays, you can "fix" a particular index and slice other dimensions with that index fixed.

To illustrate this, consider the following 3D array:

*z = 0*

| x\y   | 0 | 1 |
|-------|---|---|
| **0** | 0 | 1 |
| **1** | 2 | 3 |

*z = 1*

| x\y   | 0 | 1 |
|-------|---|---|
| **0** | 4 | 5 |
| **1** | 6 | 7 |

If you want to extract the slice `[| 4; 5 |]` from the array, use a fixed-index slice.

```fsharp
let dim = 2
let m = Array3D.zeroCreate<int> dim dim dim

let mutable count = 0

for z in 0..dim-1 do
    for y in 0..dim-1 do
        for x in 0..dim-1 do
            m[x,y,z] <- count
            count <- count + 1

// Now let's get the [4;5] slice!
m[*, 0, 1]
```

The last line fixes the `y` and `z` indices of the 3D array and takes the rest of the `x` values that correspond to the matrix.

## See also

- [Indexed properties](./members/indexed-properties.md)
