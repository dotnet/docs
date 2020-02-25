---
title: Expr.NewRecord Method (F#)
description: Expr.NewRecord Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1d17320e-f60a-4089-9233-b32188d023c8 
---

# Expr.NewRecord Method (F#)

Builds record-construction expressions.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member NewRecord : Type * Expr list -> Expr

// Usage:
Expr.NewRecord (recordType, elements)
```

#### Parameters
*recordType*
Type: **System.Type**


The type of record.


*elements*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The list of elements of the record.

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