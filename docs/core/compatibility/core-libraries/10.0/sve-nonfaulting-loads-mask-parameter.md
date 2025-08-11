---
title: "Breaking change: Arm64 SVE nonfaulting loads require mask parameter"
description: "Learn about the breaking change in .NET 10 where Arm64 SVE nonfaulting load APIs now require a mask parameter as the first argument."
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47439
---

# Arm64 SVE nonfaulting loads require mask parameter

All Arm64 SVE nonfaulting load APIs have been updated to include a `mask` parameter in the first position. This change affects all methods with `LoadVector*NonFaulting` in their name in the <xref:System.Runtime.Intrinsics.Arm.Sve?displayProperty=fullName> class.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, nonfaulting load APIs took only an address parameter and loaded a full vector:

```csharp
Vector<short> result = Sve.LoadVectorByteNonFaultingZeroExtendToInt16(address);
```

To do nonfaulting load with masked-out elements, you had to use <xref:System.Runtime.Intrinsics.Arm.Sve.ConditionalSelect*>:

```csharp
Vector<short> maskedResult = Sve.ConditionalSelect(
    mask,
    Sve.LoadVectorByteNonFaultingZeroExtendToInt16(address),
    zero);
```

## New behavior

Starting in .NET 10, nonfaulting load APIs now require a mask parameter as the first argument.

To do a nonfaulting load for all elements, use code similar to the following: `Sve.LoadVector*NonFaulting*(Sve.CreateTrueMask*(), addr);`

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was necessary because a nonfaulting load updates the first fault register (FFR) depending on which vector lanes are loaded. The standard conversion of `ConditionalSelect(mask, LoadVectorNonFaulting(addr), zero)` to a masked load can't be used because it doesn't properly handle the FFR register state. Therefore, the only valid way to implement a masked nonfaulting load is by exposing it as a dedicated API.

## Recommended action

- For existing uses of `Sve.ConditionalSelect(mask, Sve.LoadVector*NonFaulting*(addr), zero)`, replace them with `Sve.LoadVector*NonFaulting*(mask, addr)`.
- Update other uses of nonfaulting loads to include a true mask: `Sve.LoadVector*NonFaulting*(Sve.CreateTrueMask*(), addr)`.

## Affected APIs

- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt16(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt32(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToInt64(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt16(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt32(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorByteNonFaultingZeroExtendToUInt64(System.Byte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToInt32(System.Int16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToInt64(System.Int16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToUInt32(System.Int16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt16NonFaultingSignExtendToUInt64(System.Int16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt32NonFaultingSignExtendToInt64(System.Int32*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorInt32NonFaultingSignExtendToUInt64(System.Int32*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorNonFaulting%2A?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt16(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt32(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToInt64(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt16(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt32(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorSByteNonFaultingSignExtendToUInt64(System.SByte*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToInt32(System.UInt16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToInt64(System.UInt16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToUInt32(System.UInt16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt16NonFaultingZeroExtendToUInt64(System.UInt16*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt32NonFaultingZeroExtendToInt64(System.UInt32*)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.Sve.LoadVectorUInt32NonFaultingZeroExtendToUInt64(System.UInt32*)?displayProperty=fullName>
