---
title: Control.Event Module (F#)
description: Control.Event Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3d217948-6bcd-4357-81c4-dc8ad2da175c 
---

# Control.Event Module (F#)

Provides functions for managing event streams.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Event
```

## Values

|Value|Description|
|-----|-----------|
|[add](https://msdn.microsoft.com/library/10670d3b-8d47-4f6e-b8df-ebc6f64ef4fd)<br />**: ('T -&gt; unit) -&gt; Event&lt;'Del,'T&gt; -&gt; unit**|Runs the given function each time the given event is triggered.|
|[choose](https://msdn.microsoft.com/library/454dc761-8ec6-4c52-bcf5-10955407a458)<br />**: ('T -&gt; 'U option) -&gt; IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'U&gt;**|Returns a new event which fires on a selection of messages from the original event. The selection function takes an original message to an optional new message.|
|[filter](https://msdn.microsoft.com/library/8469b9e3-5513-4059-b216-2011a631022a)<br />**: ('T -&gt; bool) -&gt; IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'T&gt;**|Returns a new event that listens to the original event and triggers the resulting event only when the argument to the event passes the given function.|
|[map](https://msdn.microsoft.com/library/3a7ded1b-69a8-4cec-8717-f8573a9eb7d8)<br />**: ('T -&gt; 'U) -&gt; IEvent&lt;'Del, 'T&gt; -&gt; IEvent&lt;'U&gt;**|Returns a new event that passes values transformed by the given function.|
|[merge](https://msdn.microsoft.com/library/4eb364ff-9a40-41cf-b62e-64a80576fdc6)<br />**: IEvent&lt;'Del1,'T&gt; -&gt; IEvent&lt;'Del2,'T&gt; -&gt; IEvent&lt;'T&gt;**|Fires the output event when either of the input events fire.|
|[pairwise](https://msdn.microsoft.com/library/ee175ad7-653e-415a-8929-decbd5b4e1c7)<br />**: IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'T &#42; 'T&gt;**|Returns a new event that triggers on the second and subsequent triggerings of the input event. The Nth triggering of the input event passes the arguments from the N-1th and Nth triggering as a pair. The argument passed to the N-1th triggering is held in hidden internal state until the Nth triggering occurs.|
|[partition](https://msdn.microsoft.com/library/9854e530-5bd1-4705-bec6-688f53d7a952)<br />**: ('T -&gt; bool) -&gt; IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'T&gt; &#42; IEvent&lt;'T&gt;**|Returns a new event that listens to the original event and triggers the first resulting event if the application of the predicate to the event arguments returned **true**, and the second event if it returned **false**.|
|[scan](https://msdn.microsoft.com/library/17ab718c-2ed5-4e1a-8b93-49007fed9cb5)<br />**: ('U -&gt; 'T -&gt; 'U) -&gt; 'U -&gt; IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'U&gt;**|Returns a new event consisting of the results of applying the given accumulating function to successive values triggered on the input event. An item of internal state records the current value of the state parameter. The internal state is not locked during the execution of the accumulation function, so care should be taken that the input [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862) not triggered by multiple threads simultaneously.|
|[split](https://msdn.microsoft.com/library/90f126ec-3726-4ea5-8626-0463be8d9e7a)<br />**: ('T -&gt; Choice&lt;'U1,'U2&gt;) -&gt; IEvent&lt;'Del,'T&gt; -&gt; IEvent&lt;'U1&gt; &#42; IEvent&lt;'U2&gt;**|Returns a new event that listens to the original event and triggers the first resulting event if the application of the function to the event arguments returned a **Choice1Of2**, and the second event if it returns a **Choice2Of2**.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Control.Event&#60;'T&#62; Class &#40;F&#35;&#41;](Control.Event%5B%27T%5D-Class-%5BFSharp%5D.md)

[Events &#40;F&#35;&#41;](Events-%5BFSharp%5D.md)

[Control.IEvent&#60;'Delegate,'Args&#62; Interface &#40;F&#35;&#41;](Control.IEvent%5B%27Delegate%2C%27Args%5D-Interface-%5BFSharp%5D.md)