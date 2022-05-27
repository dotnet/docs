---
title: ".NET 6 breaking change: Additional overloads of LINQ Queryable methods"
description: Learn about the .NET 6 breaking change in core .NET libraries where additional method overloads were added to the System.Linq.Queryable type.
ms.date: 03/31/2021
---
# New System.Linq.Queryable method overloads

Additional public method overloads have been added to <xref:System.Linq.Queryable?displayProperty=fullName> as part of the new features implemented in <https://github.com/dotnet/runtime/pull/47231>. If your reflection code isn't sufficiently robust when looking up methods, these additions can break your query provider implementations.

## Change description

In .NET 6, new overloads were added to the methods listed in the [Affected APIs](#affected-apis) section. Reflection code, such as that shown in the following example, may break as a result of these additions:

```csharp
typeof(System.Linq.Queryable)
    .GetMethods(BindingFlags.Public | BindingFlags.Static)
    .Where(m => m.Name == "ElementAt")
    .Single();
```

This reflection code will now throw an <xref:System.InvalidOperationException> with a message similar to: **Sequence contains more than one element**.

## Version introduced

.NET 6

## Reason for change

The new overloads were added to extend the LINQ `Queryable` API.

## Recommended action

If you're a query-provider library author, ensure that your reflection code is tolerant of method overload additions. For example, use a <xref:System.Type.GetMethod%2A?displayProperty=nameWithType> overload that explicitly accepts the method's parameter types.

## Affected APIs

New overloads were added for the following <xref:System.Linq.Queryable> extension methods:

- <xref:System.Linq.Queryable.ElementAt%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.ElementAtOrDefault%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.Take%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.Min%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.Max%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.FirstOrDefault%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.LastOrDefault%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.SingleOrDefault%2A?displayProperty=fullName>
- <xref:System.Linq.Queryable.Zip%2A?displayProperty=fullName>

<!--

### Category

- Core .NET libraries
- LINQ

### Affected APIs

- `Overload:System.Linq.Queryable.ElementAt`
- `Overload:System.Linq.Queryable.ElementAtOrDefault`
- `Overload:System.Linq.Queryable.Take`
- `Overload:System.Linq.Queryable.Min`
- `Overload:System.Linq.Queryable.Max`
- `Overload:System.Linq.Queryable.FirstOrDefault`
- `Overload:System.Linq.Queryable.LastOrDefault`
- `Overload:System.Linq.Queryable.SingleOrDefault`
- `Overload:System.Linq.Queryable.Zip`

-->
