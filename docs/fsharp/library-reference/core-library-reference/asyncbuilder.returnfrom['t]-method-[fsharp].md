---
title: AsyncBuilder.ReturnFrom<'T> Method (F#)
description: AsyncBuilder.ReturnFrom<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a5ef34ab-86f1-4222-befa-b890f8873e2d 
---

# AsyncBuilder.ReturnFrom<'T> Method (F#)

Implements the `return!` keyword for asynchronous computations. This function delegates to the input computation.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.ReturnFrom : Async<'T> -> Async<'T>

// Usage:
asyncBuilder.ReturnFrom (computation)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The input computation.

## Return Value

The input computation.

## Remarks
The existence of this method permits the use of `return!` in the `async { ... }` computation expression syntax.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)