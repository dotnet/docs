---
title: Array.partition<'T> Function (F#)
description: Array.partition<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a864c5fc-513c-467b-9d60-72ed7124941f 
---

# Array.partition<'T> Function (F#)

Splits the collection into two collections, containing the elements for which the given predicate returns **true** and **false** respectively.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.partition : ('T -> bool) -> 'T [] -> 'T [] * 'T []

// Usage:
Array.partition predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

A pair of arrays. The first containing the elements the predicate for which the predicate evaluated to `true`, and the second containing those for which the predicate evaluated to `false`.

## Remarks
This function is named `Partition` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of Array.partition.

[!code-fsharp[Main](snippets/fsarrays/snippet33.fs)]

**Output**

```
[|51; 52; 53; 54; 55; 56; 57; 58; 59|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)