---
title: "Breaking change: Some SVE APIs removed"
description: Learn about the breaking change in .NET 9 where some SVE APIs that take 32-bit address have been removed.
ms.date: 10/02/2024
---
# Some SVE APIs removed

Several APIs that take a 32-bit address as an input parameter have been removed because of lack of testing with such addresses. These APIs might be re-enabled in the future when relevant test coverage is added.

## Previous behavior

In previous versions, these APIs were available.

## New behavior

Starting in .NET 9, these APIs aren't available.

## Version introduced

.NET 9 RC 2

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The affected APIs were removed because of lack of testing of 32-bit addresses. The affected APIs might be re-enabled in the future when relevant test coverage is added.

## Recommended action

Stop using the removed APIs and instead use the overloads that take 64-bit addresses as input.

## Affected APIs

- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch16Bit(System.Numerics.Vector{System.Int16},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch16Bit(System.Numerics.Vector{System.UInt16},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch32Bit(System.Numerics.Vector{System.Int32},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch32Bit(System.Numerics.Vector{System.UInt32},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch64Bit(System.Numerics.Vector{System.UInt64},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch64Bit(System.Numerics.Vector{System.UInt64},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch8Bit(System.Numerics.Vector{System.Byte},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherPrefetch8Bit(System.Numerics.Vector{System.SByte},System.Numerics.Vector{System.UInt32},System.Runtime.Intrinsics.Arm.SvePrefetchType)
- System.Runtime.Intrinsics.Arm.Sve.GatherVectorInt16SignExtendFirstFaulting(System.Numerics.Vector{System.Int32},System.Numerics.Vector{System.UInt32})
- System.Runtime.Intrinsics.Arm.Sve.GatherVectorInt16SignExtendFirstFaulting(System.Numerics.Vector{System.UInt32},System.Numerics.Vector{System.UInt32})
- System.Runtime.Intrinsics.Arm.Sve.GatherVectorSByteSignExtendFirstFaulting(System.Numerics.Vector{System.Int32},System.Numerics.Vector{System.UInt32})
- System.Runtime.Intrinsics.Arm.Sve.GatherVectorSByteSignExtendFirstFaulting(System.Numerics.Vector{System.UInt32},System.Numerics.Vector{System.UInt32})
