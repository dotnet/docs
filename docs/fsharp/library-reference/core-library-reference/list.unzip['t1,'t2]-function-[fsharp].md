---
title: List.unzip<'T1,'T2> Function (F#)
description: List.unzip<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 61017b2d-80d5-4999-af4e-5b1b587d957a 
---

# List.unzip<'T1,'T2> Function (F#)

Splits a list of pairs into two lists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.unzip : ('T1 * 'T2) list -> 'T1 list * 'T2 list

// Usage:
List.unzip list
```

#### Parameters
*list*
Type: (**'T1 &#42; 'T2)**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

Two lists of split elements.

## Remarks
This function is named `Unzip` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet38.fs)]

**Output**

```
[1; 3][2; 4]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)