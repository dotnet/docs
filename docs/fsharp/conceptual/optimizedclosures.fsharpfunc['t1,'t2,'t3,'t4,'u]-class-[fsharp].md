---
title: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'U> Class (F#)
description: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'U> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 48ce5fdd-d1b4-495d-a37a-40b3ca3d3d25
---

# OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'U> Class (F#)

The .NET Framework type used to represent F# function values that accept four curried arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpFunc<'T1,'T2,'T3,'T4,'U> =
class
new FSharpFunc : unit -> FSharpFunc<'T1,'T2,'T3,'T4,'U>
static member FSharpFunc.Adapt : ('T1 -> 'T2 -> 'T3 -> 'T4 -> 'U) -> FSharpFunc<'T1,'T2,'T3,'T4,'U>
abstract this.Invoke : FSharpFunc<'T1,'T2,'T3,'T4,'U> -> 'T1 * 'T2 * 'T3 * 'T4 -> 'U
end
```

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/62181386-9a25-4128-9c15-3598896938c5)|Construct an optimized function value that can accept four curried arguments without intervening execution.|

## Instance Members

|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/af2da4ee-17f5-477c-a553-a347feeac3b8)|Invoke an F# first class function value that accepts four curried arguments without intervening execution|

## Static Members

|Member|Description|
|------|-----------|
|[Adapt](https://msdn.microsoft.com/library/b1ee44d3-5054-4d0a-817b-8404cb8447a7)|Adapt an F# first class function value to be an optimized function value that can accept four curried arguments without intervening execution.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)
