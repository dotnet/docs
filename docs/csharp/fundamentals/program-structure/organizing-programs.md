---
title: "Organizing programs"
description: Learn how to organize C# programs using solutions, projects, assemblies, namespaces, and types to build maintainable, well-structured applications.
ms.date: 03/04/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "C# language, program organization"
  - "assemblies [C#]"
  - "namespaces [C#], organizing"
  - "solutions [C#]"
---
# Organizing programs

As a C# application grows, you need a clear strategy for organizing code. .NET provides a hierarchy of organizational tools—solutions, projects, assemblies, namespaces, and types—that work together to keep large codebases manageable.

## The organizational hierarchy

A typical .NET application is organized in layers, from broadest to most specific:

| Level | What it is | Example |
|---|---|---|
| **Solution** | A container that groups related projects | `MyApp.sln` |
| **Project** | A build unit that produces one assembly | `MyApp.Web.csproj` |
| **Assembly** | A compiled `.dll` or `.exe` file | `MyApp.Web.dll` |
| **Namespace** | A logical grouping of types within an assembly | `MyApp.Web.Controllers` |
| **Type** | A class, struct, interface, enum, or delegate | `OrderController` |

Each level serves a different purpose. Solutions organize your development workflow. Projects define what gets compiled together. Assemblies are the unit of deployment and versioning. Namespaces prevent naming collisions and make types discoverable. Types define the actual behavior and data.

## Projects and assemblies

Each project compiles into a single assembly—a `.dll` (class library) or `.exe` (executable). Split your code into multiple projects when you want to:

- **Separate concerns** — keep your data access, business logic, and presentation layers independent.
- **Share code** — create a class library that multiple applications reference.
- **Control dependencies** — a project can only use types from projects it explicitly references.

The following project structure demonstrates a common pattern:

:::code language="csharp" source="snippets/organizing-programs/AppDemo.cs" id="ProjectStructure":::

Create and reference projects with the `dotnet` CLI:

```bash
dotnet new classlib -n MyApp.Core
dotnet new console -n MyApp.Console
dotnet add MyApp.Console reference MyApp.Core
```

## Namespaces mirror folder structure

By convention, namespace names follow the folder structure of your project. This convention makes types easy to find—when you see `MyApp.Services.Payments`, you know to look in the `Services/Payments` folder:

:::code language="csharp" source="snippets/organizing-programs/OrderService.cs" id="NamespaceMirroring":::

The .NET SDK supports this convention automatically. When you set `<RootNamespace>` in your project file (or accept the default, which matches the project name), the compiler uses it as the base namespace. Types in subfolders don't automatically get sub-namespaces—you declare the namespace explicitly in each file—but following the convention keeps your codebase predictable.

## Choosing how to split namespaces

Group related types into namespaces by feature or responsibility, not by type kind. For example, prefer this organization:

:::code language="csharp" source="snippets/organizing-programs/Payments.cs" id="FeatureOrganization":::

Over grouping by type kind (like putting all interfaces in a `MyApp.Interfaces` namespace or all models in `MyApp.Models`). Feature-based organization keeps related types together, making the code easier to navigate and understand.

## Access modifiers and assemblies

Access modifiers interact with the project/assembly structure to control visibility:

- `public` — accessible from any assembly that references this one.
- `internal` — accessible only within the same assembly (the default for top-level types).
- `private`, `protected`, `private protected`, `protected internal` — control visibility at the type member level.

Use `internal` to hide implementation details that other projects shouldn't depend on. This is especially useful for shared libraries:

:::code language="csharp" source="snippets/organizing-programs/Inventory.cs" id="AccessModifiers":::

## Practical tips

- **Start simple.** A single project works well for small applications. Split into multiple projects only when you have a clear reason.
- **Name namespaces consistently.** Use `CompanyName.ProductName.Feature` as your naming pattern—for example, `Contoso.Inventory.Shipping`.
- **Keep projects focused.** Each project should have a single responsibility. If a project does too many unrelated things, consider splitting it.
- **Use file-scoped namespaces.** The `namespace MyApp.Services;` syntax (C# 10) reduces nesting and is the recommended style for new code.
- **Leverage `global using` directives.** Place common imports in a `GlobalUsings.cs` file to reduce repetition across files. For more information, see [Namespaces and using directives](namespaces.md).

## See also

- [Namespaces and using directives](namespaces.md) — declare namespaces, import types with `using`, and configure global usings.
- [Assemblies in .NET](../../../standard/assembly/index.md) — learn about assemblies, versioning, and deployment.
- [.NET project SDKs](../../../core/project-sdk/overview.md) — project file settings including `RootNamespace` and `ImplicitUsings`.
