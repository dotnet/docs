---
title: MailboxProcessor.PostAndTryAsyncReply<'Msg,'Reply> Method (F#)
description: MailboxProcessor.PostAndTryAsyncReply<'Msg,'Reply> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 32204396-fa81-4f2e-8248-532ae229c3c1 
---

# MailboxProcessor.PostAndTryAsyncReply<'Msg,'Reply> Method (F#)

Like [`MailboxProcessor.AsyncPostAndReply`](https://msdn.microsoft.com/library/cd7d03c7-cc82-46f3-9f9a-ed689164e4a8), but returns `None` if no reply within the timeout period.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.PostAndTryAsyncReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> Async<'Reply option>

// Usage:
mailboxProcessor.PostAndTryAsyncReply (buildMessage)
mailboxProcessor.PostAndTryAsyncReply (buildMessage, timeout = timeout)
```

#### Parameters
*buildMessage*
Type: [AsyncReplyChannel](https://msdn.microsoft.com/library/e32fd8ec-37dd-4e63-94a5-67709962d1d0)**&lt;'Reply&gt; -&gt;   'Msg**


The function to incorporate the [AsyncReplyChannel](https://msdn.microsoft.com/library/e32fd8ec-37dd-4e63-94a5-67709962d1d0) into the message to be sent.


*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout parameter (in milliseconds) to wait for a reply message. The default is -1 which corresponds to **System.Threading.Timeout.Infinite**.

## Return Value

An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that will return the reply or None if the timeout expires.

## Example

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet19.fs)]

A sample session follows.

```
Mailbox Processor Test
Type some text and press Enter to submit a message.
Type 'Stop' to close the program.
> test1
> Message number 0 was received. Message contents: test1
test2
> Message number 1 was received. Message contents: test2
test3
> Message number 2 was received. Message contents: test3
test4
> Message number 3 was received. Message contents: test4
test5
> Message number 4 was received. Message contents: test5
test6
> Reply timeout exceeded.
```

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)