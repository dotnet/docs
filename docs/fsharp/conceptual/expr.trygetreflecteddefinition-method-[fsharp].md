---
title: Expr.TryGetReflectedDefinition Method (F#)
description: Expr.TryGetReflectedDefinition Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 17ae06e3-865c-4af8-af64-7ac1e060afca 
---

# Expr.TryGetReflectedDefinition Method (F#)

Tries to find a stored reflection definition for the given method. Stored reflection definitions are added to an F# assembly through the use of the [`ReflectedDefinition`](https://msdn.microsoft.com/library/56bb03a2-4deb-4860-b334-f59fdfc95b04) attribute.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member TryGetReflectedDefinition : MethodBase -> Expr option

// Usage:
Expr.TryGetReflectedDefinition (methodBase)
```

#### Parameters
*methodBase*
Type: **System.Reflection.MethodBase**


The description of the method to find.

## Return Value

The reflection definition or None if a match could not be found.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)