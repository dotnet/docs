---
title: Seq.map<'T,'U> Function (F#)
description: Seq.map<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bdb4ebcd-5ba1-43b3-85d8-6e97a58e08d2
---

# Seq.map<'T,'U> Function (F#)

Creates a new collection whose elements are the results of applying the given function to each of the elements of the collection. The given function will be applied as elements are demanded using the `MoveNext` method on enumerators retrieved from the object.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.map : ('T -> 'U) -> seq<'T> -> seq<'U>

// Usage:
Seq.map mapping source
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


A function to transform items from the input sequence.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value
The result sequence.

## Example

```fsharp
// initial sequence
let simpleSeq = seq { for x in 1 .. 5 -> x }

// mapping function to initial sequence. Notice that the function applied by map can return any data type to the new sequence.
let xTimes2 =
  simpleSeq
  |> Seq.map(fun x -> sprintf "x * 2 = %i" (x * 2) )


printfn "simpleSeq: %A" simpleSeq
printfn "xTimes2: %A" xTimes2

// The result is...
simpleSeq: seq [1; 2; 3; 4; ...]
xTimes2: seq ["x * 2 = 2"; "x * 2 = 4"; "x * 2 = 6"; "x * 2 = 8"; ...]
```

## Remarks
The returned sequence may be passed between threads safely. However, individual `IEnumerator` values generated from the returned sequence should not be accessed concurrently.

This function is named `Map` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
