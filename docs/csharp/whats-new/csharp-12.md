---
title: What's new in C# 12 - C# Guide
description: Get an overview of the new features in C# 12.
ms.date: 09/23/2023
---
# What's new in C# 12

Some C# 12 features have been introduced in previews. You can try these features using the latest [Visual Studio preview](https://visualstudio.microsoft.com/vs/preview/) or the latest [.NET 8 preview SDK](https://dotnet.microsoft.com/download/dotnet).

- [Primary constructors](#primary-constructors) - Introduced in Visual Studio 17.6, preview 2.
- [Collection expressions](#collection-expressions) - Introduced in Visual Studio 17.7, preview 5.
- [Inline arrays](#inline-arrays) - Introduced in Visual Studio 17.7, preview 3.
- [Optional parameters in lambda expressions](#default-lambda-parameters) - Introduced in Visual Studio 17.5, preview 2.
- [`ref readonly` parameters](#ref-readonly-parameters) - Introduced in Visual Studio 17.8, preview 2.
- [Alias any type](#alias-any-type) - Introduced in Visual Studio 17.6, preview 3.

- [Interceptors](#interceptors) - *Preview feature* Introduced in Visual Studio 17.7, preview 3.

## Primary constructors

You can now create primary constructors in any `class` and `struct`. Primary constructors are no longer restricted to `record` types. Primary constructor parameters are in scope for the entire body of the class. To ensure that all primary constructor parameters are definitely assigned, all explicitly declared constructors must call the primary constructor using `this()` syntax. Adding a primary constructor to a `class` prevents the compiler from declaring an implicit parameterless constructor. In a `struct`, the implicit parameterless constructor initializes all fields, including primary constructor parameters to the 0-bit pattern.

The compiler generates public properties for primary constructor parameters only in `record` types, either `record class` or `record struct` types. Non-record classes and structs may not always want this behavior for primary constructor parameters.

You can learn more about primary constructors in the tutorial for [exploring primary constructors](./tutorials/primary-constructors.md) and in the article on [instance constructors](../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors).

## Collection expressions

Collection expressions introduce a new terse syntax to create common collection values. Inlining other collections into these values is possible using a spread operator `..`.

Several collection-like types can be created without requiring external BCL support.  These types are:

* Array types, such as `int[]`.
* <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.
* Types that support collection initializers, such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>.

The following examples show uses of collection expressions:

```csharp
// Create an array:
int[] a = [1, 2, 3, 4, 5, 6, 7, 8];

// Create a span
Span<int> b  = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];

// Create a 2 D array:
int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

// create a 2 D array from variables:
int[] row0 = [1, 2, 3];
int[] row1 = [4, 5, 6];
int[] row2 = [7, 8, 9];
int[][] twoDFromVariables = [row0, row1, row2];

```

The *spread operator*, `..` in a collection expression replaces its argument with the elements from that collection. The argument must be a collection type. The following examples show how the spread operator works:

```csharp
int[] row0 = [1, 2, 3];
int[] row1 = [4, 5, 6];
int[] row2 = [7, 8, 9];
int[] single = [..row0, ..row1, ..row2];
foreach (var element in single)
{
    Console.Write($"{element}, ");
}
// output:
// 1, 2, 3, 4, 5, 6, 7, 8, 9,
```

The operand of a spread operator is an expression that can be enumerated. The spread operator evaluates each element of the enumerations expression.

You can use collection expressions anywhere you need a collection of elements. They can specify the initial value for a collection or be passed as arguments to methods that take collection types. You can learn more about collection expressions in the [language reference article on collection expressions](../language-reference/operators/collection-expressions.md) or the [feature specification](~/_csharplang/proposals/csharp-12.0/collection-expressions.md).

## `ref readonly` parameters

C# added `in` parameters as a way to pass readonly references. `in` parameters allow both variables and values, and can be used without any annotation on arguments.

The addition of `ref readonly` parameters enables more clarity for APIs that might be using `ref` parameters or `in` parameters:

- APIs created before `in` was introduced might use `ref` even though the argument isn't modified. Those APIs can be updated with `ref readonly`. It won't be a breaking change for callers, as would be if the `ref` parameter was changed to `in`. An example is <xref:System.Runtime.InteropServices.Marshal.QueryInterface%2A?displayProperty=fullName>.
- APIs that take an `in` parameter, but logically require a variable. A value expression won't work. An example is <xref:System.ReadOnlySpan%601.%23ctor(%600@)?displayProperty=fullName>.
- APIs that use `ref` because they require a variable, but don't mutate that variable. An example is <xref:System.Runtime.CompilerServices.Unsafe.IsNullRef%2A?displayProperty=fullName>.

To learn more about `ref readonly` parameters, see the article on [parameter modifiers](../language-reference/keywords/method-parameters.md#ref-readonly-modifier) in the language reference, or the [ref readonly parameters](~/_csharplang/proposals/csharp-12.0/ref-readonly-parameters.md) feature specification.

## Default lambda parameters

You can now define default values for parameters on lambda expressions. The syntax and rules are the same as adding default values for arguments to any method or local function.

You can learn more about default parameters on lambda expressions in the article on [lambda expressions](../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression).

## Alias any type

You can use the `using` alias directive to alias any type, not just named types. That means you can create semantic aliases for tuple types, array types, pointer types, or other unsafe types. For more information, see the [feature specification](~/_csharplang/proposals/csharp-12.0/using-alias-types.md).

## Inline arrays

Inline arrays are used by the runtime team and other library authors to improve performance in your apps. Inline arrays enable a developer to create an array of fixed size in a `struct` type. A struct with an inline buffer should provide performance characteristics similar to an unsafe fixed size buffer. You likely won't declare your own inline arrays, but you'll use them transparently when they're exposed as <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> objects from runtime APIs.

An *inline array* is declared similar to the following `struct`:

```csharp
[System.Runtime.CompilerServices.InlineArray(10)]
public struct Buffer
{
    private int _element0;
}
```

You use them like any other array:

```csharp
var buffer = new Buffer();
for (int i = 0; i < 10; i++)
{
    buffer[i] = i;
}

foreach (var i in buffer)
{
    Console.WriteLine(i);
}
```

The difference is that the compiler can take advantage of known information about an inline array. You'll likely consume inline arrays as you would any other array. For more information on how to declare inline arrays, see the language reference on [`struct` types](../language-reference/builtin-types/struct.md#inline-arrays).

## Interceptors

> [!WARNING]
> Interceptors are an experimental feature, available in preview mode with C# 12. The feature may be subject to breaking changes or removal in a future release. Therefore, it is not recommended for production or released applications.
>
> In order to use interceptors, you'll need to set the `<Features>InterceptorsPreview</Features>` element in your project file. Without this flag, interceptors are disabled, even when other C# 12 features are enabled.

An *interceptor* is a method that can declaratively substitute a call to an *interceptable* method with a call to itself at compile time. This substitution occurs by having the interceptor declare the source locations of the calls that it intercepts. Interceptors provides a limited facility to change the semantics of existing code by adding new code to a compilation, for example in a source generator.

You use an *interceptor* as part of a source generator to modify, rather than add code to an existing source compilation. The source generator substitutes calls to an interceptable method with a call to the *interceptor* method.

If you're interested in experimenting with interceptors, you can learn more by reading the [feature specification](https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md). If you use the feature, make sure to stay current with any changes in the feature specification for this preview feature. Once the feature is finalized, we'll add more guidance on this site.

## See also

- [What's new in .NET 8](../../core/whats-new/dotnet-8.md)
