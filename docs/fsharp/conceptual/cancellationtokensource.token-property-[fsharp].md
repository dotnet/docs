---
title: CancellationTokenSource.Token Property (F#)
description: CancellationTokenSource.Token Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8c34e0a1-4394-43ac-9bf5-1d98249b88d5 
---

# CancellationTokenSource.Token Property (F#)

Fetches the token representing the capability to detect cancellation of an operation.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
member this.Token :  CancellationToken

// Usage:
cancellationTokenSource.Token
```

## Return Value
Returns a `System.Threading.CancellationToken` object.

## Remarks

This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, [`System.Threading.CancellationTokenSource.Token`](https://msdn.microsoft.com/library/system.threading.cancellationtokensource.aspx).

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0

## See Also

[Threading.CancellationTokenSource Class &#40;F&#35;&#41;](Threading.CancellationTokenSource-Class-%5BFSharp%5D.md)

[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)