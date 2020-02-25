---
title: Operators.ignore<'T> Function (F#)
description: Operators.ignore<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e6c84d90-ef39-4b9d-8795-6d360e6e1e08
---

# Operators.ignore<'T> Function (F#)

Ignore the passed value. This is often used to throw away results of a computation.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
ignore : 'T -> unit

// Usage:
ignore value
```

#### Parameters
*value*
Type: **'T**


The value to ignore.

## Remarks
This function is named `Ignore` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
