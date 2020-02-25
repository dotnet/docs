---
title: MailboxProcessor.CurrentQueueLength<'Msg> Property (F#)
description: MailboxProcessor.CurrentQueueLength<'Msg> Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 24724743-9f63-49bd-8a39-03c3deefb6d6 
---

# MailboxProcessor.CurrentQueueLength<'Msg> Property (F#)

Returns the number of unprocessed messages in the message queue of the agent.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.CurrentQueueLength :  [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

// Usage:
mailboxProcessor.CurrentQueueLength
```
## Return Value

The number of unprocessed messages in the queue.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)