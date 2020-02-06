---
title: List.Cons<'T> Method (F#)
description: List.Cons<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f419eeff-1be6-4aed-b6fd-57f8c76021bc 
---

# List.Cons<'T> Method (F#)

Returns a list with *head* as its first element and *tail* as its subsequent elements.

**Namespace/Module Path**: Microsoft.FSharp.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member List.Cons : 'T * 'T list -> 'T list

// Usage:
List.Cons (head, tail)
```

#### Parameters
*head*
Type: **'T**


A new head value for the list.


*tail*
Type: **'T list**


The existing list.

## Return Value

The list with head appended to the front of tail.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List&#60;'T&#62; Union &#40;F&#35;&#41;](Collections.List%5B%27T%5D-Union-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)