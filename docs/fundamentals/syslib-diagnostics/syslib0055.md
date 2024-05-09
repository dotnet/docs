---
title: SYSLIB0055 warning - AdvSimd.ShiftRightLogicalRoundedNarrowingSaturate\* methods with signed parameters are obsolete
description: Learn about the obsoletion of AdvSimd.ShiftRightLogicalRoundedNarrowingSaturate\* methods with signed parameters that generates compile-time warning SYSLIB0055.
ms.date: 05/09/2024
f1_keywords:
  - syslib0055
---
# SYSLIB0055: AdvSimd.ShiftRightLogicalRoundedNarrowingSaturate\* methods with signed parameters are obsolete

The following methods that accept signed integers are obsolete, starting in .NET 9:

- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int64},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int16},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int32},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int16},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int64},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int32},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.SByte},System.Runtime.Intrinsics.Vector128{System.Int16},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.Int16},System.Runtime.Intrinsics.Vector128{System.Int32},System.Byte)?displayProperty=nameWithType>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.Int32},System.Runtime.Intrinsics.Vector128{System.Int64},System.Byte)?displayProperty=nameWithType>

Calling them in code generates warning `SYSLIB0055` at compile time.

## Reason for obsoletion

The Arm Advanced SIMD `UQRSHRN` instruction performs an unsigned saturated narrow operation. As such, its result is always unsigned. However, the affected APIs accepted and returned signed types, meaning they didn't work as expected if you followed the API description rather than the instruction description. In addition, the underlying implementation can't be corrected to perform signed saturated narrow operations and return signed results.

## Workaround

Intentionally convert the data to signed types and call the corresponding unsigned overload instead, for example, <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.UInt32},System.Runtime.Intrinsics.Vector128{System.UInt64},System.Byte)?displayProperty=nameWithType>. Then intentionally convert the result to a signed type.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0055

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0055
```

To suppress all the `SYSLIB0055` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0055</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
