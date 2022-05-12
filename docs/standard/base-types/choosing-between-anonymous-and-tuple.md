---
title: Choosing between anonymous and tuple types
description: Learn when it's appropriate to choose between anonymous types, and tuple type.
author: IEvangelist
ms.author: dapine
ms.topic: conceptual
ms.date: 07/01/2020
---
# Choosing between anonymous and tuple types

Choosing the appropriate type involves considering its usability, performance, and tradeoffs compared to other types. Anonymous types have been available since C# 3.0, while generic <xref:System.Tuple%602?displayProperty=nameWithType> types were introduced with .NET Framework 4.0. Since then new options have been introduced with language level support, such as <xref:System.ValueTuple%602?displayProperty=nameWithType> - which as the name implies, provide a value type with the flexibility of anonymous types. In this article, you'll learn when it's appropriate to choose one type over the other.

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

For more information, see [anonymous types](../../csharp/fundamentals/types/anonymous-types.md). The same functionality exists with tuples when projecting into LINQ queries, you can select properties into tuples. These tuples flow through the query, just as anonymous types would. Now consider the following example using the `System.Tuple<string, long>`.

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

With the <xref:System.Tuple%602?displayProperty=nameWithType>, the instance exposes numbered item properties, such as `Item1`, and `Item2`. These property names can make it more difficult to understand the intent of the property values, as the property name only provides the ordinal. Furthermore, the `System.Tuple` types are reference `class` types. The <xref:System.ValueTuple%602?displayProperty=nameWithType> however, is a value `struct` type. The following C# snippet, uses `ValueTuple<string, long>` to project into. In doing so, it assigns using a literal syntax.

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

For more information about tuples, see [Tuple types (C# reference)](../../csharp/language-reference/builtin-types/value-tuples.md) or [Tuples (Visual Basic)](../../visual-basic/programming-guide/language-features/data-types/tuples.md).

The previous examples are all functionally equivalent, however, there are slight differences in their usability and their underlying implementations.

## Tradeoffs

You might want to always use <xref:System.ValueTuple> over <xref:System.Tuple>, and anonymous types, but there are tradeoffs you should consider. The <xref:System.ValueTuple> types are mutable, whereas <xref:System.Tuple> are read-only. Anonymous types can be used in expression trees, while tuples cannot. The following table is an overview of some of the key differences.

### Key differences

| Name                     | Access modifier | Type     | Custom member name | Deconstruction support | Expression tree support |
|--------------------------|-----------------|----------|----------------------|------------------------|-------------------------|
| Anonymous types          | `internal`      | `class`  | ✔️                   | ❌                     | ✔️                     |
| <xref:System.Tuple>      | `public`        | `class`  | ❌                   | ❌                     | ✔️                     |
| <xref:System.ValueTuple> | `public`        | `struct` | ✔️                   | ✔️                     | ❌                     |

### Serialization

One important consideration when choosing a type, is whether or not it will need to be serialized. Serialization is the process of converting the state of an object into a form that can be persisted or transported. For more information, see [serialization](../../csharp/programming-guide/concepts/serialization/index.md). When serialization is important, creating a `class` or `struct` is preferred over anonymous types or tuple types.

## Performance

Performance between these types depends on the scenario. The major impact involves the tradeoff between allocations and copying. In most scenarios, the impact is small. When major impacts could arise, measurements should be taken to inform the decision.

## Conclusion

As a developer choosing between tuples and anonymous types, there are several factors to consider. Generally speaking, if you're not working with [expression trees](../../csharp/expression-trees.md), and you're comfortable with tuple syntax then choose <xref:System.ValueTuple> as they provide a value type with the flexibility to name properties. If you're working with expression trees, and you'd prefer to name properties, choose anonymous types. Otherwise, use <xref:System.Tuple>.

## See also

- [Anonymous types](../../csharp/fundamentals/types/anonymous-types.md)
- [Expression trees](../../csharp/expression-trees.md)
- [Tuple types (C# reference)](../../csharp/language-reference/builtin-types/value-tuples.md)
- [Tuples (Visual Basic)](../../visual-basic/programming-guide/language-features/data-types/tuples.md)
- [Type design guidelines](../design-guidelines/type.md)
