---
title: ExtraTopLevelOperators.( ~%% )<'T> Function (F#)
description: ExtraTopLevelOperators.( ~%% )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bfc6e886-04b4-42e2-8beb-67147d87d26e 
---

# ExtraTopLevelOperators.( ~%% )<'T> Function (F#)

Special prefix operator for splicing untyped expressions into quotation holes.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ~%% ) : Expr -> 'T

// Usage:
%% expression
```

#### Parameters
*expression*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


An expression that is spliced into the quotation hole.

## Return Value

The result of the expression.

## Remarks
This function is named `SpliceUntypedExpression` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)