---
title: Collections.IStructuralEquatable Interface (F#)
description: Collections.IStructuralEquatable Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c8e074e0-18a0-4fee-abc6-de3a3502e73f 
---

# Collections.IStructuralEquatable Interface (F#)

Defines methods to support the comparison of objects for structural equality.

**Namespace/Module Path**: System.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
type IStructuralEquatable =
interface
abstract this.Equals : obj * IEqualityComparer -> bool
abstract this.GetHashCode : IEqualityComparer -> int
end
```

## Remarks

This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, [`System.Collections.IStructuralEquatable`](https://msdn.microsoft.com/library/system.collections.istructuralequatable.aspx).

## Instance Members

|Member|Description|
|------|-----------|
|[Equals](https://msdn.microsoft.com/library/d8d24d5c-1a02-49e7-ad4d-4c38b92aa670)|Equality comparison against a target object with a given comparer.|
|[GetHashCode](https://msdn.microsoft.com/library/1aeeb426-e8a9-4a4a-8151-55f1073a86c2)|Returns a hash code for the current instance.|

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0

## See Also

[System.Collections Namespace &#40;F&#35;&#41;](System.Collections-Namespace-%5BFSharp%5D.md)
