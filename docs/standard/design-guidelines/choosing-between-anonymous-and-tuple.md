---
title: "Choosing between anonymous and tuple types"
description: Learn how to decide whether to design a type as a class, or to design a type as a struct.
ms.date: 06/23/2020
ms.technology: dotnet-standard
---

# Choosing between anonymous and tuple types

As a developer, choosing the appropriate type can be scary task. Anonymous types have been available since C# 3.0, while generic <xref:System.Tuple%602?displayProperty=nameWithType> types were introduced with .NET Framework 4.0. There are more modern options that exist, such as <xref:System.ValueTuple%602?displayProperty=nameWithType> - which as the name implies, provide a value type with the flexibility of anonymous types. In this article you'll learn some of the limitations of these various type options, and when it's appropriate to choose one over the other.

## Usability and functionality

With the advent of C# 3.0, when anonymous types were introduced so too were Language-Integrated Query (LINQ) expressions. With LINQ, developers often project results from queries into anonymous types that hold a few select properties from the objects their working with. This can also be achieved with tuples.

```csharp-interactive
var dates = new[]
{
    DateTime.UtcNow.AddHours(-1),
    DateTime.UtcNow,
    DateTime.UtcNow.AddHours(1),
};

foreach (var anonymous in
             dates.Select(
                 date => new { Formatted = $"{date:MMM dd, yyyy at hh:mm zzz}", date.Ticks }))
{
    Console.WriteLine($"Ticks: {anonymous.Ticks}, formatted: {anonymous.Formatted}");
}
```

The previous example C# snippet projects an anonymous type that would be defined with two properties.

```csharp
internal sealed class f__AnonymousType0
{
    public string Formatted { get; }
    public long Ticks { get; }

    public f__AnonymousType0(string formatted, long ticks)
    {
        Formatted = formatted;
        Ticks = ticks;
    }
}
```

```csharp-interactive
var dates = new[]
{
    DateTime.UtcNow.AddHours(-1),
    DateTime.UtcNow,
    DateTime.UtcNow.AddHours(1),
};

foreach (var anonymous in
             dates.Select(
                 date => (Formatted: $"{date:MMM dd, yyyy at hh:mm zzz}", date.Ticks)))
{
    Console.WriteLine($"Ticks: {anonymous.ticks}, formatted: {anonymous.formatted}");
}
```

## Legacy tuples

## Language tuples

## Performance



NOTES:

Anonymous types can be included in expression trees, tuples can't.

On a performance and functionality basis anonymous types and Tuple<...> are basically on par. Their implementation is roughly the same. The difference though is usability because you can name anonymous type fields but not Tuple<...> fields.

Language tuples (...) and anonymous types have about the same usability but different performance (struct vs. class).

That being said I haven't explicitly used anonymous types, except as a transparent proxy in a LINQ query, in some time.

✔️ CONSIDER ...

❌ AVOID ...

## See also

- [Anonymous types](../../csharp/programming-guide/classes-and-structs/anonymous-types.md)
- [Expression trees](../../csharp/expression-trees.md)
- [Framework design guidelines](index.md)
- [Tuple types](../../csharp/tuples.md)
- [Type design guidelines](type.md)
