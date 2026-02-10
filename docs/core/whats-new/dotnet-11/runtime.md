---
title: What's new in .NET 11 runtime
description: Learn about the new features introduced in the .NET 11 runtime.
titleSuffix: ""
ms.date: 02/10/2026
ai-usage: ai-generated
---

# What's new in the .NET 11 runtime

This article describes new features in the .NET runtime for .NET 11 Preview 1.

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

## See also

- [What's new in .NET libraries for .NET 11](libraries.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
