---
title: What's new in C# 15
description: Get an overview of the new features in C# 15. C# 15 ships with .NET 11.
ms.date: 06/16/2026
ms.topic: whats-new
ms.update-cycle: 365-days
ai-usage: ai-assisted
---
# What's new in C# 15

C# 15 includes the following new features. Try these features by using the latest [Visual Studio 2026](https://visualstudio.microsoft.com/) insiders version or the [.NET 11 preview SDK](https://dotnet.microsoft.com/download/dotnet):

- [Collection expression arguments](#collection-expression-arguments)
- [Union types](#union-types)
- [Closed hierarchies](#closed-hierarchies)
- [Unsafe evolution](#unsafe-evolution)

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

The runtime includes the `UnionAttribute` and `IUnion` types beginning with .NET 11 Preview 5. Some features from the [proposal specification](~/_csharplang/proposals/unions.md) aren't yet implemented. Those features are coming in future previews.

For more information, see [Union types](../language-reference/builtin-types/union.md) in the language reference or the [feature specification](~/_csharplang/proposals/unions.md).

## Closed hierarchies

Starting in C# 15, you can apply the `closed` modifier to a class to declare a *closed hierarchy*. A closed class can only be derived from within its declaring assembly, which fixes the set of direct descendants at compile time:

```csharp
public closed record class GateState;
public record class Closed : GateState;
public record class Open(float Percent) : GateState;
```

Because the compiler knows every direct descendant, a `switch` expression that handles each one is exhaustive and doesn't need a default arm:

```csharp
string Describe(GateState state) => state switch
{
    Closed => "closed",
    Open(var percent) => $"{percent}% open",
    // No warning: every direct descendant of 'GateState' is handled.
};
```

The `closed` modifier is a contextual keyword. A `closed` class is implicitly `abstract` and can't be combined with `sealed`, `static`, or an explicit `abstract` modifier. Derivation isn't transitive: a non-closed descendant of a closed class can still be derived from in other assemblies. To extend exhaustiveness checking down the hierarchy, mark intermediate descendants `closed` as well.

> [!NOTE]
> In C# 15 preview 5, the runtime doesn't yet ship `System.Runtime.CompilerServices.ClosedAttribute`. Until it does, every project that uses the `closed` modifier must declare the attribute itself:
>
> ```csharp
> namespace System.Runtime.CompilerServices;
>
> [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
> public sealed class ClosedAttribute : Attribute { }
> ```

For more information, see the [closed modifier](../language-reference/keywords/closed.md) and [Closed hierarchy patterns](../language-reference/operators/patterns.md#closed-hierarchy-patterns) in the language reference, or the [feature specification](~/_csharplang/proposals/closed-hierarchies.md). You can copy the examples in this section, including the `ClosedAttribute` workaround, from the [keywords snippets project](https://github.com/dotnet/docs/blob/main/docs/csharp/language-reference/keywords/snippets/shared) in the `dotnet/docs` GitHub repository.

## Unsafe evolution

C# 15 begins to evolve the rules for unsafe code. Historically, the `unsafe` context covered the existence of pointer types. The updated rules tie the `unsafe` context to the operations that access unmanaged memory, not to the existence of a pointer.

When you compile with the `preview` language version, the following operations no longer require an `unsafe` context:

- Declaring a pointer type and taking the address of a variable with the `&` operator.
- The `fixed` statement that pins a variable.
- Converting a `stackalloc` expression to a pointer.
- The `sizeof` operator applied to any unmanaged type.

The following example creates and pins a pointer without an `unsafe` context:

```csharp
int number = 42;
int* pointer = &number;

int[] numbers = [10, 20, 30];
fixed (int* first = numbers)
{
    // Dereferencing the pointer still requires an unsafe context.
}
```

The operations that access the pointed-to memory, such as pointer indirection (`*p`), pointer member access (`p->member`), pointer element access (`p[i]`), and function pointer invocation, still require an `unsafe` context.

The .NET 11 Preview 5 compiler implements these relaxations. A later preview adds the *requires-unsafe* member model, the assembly opt-in to the updated memory safety rules, and the `safe` contextual keyword.

For more information, see [Unsafe code, pointer types, and function pointers](../language-reference/unsafe-code.md#unsafe-evolution-preview) in the language reference or the [feature specification](~/_csharplang/proposals/unsafe-evolution.md).

<!-- Add when available
## See also

- [What's new in .NET 11](../../core/whats-new/dotnet-11/overview.md)
- -->
