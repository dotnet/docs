---
title: FSharpFunc.Invoke<'T1,'T2,'T3,'T4,'U> Method (F#)
description: FSharpFunc.Invoke<'T1,'T2,'T3,'T4,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 23b69067-a675-4dcd-aea1-55b55694b9a8 
---

# FSharpFunc.Invoke<'T1,'T2,'T3,'T4,'U> Method (F#)

Invoke an F# first class function value that accepts four curried arguments without intervening execution.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.Invoke : FSharpFunc<'T1,'T2,'T3,'T4,'U> -> 'T1 * 'T2 * 'T3 * 'T4 -> 'U

// Usage:
fSharpFunc.Invoke (arg1, arg2, arg3, arg4)
```

#### Parameters
*arg1*
Type: **'T1**


The first argument.


*arg2*
Type: **'T2**


The second argument.


*arg3*
Type: **'T3**


The third argument.


*arg4*
Type: **'T4**


The fourth argument.

## Return Value

The function result.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[OptimizedClosures.FSharpFunc&#60;'T1,'T2,'T3,'T4,'U&#62; Class &#40;F&#35;&#41;](OptimizedClosures.FSharpFunc%5B%27T1%2C%27T2%2C%27T3%2C%27T4%2C%27U%5D-Class-%5BFSharp%5D.md)

[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)