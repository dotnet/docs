---
title: IStructuralEquatable.GetHashCode Method (F#)
description: IStructuralEquatable.GetHashCode Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a4ac4190-9fbd-4d82-93a8-3f63202ba517 
---

# IStructuralEquatable.GetHashCode Method (F#)

Returns a hash code for the current instance.

**Namespace/Module Path**: System.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GetHashCode : IEqualityComparer -> int

// Usage:
iStructuralEquatable.GetHashCode (comparer)
```

#### Parameters
*comparer*
Type: **System.Collections.IEqualityComparer**


An object that computes the hash code of the current object.

## Return Value

The hash code for the current instance.

## Remarks

This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, `System.Collections.IStructuralEquatable.GetHashCode(System.Collections.IEqualityComparer)`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Collections.IStructuralEquatable Interface &#40;F&#35;&#41;](Collections.IStructuralEquatable-Interface-%5BFSharp%5D.md)

[System.Collections Namespace &#40;F&#35;&#41;](System.Collections-Namespace-%5BFSharp%5D.md)