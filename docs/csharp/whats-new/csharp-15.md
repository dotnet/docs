---
title: What's new in C# 15
description: "Discover what's new in C# 15, including union types, closed hierarchies, extension indexers, collection expression arguments, and static interface compatibility."
ms.date: 10/19/2026
ms.topic: whats-new
ms.update-cycle: 365-days
ai-usage: ai-assisted
---
# What's new in C# 15

C# 15 includes the following new features. Try these features by using the [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0) or a compatible version of [Visual Studio 2026](https://visualstudio.microsoft.com/):

- [Collection expression arguments](#collection-expression-arguments)
- [Union types](#union-types)
- [Closed hierarchies](#closed-hierarchies)
- [Extension indexers](#extension-indexers)
- [Labeled `break` and `continue`](#labeled-break-and-continue)
- [Non-virtual static interface members on older runtimes](#non-virtual-static-interface-members-on-older-runtimes)
- [Memory safety (preview feature)](#memory-safety)

C# 15 is the default language version for projects that target `net11.0` in the .NET 11 SDK. Except for memory safety, these features don't require `<LangVersion>preview</LangVersion>`. The .NET 11 SDK is still prerelease. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can also try the [memory safety preview feature](#memory-safety). Enable the preview language version for the syntax and pointer relaxations, and the `updated-memory-safety-rules` feature flag for the updated safety rules.

The "What's new in C#" page adds new features when they're available in public preview releases. The [working set](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md#working-set) section of the [roslyn feature status page](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) tracks when upcoming features are merged into the main branch.

You can find any breaking changes introduced in C# 15 in our article on [breaking changes](~/_roslyn/docs/compilers/CSharp/Compiler%20Breaking%20Changes%20-%20DotNet%2011.md).

[!INCLUDE [released-version-feedback](./includes/released-feedback.md)]

## Collection expression arguments

Use a `with(...)` element as the first element in a collection expression to pass arguments to the underlying collection's constructor or factory method. This feature enables you to specify capacity, comparers, or other constructor parameters directly within the collection expression syntax.

The following example shows how to pass a capacity argument to a `List<T>` constructor and a comparer to a `HashSet<T>`:

```csharp
string[] values = ["one", "two", "three"];

// Pass capacity argument to List<T> constructor
List<string> names = [with(capacity: values.Length * 2), .. values];

// Pass comparer argument to HashSet<T> constructor
HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO", "hello"];
// set contains only one element because all strings are equal with OrdinalIgnoreCase
```

To learn more about collection expression arguments, see the [language reference article on collection expressions](../language-reference/operators/collection-expressions.md#collection-expression-arguments) or the [feature specification](~/_csharplang/proposals/csharp-15.0/collection-expression-arguments.md). For information on using collection expression arguments in collection initializers, see [Object and Collection Initializers](../programming-guide/classes-and-structs/object-and-collection-initializers.md#collection-expression-arguments).

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

For more information, see [Union types](../language-reference/builtin-types/union.md) in the language reference or the [feature specification](~/_csharplang/proposals/csharp-15.0/unions.md).

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

For more information, see the [closed modifier](../language-reference/keywords/closed.md) and [Closed hierarchy patterns](../language-reference/operators/patterns.md#closed-hierarchy-patterns) in the language reference, or the [feature specification](~/_csharplang/proposals/csharp-15.0/closed-hierarchies.md).

## Extension indexers

Starting with C# 15, you can declare *indexers* in an `extension` block. Extension indexers let you index into a receiver as though the indexer were declared on the receiver type. Because indexers are always instance members, an extension block that declares an indexer must provide a named receiver parameter.

The following example declares a get-only indexer on `IEnumerable<int>` that returns the element at a specified position:

```csharp
public static class SequenceIndexer
{
    extension(IEnumerable<int> sequence)
    {
        public int this[int index] => sequence.ElementAt(index);
    }
}
```

You index into the receiver as though the indexer were a member of the receiver type:

```csharp
IEnumerable<int> numbers = Enumerable.Range(1, 10);
int third = numbers[2];
```

For more information, see [Extension declaration](../language-reference/keywords/extension.md#extension-indexers) in the language reference or the [feature specification](~/_csharplang/proposals/csharp-15.0/extension-indexers.md).

## Labeled `break` and `continue`

Starting with C# 15, `break` and `continue` statements can name a label on an enclosing construct. Use a labeled `break` to exit an enclosing loop or `switch` statement. Use a labeled `continue` to start the next iteration of an enclosing loop.

Labeled `break` and `continue` replace the workarounds you'd otherwise use to steer control flow through nested loops, such as a Boolean flag that you set in an inner loop and then check at each outer level, or a `goto` that jumps past the loops. Naming the target loop directly on the jump statement removes that bookkeeping and makes the intended control flow easier to read.

```csharp
outer: for (int row = 0; row < grid.Height; row++)
{
    for (int column = 0; column < grid.Width; column++)
    {
        if (grid[row, column].IsBlocked)
        {
            continue outer;
        }

        if (grid[row, column].IsGoal)
        {
            break outer;
        }
    }
}
```

Place the label directly on the loop or `switch` statement it identifies. Without a label, `break` and `continue` keep their original behavior and target the innermost applicable statement.

The [IDE0410](../../fundamentals/code-analysis/style-rules/ide0410.md) style rule flags the Boolean flag and `goto` patterns that a labeled jump statement can replace, and shows before-and-after examples of each.

For more information, see [Jump statements](../language-reference/statements/jump-statements.md) in the language reference or the [feature specification](~/_csharplang/proposals/csharp-15.0/labeled-break-continue.md).

## Non-virtual static interface members on older runtimes

Starting in C# 15, you can declare and use non-virtual static interface members even when the target runtime doesn't support default interface implementations. For example, an interface can provide a static helper method without requiring an implementation from each implementing type:

```csharp
public interface IMeasurement
{
    public static double ToMeters(double centimeters) => centimeters / 100;
}
```

Call this helper directly on the interface, for example, `IMeasurement.ToMeters(250)`. Instance default implementations, `static abstract` and `static virtual` members, and protected interface members still require runtime support.

For more information, see [Static interface members and runtime support](../language-reference/keywords/interface.md#static-interface-members-and-runtime-support).

## Memory safety

The .NET 11 SDK includes a memory safety preview feature that begins a multirelease effort to redefine memory safety in the language. The goal is to tie the `unsafe` context to the operations that actually access unmanaged memory, rather than to the existence of pointer types. Most memory safety vulnerabilities come from these access operations, so the language makes them stand out for reviewers and auditors.

When you enable the updated rules, `unsafe` on a member marks it as *requires-unsafe*: the audit obligation flows to the caller, who must use the member from an `unsafe` context. The compiler records the assembly's use of the updated rules with the `System.Runtime.CompilerServices.MemorySafetyRulesAttribute` attribute. The model also adds a `safe` contextual keyword that marks `extern` members and fields in explicit or extended layout types as safe. Together, these rules make the boundaries of potential memory unsafety explicit across a program.

The first step includes the pointer relaxations. When you compile with the `preview` language version, the following operations no longer require an `unsafe` context:

- Declaring a pointer type and taking the address of a variable with the `&` operator.
- The `fixed` statement, which pins a variable.
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

C# 15 also adds an `unsafe` expression, `unsafe(expression)`, that establishes an unsafe context for a single expression. It's useful where an `unsafe` block can't appear syntactically, such as a field initializer, a constructor initializer, or a `catch` filter:

```csharp
class Header
{
    // A field initializer can't contain an unsafe block, but it can contain an unsafe expression.
    static readonly int Signature = unsafe(ReadSignature());

    static unsafe int ReadSignature()
    {
        int rawValue = 0x1234;
        int* pointer = &rawValue;
        return *pointer;
    }
}
```

Like the rest of the memory safety preview, `unsafe` expressions require the `preview` language version and the `AllowUnsafeBlocks` compiler option.

The compiler also recognizes the `safe` contextual keyword on declarations that can carry a safety contract, including `extern` members and fields in explicit or extended layout types. Set `LangVersion` to `preview` to enable the new syntax and pointer relaxations. To also enable the updated rules, including *requires-unsafe* caller obligations, enable the `updated-memory-safety-rules` compiler feature. For project and file-based program syntax, see [Enable the updated memory safety rules](../language-reference/compiler-options/language.md#enable-the-updated-memory-safety-rules).

For more information, see [Unsafe code, pointer types, and function pointers](../language-reference/unsafe-code.md#the-updated-memory-safety-model-preview) in the language reference or the [feature specification](~/_csharplang/proposals/unsafe-evolution.md).

## See also

- [What's new in .NET 11](../../core/whats-new/dotnet-11/overview.md)
