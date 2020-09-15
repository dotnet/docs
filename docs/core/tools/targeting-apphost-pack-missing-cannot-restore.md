---
title: Resolve targeting or apphost pack missing while NuGet package restore is not supported
description: How to resolve the issue of targeting pack missing while NuGet package restore is not supported
author: wli3
ms.topic: how-to
ms.date: 09/14/2020
---
# Resolve targeting/apphost pack missing while NuGet package restore is not supported

**This article applies to:** ✔️ .NET Core 5.0.100 SDK and later versions

When SDK issues error NETSDK1145, the targeting or apphost pack is not installed and NuGet package restore is not supported. This is typically caused by having a newer SDK than the one included in VS for C++/CLI projects. Please upgrade VS, remove global.json if it specifies a certain SDK version and uninstall the newer SDK. Alternatively, you could override the targeting or apphost version: Find the version existed under pack directory from the error message and matching the target framework of the project. Add the following to the project

For apphost pack

```xml
  <ItemGroup>
    <KnownAppHostPack Update="@(KnownAppHostPack)">
      <AppHostPackVersion Condition="'%(TargetFramework)' == 'TARGETFRAMEWORK'">EXISTINGVERSION</AppHostPackVersion>
    </KnownAppHostPack>
  </ItemGroup>
```

For targeting pack

```xml
  <ItemGroup>
    <KnownAppHostPack Update="@(KnownAppHostPack)">
      <AppHostPackVersion Condition="'%(TargetFramework)' == 'TARGETFRAMEWORK'">EXISTINGVERSION</AppHostPackVersion>
    </KnownAppHostPack>
  </ItemGroup>
```
