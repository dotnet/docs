---
title: "Organize types with namespaces"
description: Organize C# types with block-scoped, file-scoped, and nested namespaces. Resolve name conflicts with qualification and aliases, and choose using directives.
ms.date: 11/09/2026
ms.topic: concept-article
ai-usage: ai-assisted

#customer intent: As a C# developer, I want to group related types and refer to them clearly so that my code stays organized as my program grows. I also want to use namespaces in a consistent fashion.
---
# Organize types with namespaces

As your program grows, you create more types. You need a way to organize all the different types you created. A *namespace* is a named group of related types. Namespaces help you organize types by functionality and show how your code fits together.

For example, place catalog types in `Shop.Catalog` and shipping types in `Shop.Shipping`.

This article builds on [Namespaces and `using` directives](../program-structure/namespaces.md). You'll learn how to declare namespaces, refer to types unambiguously, and choose imports for a file or project.

## The global namespace

Small programs often start without a namespace declaration. The types belong to the *global namespace*. The *global namespace* is the unnamed namespace that contains all declared types and namespaces. When you create file-based apps and other apps with [top-level statements](../program-structure/top-level-statements.md), those types belong to the global namespace.

As your program grows, use named namespaces to group the types you add by their roles.

## Declare namespaces

Most source files contain types from a single namespace, and many contain only one type. For this common layout, use a *file-scoped namespace declaration*:

:::code language="csharp" source="../program-structure/snippets/namespaces/FileScopedExample.cs" id="FileScopedNamespace":::

The semicolon after `MyApp.Models` makes the declaration apply to all types that follow in the file. The *fully qualified name* of `Customer` is `MyApp.Models.Customer`: its namespace name followed by its type name.

A *block-scoped namespace declaration* encloses the same types in braces:

:::code language="csharp" source="../program-structure/snippets/namespaces/BlockScoped.cs" id="BlockScopedNamespace":::

These two declarations define the same type. Choose one form for the file. File-scoped syntax reduces indentation; block-scoped syntax also lets you declare multiple namespaces in one file. A file-scoped namespace can't share its file with another namespace declaration or with top-level statements.

The same namespace declaration can appear multiple times in your program. All types in matching declarations belong to the same namespace.

Namespace names commonly mirror folders, but the compiler uses your declarations, not your folder names, to assign types to namespaces. You must use valid [identifier names](../coding-style/identifier-names.md) for each part of a namespace name.

### Nested namespaces

Components of a namespace name are separated by a period (`.`) and express a hierarchy. A *nested namespace* is a namespace declared within another namespace. You can declare a multicomponent namespace by nesting namespace declarations or by using all components in one declaration. For the same components, both forms are equivalent:

:::code language="csharp" source="../program-structure/snippets/namespaces/Products.cs" id="NestedNamespaces":::

`Shop.Catalog` uses a dotted declaration, while `Shop.Shipping` uses nested blocks. Either form can declare either namespace. The types have the fully qualified names `Shop.Catalog.Product` and `Shop.Shipping.Product`.

The hierarchy groups names; it doesn't establish inheritance between the types. A namespace declaration doesn't grant access to another type's private members.

## Refer to types

To select a type, use its fully qualified name, which includes its namespace and type name. The following code uses both `Product` types from the preceding example:

:::code language="csharp" source="../program-structure/snippets/namespaces/ProductNames.cs" id="QualifiedNames":::

Qualification makes the choice explicit at each use. Repeating the full name can become cumbersome, so use a `using` directive to refer to a type by its simple name.

### Using directives

A *using directive* imports the types in a namespace so you can use their *simple names*, without the namespace prefix:

:::code language="csharp" source="../program-structure/snippets/namespaces/Imports.cs" id="UsingDirective":::

The directive lets you write `StringBuilder` instead of `System.Text.StringBuilder`. It applies to name lookup in the source code; it doesn't copy the types or change their namespace.

A *`using` directive* imports the types directly in the named namespace, not its nested namespaces. For example, `using System;` lets you write `Console` because its fully qualified name is `System.Console`. However, you can't use `List<int>` by its simple name because its fully qualified name is `System.Collections.Generic.List<int>`. You need to add a `using` directive for `System.Collections.Generic`.

### Type and namespace aliases

If you import both `Shop.Catalog` and `Shop.Shipping`, the simple name `Product` is ambiguous. To identify each type without repeating its full name, define a *using alias*, an alternative name for a type or namespace:

:::code language="csharp" source="../program-structure/snippets/namespaces/ProductNames.cs" id="Aliases":::

The two type aliases name the same types used in the qualified example. `Shipping` instead names a namespace, so `Shipping.Product` selects a type within that namespace. An alias changes how you refer to a type; it doesn't declare a new type.

Aliases also help shorten long type names:

:::code language="csharp" source="../program-structure/snippets/namespaces/Aliases.cs" id="TypeAlias":::

You can alias tuple types as well as named types:

:::code language="csharp" source="../program-structure/snippets/namespaces/TupleAlias.cs" id="AnyTypeAlias":::

If another name hides the first part of a namespace name, the `global::` prefix starts name lookup at the global namespace. For example, `global::System.Console` explicitly selects `Console` in the top-level `System` namespace. For the detailed rules, see [Namespace alias qualifier](../../language-reference/operators/namespace-alias-qualifier.md).

For the less common case where two assemblies define the same fully qualified type name, see [`extern alias`](../../language-reference/keywords/extern-alias.md).

## Choose imports for a project

Choose imports according to how widely you need a namespace or type throughout your project.

> [!NOTE]
> Imports control the names you write, not which libraries your project can use. To use types from another library, first add the appropriate [project or assembly reference](../../../core/tools/dotnet-reference-add.md) or [package reference](../../../core/tools/dotnet-package-add.md). A fully qualified name doesn't replace that reference.

### Implicit usings

*Implicit usings* provide a default set of imports based on your project type. The .NET SDK generates these imports as global `using` directives, so they apply throughout your project. New console projects enable them with this setting:

```xml
<ImplicitUsings>enable</ImplicitUsings>
```

For example, console project templates enable imports that include `System`, `System.Collections.Generic`, and `System.Linq`. Those generated directives let you use `Console`, `List<T>`, and LINQ extension methods without repeating imports in each file. Other SDKs can generate a different set of imports.

To manage every import explicitly, set `ImplicitUsings` to `disable` and add regular or global directives for the namespaces you need. Disabling implicit usings doesn't disable global directives you wrote yourself.

The examples in this article belong to a console project with implicit usings enabled. For the default lists and project configuration options, see [Implicit `using` directives](../../../core/project-sdk/overview.md#implicit-using-directives).

### Global using directives

Add [*global using directives*](../../../core/tutorials/top-level-templates.md#global-using-directives) for other namespaces used throughout your project, such as shared company libraries. A global `using` directive applies an import to every source file in the same compilation, typically one project.

For example, `System.Text` isn't in the console SDK's default imports. Instead of repeating `using System.Text;` in each file, put this directive in a file such as `GlobalUsings.cs`:

:::code language="csharp" source="../program-structure/snippets/namespaces/GlobalUsings.cs" id="GlobalUsings":::

Another file in the project can then use `StringBuilder` without its own import:

:::code language="csharp" source="../program-structure/snippets/namespaces/GlobalMessage.cs" id="GlobalUsingConsumer":::

Place global directives before any regular `using` directives, namespaces, or types in their file. A global import doesn't apply to other projects that reference your project.

### Regular using directives

Add regular `using` directives for namespaces that only a particular file or algorithm needs. A regular directive affects its file or the namespace body that contains it.

Place file-level `using` directives before namespace and type declarations. You can also place directives inside a namespace, before its declarations, to limit the import to that namespace body. With a file-scoped namespace, a directive before the `namespace` line is outside the namespace; a directive after it is inside. Placement also affects how names in the directive are resolved. For detailed scope and name-lookup rules, see the [`using` directive reference](../../language-reference/keywords/using-directive.md).

### Static using directives

Use a *`using static` directive* for a special-purpose utility type whose static members are clear without the type name. It imports accessible static members and nested types from a type rather than types from a namespace:

:::code language="csharp" source="../program-structure/snippets/namespaces/StaticUsing.cs" id="StaticUsing":::

Here, `PI` and `Pow` name members of `System.Math`. Keep the type prefix when it helps readers recognize which type supplies a member. For detailed rules, see [`using static`](../../language-reference/keywords/using-directive.md#the-static-modifier).

Small programs don't need named namespace declarations. As programs grow, think about how to organize names into namespaces. Prefer file-scoped namespace declarations in your code. Choose imports according to where you need them: global directives for namespaces used throughout your project, and regular directives for those needed in individual files.

## Related content

- [`namespace` keyword](../../language-reference/keywords/namespace.md)
- [`using` directive](../../language-reference/keywords/using-directive.md)
- [Namespaces in the C# language specification](~/_csharpstandard/standard/namespaces.md)
