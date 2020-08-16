---
title: Slices
description: Learn how to use slices for existing F# data types and how to define your own slices for other data types.
ms.date: 12/23/2019
---
# Slices

In F#, a slice is a subset of any data type that has a `GetSlice` method in its definition or in an in-scope [type extension](type-extensions.md). It is most commonly used with F# arrays and lists. This article explains how to take slices from existing F# types and how to define your own slices.

Slices are similar to [indexers](./members/indexed-properties.md), but instead of yielding a single value from the underlying data structure, they yield multiple ones.

F# currently has intrinsic support for slicing strings, lists, arrays, and 2D arrays.

## Basic slicing with F# lists and arrays

The most common data types that are sliced are F# lists and arrays. The following example demonstrates how to do this with lists:

```fsharp
// Generate a list of 100 integers
let fullList = [ 1 .. 100 ]

// Create a slice from indices 1-5 (inclusive)
let smallSlice = fullList.[1..5]
printfn "Small slice: %A" smallSlice

// Create a slice from the beginning to index 5 (inclusive)
let unboundedBeginning = fullList.[..5]
printfn "Unbounded beginning slice: %A" unboundedBeginning

// Create a slice from an index to the end of the list
let unboundedEnd = fullList.[94..]
printfn "Unbounded end slice: %A" unboundedEnd
```

Slicing arrays is just like slicing lists:

```fsharp
// Generate an array of 100 integers
let fullArray = [| 1 .. 100 |]

// Create a slice from indices 1-5 (inclusive)
let smallSlice = fullArray.[1..5]
printfn "Small slice: %A" smallSlice

// Create a slice from the beginning to index 5 (inclusive)
let unboundedBeginning = fullArray.[..5]
printfn "Unbounded beginning slice: %A" unboundedBeginning

// Create a slice from an index to the end of the list
let unboundedEnd = fullArray.[94..]
printfn "Unbounded end slice: %A" unboundedEnd
```

## Slicing multidimensional arrays

F# supports multidimensional arrays in the F# core library. As with one-dimensional arrays, slices of multidimensional arrays can also be useful. However, the introduction of additional dimensions mandates a slightly different syntax so that you can take slices of specific rows and columns.

The following examples demonstrate how to slice a 2D array:

```fsharp
// Generate a 3x3 2D matrix
let A = array2D [[1;2;3];[4;5;6];[7;8;9]]
printfn "Full matrix:\n %A" A

// Take the first row
let row0 = A.[0,*]
printfn "Row 0: %A" row0

// Take the first column
let col0 = A.[*,0]
printfn "Column 0: %A" col0

// Take all rows but only two columns
let subA = A.[*,0..1]
printfn "%A" subA

// Take two rows and all columns
let subA' = A.[0..1,*]
printfn "%A" subA'

// Slice a 2x2 matrix out of the full 3x3 matrix
let twoByTwo = A.[0..1,0..1]
printfn "%A" twoByTwo
```

The F# core library does not currently define `GetSlice` for 3D arrays. If you wish to slice 3D arrays or other arrays of more dimensions, define the `GetSlice` member yourself.

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
let slice = arr.[2..5] //[ 3; 4; 5]
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
    printfn "%A" arr

let sp = [| 1; 2; 3; 4; 5 |].AsSpan()
printSpan sp.[0..] // [|1; 2; 3; 4; 5|]
printSpan sp.[..5] // [|1; 2; 3; 4; 5|]
printSpan sp.[0..3] // [|1; 2; 3|]
printSpan sp.[1..3] // |2; 3|]
```

## Built-in F# slices are end-inclusive

All intrinsic slices in F# are end-inclusive; that is, the upper bound is included in the slice. For a given slice with starting index `x` and ending index `y`, the resulting slice will include the *yth* value.

```fsharp
// Define a new list
let xs = [1 .. 10]

printfn "%A" xs.[2..5] // Includes the 5th index
```

## See also

- [Indexed properties](./members/indexed-properties.md)
