---
title: ComparisonIdentity.Structural<'T> Type Function (F#)
description: ComparisonIdentity.Structural<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 96dc3737-5f2f-42a7-926e-34d1d79023a8 
---

# ComparisonIdentity.Structural<'T> Type Function (F#)

Returns a comparer object that performs structural comparison, by using [Operators.compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).

**Namespace/Module Path:** Microsoft.FSharp.Collections.ComparisonIdentity

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Structural<'T (requires comparison)> :  IComparer<'T> (requires comparison)

// Usage:
Structural
```

## Return Value

Returns an object that implements [`System.Collections.IComparer`](https://msdn.microsoft.com/library/system.collections.icomparer.aspx) that performs structural comparison.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.ComparisonIdentity Module &#40;F&#35;&#41;](Collections.ComparisonIdentity-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)