---
title: Operators.( := )<'T> Function (F#)
description: Operators.( := )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 90cf57e7-76bc-4135-bb4a-333c717899eb 
---

# Operators.( := )<'T> Function (F#)

Assign to a mutable reference cell.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( := ) : 'T ref -> 'T -> unit

// Usage:
cell := value
```

#### Parameters
*cell*
Type: **'T ref**


The cell to mutate.


*value*
Type: **'T**


The value to set inside the cell.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)