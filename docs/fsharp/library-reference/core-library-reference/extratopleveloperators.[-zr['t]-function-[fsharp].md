---
title: ExtraTopLevelOperators.( ~%<'T> Function (F#)
description: ExtraTopLevelOperators.( ~%<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9b83fe4d-0787-44b5-ba1f-3f9d4aa0c64f 
---

# ExtraTopLevelOperators.( ~%<'T> Function (F#)

Special prefix operator for splicing typed expressions into quotation holes.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ~% ) : Expr<'T> -> 'T

// Usage:
% expression
```

#### Parameters
*expression*
Type: [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)**&lt;'T&gt;**


The expression to splice into the quotation hole.

## Return Value

The result of the expression.

## Remarks
This function is named `SpliceExpression` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)