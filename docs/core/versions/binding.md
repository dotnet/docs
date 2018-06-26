---
title: .NET Core version binding
description: Learn How .NET Core finds and chooses runtime versions for your program.
author: billwagner
ms.author: wiwagn
ms.date: 06/21/2018
---
# .NET Core version binding

Rework notes:  Keep clear separation between SDK & runtime selection.


[!INCLUDE [topic-appliesto-net-core-2plus](../../../includes/topic-appliesto-net-core-2plus.md)]

.NET Core provides a single entry-point for operating on projects and built applications with the `dotnet` command. You may have multiple runtime and SDK versions installed. The `dotnet` command must:

- Select an SDK to use to run an SDK command (for example, with `dotnet new`).
- Select a runtime to target an application (for example, with `dotnet build`).
- Select a runtime to run an application (for example, with `dotnet run`).
- Select a runtime to publish an application (with `dotnet publish`).

The installation structure is machine global and in the path by default. The structure enables updating all apps to use a new .NET Core patch version by installing it in this central structure/location. You may also use private .NET Core installations without use of the path.

.NET Core applies a set of policies that determines which versions of the .NET Core runtime and SDK are used. The different scenarios and policies are defined in this document.

These policies perform the following roles:

- Enable easy and efficient deployment of .NET Core, including security and reliability updates.
- Enable developers to use the latest tools and commands independent of target runtime.

There are multiple actions where version binding takes place:

- Select an [SDK](#select-an-sdk-version).
- Select a [target framework](#build-time-version-binding) for the application.
- Select a [minimum runtime version](#runtime-version-binding).

## Select an SDK version

Your first experience with .NET Core is typically with an SDK command, for example `dotnet new`, `dotnet build` or `dotnet run`. The `dotnet` command must use a chosen version of the SDK for these commands. .NET Core uses the latest SDK by default. You'll use the .NET Core 99.9 SDK when it's installed, even if the project you are working with targets the .NET Core Runtime 2.0. Note that this is true for preview versions as well as released versions.

You can take advantage of the latest SDK features and improvements while targeting earlier .NET Core runtime versions. You can target multiple runtime versions of .NET Core on different projects, using the same SDK tools for all projects.

When needed, you configure `dotnet` to use a different version of the SDK. You specify that version in a [global.json file](../tools/global-json.md). The "use latest" policy means you only use `global.json` to specify a .NET Core version earlier than the latest installed version.

`global.json` can be placed anywhere in the file hierarchy. The CLI searches upward from the project directory for the first `global.json` it finds. You control which projects a given `global.json` applies to by its place in the file system:

Search for a global.json file, iteratively navigating the path upward from the current working directory. If a global.json is found:

- Use the SDK it specifies if that version is found.
- If the SDK specified in the global.json is not found, roll forward to the latest SDK.
- If no global.json file is found, use the latest SDK

The following example shows the `global.json` syntax:

``` json
{
  "sdk": {
    "version": "2.0.0"
  }
}
```

The process for selecting an SDK version is:

- `dotnet` searches for a `global.json` file iteratively reverse-navigating the path upward from the current working directory.
- `dotnet` uses the SDK specified in the first `global.json` found.
- `dotnet` binds to the latest installed SDK if no `global.json` is found.

## Build time version binding

You build your project against APIs defined in a **Target Framework Moniker** (TFM). You specify the target framework in the project file. Set the `TargetFramework` element in your project file as shown in the following example:

``` xml
<TargetFramework>netcoreapp2.0</TargetFramework>
```

You may build your project against multiple frameworks. Setting multiple target frameworks is more common for libraries but can be done with applications as well. You specify a `TargetFrameworks` property (plural of `TargetFramework`). The target frameworks will be semicolon-delimited as shown in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
```

A given SDK supports a fixed set of frameworks,  capped to the target framework of the runtime it ships with. For example, the .NET Core 2.0 SDK includes the .NET Core 2.0 runtime, which is an implementation of the `netcoreapp2.0` target framework. The .NET Core 2.0 SDK will support `netcoreapp1.0`, `netcoreapp1.1`, and `netcoreapp2.0` but not `netcoreapp2.1` (or higher). You install the .NET Core 2.1 SDK to build for `netcoreapp2.1`

.NET Standard target frameworks are also capped in the same way. The .NET Core 2.0 SDK is capped to `netstandard2.0`.

You can override the minimum runtime patch version (to higher or lower versions) in the project file, as shown in the following example:

``` xml
<RuntimeFrameworkVersion>2.0.4</RuntimeFrameworkVersion>
```

 The `RuntimeFrameworkVersion` element will override the default version policy if that element is present in the project file. When you target multiple frameworks, you must specify the minimum runtime patch version to the specific target framework, as shown in the following example for .NET Core:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
<RuntimeFrameworkVersion Condition="'$(TargetFramework)' == 'netcoreapp2.0'">2.0.4</RuntimeFrameworkVersion>
```

A given SDK supports a fixed set of target frameworks. Typically, the target frameworks are the SDK framework version and all earlier versions.

## Runtime version binding

You run an application from source with [`dotnet run`](../tools/dotnet-run.md). `dotnet run` both builds and runs an application.

The built application runs on machines that satisfy the minimum required runtime patch version, stored in the `*.runtimeconfig.json` file. The highest patch version is selected. For example, the `2.0.4` runtime is selected in the case that the minimum runtime version is `2.0.0` while `2.0.0`, `2.0.1` and `2.0.4` are all installed on the machine. This behavior is referred to as "minor version roll-forward." Higher minor or major versions (for example, `2.1.1` or `3.0.1`) won't be considered. Lower versions also won't be considered. When no acceptable runtime is installed, the application will not run.

Consider an application requiring 2.0.4, `dotnet` would search and bind to a runtime in this order:

- 2.0.* (highest patch version; ensure that it satisfies 2.0.4 as a lower bound)
- 2.* (highest minor version)

If neither is found, you see an error message similar to the following example:

> This application requires .NET Core 2.0.4. Please install .NET Core 2.0.4 or a higher compatible version.
> Please see https://www.microsoft.com/net/download to learn about .NET Core installation and runtime versioning.

A few usage examples demonstrate the behavior:

- 2.0.4 is required. 2.0.5 is the highest patch version available. 2.0.5 is used.
- 2.0.4 is required. No 2.0.* versions are installed. 1.1.1 is the highest runtime installed. An error message is printed.
- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is the highest 2.x runtime version installed. 2.2.2 is used.
- 2.0.4 is required. No 2.x versions are installed. 3.0.0 is installed. An error message is printed.

Minor version roll-forward has one side-effect that may affect end users. Consider the following scenario:

- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is installed. 2.2.2 is used.
- 2.0.5 is later installed. 2.0.5 will be used for subsequent application launches, not 2.2.2.
- It's possible that 2.0.5 and 2.2.2 might behave differently, particularly for scenarios like serializing binary data.

All NuGet dependencies are resolved as part of the publish operation and reside as assemblies (.dlls) in a flat directory structure. These assemblies should run on .NET Core 2.1 due to its compatibility promise for existing applications and binaries.

Developers should remember the following rules:

- Runtimes are searched for in the following order (the first found is loaded):
  - Highest patch version (check that the minimum runtime patch version is satisfied, otherwise error)
  - Highest minor version
- If an acceptable runtime is not found, the application does not run and an error message explains why.

## Publish a self-contained application

You can publish an application as a [**self-contained distribution**](../deploying/index.md#self-contained-deployments-scd). This approach includes .NET Core. Self-contained distributions do not have a dependency on runtime environments. Runtime binding occurs at publishing time, not run-time.

The publishing process will select the latest patch version of the given runtime family. For example, `dotnet publish` will select .NET Core 2.0.4 if it is the latest patch version in the .NET Core 2.0 runtime family, independent of the existence of earlier patch versions or minimum runtime patch version values. The publishing process differs from `dotnet build` runtime selection for two reasons:

- The application doesn't specify a hosting environment.
- The developer generates a target framework for the application.

The target framework (including the latest installed security patches) are packaged with the application.

It is an error if the minimum version specified for an application is not satisfied. `dotnet publish` binds to latest runtime patch version (within a given major.minor version family). `dotnet publish` does not support the roll-forward semantics of `dotnet run`.

## Publish an application with a specific .NET Core version

`dotnet publish` accepts a version to use for publishing for both self-contained and runtime-dependent apps. This is primarily for CI/CD scenarios or other times when you must publish an application, but can't update source code.
