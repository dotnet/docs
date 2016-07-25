---
title: Core.Choice<'T1,'T2,'T3,'T4> Union (F#)
description: Core.Choice<'T1,'T2,'T3,'T4> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 280d8a69-a419-4eed-a336-b9ddfb9e5df5 
---

# Core.Choice<'T1,'T2,'T3,'T4> Union (F#)

Helper types for active patterns with four choices.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<StructuralEquality>]
[<StructuralComparison>]
type Choice<'T1,'T2,'T3,'T4> =
| Choice1Of4 of 'T1
| Choice2Of4 of 'T2
| Choice3Of4 of 'T3
| Choice4Of4 of 'T4
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
|Choice1Of4 of 'T1|The first choice.|
|Choice2Of4 of 'T2|The second choice.|
|Choice3Of4 of 'T3|The third choice.|
|Choice4Of4 of 'T4|The fourth choice.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)