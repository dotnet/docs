---
title: "Namespaces and using directives"
description: Learn how to organize C# code with namespaces, file-scoped namespace declarations, global usings, static usings, and type aliases.
ms.date: 03/13/2026
ai-usage: ai-assisted
---
# Namespaces and using directives

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They introduce namespaces and `using` directives as you write your first programs.
>
> **Experienced in another language?** Namespaces in C# work similarly to packages in Java or modules in Python. Skim ahead to the syntax you need.

Namespace declarations and `using` directives are two sides of the same coin. A namespace declaration puts your types into an organized structure. A namespace groups related types together and prevents naming collisions. A `using` directive lets your program consume those types by their simple names. You don't have to spell out the full namespace path at every use.

Every .NET type belongs to a namespace. For example, the `System` namespace contains fundamental types like `System.Console` and `System.Math`. The `System.Collections.Generic` namespace groups collection types like `List<T>` and `Dictionary<TKey, TValue>`. The `System.Threading.Tasks` namespace holds `Task` and `ValueTask<T>` for asynchronous programming. A single `using` directive for any of these namespaces lets you refer to all its types by their simple names. You write `List<T>` instead of `System.Collections.Generic.List<T>` everywhere you use it.

The following example shows how namespaces work together with `using` directives in a typical C# file:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="NamespaceBasics":::

In the preceding sample, the `using` directive means you can use the <xref:System.Globalization.CultureInfo?displayProperty=nameWithType> by the name `CultureInfo` without specifying the full name of `System.Globalization.CultureInfo`. The `namespace` directive declares that the `Greeter` class is part of the `MyApp.Services` namespace. Its fully qualified name is `MyApp.Services.Greeter`.

## Namespace declarations

A namespace declaration assigns your types to a named group. Every type you write should belong to a namespace. The namespace name typically mirrors the folder structure of your project. For example, types in a `Services/Payments` folder often belong to the `MyApp.Services.Payments` namespace.

Namespaces use the `.` operator to express hierarchy, such as `System.Collections.Generic`. The `global` namespace is the root namespace - `global::System` always refers to the .NET <xref:System> namespace. Namespace names must be valid C# [identifier names](../coding-style/identifier-names.md).

### File-scoped namespaces

Use the *file-scoped* syntax when all types in a file belong to the same namespace. Add a semicolon after the namespace declaration, and it applies to the entire file. You don't need extra braces or indentation:

:::code language="csharp" source="snippets/namespaces/FileScopedExample.cs" id="FileScopedNamespace":::

File-scoped namespaces reduce nesting and make files easier to read. You can only have one file-scoped namespace declaration per file.

> [!TIP]
> Use file-scoped namespaces in new code. Most .NET templates and code analyzers recommend this style.

### Block-scoped namespaces

The older block-scoped syntax wraps all types in braces. This style is still valid but adds an extra level of indentation:

:::code language="csharp" source="snippets/namespaces/BlockScoped.cs" id="BlockScopedNamespace":::

## Using directives

Without a `using` directive, you must refer to every type by its *fully qualified name*, the complete namespace path plus the type name:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="FullyQualifiedName":::

A `using` directive at the top of a file imports a namespace so you can use its types by their simple names:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="UsingDirective":::

For more information, see the [`using` directive](../../language-reference/keywords/using-directive.md).

### Global using directives

If you write the same `using` directives in every file, *global using* directives let you declare them once for your entire project. Place them in any file. Many teams create a dedicated `GlobalUsings.cs` file:

:::code language="csharp" source="snippets/namespaces/GlobalUsings.cs" id="GlobalUsings":::

After declaring a global using, every file in the project can refer to types from that namespace by using simple names without an additional `using` directive.

### Implicit usings

The .NET SDK automatically generates global using directives for the most common namespaces based on your project type. Enable implicit usings by setting `<ImplicitUsings>enable</ImplicitUsings>` in your project file. For example, a console app project automatically imports `System`, `System.Collections.Generic`, `System.IO`, `System.Linq`, `System.Threading`, and `System.Threading.Tasks`. The current SDK enables `ImplicitUsings` when you create a new project by using `dotnet new`.

For more information, see [Implicit using directives](../../../core/project-sdk/overview.md#implicit-using-directives).

### Static using directives

A `static using` directive imports the static members of a type so you can call them without the type name prefix:

:::code language="csharp" source="snippets/namespaces/StaticUsing.cs" id="StaticUsing":::

Static usings work well for utility classes like <xref:System.Math> and <xref:System.Console> that you call frequently.

### Type and namespace aliases

A `using` alias creates a shorthand name for a type or namespace. Aliases are useful for long generic types, resolving naming conflicts, and improving readability:

:::code language="csharp" source="snippets/namespaces/Aliases.cs" id="TypeAlias":::

Starting with C# 12, you can alias any type, including tuples and pointer types:

:::code language="csharp" source="snippets/namespaces/TupleAlias.cs" id="AnyTypeAlias":::

For more advanced scenarios where two assemblies define the same fully qualified type name, use [extern alias](../../language-reference/keywords/extern-alias.md) to disambiguate between them.

## C# language specification

For more information, see the [Namespaces](~/_csharpstandard/standard/namespaces.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).
