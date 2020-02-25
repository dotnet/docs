---
title: Core.OptimizedClosures Module (F#)
description: Core.OptimizedClosures Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e2b2c7e3-54bf-4aa5-98cb-de8241704527 
---

# Core.OptimizedClosures Module (F#)

An implementation module used to hold some private implementations of function value invocation.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module OptimizedClosures
```

## Type Definitions

|Type|Description|
|----|-----------|
|type [FSharpFunc&lt;'T1,'T2,'U&gt;](https://msdn.microsoft.com/library/8e6a72a3-e385-4e94-8d06-d0f96e0eb647)|The .NET Framework type used to represent F# function values that accept two iterated (curried) arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.|
|type [FSharpFunc&lt;'T1,'T2,'T3,'U&gt;](https://msdn.microsoft.com/library/2e95913f-bcb4-458d-a8aa-151399355366)|The .NET Framework type used to represent F# function values that accept three iterated (curried) arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.|
|type [FSharpFunc&lt;'T1,'T2,'T3,'T4,'U&gt;](https://msdn.microsoft.com/library/8f831001-ef72-4261-bd43-63b440ea8f15)|The .NET Framework type used to represent F# function values that accept four curried arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.|
|type [FSharpFunc&lt;'T1,'T2,'T3,'T4,'T5,'U&gt;](https://msdn.microsoft.com/library/797270e8-2a37-495c-9b4b-48292415d213)|The .NET Framework type used to represent F# function values that accept five curried arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)