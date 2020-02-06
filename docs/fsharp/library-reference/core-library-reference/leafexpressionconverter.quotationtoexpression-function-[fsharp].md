---
title: LeafExpressionConverter.QuotationToExpression Function (F#)
description: LeafExpressionConverter.QuotationToExpression Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0fcc6014-fabb-49f3-983d-d62f6f3dfbb5 
---

# LeafExpressionConverter.QuotationToExpression Function (F#)

Converts a subset of F# quotations to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
QuotationToExpression : Expr -> Expression

// Usage:
QuotationToExpression
```

#### Parameters
*quotation*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


A quotation to convert to a LINQ expression.

## Return Value
The converted expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[RuntimeHelpers.LeafExpressionConverter Module &#40;F&#35;&#41;](RuntimeHelpers.LeafExpressionConverter-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)