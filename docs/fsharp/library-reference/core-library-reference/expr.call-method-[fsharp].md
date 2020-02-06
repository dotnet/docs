---
title: Expr.Call Method (F#)
description: Expr.Call Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 63f4931c-d235-41b5-bc87-a773ba9b3852 
---

# Expr.Call Method (F#)

Creates an expression that represents a call to an instance method associated with an object

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
static member Call : Expr * MethodInfo * Expr list -> Expr
static member Call : MethodInfo * Expr list -> Expr

// Usage:
Expr.Call (obj, methodInfo, arguments)
Expr.Call (methodInfo, arguments)
```

#### Parameters
*obj*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input object.


*methodInfo*
Type: **System.Reflection.MethodInfo**


The description of the method to call.


*arguments*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The list of arguments to the method.


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