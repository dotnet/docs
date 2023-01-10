---
title: "NETSDK1082: There was no runtime pack available"
description: Learn about .NET SDK error NETSDK1082, which warns about an unavailable runtime pack for the specified RID.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1082
---
# NETSDK1082: PackageReference to Microsoft.AspNetCore.App is not necessary

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

In this example, TARGETFRAMEWORK represents values like `net6.0`, `net5.0`, or `netcoreapp3.1` -- basically anything that’s in the **.NET 5+ (and .NET Core)** list in [Supported target frameworks](../../../standard/frameworks.md#supported-target-frameworks). EXISTINGVERSION would need to be a valid version that has been released. For example, `6.0.7` for `net6.0`, `5.0.17` for `net5.0`, and so forth.  For information about released versions, see [Download .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) and [Download .NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0).
