---
title: Threading.CancellationTokenRegistration Structure (F#)
description: Threading.CancellationTokenRegistration Structure (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e22d599e-4175-42eb-a41c-8f6c71542fcb 
---

# Threading.CancellationTokenRegistration Structure (F#)

Represents a registration to a Cancellation token source.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<CustomEquality>]
[<NoComparison>]
type CancellationTokenRegistration =
struct
interface IDisposable
member this.Dispose : unit -> unit
member this.Equals : CancellationTokenRegistration -> bool
static member ( = ) : CancellationTokenRegistration * CancellationTokenRegistration -> bool
static member ( <> ) : CancellationTokenRegistration * CancellationTokenRegistration -> bool
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Threading.CancellationTokenRegistration`.


## Instance Members


|Member|Description|
|------|-----------|
|[Dispose](https://msdn.microsoft.com/library/4a8a2756-e94a-4806-aa79-c61bb3fd0023)|Frees resources associated with the registration.|
|[Equals](https://msdn.microsoft.com/library/6d93f758-49a8-4920-9910-400fc8c813ad)|Equality comparison against another registration.|

## Static Members


|Member|Description|
|------|-----------|
|[( &lt;&gt; )](https://msdn.microsoft.com/library/f9a1c67d-624e-4360-81d2-024d761cde25)|Inequality operator for registrations.|
|[( = )](https://msdn.microsoft.com/library/b5a5bdc1-3015-4155-90d5-619dab2e1d85)|Equality operator for registrations.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)