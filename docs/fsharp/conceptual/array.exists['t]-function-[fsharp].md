---
title: Array.exists<'T> Function (F#)
description: Array.exists<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c555dd2b-55af-457e-bd0d-8066fc7dac6c 
---

# Array.exists<'T> Function (F#)

Tests if any element of the array satisfies the given predicate.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.exists : ('T -> bool) -> 'T [] -> bool

// Usage:
Array.exists predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Return Value

`true` if any result from predicate is true. Otherwise, `false`.
## Remarks
The predicate is applied to the elements of the input array. If any application returns `true` then the overall result is `true` and no further elements are tested.

This function is named `Exists` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates how to test the elements of an array by using Array.exists.

[!code-fsharp[Main](snippets/fsarrays/snippet231.fs)]

```
true
false
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)