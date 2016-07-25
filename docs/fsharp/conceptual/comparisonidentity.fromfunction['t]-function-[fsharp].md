---
title: ComparisonIdentity.FromFunction<'T> Function (F#)
description: ComparisonIdentity.FromFunction<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ee03a785-7598-4815-85a2-5755f27a5522 
---

# ComparisonIdentity.FromFunction<'T> Function (F#)

Compare using the given comparer function.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ComparisonIdentity

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
FromFunction : ('T -> 'T -> int) -> IComparer<'T>

// Usage:
FromFunction comparer
```

#### Parameters
*comparer*
Type: **'T -&gt; 'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


A function to compare two values.

## Return Value

An object implementing [`System.Collections.IComparer`](https://msdn.microsoft.com/library/system.collections.icomparer.aspx) using the supplied comparer.

## Remarks

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.ComparisonIdentity Module &#40;F&#35;&#41;](Collections.ComparisonIdentity-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)