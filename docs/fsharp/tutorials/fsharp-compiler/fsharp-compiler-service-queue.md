---
title: F# compiler service queue
description: Learn about the FSharpChecker operations queue used in F# tooling.
ms.date: 8/6/2020
---

## F# Compiler Service Queue

An `FSharpChecker` maintains an operations queue. Items from the `FSharpChecker` operations queue are processed
sequentially and in order.

The thread processing these requests can also run a low-priority, interleaved background operation when the queue is empty. This can be used to implicitly bring the background check of a project "up-to-date". When the operations queue has been empty for 1 second, this background work is run in small  incremental fragments. This work is cooperatively time-sliced to be approximately <50ms, (see `maxTimeShareMilliseconds` in `IncrementalBuild.fs`). The project to be checked in the background is set implicitly by calls to `CheckFileInProject` and `ParseAndCheckFileInProject`. To disable implicit background checking completely, set `checker.ImplicitlyStartBackgroundWork` to false. To change the time before background work starts, set `checker.PauseBeforeBackgroundWork` to the required number of milliseconds.

Most calls to the FSharpChecker API enqueue an operation in the FSharpChecker compiler queue. These correspond to the calls to EnqueueAndAwaitOpAsync in [Reactor.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/service/Reactor.fsi).

* For example, calling `ParseAndCheckProject` enqueues a `ParseAndCheckProjectImpl` operation. The time taken for the operation will depend on how much work is required to bring the project analysis up-to-date.

* Likewise, calling any of `GetUsesOfSymbol`, `GetAllUsesOfAllSymbols`, `ParseFileInProject`, `GetBackgroundParseResultsForFileInProject`, `MatchBraces`, `CheckFileInProjectIfReady`, `ParseAndCheckFileInProject`, `GetBackgroundCheckResultsForFileInProject`, `ParseAndCheckProject` `GetProjectOptionsFromScript`, `InvalidateConfiguration`, `InvaidateAll` and operations on `FSharpCheckResults` will cause an operation to be enqueued. The length of the operation will vary - many will be very fast - but they won't be processed until other operations already in the queue are complete.

Some operations do not enqueue anything on the FSharpChecker operations queue - notably any accesses to the Symbol APIs. These use cross-threaded access to the TAST data produced by other FSharpChecker operations.

Some tools throw a lot of interactive work at the FSharpChecker operations queue. If you are writing such a component, consider running your project against a debug build of `FSharp.Compiler.Service.dll` to see the `Trace.WriteInformation` messages indicating the length of the operations queue and the time to process requests.

For those writing interactive editors which use FCS, you should be cautious about operations that request a check of  the entire project. For example, be careful about requesting the check of an entire project on operations like "Highlight Symbol" or "Find Unused Declarations" (which run automatically when the user opens a file or moves the cursor), as opposed to operations like "Find All References" (which a user explicitly triggers). Project checking can cause long and contention on the FSharpChecker operations queue. Requests to FCS can be cancelled by cancelling the async operation. (Some requests also
include additional callbacks which can be used to indicate a cancellation condition). This cancellation will be effective if the cancellation is performed before the operation is executed in the operations queue.

## Attribution

This guide is based on an [original document](https://fsharp.github.io/FSharp.Compiler.Service/queue.html) written by the F# community.