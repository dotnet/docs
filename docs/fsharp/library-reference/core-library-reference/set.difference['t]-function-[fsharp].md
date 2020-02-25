---
title: Set.difference<'T> Function (F#)
description: Set.difference<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d9c27d47-bbb2-4e1b-9295-2fe9e9abdffb 
---

# Set.difference<'T> Function (F#)

Returns a new set with the elements of the second set removed from the first.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Set

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.difference : Set<'T> -> Set<'T> -> Set<'T> (requires comparison)

// Usage:
Set.difference set1 set2
```

#### Parameters
*set1*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The first input set.


*set2*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The set whose elements will be removed from **set1**.

## Return Value

The set with the elements of `set2` removed from `set1`.

## Remarks
This function is named `Difference` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssets/snippet2.fs)]

**Output**

```
Set.difference [2 .. 6] [1 .. 3] yields set [4; 5; 6]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)