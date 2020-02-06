---
title: Collections.Map<'Key,'Value> Constructor (F#)
description: Collections.Map<'Key,'Value> Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9ab8a157-6f6b-4078-b45c-194b2100d50e 
---

# Collections.Map<'Key,'Value> Constructor (F#)

Builds a map that contains the bindings of the given [`System.Collections.Generic.IEnumerable`](https://msdn.microsoft.com/library/9eekhta0.aspx).

**Namespace/Module Path**: Microsoft.FSharp.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
new Map : seq<'Key * 'Value> -> Map<'Key, 'Value> (requires comparison)

// Usage:
new Map (elements)
```

#### Parameters

*elements*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'Key &#42; 'Value&gt;**

The input sequence of key/value pairs.

## Return Value

The resulting map.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Map&#60;'Key,'Value&#62; Class &#40;F&#35;&#41;](Collections.Map%5B%27Key%2C%27Value%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
