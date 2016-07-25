---
title: Threading.CancellationToken Structure (F#)
description: Threading.CancellationToken Structure (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3f0c336b-8fec-4dbb-abd9-13565441543e 
---

# Threading.CancellationToken Structure (F#)

Represents a capability to detect cancellation of an operation.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<CustomEquality>]
[<NoComparison>]
type CancellationToken =
struct
member this.Equals : CancellationToken -> bool
member this.Register : Action<obj> * obj -> CancellationTokenRegistration
member this.IsCancellationRequested :  bool
static member ( = ) : CancellationToken * CancellationToken -> bool
static member ( <> ) : CancellationToken * CancellationToken -> bool
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Threading.CancellationToken`.


## Instance Members


|Member|Description|
|------|-----------|
|[Equals](https://msdn.microsoft.com/library/cc57e149-d5db-488b-8eaa-ce6ebebba010)|Equality comparison against another token.|
|[IsCancellationRequested](https://msdn.microsoft.com/library/d7bca0a8-3410-416c-9165-3791d9ce743b)|Flags whether an operation should be cancelled.|
|[Register](https://msdn.microsoft.com/library/e2e0e6b6-2656-4cb7-9ad0-0a10cd874d6e)|Registers an action to perform with the CancellationToken.|

## Static Members


|Member|Description|
|------|-----------|
|[( &lt;&gt; )](https://msdn.microsoft.com/library/56682c19-8f21-459f-9839-2d13d34dfec2)|Inequality operator for tokens.|
|[( = )](https://msdn.microsoft.com/library/224f2bb1-9365-45c1-b50b-c8957f33fa7a)|Equality operator for tokens.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.Threading Namespace &#40;F&#35;&#41;](System.Threading-Namespace-%5BFSharp%5D.md)