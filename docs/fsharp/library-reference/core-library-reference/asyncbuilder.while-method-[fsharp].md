---
title: AsyncBuilder.While Method (F#)
description: AsyncBuilder.While Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 271e6da4-5a06-455e-8933-d513c4c89e55 
---

# AsyncBuilder.While Method (F#)

Implements the `while` keyword in asynchronous computation expressions.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.While : (unit -> bool) * Async<unit> -> Async<unit>

// Usage:
asyncBuilder.While (guard, computation)
```

#### Parameters
*guard*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to determine when to stop executing `computation`.


*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**&gt;**


The function to be executed. Equivalent to the body of a `while` expression.

## Return Value

An asynchronous computation that behaves similarly to a while loop when run.

## Remarks
Creates an asynchronous computation that runs `computation` repeatedly until `guard` evaluates to `false`.

A cancellation check is performed whenever the computation is executed. The existence of this method permits the use of `while` in the `async { ... }` computation expression syntax.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)