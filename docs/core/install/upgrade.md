---
title: Upgrade to a new .NET version
description: Learn how to upgrade an app to a new .NET version. Upgrade .NET when the current version goes out of support or when you want to use new features of .NET. Control versions of SDK, analyzers, and packages for predictable builds.
ms.date: 10/28/2025
ai-usage: ai-assisted
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

- Open the project file (the `*.csproj`, `*.vbproj`, or `*.fsproj` file).
- Change the `<TargetFramework>` property value from, for example, `net6.0` to `net8.0`.
- The same pattern applies for the `<TargetFrameworks>` property if it is being used.

> [!TIP]
> The [GitHub Copilot app modernization - upgrade](../porting/github-copilot-app-modernization/overview.md) capability can make these changes automatically.

The next step is to build the project (or solution) with the new SDK. If additional changes are needed, the SDK will provide warnings and errors that guide you.

You might need to run `dotnet workload restore` to restore workloads with the new SDK version.

More resources:

- [Breaking changes in .NET 9](../compatibility/9.0.md)
- [Migrate an ASP.NET Core app](/aspnet/core/migration/)
- [Upgrade .NET MAUI from .NET 7 to .NET 8](https://github.com/dotnet/maui/wiki/Upgrading-.NET-MAUI-from-.NET-7-to-.NET-8)

## Version pinning

When you upgrade development tools like the .NET SDK, Visual Studio, or other components, you might encounter new behaviors, analyzer warnings, or breaking changes that affect your build process. By pinning to a version, you can upgrade your development environment while maintaining control over when specific components are updated in your projects.

Version pinning provides several benefits:

- **Predictable builds**: Ensures consistent build results across different machines and CI/CD environments.
- **Gradual adoption**: Allows you to adopt new features incrementally rather than all at once.
- **Avoid unexpected changes**: Prevents new analyzer rules, SDK behaviors, or package versions from causing build failures.
- **Team coordination**: Enables teams to upgrade together at a planned time rather than individually when tools update.
- **Debugging and troubleshooting**: Makes it easier to isolate issues when you control which versions changed.

The following sections describe various mechanisms for controlling versions of different components in your .NET projects:

- [Control SDK version with global.json](#control-sdk-version-with-globaljson)
- [Control analyzer behavior](#control-analyzer-behavior)
- [Control NuGet package versions](#control-nuget-package-versions)
- [Control MSBuild version](#control-msbuild-version)

### Control SDK version with global.json

You can pin the .NET SDK version for a project or solution by using a *global.json* file. This file specifies which SDK version to use when running .NET CLI commands and is independent of the runtime version your project targets.

Create a *global.json* file in your solution root directory:

```dotnetcli
dotnet new globaljson --sdk-version 9.0.100 --roll-forward latestFeature
```

This command creates the following *global.json* file that pins the SDK to version 9.0.100 or any later patch or feature band within the 9.0 major version:

```json
{
  "sdk": {
    "version": "9.0.100",
    "rollForward": "latestFeature"
  }
}
```

The `rollForward` policy controls how the SDK version is selected when the exact version isn't available. This configuration ensures that when you upgrade Visual Studio or install a new SDK, your project continues to use SDK 9.0.x until you explicitly update the *global.json* file.

For more information, see [global.json overview](../tools/global-json.md).

### Control analyzer behavior

Code analyzers can introduce new warnings or change behavior between versions. You can control analyzer versions to maintain consistent builds by using the [`AnalysisLevel` property](../project-sdk/msbuild-props.md#analysislevel). This property allows you to lock to a specific version of analyzer rules, preventing new rules from being introduced when you upgrade the SDK.

```xml
<PropertyGroup>
  <AnalysisLevel>9.0</AnalysisLevel>
</PropertyGroup>
```

When set to `9.0`, only the analyzer rules that shipped with .NET 9 are enabled, even if you're using the .NET 10 SDK. This prevents new .NET 10 analyzer rules from affecting your build until you're ready to address them.

For more information, see [AnalysisLevel](../project-sdk/msbuild-props.md#analysislevel).

### Control NuGet package versions

By managing package versions consistently across projects, you can prevent unexpected updates and maintain reliable builds.

- [Package lock files](#package-lock-files)
- [Central package management](#central-package-management)
- [Package source mapping](#package-source-mapping)

#### Package lock files

Package lock files ensure that package restore operations use the exact same package versions across different environments. The lock file (`packages.lock.json`) records the exact versions of all packages and their dependencies.

Enable lock files in your project file:

```xml
<PropertyGroup>
  <RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
</PropertyGroup>
```

To ensure builds fail if the lock file is out of date:

```xml
<PropertyGroup>
  <RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
  <RestoreLockedMode>true</RestoreLockedMode>
</PropertyGroup>
```

After enabling lock files, run `dotnet restore` to generate the *packages.lock.json* file. Commit this file to source control.

#### Central package management

Central package management (CPM) allows you to manage package versions in a single location for all projects in a solution. This approach simplifies version management and ensures consistency across projects.

Create a *Directory.Packages.props* file in your solution root:

```xml
<Project>
  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>

  <ItemGroup>
    <PackageVersion Include="Azure.Identity" Version="1.17.0" />
    <PackageVersion Include="Microsoft.Extensions.AI" Version="9.10.1" />
  </ItemGroup>
</Project>
```

In your project files, reference packages without specifying a version:

```xml
<ItemGroup>
  <PackageReference Include="Azure.Identity" />
  <PackageReference Include="Microsoft.Extensions.AI" />
</ItemGroup>
```

#### Package source mapping

Package source mapping allows you to control which NuGet feeds are used for specific packages, improving security and reliability.

Configure source mapping in your *nuget.config* file:

```xml
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
    <add key="contoso" value="https://contoso.com/packages/" />
  </packageSources>

  <packageSourceMapping>
    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
    <packageSource key="contoso">
      <package pattern="Contoso.*" />
    </packageSource>
  </packageSourceMapping>
</configuration>
```

This configuration ensures that all packages starting with `Contoso.` are only restored from the `contoso` feed, while other packages come from `nuget.org`.

For more information, see [NuGet package restore](../tools/dotnet-restore.md).

### Control MSBuild version

Visual Studio supports side-by-side installation of multiple versions. For example, you can install Visual Studio 2026 and Visual Studio 2022 on the same machine. Each Visual Studio version includes a corresponding .NET SDK. When you update Visual Studio, the included SDK version is updated as well. However, you can continue using older SDK versions by installing them separately from the [.NET download page](https://dotnet.microsoft.com/download).

MSBuild versions correspond to Visual Studio versions. For example, Visual Studio 2022 version 17.8 includes MSBuild 17.8. The .NET SDK also includes MSBuild. When you use `dotnet build`, you're using the MSBuild version included with the SDK specified by *global.json* or the latest installed SDK.

To use a specific MSBuild version:

- Use `dotnet build` with a pinned SDK version in *global.json*.
- Launch the appropriate Visual Studio Developer Command Prompt, which sets up the environment for that Visual Studio version's MSBuild.
- Directly invoke MSBuild from a specific Visual Studio installation (for example, `"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"`).

For more information, see [.NET SDK, MSBuild, and Visual Studio versioning](../porting/versioning-sdk-msbuild-vs.md).

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

## See also

- [Breaking changes in .NET 10](../compatibility/10.0.md)
- [Migrate an ASP.NET Core app](/aspnet/core/migration/)
