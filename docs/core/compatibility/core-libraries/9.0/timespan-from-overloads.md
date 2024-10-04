---
title: "Breaking change: New TimeSpan.From*() overloads that take integers"
description: Learn about the .NET 9 breaking change in core .NET libraries where new TimeSpan.From*() overloads were introduced that take integer arguments.
ms.date: 10/03/2024
---
# New TimeSpan.From*() overloads that take integers

New `TimeSpan.From*()` overloads that accept integers were introduced in .NET 9. This change can cause ambiguity for the F# compiler and result in compile-time errors.

## Previous behavior

Previously, there was a single overload for each `TimeSpan.From*()` method, namely:

- <xref:System.TimeSpan.FromDays(System.Double)>
- <xref:System.TimeSpan.FromHours(System.Double)>
- <xref:System.TimeSpan.FromMicroseconds(System.Double)>
- <xref:System.TimeSpan.FromMilliseconds(System.Double)>
- <xref:System.TimeSpan.FromMinutes(System.Double)>
- <xref:System.TimeSpan.FromSeconds(System.Double)>

## New behavior

Starting in .NET 9, new overloads have been added that accept integer arguments. Calling a method such as `TimeSpan.FromMinutes(20)` in F# code results in a compile-time error:

> error FS0041: A unique overload for method 'FromMinutes' could not be determined based on type information prior to this program point. A type annotation may be needed. Known type of argument: intCandidates: - TimeSpan.FromMinutes(minutes: int64) : TimeSpan - TimeSpan.FromMinutes(minutes: int64, ?seconds: int64, ?milliseconds: int64, ?microseconds: int64) : TimeSpan - TimeSpan.FromMinutes(value: float) : TimeSpan

## Version introduced

.NET 9 Preview 3

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) for F# code.

## Reason for change

The pre-existing overloads accepted a <xref:System.Double> argument. However, <xref:System.Double> is a binary-based, floating-point format and thus has natural imprecision that can introduce error. This behavior has led to user confusion and bugs in the API surface. It's also one of the less efficient ways to represent this data. To produce the intended behavior, new overloads were introduced that allow users to pass in integers.

## Recommended action

If this change affects your F# code, specify the type of argument so the compiler selects the appropriate overload.

## Affected APIs

- <xref:System.TimeSpan.FromDays*>
- <xref:System.TimeSpan.FromHours*>
- <xref:System.TimeSpan.FromMicroseconds*>
- <xref:System.TimeSpan.FromMilliseconds*>
- <xref:System.TimeSpan.FromMinutes*>
- <xref:System.TimeSpan.FromSeconds*>
