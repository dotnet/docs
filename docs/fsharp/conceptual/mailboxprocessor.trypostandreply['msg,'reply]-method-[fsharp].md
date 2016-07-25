---
title: MailboxProcessor.TryPostAndReply<'Msg,'Reply> Method (F#)
description: MailboxProcessor.TryPostAndReply<'Msg,'Reply> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f14edb0a-975f-4c87-841b-69cee174775f 
---

# MailboxProcessor.TryPostAndReply<'Msg,'Reply> Method (F#)

Like [`MailboxProcessor.PostAndReply`](https://msdn.microsoft.com/library/11842a52-ea51-45e8-86c4-72e887fedf71), but returns `None` if there is no reply within the timeout period.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.TryPostAndReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> 'Reply option

// Usage:
mailboxProcessor.TryPostAndReply (buildMessage)
mailboxProcessor.TryPostAndReply (buildMessage, timeout = timeout)
```

#### Parameters
*buildMessage*
Type: [AsyncReplyChannel](https://msdn.microsoft.com/library/e32fd8ec-37dd-4e63-94a5-67709962d1d0)**&lt;'Reply&gt; -&gt;   'Msg**


The function to incorporate the [AsyncReplyChannel](https://msdn.microsoft.com/library/e32fd8ec-37dd-4e63-94a5-67709962d1d0) into the message to be sent.


*timeout*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional timeout parameter (in milliseconds) to wait for a reply message. Defaults to -1 which corresponds to **System.Threading.Timeout.Infinite**.

## Return Value

The reply from the agent or None if the timeout expires.

## Example

The following example shows how to use `TryPostAndReply`. In this example, the agent has a delay that eventually results in a timeout.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet16.fs)]

A sample session follows.

```
Mailbox Processor Test
Type some text and press Enter to submit a message.
Type 'Stop' to close the program.
> test1Reply: Message number 0 was received. Message contents: test1
> test2Reply: Message number 1 was received. Message contents: test2
> test3Reply: Message number 2 was received. Message contents: test3
> test4Reply: Message number 3 was received. Message contents: test4
> test5Reply: Message number 4 was received. Message contents: test5
> test6
Timeout exceeded.
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