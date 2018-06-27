---
title: global.json reference
description: See the schema for the global.json file, which permits setting the .NET Core SDK version.
author: mairaw
ms.author: mairaw
ms.date: 06/27/2018
ms.custom: "updateeachrelease"
---
# global.json reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

The *global.json* file allows selection of the .NET Core SDK version being used through the `sdk` property.

.NET Core SDK looks for this file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## sdk

Type: Object

Specifies information about the .NET Core SDK to select.

### version

Type: String

The version of the .NET Core SDK to use.

Note that this field:

- Doesn't have globbing support, that is, the full version number has to be specified.
- Doesn't support version ranges.

The following example shows the contents of a *global.json* file:

```json
{
  "sdk": {
    "version": "2.1.300"
  }
}
```

## global.json and the .NET Core CLI

Starting with .NET Core SDK 2.1, to verify which SDK versions you've installed to specify in the *global.json* file, you can run the following command:

```console
dotnet --list-sdks
```

To install additional .NET Core SDK versions on your machine, visit [All .NET Downloads](https://www.microsoft.com/net/download/all).

You can create a new the *global.json* file in the current directory by executing the [dotnet new](dotnet-new.md) command, similar to the following example:

```console
dotnet new globaljson --sdk-version 2.1.300
```

## Matching rules

With .NET Core SDK 1.x, if you specified a version and no exact match was found, the latest installed SDK version was used. Latest SDK version can be either release or pre-release - the highest version number wins.

Starting with .NET Core SDK 2.0, the following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found or *global.json* doesn't specify an SDK version, the latest installed SDK version is used. Latest SDK version can be either release or pre-release - the highest version number wins.
- If *global.json* does specify an SDK version:
  - If the specified SDK version is found on the machine, that exact version is used.
  - If the specified SDK version can't be found on the machine, the latest installed SDK **patch-version** of the specified SDK version is used. Latest installed SDK **patch-version** can be either release or pre-release - the highest version number wins.
  - If the specified SDK version and an appropriate SDK **patch-version** can't be found, an error is thrown.

The SDK version is currently composed of the following parts:

`[major][minor][xyz]-[additional optional information]`

The **patch-version** is defined by the third position (`z`) in the last portion of the number (`xyz`) for SDK versions earlier than 2.1.100 and the last two digits (`yz`) starting with 2.1.100. For example, if you specify `2.1.300` as the SDK version, it can try to find up to `2.1.399` but `2.1.400` isn't considered a patch version for `2.1.300`.

## Troubleshooting build warnings

> [!WARNING]
> You are working with a preview version of the .NET Core SDK. You can define the SDK version via a global.json file in the current project. More at https://go.microsoft.com/fwlink/?linkid=869452

This warning indicates that by default your project is being compiled using a preview version of the .NET Core SDK, as explained in the [Matching rules](#matching-rules) section. If that's not the desired behavior, add a *global.json* file to your project hierarchy structure to specify the SDK version you'd like to use.

> [!WARNING]
> Startup project '{startupProject}' targets framework '.NETCoreApp' version '{targetFrameworkVersion}'. This version of the Entity Framework Core .NET Command-line Tools only supports version 2.0 or higher. For information on using older versions of the tools, see https://go.microsoft.com/fwlink/?linkid=871254

Starting with .NET Core SDK 2.1 (v. 2.1.300), the *dotnet ef* command comes included in the SDK. This warning indicates that your project targets an old version of EF Core (1.0 or 1.1) that isn't compatible with .NET Core SDK 2.1 and later versions. To compile your project, install .NET Core SDK 2.0 (v. 2.1.201) and earlier on your machine. For more information, see [EF Core .NET Command-line Tools](/ef/core/miscellaneous/cli/dotnet).

## See also

[How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved)