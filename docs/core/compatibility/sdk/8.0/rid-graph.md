---
title: "Breaking change: .NET SDK uses a smaller RID graph"
description: Learn about a breaking change in the .NET 8 SDK where the SDK uses a smaller, portable RID graph for projects that target .NET 8 or later.
ms.date: 09/05/2023
---
# .NET SDK uses a smaller RID graph

Projects that target .NET 8 or later versions now use a smaller, "portable" runtime identifier (RID) graph.

## Previous behavior

The .NET SDK used a complex [RID graph](../../../rid-catalog.md) to determine assets when building or publishing a project.

## New behavior

Starting in .NET 8, the .NET SDK uses a smaller graph consisting of only portable RIDs, for projects that target .NET 8 or a later version. This means that the SDK won't recognize version-specific or distro-specific RIDs by default.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change) and can also affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The RID graph was costly to maintain and understand, requiring .NET itself to be distro-aware in a fragile manner. The .NET team and the community spend a non-trivial amount of time updating the graph and backporting such updates to previous releases. The long-term goal is to stop updating the RID graph, stop reading it, and eventually remove it. This breaking change is a step towards that goal.

## Recommended action

Use portable RIDs, for example, `linux-<arch>`, `linux-musl-<arch>`, `osx-<arch>`, and `win-<arch>`.

If you need to revert to the previous behavior of using the old, full RID graph, you can set the `UseRidGraph` MSBuild property to `true` in your project file. However, the old RID graph won't be updated in the future to attempt to handle any other distros or architectures.

## See also

- [Host determines RID-specific assets](../../deployment/8.0/rid-asset-list.md)
- [RuntimeIdentifier returns platform for which the runtime was built](../../core-libraries/8.0/runtimeidentifier.md)
