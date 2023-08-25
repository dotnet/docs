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

If you know your application does not actually need the specified RID &mdash; for example, it is not intended to run on the platform specified by the RID &mdash; you can suppress the warning using the [`NoWarn` MSBuild property](/visualstudio/msbuild/common-msbuild-project-properties). For example:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);NETSDK1206</NoWarn>
</PropertyGroup>
```

If your application does need the specified RID and the affected package doesn't have a version that uses portable RIDs, the runtime can be configured to perform asset resolution via the old RID graph with version-specific and distro-specific RIDs. Note that the old RID graph is no longer updated and exists only as a backwards compatibility option.

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Runtime.Loader.UseRidGraph" Value="true" />
</ItemGroup>
```
