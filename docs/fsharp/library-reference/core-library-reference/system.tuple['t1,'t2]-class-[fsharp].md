---
title: System.Tuple<'T1,'T2> Class (F#)
description: System.Tuple<'T1,'T2> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dcecc0ea-279d-4556-9732-0e27b2027c11 
---

# System.Tuple<'T1,'T2> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 -> Tuple<'T1,'T2>
member this.Item1 :  'T1
member this.Item2 :  'T2
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/bf412e56-e16a-42b7-9dbc-72cf284e0181)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/b89002a7-5bd6-41dc-a51c-e9292b11b195)||
|[Item2](https://msdn.microsoft.com/library/bfdc5ddf-8ebf-4acf-9b8a-5324be79d80e)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)