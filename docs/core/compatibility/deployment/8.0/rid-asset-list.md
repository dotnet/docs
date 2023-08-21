---
title: "Breaking change: Host determines RID-specific assets"
description: Learn about the breaking change in deployment in .NET 8 where the runtime host looks for RID-specific assets via a known list.
ms.date: 06/07/2023
---
# Host determines RID-specific assets

When running an application with [RID](../../../rid-catalog.md)-specific assets, the host determines which assets are relevant for the platform on which it's running. This applies to both the application itself and the resolution logic used by <xref:System.Runtime.Loader.AssemblyDependencyResolver>.

Previously, the host tried to compute the RID at run time and then read the RID graph to determine which RID-specific assets matched or were compatible with the computed RID. Now, the default behavior doesn't compute the RID or use the RID graph. Instead, the host relies on a known list of RIDs based on how the runtime itself was built.

## Previous behavior

Previously, the process for selecting RID-specific assets was:

1. Read the RID graph from the *.deps.json* file of the root framework (Microsoft.NetCore.App).
1. Compute the current RID at run time and try to find an entry for it in the RID graph. If it doesn't exist, check for a fallback RID (built into the host at compile time).
1. Starting from the entry found in the RID graph, look for assets matching that RID.
1. Continue down the list of RIDs in the RID graph entry until an asset match is found or the list ends.

If the RID graph didn't have the computed RID or the fallback RID, RID assets weren't properly resolved.

## New behavior

By default, the process no longer relies on the RID graph. Instead, it checks for a known set of portable RIDs based on how the host was built. For example:

Linux

- linux-x64
- linux
- unix-x64
- unix
- any

Windows

- win-x64
- win
- any

macOS

- osx-x64
- osx
- unix-x64
- unix

For non-portable builds of the host or runtime, the build might also set a non-portable RID that's checked first.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and is also a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The RID graph was costly to maintain and understand, requiring .NET itself to be distro-aware in a fragile manner. The .NET team and the community spend a non-trivial amount of time updating the graph and backporting such updates to previous releases. The long-term goal is to stop updating the RID graph, stop reading it, and eventually remove it. This breaking change is a step towards that goal.

## Recommended action

Use portable RIDs, for example, `linux`, `linux-musl`, `osx`, and `win`. For specialized use cases, you can use APIs like <xref:System.Runtime.InteropServices.NativeLibrary.SetDllImportResolver(System.Reflection.Assembly,System.Runtime.InteropServices.DllImportResolver)?displayProperty=nameWithType> or <xref:System.Runtime.Loader.AssemblyLoadContext.ResolvingUnmanagedDll?displayProperty=nameWithType> for custom loading logic.

If you need to revert to the previous behavior, set the backwards compatibility switch `System.Runtime.Loader.UseRidGraph` to `true` in your *runtimeconfig.json* file. Setting the switch to `true` instructs the host to use the previous behavior of reading the RID graph. Alternatively, you can add a `RuntimeHostConfigurationOption` MSBuild item in your project file.

## Affected APIs

- <xref:System.Runtime.Loader.AssemblyDependencyResolver?displayProperty=fullName>
