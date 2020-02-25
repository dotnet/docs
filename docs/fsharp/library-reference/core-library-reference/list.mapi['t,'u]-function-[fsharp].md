---
title: List.mapi<'T,'U> Function (F#)
description: List.mapi<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 169eef6e-3ce2-491d-b94f-3135fb9a8585 
---

# List.mapi<'T,'U> Function (F#)

Creates a new collection whose elements are the results of applying the given function to each of the elements of the collection. The integer index passed to the function indicates the index (from 0) of element being transformed.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.mapi : (int -> 'T -> 'U) -> 'T list -> 'U list

// Usage:
List.mapi mapping list
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt; 'U**


The function to transform elements and their indices.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The list of transformed elements.

## Remarks
This function is named `MapIndexed` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet36.fs)]

**Output**

```
[(0, 1); (1, 2); (2, 3)]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)