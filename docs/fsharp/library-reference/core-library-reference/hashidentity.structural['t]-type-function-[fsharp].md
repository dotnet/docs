---
title: HashIdentity.Structural<'T> Type Function (F#)
description: HashIdentity.Structural<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e57df75e-3521-48b4-861b-bc442fe511ec 
---

# HashIdentity.Structural<'T> Type Function (F#)

Implements structural hashing. Hashes using [`Operators.(=)`](https://msdn.microsoft.com/library/5b1167e1-cc30-4d26-9f1d-556b2a308187) and [`Operators.hash`](https://msdn.microsoft.com/library/a83c0432-919e-407d-9ffc-8cf34fbc6daa).

**Namespace/Module Path:** Microsoft.FSharp.Collections.HashIdentity

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Structural<'T (requires equality)> :  IEqualityComparer<'T> (requires equality)

// Usage:
Structural
```

## Return Value

An object that implements `System.Collections.IEqualityComparer`.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.HashIdentity Module &#40;F&#35;&#41;](Collections.HashIdentity-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)