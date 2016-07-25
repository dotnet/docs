---
title: Patterns.FieldSet Active Pattern (F#)
description: Patterns.FieldSet Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3344e0b8-06d1-4154-b66e-fc1e44836dab
---

# Patterns.FieldSet Active Pattern (F#)

Recognizes expressions that represent setting a static or instance field.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |FieldSet|_| ) : Expr -> (Expr option * FieldInfo * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr option` &#42; `FieldInfo` &#42; `Expr`) option. The option determines whether the input results in a match. In a pattern matching expression, the input is decomposed into a tuple of three elements. The first is an option that can contain an expression that represents the instance. This element is None if the field is static. The second element is a T:System.Reflection.FieldInfo object, and the third element is an expression that represents the value to set the field to.

## Remarks
This function is named `FieldSetPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
