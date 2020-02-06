---
title: QueryBuilder.Source<'T,'Q> Method (F#)
description: QueryBuilder.Source<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4bc8cb36-8ab8-464f-ab58-e6a2f048457a
---

# QueryBuilder.Source<'T,'Q> Method (F#)

A method used to support the F# query syntax. Inputs to queries are implicitly wrapped by a call to one of the overloads of this method.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Source : IQueryable<'T> -> QuerySource<'T,'Q>

// Usage:
queryBuilder.Source (source)
```

#### Parameters
*source*
Type: **System.Linq.IQueryable&#96;1**&lt;'T&gt;


The input queryable collection.


## Return Value
A query in the form used by query expressions.

## Remarks
For more information and examples, see [Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db).

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.QueryBuilder Class &#40;F&#35;&#41;](Linq.QueryBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)
