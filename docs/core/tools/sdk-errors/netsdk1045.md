---
title: "NETSDK1045: The current .NET SDK does not support 'newer version' as a target."
description: Learn about .NET SDK error NETSDK1045, which occurs when the build tools can't find the requested version of the .NET SDK.
ms.topic: error-reference
ms.date: 02/12/2021
f1_keywords:
- NETSDK1045
---
# NETSDK1045: The current .NET SDK does not support 'newer version' as a target.

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

This error occurs when the build tools can't find the version of the .NET SDK that's needed to build a project. This is typically due to a .NET SDK installation or configuration issue. The full error message is similar to the following example:

> NETSDK1045: The current .NET SDK does not support 'newer version' as a target. Either target 'older version' or lower, or use a .NET SDK version that supports 'newer version'.

The following sections describe some of the possible reasons for this error. Check each one and see which one applies to you. Keep in mind that when making changes to the environment or the configuration files, you might have to restart command windows, restart Visual Studio, or reboot your machine, for your changes to take effect.

## .NET SDK version

Open the project file (.csproj, .vbproj, or .fsproj) and check the target framework. This is the version of the framework that your app is trying to use.

```xml
<TargetFramework>netcoreapp3.0</TargetFramework>
```

Make sure that the version of .NET listed is installed on the machine. You can list the installed versions by using the following command (open a Developer Command Prompt and run this command):

```dotnetcli
dotnet --list-sdks
```

### x86 or x64 architecture

Each version of the .NET SDK is available in both x86 and x64 architecture. The project might be trying to find the .NET SDK for the wrong architecture, or the .NET SDK for the architecture your project needs might not be installed. Check the installation folders for the architecture you need. For example, on Windows, the x86 version of the .NET SDK is installed in *C:\Program Files (x86)\dotnet* and the x64 version is installed in *C:\Program Files\dotnet*. See [How to check that .NET is already installed](../../install/how-to-detect-installed-versions.md) and choose your operating system to find out how to detect what's installed on your machine.

If the version you need isn't installed, find the one you need at the [.NET Downloads](https://dotnet.microsoft.com/download/dotnet) page.

## Preview not enabled

If you have a preview installed of the requested .NET SDK version, you also need to set the option to enable previews in Visual Studio. Go to **Tools** > **Options** > **Environment** > **Preview Features**, and make sure that **Use previews of the .NET Core SDK** is checked.

## Visual Studio version

For example, .NET Core 3.0 and later require Visual Studio 2019. Upgrade to [Visual Studio 2019 version 16.3](https://visualstudio.microsoft.com/downloads) or later to build your project.

## PATH environment variable

The build tools use the PATH environment variable to find the right version of the .NET build tools. If the PATH environment variable contains direct paths to older build tools, this error message could appear. Make sure the only path to the .NET tools in the PATH environment variable is to the top-level *dotnet* folder, for example, *C:\Program Files\dotnet*. An example of an incorrect PATH would be something like *C:\Program Files\dotnet\2.1.0\sdks*.

## MSBuildSDKPath environment variable

Check the MSBuildSDKPath environment variable. This optional environment variable is recognized by MSBuild and if set, overrides the default value. It might be set to a specific older version of the .NET SDK. If it's set, try deleting it and rebuilding your project.

## global.json file

Check for a *global.json* file in the root folder in your project and up the directory chain to the root of the volume, since it can be anywhere in the folder structure. If it contains an SDK version, delete the `sdk` node and all its children, or update it to the desired newer .NET Core version.

```json
{
  "sdk": {
    "version": "2.1.0"
  }
}
```

The *global.json* file is not required, so if it doesn't contain anything other than the `sdk` node, you can delete the whole file.

## Directory.build.props file

The *Directory.build.props* file is an optional MSBuild file that can set global properties. Check for these files in the solution folder and up the directory chain to the root of the volume, since they can be anywhere in the folder structure. Look for `TargetFramework` elements, or settings of `MSBuildSDKPath` that could override your desired settings.

## See also

- [The Current .NET SDK does not support targeting .NET Core 3.0 – Fix](https://www.ryadel.com/current-net-sdk-not-support-net-core-3-0-fix/)
