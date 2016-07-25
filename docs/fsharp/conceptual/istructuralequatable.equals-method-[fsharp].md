---
title: IStructuralEquatable.Equals Method (F#)
description: IStructuralEquatable.Equals Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 997c9628-3727-4750-8f52-5967dc14e277 
---

# IStructuralEquatable.Equals Method (F#)

Equality comparison against a target object with a given comparer.

**Namespace/Module Path**: System.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.Equals : obj * IEqualityComparer -> bool

// Usage:
iStructuralEquatable.Equals (obj, comparer)
```

#### Parameters
*obj*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The target for comparison.


*comparer*
Type: **System.Collections.IEqualityComparer**


Compares the two objects.

## Return Value

The result of the comparer.

## Remarks

This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, `System.Collections.IStructuralEquatable.Equals(System.Object,System.Collections.IEqualityComparer)`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Collections.IStructuralEquatable Interface &#40;F&#35;&#41;](Collections.IStructuralEquatable-Interface-%5BFSharp%5D.md)

[System.Collections Namespace &#40;F&#35;&#41;](System.Collections-Namespace-%5BFSharp%5D.md)