---
title: What's new in C# 12 - C# Guide
description: Get an overview of the new features in C# 12.
ms.date: 04/04/2023
---
# What's new in C# 12

Some C# 12 features have been introduced in previews. You can try these features using the latest [Visual Studio preview](https://visualstudio.microsoft.com/vs/preview/) or the latest [.NET 8 preview SDK](https://dotnet.microsoft.com/download/dotnet).

- [Primary constructors](#primary-constructors) - Introduced in Visual Studio 17.6 preview 2.
- [Optional parameters in lambda expressions](#default-lambda-parameters) - Introduced in Visual Studio 17.5 preview 2.
- [Alias any type](#alias-any-type) - Introduced in Visual Studio 17.6 preview 3.
- [Interceptors](#interceptors) - *Preview feature* Introduced in Visual Studio 17.7, preview 3.

## Primary constructors

You can now create primary constructors in any `class` and `struct`. Primary constructors are no longer restricted to `record` types. Primary constructor parameters are in scope for the entire body of the class. To ensure that all primary constructor parameters are definitely assigned, all explicitly declared constructors must call the primary constructor using `this()` syntax. Adding a primary constructor to a `class` prevents the compiler from declaring an implicit parameterless constructor. In a `struct`, the implicit parameterless constructor initializes all fields, including primary constructor parameters to the 0-bit pattern.

The compiler generates public properties for primary constructor parameters only in `record` types, either `record class` or `record struct` types. Non-record classes and structs may not always want this behavior for primary constructor parameters.

You can learn more about primary constructors in the tutorial for [exploring primary constructors](./tutorials/primary-constructors.md) and in the article on [instance constructors](../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors).

## Default lambda parameters

You can now define default values for parameters on lambda expressions. The syntax and rules are the same as adding default values for arguments to any method or local function.

You can learn more about default parameters on lambda expressions in the article on [lambda expressions](../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression).

## Alias any type

You can use the `using` alias directive to alias any type, not just named types. That means you can create semantic aliases for tuple types, array types, pointer types, or other unsafe types. For more information, see the [feature specification](~/_csharplang/proposals/using-alias-types.md)

## Interceptors

> [!WARNING]
> Interceptors are an experimental feature, available in preview mode with C# 12. The feature may be subject to breaking changes or removal in a future release. Therefore, it is not recommended for production or released applications.
>
> In order to use interceptors, you'll need to set the `<Features>InterceptorsPreview<Features>` element in your project file. Without this flag, interceptors are disabled, even when other C# 12 features are enabled.

An *interceptor* is a method which can declaratively substitute a call to an *interceptable* method with a call to itself at compile time. This substitution occurs by having the interceptor declare the source locations of the calls that it intercepts. This provides a limited facility to change the semantics of existing code by adding new code to a compilation, for example in a source generator.

You use an *interceptor* as part of a source generator to modify, rather than add code to an existing soruce compilation. The source generator substitutes calls to an interceptable method with a call to the *interceptor* method.

If you are interested in experimenting with interceptors, you can learn more by reading the [feature specification](https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md). If you use the feature, make sure to stay current with any changes in the feature specification for this preview feature. Once the feature is finalized, we'll add more guidance on this site.

## See also

- [What's new in .NET 8](../../core/whats-new/dotnet-8.md)
