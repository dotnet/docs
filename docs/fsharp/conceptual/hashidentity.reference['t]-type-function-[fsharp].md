---
title: HashIdentity.Reference<'T> Type Function (F#)
description: HashIdentity.Reference<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4e7cc1e9-1ace-474f-824b-1aee1d29093b 
---

# HashIdentity.Reference<'T> Type Function (F#)

Implements physical hashing, which means that it hashes on reference identity of objects, and the contents of value types.

**Namespace/Module Path:** Microsoft.FSharp.Collections.HashIdentity

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Reference<'T (requires reference type)> :  IEqualityComparer<'T> (requires reference type)

// Usage:
Reference
```

## Return Value

An object that implements `System.Collections.IEqualityComparer`.

## Remarks
This function hashes using [`LanguagePrimitives.PhysicalEquality`](https://msdn.microsoft.com/library/1783ed93-63f4-4936-832f-4bf0db6e3586) and [`LanguagePrimitives.PhysicalHash`](https://msdn.microsoft.com/library/8c93ad8b-70d2-4035-9961-ba0f84d9458b). That is, for value types uses `System.Object.GetHashCode` and `Overload:System.Object.Equals` (if no other optimization available), and for reference types uses `System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(System.Object)` and reference equality.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.HashIdentity Module &#40;F&#35;&#41;](Collections.HashIdentity-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)