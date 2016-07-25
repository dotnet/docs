---
title: MailboxProcessor.Start<'Msg> Method (F#)
description: MailboxProcessor.Start<'Msg> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: db6323d4-f124-4ea5-b2a7-70921c26619e 
---

# MailboxProcessor.Start<'Msg> Method (F#)

Creates and starts an agent.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Start : (MailboxProcessor<'Msg> -> Async<unit>) * ?CancellationToken -> MailboxProcessor<'Msg>

// Usage:
MailboxProcessor.Start (body)
MailboxProcessor.Start (body, cancellationToken = cancellationToken)
```

#### Parameters
*body*
Type: [MailboxProcessor](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf)**&lt;'Msg&gt; -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**&gt;**


The function to produce an asynchronous computation that will be executed as the read loop for the [MailboxProcessor](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf) when **Start** is called.


*cancellationToken*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)


An optional cancellation token for the *body*. The default is [Async.DefaultCancellationToken](https://msdn.microsoft.com/library/42e3356a-bd73-4174-beef-b36ca2006734).

## Return Value

The created [`MailboxProcessor`](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf).

## Remarks
The `body` function is used to generate the asynchronous computation executed by the agent.

## Example

The following code example shows how to start a mailbox processor agent. In this example, each line of input from the console is posted to a message queue. The program reads each message and replies by using a reply channel. When the special message "Stop" is received, the Stop reply is sent and the program exits.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet7.fs)]

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