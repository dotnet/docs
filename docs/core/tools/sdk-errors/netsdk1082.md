---
title: "NETSDK1082: There was no runtime pack available"
description: Learn about .NET SDK error NETSDK1082, which warns about an unavailable runtime pack for the specified RID.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1082
---
# NETSDK1082: There was no runtime pack available

NETSDK1082 warns you that the runtime pack for your [runtime identifier](../../rid-catalog.md) (RID) could not be found in your NuGet feed. The full error message is similar to the following example:

>There was no runtime pack for \<RuntimePack> available for the specified RuntimeIdentifier '\<RID>'.

.NET automatically downloads known runtime packs for self-contained applications but there could be a pointer to one that's not available to you. Investigate your NuGet configuration and feeds to find out why the required runtime pack is missing. In some scenarios, you might have to override the `LatestRuntimeFrameworkVersion` value to one that's available on your NuGet feeds by adding markup like the following example to the project file:

```xml
<ItemGroup>
  <KnownRuntimePack Update="@(KnownRuntimePack)">
    <LatestRuntimeFrameworkVersion Condition="'%(TargetFramework)' == 'TARGETFRAMEWORK'">EXISTINGVERSION</LatestRuntimeFrameworkVersion>
  </KnownRuntimePack>
</ItemGroup>
```

In this example, `TARGETFRAMEWORK` represents values like `net8.0` or `net6.0` -- basically anything that’s in the **.NET 5+ (and .NET Core)** list in [Supported target frameworks](../../../standard/frameworks.md#supported-target-frameworks). `EXISTINGVERSION` needs to be a valid version that's been released. For example, `6.0.7` for `net6.0`.
