---
title: Quotations.Var Constructor (F#)
description: Quotations.Var Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8f26b2cf-5f77-4de9-a9a0-a1c9de5c6509
---

# Quotations.Var Constructor (F#)

Creates a new variable with the given name, type and mutability.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
new Var : string * Type * ?bool -> Var

// Usage:
new Var (name, typ)
new Var (name, typ, isMutable = isMutable)
```

#### Parameters
*name*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The declared name of the variable.


*typ*
Type: **System.Type**


The type associated with the variable.


*isMutable*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Indicates if the variable represents a mutable storage location. The default value is **false**.

## Return Value

The created variable.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Var Class &#40;F&#35;&#41;](Quotations.Var-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
