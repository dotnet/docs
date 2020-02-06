---
title: DerivedPatterns.SpecificCall Active Pattern (F#)
description: DerivedPatterns.SpecificCall Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 88375fbc-bae0-47de-a30e-a478b3ebcdbc 
---

# DerivedPatterns.SpecificCall Active Pattern (F#)

Recognizes calls to a specified function or method. This is a parameterized active pattern.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.DerivedPatterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |SpecificCall|_| ) : (templateParameter:Expr) -> Expr -> (Expr option * Type list * Expr list) option
```

#### Parameters
*templateParameter*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input template expression that specifies the method to call.

## Return Value

The formal return type is (Expr option &#42; Type list &#42; Expr list) option. The option indicates whether there is a successful match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of three elements. The first element represents the optional target object, which is present if the target is an instance method. The second element represents the generic type instantiation, which is non-empty if the target is a generic instantiation. The third element represents the arguments to the function or method.

## Remarks
This function is named `SpecificCallPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.DerivedPatterns Module &#40;F&#35;&#41;](Quotations.DerivedPatterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)