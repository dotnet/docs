---
title: System.Tuple<'T1,'T2,'T3,'T4> Class (F#)
description: System.Tuple<'T1,'T2,'T3,'T4> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2bda4a53-6262-4b0f-bc9e-97fb7a239c68 
---

# System.Tuple<'T1,'T2,'T3,'T4> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2,'T3,'T4> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 * 'T3 * 'T4 -> Tuple<'T1,'T2,'T3,'T4>
member this.Item1 :  'T1
member this.Item2 :  'T2
member this.Item3 :  'T3
member this.Item4 :  'T4
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/c0835ad3-401d-4002-a1bc-58f65dce270b)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/8d52949a-ec8b-49c3-a6d9-6ba8cad54d5a)||
|[Item2](https://msdn.microsoft.com/library/f3bd723c-391a-47dc-94a1-345082285cf0)||
|[Item3](https://msdn.microsoft.com/library/5eb0ff1f-96f6-4e96-8a9f-a6921088b715)||
|[Item4](https://msdn.microsoft.com/library/80811883-b040-4896-a047-af2b7a1a40ac)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)