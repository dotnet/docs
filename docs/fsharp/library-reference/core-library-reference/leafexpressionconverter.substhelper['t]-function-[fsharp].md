---
title: LeafExpressionConverter.SubstHelper<'T> Function (F#)
description: LeafExpressionConverter.SubstHelper<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c81a44af-7463-4263-a2ec-cc89b5bc7fb8 
---

# LeafExpressionConverter.SubstHelper<'T> Function (F#)

A runtime helper used to evaluate nested quotation literals.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SubstHelper : Expr * Var [] * obj [] -> Expr<'T>

// Usage:
SubstHelper (quotation, vars, objects)
```

#### Parameters
*quotation*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input quotation.


*vars*
Type: [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


An array of variables.


*objects*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


An array of object instances to substitute for the variables.

## Return Value
The resulting code quotation expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[RuntimeHelpers.LeafExpressionConverter Module &#40;F&#35;&#41;](RuntimeHelpers.LeafExpressionConverter-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)