---
title: Control.AsyncReplyChannel<'Reply> Class (F#)
description: Control.AsyncReplyChannel<'Reply> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 596f5fdb-8fc8-46ec-8eba-de3cf1a85750 
---

# Control.AsyncReplyChannel<'Reply> Class (F#)

A handle to a capability to reply to a `PostAndReply` message.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
type AsyncReplyChannel<'Reply> =
class
member this.Reply : 'Reply -> unit
end
```

## Instance Members

|Member|Description|
|------|-----------|
|[Reply](https://msdn.microsoft.com/library/fd08551d-10f1-43da-88d9-718a6a812d76)|Sends a reply to a PostAndReply message.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)