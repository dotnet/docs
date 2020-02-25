---
title: Set.intersectMany<'T> Function (F#)
description: Set.intersectMany<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6cc10ecb-99a5-4e45-8d2b-ff5716ee0e31 
---

# Set.intersectMany<'T> Function (F#)

Computes the intersection of a sequence of sets. The sequence must be non-empty.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Set

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.intersectMany : seq<Set<'T>> -> Set<'T> (requires comparison)

// Usage:
Set.intersectMany sets
```

#### Parameters
*sets*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;**[Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;&gt;**


The sequence of sets to intersect.

## Return Value

The intersection of the input sets.

## Remarks

This function is named `IntersectMany` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssets/snippet5.fs)]

**Output**

```
Numbers between 1 and 10,000 that are divisible by
all the numbers from 1 to 9:
set [2520; 5040; 7560]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)