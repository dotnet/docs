---
title: List.exists<'T> Function (F#)
description: List.exists<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3f2a4c98-ef04-4ac0-98a6-790e2a1a77ca 
---

# List.exists<'T> Function (F#)

Tests if any element of the list satisfies the given predicate.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.exists : ('T -> bool) -> 'T list -> bool

// Usage:
List.exists predicate list
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

`true` if any element satisfies the predicate. Otherwise, returns `false`.

## Remarks
The predicate is applied to the elements of the input list. If any application returns `true` then the overall result is `true` and no further elements are tested.

This function is named `Exists` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of `List.exists` to determine whether a given element exists in a list.

[!code-fsharp[Main](snippets/fslists/snippet1.fs)]

**Output**

```
For list [0; 1; 2; 3], contains zero is true
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)