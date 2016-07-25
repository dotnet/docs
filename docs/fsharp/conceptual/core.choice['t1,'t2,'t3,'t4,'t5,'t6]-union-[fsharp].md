---
title: Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6> Union (F#)
description: Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 15805a93-ad36-46d3-9535-c37a409173e8 
---

# Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6> Union (F#)

Helper types for active patterns with six choices.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<StructuralEquality>]
[<StructuralComparison>]
type Choice<'T1,'T2,'T3,'T4,'T5,'T6> =
| Choice1Of6 of 'T1
| Choice2Of6 of 'T2
| Choice3Of6 of 'T3
| Choice4Of6 of 'T4
| Choice5Of6 of 'T5
| Choice6Of6 of 'T6
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
|Choice1Of6 of 'T1|The first choice.|
|Choice2Of6 of 'T2|The second choice.|
|Choice3Of6 of 'T3|The third choice.|
|Choice4Of6 of 'T4|The fourth choice.|
|Choice5Of6 of 'T5|The fifth choice.|
|Choice6Of6 of 'T6|The sixth choice.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)