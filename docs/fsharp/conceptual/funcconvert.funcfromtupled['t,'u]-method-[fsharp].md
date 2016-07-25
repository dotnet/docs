---
title: FuncConvert.FuncFromTupled<'T,'U> Method (F#)
description: FuncConvert.FuncFromTupled<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1403b2d5-d6ab-461a-b793-a8fa862e4e7d 
---

# FuncConvert.FuncFromTupled<'T,'U> Method (F#)

A utility function to convert function values from tupled to curried form.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
static member FuncConvert.FuncFromTupled : ('T -> 'U) -> 'T -> 'U

// Usage:
FuncConvert.FuncFromTupled (func)
```

#### Parameters
*func*
Type: **'T -&gt; 'U**


## Platforms
Windows 7, Windows Vista, Windows XP SP2, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, Windows Server 2000 SP4


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 3.0, 4.0, Portable


## See Also
[Core.FuncConvert Class &#40;F&#35;&#41;](Core.FuncConvert-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)