---
title: Set.isSuperset<'T> Function (F#)
description: Set.isSuperset<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1b1389a9-4eaa-433c-9837-2bf128957954 
---

# Set.isSuperset<'T> Function (F#)

Evaluates to `true` if all elements of the second set are in the first.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Set

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.isSuperset : Set<'T> -> Set<'T> -> bool (requires comparison)

// Usage:
Set.isSuperset set1 set2
```

#### Parameters
*set1*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The potential superset.


*set2*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The set to test against.

## Return Value

`true` if set1 is a superset of set2. Otherwise, returns `false`.

## Remarks

This function is named `IsSuperset` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssets/snippet13.fs)]

**Output**

```
set [1; 2; 3; 4; 5; 6; 7; 8; 9] is a superset of set [1; 2; 3; 4; 5; 6]: true
set [1; 2; 3; 4; 5; 6] is a superset of set [1; 2; 3; 4; 5; 6]: true
set [5; 6; 7; 8; 9; 10] is a superset of set [1; 2; 3; 4; 5; 6]: false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)