---
title: LeafExpressionConverter.EvaluateQuotation Function (F#)
description: LeafExpressionConverter.EvaluateQuotation Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b94c934a-d020-4fa1-beb2-719e3f3c99ba 
---

# LeafExpressionConverter.EvaluateQuotation Function (F#)

Evaluates a subset of F# quotations by first converting to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
EvaluateQuotation : Expr -> obj

// Usage:
EvaluateQuotation
```

#### Parameters
*quotation*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The quotation to evaluate.

## Return Value
The result of the evaluation.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[RuntimeHelpers.LeafExpressionConverter Module &#40;F&#35;&#41;](RuntimeHelpers.LeafExpressionConverter-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)