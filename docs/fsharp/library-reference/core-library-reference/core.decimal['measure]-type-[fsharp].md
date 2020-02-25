---
title: Core.decimal<'Measure> Type (F#)
description: Core.decimal<'Measure> Type (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 33058aab-5862-433d-9195-986227cd0f4f 
---

# Core.decimal<'Measure> Type (F#)

The type of decimal numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to `System.Decimal`.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<MeasureAnnotatedAbbreviationAttribute>]
type decimal<'Measure> = decimal
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)