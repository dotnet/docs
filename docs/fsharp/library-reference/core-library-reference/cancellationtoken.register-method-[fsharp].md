---
title: CancellationToken.Register Method (F#)
description: CancellationToken.Register Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2346c846-868c-41b7-9b82-c684b2f76d53 
---

# CancellationToken.Register Method (F#)

Registers an action to perform with the CancellationToken.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
member this.Register : Action<obj> * obj -> CancellationTokenRegistration

// Usage:
cancellationToken.Register (action, state)
```

#### Parameters

*action*
Type: **System.Action&#96;1****&lt;**[obj]**&gt;**

The action to associate with the token.

*state*
Type: [obj]

The state associated with the action.

## Return Value

Returns the created registration object.

## Remarks

This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, [`System.Threading.CancellationToken.Register`](https://msdn.microsoft.com/library/dd321635.aspx).

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0

## See Also

[Threading.CancellationToken Structure &#40;F&#35;&#41;](Threading.CancellationToken-Structure-%5BFSharp%5D.md)

[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)