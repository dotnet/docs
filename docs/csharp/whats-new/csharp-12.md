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

## Primary constructors

You can now create primary constructors in any `class` and `struct`. Primary constructors are no longer restricted to `record` types. Primary constructor parameters are in scope for the entire body of the class. To ensure that all primary constructor parameters are definitely assigned, all explicitly declared constructors must call the primary constructor using `this()` syntax. Adding a primary constructor to a `class` prevents the compiler from declaring an implicit parameterless constructor. In a `struct`, the implicit parameterless constructor initializes all fields, including primary constructor parameters to the 0-bit pattern.

The compiler generates public properties for primary constructor parameters only in `record` types, either `record class` or `record struct` types. Non-record classes and structs may not always want this behavior for primary constructor parameters.

You can learn more about primary constructors in the tutorial for [exploring primary constructors](./tutorials/primary-constructors.md) and in the article on [instance constructors](../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors).

## Default lambda parameters

You can now define default values for parameters on lambda expressions. The syntax and rules are the same as adding default values for arguments to any method or local function.

You can learn more about default parameters on lambda expressions in the article on [lambda expressions](../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression).

## Alias any type

You can use the `using` alias directive to alias any type, not just named types. That means you can create semantic aliases for tuple types, array types, pointer types, or other unsafe types. For more information, see the [feature specification](~/_csharplang/proposals/using-alias-types.md)

## See also

- [What's new in .NET 8](../../core/whats-new/dotnet-8.md)
