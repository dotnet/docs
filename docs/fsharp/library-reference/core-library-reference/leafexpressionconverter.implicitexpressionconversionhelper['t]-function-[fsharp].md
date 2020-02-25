---
title: LeafExpressionConverter.ImplicitExpressionConversionHelper<'T> Function (F#)
description: LeafExpressionConverter.ImplicitExpressionConversionHelper<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7f845d1a-7a4e-4fff-b426-1b2a79d4c797 
---

# LeafExpressionConverter.ImplicitExpressionConversionHelper<'T> Function (F#)

When used in a quotation, this function indicates that a specific conversion should be performed when converting the quotation to a LINQ expression. This function should not be called directly.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
ImplicitExpressionConversionHelper : 'T -> Expression<'T>

// Usage:
ImplicitExpressionConversionHelper
```

#### Parameters
*input*
Type: 'T


The input value.

## Return Value
The resulting LINQ expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[RuntimeHelpers.LeafExpressionConverter Module &#40;F&#35;&#41;](RuntimeHelpers.LeafExpressionConverter-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)