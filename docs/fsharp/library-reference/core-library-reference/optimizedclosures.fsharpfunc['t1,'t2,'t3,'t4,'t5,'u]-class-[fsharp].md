---
title: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U> Class (F#)
description: OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a5e486cd-d589-4c5a-878f-d9acab12f778
---

# OptimizedClosures.FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U> Class (F#)

The .NET Framework type used to represent F# function values that accept five curried arguments without intervening execution. This type should not typically used directly from either F# code or from other .NET Framework languages.

**Namespace/Module Path:** Microsoft.FSharp.Core.OptimizedClosures

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U> =
class
new FSharpFunc : unit -> FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U>
static member FSharpFunc.Adapt : ('T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'U) -> FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U>
abstract this.Invoke : FSharpFunc<'T1,'T2,'T3,'T4,'T5,'U> -> 'T1 * 'T2 * 'T3 * 'T4 * 'T5 -> 'U
end
```

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/157c9690-3ae4-46e8-861c-ac62609a1260)|Construct an optimized function value that can accept five curried arguments without intervening execution.|

## Instance Members

|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/f0e772d3-ebcc-43af-a255-acbd4b846dc8)|Invoke an F# first class function value that accepts five curried arguments without intervening execution|

## Static Members

|Member|Description|
|------|-----------|
|[Adapt](https://msdn.microsoft.com/library/0259033d-62ec-4f52-9f05-d9c30e912e7c)|Adapt an F# first class function value to be an optimized function value that can accept five curried arguments without intervening execution.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.OptimizedClosures Module &#40;F&#35;&#41;](Core.OptimizedClosures-Module-%5BFSharp%5D.md)
