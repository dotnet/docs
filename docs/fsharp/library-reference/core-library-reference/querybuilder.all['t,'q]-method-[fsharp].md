---
title: QueryBuilder.All<'T,'Q> Method (F#)
description: QueryBuilder.All<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d36193d8-470d-4159-90ea-12f552717dd0
---

# QueryBuilder.All<'T,'Q> Method (F#)

A query operator that determines whether all elements selected so far satisfy a condition.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.All : QuerySource<'T,'Q> * ('T -> bool) -> bool

// Usage:
queryBuilder.All (source, predicate)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.


*predicate*
Type: 'T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A Boolean function to test the elements.

## Return Value
`true` if the provided Boolean function *predicate* evaluates to true for all elements selected so far.

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
