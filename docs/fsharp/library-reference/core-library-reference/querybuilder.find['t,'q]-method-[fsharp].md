---
title: QueryBuilder.Find<'T,'Q> Method (F#)
description: QueryBuilder.Find<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 185ca69b-644c-4f25-9daf-137457c93beb
---

# QueryBuilder.Find<'T,'Q> Method (F#)

A query operator that selects the first element selected so far that satisfies a specified condition.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Find : QuerySource<'T,'Q> * ('T -> bool) -> 'T

// Usage:
queryBuilder.Find (source, predicate)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.


*predicate*
Type: 'T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function that tests each element.


## Exceptions
|Exception|Condition|
|----|----|
|[InvalidOperationException](https://msdn.microsoft.com/library/system.invalidoperationexception.aspx)|Thrown when no element returns **true** when evaluated by the predicate.|


## Return Value
The first element for which the Boolean function *predicate* returns `true`.

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
