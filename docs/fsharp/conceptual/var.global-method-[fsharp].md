---
title: Var.Global Method (F#)
description: Var.Global Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 719a995a-05b9-402b-bff3-0948cd9f7b6d 
---

# Var.Global Method (F#)

Fetches or creates a new variable with the given name and type from a global pool of shared variables indexed by name and type.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Global : string * Type -> Var

// Usage:
Var.Global (name, typ)
```

#### Parameters
*name*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The name of the variable.


*typ*
Type: **System.Type**


The type associated with the variable.

## Return Value
The retrieved or created variable.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Var Class &#40;F&#35;&#41;](Quotations.Var-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)