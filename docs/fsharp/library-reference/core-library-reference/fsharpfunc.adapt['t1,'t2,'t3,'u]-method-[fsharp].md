---
title: FSharpFunc.Adapt<'T1,'T2,'T3,'U> Method (F#)
description: FSharpFunc.Adapt<'T1,'T2,'T3,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6c985ba9-873e-47ce-9574-6e65f135f3ed 
---

# FSharpFunc.Adapt<'T1,'T2,'T3,'U> Method (F#)

Adapt an F# first class function value to be an optimized function value that can accept three curried arguments without intervening execution.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member FSharpFunc.Adapt : ('T1 -> 'T2 -> 'T3 -> 'U) -> FSharpFunc<'T1,'T2,'T3,'U>

// Usage:
FSharpFunc.Adapt (func)
```

#### Parameters
*func*
Type: **'T1 -&gt; 'T2 -&gt; 'T3 -&gt; 'U**


The input function.

## Return Value

The adapted function.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[OptimizedClosures.FSharpFunc&#60;'T1,'T2,'T3,'U&#62; Class &#40;F&#35;&#41;](OptimizedClosures.FSharpFunc%5B%27T1%2C%27T2%2C%27T3%2C%27U%5D-Class-%5BFSharp%5D.md)

[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)