---
title: Array.get<'T> Function (F#)
description: Array.get<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 44d9945e-fd86-4535-9d29-54ba0c129eb8 
---

# Array.get<'T> Function (F#)

Gets an element from an array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.get : 'T [] -> int -> 'T

// Usage:
Array.get array index
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The input index.

## Return value

The value of the array at the given index.

## Remarks
This function is named `Get` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates creating, setting and getting array values.

[!code-fsharp[Main](snippets/fsarrays/snippet9.fs)]

```
0 1 2 3 4 5 6 7 8 9
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)