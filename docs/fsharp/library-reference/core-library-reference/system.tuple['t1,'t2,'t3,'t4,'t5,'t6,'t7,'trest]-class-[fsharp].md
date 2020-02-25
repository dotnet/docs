---
title: System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest> Class (F#)
description: System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b3f149ec-b6c0-4c83-8e3b-3c4ac1ae35e9 
---

# System.Tuple<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest> Class (F#)

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Tuple<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest> =
class
interface IComparable
interface IStructuralComparable
interface IStructuralEquatable
new Tuple : 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'TRest -> Tuple<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest>
member this.Item1 :  'T1
member this.Item2 :  'T2
member this.Item3 :  'T3
member this.Item4 :  'T4
member this.Item5 :  'T5
member this.Item6 :  'T6
member this.Item7 :  'T7
member this.Rest :  'TRest
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Tuple`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/f579bb02-48ae-4910-a325-ad599349d50e)||

## Instance Members


|Member|Description|
|------|-----------|
|[Item1](https://msdn.microsoft.com/library/de81dc53-c129-42d6-a3cc-889b1cc6aeba)||
|[Item2](https://msdn.microsoft.com/library/d586b8de-b250-4a0d-ba66-51b6d9721549)||
|[Item3](https://msdn.microsoft.com/library/d12c4ad3-f171-42eb-928c-d01cc05be10c)||
|[Item4](https://msdn.microsoft.com/library/021390fb-22d7-453d-a33a-33856e7db8f5)||
|[Item5](https://msdn.microsoft.com/library/d1669774-957b-4cc2-a75f-b06cbe2deaad)||
|[Item6](https://msdn.microsoft.com/library/c6591974-ac8e-4e2e-b255-a55bea4f8879)||
|[Item7](https://msdn.microsoft.com/library/b5684cfe-df84-4e92-95cd-4e4b7e9d461c)||
|[Rest](https://msdn.microsoft.com/library/4158a34c-8878-4875-87cb-61fb6f5b3669)||

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)