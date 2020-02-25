---
title: Array.forall<'T> Function (F#)
description: Array.forall<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2572a176-a7a5-4ec5-8ffc-e3b2bf68c631 
---

# Array.forall<'T> Function (F#)

Tests if all elements of the array satisfy the given predicate.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.forall : ('T -> bool) -> 'T [] -> bool

// Usage:
Array.forall predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Result Value

`true` if all of the array elements satisfy the predicate. Otherwise, returns `false`.

## Remarks
The predicate is applied to the elements of the input collection. If any application returns `false` then the overall result is `false` and no further elements are tested.

This function is named `ForAll` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example shows the use of `Array.forall` to test the elements of an array.

[!code-fsharp[Main](snippets/fsarrays/snippet241.fs)]

```
false
true
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)