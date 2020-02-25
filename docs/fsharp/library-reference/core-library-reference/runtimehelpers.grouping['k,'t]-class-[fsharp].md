---
title: RuntimeHelpers.Grouping<'K,'T> Class (F#)
description: RuntimeHelpers.Grouping<'K,'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e3a6d37e-cabc-4a62-92fa-cdc697505217
---

# RuntimeHelpers.Grouping<'K,'T> Class (F#)

Reconstructs a grouping after applying a mutable to immutable mapping transformation on a result of a query. This type is used to implement `groupBy` and `groupValBy` for F# query expressions.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type [Grouping](https://msdn.microsoft.com/library/4a6ac4d6-5b30-44bb-b34d-c6773f86dedf)<'K,'T> =
class
inherit IEnumerable<'T>
inherit IEnumerable
inherit IGrouping<'K,'T>
new Grouping : 'K * seq<'T> -> Grouping<'K,'T>
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/6372a867-5fcd-41e1-9616-8d3d094d5103)|Constructs a new instance of **Grouping**.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)
