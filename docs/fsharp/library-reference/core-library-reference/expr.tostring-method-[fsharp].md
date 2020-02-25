---
title: Expr.ToString Method (F#)
description: Expr.ToString Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 853541a8-4508-40dc-809b-77b5a29f910c 
---

# Expr.ToString Method (F#)

Formats the expression as a string.

**Namespace/Module Path**: Microsoft.FSharp.Quotations

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.ToString : bool -> string

// Usage:
expr.ToString (full)
```

#### Parameters
*full*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Indicates whether or not method, property, constructor and type objects should be printed in detail. If false, these are abbreviated to their names.

## Return Value
The formatted string.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)