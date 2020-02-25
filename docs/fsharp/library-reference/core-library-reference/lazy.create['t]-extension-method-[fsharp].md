---
title: Lazy.Create<'T> Extension Method (F#)
description: Lazy.Create<'T> Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6c33477d-1127-4713-b1ef-ce80a250b126 
---

# Lazy.Create<'T> Extension Method (F#)

Creates a lazy computation that evaluates to the result of the given function when forced.

**Namespace/Module Path:** Microsoft.FSharp.Control.LazyExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.Lazy with
member static Create : Lazy<'T>

// Usage:
lazy.Create (creator)
```

#### Parameters
*creator*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'T**


The function to provide the value when needed.

## Return Value

The created [`Lazy`](https://msdn.microsoft.com/library/b29d0af5-6efb-4a55-a278-2662a4ecc489) object.

## Example

[!code-fsharp[Main](snippets/fscorelib2/snippet11.fs)]

The output is the factorial of 10.

```
3628800
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Control.LazyExtensions Module &#40;F&#35;&#41;](Control.LazyExtensions-Module-%5BFSharp%5D.md)

[Lazy Computations &#40;F&#35;&#41;](Lazy-Computations-%5BFSharp%5D.md)