---
title: Operators.string<^T> Function (F#)
description: Operators.string<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f648ee17-8353-411b-ac83-a450a403525d
---

# Operators.string<^T> Function (F#)

Converts the argument to a string using `System.Object.ToString`.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
string : ^T -> string

// Usage:
string value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted string.

## Remarks
For standard integer and floating point values the `System.Object.ToString` conversion uses `System.Globalization.CultureInfo.InvariantCulture`.

This function is named `ToString` in compiled assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
