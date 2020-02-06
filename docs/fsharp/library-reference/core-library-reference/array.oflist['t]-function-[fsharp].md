---
title: Array.ofList<'T> Function (F#)
description: Array.ofList<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2c66adcc-c71c-41dd-a5a8-76cd3e07694c 
---

# Array.ofList<'T> Function (F#)

Builds an array from the given list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.ofList : 'T list -> 'T []

// Usage:
Array.ofList list
```

#### Parameters
*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The array of elements from the list.

## Remarks
This function is named `OfList` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example demonstrates the use of `Array.ofList`.

[!code-fsharp[Main](snippets/fsarrays/snippet59.fs)]

**FSI Output**

```
val array1 : int [] = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)