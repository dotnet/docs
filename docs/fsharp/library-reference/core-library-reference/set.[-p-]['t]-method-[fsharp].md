---
title: Set.( + )<'T> Method (F#)
description: Set.( + )<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 618d3a20-0bee-4d6d-83c3-3bf2186e1e4a 
---

# Set.( + )<'T> Method (F#)

Compute the union of the two sets.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member ( + ) : Set<'T> * Set<'T> -> Set<'T> (requires comparison)

// Usage:
set1 + set2
```

#### Parameters
*set1*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The first input set.


*set2*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The second input set.

## Return Value

The union of the two input sets.

## Example

The following code illustrates the use of the `+` and `-` operators on sets.

[!code-fsharp[Main](snippets/fssets/snippet1.fs)]

**Output**

```
set1: set [1; 2; 3]
set2: set [4; 5; 6]
set3 = set1 + set2: set [1; 2; 3; 4; 5; 6]
set3 - set1: set [4; 5; 6
set3 - set2: set [1; 2; 3]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set&#60;'T&#62; Class &#40;F&#35;&#41;](Collections.Set%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)