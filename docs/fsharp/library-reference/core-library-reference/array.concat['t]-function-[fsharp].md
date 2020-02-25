---
title: Array.concat<'T> Function (F#)
description: Array.concat<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3562e369-3dd9-4687-988f-63bf729360bb 
---

# Array.concat<'T> Function (F#)

Builds a new array that contains the elements of each of the given sequence of arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.concat : seq<'T []> -> 'T []

// Usage:
Array.concat arrays
```

#### Parameters
*arrays*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)**&gt;**


The input sequence of arrays.


## Return Value

The concatenation of the sequence of input arrays.

## Remarks
This function is named `Concat` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates the use of Array.concat.

[!code-fsharp[Main](snippets/fsarrays/snippet16.fs)]

**Output:**

```
[|0; 1; 2; 3; 4|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)