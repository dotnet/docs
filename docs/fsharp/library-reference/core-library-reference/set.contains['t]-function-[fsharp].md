---
title: Set.contains<'T> Function (F#)
description: Set.contains<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2afb469a-1e7c-45c6-9a4b-01cb3021fead 
---

# Set.contains<'T> Function (F#)

Evaluates to `true` if the given element is in the input set.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Set

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Set.contains : 'T -> Set<'T> -> bool (requires comparison)

// Usage:
Set.contains element set
```

#### Parameters
*element*
Type: **'T**

The element to test.

*set*
Type: [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)**&lt;'T&gt;**

The input set.

## Return Value

Evaluates to `true` if the given element is in the input set. Otherwise, it will return `false`.

## Remarks
This function is named `Contains` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
