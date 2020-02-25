---
title: QueryBuilder.GroupBy<'T,'Q,'Key> Method (F#)
description: QueryBuilder.GroupBy<'T,'Q,'Key> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 62352838-5592-4969-a352-154fc3e04e1a
---

# QueryBuilder.GroupBy<'T,'Q,'Key> Method (F#)

A query operator that groups the elements selected so far according to a specified key selector.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.GroupBy : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<IGrouping<'Key,'T>,'Q> when 'Key : equality

// Usage:
queryBuilder.GroupBy (source, keySelector)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.

*keySelector*
Type: 'T -&gt; 'Key


A function that specifies a grouping for each element.

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
