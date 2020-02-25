---
title: MailboxProcessor.Post<'Msg> Method (F#)
description: MailboxProcessor.Post<'Msg> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: faaba1e0-52c0-443a-b8ea-6081ff50b811 
---

# MailboxProcessor.Post<'Msg> Method (F#)

Posts a message to the message queue of the [MailboxProcessor](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf), asynchronously.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Post : 'Msg -> unit

// Usage:
mailboxProcessor.Post (message)
```

#### Parameters
*message*
Type: **'Msg**


The message to post.

## Example

The following code example shows how to start a mailbox processor agent and post messages to it.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet2.fs)]

Following is an example session.

```
Press any key...
Message count = 0. Waiting for next message.
Message received. ID: 1 Contents: ABC
Message count = 1. Waiting for next message.
Message received. ID: 2 Contents: XYZ
Message count = 2. Waiting for next message.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)