---
title: Collections.ComparisonIdentity Module (F#)
description: Collections.ComparisonIdentity Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 00075168-5d15-4bf5-bf9e-8ed4a04e85ea 
---

# Collections.ComparisonIdentity Module (F#)

Common notions of comparison identity used with sorted data structures.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module ComparisonIdentity
```

## Values


|Value|Description|
|-----|-----------|
|[FromFunction](https://msdn.microsoft.com/library/96d24027-4779-4f73-a611-91cbaca2ff9c)<br />**: ('T -&gt; 'T -&gt; int) -&gt; IComparer&lt;'T&gt;**|Compare using the given comparer function.|
|[Structural](https://msdn.microsoft.com/library/af092340-5ab2-478f-b873-1c88d97a0365)<br />**: IComparer&lt;'T&gt;**|Structural comparison. Compare using [Operators.compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

