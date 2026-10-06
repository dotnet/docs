---
title: "Iterators"
description: Learn how C# iterator methods produce IEnumerable sequences with yield return and yield break for use with foreach.
ms.date: 10/06/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Iterators

> [!TIP]
> This article teaches synchronous iterators for developers who know methods, loops, and collections. For complete `yield` syntax and restrictions, see the [`yield` statement reference](../../language-reference/statements/yield.md).

An *iterator method* produces a sequence of values one at a time. This article focuses on iterator methods that return <xref:System.Collections.Generic.IEnumerable`1>, whose values callers usually consume with a `foreach` statement.

Use an iterator when the method can describe how to produce a sequence without building the complete result in a collection first. Iterator methods work especially well for filters, generated values, and pipelines where each step handles one element at a time.

## Produce elements with `yield return`

Use `yield return` to provide the next element in the sequence. The following iterator selects acceptable temperature readings from a sensor. In this scenario, `-1` marks the end of the sensor data.

:::code language="csharp" source="snippets/iterators/Program.cs" id="IteratorMethod":::

`SelectTemperatures` returns `IEnumerable<int>`, which represents a sequence of `int` values. Each `yield return reading` provides one value to the `foreach` loop. After the caller handles that value, the iterator continues with the next input.

Use the generic `IEnumerable<T>` form for most modern C# code. The type argument, such as `int`, tells callers which element type the sequence contains.

## End the sequence with `yield break`

Use `yield break` to end an iterator before control reaches the end of the method. In the example, the sentinel value `-1` means that no more readings are available:

```csharp
if (reading == -1)
{
    yield break;
}
```

The iterator also ends naturally when execution reaches the end of its body. Use `yield break` when a condition should stop element production immediately.

## Consume an iterator with `foreach`

An iterator exposes the same `IEnumerable<T>` shape as many .NET collections. Callers can use `foreach` without knowing how the sequence produces its elements:

```csharp
foreach (int temperature in SelectTemperatures(readings, 25))
{
    Console.WriteLine($"Accepted: {temperature}°C");
}
```

The caller requests each element as the loop advances. The iterator keeps its position between requests and continues after the previous `yield return`.

## Understand deferred element production

Calling an iterator method doesn't run its body immediately. The method starts to produce elements when the caller begins enumeration. This behavior is called *deferred execution*.

The example prints `Sequence created.` before any `Checking ...` messages. The iterator starts checking readings only when the `foreach` loop asks for its first element.

Deferred execution has practical effects:

- The caller can begin processing before the iterator produces every element.
- The iterator can stop early with `yield break`.
- A caller that never enumerates the sequence doesn't run the iterator body.
- Each new enumeration runs the iterator again.

Keep deferred execution visible in the method's purpose and naming. Avoid unexpected side effects in an iterator because callers might enumerate the sequence later or more than once.

## Choose an iterator or collection

Return an iterator when values naturally arrive one at a time or when the caller doesn't need the complete result immediately. Return a completed collection when callers need a stable snapshot, indexed access, or repeated enumeration without recalculating the elements.

Iterator methods compose with LINQ because both use `IEnumerable<T>`. For example, a caller can add another filter:

```csharp
var comfortableReadings = SelectTemperatures(readings, 25)
    .Where(static temperature => temperature >= 18);
```

The iterator and LINQ operation remain deferred until code enumerates `comfortableReadings`.

For asynchronous sequences, see [Generate and consume asynchronous streams](../../asynchronous-programming/generate-consume-asynchronous-stream.md). For custom enumeration patterns and all `yield` restrictions, use the [language reference](../../language-reference/statements/yield.md).

## See also

- [Functional techniques overview](index.md)
- [Lambda expressions](lambdas.md)
- [Local functions](local-functions.md)
- [`foreach` statement](../../language-reference/statements/iteration-statements.md#the-foreach-statement)
- [`yield` statement](../../language-reference/statements/yield.md)
- [LINQ](../statements/linq.md)
