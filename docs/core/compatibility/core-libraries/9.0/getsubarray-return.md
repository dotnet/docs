---
title: "Breaking change: RuntimeHelpers.GetSubArray returns different type"
description: Learn about the .NET 9 breaking change in core .NET libraries where the type of array instance returned by RuntimeHelpers.GetSubArray matches the source array.
ms.date: 01/18/2024
ms.topic: concept-article
---
# RuntimeHelpers.GetSubArray returns different type

The type of array instance returned by <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray%60%601(%60%600[],System.Range)?displayProperty=nameWithType> has changed to match the source array. `RuntimeHelpers.GetSubArray` is used by C# compiler to implement [range operator](../../../../csharp/language-reference/operators/member-access-operators.md#range-operator-) for arrays.

This behavior change can be observed only by code that uses covariant array conversions.

## Previous behavior

Previously, `RuntimeHelpers.GetSubArray<T>(T[] array, Range range)` returned an array instance of type `T[]`.

For example, the type of array instance returned by `RuntimeHelpers.GetSubArray<object>(new string[1], ...)` was `object[]`.

## New behavior

Starting in .NET 9, `RuntimeHelpers.GetSubArray<T>(T[] array, Range range)` returns an array instance of the same type as the `array` parameter.

For example, the type of array instance returned by `RuntimeHelpers.GetSubArray<object>(new string[1], ...)` is `string[]`.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The design of C# pattern-matching features assumes that the type of array instance returned by <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray%60%601(%60%600[],System.Range)?displayProperty=nameWithType> matches the source array. The previous behavior led to unexpected behavior of certain complex pattern expressions that used slicing of covariant arrays. For more information, see [dotnet/roslyn#69053](https://github.com/dotnet/roslyn/issues/69053).

## Recommended action

The recommended action is to remove dependency of the affected code on array covariance.

For example, change:

```csharp
object[] arr = new string[1];
M(arr[1..2]);
```

to:

```csharp
string[] arr = new string[1];
M(arr[1..2]);
```

## Affected APIs

- <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray%60%601(%60%600[],System.Range)?displayProperty=fullName>
