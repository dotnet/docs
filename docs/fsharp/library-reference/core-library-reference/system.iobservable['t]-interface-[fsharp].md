---
title: System.IObservable<'T> Interface (F#)
description: System.IObservable<'T> Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1c0912ab-5e60-46ff-9843-7a665faf4c0b 
---

# System.IObservable<'T> Interface (F#)

A source of observable results

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AllowNullLiteral>]
type IObservable<'T> =
interface
abstract this.Subscribe : IObserver<'T> -> IDisposable
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.IObservable`.


## Instance Members


|Member|Description|
|------|-----------|
|[Subscribe](https://msdn.microsoft.com/library/e9c09e03-b1f9-4975-b992-1f222e8298ae)|Subscribe an observer to the source of results|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)

[Control.Observable Module &#40;F&#35;&#41;](Control.Observable-Module-%5BFSharp%5D.md)