---
title: "NETSDK1083: The specified RuntimeIdentifier is not recognized"
description: Learn about .NET SDK error NETSDK1083, which warns about an unknown runtime identifier.
ms.topic: error-reference
ms.date: 09/19/2023
f1_keywords:
- NETSDK1083
---
# NETSDK1083: The specified RuntimeIdentifier is not recognized

NETSDK1083 warns you that the [runtime identifier](../../rid-catalog.md) (RID) specified for your project was not recognized. The specified RID must be in the [RID graph](../../rid-catalog.md#rid-graph).

To resolve this error, specify a known rid as your project's `RuntimeIdentifier`.

In .NET 8 and higher, the default behavior of the .NET SDK is to [use a smaller portable RID graph](../../compatibility/sdk/8.0/rid-graph.md). If your project is using a version-specific or distro-specific RID, switch to a portable RID. If you need to revert to the previous behavior of using the old, full RID graph, you can set the `UseRidGraph` MSBuild property to `true` in your project file. Note that the old RID graph is no longer updated and exists only as a backwards compatibility option, which may be removed in a future release.