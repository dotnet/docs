---
title: CancellationToken.( = ) Method (F#)
description: CancellationToken.( = ) Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 020eb358-4f5c-4ad2-9d65-325421d64973 
---

# CancellationToken.( = ) Method (F#)

Equality operator for tokens.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member ( = ) : CancellationToken * CancellationToken -> bool

// Usage:
token1 = token2
```

#### Parameters
*token1*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)


*token2*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)

## Return Value

True if the two tokens are equal.

## Remarks
This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, [`System.Threading.CancellationToken.Equality`](https://msdn.microsoft.com/library/system.threading.cancellationtoken.op_equality.aspx).


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Threading.CancellationToken Structure &#40;F&#35;&#41;](Threading.CancellationToken-Structure-%5BFSharp%5D.md)

[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)