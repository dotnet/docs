---
title: GeneratedSequenceBase.GetFreshEnumerator<'T> Method (F#)
description: GeneratedSequenceBase.GetFreshEnumerator<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d0b98e02-0b8d-4d29-9fe5-265d19edbf68 
---

# GeneratedSequenceBase.GetFreshEnumerator<'T> Method (F#)

The F# compiler emits implementations of this type for compiled sequence expressions.

**Namespace/Module Path:** Microsoft.FSharp.Core.CompilerServices

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GetFreshEnumerator : unit -> IEnumerator<'T>

// Usage:
generatedSequenceBase.GetFreshEnumerator ()
```

## Return Value

A new enumerator for the sequence.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[CompilerServices.GeneratedSequenceBase&#60;'T&#62; Class &#40;F&#35;&#41;](CompilerServices.GeneratedSequenceBase%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)