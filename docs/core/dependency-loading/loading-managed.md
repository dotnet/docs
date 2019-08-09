---
title: Managed assembly loading algorithm - .NET Core
description: Description of the details of the managed assembly loading algorithm in .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Managed assembly loading algorithm

Managed assemblies are located and loaded with an algorithm involving various stages.

All managed assemblies except satellite assemblies and `WinRT` assemblies use the same algorithm.

## Algorithm

1. Determine the active <xref:System.Runtime.Loader.AssemblyLoadContext>.

    - Recommended APIs make the active <xref:System.Runtime.Loader.AssemblyLoadContext> explicit.
    - Some APIs infer the active <xref:System.Runtime.Loader.AssemblyLoadContext>.For these APIs, the <xref:System.Runtime.Loader.AssemblyLoadContext.CurrentContextualReflectionContext?displayProperty=nameWithType> property is used. If its value is `null`, then the current executing assembly's <xref:System.Runtime.Loader.AssemblyLoadContext> is used.

2. For the active <xref:System.Runtime.Loader.AssemblyLoadContext>, try to find the assembly. In priority order by:
    * Checking its cache.

    * Calling the <xref:System.Runtime.Loader.AssemblyLoadContext.Load%2A?displayProperty=nameWithType> function.

    * Checking the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instances' cache and [trusted platform assemblies](trusted-platform-assemblies.md).

    * Raising the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event.

    * Raising the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

3. If the assembly is found, it's loaded, cached in the active <xref:System.Runtime.Loader.AssemblyLoadContext>, and the <xref:System.AppDomain.AssemblyLoad?displayProperty=nameWithType> event is raised.
