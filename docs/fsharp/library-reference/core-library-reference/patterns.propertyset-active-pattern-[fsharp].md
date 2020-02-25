---
title: Patterns.PropertySet Active Pattern (F#)
description: Patterns.PropertySet Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 597153a9-3fc8-42be-b641-705f4e36233a
---

# Patterns.PropertySet Active Pattern (F#)

Recognizes expressions that represent setting a static or instance property, or setting a non-function value declared in a module.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |PropertySet|_| ) : (input:Expr) -> (Expr option * PropertyInfo * Expr list * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return value is (`Expr option` &#42; `PropertyInfo` &#42; `Expr list` &#42; `Expr`) option. The option type indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of four elements. The first element is an option whose value is an expression that represents the instance, or `None` if the property is static. The second element is a `System.Reflection.PropertyInfo` object that represents the property (or the module value). The third element is an expression list that represents the arguments to the set accessor, which is used for indexed properties. The fourth element is an expression that represents the value to set, which is also the right side of the assignment.

## Remarks
This function is named `PropertySetPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
