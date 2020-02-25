---
title: Array.unzip<'T1,'T2> Function (F#)
description: Array.unzip<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 10f2403a-e104-4942-843c-1c8dc796d3dd 
---

# Array.unzip<'T1,'T2> Function (F#)

Splits an array of pairs into two arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.unzip : ('T1 * 'T2) [] -> 'T1 [] * 'T2 []

// Usage:
Array.unzip array
```

#### Parameters
*array*
Type: **('T1 &#42; 'T2)**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The two arrays.

## Remarks
This function is named `Unzip` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.unzip`.

[!code-fsharp[Main](snippets/fsarrays/snippet70.fs)]

**Output**

```
[|1; 3|]
[|2; 4|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)