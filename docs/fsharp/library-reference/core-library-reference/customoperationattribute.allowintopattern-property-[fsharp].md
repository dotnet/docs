---
title: CustomOperationAttribute.AllowIntoPattern Property (F#)
description: CustomOperationAttribute.AllowIntoPattern Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c0d29fa9-5fc8-419c-b46b-8a51e2b21269 
---

# CustomOperationAttribute.AllowIntoPattern Property (F#)

Indicates if the custom operation supports the use of `into` immediately after the use of the operation in a query or other computation expression to consume the results of the operation.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.AllowIntoPattern : bool with get, set
// Usage:
customOperationAttribute.AllowIntoPattern
```

## Property Value
`true` if the operation supports the use of `into`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.CustomOperationAttribute Class &#40;F&#35;&#41;](Core.CustomOperationAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)