---
title: MailboxProcessor.TryScan<'Msg,'T> Method (F#)
description: MailboxProcessor.TryScan<'Msg,'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: efb426ee-b21d-4b0b-b85a-2ee4b2498ade 
---

# MailboxProcessor.TryScan<'Msg,'T> Method (F#)

Scans for a message by looking through messages in arrival order until a provided function returns a `Some` value. Other messages remain in the queue.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.TryScan : ('Msg -> Async<'T> option) * ?int -> Async<'T option>

// Usage:
mailboxProcessor.TryScan (scanner)
mailboxProcessor.TryScan (scanner, timeout = timeout)
```

#### Parameters
*scanner*
Type: **'Msg -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


A function that returns **None** if the message is to be skipped, or **Some** if the message is to be processed and removed from the queue.


*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout in milliseconds. Defaults to -1 which corresponds to **System.Threading.Timeout.Infinite**.

## Return Value

An asynchronous computation ([`Async`](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that scanner built off the read message.

## Remarks
If a timeout period is exceeded, `None` is returned. This method is for use within the body of the agent. For each agent, at most one concurrent reader can be active, so no more than one concurrent call to [Receive](https://msdn.microsoft.com/library/46a1d8e6-3906-45c2-9722-0ddab574cc6a), [TryReceive](https://msdn.microsoft.com/library/edcb3930-cefd-4d88-935d-7dd6297355ee), [Scan](https://msdn.microsoft.com/library/e86368a3-4f97-4b51-a487-4c6b5456fcbe) or `TryScan` can be active. The body of the *scanner* function is locked during its execution, but the lock is released before the execution of the asynchronous workflow.

## Example

The following code example shows how to use the `TryScan` method. This example is a job submission agent. There are three agents: one called `runAgent` that starts each job, another called inprogressAgent that represents all running jobs, and one called `completeAgent` that represents notification that a job is completed. `TryScan` is used in the `cancelJob` function to find a job to cancel, or fail if there is no matching job.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet22.fs)]

Following is an example session.

```
Mailbox Processor Test
Type some text and press Enter to submit a message.
Type 'Stop' to close the program.
> hello
1 : Console loop
4 : mailboxProcessor
Reply: Message number 0 was received. Message contents: hello
> testing
1 : Console loop
3 : mailboxProcessor
Reply: Message number 1 was received. Message contents: testing
> hello?
1 : Console loop
4 : mailboxProcessor
Reply: Message number 2 was received. Message contents: hello?
> testing 1 2 3
1 : Console loop
3 : mailboxProcessor
Reply: Message number 3 was received. Message contents: testing 1 2 3
> Stop
1 : Console loop
4 : mailboxProcessor
Press Enter to continue.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)