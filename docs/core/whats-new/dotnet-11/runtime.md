---
title: What's new in .NET 11 runtime
description: Learn about the new features introduced in the .NET 11 runtime.
titleSuffix: ""
ms.date: 07/14/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the .NET 11 runtime

This article describes new features in the .NET runtime for .NET 11. It was last updated for Preview 6.

## Updated minimum hardware requirements

The minimum hardware requirements for .NET 11 have been updated to require more modern instruction sets on both x86/x64 and Arm64 architectures. Additionally, the ReadyToRun (R2R) compilation targets have been updated to take advantage of newer hardware capabilities.

### Arm64 requirements

For Apple, there's no change to the minimum hardware or the ReadyToRun target. The Apple M1 chips are approximately equivalent to `armv8.5-a` and provide support for at least the `AdvSimd` (NEON), `CRC`, `DOTPROD`, `LSE`, `RCPC`, `RCPC2`, and `RDMA` instruction sets.

For Linux, there's no change to the minimum hardware. .NET continues to support devices such as Raspberry Pi that might only provide support for the `AdvSimd` instruction set. The ReadyToRun target has been updated to include the `LSE` instruction set, which might result in additional jitting overhead if you launch an application.

For Windows, the baseline is updated to require the `LSE` instruction set. This is [required by Windows 11](/windows-hardware/design/minimum/minimum-hardware-requirements-overview) and by [all Arm64 CPUs officially supported by Windows 10](/windows-hardware/design/minimum/windows-processor-requirements). Additionally, it's inline with the Arm SBSA (Server Base System Architecture) requirements. The ReadyToRun target has been updated to be `armv8.2-a + RCPC`, which provides support for at least `AdvSimd`, `CRC`, `LSE`, `RCPC`, and `RDMA`, and covers the majority of hardware officially supported.

| OS      | Previous JIT/AOT minimum | New JIT/AOT minimum | Previous R2R target | New R2R target   |
|---------|--------------------------|---------------------|---------------------|------------------|
| Apple   | Apple M1                 | (No change)         | Apple M1            | (No change)      |
| Linux   | armv8.0-a                | (No change)         | armv8.0-a           | armv8.0-a + LSE  |
| Windows | armv8.0-a                | armv8.0-a + LSE     | armv8.0-a           | armv8.2-a + RCPC |

### x86/x64 requirements

For all three operating systems (Apple, Linux, and Windows), the baseline is updated from `x86-64-v1` to `x86-64-v2`. This changes the hardware from only guaranteeing `CMOV`, `CX8`, `SSE`, and `SSE2` to also guaranteeing `CX16`, `POPCNT`, `SSE3`, `SSSE3`, `SSE4.1`, and `SSE4.2`. This guarantee is required by Windows 11 and by all x86/x64 CPUs officially supported on Windows 10. It includes all chips still officially supported by Intel and AMD, with the last older chips having gone out of support around 2013.

The ReadyToRun target has been updated to `x86-64-v3` for Windows and Linux, which additionally includes the `AVX`, `AVX2`, `BMI1`, `BMI2`, `F16C`, `FMA`, `LZCNT`, and `MOVBE` instruction sets. The ReadyToRun target for Apple remains unchanged.

| OS      | Previous JIT/AOT minimum | New JIT/AOT minimum | Previous R2R target | New R2R target |
|---------|--------------------------|---------------------|---------------------|----------------|
| Apple   | x86-64-v1                | x86-64-v2           | x86-64-v2           | (No change)    |
| Linux   | x86-64-v1                | x86-64-v2           | x86-64-v2           | x86-64-v3      |
| Windows | x86-64-v1                | x86-64-v2           | x86-64-v2           | x86-64-v3      |

### Impact

Starting with .NET 11, .NET fails to run on older hardware and might print a message similar to the following:

> The current CPU is missing one or more of the baseline instruction sets.

For [ReadyToRun](../../deploying/ready-to-run.md)-capable assemblies, there might be additional startup overhead on some supported hardware that doesn't meet the expected support for a typical device.

### Reason for change

.NET supports a broad range of hardware, often above and beyond the minimum hardware requirements put in place by the underlying operating system. This support adds significant complexity to the codebase, particularly for much older hardware that's unlikely to still be in use. Additionally, it defines a "lowest common denominator" that AOT targets must default to, which can, in some scenarios, lead to reduced performance.

The update to the minimum baseline was made to reduce the maintenance complexity of the codebase and to better align with the documented (and often enforced) hardware requirements of the underlying operating system.

For more information, see [Minimum hardware requirements updated](../../compatibility/jit/11/minimum-hardware-requirements.md).

## Runtime Async

.NET 11 introduces runtime-native async (Runtime Async V2), a significant step toward replacing compiler-generated async state machines with runtime-managed suspension and resumption. Instead of the compiler emitting state-machine classes, the runtime itself tracks async execution, producing cleaner stack traces, better debuggability, and lower overhead.

Runtime Async is a preview feature. To opt in, add the following property to your project file:

```xml
<PropertyGroup>
  <Features>runtime-async=on</Features>
</PropertyGroup>
```

A `net11.0` project no longer requires `<EnablePreviewFeatures>true</EnablePreviewFeatures>` to use Runtime Async.

The .NET runtime libraries themselves are compiled with `runtime-async=on`. The runtime libraries no longer contain compiler-generated state machines and rely entirely on runtime-provided async. This makes it possible to migrate an entire app (with only library dependencies) to the new model, and it provides broad functional and performance validation of the feature. The product team welcomes any reports—positive or negative—about throughput and library size changes you observe.

.NET 11 also includes two additional improvements:

- **Covariant `Task` → `Task<T>` overrides:** When a derived class returns `Task<T>` for a base method that returns `Task`, the runtime now generates a void-returning thunk that bridges the calling convention difference, so virtual dispatch works for both flavors. The same fix applies to NativeAOT.
- **Inlining in crossgen2:** Restrictions that prevented runtime-async methods from being inlined during ReadyToRun (R2R) compilation have been removed. All async tests pass with both crossgen2 and composite R2R, and inlining of await-less async calls (the synchronous fast path) is confirmed end-to-end.

> [!NOTE]
> The `DOTNET_RuntimeAsync` and `UNSUPPORTED_RuntimeAsync` environment variables that previously controlled runtime-async behavior have been removed. To opt out of runtime-async per project, set `<UseRuntimeAsync>false</UseRuntimeAsync>` in your project file instead of relying on the environment variable.

### Cleaner live stack traces

The most visible improvement is in *live stack traces*—what profilers, debuggers, and `new StackTrace()` see during execution. With compiler-generated async, each async method produces multiple frames from state-machine infrastructure. With Runtime Async, the actual methods appear directly on the call stack.

:::code language="csharp" source="./snippets/csharp/Runtime.cs" id="RuntimeAsyncStackTrace":::

**Without `runtime-async`—13 frames, state-machine infrastructure visible:**

```text
   at Program.<<Main>$>g__InnerAsync|0_2() in Program.cs:line 24
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](...)
   at Program.<<Main>$>g__InnerAsync|0_2()
   at Program.<<Main>$>g__MiddleAsync|0_1() in Program.cs:line 14
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](...)
   at Program.<<Main>$>g__MiddleAsync|0_1()
   at Program.<<Main>$>g__OuterAsync|0_0() in Program.cs:line 8
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](...)
   at Program.<<Main>$>g__OuterAsync|0_0()
   at Program.<Main>$(String[] args) in Program.cs:line 3
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](...)
   at Program.<Main>$(String[] args)
   at Program.<Main>(String[] args)
```

**With `runtime-async`—5 frames, the real call chain:**

```text
   at Program.<<Main>$>g__InnerAsync|0_2() in Program.cs:line 24
   at Program.<<Main>$>g__MiddleAsync|0_1() in Program.cs:line 14
   at Program.<<Main>$>g__OuterAsync|0_0() in Program.cs:line 8
   at Program.<Main>$(String[] args) in Program.cs:line 3
   at Program.<Main>(String[] args)
```

> [!NOTE]
> Exception stack traces (from `catch (Exception ex)`) already look the same with or without Runtime Async, because existing `ExceptionDispatchInfo` cleanup in compiler-generated code handles that case. The improvement is in what you see *during* live execution.

This improvement benefits anything that inspects the live execution stack, including profiling tools, diagnostic logging, and the debugger call stack window.

### NativeAOT and ReadyToRun support

Runtime Async supports NativeAOT and ReadyToRun compilation. This extends the feature beyond JIT-compiled code to ahead-of-time compiled scenarios. The runtime also reuses continuation objects more aggressively and avoids saving unchanged locals, reducing allocation pressure in async-heavy code.

### Debugging improvements

Breakpoints now bind correctly inside runtime-async methods, and the debugger can step through `await` boundaries without jumping into compiler-generated infrastructure.

### Runtime Async performance improvements

Preview 6 adds several performance improvements to Runtime Async:

- **JIT async support:** The JIT compiles a dedicated runtime-async version of a synchronous, task-returning method rather than delegating through a thunk. The JIT turns the method's tail calls into runtime-async calls and awaits the task that would otherwise be returned, eliminating an extra layer of indirection.
- **Tail-merged suspension points:** The JIT tail-merges async suspension points so generated code is smaller.
- **Cached continuations:** Continuations used for runtime-async callable task thunks are cached and reused.
- **Pooled methods opt out:** Methods that are already pooled opt out of runtime-async, avoiding redundant work.

#### Async continuations without ExecutionContext

Async continuations can now opt out of `ExecutionContext` capture and restore. `ExecutionContext` carries ambient state—such as `AsyncLocal<T>` values—across `await` points. Every `Task` continuation previously captured a snapshot of the context and restored it before running, even when no `AsyncLocal<T>` state was in use and the restore was a no-op.

The runtime now detects when a continuation has nothing to restore and skips the capture/restore cycle entirely. `Task`, `Task<T>`, `ValueTask`, and `ValueTask<T>` all benefit from this change, as does the runtime-async implementation path. Applications that use `ConfigureAwait(false)` and `AsyncLocal<T>` sparingly see reduced overhead in high-throughput async code paths.

## JIT improvements

- **Bounds check elimination:** The just-in-time (JIT) compiler now eliminates bounds checks for the common pattern where an index plus a constant is compared against a length, such as `i + cns < len`. It also eliminates more redundant bounds checks for index-from-end access (for example, `values[^1]`). These improvements reduce redundant checks in tight loops and improve throughput for array and span operations.
- **Redundant checked context removal:** The JIT can now prove and remove redundant checked arithmetic contexts—for example, when a value is already known to be in range. This optimization eliminates unnecessary overflow checks in generated code.
- **Switch expression folding:** Multi-target `switch` expressions now fold into simpler branchless checks when the targets are a small set of constants, for example `x is 0 or 1 or 2 or 3 or 4`.
- **Faster uint-to-float/double casts:** Casting `uint` to `float` or `double` is faster on pre-AVX-512 x86 hardware.
- **Devirtualization in ReadyToRun images:** ReadyToRun (R2R) images can now devirtualize non-shared generic virtual method calls, improving performance of ahead-of-time compiled code for generic scenarios.
- **SVE2 intrinsics:** New Arm SVE2 (Scalable Vector Extension 2) intrinsics are available: `ShiftRightLogicalNarrowingSaturate(Even|Odd)`. These expand the set of vectorized operations available on Arm hardware that supports SVE2.
- **`Math.BigMul` on x64:** `Math.BigMul(long, long, out long)` is now significantly faster on x64. The JIT generates a single `MUL r/m64` instruction when both operands are 64-bit values and the caller requests the high half of the result, eliminating the previous helper call.
- **Single-IG prolog restriction removed:** The JIT no longer requires the function prolog to fit in a single instruction group (IG). Complex prologues with many saved registers, large stack allocations, or runtime-async state setup no longer trigger fallback paths.
- **`SELECT(cond, cns, cns)` folding:** The JIT now folds conditional selects whose two branches both produce the same constant into just that constant—for example, `condition ? 42 : 42` becomes `42`. This fold eliminates unnecessary comparisons that can appear after earlier optimizations unify branches.
- **ARM64 `Vector<T>` by reference for SVE:** When the runtime is compiled with ARM SVE support, `Vector<T>` values are passed by reference rather than by value, aligning with the ARM calling convention for scalable types and enabling better code generation for SVE-intensive code.

For better performance and code quality, .NET 11 adds several more JIT optimizations:

### Constant-folding SequenceEqual

The JIT can now fold a `string.Equals` or `ReadOnlySpan<T>.SequenceEqual` call whose operands are both compile-time constants, replacing the byte-by-byte comparison with the constant `true` or `false` result. This matters most after inlining, when a caller passes another literal to a helper that compares against a known string. When `IsAdmin` is inlined into a caller that passes `"Guest"`, the JIT sees `"Guest" == "Admin"` and folds it to `false`:

```csharp
static bool IsAdmin(string role) => role == "Admin";
```

The optimization applies to string literals, `const string` fields, and UTF-8 literals (for example, `"PNG"u8`).

### Eliminating bounds checks after an empty-span guard

The JIT now picks up the `length != 0` assertion from an empty-span check and uses it to prove the bounds check on the first element succeeds:

```csharp
if (!span.IsEmpty && span[0] == value)
{
    // The bounds check on span[0] is now eliminated.
}
```

### Redundant branch and test elimination

When an outer predicate is already implied by an inner branch, the JIT now removes the redundant outer check. Similarly, when code assigns a value in a conditional and then immediately tests it, the second test is eliminated:

```csharp
if (x > 0)
{
    if (x > 1) S();  // The outer x > 0 check is folded away.
}

int y = condition ? 1 : 2;
if (y == 1) A(); else B();  // The y == 1 test is eliminated;
                             // each branch of the ternary goes directly to A() or B().
```

These optimizations are most visible after inlining, where guards from different methods land in the same compiled body.

## Hardware intrinsics and code generation

.NET 11 includes several new hardware intrinsics and code generation improvements:

- **F16C acceleration for `Half` ↔ `float` conversions on x64:** When the CPU supports F16C (most AVX2-capable hardware), conversions between <xref:System.Half> and `float`/`double` now use the dedicated `vcvtph2ps`/`vcvtps2ph` instructions instead of helper calls.
- **Better cost modeling for x86/x64 SIMD:** The JIT's floating-point execution and size costs previously reflected x87-era assumptions. Updated costs that reflect modern SSE/AVX hardware let the JIT make better decisions about hoisting and common subexpression elimination (CSE) around SIMD code.
- **Faster `DotProduct` on AVX:** Lowering for `Vector128.Dot`-style operations now emits a `mul + permute + add` sequence instead of `vdpps`/`vdppd` when AVX is available, which is consistently faster.
- **Faster `IndexOfAnyAsciiSearcher` on Arm64:** Arm64 versions of `Vector*.Count`, `IndexOf`, and `LastIndexOf` no longer route through `ExtractMostSignificantBits`, yielding a 5–50% improvement in workloads that use these APIs in their core loop.
- **Arm64 `ToScalar` for 64-bit integers:** `ToScalar` on `Vector*<long>` and `Vector*<ulong>` now uses `fmov` instead of `umov`, which is shorter and faster on most cores.
- **SVE `CreateWhile` API expansion:** `CreateWhile` gains signed, `double`, and `single` variants alongside the existing unsigned ones, completing the predicate-generation surface for SVE loops.
- **New SVE2 and Arm64 instruction-set detection:** The runtime now reports `SVE_AES`, `SVE_SHA3`, `SVE_SM4`, `SHA3`, and `SM4` as separate instruction sets, allowing `Sve2*.IsSupported` queries for those features on capable hardware.
- **AVX10 detection fix:** The CPUID-bit cache for AVX10 was being overwritten by a later query, which could cause AVX10 to be misreported on capable hardware. This is now fixed.

## ReadyToRun improvements

`Comparer<T>.Default` and `EqualityComparer<T>.Default` are now specialized in ReadyToRun (R2R) images. Previously, the default comparers used reflection that R2R couldn't see ahead of time, causing callers to fall back to the JIT. R2R now generates a specialized helper in the image—mirroring the NativeAOT approach—and benchmarks show up to a 20× improvement for collections operations that rely on the default comparer.

## VM improvements

- **Cached interface dispatch on non-JIT platforms:** On platforms that lack JIT support, such as iOS, interface dispatch was falling back to an expensive generic fixup path. Cached dispatch yields up to 200x improvements in interface-heavy code on these targets.
- **`Guid.NewGuid()` on Linux:** <xref:System.Guid.NewGuid?displayProperty=nameWithType> on Linux now uses the `getrandom()` syscall with batch caching instead of reading from `/dev/urandom`, yielding approximately 12% throughput improvement for GUID generation.

## WebAssembly improvements

Browser and WebAssembly support has several improvements:

- **WebCIL payload loading:** The runtime can now load WebCIL payloads directly, improving compatibility with browser-based deployment scenarios.
- **Better debugging symbols:** Symbol and stack trace quality for WebAssembly debugging has improved, making it easier to diagnose issues in browser-hosted .NET apps.
- **`float[]`, `Span<float>`, and `ArraySegment<float>` marshaling:** `float[]`, `Span<float>`, and `ArraySegment<float>` are now marshaled more directly across JavaScript boundaries, reducing overhead for interop-heavy code.

.NET includes improvements to CoreCLR-on-WebAssembly:

- **WebCIL V1 is the default for CoreCLR WASM builds:** The shared WebCIL header gains a `TableBase` field (28 → 32 bytes). Both Mono and CoreCLR readers accept V0 and V1. Crossgen2's `WasmObjectWriter` produces V1 directly, and CoreCLR-flavored WASM SDK builds default `WasmWebcilVersion` to `V1`.
- **Native re-link works for CoreCLR WASM apps:** A full Emscripten-based pipeline replaces the previous stub targets. Re-linking `dotnet.native.wasm` from the runtime pack and including custom native code via `NativeFileReference` now works.
- **JavaScript minification in Release builds:** Browser CoreCLR Release builds ship minified JavaScript.
- **NativeAOT publish for WASM no longer drops package satellites:** Satellite assemblies from NuGet packages are now passed to ILC and pruned from the publish output, fixing localization for AOT-published apps that depend on packages such as `System.CommandLine`.

## Platform support for more than 1024 CPUs

The .NET runtime can now initialize on machines with more than 1024 logical processors. Previously, `sched_getaffinity` was called with the default `cpu_set_t` (capped at 1024), causing initialization to fail on high-core-count servers. The runtime now allocates the CPU set dynamically. The GC retains its 1024-heap limit, but the CPU count limit is removed.

## In-process crash report logging

A new in-process crash reporting mechanism captures diagnostic information from within the crashing process before it terminates. Previously, crash diagnostics were collected by an out-of-process monitor. While the out-of-process approach is safe, it can miss information that's only available inside the dying process. The new in-process path logs the managed stack trace, module list, and key runtime state to a well-known path before the process exits.

This capability is specific to mobile platforms.

## NativeAOT: faster interface dispatch

NativeAOT now uses a dispatch helper for interface method calls. Instead of a direct fat-pointer call sequence, the runtime routes interface dispatch through a shared helper that can be patched to the correct implementation after the call site warms up. This reduces the binary size of interface call sites and improves throughput on workloads with many interface method calls.

## SIMD lane construction and composition

`System.Runtime.Intrinsics` now includes lane construction and composition APIs for hardware vector types. The new APIs let you construct a vector from individually specified lanes and extract or reorder lanes between vectors. This enables precise, portable control over SIMD vector element placement without falling back to platform-specific intrinsics.

The new methods fall into a few families:

- **Patterned construction:** `CreateGeometricSequence`, `CreateAlternatingSequence`, and `CreateHarmonicSequence` build a vector from a starting value and a rule.
- **Interleave and de-interleave:** `Zip`, `ZipLower`/`ZipUpper`, `Unzip`, `UnzipEven`/`UnzipOdd`.
- **Rearrange:** The `Concat` family (`ConcatLowerLower`, `ConcatLowerUpper`, `ConcatUpperLower`, `ConcatUpperUpper`) and `Reverse`.

```csharp
using System.Runtime.Intrinsics;

// {1, 2, 4, 8} — each lane is the previous lane times two
Vector128<int> powers = Vector128.CreateGeometricSequence(1, 2);

// Interleave two vectors lane-by-lane
(Vector128<int> lower, Vector128<int> upper) =
    Vector128.Zip(Vector128.Create(1), Vector128.Create(2));
```

These APIs are available on `Vector128<T>`, `Vector256<T>`, `Vector512<T>`, `Vector64<T>`, and `Vector<T>`. They're building blocks for image processing, audio digital signal processing (DSP), and other SIMD-intensive workloads that need fine-grained control over vector element layout.

## See also

- [What's new in .NET libraries for .NET 11](libraries.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
