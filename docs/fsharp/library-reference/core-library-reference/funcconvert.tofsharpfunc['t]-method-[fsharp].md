---
title: FuncConvert.ToFSharpFunc<'T> Method (F#)
description: FuncConvert.ToFSharpFunc<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e309d96c-65ed-4ae2-a8a1-3e43529647c8 
---

# FuncConvert.ToFSharpFunc<'T> Method (F#)

Convert the given `System.Action` delegate object to an F# function value.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member ToFSharpFunc : Action<'T> -> 'T -> unit

// Usage:
FuncConvert.ToFSharpFunc (action)
```

#### Parameters
*action*
Type: **System.Action&#96;1****&lt;'T&gt;**


The input action.

## Return Value

The F# function.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.FuncConvert Class &#40;F&#35;&#41;](Core.FuncConvert-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)