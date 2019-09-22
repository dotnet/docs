---
title: Select which .NET Core version to use
description: Learn how .NET Core automatically finds and chooses runtime versions for your program. Additionally, this article teaches you how to force a specific version.
author: thraka
ms.author: adegeo
ms.date: 06/26/2019
ms.custom: "seodec18"
---

# Select the .NET Core version to use

This article explains the policies used by the .NET Core tools, SDK, and runtime for selecting versions. These policies provide a balance between running applications using the specified versions and enabling ease of upgrading both developer and end-user machines. These policies perform the following actions:

- Easy and efficient deployment of .NET Core, including security and reliability updates.
- Use the latest tools and commands independent of target runtime.

Version selection occurs:

- When you run an SDK command, [the SDK uses the latest installed version](#the-sdk-uses-the-latest-installed-version).
- When you build an assembly, [target framework monikers define build time APIs](#target-framework-monikers-define-build-time-apis).
- When you run a .NET Core application, [target framework dependent apps roll forward](#framework-dependent-apps-roll-forward).
- When you publish a self-contained application, [self-contained deployments include the selected runtime](#self-contained-deployments-include-the-selected-runtime).

The rest of this document examines those four scenarios.

## The SDK uses the latest installed version

SDK commands include `dotnet new` and `dotnet run`. The .NET Core CLI must choose an SDK version for every `dotnet` command. It uses the latest SDK installed on the machine by default, even if:

- The project targets an earlier version of the .NET Core runtime.
- The latest version of the .NET Core SDK is a preview version.

You can take advantage of the latest SDK features and improvements while targeting earlier .NET Core runtime versions. You can target multiple runtime versions of .NET Core on different projects, using the same SDK tools for all projects.

On rare occasions, you may need to use an earlier version of the SDK. You specify that version in a [*global.json* file](../tools/global-json.md). The "use latest" policy means you only use *global.json* to specify a .NET Core SDK version earlier than the latest installed version.

*global.json* can be placed anywhere in the file hierarchy. The CLI searches upward from the project directory for the first *global.json* it finds. You control which projects a given *global.json* applies to by its place in the file system. The .NET CLI searches for a *global.json* file iteratively navigating the path upward from the current working directory. The first *global.json* file found specifies the version used. If that SDK version is installed, that version is used. If the SDK specified in the *global.json* is not found, the .NET CLI uses [Matching rules](../tools/global-json.md#matching-rules) to select a compatible SDK, or fail if none is found.

The following example shows the *global.json* syntax:

``` json
{
  "sdk": {
    "version": "2.0.0"
  }
}
```

The process for selecting an SDK version is:

1. `dotnet` searches for a *global.json* file iteratively reverse-navigating the path upward from the current working directory.
1. `dotnet` uses the SDK specified in the first *global.json* found.
1. `dotnet` uses the latest installed SDK if no *global.json* is found.

You can learn more about selecting an SDK version in the [Matching rules](../tools/global-json.md#matching-rules) section of the article on *global.json*.

## Target Framework Monikers define build time APIs

You build your project against APIs defined in a **Target Framework Moniker** (TFM). You specify the [target framework](../../standard/frameworks.md) in the project file. Set the `TargetFramework` element in your project file as shown in the following example:

``` xml
<TargetFramework>netcoreapp2.0</TargetFramework>
```

You may build your project against multiple TFMs. Setting multiple target frameworks is more common for libraries but can be done with applications as well. You specify a `TargetFrameworks` property (plural of `TargetFramework`). The target frameworks are semicolon-delimited as shown in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
```

A given SDK supports a fixed set of frameworks, capped to the target framework of the runtime it ships with. For example, the .NET Core 2.0 SDK includes the .NET Core 2.0 runtime, which is an implementation of the `netcoreapp2.0` target framework. The .NET Core 2.0 SDK supports `netcoreapp1.0`, `netcoreapp1.1`, and `netcoreapp2.0` but not `netcoreapp2.1` (or higher). You install the .NET Core 2.1 SDK to build for `netcoreapp2.1`.

.NET Standard target frameworks are also capped to the target framework of the runtime the SDK ships with. The .NET Core 2.0 SDK is capped to `netstandard2.0`.

## Framework-dependent apps roll forward

When you run an application from source with [`dotnet run`](../tools/dotnet-run.md), from a [**framework-dependent deployment**](../deploying/index.md#framework-dependent-deployments-fdd) with [`dotnet myapp.dll`](../tools/dotnet.md#description), or from a [**framework-dependent executable**](../deploying/index.md#framework-dependent-executables-fde) with `myapp.exe`, the `dotnet` executable is the **host** for the application.

The host chooses the latest patch version installed on the machine. For example, if you specified `netcoreapp2.0` in your project file, and `2.0.4` is the latest .NET runtime installed, the `2.0.4` runtime is used.

If no acceptable `2.0.*` version is found, a new `2.*` version is used. For example, if you specified `netcoreapp2.0` and only `2.1.0` is installed, the application runs using the `2.1.0` runtime. This behavior is referred to as "minor version roll-forward." Lower versions also won't be considered. When no acceptable runtime is installed, the application won't run.

A few usage examples demonstrate the behavior, if you target 2.0:

- 2.0 is specified. 2.0.5 is the highest patch version installed. 2.0.5 is used.
- 2.0 is specified. No 2.0.* versions are installed. 1.1.1 is the highest runtime installed. An error message is displayed.
- 2.0 is specified. No 2.0.* versions are installed. 2.2.2 is the highest 2.x runtime version installed. 2.2.2 is used.
- 2.0 is specified. No 2.x versions are installed. 3.0.0 is installed. An error message is displayed.

Minor version roll-forward has one side-effect that may affect end users. Consider the following scenario:

1. The application specifies that 2.0 is required.
2. When run, version 2.0.* is not installed, however, 2.2.2 is. Version 2.2.2 will be used.
3. Later, the user installs 2.0.5 and runs the application again, 2.0.5 will now be used.

It's possible that 2.0.5 and 2.2.2 behave differently, particularly for scenarios like serializing binary data.

## Self-contained deployments include the selected runtime

You can publish an application as a [**self-contained distribution**](../deploying/index.md#self-contained-deployments-scd). This approach bundles the .NET Core runtime and libraries with your application. Self-contained deployments don't have a dependency on runtime environments. Runtime version selection occurs at publishing time, not run time.

The publishing process selects the latest patch version of the given runtime family. For example, `dotnet publish` will select .NET Core 2.0.4 if it is the latest patch version in the .NET Core 2.0 runtime family. The target framework (including the latest installed security patches) is packaged with the application.

It's an error if the minimum version specified for an application isn't satisfied. `dotnet publish` binds to the latest runtime patch version (within a given major.minor version family). `dotnet publish` doesn't support the roll-forward semantics of `dotnet run`. For more information about patches and self-contained deployments, see the article on [runtime patch selection](../deploying/runtime-patch-selection.md) in deploying .NET Core applications.

Self-contained deployments may require a specific patch version. You can override the minimum runtime patch version (to higher or lower versions) in the project file, as shown in the following example:

``` xml
<RuntimeFrameworkVersion>2.0.4</RuntimeFrameworkVersion>
```

The `RuntimeFrameworkVersion` element  overrides the default version policy. For self-contained deployments, the `RuntimeFrameworkVersion` specifies the *exact* runtime framework version. For framework-dependent applications, the `RuntimeFrameworkVersion` specifies the *minimum* required runtime framework version.
