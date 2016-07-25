---
title: Core.Choice<'T1,'T2> Union (F#)
description: Core.Choice<'T1,'T2> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 01ea76e6-6879-450f-9733-3142343cd42d 
---

# Core.Choice<'T1,'T2> Union (F#)

Helper types for active patterns with two choices.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<StructuralEquality>]
[<StructuralComparison>]
type Choice<'T1,'T2> =
| Choice1Of2 of 'T1
| Choice2Of2 of 'T2
with
interface IStructuralEquatable
interface IComparable
interface IComparable
interface IStructuralComparable
end
```

## Union Cases


|Case|Description|
|----|-----------|
|Choice1Of2 of 'T1|The first choice.|
|Choice2Of2 of 'T2|The second choice.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)