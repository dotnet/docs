---
title: Set.fold<'T,'State> Function (F#)
description: Set.fold<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1b00140f-7af2-42ec-935c-07b87881db10 
---

# Set.fold<'T,'State> Function (F#)

Applies the given accumulating function to all the elements of the set.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Set

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.fold : ('State -> 'T -> 'State) -> 'State -> Set<'T> -> 'State (requires comparison)

// Usage:
Set.fold folder state set
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


The accumulating function.


*state*
Type: **'State**


The initial state.


*set*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**


The input set.

## Return Value

The final state.

## Remarks
This function is named `Fold` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)