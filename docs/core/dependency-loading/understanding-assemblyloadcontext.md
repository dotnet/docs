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

To support dynamic code loading and unloading, it creates an isolated context for loading code and its dependencies, in their own <xref:System.Runtime.Loader.AssemblyLoadContext> instance.

## When do you need multiple <xref:System.Runtime.Loader.AssemblyLoadContext> instances?

A single <xref:System.Runtime.Loader.AssemblyLoadContext> instance is limited to loading exactly one version of an <xref:System.Reflection.Assembly> per simple assembly name, <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType>.

This restriction can become a problem when loading code modules dynamically. Each module is independently compiled and may depend on different versions of an <xref:System.Reflection.Assembly>. This problem commonly occurs when different modules depend on different versions of a commonly used library.

To support dynamically loading code, the <xref:System.Runtime.Loader.AssemblyLoadContext> API provides for loading conflicting versions of an <xref:System.Reflection.Assembly> in the same application. Each <xref:System.Runtime.Loader.AssemblyLoadContext> instance provides a unique dictionary mapping each <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> to a specific <xref:System.Reflection.Assembly> instance.

It also provides a convenient mechanism for grouping dependencies related to a code module for later unload.

## What is special about the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance?

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance is automatically populated by the runtime at startup.  It uses [default probing](default-probing.md) to locate and find all static dependencies.

It solves the most common dependency loading scenarios.

## How does <xref:System.Runtime.Loader.AssemblyLoadContext> support dynamic dependencies?

<xref:System.Runtime.Loader.AssemblyLoadContext> has various events and virtual functions that can be overridden.

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance only supports overriding the events.

The articles
[Managed assembly loading algorithm](loading-managed.md),
[Satellite assembly loading algorithm](loading-resources.md), and
[Unmanaged (native) library loading algorithm](loading-unmanaged.md) refer to all the available events and virtual functions.  The articles show each event and functions relative position in the loading algorithms. This article won't reproduce that information.

This section will cover the general principles for the relevant events and functions.

- **Be repeatable**. It's required that a query for a specific dependency will always result in the same response. The same loaded dependency instance must be returned. This requirement is fundamental  for cache consistency. For managed assemblies in particular, we're creating a <xref:System.Reflection.Assembly> cache. The cache key is a simple assembly name, <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType>.
- **Typically don't throw**.  It's expected that these functions return `null` rather than throw when unable to find the requested dependency. Throwing will prematurely end the search and be propagated to the caller. Throwing should be restricted to unexpected errors like a corrupt assembly or out of memory.
- **Avoid recursion**. Beware that these functions and handlers are implementing the loading rules for locating dependencies. Your implementation shouldn't call APIs that trigger recursion. Your code should typically be calling **AssemblyLoadContext** load functions that require a specific path or memory reference argument.
- **Load into the correct AssemblyLoadContext**. The choice of where to load dependencies is application-specific.  The choice is implemented by these events and functions. When your code calls **AssemblyLoadContext** load-by-path functions call them on the instance where you want the code loaded. Sometime returning `null` and letting the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> handle the load may be the simplest option.
- **Be aware of thread races**. Loading can be triggered by multiple threads. The AssemblyLoadContext handles thread races by atomically adding assemblies to its cache. The race loser's instance is discarded. In your implementation logic, don't add extra logic that doesn't handle multiple threads properly.

## How are dynamic dependencies isolated?

Each <xref:System.Runtime.Loader.AssemblyLoadContext> instance represents a unique scope for <xref:System.Reflection.Assembly> instances and <xref:System.Type> definitions.

There's no binary isolation between these dependencies. They're only isolated by not finding each other by name.

In each <xref:System.Runtime.Loader.AssemblyLoadContext>:
    - <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> may refer to a different <xref:System.Reflection.Assembly> instance.
    - <xref:System.Type.GetType%2A?displayProperty=nameWithType> may return a different type instance for the same type `name`.

## How are dependencies shared?

Dependencies can easily be shared between <xref:System.Runtime.Loader.AssemblyLoadContext> instances. The general model is for one <xref:System.Runtime.Loader.AssemblyLoadContext> to load a dependency.  The other shares the dependency by using a reference to the loaded assembly.

This sharing is required of the runtime assemblies. These assemblies can only be loaded into the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType>. The same is required for frameworks like `ASP.NET`, `WPF`, or `WinForms`.

It's recommended that shared dependencies should be loaded into <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType>. This sharing is the common design pattern.

Sharing is implemented in the coding of the custom <xref:System.Runtime.Loader.AssemblyLoadContext> instance. <xref:System.Runtime.Loader.AssemblyLoadContext> has various events and virtual functions that can be overridden. When any of these functions return a reference to an <xref:System.Reflection.Assembly> instance that was loaded in another <xref:System.Runtime.Loader.AssemblyLoadContext> instance, the <xref:System.Reflection.Assembly> instance is shared. The standard load algorithm defers to <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> for loading to simplify the common sharing pattern.  See [Managed assembly loading algorithm](loading-managed.md).

## Complications

### Type conversion issues

When two <xref:System.Runtime.Loader.AssemblyLoadContext> instances contain type definitions with the same `name`, they're not the same type. They're the same type if and only if they come from the same <xref:System.Reflection.Assembly> instance.

To complicate matters, exception messages about these mismatched types can be confusing. The types are referred to in the exception messages by their simple type names. The common exception message in this case would be of the form:

```
Object of type 'IsolatedType' cannot be converted to type 'IsolatedType'.
```

### Debugging type conversion issues

Given a pair of mismatched types it's important to also know:
- Each type's <xref:System.Type.Assembly?displayProperty=nameWithType>
- Each type's <xref:System.Runtime.Loader.AssemblyLoadContext>, which can be obtained via the <xref:System.Runtime.Loader.AssemblyLoadContext.GetLoadContext(System.Reflection.Assembly)?displayProperty=nameWithType> function.

Given two objects `a` and `b`, evaluating the following in the debugger will be helpful:

```C#
// In debugger look at each assembly's instance, Location, and FullName
a.GetType().Assembly
b.GetType().Assembly
// In debugger look at each AssemblyLoadContext's instance and name
System.Runtime.AssemblyLoadContext.GetLoadContext(a.GetType().Assembly)
System.Runtime.AssemblyLoadContext.GetLoadContext(b.GetType().Assembly)
```

### Resolving type conversion issues

There are two design patterns for solving these type conversion issues.

1. Use common shared types. This shared type can either be a primitive runtime type, or it can involve creating a new shared type in a shared assembly.  Often the shared type is an [interface](../../csharp/language-reference/keywords/interface.md) defined in an application assembly. See also: [How are dependencies shared?](#how-are-dependencies-shared).

2. Use marshaling techniques to convert from one type to another.
