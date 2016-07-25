---
title: Array.collect<'T,'U> Function (F#)
description: Array.collect<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f41eacb5-76ba-46d9-9a12-0c1ae631fedc 
---

# Array.collect<'T,'U> Function (F#)

For each element of the array, applies the given function. Concatenates all the results and return the combined array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.collect : ('T -> 'U []) -> 'T [] -> 'U []

// Usage:
Array.collect mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The function to create sub-arrays from the input array elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value
The concatenation of the subarrays.

## Remarks
This function is named `Collect` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code demonstrates the use of `Array.collect` to concatenate subarrays that are generated from each array element.

[!code-fsharp[Main](snippets/fsarrays/snippet15.fs)]

```
[|0; 1; 0; 1; 2; 3; 4; 5; 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)