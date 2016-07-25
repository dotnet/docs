---
title: QueryBuilder.GroupJoin<'Outer,'Q,'Inner,'Key,'Result> Method (F#)
description: QueryBuilder.GroupJoin<'Outer,'Q,'Inner,'Key,'Result> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 538614ef-6d8d-4951-93b9-a09db323ee13
---

# QueryBuilder.GroupJoin<'Outer,'Q,'Inner,'Key,'Result> Method (F#)

A query operator that correlates two sets of selected values based on matching keys and groups the results. Normal usage is `groupJoin (for y in elements2 -> key1 = key2) into group`.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.GroupJoin : QuerySource<'Outer,'Q> * QuerySource<'Inner,'Q> * ('Outer -> 'Key) * ('Inner -> 'Key) * ('Outer -> seq<'Inner> -> 'Result) -> QuerySource<'Result,'Q>

// Usage:
queryBuilder.GroupJoin (outerSource, innerSource, outerKeySelector, innerKeySelector, resultSelector)
```

#### Parameters
*outerSource*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Outer,'Q&gt;


The outer query.


*innerSource*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Inner,'Q&gt;


The inner query.


*outerKeySelector*
Type: 'Outer -&gt; 'Key


A function that specifies the correlation key from the outer query.


*innerKeySelector*
Type: 'Inner -&gt; 'Key


A function that specifies the correlation key from the inner query.


*resultSelector*
Type: 'Outer -&gt;
[seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)&lt;'Inner&gt; -&gt;
'Result


A function that returns the results of the operation.

## Return Value
The resulting query.


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
