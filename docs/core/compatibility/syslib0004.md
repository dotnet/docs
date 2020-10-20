---
title: SYSLIB0004 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0004.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0004: The constrained execution region (CER) feature is not supported

The [Constrained execution regions (CER)](../../framework/performance/constrained-execution-regions.md) feature is supported only in .NET Framework. As such, various CER-related APIs are marked obsolete, starting in .NET 5.0. Using these APIs generates warning `SYSLIB0004` at compile time.

The following CER-related APIs are obsolete:

- <xref:System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(System.Runtime.CompilerServices.RuntimeHelpers.TryCode,System.Runtime.CompilerServices.RuntimeHelpers.CleanupCode,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions?displayProperty=nameWithType>
- <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegionsNoOP?displayProperty=nameWithType>
- <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareContractedDelegate(System.Delegate)?displayProperty=nameWithType>
- <xref:System.Runtime.CompilerServices.RuntimeHelpers.ProbeForSufficientStack?displayProperty=nameWithType>
- <xref:System.Runtime.ConstrainedExecution.Cer?displayProperty=nameWithType>
- <xref:System.Runtime.ConstrainedExecution.Consistency?displayProperty=nameWithType>
- <xref:System.Runtime.ConstrainedExecution.PrePrepareMethodAttribute?displayProperty=nameWithType>
- <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute?displayProperty=nameWithType>

## See also

- [Constrained execution regions](../../framework/performance/constrained-execution-regions.md)
