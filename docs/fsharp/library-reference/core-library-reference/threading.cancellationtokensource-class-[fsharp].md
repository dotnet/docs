---
title: Threading.CancellationTokenSource Class (F#)
description: Threading.CancellationTokenSource Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 53dd91ce-1135-408e-8c07-18beea630efe 
---

# Threading.CancellationTokenSource Class (F#)

Signals to a `CancellationToken` that it should be cancelled.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
[<AllowNullLiteral>]
type CancellationTokenSource =
class
interface IDisposable
new CancellationTokenSource : unit -> CancellationTokenSource
member this.Cancel : unit -> unit
static member CreateLinkedTokenSource : CancellationToken * CancellationToken -> CancellationTokenSource
member this.Dispose : unit -> unit
member this.Token :  CancellationToken
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Threading.CancellationTokenSource`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/42dfcfe7-101c-43f6-b92a-83332a4b993e)|Creates a new cancellation capability.|

## Instance Members


|Member|Description|
|------|-----------|
|[Cancel](https://msdn.microsoft.com/library/c66b158e-7af8-4b4b-8b46-126d4d9c15e8)|Cancels the operation.|
|[Dispose](https://msdn.microsoft.com/library/dd4d00a8-da36-4fc4-8525-a1f89653cc1c)|Discards resources associated with this capability.|
|[Token](https://msdn.microsoft.com/library/02eac69e-62eb-4b1b-a247-27adaa30c88a)|Fetches the token representing the capability to detect cancellation of an operation.|

## Static Members


|Member|Description|
|------|-----------|
|[CreateLinkedTokenSource](https://msdn.microsoft.com/library/a75ae3f2-9924-4079-aaab-7f8bea64a2e8)|Creates a cancellation capability linking two tokens.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)