---
title: "Namespaces and using directives"
description: Learn how to organize C# code with namespaces, file-scoped namespace declarations, global usings, static usings, and type aliases.
ms.date: 03/16/2026
ai-usage: ai-assisted

#customer intent: As a C# developer, I want to understand namespaces and using directives so that I can organize my types and simplify how I reference them in code.

---
# Namespaces and using directives

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They introduce namespaces and `using` directives as you write your first programs.
>
> **Experienced in another language?** Namespaces in C# work similarly to packages in Java or modules in Python. Skim ahead to the syntax you need.

Namespace declarations and `using` directives are related language features. A namespace declaration puts your types into an organized structure. A namespace groups related types together and prevents naming collisions. A `using` directive lets your program consume those types by their simple names. You don't have to spell out the full namespace path at every use.

You've already used namespaces in every C# program you've written. Every .NET type belongs to a namespace, and every `using` directive at the top of a file references one. For example, `Console` and `Math` belong to the `System` namespace, so their fully qualified names are `System.Console` and `System.Math`. Collection types like `List<T>` and `Dictionary<TKey, TValue>` belong to `System.Collections.Generic`. A single `using` directive for any of these namespaces lets you refer to all its types by their simple names. You write `List<T>` instead of `System.Collections.Generic.List<T>` everywhere you use it.

This article provides more background on how namespaces and `using` directives work, and shows examples of patterns you've already encountered in .NET libraries.

A namespace contains types. Every .NET type belongs to a namespace. For example, consider `System.Threading.Tasks.Task`: the type `Task` belongs to the `System.Threading.Tasks` namespace.

It's good practice to group related or similar types in the same namespace, and that's what .NET does with the types it provides. The `System.Collections.Generic` namespace contains collection-related types and the `System.IO` namespace contains types related reading and writing files, directories, and data. The `System` namespace contains fundamental types like `Math`, `DateTime`, and `Console`.

The following example shows how namespaces work together with `using` directives in a typical C# file:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="NamespaceBasics":::

In the preceding sample, the `using` directive means you can use the <xref:System.Globalization.CultureInfo?displayProperty=nameWithType> by the name `CultureInfo` without specifying the full name of `System.Globalization.CultureInfo`. The `namespace` directive declares that the `Greeter` class is part of the `MyApp.Services` namespace. Its fully qualified name is `MyApp.Services.Greeter`.

## Namespace declarations

A namespace declaration assigns your types to a named group. Every type you write should belong to a namespace. The namespace name typically mirrors the folder structure of your project. For example, types in a `Services/Payments` folder often belong to the `MyApp.Services.Payments` namespace.

Namespaces use the `.` operator to express hierarchy, such as `System.Collections.Generic`. Namespace names must be valid C# [identifier names](../coding-style/identifier-names.md).

### File-scoped namespaces

Use the *file-scoped* syntax when all types in a file belong to the same namespace. Add a semicolon after the namespace declaration, and it applies to the entire file. You don't need extra braces or indentation:

:::code language="csharp" source="snippets/namespaces/FileScopedExample.cs" id="FileScopedNamespace":::

File-scoped namespaces reduce nesting and make files easier to read. You can only have one file-scoped namespace declaration per file.

> [!TIP]
> Use file-scoped namespaces in new code. Most .NET templates and code analyzers recommend this style.

### Block-scoped namespaces

Use *block-scoped* syntax when you need to declare more than one namespace in the same file. This style adds an extra level of indentation.

> [!IMPORTANT]
> It's considered bad-practice to declare more than one namespace in the same file. The more common scenario is to use *file-scoped* namespaces.

The following snippet is an example of a *block-scoped* namespace:

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

## Related content

- [`using` directive (language reference)](../../language-reference/keywords/using-directive.md)
- [Namespaces in the C# language specification](~/_csharpstandard/standard/namespaces.md)
