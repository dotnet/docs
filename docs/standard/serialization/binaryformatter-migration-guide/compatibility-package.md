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
---

# Using the compatibility package

> [!WARNING]
> The compatibility package is unsafe and not recommended.

.NET 9+ users who can't migrate away from `BinaryFormatter` can install the [System.Runtime.Serialization.Formatters](https://www.nuget.org/packages/System.Runtime.Serialization.Formatters) NuGet package and set the `System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization` AppContext switch to `true`.

```xml
<PropertyGroup>
  <TargetFramework>net9.0</TargetFramework>
  <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="System.Runtime.Serialization.Formatters" Version="9.0.0-*" />
</ItemGroup>
```

> [!WARNING]
> The compatibility package is unsafe and not recommended.
