---
title: IntrinsicOperators.or Function (F#)
description: IntrinsicOperators.or Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cadb87aa-afeb-418d-99a1-e1520854c014 
---

# IntrinsicOperators.or Function (F#)

Binary `or`. When used as a binary operator the right hand value is evaluated only on demand.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
or : bool -> bool -> bool

// Usage:
or e1 e2
```

#### Parameters
*e1*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The first operand.


*e2*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The second operand.

## Return Value

The result of the Boolean `OR` operation.

## Remarks
This function is for use by compiled F# code and should not be used directly.

This function is named `Or` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicOperators Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicOperators-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)