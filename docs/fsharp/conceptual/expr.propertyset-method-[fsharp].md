---
title: Expr.PropertySet Method (F#)
description: Expr.PropertySet Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 914be6e1-ffb1-4335-ac88-0ffd41301db1 
---

# Expr.PropertySet Method (F#)

Creates an expression that represents writing to a static property

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
static member PropertySet : PropertyInfo * Expr * ?Expr list -> Expr
static member PropertySet : Expr * PropertyInfo * Expr * ?Expr list -> Expr

// Usage:
Expr.PropertySet (property, value)
Expr.PropertySet (property, value, indexerArgs = indexerArgs)
Expr.PropertySet (obj, property, value)
Expr.PropertySet (obj, property, value, indexerArgs = indexerArgs)
```

#### Parameters
*property*
Type: **System.Reflection.PropertyInfo**


The description of the property.


*value*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The value to set.


*indexerArgs*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


List of indices for the property if it is an indexed property.


*obj*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The object instance, if applicable.

## Return Value

The resulting expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)