---
title: Async.AwaitIAsyncResult Method (F#)
description: Async.AwaitIAsyncResult Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 38be2b33-a9a3-4717-a6b1-6540a92f4922 
---

# Async.AwaitIAsyncResult Method (F#)

Creates an asynchronous computation that will wait on the [`System.IAsyncResult`](https://msdn.microsoft.com/library/system.iasyncresult.aspx).

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member AwaitIAsyncResult : IAsyncResult * ?int -> Async<bool>

// Usage:
Async.AwaitIAsyncResult (iar)
Async.AwaitIAsyncResult (iar, millisecondsTimeout = millisecondsTimeout)
```

#### Parameters

*iar*
Type: **System.IAsyncResult**

The IAsyncResult to wait on.

*millisecondsTimeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The timeout value in milliseconds. If one is not provided then the default value of -1 corresponding to **System.Threading.Timeout.Infinite**.

## Return Value

Returns an asynchronous computation that waits on the given [`System.IAsyncResult`](https://msdn.microsoft.com/library/system.iasyncresult.aspx).

## Remarks

The computation returns `true` if the handle indicated a result within the given timeout.

The following code example illustrates how to use Async.AwaitIAsyncResult to set up and execute a computation that is triggered when a previous .NET Framework asynchronous operation that produces an [`System.IAsyncResult`](https://msdn.microsoft.com/library/system.iasyncresult.aspx) finishes. In this case, the call to `AwaitIAsyncResult` causes the operation to wait for a file write operation to be completed before opening the file for reading.

```fsharp
open System.IO

let streamWriter1 = File.CreateText("test1.txt")
let count = 10000000
let buffer = Array.init count (fun index -> byte (index % 256)) 

printfn "Writing to file test1.txt."
let asyncResult = streamWriter1.BaseStream.BeginWrite(buffer, 0, count, null, null)

// Read a file, but use AwaitIAsyncResult to wait for the write operation
// to be completed before reading.
let readFile filename asyncResult count = 
    async {
        let! returnValue = Async.AwaitIAsyncResult(asyncResult)
        printfn "Reading from file test1.txt."
        // Close the file.
        streamWriter1.Close()
        // Now open the same file for reading.
        let streamReader1 = File.OpenText(filename)
        let! newBuffer = streamReader1.BaseStream.AsyncRead(count)
        return newBuffer
    }

let bufferResult = readFile "test1.txt" asyncResult count
                   |> Async.RunSynchronously
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
