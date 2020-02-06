---
title: Patterns.Call Active Pattern (F#)
description: Patterns.Call Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b13c6f75-81cf-4d31-8a58-a476cf87cde6
---

# Patterns.Call Active Pattern (F#)

Recognizes expressions that represent calls to static and instance methods, and those that represent and functions defined in modules.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Call|_| ) : (input:Expr) -> (Expr option * MethodInfo * Expr list) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr option` &#42; `MethodInfo` &#42; `Expr list`) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of three elements. The first element is an option for an expression that represents the reference to the object for an instance method call. It has a value only if the call is an instance method. The second element of the tuple is a T:System.Reflection.MethodInfo object that describes the method. The final element of the tuple is a list that contains the arguments for the method call.

## Remarks
This function is named `CallPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
