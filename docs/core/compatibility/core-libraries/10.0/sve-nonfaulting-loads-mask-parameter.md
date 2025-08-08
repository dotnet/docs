---
title: "Breaking change: Arm64 SVE NonFaulting loads require mask parameter"
description: "Learn about the breaking change in .NET 10 where Arm64 SVE NonFaulting load APIs now require a mask parameter as the first argument."
ms.date: 01/31/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47439
---

# Arm64 SVE NonFaulting loads require mask parameter

All Arm64 SVE NonFaulting load APIs have been updated to include a `mask` argument as the first position. This affects all methods with "NonFaulting" in their name in the <xref:System.Runtime.Intrinsics.Arm.Sve?displayProperty=fullName> class.

## Version introduced

.NET 10

## Previous behavior

NonFaulting load APIs took only an address parameter and would load a full vector:

```csharp
// .NET 9 behavior
Vector<short> result = Sve.LoadVectorByteNonFaultingZeroExtendToInt16(address);

// To do masked loading, you had to use ConditionalSelect
Vector<short> maskedResult = Sve.ConditionalSelect(mask, 
    Sve.LoadVectorByteNonFaultingZeroExtendToInt16(address), 
    zero);
```

## New behavior

NonFaulting load APIs now require a mask parameter as the first argument:

```csharp
// .NET 10 behavior - mask parameter required
Vector<short> result = Sve.LoadVectorByteNonFaultingZeroExtendToInt16(
    Sve.CreateTrueMaskInt16(), address);

// Masked loading is now done directly
Vector<short> maskedResult = Sve.LoadVectorByteNonFaultingZeroExtendToInt16(
    mask, address);
```

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was necessary because a non-faulting load updates the FFR (First Fault Register) depending on which vector lanes are loaded. The standard conversion of `ConditionalSelect(mask, LoadVectorNonFaulting(addr), zero)` to a masked load cannot be used because it doesn't properly handle the FFR register state. Therefore, the only valid way to implement a masked non-faulting load is by exposing it as a dedicated API with a mask parameter.

## Recommended action

- For existing uses of `Sve.ConditionalSelect(mask, Sve.LoadVector*NonFaulting*(addr), zero)`, replace them with `Sve.LoadVector*NonFaulting*(mask, addr)`.
- For other uses of non-faulting loads that should load all elements, update them to include a true mask: `Sve.LoadVector*NonFaulting*(Sve.CreateTrueMask*(), addr)`.

## Affected APIs

- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt16%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt16%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToUInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToUInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt32NonFaultingSignExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt32NonFaultingSignExtendToUInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorNonFaulting%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt16%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt16%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToUInt32%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToUInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt32NonFaultingZeroExtendToInt64%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt32NonFaultingZeroExtendToUInt64%2A?displayProperty=fullName>
