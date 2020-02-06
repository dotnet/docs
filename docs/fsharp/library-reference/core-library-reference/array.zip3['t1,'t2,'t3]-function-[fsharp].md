---
title: Array.zip3<'T1,'T2,'T3> Function (F#)
description: Array.zip3<'T1,'T2,'T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a8d77585-9382-4fa8-9839-0cb53d478704 
---

# Array.zip3<'T1,'T2,'T3> Function (F#)

Combines three arrays into an array of tuples with three elements. The three arrays must have equal lengths, otherwise an **System.ArgumentException** is raised.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.zip3 : 'T1 [] -> 'T2 [] -> 'T3 [] -> ('T1 * 'T2 * 'T3) []

// Usage:
Array.zip3 array1 array2 array3
```

#### Parameters
*array1*
Type: **'T1**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T2**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

*array3*
Type: **'T3**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The third input array.

## Return Value

Returns the array of tupled elements.

## Remarks
This function is named `Zip3` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.zip3`.

[!code-fsharp[Main](snippets/fsarrays/snippet73.fs)]

**Output**

```
[|(1, -1, "horse"); (2, -2, "dog"); (3, -3, "elephant")|]
```
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)