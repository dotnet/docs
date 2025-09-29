---
title: "Breaking change: YMM embedded rounding removed from AVX10.2"
description: Learn about the .NET 10 breaking change in core .NET libraries where support for YMM embedded rounding was removed from AVX10.2.
ms.date: 06/06/2025
---

# YMM embedded rounding removed from AVX10.2

Support for YMM embedded rounding has been removed from the <xref:System.Runtime.Intrinsics.X86.Avx10v2> type.

## Previous behavior

In previous .NET 10 Preview versions, the [affected APIs](#affected-apis) in <xref:System.Runtime.Intrinsics.X86.Avx10v2> were available.

## New behavior

Starting in Preview 5, the [affected APIs](#affected-apis) in <xref:System.Runtime.Intrinsics.X86.Avx10v2> are removed and no longer available.

## Version introduced

.NET 10 Preview 5

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Intel pivoted direction and now requires that AVX10.2 also implement AVX512. Since ZMM embedded rounding is always available, the YMM embedded rounding feature isn't necessary.

## Recommended action

Because the hardware isn't yet available, no users should be affected by this change.

## Affected APIs

- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToSByteWithSaturationAndZeroExtendToInt32`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToByteWithSaturationAndZeroExtendToInt32`
- `System.Runtime.Intrinsics.X86.Avx10v2.Add`
- `System.Runtime.Intrinsics.X86.Avx10v2.Divide`
- `System.Runtime.Intrinsics.X86.Avx10v2.Multiply`
- `System.Runtime.Intrinsics.X86.Avx10v2.Scale`
- `System.Runtime.Intrinsics.X86.Avx10v2.Sqrt`
- `System.Runtime.Intrinsics.X86.Avx10v2.Subtract`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector128Int32`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector128Single`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector128UInt32`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256Double`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256Int32`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256Int64`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256Single`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256UInt32`
- `System.Runtime.Intrinsics.X86.Avx10v2.ConvertToVector256UInt64`
