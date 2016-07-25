---
title: Async.AwaitWaitHandle Method (F#)
description: Async.AwaitWaitHandle Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 70f5df5a-57b3-471d-8662-ed81be7a3dfa 
---

# Async.AwaitWaitHandle Method (F#)

Creates an asynchronous computation that will wait for the supplied [`System.Threading.WaitHandle`](https://msdn.microsoft.com/library/system.threading.waithandle.aspx).

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member AwaitWaitHandle : WaitHandle * ?int -> Async<bool>

// Usage:
Async.AwaitWaitHandle (waitHandle)
Async.AwaitWaitHandle (waitHandle, millisecondsTimeout = millisecondsTimeout)
```

#### Parameters

*waitHandle*
Type:  [`System.Threading.WaitHandle`](https://msdn.microsoft.com/library/system.threading.waithandle.aspx)

The wait handle that can be signaled.

*millisecondsTimeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The timeout value in milliseconds. If no timeout value is provided, the default value is -1, which corresponds to `System.Threading.Timeout.Infinite`.

## Return Value

Returns an asynchronous computation that waits on the given [`System.Threading.WaitHandle`](https://msdn.microsoft.com/library/system.threading.waithandle.aspx) object.

## Remarks

The computation returns true if the handle indicated a result within the given timeout.

## Example

The following code example illustrates how to use `Async.AwaitWaitHandle` to set up a computation to run when another asynchronous operation is completed, as indicated by a wait handle.

```fsharp
open System.IO

let streamWriter1 = File.CreateText("test1.txt")
let count = 10000000
let buffer = Array.init count (fun index -> byte (index % 256)) 

printfn "Writing to file test1.txt."
let asyncResult = streamWriter1.BaseStream.BeginWrite(buffer, 0, count, null, null)

// Read a file, but use the waitHandle to wait for the write operation
// to be completed before reading.
let readFile filename waitHandle count = 
    async {
        let! returnValue = Async.AwaitWaitHandle(waitHandle)
        printfn "Reading from file test1.txt."
        // Close the file.
        streamWriter1.Close()
        // Now open the same file for reading.
        let streamReader1 = File.OpenText(filename)
        let! newBuffer = streamReader1.BaseStream.AsyncRead(count)
        return newBuffer
    }

let bufferResult = readFile "test1.txt" asyncResult.AsyncWaitHandle count
                   |> Async.RunSynchronously
```

**Output**

```
Writing to file BigFile.dat.
Reading from file BigFile.dat.
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)