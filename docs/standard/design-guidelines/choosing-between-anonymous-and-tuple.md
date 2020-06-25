---
title: "Choosing between anonymous and tuple types"
description: Learn how to decide whether to design a type as a class, or to design a type as a struct.
ms.date: 06/24/2020
ms.technology: dotnet-standard
---

# Choosing between anonymous and tuple types

As a developer, choosing the appropriate type can be scary task. Anonymous types have been available since C# 3.0, while generic <xref:System.Tuple%602?displayProperty=nameWithType> types were introduced with .NET Framework 4.0. There are more modern options that exist, such as <xref:System.ValueTuple%602?displayProperty=nameWithType> - which as the name implies, provide a value type with the flexibility of anonymous types. In this article, you'll learn when it's appropriate to choose one type over the other.

## Usability and functionality

Anonymous types were introduced in C# 3.0 with Language-Integrated Query (LINQ) expressions. With LINQ, developers often project results from queries into anonymous types that hold a few select properties from the objects they're working with. Consider the following example, that instantiates an array of <xref:System.DateTime> objects, and iterates through them projecting into an anonymous type with two properties.

```csharp-interactive
var dates = new[]
{
    DateTime.UtcNow.AddHours(-1),
    DateTime.UtcNow,
    DateTime.UtcNow.AddHours(1),
};

foreach (var anonymous in
             dates.Select(
                 date => new { Formatted = $"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks }))
{
    Console.WriteLine($"Ticks: {anonymous.Ticks}, formatted: {anonymous.Formatted}");
}
```

Anonymous types are instantiated by using the [`new`](../../csharp/language-reference/operators/new-operator.md) operator, and the property names and types are inferred from the declaration. If two or more anonymous object initializers in the same assembly specify a sequence of properties that are in the same order and that have the same names and types, the compiler treats the objects as instances of the same type. They share the same compiler-generated type information.

The previous C# snippet projects an anonymous type with two properties, much like the following compiler-generated C# class:

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

For more information, see [anonymous types](../../csharp/programming-guide/classes-and-structs/anonymous-types.md). The same functionality exists with tuples when projecting into LINQ queries, you can select properties into tuples. These tuples flow through the query, just as anonymous types would. Now consider the following example using the `System.Tuple<string, long>`.

```csharp-interactive
var dates = new[]
{
    DateTime.UtcNow.AddHours(-1),
    DateTime.UtcNow,
    DateTime.UtcNow.AddHours(1),
};

foreach (var tuple in
            dates.Select(
                date => new Tuple<string, long>($"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks)))
{
    Console.WriteLine($"Ticks: {tuple.Item2}, formatted: {tuple.Item1}");
}
```

With the <xref:System.Tuple%602?displayProperty=nameWithType>, the instance exposes numbered item properties, such as `Item1`, and `Item2`. These property names can make it more difficult to understand the intent of the property values, as the property name only provides the ordinal. Furthermore, the `System.Tuple` types are reference `class` types. The <xref:System.ValueTuple%602?displayProperty=nameWithType> however, is a value `struct` type.

```csharp-interactive
var dates = new[]
{
    DateTime.UtcNow.AddHours(-1),
    DateTime.UtcNow,
    DateTime.UtcNow.AddHours(1),
};

foreach (var (formatted, ticks) in
            dates.Select(
                date => (Formatted: $"{date:MMM dd, yyyy at hh:mm zzz}", date.Ticks)))
{
    Console.WriteLine($"Ticks: {ticks}, formatted: {formatted}");
}
```

The previous examples are all functionally equivalent, however; there are slight differences in their usability and their underlying implementations. One nicety with <xref:System.ValueTuple> is the ability to deconstruct the tuple into its members.

## Limitations

While it might seem as though you should always use <xref:System.ValueTuple> over <xref:System.Tuple>, and anonymous types - there are tradeoffs you should consider. The <xref:System.ValueTuple> types are mutable, whereas <xref:System.Tuple> are read-only. Anonymous types can be used in expression trees, while tuples cannot.

### Key differences

| Name                     | Type     | Custom property name | Deconstruction support | Expression tree support |
|--------------------------|----------|----------------------|------------------------|-------------------------|
| Anonymous types          | `class`  | ✔️                  | ❌                      | ✔️                     |
| <xref:System.Tuple>      | `class`  | ❌                   | ❌                      | ✔️                     |
| <xref:System.ValueTuple> | `struct` | ✔️                  | ✔️                     | ❌                      |

## Performance

Performance is always a topic of discussion when referring to value types vs reference types, often leading to conversations of stack versus heap allocations. However, performance between these types is fairly similar with each other - in other words, performance is irrelevant. The micro-optimizations you might gain from choosing tuples over anonymous types is more often than not negligible.

## Conclusion

As a developer choosing between tuples and anonymous types, there are several factors to consider. Generally speaking, if you're not working with [expression trees](../../csharp/expression-trees.md), and you're comfortable with tuple syntax then choose <xref:System.ValueTuple> as they provide a value type with the flexibility to name properties. If you're working with expression trees, and you'd prefer to name properties, choose anonymous types. Otherwise, use <xref:System.Tuple>.

## See also

- [Anonymous types](../../csharp/programming-guide/classes-and-structs/anonymous-types.md)
- [Expression trees](../../csharp/expression-trees.md)
- [Framework design guidelines](index.md)
- [Tuple types](../../csharp/tuples.md)
- [Type design guidelines](type.md)
