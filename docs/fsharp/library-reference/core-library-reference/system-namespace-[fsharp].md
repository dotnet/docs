---
title: System Namespace (F#)
description: System Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 830fa460-baf0-4555-8c23-519c34c5afa7 
---

# System Namespace (F#)

This topic describes the F# extensions to the System namespace. For the .NET Framework System namespace, see `System`.

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace System
```

## Remarks
The APIs documented in this topic are provided for use only with the version of the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 version of these APIs, which are documented in `System`.


## Type Definitions


|Type|Description|
|----|-----------|
|type [AggregateException](https://msdn.microsoft.com/library/ae45f193-7168-4627-94f2-3c7928c78f61)|Represents one or more errors that occur during application execution.|
|type [IObservable&lt;'T&gt;](https://msdn.microsoft.com/library/04855e2b-42e4-4342-860a-b86566c4f2d9)|A source of observable results|
|type [IObserver&lt;'T&gt;](https://msdn.microsoft.com/library/38436152-0d4c-4b0f-9916-440b34f377fb)|A client that may be subscribed to observe the results from an IObservable.|
|type [Lazy&lt;'T&gt;](https://msdn.microsoft.com/library/0ad70644-137c-4a59-b125-163c489c07a6)|Encapsulates a lazily computed value.|
|type [Tuple&lt;'T1,'T2,'T3,'T4,'T5,'T6,'T7,'TRest&gt;](https://msdn.microsoft.com/library/8e191b64-0a93-4b47-973c-b92ac5726116)||
|type [Tuple&lt;'T1,'T2,'T3,'T4,'T5,'T6,'T7&gt;](https://msdn.microsoft.com/library/558d020e-7ba6-4686-82c6-938ff29247ce)||
|type [Tuple&lt;'T1,'T2,'T3,'T4,'T5,'T6&gt;](https://msdn.microsoft.com/library/3e4a07fc-8f49-4e17-9e75-a11c5ca71707)||
|type [Tuple&lt;'T1,'T2,'T3,'T4,'T5&gt;](https://msdn.microsoft.com/library/bc9b80c0-4dbb-4363-b1f0-7bd6224b5d2b)||
|type [Tuple&lt;'T1,'T2,'T3,'T4&gt;](https://msdn.microsoft.com/library/e423ea16-8a7a-4845-baa8-143ee5775d92)||
|type [Tuple&lt;'T1,'T2,'T3&gt;](https://msdn.microsoft.com/library/a3b7aab4-d00b-4a48-9347-6880e4dafe9e)||
|type [Tuple&lt;'T1,'T2&gt;](https://msdn.microsoft.com/library/bab6f387-fb9c-4ed5-beda-a51f80c149bb)||
|type [Tuple&lt;'T1&gt;](https://msdn.microsoft.com/library/5ac7953d-acdc-4a58-bfb7-c1f6406c0fa3)|Compiled versions of F# tuple types. These are not used directly, though these compiled forms are seen by other CLI languages.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)