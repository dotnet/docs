---
title: "Breaking change: Maximum precision for numeric format strings"
description: Learn about the .NET 7 breaking change in core .NET libraries where the maximum precision for numeric format strings was changed to 999,999,999.
ms.date: 09/02/2022
---
# Maximum precision for numeric format strings

The maximum precision when formatting numbers as strings using `ToString` and `TryFormat` has been changed from <xref:System.Int32.MaxValue?displayProperty=nameWithType> to 999,999,999. (The maximum precision was [previously changed](../6.0/numeric-format-parsing-handles-higher-precision.md) to <xref:System.Int32.MaxValue?displayProperty=nameWithType> in .NET 6.)

In addition, the maximum exponent allowed when parsing a <xref:System.Numerics.BigInteger> from a string has been limited to 999,999,999.

## Previous behavior

In .NET 6, the standard numeric format parsing logic was limited to a precision of <xref:System.Int32.MaxValue?displayProperty=nameWithType> or less. The intended behavior was to throw a <xref:System.FormatException> for any precision larger than <xref:System.Int32.MaxValue?displayProperty=nameWithType>. However, due to a bug, .NET 6 didn't throw that exception for some such inputs. The intended behavior was:

```csharp
double d = 123.0;

d.ToString("E" + int.MaxValue.ToString()); // Doesn't throw.

long intMaxPlus1 = (long)int.MaxValue + 1;
string intMaxPlus1String = intMaxPlus1.ToString();
Assert.Throws<FormatException>(() => d.ToString("E" + intMaxPlus1String)); // Throws.
```

In addition, there was no limit on the exponent size when parsing a <xref:System.Numerics.BigInteger> from a string.

## New behavior

Starting in .NET 7, .NET supports precision up to 999,999,999. A <xref:System.FormatException> is thrown if the precision is greater than 999,999,999. This change was implemented in the parsing logic that affects all numeric types.

```csharp
double d = 123.0;
Assert.Throws<FormatException>(() => d.ToString("E" + int.MaxValue.ToString())); // Throws.

long intMaxPlus1 = (long)int.MaxValue + 1;
string intMaxPlus1String = intMaxPlus1.ToString();
Assert.Throws<FormatException>(() => d.ToString("E" + intMaxPlus1String)); // Throws.

d.ToString("E999999999"); // Doesn't throw.

d.ToString("E00000999999999"); // Doesn't throw.
```

In addition, if you attempt to parse a <xref:System.Numerics.BigInteger> with an exponent greater than 999,999,999 from a string, a <xref:System.FormatException> is thrown.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The behavior that was introduced in .NET 6 was intended to throw a <xref:System.FormatException> for any precision larger than <xref:System.Int32.MaxValue?displayProperty=nameWithType>. However, due to a bug, it did not throw that exception for some inputs larger than the maximum. This change fixes the bug by limiting the precision to 999,999,999.

## Recommended action

In most cases, no action is necessary, because it's unlikely that you're already using a precision higher than 999,999,999 in your format strings.

## Affected APIs

This change was implemented in the parsing logic that affects all numeric types.

- <xref:System.Numerics.BigInteger.ToString(System.String)?displayProperty=fullName>
- <xref:System.Numerics.BigInteger.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Numerics.BigInteger.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Int32.ToString(System.String)?displayProperty=fullName>
- <xref:System.Int32.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Int32.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt32.ToString(System.String)?displayProperty=fullName>
- <xref:System.UInt32.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt32.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Byte.ToString(System.String)?displayProperty=fullName>
- <xref:System.Byte.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Byte.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.SByte.ToString(System.String)?displayProperty=fullName>
- <xref:System.SByte.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.SByte.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Int16.ToString(System.String)?displayProperty=fullName>
- <xref:System.Int16.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Int16.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt16.ToString(System.String)?displayProperty=fullName>
- <xref:System.UInt16.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt16.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Numerics.BigInteger.Parse%2A?displayProperty=fullName>
- <xref:System.Numerics.BigInteger.TryParse%2A?displayProperty=fullName>
- <xref:System.Int64.ToString(System.String)?displayProperty=fullName>
- <xref:System.Int64.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Int64.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt64.ToString(System.String)?displayProperty=fullName>
- <xref:System.UInt64.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.UInt64.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Half.ToString(System.String)?displayProperty=fullName>
- <xref:System.Half.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Half.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Single.ToString(System.String)?displayProperty=fullName>
- <xref:System.Single.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Single.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Double.ToString(System.String)?displayProperty=fullName>
- <xref:System.Double.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Double.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Decimal.ToString(System.String)?displayProperty=fullName>
- <xref:System.Decimal.ToString(System.String,System.IFormatProvider)?displayProperty=fullName>
- <xref:System.Decimal.TryFormat(System.Span{System.Char},System.Int32@,System.ReadOnlySpan{System.Char},System.IFormatProvider)?displayProperty=fullName>

## See also

- [Standard numeric format parsing precision breaking change (.NET 6)](../6.0/numeric-format-parsing-handles-higher-precision.md)
- [Standard numeric format strings](../../../../standard/base-types/standard-numeric-format-strings.md)
- [Character literals in custom format strings](../../../../standard/base-types/custom-numeric-format-strings.md#character-literals)
