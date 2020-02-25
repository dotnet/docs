---
title: Set.add<'T> Function (F#)
description: Set.add<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c47d6fc4-8107-4d29-a4b6-5e45cdbc75a3 
---

# Set.add<'T> Function (F#)

Returns a new set with an element added to the set. No exception is raised if the set already contains the given element.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Set

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.add : 'T -> Set<'T> -> Set<'T> (requires comparison)

// Usage:
Set.add value set
```

#### Parameters
*value*
Type: **'T**


The value to add.


*set*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The input set.

## Return Value

A new set containing value.

## Remarks
This function is named `Add` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)