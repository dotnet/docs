---
title: LeafExpressionConverter.QuotationToLambdaExpression<'T> Function (F#)
description: LeafExpressionConverter.QuotationToLambdaExpression<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b9940a4f-e470-46fa-af24-59459795e027 
---

# LeafExpressionConverter.QuotationToLambdaExpression<'T> Function (F#)

Converts a subset of F# quotations to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
QuotationToLambdaExpression : Expr<'T> -> Expression<'T>

// Usage:
QuotationToLambdaExpression
```

#### Parameters
*expression*
Type: [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)&lt;'T&gt;


A quotation that represents a LINQ expression.

## Return Value
An expression tree as a LINQ expression.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[RuntimeHelpers.LeafExpressionConverter Module &#40;F&#35;&#41;](RuntimeHelpers.LeafExpressionConverter-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)