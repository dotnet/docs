---
title: System.Tuple<'T1,'T2,'T3> Class (F#)
description: System.Tuple<'T1,'T2,'T3> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 22be0160-3b77-431e-8c65-2bb7f7641ebb 
---

# System.Tuple<'T1,'T2,'T3> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2,'T3> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 * 'T3 -> Tuple<'T1,'T2,'T3>
member this.Item1 :  'T1
member this.Item2 :  'T2
member this.Item3 :  'T3
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/7f3fcf0b-eb72-410a-9b82-19ec2e31d294)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/2913ad56-a6a4-4520-949f-cab842fa2cf0)||
|[Item2](https://msdn.microsoft.com/library/dd8add01-5051-408c-9ab7-e293f2ea4d1d)||
|[Item3](https://msdn.microsoft.com/library/c96bab59-8931-4a18-83ff-d25f64e72551)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)