---
title: RuntimeHelpers.Grouping<'K,'T> Constructor (F#)
description: RuntimeHelpers.Grouping<'K,'T> Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2a36a070-a066-4433-8db6-7336b2e3074d
---

# RuntimeHelpers.Grouping<'K,'T> Constructor (F#)

Constructs a new instance of a grouping for use in F# query expressions.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
new Grouping : 'K * seq<'T> -> Grouping<'K,'T>

// Usage:
new Grouping (key, values)
```

#### Parameters
*key*
Type: 'K


The grouping key.


*values*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)&lt;'T&gt;


The values to be grouped.

## Return Value
A collection that represents the grouped values.



## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[RuntimeHelpers.Grouping&#60;'K,'T&#62; Class &#40;F&#35;&#41;](RuntimeHelpers.Grouping%5B%27K%2C%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)
