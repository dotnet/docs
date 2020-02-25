---
title: CancellationToken.Equals Method (F#)
description: CancellationToken.Equals Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 12106503-a0a9-460a-a1c8-84c738c5c378 
---

# CancellationToken.Equals Method (F#)

Equality comparison against another token.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Equals : CancellationToken -> bool

// Usage:
cancellationToken.Equals (token)
```

#### Parameters
*token*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)


The target for comparison.


## Return Value
True if the two tokens are equal.

## Remarks
This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, [`System.Threading.CancellationToken.Equals`](https://msdn.microsoft.com/library/system.threading.cancellationtoken.equals.aspx).


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Threading.CancellationToken Structure &#40;F&#35;&#41;](Threading.CancellationToken-Structure-%5BFSharp%5D.md)

[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)