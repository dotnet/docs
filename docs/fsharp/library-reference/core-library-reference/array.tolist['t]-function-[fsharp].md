---
title: Array.toList<'T> Function (F#)
description: Array.toList<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d2325256-890a-4df5-992a-c1c6199ff163 
---

# Array.toList<'T> Function (F#)

Builds a list from the given array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.toList : 'T [] -> 'T list

// Usage:
Array.toList array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The list of array elements.

## Remarks
This function is named `ToList` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Return Value

The following code example shows how to use `Array.toList`.

[!code-fsharp[Main](snippets/fsarrays/snippet68.fs)]

**Output**

```
10 9 8 7 6 5 4 3 2 1
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)