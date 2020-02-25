---
title: OptimizedClosures.FSharpFunc<'T1,'T2,'U> Class (F#)
description: OptimizedClosures.FSharpFunc<'T1,'T2,'U> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 20aeea2b-9870-4704-aa84-b8890d41573f
---

# OptimizedClosures.FSharpFunc<'T1,'T2,'U> Class (F#)

The .NET Framework type used to represent F# function values that accept two iterated (curried) arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpFunc<'T1,'T2,'U> =
class
new FSharpFunc : unit -> FSharpFunc<'T1,'T2,'U>
static member FSharpFunc.Adapt : ('T1 -> 'T2 -> 'U) -> FSharpFunc<'T1,'T2,'U>
abstract this.Invoke : FSharpFunc<'T1,'T2,'U> -> 'T1 * 'T2 -> 'U
end
```

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/6bd2a7fb-34fe-412a-b051-431401959b3e)|Construct an optimized function value that can accept two curried arguments without intervening execution.|

## Instance Members

|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/3373e0ad-8a6e-4998-b906-35fb92bc8ca4)|Invoke the optimized function value with two curried arguments|

## Static Members

|Member|Description|
|------|-----------|
|[Adapt](https://msdn.microsoft.com/library/17223c26-7923-4b96-8ee8-3c1ce77fdcf6)|Adapt an F# first class function value to be an optimized function value that can accept two curried arguments without intervening execution.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)
