---
title: "Breaking change: Minimum hardware requirements updated"
description: "Learn about the breaking change in .NET 11 where minimum hardware requirements have been updated for x86/x64 and Arm64 architectures."
ms.date: 01/09/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48045
---

# Minimum hardware requirements updated

The minimum hardware requirements for .NET 11 have been updated to require more modern instruction sets on both x86/x64 and Arm64 architectures. Additionally, the ReadyToRun (R2R) compilation targets have been updated to take advantage of newer hardware capabilities.

### Arm64

For Apple, there's no change to the minimum hardware or the `ReadyToRun` target. The `Apple M1` chips are approximately equivalent to `armv8.5-a` and so provide support for at least the `AdvSimd` (NEON), `CRC`, `DOTPROD`, `LSE`, `RCPC`, `RCPC2`, and `RDMA` instruction sets.

For Linux, there's no change to the minimum hardware. .NET continues to support devices such as Raspberry Pi that might only provide support for the `AdvSimd` instruction set. The `ReadyToRun` target has been updated to include the `LSE` instruction set, which might result in additional jitting overhead if you launch an application.

For Windows, the baseline is updated to require the `LSE` instruction set. This is [required by Windows 11](/windows-hardware/design/minimum/minimum-hardware-requirements-overview) and by [all Arm64 CPUs officially supported by Windows 10](/windows-hardware/design/minimum/windows-processor-requirements). Additionally, it's inline with the `Arm SBSA` (Server Base System Architecture) requirements. The `ReadyToRun` target has been updated to be `armv8.2-a + RCPC` (this provides support for at least `AdvSimd`, `CRC`, `LSE`, `RCPC`, and `RDMA`), which covers the majority of hardware officially supported.

| OS      | Previous JIT/AOT minimum | New JIT/AOT minimum | Previous R2R target | New R2R target   |
|---------|--------------------------|---------------------|---------------------|------------------|
| Apple   | Apple M1                 | (No change)         | Apple M1            | (No change)      |
| Linux   | armv8.0-a                | (No change)         | armv8.0-a           | armv8.0-a + LSE  |
| Windows | armv8.0-a                | armv8.0-a + LSE     | armv8.0-a           | armv8.2-a + RCPC |

### x86/x64

For all three operating systems (Apple, Linux, and Windows), the baseline is updated from `x86-64-v1` to `x86-64-v2`. This changes the hardware from only guaranteeing `CMOV`, `CX8`, `SSE`, and `SSE2` to also guaranteeing `CX16`, `POPCNT`, `SSE3`, `SSSE3`, `SSE4.1`, and `SSE4.2`. This guarantee is required by Windows 11 and by all x86/x64 CPUs officially supported on Windows 10. It includes all chips still officially supported by Intel/AMD, with the last older chips having gone out of support around 2013.

The `ReadyToRun` target has been updated to `x86-64-v3` for Windows and Linux, while it remains unchanged for Apple, which additionally includes the `AVX`, `AVX2`, `BMI1`, `BMI2`, `F16C`, `FMA`, `LZCNT`, and `MOVBE` instruction sets.

| OS      | Previous JIT/AOT minimum | New JIT/AOT minimum | Previous R2R target | New R2R target |
|---------|--------------------------|---------------------|---------------------|----------------|
| Apple   | x86-64-v1                | x86-64-v2           | x86-64-v2           | (No change)    |
| Linux   | x86-64-v1                | x86-64-v2           | x86-64-v2           | x86-64-v3      |
| Windows | x86-64-v1                | x86-64-v2           | x86-64-v2           | x86-64-v3      |

## Version introduced

.NET 11 Preview 1

## Previous behavior

By default, .NET successfully launched and ran on older hardware. Individual applications might have opted-in to higher baselines or explicitly used [hardware intrinsics](xref:System.Runtime.Intrinsics) that raised the baseline for their scenario.

## New behavior

Starting with .NET 11, .NET fails to run on older hardware and might print a message similar to the following. (In some scenarios, a more descriptive message might be provided that lists the concrete hardware requirements for a given operating system and architecture.)

> The current CPU is missing one or more of the baseline instruction sets.

For [`ReadyToRun`](../../../deploying/ready-to-run.md)-capable assemblies, there might be additional startup overhead on some supported hardware that doesn't meet the expected support for a typical device.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET supports a broad range of hardware, often above and beyond the minimum hardware requirements put in place by the underlying operating system (OS). .NET also has built-in support for taking advantage of the hardware it's actively running on for JIT scenarios. However, this support adds significant complexity to the codebase, particularly for much older hardware that's unlikely to still be in use. Additionally, it defines a "lowest common denominator" that AOT targets must default to which can, in some domain-specific scenarios, lead to reduced performance for applications.

The update to the minimum baseline was made to reduce the maintenance complexity of the codebase and to better align with the documented (and often enforced) hardware requirements of the underlying OS.

## Recommended action

If you're using hardware that's no longer supported, consider updating. Such hardware is officially out of support and might not boot on operating system versions that are supported by .NET.

## Affected APIs

This change affects all of .NET.

## See also

- [Hardware intrinsics](xref:System.Runtime.Intrinsics)
- [ReadyToRun deployment](../../../deploying/ready-to-run.md)
