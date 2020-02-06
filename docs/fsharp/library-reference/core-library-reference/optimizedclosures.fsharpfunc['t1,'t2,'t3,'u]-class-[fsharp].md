---
title: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'U> Class (F#)
description: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'U> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a512af2b-7911-4a18-9b01-dc3a8de1262f
---

# OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'U> Class (F#)

The .NET Framework type used to represent F# function values that accept three iterated (curried) arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpFunc<'T1,'T2,'T3,'U> =
class
new FSharpFunc : unit -> FSharpFunc<'T1,'T2,'T3,'U>
static member FSharpFunc.Adapt : ('T1 -> 'T2 -> 'T3 -> 'U) -> FSharpFunc<'T1,'T2,'T3,'U>
abstract this.Invoke : FSharpFunc<'T1,'T2,'T3,'U> -> 'T1 * 'T2 * 'T3 -> 'U
end
```

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/c3330e7d-d6a6-4ce0-b579-2600ad2e0a74)|Construct an optimized function value that can accept three curried arguments without intervening execution.|

## Instance Members

|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/212501c1-8378-461b-b5ad-54f8b3d41f56)|Invoke an F# first class function value that accepts three curried arguments without intervening execution|

## Static Members

|Member|Description|
|------|-----------|
|[Adapt](https://msdn.microsoft.com/library/785cfdb2-21e1-4f8f-930f-db6de480ae47)|Adapt an F# first class function value to be an optimized function value that can accept three curried arguments without intervening execution.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)
