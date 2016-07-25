---
title: Seq.empty<'T> Type Function (F#)
description: Seq.empty<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bfc63bc2-572d-43af-a298-7348fc2d8413
---

# Seq.empty<'T> Type Function (F#)

Creates an empty sequence.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.empty<'T> :  seq<'T>

// Usage:
Seq.empty
```

## Return Value

An empty sequence.

## Remarks
This function is named `Empty` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssequences/snippet32.fs)]

**F# Interactive Output**

```
val emptySeq1 : seq<'a>val emptySeq2 : seq<string>
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
