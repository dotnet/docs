---
title: "Breaking change: BigInteger maximum length"
description: Learn about the .NET 9 breaking change in core .NET libraries where a maximum length for BigInteger is enforced.
ms.date: 08/06/2024
ms.topic: concept-article
---
# BigInteger maximum length

.NET 9 enforces a maximum length of <xref:System.Numerics.BigInteger>, which is that it can contain no more than `(2^31) - 1` (approximately 2.14 billion) bits. Such a number represents an almost 256 MB allocation and contains approximately 646.5 million digits. This new limit ensures that all APIs exposed are well behaved and consistent while still allowing numbers that are far beyond most usage scenarios.

## Previous behavior

Previously, you could assign a value with a length up to `Array.MaxLength * 32` bits to a <xref:System.Numerics.BigInteger> variable.

> [!NOTE]
> Typical machines would hit an <xref:System.OutOfMemoryException> far before this limit could ever be reached.

## New behavior

Starting in .NET 9, <xref:System.Numerics.BigInteger> has a maximum length of `(2^31) - 1` (approximately 2.14 billion) bits. If you attempt to assign a larger value, an <xref:System.OverflowException> is thrown at run time. For example, the following code throws an exception:

```csharp
BigInteger bigInt = new BigInteger(-1) << int.MaxValue;
```

## Version introduced

.NET 9 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

<xref:System.Numerics.BigInteger> supports representing integer values of essentially arbitrary length. However, in practice, the length is constrained by limits of the underlying computer, such as available memory or how long it would take to compute a given expression. Additionally, there exist some APIs that fail given inputs that result in a value that's too large. For these reasons, a maximum length is now enforced.

## Recommended action

If your code is affected, decrease the length of value you're assigning to <xref:System.Numerics.BigInteger> or add a length check.

## Affected APIs

- <xref:System.Numerics.BigInteger>
