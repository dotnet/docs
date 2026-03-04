---
title: "Namespaces and using directives"
description: Learn how to organize C# code with namespaces, file-scoped namespace declarations, global usings, static usings, and type aliases.
ms.date: 03/04/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "C# language, namespaces"
  - "namespaces [C#]"
  - "using directive [C#]"
  - "global using [C#]"
  - "file-scoped namespace [C#]"
---
# Namespaces and using directives

Namespaces organize C# types into logical groups and prevent naming collisions between types that share the same name. Every .NET type belongs to a namespace—`System.Console`, `System.Collections.Generic.List<T>`, and `System.Threading.Tasks.Task` are all examples. You encounter namespaces constantly, whether you're consuming .NET libraries or organizing your own code.

The following example shows how namespaces work together with `using` directives in a modern C# file:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="NamespaceBasics":::

## Using directives

Without a `using` directive, you must refer to every type by its *fully qualified name*—the complete namespace path plus the type name:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="FullyQualifiedName":::

A `using` directive at the top of a file imports a namespace so you can use its types by their short names:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="UsingDirective":::

For more information, see the [`using` directive](../../language-reference/keywords/using-directive.md).

## File-scoped namespaces

When you declare your own namespace, use the *file-scoped* syntax (introduced in C# 10). Add a semicolon after the namespace declaration, and it applies to the entire file—no extra braces or indentation needed:

:::code language="csharp" source="snippets/namespaces/FileScopedExample.cs" id="FileScopedNamespace":::

File-scoped namespaces are the recommended style for new code. They reduce nesting and make files easier to read. You can only have one file-scoped namespace declaration per file.

The older block-scoped syntax wraps all types in braces. This style is still valid but adds an extra level of indentation:

:::code language="csharp" source="snippets/namespaces/BlockScoped.cs" id="BlockScopedNamespace":::

> [!TIP]
> Use file-scoped namespaces in new code. Most .NET templates and code analyzers recommend this style.

## Global using directives

If you find yourself writing the same `using` directives in every file, *global using* directives (C# 10) let you declare them once for your entire project. Place them in any file—many teams create a dedicated `GlobalUsings.cs` file:

:::code language="csharp" source="snippets/namespaces/GlobalUsings.cs" id="GlobalUsings":::

After declaring a global using, every file in the project can use types from that namespace without an additional `using` directive.

### Implicit usings

The .NET SDK automatically generates global using directives for the most common namespaces based on your project type. Implicit usings are enabled by default when `<ImplicitUsings>enable</ImplicitUsings>` is set in your project file. For example, a console app project automatically imports `System`, `System.Collections.Generic`, `System.IO`, `System.Linq`, `System.Threading`, and `System.Threading.Tasks`.

For more information, see [Implicit using directives](../../../core/project-sdk/overview.md#implicit-using-directives).

## Static using directives

A `static using` directive (C# 6) imports the static members of a type so you can call them without the type name prefix:

:::code language="csharp" source="snippets/namespaces/StaticUsing.cs" id="StaticUsing":::

Static usings work well for utility classes like <xref:System.Math> and <xref:System.Console> that you call frequently.

## Type and namespace aliases

A `using` alias creates a shorthand name for a type or namespace. Aliases are useful for long generic types, resolving naming conflicts, and improving readability:

:::code language="csharp" source="snippets/namespaces/Aliases.cs" id="TypeAlias":::

Beginning with C# 12, you can alias any type, including tuples and pointer types:

:::code language="csharp" source="snippets/namespaces/TupleAlias.cs" id="AnyTypeAlias":::

For more advanced scenarios where two assemblies define the same fully qualified type name, you can use [extern alias](../../language-reference/keywords/extern-alias.md) to disambiguate between them.

## How namespaces organize code

Namespaces have these key properties:

- They organize large code projects into logical groups.
- They use the `.` operator to express hierarchy—for example, `System.Collections.Generic`.
- The `using` directive lets you access types without writing the full namespace path.
- The `global` namespace is the root namespace: `global::System` always refers to the .NET <xref:System> namespace.
- Namespace names must be valid C# [identifier names](../coding-style/identifier-names.md).

The namespace name typically mirrors the folder structure of your project. For example, types in a `Services/Payments` folder often belong to the `MyApp.Services.Payments` namespace.

## C# language specification

For more information, see the [Namespaces](~/_csharpstandard/standard/namespaces.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).
