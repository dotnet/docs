---
title: Linq.QuerySource<'T,'Q> Constructor (F#)
description: Linq.QuerySource<'T,'Q> Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 90efe751-9585-4600-8756-e6e7e1237fb1 
---

# Linq.QuerySource<'T,'Q> Constructor (F#)

Constructs an instance of `QuerySource`.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
new QuerySource : seq<'T> -> QuerySource<'T,'Q>

// Usage:
new QuerySource (source)
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)&lt;'T&gt;


An enumerable sequence of data to query against, such as a database table or collection.


## Return Value
A new instance of `QuerySource`.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.QuerySource&#60;'T,'Q&#62; Class &#40;F&#35;&#41;](Linq.QuerySource%5B%27T%2C%27Q%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)