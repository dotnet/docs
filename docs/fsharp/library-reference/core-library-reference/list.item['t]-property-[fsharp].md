---
title: List.Item<'T> Property (F#)
description: List.Item<'T> Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: da4d7292-131c-4003-bb7b-ae8adc47fb51 
---

# List.Item<'T> Property (F#)

Gets the element of the list at the given position.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Item (int) :  'T

// Usage:
list.[index]
```

#### Parameters
*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index.

## Return Value

The value at the given index.

## Remarks
Lists are represented as linked lists so this is an `O(n)` operation.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List&#60;'T&#62; Union &#40;F&#35;&#41;](Collections.List%5B%27T%5D-Union-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)