---
title: QueryBuilder.Where<'T,'Q> Method (F#)
description: QueryBuilder.Where<'T,'Q> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 70d18472-1325-4e1b-a2b9-2b37c0c3d90b
---

# QueryBuilder.Where<'T,'Q> Method (F#)

A query operator that selects those elements based on a specified predicate.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Where : QuerySource<'T,'Q> * ('T -> bool) -> QuerySource<'T,'Q>

// Usage:
queryBuilder.Where (source, predicate)
```

#### Parameters
*source*
Type: [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;


The input query.


*predicate*
Type: 'T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A Boolean expression that specifies elements to select.

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

[How to: Handle Exceptions in Query Expressions (C# Programming Guide)](https://msdn.microsoft.com/library/4ce6c081-7731-4b8f-b4fa-d947f165a18a)
