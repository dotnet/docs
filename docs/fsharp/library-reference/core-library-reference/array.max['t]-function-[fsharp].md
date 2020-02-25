---
title: Array.max<'T> Function (F#)
description: Array.max<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b2bece1e-efc4-4921-bf3c-f001e6bea48a 
---

# Array.max<'T> Function (F#)

Returns the greatest of all elements of the array, compared by using [Operators.max](https://msdn.microsoft.com/library/9a988328-00e9-467b-8dfa-e7a6990f6cce) on the function result.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.max : 'T [] -> 'T (requires comparison)

// Usage:
Array.max array
```

#### Parameters

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

Returns the maximum element.

## Remarks

This function is named `Max` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example demonstrates how to use Array.max.

[!code-fsharp[Main](snippets/fsarrays/snippet55.fs)]

**Output**

```
4
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)