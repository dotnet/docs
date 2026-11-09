---
title: "Namespaces and using directives"
description: Learn how C# namespaces organize types and how using directives let you refer to those types by their simple names.
ms.date: 11/05/2026
ms.topic: concept-article
ai-usage: ai-assisted

#customer intent: As a developer new to C#, I want to recognize namespace declarations and using directives so that I can understand the structure of a C# program.
---
# Namespaces and using directives

A C# file often starts with `using` directives followed by a `namespace` declaration:

:::code language="csharp" source="snippets/namespaces/Basics.cs" id="NamespaceBasics":::

The example declares `Greeter` in the `MyApp.Services` namespace. Its complete name is `MyApp.Services.Greeter`. The `using System;` directive lets the code refer to types such as `Console` by their simple names.

## Namespace declarations

A *namespace* is a named group of related types, such as classes, structs, and interfaces. Namespaces help you organize code and distinguish types with the same simple name. For example, your application can declare its own `Timer` without conflicting with a library's `Timer` when the types belong to different namespaces.

Use the `namespace` keyword to place your types in a namespace. The example uses a *file-scoped namespace declaration*: the semicolon after `MyApp.Services` makes the declaration apply to all types that follow in the file. Another form uses braces to enclose the types in a namespace.

Namespace names often match project folders, but C# doesn't require that convention. The declaration in your source code determines a type's namespace. Types declared outside a named namespace belong to the *global namespace*, the unnamed namespace that contains all named namespaces.

## Using directives

A *using directive* lets you refer to types from a namespace without repeating the namespace name. For example, both of these statements call the same method:

```csharp
System.Console.WriteLine("Hello!");
Console.WriteLine("Hello!"); // With using System;
```

`System.Console` is a *fully qualified name*: it includes both the namespace and the type name. A `using` directive changes how you write the name, not which type you use. It also doesn't add a library or package to your project. Your project must already have access to the types.

In a new console project, `Console` often works without an explicit `using System;`. The .NET SDK can generate common imports for you through the project's `ImplicitUsings` setting.

To declare namespaces, resolve name conflicts, and choose between file-local, global, and SDK-generated imports, continue with [Organize types with namespaces](../namespaces/overview.md).

## Related content

- [`namespace` keyword](../../language-reference/keywords/namespace.md)
- [`using` directive](../../language-reference/keywords/using-directive.md)
