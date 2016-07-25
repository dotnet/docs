---
title: Array.append<'T> Function (F#)
description: Array.append<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c85ab263-1d99-4b2d-94d7-f8d2feeea135 
---

# Array.append<'T> Function (F#)

Creates an array that contains the elements of one array followed by the elements of another array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.append : 'T [] -> 'T [] -> 'T []

// Usage:
Array.append array1 array2
```

#### Parameters
*array1*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The first input array.


*array2*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The second input array.

## Return Value

The resulting array.

## Remarks
This function is named `Append` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.append`.

[!code-fsharp[Main](snippets/fsarrays/snippet13.fs)]

```
[|1; 2; 3; 4; 5; 6|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)