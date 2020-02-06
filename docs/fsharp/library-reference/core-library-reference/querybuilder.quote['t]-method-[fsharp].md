---
title: QueryBuilder.Quote<'T> Method (F#)
description: QueryBuilder.Quote<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: feeb3f0f-ecdf-4fc1-b093-d11c6614b189
---

# QueryBuilder.Quote<'T> Method (F#)

A method used to support the F# query syntax. Indicates that the query should be passed as a quotation to the [Run](https://msdn.microsoft.com/library/33bbcef1-2a4a-45cb-9105-01aa0082cfc9) method.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Quote : Expr<'T> -> Expr<'T>

// Usage:
queryBuilder.Quote ()
```

#### Parameters
*source*
Type: [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)&lt;'T&gt;


The input query.

## Return Value
The query as an F# quotation.


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
