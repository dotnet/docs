---
title: QueryBuilder.GroupValBy<'T,'Key,'Value,'Q> Method (F#)
description: QueryBuilder.GroupValBy<'T,'Key,'Value,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 071ed67a-1eea-4b6f-b7aa-c8eb623f2075
---

# QueryBuilder.GroupValBy<'T,'Key,'Value,'Q> Method (F#)

A query operator that selects a value for each element selected so far and groups the elements by the given key.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.GroupValBy : QuerySource<'T,'Q> * ('T -> 'Value) * ('T -> 'Key) -> QuerySource<IGrouping<'Key,'Value>,'Q> when 'Key : equality

// Usage:
queryBuilder.GroupValBy (source, resultSelector, keySelector)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.


*resultSelector*
Type: 'T -&gt; 'Value


A function that computes a value for each element.


*keySelector*
Type: 'T -&gt; 'Key


A function that returns the grouping key for each element.

## Return Value
The grouped query.


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
