---
title: DerivedPatterns.Int64 Active Pattern (F#)
description: DerivedPatterns.Int64 Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9fb5628a-92ee-4b57-8462-507cf5c2c86c 
---

# DerivedPatterns.Int64 Active Pattern (F#)

Recognizes constant `int64` expressions.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.DerivedPatterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Int64|_| ) : (input:Expr) -> int64 option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The result of a successful match is the `int64` value.

## Remarks

This function is named `Int64Pattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.DerivedPatterns Module &#40;F&#35;&#41;](Quotations.DerivedPatterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)