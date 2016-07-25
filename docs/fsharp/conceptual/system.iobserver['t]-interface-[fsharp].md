---
title: System.IObserver<'T> Interface (F#)
description: System.IObserver<'T> Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c84d60a7-2443-4a1e-8bdf-836edf122d85 
---

# System.IObserver<'T> Interface (F#)

A client that may be subscribed to observe the results from an `IObservable`.

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AllowNullLiteral>]
type IObserver<'T> =
interface
abstract this.OnCompleted : unit -> unit
abstract this.OnError : exn -> unit
abstract this.OnNext : 'T -> unit
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.IObserver`.


## Instance Members


|Member|Description|
|------|-----------|
|[OnCompleted](https://msdn.microsoft.com/library/0c16300c-67b0-4bc7-98e0-6f31ef00420f)|Notify an observer that no more results will be produced|
|[OnError](https://msdn.microsoft.com/library/fc34d34d-9fed-4eb0-99f3-667cb85929c1)|Notify an observer of an error|
|[OnNext](https://msdn.microsoft.com/library/3d2e91d2-c589-431c-b9e3-e822b422f29c)|Notify an observer of a new result|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)