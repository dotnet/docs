---
title: QueryBuilder.Run<'T> Method (F#)
description: QueryBuilder.Run<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ac511bcb-87f4-4d7b-b349-acf282643ecd
---

# QueryBuilder.Run<'T> Method (F#)

A method used to support the F# query syntax. Runs the given quotation as a query using LINQ `IQueryable` rules.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Run : Expr<QuerySource<'T,IQueryable>> -> IQueryable<'T>

// Usage:
queryBuilder.Run ()
```

#### Parameters
*source*
Type: [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)&lt;[QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,
**System.Linq.IQueryable**&gt;&gt;


A query expression.

## Return Value
The query as a queryable value.

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
