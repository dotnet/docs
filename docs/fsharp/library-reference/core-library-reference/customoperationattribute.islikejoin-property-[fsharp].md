---
title: CustomOperationAttribute.IsLikeJoin Property (F#)
description: CustomOperationAttribute.IsLikeJoin Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 014830cd-29bd-411e-8313-74e861cec9ec 
---

# CustomOperationAttribute.IsLikeJoin Property (F#)

Indicates if the custom operation is an operation similar to a join in a sequence computation, in that it supports two inputs and a correlation constraint.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
member this.IsLikeJoin : bool with get, set
// Usage:
customOperationAttribute.IsLikeJoincustomOperationAttribute.IsLikeJoin <- isLikeJoin
```

## Property Value
`true` if the operation is like a join.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.CustomOperationAttribute Class &#40;F&#35;&#41;](Core.CustomOperationAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)