---
title: "NETSDK1032: RuntimeIdentifier and PlatformTarget must be compatible."
description: How to resolve the NETSDK1032 error 'RuntimeIdentifier and PlatformTarget must be compatible.'
author: tdykstra
ms.topic: error-reference
ms.date: 01/14/2025
ai-usage: ai-assisted
f1_keywords:
- NETSDK1032
---
# NETSDK1032: RuntimeIdentifier and PlatformTarget must be compatible

The error `NETSDK1032` occurs when there's a mismatch between the `RuntimeIdentifier` (RID), such as `win-x64` or `linux-x64`, and the `PlatformTarget`, such as `x64` or `x86`. The full error message is similar to the following example:

> The `RuntimeIdentifier` platform '{RID}' and the `PlatformTarget` '{Target}' must be compatible.

The RID is specified in the project file or the command line. If not specified, the default RID used is `win-x64` for Windows, `linux-x64` for Linux, and `osx-x64` for macOS.

The `PlatformTarget` is specified in the project file or the command line. If not specified, the default is `AnyCPU`.

Here's an example of a `.csproj` file with incompatible RID and `PlatformTarget` settings:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <PlatformTarget>x86</PlatformTarget>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
  </PropertyGroup>
</Project>
```

Fix the preceding `.csproj` file by changing either `PlatformTarget` or `RuntimeIdentifier`. For example, change `PlatformTarget` to match the RID:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <PlatformTarget>x64</PlatformTarget>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
  </PropertyGroup>
</Project>
```

Or change the RID to match the `PlatformTarget`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <PlatformTarget>x86</PlatformTarget>
    <RuntimeIdentifier>win-x86</RuntimeIdentifier>
  </PropertyGroup>
</Project>
```
