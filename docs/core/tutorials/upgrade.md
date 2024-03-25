---
title: Upgrade to a new .NET version
description: Learn how to upgrade an app to a new .NET version.
ms.topic: how-to
ms.date: 03/25/2024
---
# Upgrade to a new .NET version

New .NET versions are [released each year](https://github.com/dotnet/core/blob/main/releases.md). Many developers start the upgrade process as soon as the new version is available, while others wait until the version they are using is no longer supported. The upgrade process has multiple aspects to consider.

## Requesting an upgrade (as a user)

You may need an app to use a new .NET version and to make a rquest to the team or vendor that produced the app.

Common reasons to upgrade to a new .NET version:

- The currently used .NET version is no longer supported
- The new version supports a new operating system
- The new version has an important performance or security feature

## Upgrading development environment

The .NET SDK is the primary component to install, to upgrade to a new .NET version. It includes an updated .NET CLI, build system, and runtime version. 

The .NET website offers [installers and archives](https://dotnet.microsoft.com/download) that can be downloaded and used on any supported operating system and architecture.

Some operating systems have a package manager that can be used to install a new .NET version, which may be a prefered option for some users.

- [macOS](https://formulae.brew.sh/cask/dotnet-sdk)
- [Linux](https://learn.microsoft.com/dotnet/core/install/linux)
- [Windows](https://github.com/microsoft/winget-pkgs/tree/master/manifests/m/Microsoft/DotNet/SDK)

Visual Studio installs [new .NET SDK versions automatically](https://learn.microsoft.com/dotnet/core/porting/versioning-sdk-msbuild-vs). For Visual Studio users, upgrading to a newer Visual Studio version will be sufficient.

## Upgrading source code

The only required change to upgrade an app is updating the `TargetFramework` property in a project file to the newer .NET version.

Here's how to do it:

* Open the project file (the `*.csproj`, `*.vbproj`, or `*.fsproj` file).
* Change the `<TargetFramework>` property value from, for example, `net6.0` to `net8.0`.
* The same pattern applies for the `<TargetFrameworks>` property if it is being used.

The next step is to build the project (or solution) with the new SDK. The SDK will provide warnings and errors that guide any additional changes that are needed.

`dotnet workload restore` may be needed to restore workloads with the new SDK version.

More resources:

* [Breaking changes in .NET 8](https://docs.microsoft.com/dotnet/core/compatibility/8.0)
* [Migrate from ASP.NET Core in .NET 7 to .NET 8](https://learn.microsoft.com/aspnet/core/migration/70-80?view=aspnetcore-8.0&tabs=visual-studio)
* [Upgrading .NET MAUI from .NET 7 to .NET 8](https://github.com/dotnet/maui/wiki/Upgrading-.NET-MAUI-from-.NET-7-to-.NET-8)

## Updating continuous integration (CI)

CI pipelines follow a similar update process as project files and Dockerfiles. [CI pipelines](https://github.com/actions/setup-dotnet) can typically be updated with changing only version values.


## Updating hosting environment

There are many patterns that are used for hosting applications. If the hosting environment includes the .NET runtime, then the new version of the .NET runtime will need to be installed. On Linux, [dependencies](https://github.com/dotnet/core/blob/main/release-notes/8.0/linux-packages.md) need to be installed, however, they typically do not change across .NET versions.

For containers, [`FROM` statements](https://github.com/dotnet/dotnet-docker/blob/e5e8164460037e77902cd269c788eccbdeea5edd/samples/aspnetapp/Dockerfile#L17) need to be changed to include new version numbers.

The following Dockerfile example demonstrates pulling an ASP.NET Core 8.0 image.

```dockerfile=
FROM mcr.microsoft.com/dotnet/aspnet:8.0
```

In a cloud service like [Azure App Service](https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore), a configuration change will be needed.
