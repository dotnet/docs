---
title: "NETSDK1083: The specified RuntimeIdentifier is not recognized"
description: Learn about .NET SDK error NETSDK1083, which warns about an unknown runtime identifier.
ms.topic: error-reference
ms.date: 04/01/2024
f1_keywords:
- NETSDK1083
---
# NETSDK1083: The specified RuntimeIdentifier is not recognized

NETSDK1083 warns you that the [runtime identifier](../../rid-catalog.md) (RID) specified for your project was not recognized. The specified RID must be in the [RID graph](../../rid-catalog.md#rid-graph).

To resolve this error, specify a known RID as your project's `RuntimeIdentifier`.

In .NET 8 and later versions, the default behavior of the .NET SDK is to [use a smaller portable RID graph](../../compatibility/sdk/8.0/rid-graph.md). If your project uses a version-specific or distro-specific RID, switch to a portable RID. For example, if your project file contains the property `<RuntimeIdentifier>win10-x64</RuntimeIdentifier>`, change it to `<RuntimeIdentifier>win-x64</RuntimeIdentifier>`.

If you need to revert to the previous behavior of using the old, full RID graph, you can set the `UseRidGraph` MSBuild property to `true` in your project file. The old RID graph is no longer updated and exists only for backwards compatibility, and the option to use it might be removed in a future release.

## See also

- [.NET SDK uses a smaller RID graph](../../compatibility/sdk/8.0/rid-graph.md)
