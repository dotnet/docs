---
title: Array.min<'T> Function (F#)
description: Array.min<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3bce9862-a6a3-4a4d-9193-3a5f14fdfe37 
---

# Array.min<'T> Function (F#)

Returns the lowest of all elements of the array, compared by using [Operators.min](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed).

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.min : 'T [] -> 'T (requires comparison)

// Usage:
Array.min array
```

#### Parameters

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

Returns the minimum element.

## Remarks

This function is named `Min` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Array.min`.

[!code-fsharp[Main](snippets/fsarrays/snippet57.fs)]

**Output**

```
-4
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)