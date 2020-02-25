---
title: System.Threading Namespace (F#)
description: System.Threading Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c379df53-77db-4f17-aace-399a65a32494 
---

# System.Threading Namespace (F#)

This topic describes the F# extensions to the `System.Threading` namespace. For information about the .NET Framework `System.Threading` namespace, see `System.Threading`.

**Namespace/Module Path**: System.Threading

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace System.Threading
```

## Remarks
The APIs documented in this topic are provided for use only with the version of the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 version of these APIs, which are documented in `System.Threading`.


## Type Definitions


|Type|Description|
|----|-----------|
|type [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)|Represents a capability to detect cancellation of an operation.|
|type [CancellationTokenRegistration](https://msdn.microsoft.com/library/9696e15c-a160-4336-9c5c-6277eaa1e1d1)|Represents a registration to a Cancellation token source.|
|type [CancellationTokenSource](https://msdn.microsoft.com/library/0aba0101-26eb-41d9-bffc-8b536b1581e8)|Signals to a **CancellationToken** that it should be cancelled.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)