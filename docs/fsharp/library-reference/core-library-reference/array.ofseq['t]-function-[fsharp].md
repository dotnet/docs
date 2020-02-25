---
title: Array.ofSeq<'T> Function (F#)
description: Array.ofSeq<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9377670b-bc81-42f9-a27d-fb2456cc3b74 
---

# Array.ofSeq<'T> Function (F#)

Builds a new array from the given enumerable object.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.ofSeq : seq<'T> -> 'T []

// Usage:
Array.ofSeq source
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Return Value

The array of elements from the sequence.

## Remarks
This function is named `OfSeq` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.ofSeq`.

[!code-fsharp[Main](snippets/fsarrays/snippet60.fs)]

**FSI Output**

```
val array1 : int [] = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)