---
title: Async.Catch<'T> Method (F#)
description: Async.Catch<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9f208628-4d06-41a4-a2b6-c6586edbd6b4 
---

# Async.Catch<'T> Method (F#)

Creates an asynchronous computation that executes a specified computation. If this computation completes successfully, then this method returns `Choice1Of2` with the returned value. If this computation raises an exception before it completes then return `Choice2Of2` with the raised exception.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Catch : Async<'T> -> Async<Choice<'T,exn>>

// Usage:
Async.Catch (computation)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The input computation that returns the type 'T.

**A computation that returns a [Choice](https://msdn.microsoft.com/library/2ab2513e-e307-4360-96cd-8b682a8d64f0) of type 'T or an exception.**
## Remarks

## Example

The following code example shows how to use `Async.Catch` to run an asynchronous computation that might throw an exception.

[!code-fsharp[Main](snippets/fscorelib1/snippet1002.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)