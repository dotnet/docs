---
title: Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6,'T7> Union (F#)
description: Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6,'T7> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 037ca804-fca4-478b-bd36-876836a77c4b 
---

# Core.Choice<'T1,'T2,'T3,'T4,'T5,'T6,'T7> Union (F#)

Helper types for active patterns with seven choices.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<StructuralEquality>]
[<StructuralComparison>]
type Choice<'T1,'T2,'T3,'T4,'T5,'T6,'T7> =
| Choice1Of7 of 'T1
| Choice2Of7 of 'T2
| Choice3Of7 of 'T3
| Choice4Of7 of 'T4
| Choice5Of7 of 'T5
| Choice6Of7 of 'T6
| Choice7Of7 of 'T7
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
|Choice1Of7 of 'T1|The first choice.|
|Choice2Of7 of 'T2|The second choice.|
|Choice3Of7 of 'T3|The third choice.|
|Choice4Of7 of 'T4|The fourth choice.|
|Choice5Of7 of 'T5|The fifth choice.|
|Choice6Of7 of 'T6|The sixth choice.|
|Choice7Of7 of 'T7|The seventh choice.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)