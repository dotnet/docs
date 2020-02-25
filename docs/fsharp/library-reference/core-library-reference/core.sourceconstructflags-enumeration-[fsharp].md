---
title: Core.SourceConstructFlags Enumeration (F#)
description: Core.SourceConstructFlags Enumeration (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8273d03a-8c31-4b67-a7f4-cffc842d4249 
---

# Core.SourceConstructFlags Enumeration (F#)

Indicates the relationship between a compiled entity in a .NET Framework binary and an element in F# source code.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type SourceConstructFlags =
| None = 0
| SumType = 1
| RecordType = 2
| ObjectType = 3
| Field = 4
| Exception = 5
| Closure = 6
| Module = 7
| UnionCase = 8
| Value = 9
| KindMask = 31
| NonPublicRepresentation = 32
```

## Remarks
The following table shows the possible values and their meaning.

|Value|Description|
|-----|-----------|
|None|Indicates that the compiled entity has no relationship to an element in F# source code.|
|SumType|Indicates that the compiled entity is part of the representation of an F# union type declaration.|
|RecordType|Indicates that the compiled entity is part of the representation of an F# record type declaration.|
|ObjectType|Indicates that the compiled entity is part of the representation of an F# class or other object type declaration.|
|Field|Indicates that the compiled entity is part of the representation of an F# record or union case declaration.|
|Exception|Indicates that the compiled entity is part of the representation of an F# exception declaration.|
|Closure|Indicates that the compiled entity is part of the representation of an F# closure.|
|Module|Indicates that the compiled entity is part of the representation of an F# module declaration.|
|UnionCase|Indicates that the compiled entity is part of the representation of an F# union case declaration.|
|Value|Indicates that the compiled entity is part of an F# value declaration.|
|KindMask|The mask of values related to the kind of the compiled entity.|
|NonPublicRepresentation|Indicates that the compiled entity had private or internal representation in F# source code.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)