---
title: Quotations.ExprShape Module (F#)
description: Quotations.ExprShape Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8abefb71-1ac3-45b1-bb0f-e66fa98c1297
---

# Quotations.ExprShape Module (F#)

Active patterns for traversing, visiting, rebuilding and transforming expressions in a generic way

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module ExprShape
```

## Values


|Value|Description|
|-----|-----------|
|[RebuildShapeCombination](https://msdn.microsoft.com/library/38c3f403-b3ed-4ddf-a69c-53a21339aa2f)<br />**: obj &#42; Expr list -&gt; Expr**|Rebuild combination expressions. The first parameter should be an object returned by the [ShapeCombination](https://msdn.microsoft.com/library/e090818c-3353-4f28-96ed-1eb04d71139c) case of the active pattern in this module.|

## Active Patterns


|Active Pattern|Description|
|--------------|-----------|
|[( &#124;ShapeVar&#124;ShapeLambda&#124;ShapeCombination&#124; )](https://msdn.microsoft.com/library/e090818c-3353-4f28-96ed-1eb04d71139c)|An active pattern that performs a complete decomposition viewing the expression tree as a binding structure|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
