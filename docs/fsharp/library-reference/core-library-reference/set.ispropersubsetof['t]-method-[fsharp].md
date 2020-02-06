---
title: Set.IsProperSubsetOf<'T> Method (F#)
description: Set.IsProperSubsetOf<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ce3cbdd8-3617-4725-abb6-d447dabc5fea 
---

# Set.IsProperSubsetOf<'T> Method (F#)

Evaluates to `true` if all elements of the first set are in the second, and at least one element of the second is not in the first.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.IsProperSubsetOf : Set<'T> -> bool (requires comparison)

// Usage:
set.IsProperSubsetOf (otherSet)
```

#### Parameters
*otherSet*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The set to test against.

## Return Value

`true` if this set is a proper subset of otherSet. Otherwise, returns `false`.

## Example

[!code-fsharp[Main](snippets/fssets/snippet6.fs)]

**Output**

```
set [1; 2; 3; 4; 5] is a proper subset of set [1; 2; 3; 4; 5; 6]: true
set [1; 2; 3; 4; 5; 6] is a proper subset of set [1; 2; 3; 4; 5; 6]: false
set [5; 6; 7; 8; 9; 10] is a proper subset of set [1; 2; 3; 4; 5; 6]: false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set&#60;'T&#62; Class &#40;F&#35;&#41;](Collections.Set%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)