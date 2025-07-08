---
title: "NETSDK1206: Found version-specific or distribution-specific runtime identifier(s)"
description: Learn about .NET SDK error NETSDK1206, which occurs when a project has dependencies with version-specific or distribution-specific runtime identifiers.
ms.topic: error-reference
ms.date: 08/24/2023
f1_keywords:
- NETSDK1206
---
# NETSDK1206: Found version-specific or distribution-specific runtime identifier(s)

NETSDK1206 indicates your project has assets for version-specific or distribution-specific [runtime identifiers](../../rid-catalog.md). In .NET 8 and higher, the runtime no longer considers version-specific or distro-specific RIDs by default and will find [RID-specific assets using a known set of portable RIDs](../../compatibility/deployment/8.0/rid-asset-list.md). The warning will list the RIDs and packages affected.

First, check for a newer version of any affected packages to see if they have moved to portable RIDs. Many packages have already moved to portable RIDs in their latest versions. If no such version exists, we recommend contacting the package authors to request switching the package to use only portable RIDs.

If you know your application does not actually need the specified RID&mdash;for example, it is not intended to run on the platform specified by the RID&mdash;you can switch to using a more general RID. For example, change `<RuntimeIdentifier>win10-x64</RuntimeIdentifier>` to `<RuntimeIdentifier>win-x64</RuntimeIdentifier>` in your project file:

```xml
<PropertyGroup>
  ...
  <RuntimeIdentifier>win-x64</RuntimeIdentifier>
</PropertyGroup>
```

If you specify the RID as a command-line argument, make a similar change. For example, instead of `dotnet publish --framework net8.0 --runtime win10-x64`, use the command `dotnet publish --framework net8.0 --runtime win-x64`.

If you need to revert to the previous behavior of using the old, full RID graph, you can set the `UseRidGraph` MSBuild property to `true` in your project file. However, the old RID graph won't be updated in the future to attempt to handle any other distros or architectures.

```xml
<PropertyGroup>
  <UseRidGraph>true</UseRidGraph>
</PropertyGroup>
```
