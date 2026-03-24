---
title: What's new in C# 15
description: Get an overview of the new features in C# 15. C# 15 ships with .NET 11.
ms.date: 03/20/2026
ms.topic: whats-new
ms.update-cycle: 365-days
ai-usage: ai-assisted
---
# What's new in C# 15

C# 15 includes the following new features. Try these features by using the latest [Visual Studio 2026](https://visualstudio.microsoft.com/) insiders version or the [.NET 11 preview SDK](https://dotnet.microsoft.com/download/dotnet):

- [Collection expression arguments](#collection-expression-arguments)
- [Union types](#union-types)

C# 15 is the latest C# preview release. .NET 11 preview versions support C# 15. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 11 preview SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2026 insiders](https://visualstudio.microsoft.com/vs/), which includes the .NET 11 preview SDK.

The "What's new in C#" page adds new features when they're available in public preview releases. The [working set](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md#working-set) section of the [roslyn feature status page](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) tracks when upcoming features are merged into the main branch.

You can find any breaking changes introduced in C# 15 in our article on [breaking changes](~/_roslyn/docs/compilers/CSharp/Compiler%20Breaking%20Changes%20-%20DotNet%2011.md).

[!INCLUDE [released-version-feedback](./includes/released-feedback.md)]

## Collection expression arguments

You can pass arguments to the underlying collection's constructor or factory method by using a `with(...)` element as the first element in a collection expression. This feature enables you to specify capacity, comparers, or other constructor parameters directly within the collection expression syntax.

The following example shows how to pass a capacity argument to a `List<T>` constructor and a comparer to a `HashSet<T>`:

```csharp
string[] values = ["one", "two", "three"];

// Pass capacity argument to List<T> constructor
List<string> names = [with(capacity: values.Length * 2), .. values];

// Pass comparer argument to HashSet<T> constructor
HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO", "hello"];
// set contains only one element because all strings are equal with OrdinalIgnoreCase
```

To learn more about collection expression arguments, see the [language reference article on collection expressions](../language-reference/operators/collection-expressions.md#collection-expression-arguments) or the [feature specification](~/_csharplang/proposals/collection-expression-arguments.md). For information on using collection expression arguments in collection initializers, see [Object and Collection Initializers](../programming-guide/classes-and-structs/object-and-collection-initializers.md#collection-expression-arguments).

## Union types

C# 15 introduces *union types*, which represent a value that can be one of several *case types*. Declare a union with the `union` keyword:

```csharp
public record class Cat(string Name);
public record class Dog(string Name);
public record class Bird(string Name);

public union Pet(Cat, Dog, Bird);
```

Unions provide implicit conversions from each case type, and the compiler ensures `switch` expressions are exhaustive across all case types:

```csharp
Pet pet = new Dog("Rex");

string name = pet switch
{
    Dog d => d.Name,
    Cat c => c.Name,
    Bird b => b.Name,
};
```

Union types first appeared in .NET 11 Preview 2. In early .NET 11 previews, the `UnionAttribute` and `IUnion` interface aren't included in the runtime, so you must declare them in your project. Later .NET 11 preview versions include these runtime types. Also, some features from the [proposal specification](~/_csharplang/proposals/unions.md) aren't yet implemented, including *union member providers*. Those features are coming in future previews.

For more information, see [Union types](../language-reference/builtin-types/union.md) in the language reference or the [feature specification](~/_csharplang/proposals/unions.md).

<!-- Add when available
## See also

- [What's new in .NET 11](../../core/whats-new/dotnet-11/overview.md)
- -->
