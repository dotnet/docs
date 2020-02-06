---
title: IntrinsicFunctions.TypeTestGeneric<'T> Function (F#)
description: IntrinsicFunctions.TypeTestGeneric<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cc2c72ca-435e-4011-8e41-6d019e833b3f 
---

# IntrinsicFunctions.TypeTestGeneric<'T> Function (F#)

A compiler intrinsic that implements the `:?` operator.

**Namespace/Module Path**: Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
TypeTestGeneric : obj -> bool

// Usage:
TypeTestGeneric source
```

#### Parameters
*source*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The object to test.

## Return Value

`true` if the type matches the specified type; otherwise `false`.

## Remarks
This function is for use by compiled F# code and should not be used directly.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)