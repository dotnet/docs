---
title: "Breaking change: Floating-point conversions to small integral types are saturating"
description: "Learn about the breaking change in .NET 11 where unchecked floating-point conversions to small integral types saturate at the destination type's bounds."
ms.date: 09/10/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/runtime/pull/128604
---

# Floating-point conversions to small integral types are saturating

In .NET 11, unchecked floating-point conversions to `sbyte`, `byte`, `short`, `ushort`, and `char` now have *saturating* behavior at the destination type's bounds. Values that are too small or too large are set to the destination type's minimum or maximum value, respectively.

This change continues the [.NET 9 change to floating point-to-integer conversions](../9.0/fp-to-integer.md), which standardized conversions from `float` and `double` to `int`, `uint`, `long`, and `ulong`. .NET 11 extends saturation to 8- and 16-bit destinations.

The change applies to CoreCLR, including its interpreter, and Native AOT. Mono is not included in this change.

For more information, see [dotnet/runtime#128604](https://github.com/dotnet/runtime/pull/128604).

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, .NET did not guarantee the result of an unchecked floating-point to integral conversion when the value overflowed the destination type or was `NaN`. Results could differ between runtime implementations, such as CoreCLR and Mono, between architectures, such as x86, x64, Arm32, Arm64, and WebAssembly, and between hardware instruction sets within an architecture, such as x87, SSE2, AVX, and AVX-512.

The .NET 9 breaking change specifically highlighted x86 and x64, where conversions commonly returned sentinel values on overflow. Arm64 already used saturating conversions by convention. The change standardized conversions to the wider integer types rather than establishing the old sentinel results as a contract.

For small integral types, a common CoreCLR conversion sequence in .NET 9 and .NET 10 was a saturating conversion to `int`, followed by narrowing to the destination type by discarding the high bits. This sequence explains the behavior many applications experienced, but it was not a guaranteed contract for a direct floating-point to small-integral cast.

The following table shows results from that two-step sequence for a runtime `float` or `double` value `x`. These inputs fit in `int`, so the examples isolate the effect of discarding all but the destination's low 8 or 16 bits. The retained bits are interpreted as signed for `sbyte` and `short`, and unsigned for `byte`, `ushort`, and `char`. Results for `char` are shown numerically.

| Convert to | Value of `x` | Retained low bits | Example previous result |
| --- | --- | --- | --- |
| `sbyte` or `byte` | 298 | `0x2A` | 42 |
| `sbyte` | -298 | `0xD6` | -42 |
| `byte` | -42 | `0xD6` | 214 |
| `short`, `ushort`, or `char` | 65578 | `0x002A` | 42 |
| `short` | -65578 | `0xFFD6` | -42 |
| `ushort` or `char` | -42 | `0xFFD6` | 65494 |

For example, the following code could return `42`:

```csharp
static short ConvertValue(double value)
{
    return unchecked((short)value);
}

short result = ConvertValue(65578.0);
```

The intermediate `int` is `65578` (`0x0001002A`). With only its low 16 bits retained, the result is `42` (`0x002A`), rather than saturation to `short.MaxValue`.

## New behavior

Starting in .NET 11, unchecked conversions saturate at the destination type's bounds. Finite values within the destination range continue to be rounded toward zero. `NaN` converts to zero.

| Convert to | Below minimum, including negative infinity | Above maximum, including positive infinity | `NaN` |
| --- | --- | --- | --- |
| `sbyte` | -128 (`sbyte.MinValue`) | 127 (`sbyte.MaxValue`) | 0 |
| `byte` | 0 (`byte.MinValue`) | 255 (`byte.MaxValue`) | 0 |
| `short` | -32768 (`short.MinValue`) | 32767 (`short.MaxValue`) | 0 |
| `ushort` | 0 (`ushort.MinValue`) | 65535 (`ushort.MaxValue`) | 0 |
| `char` | 0 (`char.MinValue`) | 65535 (`char.MaxValue`) | 0 |

The preceding example now returns `32767` (`short.MaxValue`) instead of `42`. Similarly, a conversion from `298` to `byte` now returns `255` instead of `42`, and a conversion from `-42` to `ushort` now returns `0` instead of `65494`.

Because they convert through `float`, the corresponding unchecked conversions from <xref:System.Half> also use the new behavior. <xref:System.Single.ConvertToInteger``1(System.Single)> and <xref:System.Double.ConvertToInteger``1(System.Double)> now correctly saturate for these small destination types.

Checked conversions are unchanged and continue to throw <xref:System.OverflowException> when the conversion overflows. This change does not alter integer-to-integer narrowing conversions or the wider integer and vector conversions covered by the .NET 9 change.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The [.NET 9 change](../9.0/fp-to-integer.md) established saturating behavior for conversions to wider integer types, but conversions to 8-bit and 16-bit destinations still had hardware-dependent and implementation-dependent behavior for out-of-range values and `NaN`. This change gives those conversions deterministic, saturating behavior and makes the JIT, CoreCLR interpreter, and Native AOT preinitialized values agree.

## Recommended action

If your code relies on previous results for out-of-range inputs, update it to expect saturation at the destination type's bounds where possible.

If you need the platform-native behavior commonly used before these changes, the simplest workaround is <xref:System.Single.ConvertToIntegerNative``1(System.Single)> or <xref:System.Double.ConvertToIntegerNative``1(System.Double)>. For example, replace a direct `(ushort)x` cast with `double.ConvertToIntegerNative<ushort>(x)` when `x` is a `double`, or `float.ConvertToIntegerNative<ushort>(x)` when it is a `float`.

You can also select the intermediate conversion explicitly. The following examples use a `double` input `x` and a `ushort` destination:

| Required behavior | Conversion |
| --- | --- |
| Platform-native conversion to the destination type, which commonly recovers earlier behavior | `double.ConvertToIntegerNative<ushort>(x)` |
| Saturation to `int`, then narrowing, matching the common .NET 9 and .NET 10 CoreCLR sequence | `unchecked((ushort)(int)x)` |
| Platform-native conversion to `int`, then narrowing, matching a common pre-.NET 9 sequence | `unchecked((ushort)double.ConvertToIntegerNative<int>(x))` |

Use `float.ConvertToIntegerNative` for `float` inputs and substitute the appropriate destination type for `sbyte`, `byte`, `short`, or `char`.

As with the .NET 9 change, `ConvertToIntegerNative` is **not guaranteed to reproduce previous results** for out-of-range values or `NaN`. It selects behavior that is efficient for the current platform, which can change across runtimes, architectures, or hardware revisions. An explicit `(ushort)(int)x` instead selects a saturating conversion to `int` followed by integer narrowing; it does not restore every historical implementation's behavior.

If the converted value is used as an array index, buffer offset, or length, validate that the resulting value is within the required bounds. A conversion that produces a usable value on one machine does not establish that platform-native conversion will do so on another.

## Affected APIs

- Unchecked explicit casts from <xref:System.Single> or <xref:System.Double> to <xref:System.SByte>, <xref:System.Byte>, <xref:System.Int16>, <xref:System.UInt16>, or <xref:System.Char>.
- <xref:System.Half> unchecked explicit conversion operators:
  - <xref:System.Half.op_Explicit(System.Half)~System.SByte>
  - <xref:System.Half.op_Explicit(System.Half)~System.Byte>
  - <xref:System.Half.op_Explicit(System.Half)~System.Int16>
  - <xref:System.Half.op_Explicit(System.Half)~System.UInt16>
  - <xref:System.Half.op_Explicit(System.Half)~System.Char>
- <xref:System.Single.ConvertToInteger``1(System.Single)> when `TInteger` is <xref:System.SByte>, <xref:System.Byte>, <xref:System.Int16>, <xref:System.UInt16>, or <xref:System.Char>.
- <xref:System.Double.ConvertToInteger``1(System.Double)> when `TInteger` is <xref:System.SByte>, <xref:System.Byte>, <xref:System.Int16>, <xref:System.UInt16>, or <xref:System.Char>.
