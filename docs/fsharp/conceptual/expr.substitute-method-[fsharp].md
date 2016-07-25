---
title: Expr.Substitute Method (F#)
description: Expr.Substitute Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 328e569e-f520-4723-a4fa-51d1ad754794 
---

# Expr.Substitute Method (F#)

Substitutes through the given expression using the given functions to map variables to new values. The functions must give consistent results at each application. Variable renaming may occur on the target expression if variable capture occurs.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Substitute : (Var -> Expr option) -> Expr

// Usage:
expr.Substitute (substitution)
```

#### Parameters
*substitution*
Type: [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5)**-&gt;**[Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The function to map variables into expressions.

## Return Value

The expression with the given substitutions.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)