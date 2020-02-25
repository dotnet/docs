---
title: Seq.ofList<'T> Function (F#)
description: Seq.ofList<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cae7efb1-54ba-4c98-b219-8badd20e104a
---

# Seq.ofList<'T> Function (F#)

Views the given list as a sequence.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.ofList : 'T list -> seq<'T>

// Usage:
Seq.ofList source
```

#### Parameters
*source*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The result sequence.

## Remarks
This function is named `OfList` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Example

[!code-fsharp[Main](snippets/fssequences/snippet61.fs)]

**F# Interactive Output**

```
val seq1 : seq<string> = ["0"; "1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
