---
title: Async and task functions
description: Choose FSharp.Core functions for task interop, cancellation, result transformations, and bounded concurrency.
ms.date: 09/29/2026
ai-usage: ai-generated
---

# Async and task functions

FSharp.Core 11 adds functions for task interop, result transformations, and bounded concurrency. Use them with existing [async workflows](../tutorials/async.md) and [task expressions](task-expressions.md); they don't require the runtime-async prototype.

## Await .NET operations from async

To start a .NET operation with the async workflow's cancellation token, pass a factory to `Async.StartTaskImmediate`:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Await":::

The file read receives the workflow's cancellation token. A missing file returns `None`; a successful read returns `Some contents`. The workflow waits for completion, including cancellation and cleanup.

Use `Async.Await` when you already have a task-like value. Both APIs propagate the single underlying exception of a faulted task directly. An aggregate with multiple inner exceptions remains an aggregate. `Async.AwaitTask` keeps its existing exception-wrapping behavior.

| API | Supported argument/result shapes |
|---|---|
| `Async.Await` | `Task<'T> -> Async<'T>`; `Task -> Async<unit>` |
| `Async.Await` | `ValueTask<'T> -> Async<'T>`; `ValueTask -> Async<unit>` |
| `Async.Await` | Inline task-like overload using the `GetAwaiter` protocol. |
| `Async.StartTaskImmediate` | `(CancellationToken -> Task<'T>) -> Async<'T>`; non-generic `Task` returns `Async<unit>`. |
| `Async.StartTaskImmediate` | Corresponding `ValueTask`, `ValueTask<'T>`, and task-like factory overloads. |
| `Task.startAsyncImmediate` | `CancellationToken -> Async<'T> -> Task<'T>` |
| `Async.RunSynchronouslyImmediate` | `Async<'T> * ?cancellationToken: CancellationToken -> 'T` |

`Async.RunSynchronouslyImmediate` starts on the calling thread, unlike `Async.RunSynchronously` on a foreground thread, and blocks for completion. It has no timeout parameter. Prefer asynchronous composition on UI and request threads.

### Expose an async workflow as a task

To offer the file-reading workflow above to task-based callers, accept a cancellation token and pass it through `Task.startAsyncImmediate`:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="AsyncBoundary":::

The bridge returns `Task<string option>` and propagates cancellation. It starts on the calling thread until the first suspension; later continuations needn't use that thread.

## Bound concurrency

An `Async<'T>` value describes deferred work. A task usually represents an operation that has already started. To limit resource use, describe task work as factories rather than already-running tasks:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Bounded":::

`Task.parallelLimit` starts at most the positive limit of computations concurrently and returns results in input order. Start order and completion order are otherwise unspecified. For concurrency greater than one, each factory receives a linked token that also signals sibling failure; for sequential execution it receives the supplied token directly.

When one computation faults, cancellation is requested for its siblings. Operations must observe their tokens to cooperate. If several computations fail, one exception is propagated; don't depend on which failure wins.

| Function | Signature shape |
|---|---|
| `Task.parallelLimit` | `int -> CancellationToken -> seq<CancellationToken -> Task<'T>> -> Task<'T[]>` |
| `Task.parallelDoLimit` | `int -> CancellationToken -> seq<CancellationToken -> Task<unit>> -> Task<unit>` |
| `Task.sequential` | `CancellationToken -> seq<CancellationToken -> Task<'T>> -> Task<'T[]>` |
| `Task.sequentialDo` | `CancellationToken -> seq<CancellationToken -> Task<unit>> -> Task<unit>` |
| `Async.parallelLimit` | `int -> seq<Async<'T>> -> Async<'T[]>` |
| `Async.parallelDoLimit` | `int -> seq<Async<unit>> -> Async<unit>` |
| `Async.sequentialDo` | `seq<Async<unit>> -> Async<unit>` |

The `Async` functions flow the workflow's ambient cancellation token. Existing `Async.Parallel` (including its concurrency-limit option) and `Async.Sequential` remain available. The `Do` variants expose a `unit` result when you only need completion. A concurrency limit isn't a rate limiter: fast operations can still produce many requests per second.

## Transform results and recover from faults

The `Microsoft.FSharp.Control.Async`, `Task`, and `ValueTask` modules expose these qualified functions. `M<'T>` in the shape column stands for the corresponding computation type, not an F# type abbreviation.

| Qualified functions | Shape |
|---|---|
| `Async.result`, `Task.result`, `ValueTask.result` | `'T -> M<'T>` |
| `Async.map`, `Task.map`, `ValueTask.map` | `('T -> 'U) -> M<'T> -> M<'U>` |
| `Async.bind`, `Task.bind`, `ValueTask.bind` | `('T -> M<'U>) -> M<'T> -> M<'U>` |
| `Async.ignore<'T>`, `Task.ignore<'T>`, `ValueTask.ignore<'T>` | `M<'T> -> M<unit>`; explicit input type argument required. |
| `Async.catchWith`, `Task.catchWith`, `ValueTask.catchWith` | `(exn -> 'T) -> M<'T> -> M<'T>` |
| `Async.catch`, `Task.catch`, `ValueTask.catch` | `M<'T> -> M<Result<'T, exn>>` |
| `Async.empty`, `Task.empty`, `ValueTask.empty` | `M<unit>` |
| `Task.ofValueTask` | `ValueTask<'T> -> Task<'T>` |
| `ValueTask.ofTask` | `Task<'T> -> ValueTask<'T>` |

For example, map a file's contents to a length, then represent a read failure as a `Result`:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` gives `Ok 8`. A missing file gives an `Error` containing a `FileNotFoundException`. To discard a successful value rather than transform it, specify the input type when you call `ignore`:

```fsharp
let completion: System.Threading.Tasks.Task<unit> =
    Task.result 42 |> Task.ignore<int>
```

`catchWith` supplies a replacement value for a non-cancellation failure; it doesn't run another asynchronous computation. `catch` returns `Ok` or `Error`. Cancellation isn't converted to an error value or passed to the recovery handler. `Task.empty` is a `Task<unit>`, not the non-generic `Task.CompletedTask`.

Unlike lowercase `Async.catch`, existing `Async.Catch` returns `Choice`. Recovery handles failures of the supplied computation, not synchronous exceptions thrown before the call. Async remains deferred; tasks remain eager.

## ValueTask and library availability

ValueTask APIs require the `netstandard2.1` or `net10.0` build of FSharp.Core 11. See [Core target selection](../fsharp-core-targeting.md).

Observe the [ValueTask single-consumption contract](/dotnet/api/system.threading.tasks.valuetask-1#remarks): consume each value once, not through separate awaits or pipelines. For repeated awaits, call `Task.ofValueTask` once and reuse only the resulting task.

## See also

- [Asynchronous programming](../tutorials/async.md)
- [Task expressions](task-expressions.md)
- [FSharp.Core API reference](https://fsharp.github.io/fsharp-core-docs/)
- [What's new in F# 11](../whats-new/fsharp-11.md)
