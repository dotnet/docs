---
title: Array.tryFind<'T> Function (F#)
description: Array.tryFind<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: befdb684-b907-4640-910c-50a41f0da614 
---

# Array.tryFind<'T> Function (F#)

Returns the first element for which the given function returns `true`. Return `None` if no such element exists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.tryFind : ('T -> bool) -> 'T [] -> 'T option

// Usage:
Array.tryFind predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Return Value

The first element that satisfies the predicate, or None.

## Remarks
This function is named `TryFind` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.tryFind` to attempt to locate array elements that are both perfect cubes and perfect squares.

[!code-fsharp[Main](snippets/fsarrays/snippet26.fs)]

```
Found an element: 1
Found an element: 729
Failed to find a matching element.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)