---
title: .NET Core 2 and later version binding
description: Learn How the .NET runtime finds and chooses versions during build and run for your program
author: billwagner
ms.author: wiwagn
ms.date: 06/21/2018
---
# .NET Core 2 and later version binding

.NET Core provides a single entry-point for operating on projects and built applications with the `dotnet` command. You may have multiple runtime and SDK versions installed. The `dotnet` command must select a version in the following cases:

- Select an SDK to use to run an SDK command (for example, with `dotnet new`).
- Select a runtime to target an application (for example, with `dotnet build`).
- Select a runtime to run an application (for example, with `dotnet run`).
- Select a runtime to publish an application (with `dotnet publish`).

The installation structure is machine global and in the path by default, enabling a developer to access all .NET Core versions from any command prompt. The structure enables updating all apps to use a new .NET Core patch version by installing it in this central structure/location. You may also use private .NET Core installations without use of the path.

.NET Core applies a set of policies that determine which versions of the .NET Core runtime and SDK are used. The different scenarios and policies are defined in this document.

These policies performing the following roles:

- Provide an implicit "version manager" experience.
- Enable easy and efficient deployment of .NET Core, including security and reliability updates.
- Enable developers to use the latest tools and commands independent of target runtime.

There are multiple points of version binding to consider:

- Select an [SDK](#select-an-sdk-version).
- Select a [target framework](#select-a-target-framework) for the application.
- Select a [minimum runtime version](#minimum-required-runtime-version)
- Selecting a runtime to run on


## Select an SDK version

Your first experience with .NET Core is typically with an SDK command, for example `dotnet new`, `dotnet build` or `dotnet run`. The `dotnet` command must use a chosen version of the SDK for these commands. .NET Core uses the latest SDK. You will use the .NET Core 99.9 SDK when it's installed, even if you're using the SDK command for .NET Core 2.0 development.

You take advantage of the latest SDK features and improvements while targeting earlier .NET Core versions. You may target multiple versions of .NET Core on multiple projects. You can use the same tools for all projects.

When needed, you configure `dotnet` to use a different version of the SDK. You specify that version in a [global.json file](../tools/global-json.md). The "use latest" policy means you only use `global.json` to specify a .NET Core version earlier than the latest installed version.

`global.json`can be used at different scopes:

- Per project, placed beside the project file.
- For a set of projects, placed at a common [grand-]parent for all of the projects. This location can be as high in the directory structure as the root of a drive.

The following example shows the `global.json` syntax:

``` json
{
  "sdk": {
    "version": "1.0.0"
  }
}
```

You only use `global.json` to specify a version when you must lock a specific app or set of apps to an earlier SDK than the latest on the machine.

The process for selecting an SDK version is:

- `dotnet` binds to latest SDK by default.
- You can override the latest version using global.json.
- `dotnet` uses the first global.json file found, iteratively reverse-navigating the path upward from the current working directory.

## Select a target SDK

You specify the target framework in the project file. Set the `TargetFramework` as shown in the following example:

``` xml
<TargetFramework>netcoreapp2.0</TargetFramework>
```

You can set multiple target frameworks if you need to build different code for different targets. Setting multiple target frameworks is more common for libraries, but can be done with applications as well. You specify a `TargetFrameworks` property (plural of `TargetFramework`). The target frameworks will be semicolon-delimited as shown in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
```

A given SDK will support a fixed set of frameworks, typically capped to the target framework of the runtime(s) it includes. For example, the .NET Core 2.0 SDK includes the .NET Core 2.0 runtime, which is an implementation of the `netcoreapp2.0` target framework. The .NET Core 2.0 SDK will support `netcoreapp1.0`, `netcoreapp1.1` and `netcoreapp2.0` but not `netcoreapp2.1` (or higher). You will need to install the .NET Core 2.1 SDK in order to build for `netcoreapp2.1`. 

.NET Standard target frameworks are also capped in the same way. The .NET Core 2.0 SDK will be capped to `netstandard2.0`.

A given SDK will define a fixed minimum runtime patch version for each target framework that it supports. The minimum runtime patch version will be maintained at the `.0` version (for example, `2.0.0`) for the lifetime of a major/minor runtime version family. This policy makes deploying patches a web hoster concern and not a developer concern.

Hosters and other users have reported challenges with the .NET Core 1.x behavior, where the minimum patch version increases with each .NET Core SDK release. See: [Reconsider implicitly using the latest patch version of the targeted version of .NET Core in the SDK](https://github.com/dotnet/sdk/issues/983). This proposal is intended to resolve their feedback.

The SDK stores the minimum patch version for each supported target framework in the `~\dotnet\sdk\1.0.0\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.DefaultItems.targets` file.

The minimum runtime patch version is stored in the application directory in the `*.runtimeconfig.json` file. This value is used as part of runtime selection. You are not intended to edit this file.

You can override the minimum runtime patch version (to higher or lower versions) in the project file, as you can see in the following example:

``` xml
<RuntimeFrameworkVersion>2.0.4</RuntimeFrameworkVersion>
```

When you target multiple target frameworks, you must specify the minimum runtime patch version to the specific .NET Core target framework, as shown in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
<RuntimeFrameworkVersion Condition="'$(TargetFramework)' == 'netcoreapp2.0'">2.0.4</RuntimeFrameworkVersion>
```

A given SDK supports a fixed set of target frameworks. Typically, the target frameworks are the SDK framework version and a set of earlier versions.

## Minimum required runtime version

You run an application from source with `dotnet run`. `dotnet run` both builds and runs an application.

The built application runs on machines that satisfy the minimum required runtime patch version, stored in the `*.runtimeconfig.json` file. The highest patch version is selected. For example, the `2.0.4` runtime is selected in the case that the minimum runtime version is `2.0.0` while `2.0.0`, `2.0.1` and `2.0.4` are all installed on the machine. Higher minor or major versions (for example, `2.1.1` or `3.0.1`) won't be considered. Lower versions also won't be considered.

It is an error if the minimum version specified for an application is not satisfied. However, you may run an application on a machine that is missing the runtime required by the application. If a higher minor version is installed, the minor version is used instead of failing. Higher major versions will not be used to load applications. This behavior is referred to as "minor version roll-forward."

Consider an application requiring 2.0.4, `dotnet` would search and bind to a runtime in this order:

- 2.0.* (highest patch version; ensure that it satisfies 2.0.4 as a lower bound)
- 2.* (highest minor version)

If neither is found, you see an error message similar to the following:

> This application requires .NET Core 2.0.4. Please install .NET Core 2.0.4 or a higher compatible version.
> Please see https://aka.ms/install-dotnet-core to learn about .NET Core installation and runtime versioning.

A few usage examples demonstrate the desired behavior:

- 2.0.4 is required. 2.0.5 is the highest patch version available. 2.0.5 is used.
- 2.0.4 is required. No 2.0.* versions are installed. 1.1.1 is the highest runtime installed. An error message is printed.
- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is the highest 2.x runtime version installed. 2.2.2 is used.
- 2.0.4 is required. No 2.x versions are installed. 3.0.0 is installed. An error message is printed.

Minor version roll-forward has one side-effect that may affect end users. Consider the following scenario:

- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is installed. It is used.
- 2.0.5 is later installed. 2.0.5 will be used for subsequent application launches, not 2.2.2.
- It is possible that 2.0.5 and 2.2.2 might behave differently, particularly for scenarios like serializing binary data.

You also need to understand how NuGet dependencies are treated. An application might be built for .NET Core 2.0 but run on .NET Core 2.1 due to this algorithm. There may be later versions of an application's NuGet dependencies that target .NET Core 2.1. These later versions are not considered or installed. All NuGet dependencies are resolved as part of the publish operation and reside as assemblies (.dlls) in a flat directory structure. These assemblies should run on .NET Core 2.1 due to its compatibility promise for existing applications and binaries.

Occasionally, ASP.NET packages are deployed via a web host rather than with a published application. In those cases, the web host should correctly configure their environments based on published guidance such that all supported ASP.NET applications run correctly.

Developers should remember the following rules:

- Runtimes are searched for in the following order (the first found is loaded):
  - Highest patch version (check that the minimum runtime path version is satisfied, otherwise error)
  - Highest minor version
- If an acceptable runtime is not found, the application does not run and an error message explains why.

## Publish a self-contained application

You can publish an application as a **self-contained distribution**. This approach includes .NET Core. Self-contained distributions do not have a dependency on runtime environments. Runtime binding occurs at publishing time, not run-time.

The publishing process will select the latest patch version of the given runtime family. For example, `dotnet publish` will select .NET Core 2.0.4 if it is the latest patch version in the .NET Core 2.0 runtime family, independent of the existence of earlier patch versions or minimum runtime patch version values. This differs from `dotnet build` runtime selection for two reasons:

- The application doesn't specify a hosting environment.
- The developer generates a final configuration for the application (that can't be practically modified). The best runtime choice is the latest installed runtime patch version. It's the same version used for development and it has the latest (per the machine) security and reliability fixes.

Note that the `runtimeframeworkversion` element will override the default version policy if that element is present in the project file.

It is an error if the minimum version specified for an application is not satisfied. `dotnet publish` binds to latest runtime patch version (within a given major.minor version family). `dotnet publish` does not support the roll-forward semantics of `dotnet run`.

## Publish an application with a specific .NET Core version

`dotnet publish` accepts a version to use for publishing for both self-contained and framework-dependent apps. This is primarily for CI/CD scenarios or other times when you must publish an application, but can't update source code.

You publish with the latest runtime patch version for the given target framework specifying `--latest`. This argument has the same default runtime binding behavior for publishing self-contained applications. You can see this in the following example:

``` console
dotnet publish -c release -o app --latest
```

You publish with a specific runtime patch version for the given target framework specifying `--version=[version]`. It is an error if this version is missing. It's an error if the given version doesn't support the target framework (as a lower bound). You may specify higher versions (even major versions), provided they exist on the machine. You can see this usage in the following example:

``` console
dotnet publish -c release -o app --version=3.1.0
```
