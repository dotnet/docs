---
title: Microsoft.FSharp.Control Namespace (F#)
description: Microsoft.FSharp.Control Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8434f1a4-d68a-4394-aac5-b5b1c8a5a634
---

# Microsoft.FSharp.Control Namespace (F#)

This namespace contains several types that common scenarios in F# programs, including asynchronous programming, message passing, and event-based programming.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace Microsoft.FSharp.Control
```

## Modules


|Module|Description|
|------|-----------|
|module [CommonExtensions](https://msdn.microsoft.com/library/2edb67cb-6814-4a30-849f-b6dbdd042396)|A module of extension members providing asynchronous operations for some basic CLI types related to concurrency and I/O.|
|module [Event](https://msdn.microsoft.com/library/8b883baa-a460-4840-9baa-de8260351bc7)|Provides functions for managing event streams.|
|module [LazyExtensions](https://msdn.microsoft.com/library/86671f40-84a0-402a-867d-ae596218d948)|Extensions related to Lazy values.|
|module [Observable](https://msdn.microsoft.com/library/16b8610b-b30a-4df7-aa99-d9d352276227)|Basic operations on first class event and other observable objects.|
|module [WebExtensions](https://msdn.microsoft.com/library/95ef17bc-ee3f-44ba-8a11-c90fcf4cf003)|A module of extension members providing asynchronous operations for some basic Web operations.|

## Type Definitions

|Type|Description|
|----|-----------|
|type [Async&lt;'T&gt;](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)|A compositional asynchronous computation, which, when run, will eventually produce a value of type T, or else raises an exception.|
|type [Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7)|This static class holds members for creating and manipulating asynchronous computations.|
|type [AsyncBuilder](https://msdn.microsoft.com/library/7f593fcf-bc6e-42fc-bd26-fb9e18951016)|The type of the **async** operator, used to build workflows for asynchronous computations.|
|type [AsyncReplyChannel&lt;'Reply&gt;](https://msdn.microsoft.com/library/e32fd8ec-37dd-4e63-94a5-67709962d1d0)|A handle to a capability to reply to a PostAndReply message.|
|type [DelegateEvent&lt;'Delegate&gt;](https://msdn.microsoft.com/library/d5c57485-4db6-4fd0-b93e-d96a99dc1051)|Event implementations for an arbitrary type of delegate.|
|type [Event&lt;'Delegate,'Args&gt;](https://msdn.microsoft.com/library/114c0f1a-1c34-46d4-a93a-b629e6ddd13c)|Event implementations for a delegate types following the standard .NET Framework convention of a first 'sender' argument.|
|type [Event&lt;'T&gt;](https://msdn.microsoft.com/library/f3b47c8a-4ee5-4ce8-9a72-ad305a17c4b9)|Event implementations for the IEvent&lt;_&gt; type.|
|type [Handler&lt;'T&gt;](https://msdn.microsoft.com/library/53830512-6518-40da-a2e6-27c7957edccd)|A delegate type associated with the F# event type **IEvent&lt;_&gt;**|
|type [IDelegateEvent&lt;'Delegate&gt;](https://msdn.microsoft.com/library/3d849465-6b8e-4fc5-b36c-2941d734268a)|First class event values for arbitrary delegate types.|
|type [IEvent&lt;'Delegate,'Args&gt;](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)|First class event values for CLI events conforming to CLI Framework standards.|
|type [MailboxProcessor&lt;'Msg&gt;](https://msdn.microsoft.com/library/2052c977-f787-4a0b-b25f-9444e26b5fdf)|A message-processing agent which executes an asynchronous computation.|

## Type Abbreviations

|Type|Description|
|----|-----------|
|type [IEvent&lt;'T&gt;](https://msdn.microsoft.com/library/7976554f-9aa8-451f-a69d-d4670c064432)|First-class listening points (i.e. objects that permit you to register a callback activated when the event is triggered).|
|type [lazy&lt;'T&gt;](https://msdn.microsoft.com/library/8034b272-272d-43fb-b6e1-b4788fc0c32c)|An abbreviation for the type of delayed computations.|
|type [Lazy&lt;'T&gt;](https://msdn.microsoft.com/library/b29d0af5-6efb-4a55-a278-2662a4ecc489)|An abbreviation for the type of delayed computations.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)
