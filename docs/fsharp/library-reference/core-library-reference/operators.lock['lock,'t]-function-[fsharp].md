---
title: Operators.lock<'Lock,'T> Function (F#)
description: Operators.lock<'Lock,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fe941ce8-a38c-4c1a-9ece-554d6ffbcd4a
---

# Operators.lock<'Lock,'T> Function (F#)

Execute the function as a mutual-exclusion region using the input value as a lock.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
lock : 'Lock -> (unit -> 'T) -> 'T (requires reference type)

// Usage:
lock lockObject action
```

#### Parameters
*lockObject*
Type: **'Lock**


The object to be locked.


*action*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'T**


The action to perform during the lock.

## Return Value

The resulting value.

## Remarks
This function is named `Lock` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
