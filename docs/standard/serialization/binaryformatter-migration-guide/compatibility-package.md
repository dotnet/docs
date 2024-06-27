---
title: "BinaryFormatter Migration Guide: Compatibility Package"
description: "Using the BinaryFormatter compatibility package."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
  - VB
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Using the compatibility package

> [!WARNING]
> It's unsafe and not recommended.

All the .NET 9+ users who for some reason can not migrate away from `BinaryFormatter` can just install the [System.Runtime.Serialization.Formatters](https://www.nuget.org/packages/System.Runtime.Serialization.Formatters) NuGet package and set the `System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization` AppContext switch to `true`.

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
> It's unsafe and not recommended.
