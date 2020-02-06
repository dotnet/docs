---
title: FSharpFunc.ToConverter<'T,'U> Method (F#)
description: FSharpFunc.ToConverter<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a8bd65d7-9275-4afa-a7bd-033d733500ef 
---

# FSharpFunc.ToConverter<'T,'U> Method (F#)

Convert an F# first class function value to a value of type `System.Converter`.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member ToConverter : ('T -> 'U) -> Converter<'T,'U>

// Usage:
FSharpFunc.ToConverter (func)
```

#### Parameters
*func*
Type: **'T -&gt; 'U**


The input function.

## Return Value

An instance of `System.Converter` that represents the input function.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Core.FSharpFunc&#60;'T,'U&#62; Class &#40;F&#35;&#41;](Core.FSharpFunc%5B%27T%2C%27U%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)