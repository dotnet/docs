---
title: Array.blit<'T> Function (F#)
description: Array.blit<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1b234cc2-dbd1-4330-b6f1-3ffc0ad5ed75 
---

# Array.blit<'T> Function (F#)

Reads a range of elements from the first array and writes them into the second.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.blit : 'T [] -> int -> 'T [] -> int -> int -> unit

// Usage:
Array.blit source sourceIndex target targetIndex count
```

#### Parameters
*source*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The source array.


*sourceIndex*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The starting index of the source array.


*target*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The target array.


*targetIndex*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The starting index of the target array.


*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The number of elements to copy.


## Remarks
This function is named `CopyTo` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code example illustrates the use of Array.blit.

[!code-fsharp[Main](snippets/fsarrays/snippet30.fs)]

**Output**

```
[|0; 0; 0; 0; 0; 4; 5; 6; 7; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)