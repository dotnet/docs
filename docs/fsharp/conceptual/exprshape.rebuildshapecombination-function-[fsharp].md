---
title: ExprShape.RebuildShapeCombination Function (F#)
description: ExprShape.RebuildShapeCombination Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 77f3b791-6ae4-462d-a5c2-2ab3e08be8d1 
---

# ExprShape.RebuildShapeCombination Function (F#)

Re-build combination expressions. The first parameter should be an object returned by the `ShapeCombination` case of the active pattern in this module.

**Namespace/Module Path:** Microsoft.FSharp.Quotations.ExprShape

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RebuildShapeCombination : obj * Expr list -> Expr

// Usage:
RebuildShapeCombination (shape, arguments)
```

#### Parameters
*shape*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The input shape.


*arguments*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The list of arguments.

## Return Value

The rebuilt expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.ExprShape Module &#40;F&#35;&#41;](Quotations.ExprShape-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)