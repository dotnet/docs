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

The RID is specified in the project file or passed into the build process from the command line. If not specified, the default RID used is `win-x64` for Windows, `linux-x64` for Linux, and `osx-x64` for macOS.

The `PlatformTarget` is specified in the project file or passed into the build process from the command line. If not specified, the default is `AnyCPU`.

With `PlatformTarget` set to `AnyCPU`, the application can run on both 32-bit and 64-bit platforms. The runtime executes the app as 64-bit if the OS is 64-bit, and as 32-bit if the OS is 32-bit.

Here's an example of a `.csproj` file with incompatible RID and `PlatformTarget` settings (an x86 RID and an x64 `PlatformTarget`):

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

Fix the error in the preceding `.csproj` file by changing either `PlatformTarget` or `RuntimeIdentifier`. For example, change the PlatformTarget to match the RID:

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
