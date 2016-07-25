---
title: Array.sortBy<'T,'Key> Function (F#)
description: Array.sortBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0422e286-0dfe-4477-bb1f-d9741914f33b 
---

# Array.sortBy<'T,'Key> Function (F#)

Sorts the elements of an array, using the given projection for the keys and returning a new array. Elements are compared using [Operators.compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.sortBy : ('T -> 'Key) -> 'T [] -> 'T [] (requires comparison)

// Usage:
Array.sortBy projection array
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**


The function to transform array elements into the type that is compared.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The sorted array.

## Remarks
This is not a stable sort, that is, the original order of equal elements is not necessarily preserved. For a stable sort, consider using [Seq.sort](https://msdn.microsoft.com/library/327ea595-e77c-4529-b61e-8c6cbf5ec92e).

This function is named `SortBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of `Array.sortBy`.

[!code-fsharp[Main](snippets/fsarrays/snippet38.fs)]

**Output**

```
[|1; -2; 4; 5; 8|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)