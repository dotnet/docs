---
title: MailboxProcessor.Error<'Msg> Property (F#)
description: MailboxProcessor.Error<'Msg> Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f71c4b58-1385-4675-a6df-fdea77248504 
---

# MailboxProcessor.Error<'Msg> Property (F#)

Occurs when the execution of the agent results in an exception.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Error :  [IEvent](https://msdn.microsoft.com/library/7976554f-9aa8-451f-a69d-d4670c064432)<Exception>

// Usage:
mailboxProcessor.Error
```

## Return Value
The error event as an object that implements [`IEvent`](https://msdn.microsoft.com/library/7976554f-9aa8-451f-a69d-d4670c064432)

## Example

The following code shows how to use the `Error` event to handle an exception that occurs in the body of the agent.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet23.fs)]

An example session follows.

```
Mailbox Processor Test
Type some text and press Enter to submit a message.
hello
Message number 0. Message contents: hello
testing
Message number 1. Message contents: testing
The agent timed out.
Press Enter to close the program.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)