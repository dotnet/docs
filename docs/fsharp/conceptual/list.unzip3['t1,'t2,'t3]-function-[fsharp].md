---
title: List.unzip3<'T1,'T2,'T3> Function (F#)
description: List.unzip3<'T1,'T2,'T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 444a5275-19fe-43d1-a40b-a0c2e65c8041 
---

# List.unzip3<'T1,'T2,'T3> Function (F#)

Splits a list of triples into three lists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.unzip3 : ('T1 * 'T2 * 'T3) list -> 'T1 list * 'T2 list * 'T3 list

// Usage:
List.unzip3 list
```

#### Parameters
*list*
Type: **('T1 &#42; 'T2 &#42; 'T3)**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

Three lists of split elements.

## Remarks
This function is named `Unzip3` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet39.fs)]

**Output**

```
[1; 4] [2; 5] [3; 6]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)