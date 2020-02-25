---
title: MailboxProcessor.add_Error<'Msg> Method (F#)
description: MailboxProcessor.add_Error<'Msg> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9034d70a-0b06-49bf-ab7f-02de2942f305 
---

# MailboxProcessor.add_Error<'Msg> Method (F#)

Occurs when the execution of the agent results in an exception.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.add_Error : Handler<Exception> -> unit

// Usage:
mailboxProcessor.add_Error ()
```

#### Parameters
Type: [Handler](https://msdn.microsoft.com/library/53830512-6518-40da-a2e6-27c7957edccd)**&lt;****System.Exception****&gt;**


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)