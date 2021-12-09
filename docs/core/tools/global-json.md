---
title: global.json overview
description: Learn how to use the global.json file to set the .NET SDK version when running .NET CLI commands.
ms.topic: how-to
ms.date: 12/09/2021
ms.custom: "updateeachrelease"
---
# global.json overview

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

The *global.json* file allows you to define which .NET SDK version is used when you run .NET CLI commands. Selecting the .NET SDK is independent from specifying the runtime your project targets. The .NET SDK version indicates which versions of the .NET CLI is used.

In general, you want to use the latest version of the SDK tools, so no *global.json* file is needed. In some advanced scenarios, you might want to control the version of the SDK tools, and this article explains how to do that.

For more information about specifying the runtime instead, see [Target frameworks](../../standard/frameworks.md).

The .NET SDK looks for a *global.json* file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## global.json schema

### sdk

Type: `object`

Specifies information about the .NET SDK to select.

#### version

- Type: `string`

The version of the .NET SDK to use.

This field:

- Doesn't have wildcard support; that is, you must specify the full version number.
- Doesn't support version ranges.

#### allowPrerelease

- Type: `boolean`
- Available since: .NET Core 3.0 SDK.

Indicates whether the SDK resolver should consider prerelease versions when selecting the SDK version to use.

If you don't set this value explicitly, the default value depends on whether you're running from Visual Studio:

- If you're **not** in Visual Studio, the default value is `true`.
- If you are in Visual Studio, it uses the prerelease status requested. That is, if you're using a Preview version of Visual Studio or you set the **Use previews of the .NET SDK** option (under **Tools** > **Options** > **Environment** > **Preview Features**), the default value is `true`. Otherwise, the default value is `false`.

#### rollForward

- Type: `string`
- Available since: .NET Core 3.0 SDK.

The roll-forward policy to use when selecting an SDK version, either as a fallback when a specific SDK version is missing or as a directive to use a higher version. A [version](#version) must be specified with a `rollForward` value, unless you're setting it to `latestMajor`.
The default roll forward behavior is determined by the [matching rules](#matching-rules).

To understand the available policies and their behavior, consider the following definitions for an SDK version in the format `x.y.znn`:

- `x` is the major version.
- `y` is the minor version.
- `z` is the feature band.
- `nn` is the patch version.

The following table shows the possible values for the `rollForward` key:

| Value         | Behavior |
| ------------- | ---------- |
| `patch`       | Uses the specified version. <br> If not found, rolls forward to the latest patch level. <br> If not found, fails. <br><br> This value is the legacy behavior from the earlier versions of the SDK. |
| `feature`     | Uses the latest patch level for the specified major, minor, and feature band. <br> If not found, rolls forward to the next higher feature band within the same major/minor and uses the latest patch level for that feature band. <br> If not found, fails. |
| `minor`       | Uses the latest patch level for the specified major, minor, and feature band. <br> If not found, rolls forward to the next higher feature band within the same major/minor version and uses the latest patch level for that feature band. <br> If not found, rolls forward to the next higher minor and feature band within the same major and uses the latest patch level for that feature band. <br> If not found, fails. |
| `major`       | Uses the latest patch level for the specified major, minor, and feature band. <br> If not found, rolls forward to the next higher feature band within the same major/minor version and uses the latest patch level for that feature band. <br> If not found, rolls forward to the next higher minor and feature band within the same major and uses the latest patch level for that feature band. <br> If not found, rolls forward to the next higher major, minor, and feature band and uses the latest patch level for that feature band. <br> If not found, fails. |
| `latestPatch` | Uses the latest installed patch level that matches the requested major, minor, and feature band with a patch level and that is greater or equal than the specified value. <br> If not found, fails. |
| `latestFeature` | Uses the highest installed feature band and patch level that matches the requested major and minor with a feature band and patch level that is greater or equal than the specified value. <br> If not found, fails. |
| `latestMinor` | Uses the highest installed minor, feature band, and patch level that matches the requested major with a minor, feature band, and patch level that is greater or equal than the specified value. <br> If not found, fails. |
| `latestMajor` | Uses the highest installed .NET SDK with a version that is greater or equal than the specified value. <br> If not found, fail. |
| `disable`     | Doesn't roll forward. Exact match required. |

### msbuild-sdks

Type: `object`

Lets you control the project SDK version in one place rather than in each individual project. For more information, see [How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved).

## Examples

The following example shows how to not use prerelease versions:

```json
{
  "sdk": {
    "allowPrerelease": false
  }
}
```

The following example shows how to use the highest version installed that's greater or equal than the specified version. The JSON shown disallows any SDK version earlier than 2.2.200 and allows 2.2.200 or any later version, including 3.0.xxx and 3.1.xxx.

```json
{
  "sdk": {
    "version": "2.2.200",
    "rollForward": "latestMajor"
  }
}
```

The following example shows how to use the exact specified version:

```json
{
  "sdk": {
    "version": "3.1.100",
    "rollForward": "disable"
  }
}
```

The following example shows how to use the latest feature band and patch version installed of a specific major and minor version. The JSON shown disallows any SDK version earlier than 3.1.102 and allows 3.1.102 or any later 3.1.xxx version, such as 3.1.103 or 3.1.200.

```json
{
  "sdk": {
    "version": "3.1.102",
    "rollForward": "latestFeature"
  }
}
```

The following example shows how to use the highest patch version installed of a specific version. The JSON shown disallows any SDK version earlier than 3.1.102 and allows 3.1.102 or any later 3.1.1xx version, such as 3.1.103 or 3.1.199.

```json
{
  "sdk": {
    "version": "3.1.102",
    "rollForward": "latestPatch"
  }
}
```

## global.json and the .NET CLI

To set an SDK version in the *global.json* file, it's helpful to know which SDK versions are installed on your machine. For information on how to do that, see [How to check that .NET is already installed](../install/how-to-detect-installed-versions.md#check-sdk-versions).

To install additional .NET SDK versions on your machine, visit the [Download .NET](https://dotnet.microsoft.com/download/dotnet) page.

You can create a new *global.json* file in the current directory by executing the [dotnet new](dotnet-new.md) command, similar to the following example:

```dotnetcli
dotnet new globaljson --sdk-version 6.0.100
```

## Matching rules

> [!NOTE]
> The matching rules are governed by the `dotnet.exe` entry point, which is common across all installed .NET installed runtimes. The matching rules for the latest installed version of the .NET Runtime are used when you have multiple runtimes installed side-by-side or if or you're using a *global.json* file.

## [.NET Core 3.x and .NET 5+](#tab/netcore3x)

Starting with .NET Core 3.0, the following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found, or *global.json* doesn't specify an SDK version nor an `allowPrerelease` value, the highest installed SDK version is used (equivalent to setting `rollForward` to `latestMajor`). Whether prerelease SDK versions are considered depends on how `dotnet` is being invoked.
  - If you're **not** in Visual Studio, prerelease versions are considered.
  - If you are in Visual Studio, it uses the prerelease status requested. That is, if you're using a Preview version of Visual Studio or you set the **Use previews of the .NET SDK** option (under **Tools** > **Options** > **Environment** > **Preview Features**), prerelease versions are considered; otherwise, only release versions are considered.
- If a *global.json* file is found that doesn't specify an SDK version but it specifies an `allowPrerelease` value, the highest installed SDK version is used (equivalent to setting `rollForward` to `latestMajor`). Whether the latest SDK version can be release or prerelease depends on the value of `allowPrerelease`. `true` indicates prerelease versions are considered; `false` indicates that only release versions are considered.
- If a *global.json* file is found and it specifies an SDK version:

  - If no `rollForward` value is set, it uses `latestPatch` as the default `rollForward` policy. Otherwise, check each value and their behavior in the [rollForward](#rollforward) section.
  - Whether prerelease versions are considered and what's the default behavior when `allowPrerelease` isn't set is described in the [allowPrerelease](#allowprerelease) section.

## [.NET Core 2.x](#tab/netcore2x)

In .NET Core 2.x SDK, the following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found or *global.json* doesn't specify an SDK version, the latest installed SDK version is used. Latest SDK version can be either release or prerelease - the highest version number wins.
- If *global.json* does specify an SDK version:
  - If the specified SDK version is found on the machine, that exact version is used.
  - If the specified SDK version can't be found on the machine, the latest installed SDK **patch version** of that version is used. Latest installed SDK **patch version** can be either release or prerelease - the highest version number wins. In .NET Core 2.1 and higher, the **patch versions** lower than the **patch version** specified are ignored in the SDK selection.
  - If the specified SDK version and an appropriate SDK **patch version** can't be found, an error is thrown.

The SDK version is composed of the following parts:

`[.NET Core major version].[.NET Core minor version].[xyz][-optional preview name]`

The **feature release** of the .NET Core SDK is represented by the first digit (`x`) in the last portion of the number (`xyz`) for SDK versions 2.1.100 and higher. In general, the .NET Core SDK has a faster release cycle than .NET Core.

The **patch version** is defined by the last two digits (`yz`) in the last portion of the number (`xyz`) for SDK versions 2.1.100 and higher. For example, if you specify `2.1.300` as the SDK version, SDK selection finds up to `2.1.399` but `2.1.400` isn't considered a patch version for `2.1.300`.

.NET Core SDK versions `2.1.100` through `2.1.201` were released during the transition between version number schemes and don't correctly handle the `xyz` notation. We highly recommend if you specify these versions in the *global.json* file, that you ensure the specified versions are on the target machines.

---

## Troubleshoot build warnings

* The following warnings indicate that your project was compiled using a prerelease version of the .NET SDK:

  > You are working with a preview version of the .NET Core SDK. You can define the SDK version via a global.json file in the current project. More at <https://go.microsoft.com/fwlink/?linkid=869452>.

  > You are using a preview version of .NET. See: <https://aka.ms/dotnet-core-preview>

  .NET SDK versions have a history and commitment of being high quality. However, if you don't want to use a prerelease version, check the different strategies you can use in the [allowPrerelease](#allowprerelease) section. For machines that have never had a .NET Core 3.0 or higher runtime or SDK installed, you need to create a *global.json* file and specify the exact version you want to use.

* The following warning indicates that your project targets EF Core 1.0 or 1.1, which isn't compatible with .NET Core 2.1 SDK and later versions:

  > Startup project '{startupProject}' targets framework '.NETCoreApp' version '{targetFrameworkVersion}'. This version of the Entity Framework Core .NET Command-line Tools only supports version 2.0 or higher. For information on using older versions of the tools, see <https://go.microsoft.com/fwlink/?linkid=871254>.

  Starting with .NET Core 2.1 SDK (version 2.1.300), the `dotnet ef` command comes included in the SDK. To compile your project, install .NET Core 2.0 SDK (version 2.1.201) or earlier on your machine and define the desired SDK version using the *global.json* file. For more information about the `dotnet ef` command, see [EF Core .NET Command-line Tools](/ef/core/miscellaneous/cli/dotnet).

## See also

- [How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved)
