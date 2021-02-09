---
title: "NETSDK1045: The current .NET SDK does not support 'newer version' as a target."
description: Learn about .NET SDK error NETSDK1045, which occurs when the build tools can't find the requested version of the .NET SDK.
ms.topic: error-reference
ms.date: 02/12/2021
f1_keywords:
- NETSDK1045
---
# NETSDK1045: The current .NET SDK does not support 'newer version' as a target. Either target 'older version' or lower, or use a .NET SDK version that supports 'newer version'.

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

This error occurs when the build tools can't find the version of the .NET SDK that's needed to build a project. This is typically due to a .NET Core SDK installation or configuration issue.

The following sections describe some of the possible reasons for this error. Check each one and see which one applies to you. Keep it mind that when making changes to the environment or the configuration files, you might have to restart command windows, restart Visual Studio, or reboot your machine, for your changes to take effect.

## .NET Core SDK version

Open the project file (.csproj, .vbproj, or .fsproj) and check the target framework. This is the version of the framework that your app is trying to use.

```xml
<TargetFramework>netcoreapp3.0</TargetFramework>
```

Make sure that the version of .NET Core listed is installed on the machine. You can list the installed versions by using the following command (open a Developer Command Prompt and run this command):

```cmd
dotnet --list-sdks
```

If the version requested is not installed, download it from [here](https://dotnet.microsoft.com/download/dotnet-core).

## Preview not enabled

If you have a preview installed of the requested .NET Core SDK version, you also need to set the option to enable previews in Visual Studio. Go to **Tools** > **Options** > **Environment** > **Preview Features**, and make sure that **Use previews of the .NET Core SDK** is checked.

## Visual Studio version

For example, .NET Core 3.0 and later require Visual Studio 2019. Upgrade to [Visual Studio 2019 version 16.3](https://visualstudio.microsoft.com/downloads) or later to build your project.

## The PATH environment variable

The build tools use the PATH environment variable to find the right version of the .NET Core build tools. If the PATH environment variable contains direct paths to older build tools, this error message could appear. Make sure the only path to the .NET tools in the PATH environment variable is to the top-level *dotnet* folder, for example, *C:\Program Files\dotnet\\*. An example of an incorrect PATH would be something like *C:\Program Files\dotnet\2.1.0\sdks\\*.

## The MSBuildSDKPath variable

Check the MSBuildSDKPath variable. This optional environment variable is recognized by MSBuild and if set, overrides the default value. It might be set to a specific older version of the .NET SDK. If it's set, try deleting it and rebuilding your project.

## The global.json file

Check the root folder in your project for the *global.json* file. If it contains an SDK version, delete the `sdk` node and all its children, or update it to the desired newer .NET Core version.

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
