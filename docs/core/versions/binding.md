---
title: .NET Core version binding
description: Learn How .NET Core finds and chooses runtime versions for your program.
author: billwagner
ms.author: wiwagn
ms.date: 06/27/2018
---
# .NET Core version binding

[!INCLUDE [topic-appliesto-net-core-2plus](../../../includes/topic-appliesto-net-core-2plus.md)]

This article explains the policies used by the .NET Core tools, SDK, and runtime for selecting versions. These policies provide a balance between always running applications using the specified versions and enabling ease of upgrading both developer and end user machines. These policies perform the following:

- Easy and efficient deployment of .NET Core, including security and reliability updates.
- Usage of the latest tools and commands independent of target runtime.

There are four activities during development and deployment where version binding occurs:

- When you [run an SDK command](#the-sdk-uses-the-latest-installed-version).
- When you [build an assembly](target-framework-monikers-define-build-time-apis).
- When you [run a .NET Core application](dotnet-run-rolls-forward).
- When you publish a [self-contained application](self-contained-deployments-include-the-selected-runtime).

The rest of this document examines those four scenarios.

## The SDK uses the latest installed version

SDK commands include `dotnet new`, `dotnet build` or `dotnet run`. The `dotnet` CLI must choose an SDK version for any command. The .NET Core CLI uses the latest SDK installed on the machine. You'll use the .NET Core 99.9 SDK when it's installed, even if the project you are working with targets the .NET Core Runtime 2.0. Note that this is true for preview versions as well as released versions. You can take advantage of the latest SDK features and improvements while targeting earlier .NET Core runtime versions. You can target multiple runtime versions of .NET Core on different projects, using the same SDK tools for all projects.

On rare occasions, you may need to use a different version of the SDK. You specify that version in a [global.json file](../tools/global-json.md). The "use latest" policy means you only use `global.json` to specify a .NET Core version earlier than the latest installed version.

`global.json` can be placed anywhere in the file hierarchy. The CLI searches upward from the project directory for the first `global.json` it finds. You control which projects a given `global.json` applies to by its place in the file system. The .NET CLI searches for a `global.json` file iteratively navigating the path upward from the current working directory. The first `global.json` file found specifies the version used. If that version is installed, that version is used. If the SDK specified in the global.json is not found, the .NET CLI rolls forward to the latest SDK installed. This is the same as the default behavior, when no global.json file is found.

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

## Target Framework Monikers define build time APIs

You build your project against APIs defined in a **Target Framework Moniker** (TFM). You specify the target framework in the project file. Set the `TargetFramework` element in your project file as shown in the following example:

``` xml
<TargetFramework>netcoreapp2.0</TargetFramework>
```

You may build your project against multiple TFMs. Setting multiple target frameworks is more common for libraries but can be done with applications as well. You specify a `TargetFrameworks` property (plural of `TargetFramework`). The target frameworks will be semicolon-delimited as shown in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
```

A given SDK supports a fixed set of frameworks, capped to the target framework of the runtime it ships with. For example, the .NET Core 2.0 SDK includes the .NET Core 2.0 runtime, which is an implementation of the `netcoreapp2.0` target framework. The .NET Core 2.0 SDK will support `netcoreapp1.0`, `netcoreapp1.1`, and `netcoreapp2.0` but not `netcoreapp2.1` (or higher). You install the .NET Core 2.1 SDK to build for `netcoreapp2.1`

.NET Standard target frameworks are also capped in the same way. The .NET Core 2.0 SDK is capped to `netstandard2.0`.

You can override the minimum runtime patch version (to higher or lower versions) in the project file, as shown in the following example:

``` xml
<RuntimeFrameworkVersion>2.0.4</RuntimeFrameworkVersion>
```

 The `RuntimeFrameworkVersion` element  overrides the default version policy. When you target multiple frameworks, you must specify the minimum runtime patch version to the specific target framework, as shown in the following example for .NET Core:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
<RuntimeFrameworkVersion Condition="'$(TargetFramework)' == 'netcoreapp2.0'">2.0.4</RuntimeFrameworkVersion>
```

## dotnet run rolls forward

You run an application from source with [`dotnet run`](../tools/dotnet-run.md). `dotnet run` both builds and runs an application.

The .NET CLI chooses the latest patch version installed on the machine. For example, if you specified `netcoreapp2.0` in your project file, and `2.0.4` is the latest .NET runtime installed, the `2.0.4` runtime is used.

If no acceptable `2.0.*` version is found, a new `2.*` version will be used. For example, if you specified `netcoreapp2.0` and only `2.1.0` is installed, the application will run using the `2.1.0` runtime. This This behavior is referred to as "minor version roll-forward." Lower versions also won't be considered. When no acceptable runtime is installed, the application will not run.

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

## Self-contained deployments include the selected runtime

You can publish an application as a [**self-contained distribution**](../deploying/index.md#self-contained-deployments-scd). This approach includes .NET Core. Self-contained distributions do not have a dependency on runtime environments. Runtime binding occurs at publishing time, not run-time.

The publishing process selects the latest patch version of the given runtime family. For example, `dotnet publish` will select .NET Core 2.0.4 if it is the latest patch version in the .NET Core 2.0 runtime family. The target framework (including the latest installed security patches) are packaged with the application.

It is an error if the minimum version specified for an application is not satisfied. `dotnet publish` binds to latest runtime patch version (within a given major.minor version family). `dotnet publish` does not support the roll-forward semantics of `dotnet run`.
