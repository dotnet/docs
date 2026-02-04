---
title: What's new in C# 15
description: Get an overview of the new features in C# 15. C# 15 ships with .NET 11.
ms.date: 02/04/2025
ms.topic: whats-new
ms.update-cycle: 365-days
---
# What's new in C# 15

C# 15 includes the following new features. You can try these features using the latest [Visual Studio 2026](https://visualstudio.microsoft.com/) version or the [.NET 11 preview SDK](https://dotnet.microsoft.com/download/dotnet):

- [Collection expression arguments](#collection-expression-arguments)

C# 15 is the latest C# release. C# 15 is supported on **.NET 11**. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 11 preview SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2026 insiders](https://visualstudio.microsoft.com/vs/), which includes the .NET 11 preview SDK.

New features are added to the "What's new in C#" page when they're available in public preview releases. The [working set](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md#working-set) section of the [roslyn feature status page](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) tracks when upcoming features are merged into the main branch.

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

You can learn more about collection expression arguments in the [language reference article on collection expressions](../language-reference/operators/collection-expressions.md#collection-expression-arguments) or the [feature specification](~/_csharplang/proposals/collection-expression-arguments.md). For information on using collection expression arguments in collection initializers, see [Object and Collection Initializers](../programming-guide/classes-and-structs/object-and-collection-initializers.md#collection-expression-arguments).

<!-- Add when available
## See also

- [What's new in .NET 11](../../core/whats-new/dotnet-11/overview.md)
- -->
