---
title: Upgrade to a new .NET version
description: Learn how to upgrade an app to a new .NET version. Upgrade .NET when the current version goes out of support or when you want to use new features of .NET.
ms.date: 11/11/2024
---

# Upgrade to a new .NET version

New .NET versions are [released each year](https://github.com/dotnet/core/blob/main/releases.md). Many developers start the upgrade process as soon as the new version is available, while others wait until the version they are using is no longer supported. The upgrade process has multiple aspects to consider.

Common reasons to upgrade to a new .NET version:

- The currently used .NET version is no longer supported
- The new version supports a new operating system
- The new version has an important API, performance, or security feature

## Upgrade development environment

To upgrade to a new .NET version, the .NET SDK is the primary component to install. It includes an updated .NET CLI, build system, and runtime version.

The .NET website offers [installers and archives](https://dotnet.microsoft.com/download) that you can download and use on any supported operating system and architecture.

Some operating systems have a package manager that you can also use to install a new .NET version, which you might prefer.

- [macOS](https://formulae.brew.sh/cask/dotnet-sdk)
- [Linux](linux.md)
- [Windows](https://github.com/microsoft/winget-pkgs/tree/master/manifests/m/Microsoft/DotNet/SDK)

Visual Studio installs [new .NET SDK versions automatically](../porting/versioning-sdk-msbuild-vs.md). For Visual Studio users, it's sufficient to upgrade to a newer Visual Studio version.

## Upgrade source code

The only required change to upgrade an app is updating the `TargetFramework` property in a project file to the newer .NET version.

Here's how to do it:

* Open the project file (the `*.csproj`, `*.vbproj`, or `*.fsproj` file).
* Change the `<TargetFramework>` property value from, for example, `net6.0` to `net8.0`.
* The same pattern applies for the `<TargetFrameworks>` property if it is being used.

> [!TIP]
> The [GitHub Copilot app modernization - upgrade](../porting/github-copilot-app-modernization-overview.md) capability can make these changes automatically.

The next step is to build the project (or solution) with the new SDK. If additional changes are needed, the SDK will provide warnings and errors that guide you.

You might need to run `dotnet workload restore` to restore workloads with the new SDK version.

More resources:

* [Breaking changes in .NET 9](../compatibility/9.0.md)
* [Migrate from ASP.NET Core in .NET 7 to .NET 8](/aspnet/core/migration/70-80?tabs=visual-studio)
* [Upgrade .NET MAUI from .NET 7 to .NET 8](https://github.com/dotnet/maui/wiki/Upgrading-.NET-MAUI-from-.NET-7-to-.NET-8)

## Update continuous integration (CI)

CI pipelines follow a similar update process as project files and Dockerfiles. Typically, you can update [CI pipelines](https://github.com/actions/setup-dotnet) by changing only version values.

## Update hosting environment

There are many patterns that are used for hosting applications. If the hosting environment includes the .NET runtime, then the new version of the .NET runtime needs to be installed. On Linux, [dependencies](https://github.com/dotnet/core/blob/main/release-notes/8.0/linux-packages.md) need to be installed, however, they typically don't change across .NET versions.

For containers, [`FROM` statements](https://github.com/dotnet/dotnet-docker/blob/e5e8164460037e77902cd269c788eccbdeea5edd/samples/aspnetapp/Dockerfile#L17) need to be changed to include new version numbers.

The following Dockerfile example demonstrates pulling an ASP.NET Core 9.0 image.

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
```

In a cloud service like [Azure App Service](/azure/app-service/quickstart-dotnetcore), a configuration change is needed.
