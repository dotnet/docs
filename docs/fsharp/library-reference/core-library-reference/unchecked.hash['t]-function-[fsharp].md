---
title: Unchecked.hash<'T> Function (F#)
description: Unchecked.hash<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f27d0d10-de6d-4286-a8c5-a26371aec5a3 
---

# Unchecked.hash<'T> Function (F#)

Perform generic hashing on a value where the type of the value is not statically required to satisfy the equality constraint.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Unchecked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
hash : 'T -> int

// Usage:
hash value
```

#### Parameters
*value*
Type: **'T**


The value to generate a hash for.


## Return Value

The computed hash value.

## Remarks
This function is named `Hash` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Unchecked Module &#40;F&#35;&#41;](Operators.Unchecked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)