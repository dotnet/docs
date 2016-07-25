---
title: List.partition<'T> Function (F#)
description: List.partition<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b568578a-4f7a-4fd0-a830-bc78537666e0 
---

# List.partition<'T> Function (F#)

Splits the collection into two collections, containing the elements for which the given predicate returns `true` and `false` respectively.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.partition : ('T -> bool) -> 'T list -> 'T list * 'T list

// Usage:
List.partition predicate list
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

A list containing the elements for which the predicate evaluated to `false` and a list containing the elements for which the predicate evaluated to `true`.

## Remarks
This function is named `Partition` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet50.fs)]

**Output**

```
Evens: [2; 4; 6; 8; 10]
Odds: [1; 3; 5; 7; 9]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)