---
title: Control.Async Class (F#)
description: Control.Async Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 32953768-6b60-49b0-a0f4-c6e44e524631 
---

# Control.Async Class (F#)

Contains members for creating and manipulating asynchronous computations. `Control.Async` is a static class.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
type Async =
class
static member AsBeginEnd : ('Arg -> Async<'T>) -> ('Arg * AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * (IAsyncResult -> unit)
static member AwaitEvent : IEvent<'Del,'T> * ?(unit -> unit) -> Async<'T>
static member AwaitIAsyncResult : IAsyncResult * ?int -> Async<bool>
static member AwaitTask : Task<'T> -> Async<'T>
static member AwaitWaitHandle : WaitHandle * ?int -> Async<bool>
static member CancelDefaultToken : unit -> unit
static member Catch : Async<'T> -> Async<Choice<'T,exn>>
static member FromBeginEnd : 'Arg1 * 'Arg2 * 'Arg3 * ('Arg1 * 'Arg2 * 'Arg3 * AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>
static member FromBeginEnd : 'Arg1 * 'Arg2 * ('Arg1 * 'Arg2 * AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>
static member FromBeginEnd : 'Arg1 * ('Arg1 * AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>
static member FromBeginEnd : (AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>
static member FromContinuations : (('T -> unit) * (exn -> unit) * (OperationCanceledException -> unit) -> unit) -> Async<'T>
static member Ignore : Async<'T> -> Async<unit>
static member OnCancel : (unit -> unit) -> Async<IDisposable>
static member Parallel : seq<Async<'T>> -> Async<'T []>
static member RunSynchronously : Async<'T> * ?int * ?CancellationToken -> 'T
static member Sleep : int -> Async<unit>
static member Start : Async<unit> * ?CancellationToken -> unit
static member StartAsTask : Async<'T> * ?TaskCreationOptions * ?CancellationToken -> Task<'T>
static member StartChild : Async<'T> * ?int -> Async<Async<'T>>
static member StartChildAsTask : Async<'T> * ?TaskCreationOptions -> Async<Task<'T>>
static member StartImmediate : Async<unit> * ?CancellationToken -> unit
static member StartWithContinuations : Async<'T> * ('T -> unit) * (exn -> unit) * (OperationCanceledException -> unit) * ?CancellationToken -> unit
static member SwitchToContext : SynchronizationContext -> Async<unit>
static member SwitchToNewThread : unit -> Async<unit>
static member SwitchToThreadPool : unit -> Async<unit>
static member TryCancelled : Async<'T> * (OperationCanceledException -> unit) -> Async<'T>
static member CancellationToken :  Async<CancellationToken>
static member DefaultCancellationToken :  CancellationToken
end
```

## Remarks
This type is named `FSharpAsync` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.

For an overview of asynchronous workflows, see [Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md).


## Static Members


|   Member   |   Description   |
|-----------|-----------|
|[AsBeginEnd](https://msdn.microsoft.com/library/a38a0e75-7717-4791-b2ec-0fc9977b4e6e)|Creates three functions that can be used to implement the .NET Framework Asynchronous Programming Model (APM) for the supplied asynchronous computation.|
|[AwaitEvent](https://msdn.microsoft.com/library/08457e9a-0c8e-4ade-9146-3dbe10c28584)|Creates an asynchronous computation that waits for a single invocation of a .NET Framework event by adding a handler to the event. When the computation finishes or is canceled, the handler is removed from the event.|
|[AwaitIAsyncResult](https://msdn.microsoft.com/library/62c03ef2-a95e-499d-a614-67ad0719dde0)|Creates an asynchronous computation that waits for the supplied **System.IAsyncResult**.|
|[AwaitTask](https://msdn.microsoft.com/library/d4bdabff-00b2-4459-9a06-e745e4812565)|Returns an asynchronous computation that waits for the given task to complete and returns its result.|
|[AwaitWaitHandle](https://msdn.microsoft.com/library/0f3ee86d-5fb6-4ff9-9917-94f272923715)|Creates an asynchronous computation that waits for the supplied **System.Threading.WaitHandle**.|
|[CancelDefaultToken](https://msdn.microsoft.com/library/95289172-8711-4479-b9c1-05c616e26472)|Raises the cancellation condition for the most recent set of asynchronous computations started without any specific **System.Threading.CancellationToken**. Replaces the global **System.Threading.CancellationTokenSource** with a new global token source for any asynchronous computations created without any specific **System.Threading.CancellationToken**.|
|[CancellationToken](https://msdn.microsoft.com/library/3f118642-dd42-4e34-9a63-1779e7a0a6f9)|Creates an asynchronous computation that returns the **System.Threading.CancellationToken** that manages the execution of the computation.|
|[Catch](https://msdn.microsoft.com/library/c31e1ccb-c0f5-4da9-ba3d-c2454bcd0807)|Creates an asynchronous computation. If this computation finishes successfully, this method returns **Choice1Of2** with the returned value. If this computation raises an exception before it finishes, this method returns **Choice2Of2** with the raised exception.|
|[DefaultCancellationToken](https://msdn.microsoft.com/library/42e3356a-bd73-4174-beef-b36ca2006734)|Gets the default cancellation token for running asynchronous computations.|
|[FromBeginEnd&lt;'T&gt;](https://msdn.microsoft.com/library/eb24fcb5-36fb-4c9b-8343-02148b327b56)|Creates an asynchronous computation by specifying a beginning and ending function, like .NET Framework APIs.|
|[FromBeginEnd&lt;'Arg1,'T&gt;](https://msdn.microsoft.com/library/fd61e0e4-3d74-4c70-a55f-083ed4239563)|Creates an asynchronous computation by specifying a beginning and ending function, like .NET Framework APIs. This overload should be used if the operation is qualified by one argument.|
|[FromBeginEnd&lt;'Arg1,'Arg2,'T&gt;](https://msdn.microsoft.com/library/7c63e974-4c14-47cb-bf22-f8110ed46c30)|Creates an asynchronous computation by specifying a beginning and ending function, like .NET Framework APIs. This overload should be used if the operation is qualified by two arguments.|
|[FromBeginEnd&lt;'Arg1,'Arg2,'Arg3,'T&gt;](https://msdn.microsoft.com/library/01a7a1a0-5d36-4ff6-b382-f1ab5fcb6973)|Creates an asynchronous computation by specifying a beginning and ending function, like .NET Framework APIs. This overload should be used if the operation is qualified by three arguments.|
|[FromContinuations](https://msdn.microsoft.com/library/76fb99a4-e92f-4e68-affc-546c46b6a9b2)|Creates an asynchronous computation that includes the current success, exception, and cancellation continuations. The callback function must eventually call exactly one of the given continuations.|
|[Ignore](https://msdn.microsoft.com/library/2cb37887-d5f3-4530-b8ec-08f4ac0ae7df)|Creates an asynchronous computation that runs the given computation and ignores its result.|
|[OnCancel](https://msdn.microsoft.com/library/917fde0f-2177-40db-8af4-eee96aa87b7a)|Generates a scoped, cooperative cancellation handler for use within an asynchronous workflow.|
|[Parallel](https://msdn.microsoft.com/library/aa9b0355-2d55-4858-b943-cbe428de9dc4)|Creates an asynchronous computation that runs all the supplied asynchronous computations, initially queuing each as a work item and using a fork/join pattern.|
|[RunSynchronously](https://msdn.microsoft.com/library/0a6663a9-50f2-4d38-8bf3-cefd1a51fd6b)|Runs an asynchronous computation and waits for its result.|
|[Sleep](https://msdn.microsoft.com/library/de7a7567-fade-494e-af85-3758a31c4960)|Creates an asynchronous computation that pauses for the specified time. A **System.Threading.Timer** object is used to schedule the delay. The operation does not block operating system threads for the duration of the delay.|
|[Start](https://msdn.microsoft.com/library/338aa756-beac-4dc1-95ca-613822679347)|Starts an asynchronous computation in the thread pool. Does not wait for its result.|
|[StartAsTask](https://msdn.microsoft.com/library/3f3ef301-fcc9-4006-9414-c2268e65d79c)|Executes a computation in the thread pool. Returns a **System.Threading.Tasks.Task** that will be completed in the corresponding state once the computation terminates (produces the result, throws exception or gets canceled) If no cancellation token is provided then the default cancellation token is used.|
|[StartChild](https://msdn.microsoft.com/library/dee323cf-015b-447f-8ffe-1a04443a7aa7)|Starts a child computation within an asynchronous workflow. This allows multiple asynchronous computations to be executed simultaneously.|
|[StartChildAsTask](https://msdn.microsoft.com/library/f4363517-4430-466e-bb72-7a51e9ffef28)|Creates an asynchronous computation which starts the given computation as a **System.Threading.Tasks.Task**.|
|[StartImmediate](https://msdn.microsoft.com/library/2f71d1cc-187f-48cf-ac66-e7fda41c46e3)|Runs an asynchronous computation, starting immediately on the current operating system thread.|
|[StartWithContinuations](https://msdn.microsoft.com/library/dbca7cda-02d1-4a91-bbd0-23aef7050a5c)|Runs an asynchronous computation, starting immediately on the current operating system thread. This method calls one of the three continuations when the operation finishes.|
|[SwitchToContext](https://msdn.microsoft.com/library/c36395ac-adeb-4c9b-af0a-47471cccc0ea)|Creates an asynchronous computation that runs its continuation by using the **System.Threading.SynchronizationContext.Post(System.Threading.SendOrPostCallback,System.Object)** method of the supplied synchronization context. If the supplied synchronization context is **null**, the asynchronous computation is equivalent to [SwitchToThreadPool](https://msdn.microsoft.com/library/c2708739-5389-487a-a3c9-490f417bcdc6).|
|[SwitchToNewThread](https://msdn.microsoft.com/library/1f0b78f7-8621-47da-89e8-5040ead1004c)|Creates an asynchronous computation that creates a new thread and runs its continuation in that thread.|
|[SwitchToThreadPool](https://msdn.microsoft.com/library/c2708739-5389-487a-a3c9-490f417bcdc6)|Creates an asynchronous computation that queues a work item that runs its continuation.|
|[TryCancelled](https://msdn.microsoft.com/library/cab396e2-d42c-433c-8c66-4457868a5f9f)|Creates an asynchronous computation that runs the supplied computation. If this computation is cancelled before it finishes, the computation generated by running the supplied compensation function is executed.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md)

[Control.Async&#60;'T&#62; Type &#40;F&#35;&#41;](Control.Async%5B%27T%5D-Type-%5BFSharp%5D.md)