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

## Algorithm

The .NET Core resource fallback process involves the following steps:

1. The executing assembly's <xref:System.Runtime.Loader.AssemblyLoadContext> instance attempts to load a satellite assembly for the requested culture. In priority order by:
    * Checking its cache.
    * Checking the directory of the currently executing assembly for a subdirectory that matches the requested <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType> (for example `es-MX`).

        > [!NOTE]
        > This feature was not implemented until .NET Core 3.0.
        >
        > On Linux and macOS, the subdirectory is case-sensitive and must either:
        > - Exactly case match.
        > - Be in lower case.

    * Calling the <xref:System.Runtime.Loader.AssemblyLoadContext.Load%2A?displayProperty=nameWithType> function.

    * Raising the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event.

    * Raising the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

2. If a satellite assembly is found, it's loaded, cached, and the <xref:System.AppDomain.AssemblyLoad?displayProperty=nameWithType> event is raised. Then it is searched it for the requested resource. If it finds the resource in the assembly, it uses it. If it doesn't find the resource, it continues the search.

    > [!NOTE]
    > To find a resource within the satellite assembly, the runtime searches for the resource file requested by the <xref:System.Resources.ResourceManager> for the current <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType>. Within the resource file it searches for the requested resource name. If either is not found, the resource is treated as not found.

3. The runtime next searches the parent culture assemblies through many potential levels, each time repeating steps 1 & 2.

    Each culture has only one parent, which is defined by the <xref:System.Globalization.CultureInfo.Parent%2A?displayProperty=nameWithType> property.

    The search for parent cultures stops when a culture's <xref:System.Globalization.CultureInfo.Parent%2A> property is <xref:System.Globalization.CultureInfo.InvariantCulture>.

    For the <xref:System.Globalization.CultureInfo.InvariantCulture>, we don't perform steps 1 & 2, but proceed to step 4.

4. If the resource is still not found, the resource for the default (fallback) culture is used.

   Typically, the resources for the default culture are included in the main application assembly. However, you can specify <xref:System.Resources.UltimateResourceFallbackLocation.Satellite> for the <xref:System.Resources.NeutralResourcesLanguageAttribute.Location?displayProperty=nameWithType> property. This value indicates that the ultimate fallback location for resources is a satellite assembly rather than the main assembly.

    > [!NOTE]
    > The default culture is the ultimate fallback. Therefore, we recommend that you always include a exhaustive set of resources in the default resource file. This helps prevent exceptions from being thrown. By having an exhaustive set, you provide a fallback for all resources and ensure that at least one resource is always present for the user, even if it is not culturally specific.

5. Finally,
   - If the runtime doesn't find a resource file for a default (fallback) culture, a <xref:System.Resources.MissingManifestResourceException> or <xref:System.Resources.MissingSatelliteAssemblyException> exception is thrown.
   - If the resource file is found but the requested resource isn't present, the request returns `null`.
