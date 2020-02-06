---
title: Patterns.TupleGet Active Pattern (F#)
description: Patterns.TupleGet Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 04d54618-bbb6-42ac-84ab-508c87271bbe
---

# Patterns.TupleGet Active Pattern (F#)

Recognizes expressions that represent getting a tuple field.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |TupleGet|_| ) : (input:Expr) -> (Expr * int) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return value is (`Expr` &#42; `int`) option. The option type indicates whether there is a successful match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of two elements. The first is an expression that represents the tuple and the second is an integer that represents the zero-based index.

## Remarks
This function is named `TupleGetPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
