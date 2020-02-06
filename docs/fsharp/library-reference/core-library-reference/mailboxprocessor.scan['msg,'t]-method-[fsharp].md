---
title: MailboxProcessor.Scan<'Msg,'T> Method (F#)
description: MailboxProcessor.Scan<'Msg,'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2d7cc658-d09d-4f79-af81-7fa4c66382ab 
---

# MailboxProcessor.Scan<'Msg,'T> Method (F#)

Scans for a message by looking through messages in arrival order until a provided function returns a `Some` value. Other messages remain in the queue.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Scan : ('Msg -> Async<'T> option) * ?int -> Async<'T>

// Usage:
mailboxProcessor.Scan (scanner)
mailboxProcessor.Scan (scanner, timeout = timeout)
```

#### Parameters
*scanner*
Type: **'Msg -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


A function that returns **None** if the message is to be skipped, or **Some** if the message is to be processed and removed from the queue.


*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout in milliseconds. Defaults to -1 which corresponds to **System.Threading.Timeout.Infinite**.

## Exceptions
|Exception|Condition|
|----|----|
|[TimeoutException](https://msdn.microsoft.com/library/system.timeoutexception.aspx)|Thrown when the timeout is exceeded.|

## Return Value

An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that scanner built off the read message.

## Remarks
This method is for use within the body of the agent. For each agent, at most one concurrent reader may be active, so no more than one concurrent call to [Receive](https://msdn.microsoft.com/library/46a1d8e6-3906-45c2-9722-0ddab574cc6a), [TryReceive](https://msdn.microsoft.com/library/edcb3930-cefd-4d88-935d-7dd6297355ee), `Scan` or [TryScan](https://msdn.microsoft.com/library/05aa6c91-fe9f-4830-a2d7-6dfa5a2ab376) may be active. The body of the *scanner* function is locked during its execution, but the lock is released before the execution of the asynchronous workflow.

## Example

The following example shows how to use the `Scan` method. In this code, mailbox processor agents manage a series of simulated jobs that run and compute a result.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet21.fs)]

A sample session follows.

```
Number Of Logical Processors: 2
Requesting job #1
Job #1 submitted.
Job #1 started on procId 0.
Requesting job #2
Job #2 submitted.
Job #2 started on procId 1.
Requesting job #3
Requesting job #4
Requesting job #5
Requesting job #6
Requesting job #7
Requesting job #8
Requesting job #9
Requesting job #10
Job #1 completed.
Nth Prime for N = 5000 is 48611.
Job #3 submitted.
Job #3 started on procId 0.
Done submitting jobs. Press Enter to exit when ready.
Job #2 completed.
Nth Prime for N = 10000 is 104729.
Job #4 submitted.
Job #4 started on procId 1.
Job #3 completed.
Nth Prime for N = 15000 is 163841.
Job #5 submitted.
Job #5 started on procId 0.
Job #4 completed.
Nth Prime for N = 20000 is 224737.
Job #6 submitted.
Job #6 started on procId 1.
Job #5 completed.
Nth Prime for N = 25000 is 287117.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)