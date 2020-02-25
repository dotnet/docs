---
title: Set.foldBack<'T,'State> Function (F#)
description: Set.foldBack<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4dc0f353-6db3-498b-8a5a-7a953326dd50 
---

# Set.foldBack<'T,'State> Function (F#)

Applies the given accumulating function to all the elements of the set.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Set

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.foldBack : ('T -> 'State -> 'State) -> Set<'T> -> 'State -> 'State (requires comparison)

// Usage:
Set.foldBack folder set state
```

#### Parameters
*folder*
Type: **'T -&gt; 'State -&gt; 'State**


The accumulating function.


*set*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The input set.


*state*
Type: **'State**


The initial state.

## Return Value

The final state.

## Remarks

This function is named `FoldBack` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)