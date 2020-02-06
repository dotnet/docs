---
title: Array.copy<'T> Function (F#)
description: Array.copy<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 84115a0a-923a-4d0e-99e8-785f3cc51520 
---

# Array.copy<'T> Function (F#)

Builds a new array that contains the elements of the given array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.copy : 'T [] -> 'T []

// Usage:
Array.copy array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

A copy of the input array.

## Remarks
This function is named `Copy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of `Array.copy`.

[!code-fsharp[Main](snippets/fsarrays/snippet31.fs)]

**Output**

```
[|1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
[|1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

