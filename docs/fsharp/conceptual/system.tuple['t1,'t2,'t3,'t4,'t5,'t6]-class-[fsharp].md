---
title: System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6> Class (F#)
description: System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 20999440-8c04-401b-bab5-b7b79bbcfd83 
---

# System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2,'T3,'T4,'T5,'T6> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 -> Tuple<'T1,'T2,'T3,'T4,'T5,'T6>
member this.Item1 :  'T1
member this.Item2 :  'T2
member this.Item3 :  'T3
member this.Item4 :  'T4
member this.Item5 :  'T5
member this.Item6 :  'T6
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/b622d6ab-deed-413c-9c92-c7e3c614a2ee)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/0414639d-0cf6-48a8-90f3-509db76836b1)||
|[Item2](https://msdn.microsoft.com/library/43257785-c10f-4b98-89cc-f02202907018)||
|[Item3](https://msdn.microsoft.com/library/f730f59f-0107-4a40-881c-957d47c84fec)||
|[Item4](https://msdn.microsoft.com/library/3f0e06f4-a970-4067-a6e6-926ff02c4de6)||
|[Item5](https://msdn.microsoft.com/library/ea3710d8-cf18-4fe1-9250-4a65f68255ee)||
|[Item6](https://msdn.microsoft.com/library/f2b77aa8-cdfc-4105-8698-d55e5b9f5ab3)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)