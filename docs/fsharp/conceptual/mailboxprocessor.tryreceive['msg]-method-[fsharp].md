---
title: MailboxProcessor.TryReceive<'Msg> Method (F#)
description: MailboxProcessor.TryReceive<'Msg> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3ebf11ba-f9bb-483f-a26b-871e387ee2f7 
---

# MailboxProcessor.TryReceive<'Msg> Method (F#)

Waits for a message. This will consume the first message in arrival order.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.TryReceive : ?int -> Async<'Msg option>

// Usage:
mailboxProcessor.TryReceive ()
mailboxProcessor.TryReceive (timeout = timeout)
```

#### Parameters
*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout in milliseconds. Defaults to -1 which corresponds to **System.Threading.Timeout.Infinite**.

## Return Value

An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that returns the received message or None if the timeout is exceeded.

## Remarks
This method is for use within the body of the agent. Returns `None` if a timeout is given and the timeout is exceeded. This method is for use within the body of the agent. For each agent, at most one concurrent reader may be active, so no more than one concurrent call to [Receive](https://msdn.microsoft.com/library/46a1d8e6-3906-45c2-9722-0ddab574cc6a), `TryReceive`, [Scan](https://msdn.microsoft.com/library/e86368a3-4f97-4b51-a487-4c6b5456fcbe) or [TryScan](https://msdn.microsoft.com/library/05aa6c91-fe9f-4830-a2d7-6dfa5a2ab376) may be active.

## Example

The following example shows how to use `TryReceive`. If a message is not received within 10 seconds, a timeout occurs and the message ID increments by 1.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet18.fs)]

A sample session follows. Notice that the message number 2 is skipped due to the timeout.

```
Mailbox Processor Test
Type some text and press Enter to submit a message.
Type 'Stop' to close the program.
> test1Reply: Message number 0 was received. Message contents: test1
> test2Reply: Message number 1 was received. Message contents: test2
> test3Reply: Message number 3 was received. Message contents: test3
> Stop
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