---
title: What's new in C# 13
description: Get an overview of the new features in C# 13.
ms.date: 05/29/2025
ms.topic: whats-new
---
# What's new in C# 13

C# 13 includes the following new features. You can try these features using the latest [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) version or the [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet):

- [`params` collections](#params-collections)
- [New `lock` type and semantics](#new-lock-object).
- [New escape sequence - `\e`](#new-escape-sequence).
- [Method group natural type improvements](#method-group-natural-type)
- [Implicit indexer access in object initializers](#implicit-index-access)
- [Enable `ref` locals and `unsafe` contexts in iterators and async methods](#ref-and-unsafe-in-iterators-and-async-methods)
- [Enable `ref struct` types to implement interfaces](#ref-struct-interfaces).
- [Allow ref struct types](#allows-ref-struct) as arguments for type parameters in generics.
- [Partial properties and indexers](#more-partial-members) are now allowed in `partial` types.
- [Overload resolution priority](#overload-resolution-priority) allows library authors to designate one overload as better than others.

Beginning with Visual Studio 17.12, C# 13 includes the [`field`](#the-field-keyword) contextual keyword as a preview feature.

C# 13 is supported on **.NET 9**. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 9 SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), which includes the .NET 9 SDK.

You can find any breaking changes introduced in C# 13 in our article on [breaking changes](~/_roslyn/docs/compilers/CSharp/Compiler%20Breaking%20Changes%20-%20DotNet%209.md).

[!INCLUDE [released-version-feedback](./includes/released-feedback.md)]

## `params` collections

The `params` modifier isn't limited to array types. You can now use `params` with any recognized collection type, including <xref:System.Span%601?displayProperty=nameWithType>, <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>, and types that implement <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> and have an `Add` method. In addition to concrete types, the interfaces <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>, <xref:System.Collections.Generic.IReadOnlyCollection%601?displayProperty=nameWithType>, <xref:System.Collections.Generic.IReadOnlyList%601?displayProperty=nameWithType>, <xref:System.Collections.Generic.ICollection%601?displayProperty=nameWithType>, and <xref:System.Collections.Generic.IList%601?displayProperty=nameWithType> can also be used.

When an interface type is used, the compiler synthesizes the storage for the arguments supplied. You can learn more in the feature specification for [`params` collections](~/_csharplang/proposals/csharp-13.0/params-collections.md).

For example, method declarations can declare spans as `params` parameters:

```csharp
public void Concat<T>(params ReadOnlySpan<T> items)
{
    for (int i = 0; i < items.Length; i++)
    {
        Console.Write(items[i]);
        Console.Write(" ");
    }
    Console.WriteLine();
}
```

## New lock object

The .NET 9 runtime includes a new type for thread synchronization, the <xref:System.Threading.Lock?displayProperty=fullName> type. This type provides better thread synchronization through its API. The <xref:System.Threading.Lock.EnterScope?displayProperty=nameWithType> method enters an exclusive scope. The `ref struct` returned from that supports the `Dispose()` pattern to exit the exclusive scope.

The C# [`lock`](../language-reference/statements/lock.md) statement recognizes if the target of the lock is a `Lock` object. If so, it uses the updated API, rather than the traditional API using <xref:System.Threading.Monitor?displayProperty=nameWithType>. The compiler also recognizes if you convert a `Lock` object to another type and the `Monitor` based code would be generated. You can read more in the feature specification for the [new lock object](~/_csharplang/proposals/csharp-13.0/lock-object.md).

This feature allows you to get the benefits of the new library type by changing the type of object you `lock`. No other code needs to change.

## New escape sequence

You can use `\e` as a [character literal](~/_csharpstandard/standard/lexical-structure.md#6455-character-literals) escape sequence for the `ESCAPE` character, Unicode `U+001B`. Previously, you used `\u001b` or `\x1b`. Using `\x1b` wasn't recommended because if the next characters following `1b` were valid hexadecimal digits, those characters became part of the escape sequence.

## Method group natural type

This feature makes small optimizations to overload resolution involving method groups. A *method group* is a method and all overloads with the same name. The previous behavior was for the compiler to construct the full set of candidate methods for a method group. If a natural type was needed, the natural type was determined from the full set of candidate methods.

The new behavior is to prune the set of candidate methods at each scope, removing those candidate methods that aren't applicable. Typically, the removed methods are generic methods with the wrong arity, or constraints that aren't satisfied. The process continues to the next outer scope only if no candidate methods are found. This process more closely follows the general algorithm for overload resolution. If all candidate methods found at a given scope don't match, the method group doesn't have a natural type.

You can read the details of the changes in the [proposal specification](~/_csharplang/proposals/csharp-13.0/method-group-natural-type-improvements.md).

## Implicit index access

The implicit "from the end" index operator, `^`, is now allowed in an object initializer expression for single-dimension collections. For example, you can now initialize a single-dimension array using an object initializer as shown in the following code:

```csharp
public class TimerRemaining
{
    public int[] buffer { get; set; } = new int[10];
}

var countdown = new TimerRemaining()
{
    buffer =
    {
        [^1] = 0,
        [^2] = 1,
        [^3] = 2,
        [^4] = 3,
        [^5] = 4,
        [^6] = 5,
        [^7] = 6,
        [^8] = 7,
        [^9] = 8,
        [^10] = 9
    }
};
```

The `TimerRemaining` class includes a `buffer` array initialized to a length of 10. The preceding example assigns values to this array using the "from the end" index operator (`^`), effectively creating an array that counts down from 9 to 0.

In versions before C# 13, the `^` operator can't be used in an object initializer. You need to index the elements from the front.

## `ref` and `unsafe` in iterators and `async` methods

This feature and the following two features enable `ref struct` types to use new constructs. You won't use these features unless you write your own `ref struct` types. More likely, you'll see an indirect benefit as <xref:System.Span`1?displayProperty=nameWithType> and <xref:System.ReadOnlySpan`1?displayProperty=nameWithType> gain more functionality.

Before C# 13, iterator methods (methods that use `yield return`) and `async` methods couldn't declare local `ref` variables, nor could they have an `unsafe` context.

In C# 13, `async` methods can declare `ref` local variables, or local variables of a `ref struct` type. However, those variables can't be accessed across an `await` boundary. Neither can they be accessed across a `yield return` boundary.

This relaxed restriction enables the compiler to allow verifiably safe use of `ref` local variables and `ref struct` types in more places. You can safely use types like <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> in these methods. The compiler tells you if you violate safety rules.

In the same fashion, C# 13 allows `unsafe` contexts in iterator methods. However, all `yield return` and `yield break` statements must be in safe contexts.

## `allows ref struct`

Before C# 13, `ref struct` types couldn't be declared as the type argument for a generic type or method. Now, generic type declarations can add an anti-constraint, `allows ref struct`. This anti-constraint declares that the type argument supplied for that type parameter can be a `ref struct` type. The compiler enforces ref safety rules on all instances of that type parameter.

For example, you might declare a generic type like the following code:

```csharp
public class C<T> where T : allows ref struct
{
    // Use T as a ref struct:
    public void M(scoped T p)
    {
        // The parameter p must follow ref safety rules
    }
}
```

This enables types such as <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> to be used with generic algorithms, where applicable. You can learn more in the updates for [`where`](../language-reference/keywords/where-generic-type-constraint.md) and the programming guide article on [generic constraints](../programming-guide/generics/constraints-on-type-parameters.md).

## `ref struct` interfaces

Before C# 13, `ref struct` types weren't allowed to implement interfaces. Beginning with C# 13, they can. You can declare that a `ref struct` type implements an interface. However, to ensure ref safety rules, a `ref struct` type can't be converted to an interface type. That conversion is a boxing conversion, and could violate ref safety. Explicit interface method declarations in a `ref struct` can be accessed only through a type parameter where that type parameter [`allows ref struct`](../programming-guide/generics/constraints-on-type-parameters.md#allows-ref-struct). Also, `ref struct` types must implement all methods declared in an interface, including those methods with a default implementation.

Learn more in the updates on [`ref struct` types](../language-reference/builtin-types/ref-struct.md#restrictions-for-ref-struct-types-that-implement-an-interface) and the addition of the [`allows ref struct`](../programming-guide/generics/constraints-on-type-parameters.md#allows-ref-struct) generic constraint.

## More partial members

You can declare `partial` properties and `partial` indexers in C# 13. Partial properties and indexers generally follow the same rules as `partial` methods: you create one *declaring declaration* and one *implementing declaration*. The signatures of the two declarations must match. One restriction is that you can't use an auto-property declaration for *implementing* a partial property. Properties that don't declare a body are considered the *declaring declaration*.

```csharp
public partial class C
{
    // Declaring declaration
    public partial string Name { get; set; }
}

public partial class C
{
    // implementation declaration:
    private string _name;
    public partial string Name
    {
        get => _name;
        set => _name = value;
    }
}
```

You can learn more in the article on [partial members](../language-reference/keywords/partial-member.md).

## Overload resolution priority

In C# 13, the compiler recognizes the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute> to prefer one overload over another. Library authors can use this attribute to ensure that a new, better overload is preferred over an existing overload. For example, you might add a new overload that's more performant. You don't want to break existing code that uses your library, but you want users to update to the new version when they recompile. You can use [Overload resolution priority](../language-reference/attributes/general.md#overloadresolutionpriority-attribute) to inform the compiler which overload should be preferred. Overloads with the highest priority are preferred.

This feature is intended for library authors to avoid ambiguity when adding new overloads. Library authors should use care with this attribute to avoid confusion.

## The `field` keyword

The [`field`](../language-reference/keywords/field.md) contextual keyword is in C# 13 as a preview feature. The token `field` accesses the compiler synthesized backing field in a property accessor. It enables you to write an accessor body without declaring an explicit backing field in your type declaration. You can declare a body for one or both accessors for a field backed property.

The `field` feature is released as a preview feature. We want to learn from your experiences using it. There's a potential breaking change or confusion reading code in types that also include a field named `field`. You can use `@field` or `this.field` to disambiguate between the `field` keyword and the identifier.

[!INCLUDE[field-preview](../includes/field-preview.md)]

If you try this feature and have feedback, add it to the [feature issue](https://github.com/dotnet/csharplang/issues/140) in the `csharplang` repository.

## See also

- [What's new in .NET 9](../../core/whats-new/dotnet-9/overview.md)
