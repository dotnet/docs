---
title: Set.isSubset<'T> Function (F#)
description: Set.isSubset<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c79b8c17-00cd-4492-944d-554c79cd47a2 
---

# Set.isSubset<'T> Function (F#)

Evaluates to `true` if all elements of the first set are in the second.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Set

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.isSubset : Set<'T> -> Set<'T> -> bool (requires comparison)

// Usage:
Set.isSubset set1 set2
```

#### Parameters
*set1*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The potential subset.


*set2*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The set to test against.

## Return Value

`true` if `set1` is a subset of `set2`.

## Remarks
This function is named `IsSubset` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssets/snippet11.fs)]

**Output**

```
set [1; 2; 3; 4; 5] is a subset of set [1; 2; 3; 4; 5; 6]: true
set [1; 2; 3; 4; 5; 6] is a subset of set [1; 2; 3; 4; 5; 6]: true
set [5; 6; 7; 8; 9; 10] is a subset of set [1; 2; 3; 4; 5; 6]: false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)