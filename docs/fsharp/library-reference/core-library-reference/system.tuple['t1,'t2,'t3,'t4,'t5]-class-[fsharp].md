---
title: System.Tuple<'T1,'T2,'T3,'T4,'T5> Class (F#)
description: System.Tuple<'T1,'T2,'T3,'T4,'T5> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b35269e0-7ac9-496f-9e5c-7471e51d1f12 
---

# System.Tuple<'T1,'T2,'T3,'T4,'T5> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2,'T3,'T4,'T5> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 * 'T3 * 'T4 * 'T5 -> Tuple<'T1,'T2,'T3,'T4,'T5>
member this.Item1 :  'T1
member this.Item2 :  'T2
member this.Item3 :  'T3
member this.Item4 :  'T4
member this.Item5 :  'T5
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/f0b172c7-4736-4d0b-ab38-bc41391db119)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/fc4ffc91-6a45-488a-b07f-e6a5308cae58)||
|[Item2](https://msdn.microsoft.com/library/bf571ccd-3d82-446e-b41c-8f0e697a0ec7)||
|[Item3](https://msdn.microsoft.com/library/f4aa0285-4695-4e74-9782-0ffe24d47dae)||
|[Item4](https://msdn.microsoft.com/library/d98acff5-c44a-4a8f-b583-a14ef08f25cc)||
|[Item5](https://msdn.microsoft.com/library/9be08b0d-7c04-4121-85c4-b46f48145fdd)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)