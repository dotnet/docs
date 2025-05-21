---
title: "BinaryFormatter migration guide: Compatibility Package"
description: "Using the BinaryFormatter compatibility package."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: upgrade-and-migration-article
---

# BinaryFormatter compatibility package

> [!CAUTION]
> The compatibility package is not supported and unsafe. We strongly recommend against taking a dependency on this package and instead [migrate away from BinaryFormatter](./index.md#migration-topics).

.NET 9+ users who can't migrate away from `BinaryFormatter` can install the unsupported [System.Runtime.Serialization.Formatters](https://www.nuget.org/packages/System.Runtime.Serialization.Formatters) NuGet package and set the `System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization` AppContext switch to `true`.

> [!NOTE]
> Please note that this package doesn't change the type identity of BinaryFormatter. Existing libraries don't need to be updated to depend on this package in order to use it. The only place that needs to depend on this package is the application project.

The package replaces the in-box implementation of BinaryFormatter with a functioning one, including its vulnerabilities and risks. It's meant as a stop gap if you can't wait with migrating to .NET 9 and later while not having replaced the usages of BinaryFormatter yet. We still strongly recommend you [migrate away from BinaryFormatter](./index.md#migration-topics).

```xml
<PropertyGroup>
  <TargetFramework>net9.0</TargetFramework>
  <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="System.Runtime.Serialization.Formatters" Version="9.0.0-*" />
</ItemGroup>
```

> [!CAUTION]
> The compatibility package is not supported and unsafe. We strongly recommend against taking a dependency on this package and instead [migrate away from BinaryFormatter](./index.md#migration-topics).
