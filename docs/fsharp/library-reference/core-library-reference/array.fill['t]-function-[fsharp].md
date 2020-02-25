---
title: Array.fill<'T> Function (F#)
description: Array.fill<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 28945224-b757-4a9c-8bd0-661ef6599f95 
---

# Array.fill<'T> Function (F#)

Fills a range of elements of the array with the given value.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.fill : 'T [] -> int -> int -> 'T -> unit

// Usage:
Array.fill target targetIndex count value
```

#### Parameters
*target*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The target array.


*targetIndex*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index of the first element to set.


*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The number of elements to set.


*value*
Type: **'T**


The value to set.


## Remarks
This function is named `Fill` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates the use of Array.fill to overwrite a section of an array with zeroes.

[!code-fsharp[Main](snippets/fsarrays/snippet28.fs)]

```
[|1; 2; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 23; 24; 25|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)