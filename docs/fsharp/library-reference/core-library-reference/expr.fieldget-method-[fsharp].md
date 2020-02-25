---
title: Expr.FieldGet Method (F#)
description: Expr.FieldGet Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2864cf27-4a6a-4354-9f74-0e264d6b7374 
---

# Expr.FieldGet Method (F#)

Creates an expression that represents the access of a field of an object.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
static member FieldGet : Expr * FieldInfo -> Expr
static member FieldGet : FieldInfo -> Expr

// Usage:
Expr.FieldGet (obj, fieldInfo)
Expr.FieldGet (fieldInfo)
```

#### Parameters
*obj*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input object.


*fieldInfo*
Type: **System.Reflection.FieldInfo**


The description of the field to access.

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