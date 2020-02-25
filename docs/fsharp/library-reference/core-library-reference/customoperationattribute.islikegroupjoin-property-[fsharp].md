---
title: CustomOperationAttribute.IsLikeGroupJoin Property (F#)
description: CustomOperationAttribute.IsLikeGroupJoin Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dbc32c8f-cfd1-43a2-8cbf-3f0a4d8fefc1 
---

# CustomOperationAttribute.IsLikeGroupJoin Property (F#)

Indicates if the custom operation is an operation similar to a group join in a sequence computation, in that the operation supports two inputs and a correlation constraint, and generates a group.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
member this.IsLikeGroupJoin : bool with get, set
// Usage:
customOperationAttribute.IsLikeGroupJoincustomOperationAttribute.IsLikeGroupJoin <- isLikeGroupJoin
```

## Property Value
`true` if the operation resembles a group join.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.CustomOperationAttribute Class &#40;F&#35;&#41;](Core.CustomOperationAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)