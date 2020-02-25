---
title: Operators.int64<^T> Function (F#)
description: Operators.int64<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c6a49d4e-4c7c-4b05-8e81-4eeb0f9766aa
---

# Operators.int64<^T> Function (F#)

Converts the argument to signed 64-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using `System.Int64.Parse(System.String)` with `System.Globalization.CultureInfo.InvariantCulture` settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
int64 : ^T -> int64 (requires ^T with static member op_Explicit)

// Usage:
int64 value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted int64 value.

## Remarks
This function is named `ToInt64` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
