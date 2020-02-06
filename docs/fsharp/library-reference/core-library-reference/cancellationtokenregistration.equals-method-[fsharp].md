---
title: CancellationTokenRegistration.Equals Method (F#)
description: CancellationTokenRegistration.Equals Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 51509464-52bc-4554-b05c-ac4a7b7f00f8 
---

# CancellationTokenRegistration.Equals Method (F#)

Equality comparison against another registration.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Equals : CancellationTokenRegistration -> bool

// Usage:
cancellationTokenRegistration.Equals (registration)
```

#### Parameters
*registration*
Type: [CancellationTokenRegistration](https://msdn.microsoft.com/library/9696e15c-a160-4336-9c5c-6277eaa1e1d1)


The target for comparison.

## Return Value

`true` if the two registrations are equal.

## Remarks
This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, [`System.Threading.CancellationTokenRegistration.Equals`](https://msdn.microsoft.com/library/system.threading.cancellationtokenregistration.equals.aspx).

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Threading.CancellationTokenRegistration Structure &#40;F&#35;&#41;](Threading.CancellationTokenRegistration-Structure-%5BFSharp%5D.md)

[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)