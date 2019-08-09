---
title: Unmanaged library loading algorithm - .NET Core
description: Description of the details of the unmanaged assembly loading algorithm in .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Unmanaged (native) library loading algorithm

Unmanaged libraries are located and loaded with an algorithm involving various stages.

## Algorithm

1. Determine the active <xref:System.Runtime.Loader.AssemblyLoadContext>.

    - Recommended APIs make the active <xref:System.Runtime.Loader.AssemblyLoadContext> explicit.
    - Some APIs infer the active <xref:System.Runtime.Loader.AssemblyLoadContext>.For these APIs, the <xref:System.Runtime.Loader.AssemblyLoadContext.CurrentContextualReflectionContext?displayProperty=nameWithType> property is used. If its value is `null`, then the current executing assembly's <xref:System.Runtime.Loader.AssemblyLoadContext> is used.

2. For the active <xref:System.Runtime.Loader.AssemblyLoadContext>, try to find the assembly. In priority order by:
    * Checking its cache.

    * Calling the <xref:System.Runtime.Loader.AssemblyLoadContext.LoadUnmanagedDll%2A?displayProperty=nameWithType> function.

    * Checking the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> class' cache and [trusted platform assemblies](trusted=platform-assemblies).

    * Raising the <xref:System.Runtime.Loader.AssemblyLoadContext.ResolvingUnmanagedDll?displayProperty=nameWithType> event.

3. If the unmanaged library is found, it's loaded, cached in the active <xref:System.Runtime.Loader.AssemblyLoadContext>, and the <xref:System.AppDomain.AssemblyLoad?displayProperty=nameWithType> event is raised.
