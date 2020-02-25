---
title: QueryBuilder.ExactlyOne<'T,'Q> Method (F#)
description: QueryBuilder.ExactlyOne<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7272bffe-ed0a-4d0d-bd7d-53ab17135e8f
---

# QueryBuilder.ExactlyOne<'T,'Q> Method (F#)

A query operator that selects the single, specific element selected so far.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.ExactlyOne : QuerySource<'T,'Q> -> 'T

// Usage:
queryBuilder.ExactlyOne (source)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.

## Exceptions
|Exception|Condition|
|----|----|
|[InvalidOperationException](https://msdn.microsoft.com/library/system.invalidoperationexception.aspx)|Thrown when the query contains more than one selected element.|

## Return Value
A single element.


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
