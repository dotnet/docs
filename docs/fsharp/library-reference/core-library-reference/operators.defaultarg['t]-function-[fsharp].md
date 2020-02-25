---
title: Operators.defaultArg<'T> Function (F#)
description: Operators.defaultArg<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5f20ed2a-9086-4a53-b1a4-dec8ffc71945
---

# Operators.defaultArg<'T> Function (F#)

Used to specify a default value for an optional argument in the implementation of a function.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
defaultArg : 'T option -> 'T -> 'T

// Usage:
defaultArg arg defaultValue
```

#### Parameters
*arg*
Type: **'T option**


An option representing the argument.


*defaultValue*
Type: **'T**


The default value of the argument.

## Return Value

The argument value. If it is `None`, the `defaultValue` is returned.

## Remarks
This function is named `DefaultArg` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
