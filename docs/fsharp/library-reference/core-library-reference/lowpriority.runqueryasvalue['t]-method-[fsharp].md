---
title: LowPriority.RunQueryAsValue<'T> Method (F#)
description: LowPriority.RunQueryAsValue<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8e4f05d3-64ca-4c62-af63-98038b9c89ce 
---

# LowPriority.RunQueryAsValue<'T> Method (F#)

Runs a query to produce a simple value.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.RunQueryAsValue : Expr<'T> -> 'T

// Usage:
queryBuilder.RunQueryAsValue (expr)
```

#### Parameters
*expr*
Type: [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)&lt;'T&gt;


The query as an expression.


## Return Value
The query result as a simple value.


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

[QueryRunExtensions.LowPriority Module (F#)](https://msdn.microsoft.com/library/4b4bf192-b3b1-4361-a550-df7d6643cabd)