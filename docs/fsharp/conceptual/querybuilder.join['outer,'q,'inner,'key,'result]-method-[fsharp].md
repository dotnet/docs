---
title: QueryBuilder.Join<'Outer,'Q,'Inner,'Key,'Result> Method (F#)
description: QueryBuilder.Join<'Outer,'Q,'Inner,'Key,'Result> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4cbf6295-e6cd-449b-8c5d-835613557a14
---

# QueryBuilder.Join<'Outer,'Q,'Inner,'Key,'Result> Method (F#)

A query operator that correlates two sets of selected values based on matching keys. Normal usage is `join (for y in elements2 -> key1 = key2)`.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Join : QuerySource<'Outer,'Q> * QuerySource<'Inner,'Q> * ('Outer -> 'Key) * ('Inner -> 'Key) * ('Outer -> 'Inner -> 'Result) -> QuerySource<'Result,'Q>

// Usage:
queryBuilder.Join (outerSource, innerSource, outerKeySelector, innerKeySelector, resultSelector)
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


A function that returns the outer correlation key.


*innerKeySelector*
Type: 'Inner -&gt; 'Key


A function that returns the inner correlation key.


*resultSelector*
Type: 'Outer -&gt; 'Inner -&gt;
'Result


A function to return the results of the join operation.


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
