---
title: Understanding AssemblyLoadContext - .NET Core
description: Key concepts to understand the purpose and behavior of AssemblyLoadContext in .NET Core.
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Understanding <xref:System.Runtime.Loader.AssemblyLoadContext>

The <xref:System.Runtime.Loader.AssemblyLoadContext> class is unique to .NET Core. This article attempts to supplement the API docs <xref:System.Runtime.Loader.AssemblyLoadContext> with conceptual information.

This article is relevant to developers implementing dynamic loading, especially dynamic loading framework developers.

## What is the <xref:System.Runtime.Loader.AssemblyLoadContext>?

Every .NET Core application implicitly uses the <xref:System.Runtime.Loader.AssemblyLoadContext>.
It's the runtime's provider for locating and loading dependencies. Whenever a dependency is loaded an <xref:System.Runtime.Loader.AssemblyLoadContext> instance is invoked to locate it.

- It provides a service of locating, loading, and caching managed assemblies and other dependencies.

## What is special about the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance?

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance is automatically populated by the runtime at startup.  It uses the [trusted platform assemblies](trusted-platform-assemblies.md) to locate and find all static dependencies.

It solves the most common dependency loading scenarios.

## How does <xref:System.Runtime.Loader.AssemblyLoadContext> support dynamic dependencies?

<xref:System.Runtime.Loader.AssemblyLoadContext> has various events and virtual functions that can be overridden.

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance only supports overriding the events.

The articles
[Managed assembly loading algorithm](loading-managed.md),
[Satellite assembly loading algorithm](loading-resources.md), and
[Unmanaged (native) library loading algorithm](loading-unmanaged.md) refer to all the available events and virtual functions.  The articles show each event and functions relative position in the loading algorithms. This article won't reproduce that information.

This section will cover the general principles for the relevant events and functions.

- **Be repeatable**. It's required that a query for a specific dependency will always result in the same response. The same loaded dependency instance must be returned. This requirement is fundamental  for cache consistency.
  - The exception is that the initial `null` response could be followed by a later non-`null` response.
  - For managed assemblies in particular, we're creating a <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> to <xref:System.Reflection.Assembly> cache. There can be exactly one <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> in the cache.
- **Typically don't throw**.  It's expected that these functions return `null` rather than throw when unable to find the requested dependency. Throwing should be restricted to unexpected errors like a corrupt assembly or out of memory.
- **Avoid recursion**. Beware that these functions and handlers are implementing the loading rules for locating dependencies. Your implementation shouldn't call APIs that trigger recursion. Your code should typically be calling **AssemblyLoadContext** load functions that require a specific path or memory reference argument.
- **Load into the correct AssemblyLoadContext**. The choice of where to load dependencies is application-specific.  The choice is implemented by these events and functions. When your code calls **AssemblyLoadContext** load-by-path functions call them on the instance where you want the code loaded. Sometime returning `null` and letting the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> handle the load may be the simplest option.

## How are dynamic dependencies isolated?

One of the primary purposes of exposing the <xref:System.Runtime.Loader.AssemblyLoadContext> is to allow for isolation of dependencies.

The general static dependency model requires a one to one mapping of name to dependency instance.

For dynamic dependencies, there's no guarantee that another static or dynamic dependency hasn't already loaded a dependency of the same name.

Each <xref:System.Runtime.Loader.AssemblyLoadContext> instance represents a unique scope for mapping names.

There's no binary isolation between these dependencies. They're only isolated by not finding each other by name.

## How are dependencies shared?

Dependencies can easily be shared between <xref:System.Runtime.Loader.AssemblyLoadContext> instances. The general model is for one <xref:System.Runtime.Loader.AssemblyLoadContext> to load a dependency.  The other share the dependency by adding the dependency instance to their cache.

This sharing is required of the runtime assemblies. These assemblies can only be loaded into the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType>. The same is required for frameworks like `ASP.NET`, `WPF`, or `WinForms`.

It's recommended that shared dependencies should be loaded into <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType>.

## Complications

### Type conversion issues

When two <xref:System.Runtime.Loader.AssemblyLoadContext> instances contain type definitions with the same name, they may not be the same type.

They're the same type if and only if they come from the same <xref:System.Reflection.Assembly> instance.

To complicate matters, exception messages about these mismatched types can be confusing. The types are referred to in the exception messages by their simple names.

### Debugging type conversion issues

Given a pair of mismatched types it's important to also know:
- Each type's <xref:System.Type.Assembly?displayProperty=nameWithType>
- Each type's <xref:System.Runtime.Loader.AssemblyLoadContext>, which can be obtained via the <xref:System.Runtime.Loader.AssemblyLoadContext.GetLoadContext(System.Reflection.Assembly)?displayProperty=nameWithType> function.
