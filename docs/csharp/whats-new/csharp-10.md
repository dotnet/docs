---
title: What's new in C# 10.0 - C# Guide
description: Get an overview of the new features available in C# 10.0.
ms.date: 07/06/2021
---
# What's new in C# 10.0

> [!IMPORTANT]
> This article discusses the features available in C# 10 as of .NET 6 preview 7. Documenting the enhancements for C# 10 is in progress. You can check [this project](https://github.com/dotnet/docs/projects/133) for progress on documentation.

C# 10.0 adds the following features and enhancements to the C# language (as of .NET 6 Preview 7):

- Allow `const` interpolated strings.
- Record types can seal `ToString()`.
- Allow both assignment and declaration in the same deconstruction.
- Allow `AsyncMethodBuilder` attribute on methods.
- `global using` directives.
- File-scoped namespace declaration.

Some of the features you can try are available only when you set your language version to "preview". These features may have more refinements in future previews before .NET 6.0 is released.

C# 10.0 is supported on **.NET 6**. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 6.0 SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2022 preview](https://visualstudio.microsoft.com/vs/preview/vs2022/), which includes the .NET 6.0 preview SDK.

## Global using directives

You can add the `global` modifier to any [using directive](../language-reference/keywords/using-directive.md) to instruct the compiler that the directive applies to all source files in the compilation. This is typically all source files in a project.

## File-scoped namespace declaration

You can use a new form of the [`namespace` declaration](../language-reference/keywords/namespace.md) to declare that all subsequent declarations are members of the declared namespace:

```csharp
namespace MyNamespace;
```

This new syntax saves both horizontal and vertical space for the most common `namespace` declarations.

## Constant interpolated strings

In C# 10.0, `const` strings may be initialized using [string interpolation](../language-reference/tokens/interpolated.md) if all the placeholders are themselves constant strings. String interpolation can create more readable constant strings as you build constant strings used in your application. The placeholder expressions can't be numeric constants because those constants are converted to strings at runtime. The current culture may affect their string representation. Learn more in the language reference on [`const` expressions](../language-reference/keywords/const.md).

> [!NOTE]
> When using .NET 6.0 preview 5, this feature requires setting the `<LangVersion>` element in your *csproj* file to `preview`.

## Record types can seal ToString

In C# 10.0, you can add the `sealed` modifier when you override `ToString` in a record type. Sealing the `ToString` method prevents the compiler from synthesizing a `ToString` method for any derived record types. This ensures all derived record types use the `ToString` method defined in a common base record type. You can learn more about this feature in the article on [records](../language-reference/builtin-types/record.md).

> [!NOTE]
> When using .NET 6.0 preview 5, this feature requires setting the `<LangVersion>` element in your *csproj* file to `preview`.

## Assignment and declaration in same deconstruction

This change removes a restriction from earlier versions of C#. Previously, a deconstruction could assign all values to existing variables, or initialize newly declared variables:

```csharp
// Initialization:
(int x, int y) = point;

// assignment:
int x1 = 0;
int y1 = 0;
(x1, y1) = point;
```

C# 10.0 removes this restriction:

```csharp
int x = 0;
(x, int y) = point;
```

> [!NOTE]
> When using .NET 6.0 preview 5, this feature requires setting the `<LangVersion>` element in your *csproj* file to `preview`.

## Allow AsyncMethodBuilder attribute on methods

In C# 10, you can specify a different async method builder for a single method, in addition to specifying the method builder type for all methods that return a given task-like type. This enables advanced performance tuning scenarios where a given method may benefit from a custom builder.

To learn more, see the section on [`AsyncMethodBuilder`](../language-reference/attributes/general.md#asyncmethodbuilder-attribute) in the article on attributes read by the compiler.
