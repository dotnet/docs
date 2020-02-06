---
title: MailboxProcessor.Receive<'Msg> Method (F#)
description: MailboxProcessor.Receive<'Msg> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 61086106-3d48-4d62-ae18-4ad79f8695dc 
---

# MailboxProcessor.Receive<'Msg> Method (F#)

Waits for a message. This will consume the first message in arrival order.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Receive : ?int -> Async<'Msg>

// Usage:
mailboxProcessor.Receive ()
mailboxProcessor.Receive (timeout = timeout)
```

#### Parameters
*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout in milliseconds. Defaults to -1 which corresponds to **System.Threading.Timeout.Infinite**.


## Exceptions
|Exception|Condition|
|----|----|
|[TimeoutException](https://msdn.microsoft.com/library/system.timeoutexception.aspx)|Thrown when the timeout is exceeded.|

## Return Value
An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that returns the received message.

## Remarks
This method is for use within the body of the agent. For each agent, at most one concurrent reader may be active, so no more than one concurrent call to **Receive**, [TryReceive](https://msdn.microsoft.com/library/edcb3930-cefd-4d88-935d-7dd6297355ee), [Scan](https://msdn.microsoft.com/library/e86368a3-4f97-4b51-a487-4c6b5456fcbe) or [TryScan](https://msdn.microsoft.com/library/05aa6c91-fe9f-4830-a2d7-6dfa5a2ab376) may be active.

## Example
The following example shows how to use the Receive method. In this case, a timeout of 10 seconds is specified. In general, the message processing function runs on a different thread from the [Post](https://msdn.microsoft.com/library/70597a62-6aa9-4565-9b37-c0877cd3283b) function, so you must catch the timeout exception in the message processor function. In this example, the timeout exception just causes the loop to continue, and increases the message number by 1.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet10.fs)]

A typical session follows. Notice that message 2 is skipped, due to the timeout.

```
> hello
Reply: Message number 0 was received. Message contents: hello
> hello?
Reply: Message number 1 was received. Message contents: hello?
> The mailbox processor timed out.
anyone there?
Reply: Message number 3 was received. Message contents: anyone there?
>
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)