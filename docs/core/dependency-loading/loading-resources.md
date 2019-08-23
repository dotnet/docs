---
title: Satellite assembly loading algorithm - .NET Core
description: Description of the details of the Satellite assembly loading algorithm in .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Satellite assembly loading algorithm

Satellite assemblies are used to store localized resources customized for language and culture.

Satellite assemblies use a different loading algorithm than general managed assemblies.

## When are satellite assemblies loaded?

Satellite assemblies are loaded when loading a localized resource.

The basic API to load localized resources is the <xref:System.Resources.ResourceManager?displayProperty=fullName> class. Ultimately the <xref:System.Resources.ResourceManager> class will call the <xref:System.Reflection.Assembly.GetSatelliteAssembly%2A> method for each <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType>.

Higher-level APIs may abstract the low-level API.

## Algorithm

The .NET Core resource fallback process involves the following steps:

1. Determine the `active` <xref:System.Runtime.Loader.AssemblyLoadContext> instance. In all cases, the `active` instance is the executing assembly's <xref:System.Runtime.Loader.AssemblyLoadContext>.

2. The `active` instance attempts to load a satellite assembly for the requested culture in priority order by:
    * Checking its cache.
    * Checking the directory of the currently executing assembly for a subdirectory that matches the requested <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType> (for example `es-MX`).

        > [!NOTE]
        > This feature was not implemented in .NET Core before 3.0.
        >
        > [!NOTE]
        > On Linux and macOS, the subdirectory is case-sensitive and must either:
        > - Exactly match case.
        > - Be in lower case.

    * If `active` is the <xref:System.Runtime.Loader.AssemblyLoadContext.Default?displayProperty=nameWithType> instance, by running the [default satellite (resource) assembly probing](default-probing.md#satellite-resource-assembly-probing) logic.

    * Calling the <xref:System.Runtime.Loader.AssemblyLoadContext.Load%2A?displayProperty=nameWithType> function.

    * Raising the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event.

    * Raising the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

3. If a satellite assembly is loaded:
   - The <xref:System.AppDomain.AssemblyLoad?displayProperty=nameWithType> event is raised.
   - The assembly is searched it for the requested resource. If the runtime finds the resource in the assembly, it uses it. If it doesn't find the resource, it continues the search.

    > [!NOTE]
    > To find a resource within the satellite assembly, the runtime searches for the resource file requested by the <xref:System.Resources.ResourceManager> for the current <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType>. Within the resource file, it searches for the requested resource name. If either is not found, the resource is treated as not found.

4. The runtime next searches the parent culture assemblies through many potential levels, each time repeating steps 2 & 3.

    Each culture has only one parent, which is defined by the <xref:System.Globalization.CultureInfo.Parent%2A?displayProperty=nameWithType> property.

    The search for parent cultures stops when a culture's <xref:System.Globalization.CultureInfo.Parent%2A> property is <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>.

    For the <xref:System.Globalization.CultureInfo.InvariantCulture>, we don't return to steps 2 & 3, but rather continue with step 5.

5. If the resource is still not found, the resource for the default (fallback) culture is used.

   Typically, the resources for the default culture are included in the main application assembly. However, you can specify <xref:System.Resources.UltimateResourceFallbackLocation.Satellite?displayProperty=nameWithType> for the <xref:System.Resources.NeutralResourcesLanguageAttribute.Location?displayProperty=nameWithType> property. This value indicates that the ultimate fallback location for resources is a satellite assembly rather than the main assembly.

    > [!NOTE]
    > The default culture is the ultimate fallback. Therefore, we recommend that you always include an exhaustive set of resources in the default resource file. This helps prevent exceptions from being thrown. By having an exhaustive set, you provide a fallback for all resources and ensure that at least one resource is always present for the user, even if it is not culturally specific.

6. Finally,
   - If the runtime doesn't find a resource file for a default (fallback) culture, a <xref:System.Resources.MissingManifestResourceException> or <xref:System.Resources.MissingSatelliteAssemblyException> exception is thrown.
   - If the resource file is found but the requested resource isn't present, the request returns `null`.
