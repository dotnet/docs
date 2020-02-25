---
title: Array.toSeq<'T> Function (F#)
description: Array.toSeq<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 50921af5-3b71-4b99-bb38-17fbe4f9c6ac 
---

# Array.toSeq<'T> Function (F#)

Views the given array as a sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.toSeq : 'T [] -> seq<'T>

// Usage:
Array.toSeq array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The sequence of array elements.

## Remarks
This function is named `ToSeq` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.toSeq`.

[!code-fsharp[Main](snippets/fsarrays/snippet69.fs)]

**Output**

```
1 2 3 4 5
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)