---
title: System.Tuple<'T1> Class (F#)
description: System.Tuple<'T1> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cbcdda6f-e43e-4316-8807-2d612d93a65d 
---

# System.Tuple<'T1> Class (F#)

Compiled versions of F# tuple types. These are not used directly, though these compiled forms are seen by other CLI languages.

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 -> Tuple<'T1>
member this.Item1 :  'T1
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, [System.Tuple](https://msdn.microsoft.com/library/dd386941.aspx).


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/a4529058-fd29-4bf9-9266-0c234175ba7b)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/5c5658d2-6b89-4e90-affc-d45f1467a1d2)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0




## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)

