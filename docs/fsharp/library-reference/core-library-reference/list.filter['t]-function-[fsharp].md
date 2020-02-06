---
title: List.filter<'T> Function (F#)
description: List.filter<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d6419861-065a-493c-9b67-08138e2a53ae 
---

# List.filter<'T> Function (F#)

Returns a new collection containing only the elements of the collection for which the given predicate returns `true`.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.filter : ('T -> bool) -> 'T list -> 'T list

// Usage:
List.filter predicate list
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

A list containing only the elements that satisfy the predicate.

## Remarks

This function is named `Filter` in compiled assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet24.fs)]

### Output

```
The resulting list is [2; 4; 6].****The following example shows another typical use for List.filter.
```

[!code-fsharp[Main](snippets/fssamples101/snippet3007.fs)]

### Output

```
Animals with short names: [("Cats", 4); ("Dogs", 5); ("Mice", 3)]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)