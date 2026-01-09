---
title: "Breaking change: Minimum hardware requirements updated"
description: "Learn about the breaking change in .NET 11 where minimum hardware requirements have been updated for x86/x64 and Arm64 architectures."
ms.date: 01/09/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/50793
---

# Minimum hardware requirements updated

The minimum hardware requirements for .NET 11 have been updated to require more modern instruction sets on both x86/x64 and Arm64 architectures. Additionally, the ReadyToRun (R2R) compilation targets have been updated to take advantage of newer hardware capabilities.

## Version introduced

.NET 11 Preview 1

## Previous behavior

By default, .NET would successfully launch and run on older hardware. The baseline instruction sets were:

### Arm64

- **Apple**: Apple M1 (approximately armv8.5-a with AdvSimd, CRC, DOTPROD, LSE, RCPC, RCPC2, and RDMA)
- **Linux**: armv8.0-a (basic AdvSimd support)
- **Windows**: armv8.0-a

### x86/x64

- **All platforms**: x86-64-v1 (CMOV, CX8, SSE, SSE2)

Individual applications could opt in to higher baselines or explicitly use [hardware intrinsics](xref:System.Runtime.Intrinsics) that raised the baseline for their scenario.

## New behavior

.NET will fail to run on older hardware that doesn't meet the new minimum requirements and may print a message similar to the following:

> The current CPU is missing one or more of the baseline instruction sets.

A more descriptive message may be provided in some scenarios that lists the concrete hardware requirements for a given operating system and architecture.

The updated minimum requirements are:

### Arm64

| Operating System | JIT/AOT Minimum | R2R Target      |
| ---------------- | --------------- | --------------- |
| Apple            | Apple M1        | Apple M1        |
| Linux            | armv8.0-a       | armv8.0-a + LSE |
| Windows          | armv8.0-a + LSE | armv8.2-a + RCPC |

### x86/x64

| Operating System | JIT/AOT Minimum | R2R Target    |
| ---------------- | --------------- | ------------- |
| Apple            | x86-64-v2       | x86-64-v2     |
| Linux            | x86-64-v2       | x86-64-v3     |
| Windows          | x86-64-v2       | x86-64-v3     |

The **x86-64-v2** baseline adds support for CX16, POPCNT, SSE3, SSSE3, SSE4.1, and SSE4.2 instruction sets.

The **x86-64-v3** baseline adds support for AVX, AVX2, BMI1, BMI2, F16C, FMA, LZCNT, and MOVBE instruction sets.

For ReadyToRun capable assemblies, there may be additional startup overhead on some hardware that is supported but doesn't meet the expected support for a typical device.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET supports a broad range of hardware, often beyond the minimum hardware requirements put in place by the underlying operating system. However, this support adds significant complexity to the codebase, particularly for older hardware that is unlikely to still be in use. Additionally, it defines a "lowest common denominator" that AOT targets must default to, which can lead to reduced performance in some scenarios.

The update to the minimum baseline was made to:

- Reduce the maintenance complexity of the codebase
- Better align with the documented (and often enforced) hardware requirements of the underlying operating system
- Improve performance by allowing the runtime to assume support for modern instruction sets

### Arm64 details

- **Apple**: No change. The Apple M1 chips are approximately equivalent to armv8.5-a and provide support for at least the AdvSimd (NEON), CRC, DOTPROD, LSE, RCPC, RCPC2, and RDMA instruction sets.

- **Linux**: No change to the minimum hardware. Devices such as Raspberry Pi that may only provide support for the AdvSimd instruction set continue to be supported. The ReadyToRun target has been updated to include the LSE instruction set, which may result in additional jitting overhead if you launch an application on older hardware.

- **Windows**: The baseline is updated to require the LSE instruction set. This is required by [Windows 11](https://learn.microsoft.com/windows-hardware/design/minimum/minimum-hardware-requirements-overview) and by all Arm64 CPUs officially supported by [Windows 10](https://learn.microsoft.com/windows-hardware/design/minimum/windows-processor-requirements). It's also inline with the Arm SBSA (Server Base System Architecture) requirements. The ReadyToRun target has been updated to be armv8.2-a + RCPC (this provides support for at least AdvSimd, CRC, LSE, RCPC, and RDMA), which covers the majority of hardware officially supported.

### x86/x64 details

For all three operating systems, the baseline is updated from x86-64-v1 to x86-64-v2. This changes the hardware from only guaranteeing CMOV, CX8, SSE, and SSE2 to also guaranteeing CX16, POPCNT, SSE3, SSSE3, SSE4.1, and SSE4.2. This is required by Windows 11 and by all x86/x64 CPUs officially supported on Windows 10. It includes all chips still officially supported by Intel and AMD, with the last older chips having gone out of support around 2013.

The ReadyToRun target has been updated to x86-64-v3 for Windows and Linux, which additionally includes the AVX, AVX2, BMI1, BMI2, F16C, FMA, LZCNT, and MOVBE instruction sets. The ReadyToRun target remains unchanged for Apple at x86-64-v2.

## Recommended action

Developers on no longer supported hardware should consider updating. Such hardware is officially out of support and may not boot on operating system versions that are supported by .NET.

If you're running .NET on hardware that doesn't meet these requirements:

- Upgrade to newer hardware that meets the minimum requirements
- If upgrading isn't possible, consider using an earlier version of .NET that supports your hardware

## Affected APIs

This affects all of .NET. All applications running on .NET 11 must meet the new minimum hardware requirements.

## See also

- [Hardware intrinsics](xref:System.Runtime.Intrinsics)
- [ReadyToRun deployment](/dotnet/core/deploying/ready-to-run)
