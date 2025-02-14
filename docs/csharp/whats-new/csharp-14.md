---
title: What's new in C# 14
description: Get an overview of the new features in C# 14. C# 14 ships with .NET 10.
ms.date: 02/04/2025
ms.topic: whats-new
---
# What's new in C# 14

C# 14 includes the following new features. You can try these features using the latest [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) version or the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet):

- [`nameof` supports unbound generic types](#unbound-generic-types-and-nameof)
- [More implicit conversions for `Span<T>` and `ReadOnlySpan<T>`](#implicit-span-conversions)
- [Modifiers on simple lambda parameters](#simple-lambda-parameters-with-modifiers)
- [`field` backed properties](#the-field-keyword)

C# 14 is supported on **.NET 10**. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 10 SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), which includes the .NET 10 SDK.

New features are added to the "What's new in C#" page when they're available in public preview releases. The [working set](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md#working-set) section of the [roslyn feature status page](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) tracks when upcoming features are merged into the main branch.

You can find any breaking changes introduced in C# 14 in our article on [breaking changes](~/_roslyn/docs/compilers/CSharp/Compiler%20Breaking%20Changes%20-%20DotNet%2010.md).

[!INCLUDE [released-version-feedback](./includes/released-feedback.md)]

## The `field` keyword

The token `field` enables you to write a property accessor body without declaring an explicit backing field. The token `field` is replaced with a compiler synthesized backing field.

For example, previously, if you wanted to ensure that a `string` property couldn't be set to `null`, you had to declare a backing field and implement both accessors:

```csharp
private string _msg;
public string Message
{
    get => _msg;
    set
    {
        if (value is null) throw new NullArgumentException(nameof(value));
        _msg = value;
    }
}
```

You can now simplify your code to:

```csharp
public string Message
{
    get;
    set
    {
        field = (value is not null) ? value : throw new NullArgumentException(nameof(value));
    }
}
```

You can declare a body for one or both accessors for a field backed property.

There's a potential breaking change or confusion reading code in types that also include a symbol named `field`. You can use `@field` or `this.field` to disambiguate between the `field` keyword and the identifier, or you can rename the current `field` symbol to provide more distinction.

[!INCLUDE[field-preview](../includes/field-preview.md)]

If you try this feature and have feedback, comment on the [feature issue](https://github.com/dotnet/csharplang/issues/140) in the `csharplang` repository.

The [`field`](../language-reference/keywords/field.md) contextual keyword is in C# 13 as a preview feature. You can try it if you're using .NET 9 and C# 13 to provide [feedback](https://github.com/dotnet/csharplang/issues/140).

## Implicit span conversions

C# 14 introduces first-class support for <xref:System.Span`1?displayProperty=fullName> and <xref:System.ReadOnlySpan`1?displayProperty=fullName> in the language. This support involves new implicit conversions allowing more natural programming with these integral types.

`Span<T>` and `ReadOnlySpan<T>` are used in many key ways in C# and the runtime. Their introduction improves performance without risking safety. C# 14 recognizes the relationship and supports some conversions between `ReadOnlySpan<T>`, `Span<T>`, and `T[]`. The span types can be extension method receivers, compose with other conversions, and help with generic type inference scenarios.

You can find the list of implicit span conversions in the article on [built-in types](../language-reference/builtin-types/built-in-types.md) in the language reference section. You can learn more details by reading the feature specification for [First class span types](~/_csharplang/proposals/first-class-span-types.md).

## Unbound generic types and nameof

Beginning with C# 14, the argument to `nameof` can be an unbound generic type. For example, `nameof(List<>)` evaluates to `List`. In earlier versions of C#, only closed generic types, such as `List<int>`, could be used to return the `List` name.

## Simple lambda parameters with modifiers

Beginning with C# 14, you can add parameter modifiers, such as `scoped`, `ref`, `in`, `out`, or `ref readonly` to lambda expression parameters without specifying the parameter type:

```csharp
delegate bool TryParse<T>(string text, out T result);
// ...
TryParse<int> parse1 = (text, out result) => Int32.TryParse(text, out result);
```

Previously, adding any modifiers was allowed only when the parameter declarations included the types for the parameters. The preceding declaration would require typs on all parameters:

```csharp
TryParse<int> parse2 = (string text, out int result) => Int32.TryParse(text, out result);
```

The `params` modifier still requires an explicitly typed parameter list.

You can read more about these changes in the article on [lambda expressions](../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) in the C# language reference.

<!-- Add link to What's new in .NET 10 once it's published -->
