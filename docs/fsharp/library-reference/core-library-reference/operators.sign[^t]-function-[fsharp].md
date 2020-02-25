---
title: Operators.sign<^T> Function (F#)
description: Operators.sign<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a94785e9-0c5f-48cc-a22b-6cccab5014fc
---

# Operators.sign<^T> Function (F#)

Sign of the given number.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
sign : ^T -> int (requires ^T with member Sign)

// Usage:
sign value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

-1, 0, or 1 depending on the sign of the input.

## Remarks
This function is named `Sign` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
