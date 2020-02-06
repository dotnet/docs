---
title: DerivedPatterns.MethodWithReflectedDefinition Active Pattern (F#)
description: DerivedPatterns.MethodWithReflectedDefinition Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8611d997-82a9-4536-ae31-1acc59c596e3 
---

# DerivedPatterns.MethodWithReflectedDefinition Active Pattern (F#)

Recognizes methods that have an associated `ReflectedDefinition`.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.DerivedPatterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |MethodWithReflectedDefinition|_| ) : (methodBase:MethodBase) -> Expr option
```

#### Parameters
*methodBase*
Type: **System.Reflection.MethodBase**


The description of the method.

## Return Value

The expression of the method definition if it is found; otherwise, `None`.

## Remarks
This function is named `MethodWithReflectedDefinitionPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.DerivedPatterns Module &#40;F&#35;&#41;](Quotations.DerivedPatterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)