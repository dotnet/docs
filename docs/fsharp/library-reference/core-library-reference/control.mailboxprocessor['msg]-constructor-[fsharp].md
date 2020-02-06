---
title: Control.MailboxProcessor<'Msg> Constructor (F#)
description: Control.MailboxProcessor<'Msg> Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2105360e-1fed-45c4-8525-504c00d6de63 
---

# Control.MailboxProcessor<'Msg> Constructor (F#)

Creates an agent.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
new MailboxProcessor : (MailboxProcessor<'Msg> -> Async<unit>) * ?CancellationToken -> MailboxProcessor<'Msg>

// Usage:
new MailboxProcessor (body)
new MailboxProcessor (body, cancellationToken = cancellationToken)
```

#### Parameters
*body*
Type: [MailboxProcessor](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf)**&lt;'Msg&gt; -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**&gt;**


The function to produce an asynchronous computation that will be executed as the read loop for the [MailboxProcessor](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf) when [Start](https://msdn.microsoft.com/library/ebf18bf3-ba17-42b9-91ac-313a7eee6fa0) is called.


*cancellationToken*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)


An optional cancellation token for the *body*. Defaults to [Async.DefaultCancellationToken](https://msdn.microsoft.com/library/42e3356a-bd73-4174-beef-b36ca2006734).

## Return Value

The created `MailboxProcessor`.

## Remarks
The *body* function is used to generate the asynchronous computation executed by the agent. This function is not executed until [`Start`](https://msdn.microsoft.com/library/ebf18bf3-ba17-42b9-91ac-313a7eee6fa0) is called.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)