---
title: FuncConvert.ToFSharpFunc<'T,'U> Method (F#)
description: FuncConvert.ToFSharpFunc<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a9d5846f-ce77-4d61-a64d-242d89bfbb69 
---

# FuncConvert.ToFSharpFunc<'T,'U> Method (F#)

Convert the given `System.Converter` delegate object to an F# function value.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member ToFSharpFunc : Converter<'T,'U> -> 'T -> 'U

// Usage:
FuncConvert.ToFSharpFunc (converter)
```

#### Parameters
*converter*
Type: **System.Converter&#96;2****&lt;'T,'U&gt;**


The input Converter.

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