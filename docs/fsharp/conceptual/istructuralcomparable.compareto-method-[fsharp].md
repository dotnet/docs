---
title: IStructuralComparable.CompareTo Method (F#)
description: IStructuralComparable.CompareTo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 01a10f1d-3649-41f7-8e4b-d41939c569e1 
---

# IStructuralComparable.CompareTo Method (F#)

Determines whether the current object precedes, occurs in the same position as, or follows another object in the sort order.

**Namespace/Module Path**: System.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.CompareTo : obj * IComparer -> int

// Usage:
iStructuralComparable.CompareTo (obj, comparer)
```

#### Parameters
*obj*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The object to compare with the current instance.


*comparer*
Type: **System.Collections.IComparer**


An object that performs comparisons.

## Return Value

An integer that indicates the relationship of the current object to the target object.

## Remarks

This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, `System.Collections.IStructuralComparable.CompareTo(System.Object,System.Collections.IComparer)`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Collections.IStructuralComparable Interface &#40;F&#35;&#41;](Collections.IStructuralComparable-Interface-%5BFSharp%5D.md)

[System.Collections Namespace &#40;F&#35;&#41;](System.Collections-Namespace-%5BFSharp%5D.md)