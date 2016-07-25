---
title: Lazy.Force<'T> Extension Method (F#)
description: Lazy.Force<'T> Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b532f1c5-e87e-4774-a0ff-ab490b02d080 
---

# Lazy.Force<'T> Extension Method (F#)

Forces the execution of this value and returns its result. Same as `System.Lazy.Value`. Mutual exclusion is used to prevent other threads from also computing the value.

**Namespace/Module Path**: Microsoft.FSharp.Control.LazyExtensions

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.Lazy with
member Force : unit -> 'T

// Usage:
lazy.Force ()
```

## Return Value

The value of the [`Lazy`](https://msdn.microsoft.com/library/b29d0af5-6efb-4a55-a278-2662a4ecc489) object.

## Example

[!code-fsharp[Main](snippets/fscorelib2/snippet13.fs)]

The output indicates that when Force is called to create the value for lazyVal1, the computed value is retrieved when printing the values.

```
Retrieving stored value: 479001600
Computing value: 3628800
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Control.LazyExtensions Module &#40;F&#35;&#41;](Control.LazyExtensions-Module-%5BFSharp%5D.md)

[Lazy Computations &#40;F&#35;&#41;](Lazy-Computations-%5BFSharp%5D.md)