---
title: Runtime async
description: "Learn about Runtime Async in .NET 11, which manages asynchronous suspension and resumption natively within the runtime instead of compiler-generated state machines."
ms.date: 10/27/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Runtime async

Starting in .NET 11, .NET introduces **Runtime Async** (Runtime Async V2), an execution model where asynchronous method suspension and resumption are handled natively by the Common Language Runtime (CLR) rather than through compiler-generated state machine structures.

## Overview

In traditional C# asynchronous programming, the compiler rewrites every `async` method into a state-machine `struct` or `class` that implements <xref:System.Runtime.CompilerServices.IAsyncStateMachine>. The method body is transformed into a `MoveNext()` method containing a switch table across await suspension points, orchestrated by an <xref:System.Runtime.CompilerServices.AsyncTaskMethodBuilder>.

While compiler-generated state machines enabled the widespread adoption of `async`/`await`, they introduce trade-offs:
- **Compiler code expansion:** Every async method generates extra metadata, structs, and helper methods, increasing assembly size.
- **Mangled live stack traces:** When taking stack traces of running threads or inspecting debuggers, execution frames display state-machine plumbing (such as `AsyncMethodBuilderCore.Start` and `<MethodName>d__1.MoveNext`) rather than clean method call chains.
- **Stepping overhead:** Debuggers must parse compiler-generated mapping tables to provide smooth stepping over `await` expressions.

**Runtime Async** moves the management of async suspension points, continuation dispatch, and local variable preservation directly into the CLR and the Just-In-Time (JIT) compiler. The compiler emits straightforward method bodies with runtime async markers, allowing the CLR to manage async execution frames efficiently.

## Feature status and requirements

Runtime Async is available starting in **.NET 11** as a preview feature. The .NET 11 runtime and base class libraries are built with Runtime Async enabled by default.

### Enable Runtime Async

To opt in to Runtime Async in your application or library, set the `Features` property in your project file:

```xml
<PropertyGroup>
  <Features>runtime-async=on</Features>
</PropertyGroup>
```

> [!NOTE]
> Projects targeting `net11.0` do not require `<EnablePreviewFeatures>true</EnablePreviewFeatures>` to enable Runtime Async.

### Opt out of Runtime Async

If you need to disable Runtime Async for a specific project, set the `<UseRuntimeAsync>` property to `false`:

```xml
<PropertyGroup>
  <UseRuntimeAsync>false</UseRuntimeAsync>
</PropertyGroup>
```

> [!IMPORTANT]
> The legacy `DOTNET_RuntimeAsync` and `UNSUPPORTED_RuntimeAsync` environment variables used in early experimental prototypes have been removed in .NET 11. Project-level configuration through MSBuild properties is the supported mechanism to control Runtime Async.

## Cleaner live stack traces

The most noticeable benefit of Runtime Async is in *live stack traces*—what profilers, diagnostic tools, and <xref:System.Diagnostics.StackTrace?displayProperty=nameWithType> capture during execution.

With compiler-generated async, each asynchronous invocation inserts intermediate state-machine helper frames into the call stack:

```text
   at Program.<<Main>$>g__InnerAsync|0_2() in Program.cs:line 24
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](TStateMachine& stateMachine)
   at Program.<<Main>$>g__InnerAsync|0_2()
   at Program.<<Main>$>g__MiddleAsync|0_1() in Program.cs:line 14
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](TStateMachine& stateMachine)
   at Program.<<Main>$>g__MiddleAsync|0_1()
   at Program.<Main>$(String[] args) in Program.cs:line 7
```

With **Runtime Async**, the synthetic infrastructure frames are absent. Live stack traces directly display the logical method invocations:

```text
   at Program.<<Main>$>g__InnerAsync|0_2() in Program.cs:line 24
   at Program.<<Main>$>g__MiddleAsync|0_1() in Program.cs:line 14
   at Program.<Main>$(String[] args) in Program.cs:line 7
```

> [!NOTE]
> Exception stack traces (captured via `catch (Exception ex)`) already appeared clean in earlier .NET versions because runtime stack-trace formatting filters out compiler-generated state-machine frames. Runtime Async brings that same clarity to live thread inspection, profilers, and debuggers.

## Debugging experience

Runtime Async significantly simplifies debugger operation:
- **Breakpoint binding:** Breakpoints reliably bind to the source lines inside async methods without relying on state-machine IL offset remapping.
- **Single-stepping:** Stepping into or over an `await` statement transfers control directly across suspension boundaries without exposing internal builder calls.
- **Local variable inspection:** The runtime preserves active local variables in the runtime frame without hoisting every variable into fields of a heap-allocated state machine closure.

## Native AOT and ReadyToRun

Runtime Async fully supports Ahead-of-Time compilation, including **Native AOT** and **ReadyToRun (R2R)** via `crossgen2`:
- **Smaller binary footprint:** Eliminating compiler-generated state-machine structs and interfaces reduces compiled binary size for async-heavy applications.
- **R2R inlining:** In .NET 11, previous restrictions preventing runtime-async methods from inlining during ReadyToRun compilation have been resolved. Synchronous fast paths (where an awaited task completes synchronously) inline cleanly across R2R boundaries.
- **Covariant return bridging:** When an overriding method returns `Task<T>` while its base method returns `Task`, the runtime automatically generates calling-convention bridging thunks compatible with Native AOT.

## Continuations and ExecutionContext

In .NET asynchronous programming, <xref:System.Threading.ExecutionContext> propagates ambient information, such as <xref:System.Threading.AsyncLocal`1> values, across asynchronous suspension points.

Runtime Async includes optimizations that detect when an asynchronous continuation does not depend on ambient `ExecutionContext` modifications. When no ambient context needs to be restored, the runtime elides the capture and restore cycles, avoiding unnecessary allocations and synchronization overhead in high-throughput pipelines.

## Performance characteristics

Runtime Async introduces several architectural JIT optimizations:
- **Tail-merged suspension points:** The JIT merges common suspension and resumption handling to minimize generated native code size.
- **Tiered compilation for async:** Runtime-async methods participate directly in tiered compilation. Hot async methods are promoted to Tier 1 optimizations after warm-up without state-machine dispatch penalties.
- **Intrinsic factory recognition:** Common task completion factories like <xref:System.Threading.Tasks.Task.FromResult*?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.CompletedTask?displayProperty=nameWithType> are recognized as JIT intrinsics and folded directly into fast paths.
- **Continuation reuse:** Internal continuation objects are cached and reused across suspension points rather than allocating anew per await.

## See also

- [Asynchronous programming in C#](index.md)
- [Task asynchronous programming model](task-asynchronous-programming-model.md)
- [Async return types](async-return-types.md)
- [What's new in .NET 11 runtime](../../core/whats-new/dotnet-11/runtime.md#runtime-async)
