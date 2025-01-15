---
title: "NETSDK1144: Optimizing assemblies for size failed"
description: How to resolve the optimizing for size failed message.
author: tdykstra
ms.topic: error-reference
ms.date: 01/14/2025
f1_keywords:
- NETSDK1144
---
# NETSDK1144: Duplicate items were included

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

## Causes of .NET Build Error Code NETSDK1144

One cause of error code `NETSDK1144` is a `UseAppHost` property set to `true` in a project that targets a runtime identifier (RID) that does not support an application host. This typically happens when building a project for a platform that doesn't support generating an executable host.

## How to Fix NETSDK1144 Errors

1. Check the Target Runtime Identifier (RID):
   - Ensure that the RID specified in your project file is correct and supported for generating an application host.
   - Some common RIDs are `win-x64`, `linux-x64`, `osx-x64`.

2. Modify the `UseAppHost` Property or remove unsupported RIDs:
   - If the target RID does not support an application host, set the `UseAppHost` property to `false` in your project file.
   - If you're targeting multiple RIDs, remove any that don't support generating an application host.

## Example Fix

Here is an example of a `.csproj` file with the `UseAppHost` property set to `false`:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <RuntimeIdentifier>linux-arm</RuntimeIdentifier>
    <UseAppHost>false</UseAppHost>
  </PropertyGroup>

</Project>
```

In this example, the `UseAppHost` property is set to `false` because the `linux-arm` RID does not support generating an application host.
