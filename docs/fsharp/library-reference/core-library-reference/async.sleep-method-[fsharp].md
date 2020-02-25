---
title: Async.Sleep Method (F#)
description: Async.Sleep Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9244f011-bc01-49a0-ad72-c6c51d7ef6e2 
---

# Async.Sleep Method (F#)

Creates an asynchronous computation that will sleep for the given time. This is scheduled using a [`System.Threading.Timer`](https://msdn.microsoft.com/library/system.threading.timer.aspx) object. The operation will not block operating system threads for the duration of the wait.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member Sleep : int -> Async<unit>

// Usage:
Async.Sleep (millisecondsDueTime)
```

#### Parameters

*millisecondsDueTime*
Type: **[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**

The number of milliseconds to sleep.

## Return Value

Returns an asynchronous computation that will sleep for the given time.

## Example

The following code example shows how to use `Async.Sleep` to simulate computations that run for specific durations.

[!code-fsharp[Main](snippets/fsasyncapis/snippet6.fs)]

**Sample Output**

```
The output is interleaved, because there are multiple threads running at the same time.
Job Job 0 start
1 start
Job 2 starJob 3 start
Job 4 start
Job 5 start
Job 6 start
Job 7 start
Job 8 start
Job 9 start
t
Job 0 end 0:00:00:01.0091009
Job 1 end 0:00:00:02.0102010
Job 2 end 0:00:00:03.0033003
Job 3 end 0:00:00:04.0074007
Job 4 end 0:00:00:05.0065006
Job 5 end 0:00:00:06.0076007
Job 6 end 0:00:00:07.0007000
Job 7 end 0:00:00:07.9957995
Job 8 end 0:00:00:08.9928992
Job 9 end 0:00:00:09.9919991
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

