---
title: Array.forall2<'T1,'T2> Function (F#)
description: Array.forall2<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1a0e85d9-c390-46f3-a3e3-c53de121f639 
---

# Array.forall2<'T1,'T2> Function (F#)

Tests if all corresponding elements of the array satisfy the given predicate pairwise.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.forall2 : ('T1 -> 'T2 -> bool) -> 'T1 [] -> 'T2 [] -> bool

// Usage:
Array.forall2 predicate array1 array2
```

#### Parameters
*predicate*
Type: **'T1 -&gt; 'T2 -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

The function to test the input elements.

*array1*
Type: **'T1**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T2**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

## Return Value

`true` if all of the array elements satisfy the predicate. Otherwise, returns `false`.

## Remarks
The predicate is applied to matching elements in the two collections up to the lesser of the two lengths of the collections. If any application returns `false` then the overall result is `false` and no further elements are tested. Otherwise, if one collection is longer than the other, then the [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx) exception is raised.

This function is named `ForAll2` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example shows the use of `Array.forall2` to test the equality of all the elements in two arrays.

[!code-fsharp[Main](snippets/fsarrays/snippet242.fs)]

```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)