---
title: "NETSDK1100: Set the `EnableWindowsTargeting` property to true"
description: Learn about the .NET SDK error message that instructs you to set the EnableWindowsTargeting property to true.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1100
---
# NETSDK1100: Set the EnableWindowsTargeting property to true

NETSDK1100 indicates that you're building a project that targets Windows on Linux or macOS. The full error message is similar to the following example:

> To build a project targeting Windows on this operating system, set the `EnableWindowsTargeting` property to true.

To resolve this error, set the `EnableWindowsTargeting` property to true. You can set it in the project file or by passing `/p:EnableWindowsTargeting=true` to a .NET CLI command, such as `dotnet build`. Here's an example project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <EnableWindowsTargeting>true</EnableWindowsTargeting>
  </PropertyGroup>
</Project>
```

If you want to apply this setting to your whole solution or repository, you can set it in a *Directory.Build.props* file.

By default, .NET downloads all targeting packs (and runtime packs for self-contained builds) for the current target framework whether they're needed or not, because they might be brought in by a transitive framework reference. We didn't want to ship the Windows targeting packs with the non-Windows SDK builds, but we also didn't want a vanilla Console or ASP.NET Core app to automatically download these targeting and runtime packs the first time you build. The `EnableWindowsTargeting` property enables them to be downloaded only if you opt in.

## See also

- [EnableWindowsTargeting property](../../project-sdk/msbuild-props.md#enablewindowstargeting)
