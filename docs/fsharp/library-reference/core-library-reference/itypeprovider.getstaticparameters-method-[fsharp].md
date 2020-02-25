---
title: ITypeProvider.GetStaticParameters Method (F#)
description: ITypeProvider.GetStaticParameters Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a198ee08-c101-47e2-80ae-a432f64f0946 
---

# ITypeProvider.GetStaticParameters Method (F#)

Get the static parameters for a provided type.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GetStaticParameters : Type -> ParameterInfo []

// Usage:
iTypeProvider.GetStaticParameters (typeWithoutArguments)
```

#### Parameters
*typeWithoutArguments*
Type: **System.Type**


A type returned by GetTypes or ResolveTypeName

## Return Value
An array of parameters.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0Supported in: 4.0, Portable

## See Also
[CompilerServices.ITypeProvider Interface &#40;F&#35;&#41;](CompilerServices.ITypeProvider-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)