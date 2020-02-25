---
title: QueryBuilder.Head<'T,'Q> Method (F#)
description: QueryBuilder.Head<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f66f20c1-6a06-47c8-9412-061381fbd3a2
---

# QueryBuilder.Head<'T,'Q> Method (F#)

A query operator that selects the first element from those selected so far.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Head : QuerySource<'T,'Q> -> 'T

// Usage:
queryBuilder.Head (source)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.

## Return Value
The first element.

## Remarks
For more information and examples, see [Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db).

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)
