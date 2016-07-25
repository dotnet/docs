---
title: Array.findIndex<'T> Function (F#)
description: Array.findIndex<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 32c37f7f-32f4-47fd-95c7-78e8a85045ed 
---

# Array.findIndex<'T> Function (F#)

Returns the index of the first element in the array that satisfies the given predicate. Raise [KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx) if none of the elements satisfy the predicate.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.findIndex : ('T -> bool) -> 'T [] -> int

// Usage:
Array.findIndex predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

The function to test the input elements.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

The index of the first element in the array that satisfies the given predicate.

## Remarks
This function is named `FindIndex` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.find` and `Array.findIndex` to identify the first integer greater than 1 that is both a square and a cube.

[!code-fsharp[Main](snippets/fsarrays/snippet25.fs)]

```
The first element that is both a square and a cube is 64 and its index is 62.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Array.find&#60;'T&#62; Function &#40;F&#35;&#41;](Array.find%5B%27T%5D-Function-%5BFSharp%5D.md)