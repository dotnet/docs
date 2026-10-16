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

The file read receives the running async workflow's token, supplied when the caller starts that workflow. A missing file returns `None`, while a successful read returns `Some contents`. The workflow waits for the operation to finish, including its cancellation or cleanup. Starting the operation without passing its token and only then awaiting it can't retroactively make the operation observe cancellation.

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

`Async.RunSynchronouslyImmediate` begins on the calling thread until the first asynchronous suspension and then blocks for completion. Unlike `Async.RunSynchronously`, it doesn't initially offload foreground-thread execution. It has no timeout parameter. Neither synchronous runner is a substitute for asynchronous composition on a UI or request thread.

### Expose an async workflow as a task

To offer the file-reading workflow above to task-based callers, accept a cancellation token and pass it through `Task.startAsyncImmediate`:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="AsyncBoundary":::

The return type is `Task<string option>`. A successful read returns `Some contents`, a missing file returns `None`, and cancellation still propagates. The bridge starts the workflow on the calling thread until its first asynchronous suspension. It doesn't promise to run every continuation on that thread.

## Bound concurrency

An `Async<'T>` value describes deferred work. A task usually represents an operation that has already started. To limit resource use, describe task work as factories rather than already-running tasks:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Bounded":::

`Task.parallelLimit` starts at most the positive limit of computations concurrently and returns results in input order. Start order and completion order are otherwise unspecified. For concurrency greater than one, each factory receives a linked token that also signals sibling failure; for sequential execution it receives the supplied token directly.

When one computation faults, cancellation is requested for its siblings. Operations must observe their tokens to cooperate. If several computations fail, one exception is propagated; don't depend on which failure wins.

To observe result ordering without relying on timer delays or worker scheduling, complete two task results explicitly in reverse order:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Coordination.fs" id="Ordering":::

`TaskCompletionSource<'T>` lets the example supply a task's result explicitly. The returned array follows the factories' order even though the second source receives its result first. The example doesn't prescribe start order or elapsed time.

| Function | Signature shape |
|---|---|
| `Task.parallelLimit` | `int -> CancellationToken -> seq<CancellationToken -> Task<'T>> -> Task<'T[]>` |
| `Task.parallelDoLimit` | `int -> CancellationToken -> seq<CancellationToken -> Task<unit>> -> Task<unit>` |
| `Task.sequential` | `CancellationToken -> seq<CancellationToken -> Task<'T>> -> Task<'T[]>` |
| `Task.sequentialDo` | `CancellationToken -> seq<CancellationToken -> Task<unit>> -> Task<unit>` |
| `Async.parallelLimit` | `int -> seq<Async<'T>> -> Async<'T[]>` |
| `Async.parallelDoLimit` | `int -> seq<Async<unit>> -> Async<unit>` |
| `Async.sequentialDo` | `seq<Async<unit>> -> Async<unit>` |

The `Async` functions flow the workflow's ambient cancellation token. Existing `Async.Parallel` (including its concurrency-limit option) and `Async.Sequential` remain available. The `Do` variants avoid allocating a result array when you only need completion. A concurrency limit isn't a rate limiter: fast operations can still produce many requests per second.

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

The lowercase `Async.catch` returns `Result`, whereas the existing `Async.Catch` returns `Choice`. `catchWith` and `catch` observe failures of the supplied computation; they can't catch a synchronous exception thrown before you supply that computation. The functions preserve async's deferred execution and task's eager execution; a common name doesn't make their scheduling models identical.

## ValueTask and library availability

The ValueTask APIs are available in the `netstandard2.1` and `net10.0` builds of FSharp.Core 11, not its `netstandard2.0` build. These are target-specific versions of the library within the same package, selected by NuGet for your project's target framework. Use a package version containing the API you call; changing `LangVersion` doesn't add library functions.

`ValueTask<'T>` is a struct that can contain a result directly or represent an asynchronous operation. Observe its [single-consumption contract](/dotnet/api/system.threading.tasks.valuetask-1#remarks): don't await the same value repeatedly or concurrently, or pass it into separate combinator pipelines. A single pipeline consumes its input and passes its new result onward. If repeated awaits are required, call `Task.ofValueTask` once and reuse only the resulting task; don't consume the original value task again.

## See also

- [Asynchronous programming](../tutorials/async.md)
- [Task expressions](task-expressions.md)
- [FSharp.Core API reference](https://fsharp.github.io/fsharp-core-docs/)
- [What's new in F# 11](../whats-new/fsharp-11.md)
