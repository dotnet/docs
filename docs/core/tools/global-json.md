---
title: global.json overview
description: Learn how to use the global.json file to set the .NET Core SDK version when running .NET Core CLI commands.
ms.date: 12/03/2018
ms.custom: "updateeachrelease, seodec18"
---
# global.json overview

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

The *global.json* file allows you to define which .NET Core SDK version is used when you run .NET Core CLI commands. Selecting the .NET Core SDK is independent from specifying the runtime your project targets. The .NET Core SDK version indicates which versions of the .NET Core CLI tools are used. In general, you want to use the latest version of the tools, so no *global.json* file is needed.

For more information about specifying the runtime instead, see [Target frameworks](../../standard/frameworks.md).

.NET Core SDK looks for a *global.json* file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## global.json schema

### sdk

Type: Object

Specifies information about the .NET Core SDK to select.

#### version

Type: String

The version of the .NET Core SDK to use.

Note that this field:

- Doesn't have globbing support, that is, the full version number has to be specified.
- Doesn't support version ranges.

The following example shows the contents of a *global.json* file:

```json
{
  "sdk": {
    "version": "2.2.100"
  }
}
```

## global.json and the .NET Core CLI

It's helpful to know which versions are available in order to set one in the *global.json* file. You can find the full list of supported available SDKs at the [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core) page. Starting with .NET Core 2.1 SDK, you can run the following command to verify which SDK versions are already installed on your machine:

```dotnetcli
dotnet --list-sdks
```

To install additional .NET Core SDK versions on your machine, visit the [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core) page.

You can create a new the *global.json* file in the current directory by executing the [dotnet new](dotnet-new.md) command, similar to the following example:

```dotnetcli
dotnet new globaljson --sdk-version 2.2.100
```

## Matching rules

> [!NOTE]
> The matching rules are governed by the apphost, which is part of the .NET Core runtime.
> The latest version of the host is used when you have multiple runtimes installed side-by-side.

Starting with .NET Core 2.0, the following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found or *global.json* doesn't specify an SDK version, the latest installed SDK version is used. Latest SDK version can be either release or pre-release - the highest version number wins.
- If *global.json* does specify an SDK version:
  - If the specified SDK version is found on the machine, that exact version is used.
  - If the specified SDK version can't be found on the machine, the latest installed SDK **patch version** of that version is used. Latest installed SDK **patch version** can be either release or pre-release - the highest version number wins. In .NET Core 2.1 and higher, the **patch versions** lower than the **patch version** specified are ignored in the SDK selection.
  - If the specified SDK version and an appropriate SDK **patch version** can't be found, an error is thrown.

The SDK version is currently composed of the following parts:

`[.NET Core major version].[.NET Core minor version].[xyz][-optional preview name]`

The **feature release** of the .NET Core SDK is represented by the first digit (`x`) in the last portion of the number (`xyz`) for SDK versions 2.1.100 and higher. In general, the .NET Core SDK has a faster release cycle than .NET Core.

The **patch version** is defined by the last two digits (`yz`) in the last portion of the number (`xyz`) for SDK versions 2.1.100 and higher. For example, if you specify `2.1.300` as the SDK version, SDK selection finds up to `2.1.399` but `2.1.400` isn't considered a patch version for `2.1.300`.

.NET Core SDK versions `2.1.100` through `2.1.201` were released during the transition between version number schemes and don't correctly handle the `xyz` notation. We highly recommend if you specify these versions in the *global.json* file, that you ensure the specified versions are on the target machines.

With .NET Core SDK 1.x, if you specified a version and no exact match was found, the latest installed SDK version was used. Latest SDK version can be either release or pre-release - the highest version number wins.

## Troubleshooting build warnings

> [!WARNING]
> You are working with a preview version of the .NET Core SDK. You can define the SDK version via a global.json file in the current project. More at <https://go.microsoft.com/fwlink/?linkid=869452>

This warning indicates that your project is being compiled using a preview version of the .NET Core SDK, as explained in the [Matching rules](#matching-rules) section. .NET Core SDK versions have a history and commitment of being high quality. However, if you don't want to use a preview version, add a *global.json* file to your project hierarchy structure to specify which SDK version to use, and use `dotnet --list-sdks` to confirm that the version is installed on your machine. When a new version is released, to use the new version, either remove the *global.json* file or update it to use the newer version.

> [!WARNING]
> Startup project '{startupProject}' targets framework '.NETCoreApp' version '{targetFrameworkVersion}'. This version of the Entity Framework Core .NET Command-line Tools only supports version 2.0 or higher. For information on using older versions of the tools, see <https://go.microsoft.com/fwlink/?linkid=871254>

Starting with .NET Core 2.1 SDK (version 2.1.300), the `dotnet ef` command comes included in the SDK. This warning indicates that your project targets EF Core 1.0 or 1.1, which isn't compatible with .NET Core 2.1 SDK and later versions. To compile your project, install .NET Core 2.0 SDK (version 2.1.201) and earlier on your machine and define the desired SDK version using the *global.json* file. For more information about the `dotnet ef` command, see [EF Core .NET Command-line Tools](/ef/core/miscellaneous/cli/dotnet).

## See also

- [How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved)
