---
title: Control.CommonExtensions Module (F#)
description: Control.CommonExtensions Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c5d5e0a5-fe47-4354-aa0f-5be78417bae7 
---

# Control.CommonExtensions Module (F#)

A module of extension members providing asynchronous operations for some basic CLI types related to concurrency and I/O.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AutoOpen>]
module CommonExtensions
```

## Extension Members

|Extension Member|Description|
|----------------|-----------|
|[Add](https://msdn.microsoft.com/library/cf21f284-ab78-4628-9585-090df11336c5)<br />**: ('T -&gt; unit) -&gt; unit**|Permanently connects a listener function to the observable. The listener will be invoked for each observation.|
|[Subscribe](https://msdn.microsoft.com/library/cf21f284-ab78-4628-9585-090df11336c5)<br />**: ('T -&gt; unit) -&gt; IDisposable**|Connects a listener function to the observable. The listener will be invoked for each observation. You can remove the listener by calling `System.IDisposable.Dispose` on the returned `System.IDisposable` object.|
|[AsyncRead](https://msdn.microsoft.com/library/85698aaa-bdda-47e6-abed-3730f59fda5e)<br />**: byte [] &#42; ?int &#42; ?int -&gt; Async&lt;int&gt;**|Returns an asynchronous computation that will read from the stream into the given buffer.|
|[AsyncWrite](https://msdn.microsoft.com/library/1b0a2751-e42a-47e1-bd27-020224adc618)<br />**: byte[] &#42; ?int &#42; ?int -&gt; Async&lt;unit&gt;**|Returns an asynchronous computation that will write the given bytes to the stream.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)