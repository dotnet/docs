---
title: "Program organization"
description: Learn how to organize C# programs using solutions, projects, assemblies, namespaces, and types to build maintainable, well-structured applications.
ms.date: 03/13/2026
ai-usage: ai-assisted
---
# Program organization

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll learn about program organization naturally as your projects grow.
>
> **Experienced in another language?** If you're familiar with solutions and projects in Visual Studio, or build systems like Maven or Cargo, this article maps those concepts to .NET.

As a C# application grows, you need to organize the code. .NET provides a hierarchy of organizational tools—solutions, projects, assemblies, namespaces, and types—that work together to keep large codebases manageable. The conventions described here represent broad consensus in the .NET community. You might deviate for specific reasons, but following these conventions makes your code familiar and navigable to other .NET developers.

## The organizational hierarchy

Organize a typical .NET application in layers, from broadest to most specific:

| Level         | Description                                         | Example                 |
|---------------|-----------------------------------------------------|-------------------------|
| **Solution**  | A container that groups related projects            | `MyApp.slnx`            |
| **Project**   | A build unit that produces one assembly             | `MyApp.Web.csproj`      |
| **Assembly**  | The compiled `.dll` or `.exe` produced by a project | `MyApp.Web.dll`         |
| **Namespace** | A logical grouping of types                         | `MyApp.Web.Controllers` |
| **Type**      | A class, struct, interface, enum, or delegate       | `OrderController`       |

Each level serves a different purpose. Solutions organize your development workflow. Projects define what gets compiled together, and each project produces one assembly. Assemblies are the unit of deployment and versioning. Namespaces prevent naming collisions and make types easy to find. A single assembly can contain multiple namespaces, and a single namespace can span multiple assemblies. Types define the actual behavior and data.

## Projects and assemblies

Each project compiles into a single assembly: a class library or executable. Start with a single project for small applications—don't split prematurely. Add projects when you have a concrete reason:

- **Separate concerns** — keep your data access, business logic, and presentation layers independent.
- **Share code** — create a class library that multiple applications reference.
- **Control dependencies** — a project can only use types from projects it explicitly references.

A single project works well for many applications. Resist the urge to create separate projects "just in case." You can always refactor later when the need is clear.

The following project structure demonstrates a common pattern:

:::code language="csharp" source="snippets/organizing-programs/AppDemo.cs" id="ProjectStructure":::

Create and reference projects by using the `dotnet` CLI:

```dotnetcli
dotnet new classlib -n MyApp.Core
dotnet new console -n MyApp.Console
dotnet add MyApp.Console reference MyApp.Core
```

## Match namespaces to folder structure

Namespace names should follow the folder structure of your project. When you see `MyApp.Services.Payments`, you know to look in the `Services/Payments` folder. This convention is so widely followed that violating it actively confuses other developers:

:::code language="csharp" source="snippets/organizing-programs/OrderService.cs" id="NamespaceMirroring":::

The .NET SDK supports this convention. When you set `<RootNamespace>` in your project file (or accept the default, which matches the project name), the compiler uses it as the base namespace. Types in subfolders don't automatically get sub-namespaces—you declare the namespace explicitly in each file—but always keep them in sync.

## Organize namespaces by feature, not by type kind

Group related types into namespaces by feature or responsibility. Place an interface, its implementations, and supporting types together:

:::code language="csharp" source="snippets/organizing-programs/Payments.cs" id="FeatureOrganization":::

Feature-based organization keeps everything you need in one place, making the code easier to navigate and reason about.

## Access modifiers and assemblies

Access modifiers work with the project and assembly structure to control accessibility:

- [`public`](../../language-reference/keywords/public.md) — accessible from any assembly that references this assembly.
- [`internal`](../../language-reference/keywords/internal.md) — accessible only within the same assembly (the default for top-level types).
- [`private`](../../language-reference/keywords/private.md), [`protected`](../../language-reference/keywords/protected.md), [`private protected`](../../language-reference/keywords/private-protected.md), [`protected internal`](../../language-reference/keywords/protected-internal.md) — accessible based on the containing type, the assembly, or derived types.

Default to `internal` for types that other projects don't need. This practice hides implementation details and gives you freedom to refactor without breaking consumers. It's especially important for shared libraries:

:::code language="csharp" source="snippets/organizing-programs/Inventory.cs" id="AccessModifiers":::

## Recommended practices

- **Name namespaces consistently.** Use `CompanyName.ProductName.Feature` as your naming pattern. For example, use `Contoso.Inventory.Shipping`. Consistent naming helps developers find types without searching.
- **Keep projects focused.** Each project should have a single, clear responsibility. When a project handles too many unrelated concerns, split it.
- **Use file-scoped namespaces.** The `namespace MyApp.Services;` syntax reduces indentation and is the recommended style. Use it in all new code.
- **Use `global using` directives.** Place common imports in a `GlobalUsings.cs` file to eliminate repetitive `using` lines across files. For more information, see [Namespaces and using directives](namespaces.md).
- **Default to `internal`.** Only mark types `public` when other assemblies genuinely need them. You can always widen access later; narrowing it is a breaking change.

## See also

- [Namespaces and using directives](namespaces.md) — declare namespaces, import types with `using`, and configure global usings.
- [Assemblies in .NET](../../../standard/assembly/index.md) — learn about assemblies, versioning, and deployment.
- [.NET project SDKs](../../../core/project-sdk/overview.md) — view project file settings including `RootNamespace` and `ImplicitUsings`.
