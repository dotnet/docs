---
title: "Organize types with namespaces"
description: Organize C# types with block-scoped, file-scoped, and nested namespaces. Resolve name conflicts with qualification and aliases, and choose using directives.
ms.date: 11/05/2026
ms.topic: concept-article
ai-usage: ai-assisted

#customer intent: As a C# developer, I want to organize types and resolve their names so that I can use my own code and libraries without name conflicts.
---
# Organize types with namespaces

When your application and a library both define a `Product` type, a namespace distinguishes the two names. A *namespace* is a named group of related types. For example, `Shop.Catalog.Product` and `Shop.Shipping.Product` name different types even though both use the short name `Product`.

This article builds on [Namespaces and using directives](../program-structure/namespaces.md). You'll learn how to declare namespaces, refer to types unambiguously, and choose imports for a file or project.

## Declare namespaces

Use a *file-scoped namespace declaration* when all types in a file belong to the same namespace:

:::code language="csharp" source="../program-structure/snippets/namespaces/FileScopedExample.cs" id="FileScopedNamespace":::

The semicolon after `MyApp.Models` makes the declaration apply to all types that follow in the file. The fully qualified name of `Customer` is `MyApp.Models.Customer`.

A *block-scoped namespace declaration* encloses the same types in braces:

:::code language="csharp" source="../program-structure/snippets/namespaces/BlockScoped.cs" id="BlockScopedNamespace":::

These two declarations define the same type. Choose one form for the file. File-scoped syntax reduces indentation; block-scoped syntax also lets you declare multiple namespaces in one file. A file-scoped namespace can't share its file with another namespace declaration or with top-level statements.

To group related types, use the same namespace name in multiple files. Namespace names commonly mirror folders, but the compiler uses your declarations, not your folder names, to assign types to namespaces. Use valid [identifier names](../coding-style/identifier-names.md) for each part of a namespace name.

### Nested namespaces

Namespace names use dots to express a hierarchy. A *nested namespace* is a namespace declared within another namespace. You can express that relationship with a dotted name or nested blocks:

:::code language="csharp" source="../program-structure/snippets/namespaces/Products.cs" id="NestedNamespaces":::

`Shop.Catalog` uses a dotted declaration, while `Shop.Shipping` uses nested blocks. Either form can declare either namespace. The types have the fully qualified names `Shop.Catalog.Product` and `Shop.Shipping.Product`.

The hierarchy groups names; it doesn't establish inheritance between the types. A namespace declaration doesn't grant access to another type's private members.

### The global namespace

Types declared outside a named namespace belong to the *global namespace*, the unnamed namespace that contains all named namespaces. Use named namespaces for your application's types so their names communicate where they belong.

If another name hides the first part of a namespace name, the `global::` prefix starts name lookup at the global namespace. For example, `global::System.Console` explicitly selects `Console` in the top-level `System` namespace. For the detailed rules, see [Namespace alias qualifier](../../language-reference/operators/namespace-alias-qualifier.md).

## Refer to types

To select a type without an import, use its *fully qualified name*, which includes its namespace and type name. The following code uses both `Product` types from the preceding example:

:::code language="csharp" source="../program-structure/snippets/namespaces/ProductNames.cs" id="QualifiedNames":::

Qualification makes the choice explicit at each use. For types you use repeatedly, imports or aliases can keep the code shorter.

### Using directives

A *using directive* imports the types in a namespace so you can use their short names:

:::code language="csharp" source="../program-structure/snippets/namespaces/Imports.cs" id="UsingDirective":::

The directive lets you write `StringBuilder` instead of `System.Text.StringBuilder`. It applies to name lookup in the source code; it doesn't copy the types or change their namespace.

An import covers the types in the named namespace, not its nested namespaces. For example, `using System;` lets you write `Console`, but to write `List<int>` you need an import for `System.Collections.Generic` or the fully qualified name `System.Collections.Generic.List<int>`.

Place file-level `using` directives before namespace and type declarations. You can also place directives inside a namespace, before its declarations, to limit the import to that namespace body. With a file-scoped namespace, a directive before the `namespace` line is outside the namespace; a directive after it is inside. Placement also affects how names in the directive are resolved. For detailed scope and name-lookup rules, see the [`using` directive reference](../../language-reference/keywords/using-directive.md).

### Type and namespace aliases

If you import both `Shop.Catalog` and `Shop.Shipping`, the short name `Product` is ambiguous. To identify each type without repeating its full name, define a *using alias*, an alternative name for a type or namespace:

:::code language="csharp" source="../program-structure/snippets/namespaces/ProductNames.cs" id="Aliases":::

The two type aliases name the same types used in the qualified example. `Shipping` instead names a namespace, so `Shipping.Product` selects a type within that namespace. An alias changes how you refer to a type; it doesn't declare a new type.

Aliases also help shorten long type names:

:::code language="csharp" source="../program-structure/snippets/namespaces/Aliases.cs" id="TypeAlias":::

You can alias tuple types as well as named types:

:::code language="csharp" source="../program-structure/snippets/namespaces/TupleAlias.cs" id="AnyTypeAlias":::

For the less common case where two assemblies define the same fully qualified type name, see [`extern alias`](../../language-reference/keywords/extern-alias.md).

## Choose imports for a project

A regular `using` directive affects its file or the namespace body that contains it. For imports shared across source files, use explicit global directives or the .NET SDK's implicit usings.

### Global using directives

A *global using directive* applies an import to every source file in the same compilation, typically one project. Instead of repeating `using System.Text;` in each file, put this directive in a file such as `GlobalUsings.cs`:

:::code language="csharp" source="../program-structure/snippets/namespaces/GlobalUsings.cs" id="GlobalUsings":::

Another file in the project can then use `StringBuilder` without its own import:

:::code language="csharp" source="../program-structure/snippets/namespaces/GlobalMessage.cs" id="GlobalUsingConsumer":::

Place global directives before any regular `using` directives, namespaces, or types in their file. A global import doesn't apply to other projects that reference your project.

### Implicit usings

*Implicit usings* are global using directives generated by the .NET SDK according to your project type. They're a project setting, not a C# rule that imports namespaces automatically. In an SDK-style project, enable them with:

```xml
<ImplicitUsings>enable</ImplicitUsings>
```

For example, console project templates enable imports that include `System`, `System.Collections.Generic`, and `System.Linq`. Those generated directives let you use `Console`, `List<T>`, and LINQ extension methods without repeating imports in each file. Other SDKs can generate a different set of imports.

To manage every import explicitly, set `ImplicitUsings` to `disable` and add regular or global directives for the namespaces you need. Disabling implicit usings doesn't disable global directives you wrote yourself.

The examples in this article belong to a console project with implicit usings enabled. Its explicit `global using System.Text;` adds an import beyond the console SDK's default set. For the default lists and project configuration options, see [Implicit using directives](../../../core/project-sdk/overview.md#implicit-using-directives).

### Static using directives

A *using static directive* imports accessible static members and nested types from a type rather than types from a namespace:

:::code language="csharp" source="../program-structure/snippets/namespaces/StaticUsing.cs" id="StaticUsing":::

Here, `PI` and `Pow` name members of `System.Math`. Use this form when those short names make the calculation easier to read. Keep the type prefix when it helps readers recognize which type supplies a member. For detailed rules, see [`using static`](../../language-reference/keywords/using-directive.md#the-static-modifier).

## Imports aren't references

To use a library's types, your project needs a reference to the code that defines them. An *assembly* is a compiled unit of .NET code, usually a `.dll` or `.exe`. A *package* distributes libraries and other assets, often through NuGet.

A namespace and an assembly aren't the same boundary. One assembly can contain types in many namespaces, and types in one namespace can come from multiple assemblies.

| Mechanism | Purpose |
|---|---|
| `using`, aliases, and `global using` | Control how source code refers to available types and members. |
| SDK implicit usings | Generate global directives for common namespaces. |
| Project, package, and assembly references | Make another project's or library's types available to the compiler. |

For example, `using System.Text;` works because the project's framework references already provide `StringBuilder`. To use a type from an additional library, first add the appropriate [project or assembly reference](../../../core/tools/dotnet-reference-add.md) or [package reference](../../../core/tools/dotnet-package-add.md) to your project. Then use a directive, an alias, or the fully qualified name. Adding an import doesn't download a package, and writing a fully qualified name doesn't remove the need for a reference.

## Related content

- [`namespace` keyword](../../language-reference/keywords/namespace.md)
- [`using` directive](../../language-reference/keywords/using-directive.md)
- [Namespaces in the C# language specification](~/_csharpstandard/standard/namespaces.md)
