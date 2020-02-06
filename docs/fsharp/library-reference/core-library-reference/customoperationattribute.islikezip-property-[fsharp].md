---
title: CustomOperationAttribute.IsLikeZip Property (F#)
description: CustomOperationAttribute.IsLikeZip Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 559d60db-d658-495e-8f9c-66df41de07a7 
---

# CustomOperationAttribute.IsLikeZip Property (F#)

Indicates if the custom operation is an operation similar to a zip in a sequence computation, in that it supports two inputs.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
member this.IsLikeZip : bool with get, set
// Usage:
customOperationAttribute.IsLikeZipcustomOperationAttribute.IsLikeZip <- isLikeZip
```

## Property Value
`true` if the operation resembles a zip operation.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.CustomOperationAttribute Class &#40;F&#35;&#41;](Core.CustomOperationAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)