---
title: Collections.IStructuralComparable Interface (F#)
description: Collections.IStructuralComparable Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5bbee881-121b-412f-b797-4b12c66d6b25 
---

# Collections.IStructuralComparable Interface (F#)

Supports the structural comparison of collection objects.

**Namespace/Module Path**: System.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
type IStructuralComparable =
interface
abstract this.CompareTo : obj * IComparer -> int
end
```

## Remarks

This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, [`System.Collections.IStructuralComparable`](https://msdn.microsoft.com/library/system.collections.istructuralcomparable.aspx).

## Instance Members

|Member|Description|
|------|-----------|
|[CompareTo](https://msdn.microsoft.com/library/0aa85582-a8a5-4cdb-a75e-e91bab0e4139)|Determines whether the current object precedes, occurs in the same position as, or follows another object in the sort order.|

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0

## See Also

[System.Collections Namespace &#40;F&#35;&#41;](System.Collections-Namespace-%5BFSharp%5D.md)
