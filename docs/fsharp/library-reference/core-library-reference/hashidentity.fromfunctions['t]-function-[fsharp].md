---
title: HashIdentity.FromFunctions<'T> Function (F#)
description: HashIdentity.FromFunctions<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 85b45ae5-fe45-42e1-89c3-798075392044 
---

# HashIdentity.FromFunctions<'T> Function (F#)

Hash using the given hashing and equality functions.

**Namespace/Module Path:** Microsoft.FSharp.Collections.HashIdentity

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
FromFunctions : ('T -> int) -> ('T -> 'T -> bool) -> IEqualityComparer<'T>

// Usage:
FromFunctions hasher equality
```

#### Parameters
*hasher*
Type: **'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


A function to generate a hash code from a value.


*equality*
Type: **'T -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function to test equality of two values.

## Return Value

An object that implements `System.Collections.IEqualityComparer` using the supplied functions.

## Remarks

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.HashIdentity Module &#40;F&#35;&#41;](Collections.HashIdentity-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)