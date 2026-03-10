---
title: What's new in .NET 11 runtime
description: Learn about the new features introduced in the .NET 11 runtime.
titleSuffix: ""
ms.date: 03/10/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the .NET 11 runtime

This article describes new features in the .NET runtime for .NET 11. It was last updated for Preview 2.

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

Runtime Async is still a preview feature in .NET 11 Preview 2. To opt in, add the following properties to your project file:

```xml
<PropertyGroup>
  <Features>runtime-async=on</Features>
  <EnablePreviewFeatures>true</EnablePreviewFeatures>
</PropertyGroup>
```

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

This improvement benefits profiling tools, diagnostic logging, and the debugger call stack window—anything that inspects the live execution stack.

### Debugging improvements

Breakpoints now bind correctly inside runtime-async methods, and the debugger can step through `await` boundaries without jumping into compiler-generated infrastructure.

## JIT improvements

### Bounds check elimination

The just-in-time (JIT) compiler now eliminates bounds checks for the common pattern where an index plus a constant is compared against a length, such as `i + cns < len`. This reduces redundant checks in tight loops and improves throughput for array and span operations.

### Redundant checked context removal

The JIT can now prove and remove redundant checked arithmetic contexts—for example, when a value is already known to be in range. This optimization eliminates unnecessary overflow checks in generated code.

### Devirtualization in ReadyToRun images

ReadyToRun (R2R) images can now devirtualize non-shared generic virtual method calls, improving performance of ahead-of-time compiled code for generic scenarios.

### SVE2 intrinsics

New Arm SVE2 (Scalable Vector Extension 2) intrinsics are available: `ShiftRightLogicalNarrowingSaturate(Even|Odd)`. These expand the set of vectorized operations available on Arm hardware that supports SVE2.

## VM improvements

### Cached interface dispatch on non-JIT platforms

On platforms that lack JIT support—such as iOS—interface dispatch was falling back to an expensive generic fixup path. Enabling cached dispatch by default yields up to 200x improvements in interface-heavy code on these targets.

### Guid.NewGuid() on Linux

<xref:System.Guid.NewGuid?displayProperty=nameWithType> on Linux now uses the `getrandom()` syscall with batch caching instead of reading from `/dev/urandom`, yielding approximately 12% throughput improvement for GUID generation.

## See also

- [What's new in .NET libraries for .NET 11](libraries.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
