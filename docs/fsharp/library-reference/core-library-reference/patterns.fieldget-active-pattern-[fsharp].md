---
title: Patterns.FieldGet Active Pattern (F#)
description: Patterns.FieldGet Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d3f2f16f-14d4-46f1-84ae-87aa4120cbe6
---

# Patterns.FieldGet Active Pattern (F#)

Recognizes expressions that represent getting a static or instance field.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |FieldGet|_| ) : (input:Expr) -> (Expr option * FieldInfo) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr option` &#42; `FieldInfo`) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of two elements. The tuple contains an option that contains either an expression that represents the instance for an instance field, or None if the field is static. The second element of the tuple is a `System.Reflection.FieldInfo` object that represents the field.

## Remarks
This function is named `FieldGetPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
