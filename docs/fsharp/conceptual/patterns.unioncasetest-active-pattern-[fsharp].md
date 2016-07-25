---
title: Patterns.UnionCaseTest Active Pattern (F#)
description: Patterns.UnionCaseTest Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 80d33bbf-7a6d-4292-b399-e222ffe311e9
---

# Patterns.UnionCaseTest Active Pattern (F#)

Recognizes expressions that represent an operation that tests whether a value is of a particular union case.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |UnionCaseTest|_| ) : (input:Expr) -> (Expr * UnionCaseInfo) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr` &#42; `UnionCaseInfo`) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed into a tuple of two elements. The first element is the expression that represents the target of the test and the second element is the [UnionCaseInfo](https://msdn.microsoft.com/library/d97eb038-9521-4e20-89b4-dd0cd92d7221) object that represents the union case.

## Remarks
This function is named `UnionCaseTestPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
