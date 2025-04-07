---
title: global.json overview
description: Learn how to use the global.json file to set the .NET SDK version when running .NET CLI commands.
ms.topic: how-to
ms.date: 07/05/2024
ms.custom: "updateeachrelease"
---
# global.json overview

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

The *global.json* file allows you to define which .NET SDK version is used when you run .NET CLI commands. Selecting the .NET SDK version is independent from specifying the runtime version a project targets. The .NET SDK version indicates which version of the .NET CLI is used. This article explains how to select the SDK version by using *global.json*.

If you always want to use the latest SDK version that is installed on your machine, no *global.json* file is needed. In CI (continuous integration) scenarios, however, you typically want to specify an acceptable range for the SDK version that is used. The *global.json* file has a `rollForward` feature that provides flexible ways to specify an acceptable range of versions. For example, the following *global.json* file selects 8.0.300 or any later [feature band or patch](../releases-and-support.md) for 8.0 that is installed on the machine:

```json
{
  "sdk": {
    "version": "8.0.300",
    "rollForward": "latestFeature"
  }
}
```

The .NET SDK looks for a *global.json* file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

For information about specifying the runtime version instead of the SDK version, see [Target frameworks](../../standard/frameworks.md).

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
- If you're in Visual Studio, it uses the prerelease status requested. That is, if you're using a Preview version of Visual Studio or you set the **Use previews of the .NET SDK** option (under **Tools** > **Options** > **Environment** > **Preview Features**), the default value is `true`. Otherwise, the default value is `false`.

#### rollForward

- Type: `string`
- Available since: .NET Core 3.0 SDK.

The roll-forward policy to use when selecting an SDK version, either as a fallback when a specific SDK version is missing or as a directive to use a later version. A [version](#version) must be specified with a `rollForward` value, unless you're setting it to `latestMajor`.
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
| `latestPatch` | Uses the latest installed patch level that matches the requested major, minor, and feature band with a patch level that's greater than or equal to the specified value. <br> If not found, fails. |
| `latestFeature` | Uses the highest installed feature band and patch level that matches the requested major and minor with a feature band and patch level that's greater than or equal to the specified value. <br> If not found, fails. |
| `latestMinor` | Uses the highest installed minor, feature band, and patch level that matches the requested major with a minor, feature band, and patch level that's greater than or equal to the specified value. <br> If not found, fails. |
| `latestMajor` | Uses the highest installed .NET SDK with a version that's greater than or equal to the specified value. <br> If not found, fail. |
| `disable`     | Doesn't roll forward. An exact match is required. |

#### paths

- Type: Array of `string`
- Available since: .NET 10 Preview 3 SDK.

Specifies the locations that should be considered when searching for a compatible .NET SDK. Paths can be absolute or relative to the location of the *global.json* file. The special value `$host$` represents the location corresponding to the running `dotnet` executable.

These paths are searched in the order they're defined and the first [matching](#matching-rules) SDK is used.

#### errorMessage

- Type: `string`
- Available since: .NET 10 Preview 3 SDK.

Specifies a custom error message displayed when the SDK resolver can't find a compatible .NET SDK.

### msbuild-sdks

Type: `object`

Lets you control the project SDK version in one place rather than in each individual project. For more information, see [How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved).

### Comments in global.json

Comments in *global.json* files are supported using JavaScript or C# style comments. For example:

```json
{
   // This is a comment.
  "sdk": {
    "version": "8.0.300" /* This is comment 2*/
  /* This is a
  multiline comment.*/
  }
}
```

## Examples

The following example shows how to disallow the use of prerelease versions:

```json
{
  "sdk": {
    "allowPrerelease": false
  }
}
```

The following example shows how to use the highest version installed that's greater or equal than the specified version. The JSON shown disallows any SDK version earlier than 7.0.200 and allows 7.0.200 or any later version, including 8.0.xxx.

```json
{
  "sdk": {
    "version": "7.0.200",
    "rollForward": "latestMajor"
  }
}
```

The following example shows how to use the exact specified version:

```json
{
  "sdk": {
    "version": "8.0.302",
    "rollForward": "disable"
  }
}
```

The following example shows how to use the latest feature band and patch version installed of a specific major and minor version. The JSON shown disallows any SDK version earlier than 8.0.302 and allows 8.0.302 or any later 8.0.xxx version, such as 8.0.303 or 8.0.402.

```json
{
  "sdk": {
    "version": "8.0.302",
    "rollForward": "latestFeature"
  }
}
```

The following example shows how to use the highest patch version installed of a specific version. The JSON shown disallows any SDK version earlier than 8.0.102 and allows 8.0.102 or any later 8.0.1xx version, such as 8.0.103 or 8.0.199.

```json
{
  "sdk": {
    "version": "8.0.102",
    "rollForward": "latestPatch"
  }
}
```

The following example shows how to specify additional SDK search paths and a custom error message:

```json
{
  "sdk": {
    "version": "10.0.100",
    "paths": [ ".dotnet", "$host$" ],
    "errorMessage": "The required .NET SDK wasn't found. Please run ./install.sh to install it."
  }
}
```

## global.json and the .NET CLI

To set an SDK version in the *global.json* file, it's helpful to know which SDK versions are installed on your machine. For information on how to do that, see [How to check that .NET is already installed](../install/how-to-detect-installed-versions.md#check-sdk-versions).

To install additional .NET SDK versions on your machine, visit the [Download .NET](https://dotnet.microsoft.com/download/dotnet) page.

You can create a new *global.json* file in the current directory by executing the [dotnet new](dotnet-new.md) command, similar to the following example:

```dotnetcli
dotnet new globaljson --sdk-version 8.0.302 --roll-forward latestFeature
```

## Matching rules

> [!NOTE]
> The matching rules are governed by the `dotnet.exe` entry point, which is common across all installed .NET runtimes. The matching rules for the latest installed version of the .NET Runtime are used when you have multiple runtimes installed side-by-side or if you're using a *global.json* file.

The following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found, or *global.json* doesn't specify an SDK version and doesn't specify an `allowPrerelease` value, the highest installed SDK version is used (equivalent to setting `rollForward` to `latestMajor`). Whether prerelease SDK versions are considered depends on how `dotnet` is being invoked:
  - If you're **not** in Visual Studio, prerelease versions are considered.
  - If you're in Visual Studio, it uses the prerelease status requested. That is, if you're using a Preview version of Visual Studio or you set the **Use previews of the .NET SDK** option (under **Tools** > **Options** > **Environment** > **Preview Features**), prerelease versions are considered; otherwise, only release versions are considered.
- If a *global.json* file is found that doesn't specify an SDK version but it specifies an `allowPrerelease` value, the highest installed SDK version is used (equivalent to setting `rollForward` to `latestMajor`). Whether the latest SDK version can be release or prerelease depends on the value of `allowPrerelease`. `true` indicates prerelease versions are considered; `false` indicates that only release versions are considered.
- If a *global.json* file is found and it specifies an SDK version:

  - If no `rollForward` value is set, it uses `patch` as the default `rollForward` policy. Otherwise, check each value and their behavior in the [rollForward](#rollforward) section.
  - Whether prerelease versions are considered and what's the default behavior when `allowPrerelease` isn't set is described in the [allowPrerelease](#allowprerelease) section.

## Troubleshoot build warnings

- The following warnings indicate that your project was compiled using a prerelease version of the .NET SDK:

  > You're using a preview version of .NET. See: <https://aka.ms/dotnet-support-policy>

  .NET SDK versions have a history and commitment of being high quality. However, if you don't want to use a prerelease version, check the different strategies you can use in the [allowPrerelease](#allowprerelease) section. For machines that have never had a .NET Core 3.0 or higher runtime or SDK installed, you need to create a *global.json* file and specify the exact version you want to use.

- The following warning indicates that your project targets EF Core 1.0 or 1.1, which isn't compatible with .NET Core 2.1 SDK and later versions:

  > Startup project '{startupProject}' targets framework '.NETCoreApp' version '{targetFrameworkVersion}'. This version of the Entity Framework Core .NET Command-line Tools only supports version 2.0 or higher. For information on using older versions of the tools, see <https://go.microsoft.com/fwlink/?linkid=871254>.

  Starting with .NET Core 2.1 SDK (version 2.1.300), the `dotnet ef` command comes included in the SDK. To compile your project, install .NET Core 2.0 SDK (version 2.1.201) or earlier on your machine and define the desired SDK version using the *global.json* file. For more information about the `dotnet ef` command, see [EF Core .NET Command-line Tools](/ef/core/miscellaneous/cli/dotnet).

- If you're using *global.json* to stay on a specific version of the .NET SDK, note that Visual Studio only ever installs a single copy of the .NET SDK. So if you upgrade your Visual Studio version, it removes the previous version of the .NET SDK it had used to install the new version. It removes the old version even if it's a different major .NET version.

To avoid Visual Studio removing versions of the .NET SDK, install the stand-alone .NET SDK from the [download page](https://dotnet.microsoft.com/download/dotnet). However, if you do, you won't get automatic updates to that version of the .NET SDK anymore through Visual Studio and might be at risk for security issues.

## See also

- [How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved)
