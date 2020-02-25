---
title: Control.MailboxProcessor<'Msg> Class (F#)
description: Control.MailboxProcessor<'Msg> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4fba0b67-ca85-44e0-915f-326bc0e50bba 
---

# Control.MailboxProcessor<'Msg> Class (F#)

A message-processing agent which executes an asynchronous computation.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
[<AutoSerializable(false)>]
type MailboxProcessor<'Msg> =
class
    interface IDisposable
    new MailboxProcessor : (MailboxProcessor<'Msg> -> Async<unit>) * ?CancellationToken -> MailboxProcessor<'Msg>
    member this.Post : 'Msg -> unit
    member this.PostAndAsyncReply : (AsyncReplyChannel<'Reply> -> 'Msg) * int option -> Async<'Reply>
    member this.PostAndReply : (AsyncReplyChannel<'Reply> -> 'Msg) * int option -> 'Reply
    member this.PostAndTryAsyncReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> Async<'Reply option>
    member this.Receive : ?int -> Async<'Msg>
    member this.Scan : ('Msg -> Async<'T> option) * ?int -> Async<'T>
    member this.Start : unit -> unit
    static member Start : (MailboxProcessor<'Msg> -> Async<unit>) * ?CancellationToken -> MailboxProcessor<'Msg>
    member this.TryPostAndReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> 'Reply option
    member this.TryReceive : ?int -> Async<'Msg option>
    member this.TryScan : ('Msg -> Async<'T> option) * ?int -> Async<'T option>
    member this.add_Error : Handler<Exception> -> unit
    member this.CurrentQueueLength :  int
    member this.DefaultTimeout :  int with get, set
    member this.Error :  IEvent<Exception>
    member this.remove_Error : Handler<Exception> -> unit
end
```

## Remarks
The agent encapsulates a message queue that supports multiple-writers and a single reader agent. Writers send messages to the agent by using the `Post` method and its variations. The agent may wait for messages using the `Receive` or `TryReceive` methods or scan through all available messages using the `Scan` or `TryScan` method.

This type is named `FSharpMailboxProcessor` in the .NET assembly. If accessing the type from a .NET language other than F#, or through reflection, use this name.

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/f13a40de-09c2-4446-9465-c1c476c57d1e)|Creates an agent. The **body** function is used to generate the asynchronous computation executed by the agent. This function is not executed until **Start** is called.|

## Instance Members


|Member|Description|
|------|-----------|
|[add_Error](https://msdn.microsoft.com/library/ecd8c707-7ef1-4db1-b847-0c9d9251fa53)|Occurs when the execution of the agent results in an exception.|
|[CurrentQueueLength](https://msdn.microsoft.com/library/bed32e01-5c56-4bce-985c-35f3244f3580)|Returns the number of unprocessed messages in the message queue of the agent.|
|[DefaultTimeout](https://msdn.microsoft.com/library/9f54edae-6167-4a68-acc5-fd444817fb1b)|Raises a timeout exception if a message not received in this amount of time. By default no timeout is used.|
|[Error](https://msdn.microsoft.com/library/f9bf8e54-a0bc-4cfa-9b2d-abdedde9b74e)|Occurs when the execution of the agent results in an exception.|
|[Post](https://msdn.microsoft.com/library/70597a62-6aa9-4565-9b37-c0877cd3283b)|Posts a message to the message queue of the MailboxProcessor, asynchronously.|
|[PostAndAsyncReply](https://msdn.microsoft.com/library/cd7d03c7-cc82-46f3-9f9a-ed689164e4a8)|Posts a message to an agent and await a reply on the channel, asynchronously.|
|[PostAndReply](https://msdn.microsoft.com/library/11842a52-ea51-45e8-86c4-72e887fedf71)|Posts a message to an agent and await a reply on the channel, synchronously.|
|[PostAndTryAsyncReply](https://msdn.microsoft.com/library/d1eba793-83b7-430c-ab83-81576ab670dd)|Like AsyncPostAndReply, but returns None if no reply within the timeout period.|
|[Receive](https://msdn.microsoft.com/library/46a1d8e6-3906-45c2-9722-0ddab574cc6a)|Waits for a message. This will consume the first message in arrival order.|
|[remove_Error](https://msdn.microsoft.com/library/bfbc587c-9317-4094-8091-8519d8a47a37)|Occurs when the execution of the agent results in an exception.|
|[Scan](https://msdn.microsoft.com/library/e86368a3-4f97-4b51-a487-4c6b5456fcbe)|Scans for a message by looking through messages in arrival order until **scanner** returns a Some value. Other messages remain in the queue.|
|[Start](https://msdn.microsoft.com/library/ebf18bf3-ba17-42b9-91ac-313a7eee6fa0)|Starts the agent.|
|[TryPostAndReply](https://msdn.microsoft.com/library/5c4a758b-aace-4cc1-950d-6105fd3652b9)|Like PostAndReply, but returns None if no reply within the timeout period.|
|[TryReceive](https://msdn.microsoft.com/library/edcb3930-cefd-4d88-935d-7dd6297355ee)|Waits for a message. This will consume the first message in arrival order.|
|[TryScan](https://msdn.microsoft.com/library/05aa6c91-fe9f-4830-a2d7-6dfa5a2ab376)|Scans for a message by looking through messages in arrival order until **scanner** returns a Some value. Other messages remain in the queue.|

## Static Members


|Member|Description|
|------|-----------|
|[Start](https://msdn.microsoft.com/library/ebf18bf3-ba17-42b9-91ac-313a7eee6fa0)|Creates and starts an agent. The **body** function is used to generate the asynchronous computation executed by the agent.|

## Example

The following example shows the basic use of the `MailboxProcessor` class.

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet2.fs)]

**Sample Output**

```text
Press any key...
Message count = 0. Waiting for next message.
Message received. ID: 1 Contents: ABC
Message count = 1. Waiting for next message.
Message received. ID: 2 Contents: XYZ
Message count = 2. Waiting for next message.
```

**The following example shows how to use MailboxProcessor to create a simple agent that accepts various types of messages and returns appropriate replies. This server agent represents a market maker, which is a buying and selling agent on a stock exchange that sets bid and ask prices for assets. Clients can query for prices, or buy and sell shares.**

[!code-fsharp[Main](snippets/fsmailboxprocessor/snippet3.fs)]

**Sample Output**

```text
Posting message for AAA
Replying with Info for AAA
Posting message for BBB
Replying with Notification:
Bought 100 units of BBB at price $20.100000. Total purchase $2010.000000.
Marketmaker balance: $   2010.00
Posting message for CCC
Replying with Notification:
Sold 100 units of CCC at price $30.000000. Total sale $3000.000000.
Marketmaker balance: $   -990.00
Posting message for WrongCode
Posting message with large number of shares of AAA.
Insufficient shares to fulfill order for 1000000000 units of AAA.
Posting message with too large a monetary amount.
Insufficient cash to fulfill order for 100000000 units of AAA.
Press any key...
Posting BUY CCC 1338.
Replying with Notification:
Bought 1338 units of CCC at price $30.150000. Total purchase $40340.700000.
Marketmaker balance: $  39350.70
Program+Snippet3+Reply+Notify
Posting BUY BBB 1961.
Replying with Notification:
Bought 1961 units of BBB at price $20.100000. Total purchase $39416.100000.
Marketmaker balance: $  78766.80
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)