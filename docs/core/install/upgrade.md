---
title: Upgrade to a new .NET version
description: Learn how to upgrade an app to a new .NET version. Upgrade .NET when the current version goes out of support or when you want to use new features of .NET. Control versions of SDK, analyzers, and packages for predictable builds.
ms.date: 11/11/2024
ai-usage: ai-assisted
---

# Upgrade to a new .NET version

New .NET versions are [released each year](https://github.com/dotnet/core/blob/main/releases.md). Many developers start the upgrade process as soon as the new version is available, while others wait until the version they are using is no longer supported. The upgrade process has multiple aspects to consider.

Common reasons to upgrade to a new .NET version:

- The currently used .NET version is no longer supported
- The new version supports a new operating system
- The new version has an important API, performance, or security feature

## Controlled upgrades and version pinning

When upgrading development tools like the .NET SDK, Visual Studio, or other components, you might encounter new behaviors, analyzer warnings, or breaking changes that affect your build process. Version pinning allows you to upgrade your development environment while maintaining control over when specific components are updated in your projects.

### Why pinning matters

Pinning versions provides several benefits:

- **Predictable builds**: Ensures consistent build results across different machines and CI/CD environments.
- **Gradual adoption**: Allows you to adopt new features incrementally rather than all at once.
- **Avoid unexpected changes**: Prevents new analyzer rules, SDK behaviors, or package versions from causing build failures.
- **Team coordination**: Enables teams to upgrade together at a planned time rather than individually when tools update.
- **Debugging and troubleshooting**: Makes it easier to isolate issues when you control which versions changed.

The following sections describe various mechanisms for controlling versions of different components in your .NET projects.

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

## Control SDK version with global.json

You can pin the .NET SDK version for a project or solution by using a *global.json* file. This file specifies which SDK version to use when running .NET CLI commands and is independent of the runtime version your project targets.

Create a *global.json* file in your solution root directory:

```dotnetcli
dotnet new globaljson --sdk-version 9.0.100 --roll-forward latestFeature
```

This example pins the SDK to version 9.0.100 or any later patch or feature band within the 9.0 major version. The `rollForward` policy controls how the SDK version is selected when the exact version isn't available.

Common roll-forward strategies:

- **`disable`**: Requires the exact SDK version specified.
- **`patch`**: Allows the latest patch version of the specified SDK.
- **`feature`**: Allows the latest feature band within the same major and minor version.
- **`latestFeature`**: Uses the highest feature band and patch within the same major and minor version (recommended for most scenarios).
- **`latestMinor`**: Allows any minor version within the same major version.

Example *global.json* file:

```json
{
  "sdk": {
    "version": "9.0.100",
    "rollForward": "latestFeature"
  }
}
```

This configuration ensures that when you upgrade Visual Studio or install a new SDK, your project continues to use SDK 9.0.x until you explicitly update the *global.json* file.

For more information, see [global.json overview](../tools/global-json.md).

## Control analyzer behavior

Code analyzers can introduce new warnings or change behavior between versions. You can control analyzer versions and which rules are enabled to maintain consistent builds.

### AnalysisLevel

The `AnalysisLevel` property controls which code quality rules are enabled. This property allows you to lock to a specific version of analyzer rules, preventing new rules from being introduced when you upgrade the SDK.

```xml
<PropertyGroup>
  <AnalysisLevel>8.0</AnalysisLevel>
</PropertyGroup>
```

When set to `8.0`, only the analyzer rules that shipped with .NET 8 are enabled, even if you're using the .NET 9 SDK. This prevents new .NET 9 analyzer rules from affecting your build until you're ready to address them.

Available values:

- **`latest`**: Uses all analyzer rules from the SDK you're building with (default).
- **`latest-all`**: Uses all analyzer rules, including those in preview.
- **`latest-recommended`**: Uses only recommended analyzer rules.
- **Specific version** (for example, `8.0`, `9.0`): Uses rules from that .NET version.

### AnalysisMode

The `AnalysisMode` property determines how aggressive the analyzer rules should be:

```xml
<PropertyGroup>
  <AnalysisMode>Default</AnalysisMode>
</PropertyGroup>
```

Available values:

- **`Default`**: Default set of rules.
- **`None`**: Disables most analyzer rules.
- **`Minimum`**: Enables only the most critical rules.
- **`Recommended`**: Enables recommended rules (default in .NET 8 and later).
- **`All`**: Enables all available analyzer rules.

You can also control analysis mode by category:

```xml
<PropertyGroup>
  <AnalysisModeSecurity>All</AnalysisModeSecurity>
  <AnalysisModePerformance>Recommended</AnalysisModePerformance>
</PropertyGroup>
```

For more information, see [Code analysis configuration options](../../fundamentals/code-analysis/configuration-options.md).

## Control NuGet package versions

Managing package versions consistently across projects and preventing unexpected updates is critical for reliable builds.

### Package lock files

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

### Central Package Management

Central Package Management (CPM) allows you to manage package versions in a single location for all projects in a solution. This approach simplifies version management and ensures consistency across projects.

Create a *Directory.Packages.props* file in your solution root:

```xml
<Project>
  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>

  <ItemGroup>
    <PackageVersion Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageVersion Include="Serilog" Version="3.1.1" />
  </ItemGroup>
</Project>
```

In your project files, reference packages without specifying versions:

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" />
  <PackageReference Include="Serilog" />
</ItemGroup>
```

The versions are managed centrally in *Directory.Packages.props*, making it easier to update all projects at once.

### Package Source Mapping

Package Source Mapping allows you to control which NuGet feeds are used for specific packages, improving security and reliability.

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

## Manage Visual Studio and MSBuild versions

### Visual Studio side-by-side installation

Visual Studio supports side-by-side installation of multiple versions. You can install Visual Studio 2022 and Visual Studio 2019 on the same machine, or multiple releases of Visual Studio 2022 (for example, 17.8 and 17.12).

Each Visual Studio version includes a corresponding .NET SDK. When you update Visual Studio, the included SDK version is updated as well. However, you can continue using older SDK versions by installing them separately from the [.NET download page](https://dotnet.microsoft.com/download).

Key points:

- Visual Studio updates don't affect separately installed .NET SDKs.
- Use *global.json* to control which SDK version is used, regardless of the Visual Studio version.
- Each Visual Studio instance can have different settings and extensions.

### MSBuild versioning

MSBuild versions correspond to Visual Studio versions:

- Visual Studio 2022 version 17.8 includes MSBuild 17.8
- Visual Studio 2022 version 17.12 includes MSBuild 17.12

The .NET SDK also includes MSBuild. When you use `dotnet build`, you're using the MSBuild version included with the SDK specified by *global.json* or the latest installed SDK.

To specify a specific MSBuild version:

- Use `dotnet build` with a pinned SDK version in *global.json*.
- Launch the appropriate Visual Studio Developer Command Prompt, which sets up the environment for that Visual Studio version's MSBuild.
- Directly invoke MSBuild from a specific Visual Studio installation (for example, `"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"`).

For more information, see [.NET SDK, MSBuild, and Visual Studio versioning](../porting/versioning-sdk-msbuild-vs.md).

## Upgrade readiness checklist

Before upgrading to a new .NET version or development environment, use this checklist to ensure a smooth transition:

### Pre-upgrade assessment

- [ ] Review the [breaking changes](../compatibility/9.0.md) for the new .NET version.
- [ ] Check if your NuGet packages support the new .NET version.
- [ ] Verify that any third-party tools and libraries are compatible.
- [ ] Review the [.NET support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) for the versions you're using and upgrading to.

### Version pinning setup

- [ ] Create or update *global.json* to pin the SDK version.
- [ ] Set `AnalysisLevel` to lock analyzer rules to the current version.
- [ ] Enable package lock files (`RestorePackagesWithLockFile`) for consistent package versions.
- [ ] Consider setting up Central Package Management if managing multiple projects.
- [ ] Configure package source mapping if using multiple NuGet feeds.

### Development environment

- [ ] Install the new .NET SDK version.
- [ ] Update Visual Studio (if applicable) or install it side-by-side with existing versions.
- [ ] Update IDE extensions and tools.
- [ ] Verify that your CI/CD pipeline can use the new SDK version.

### Code changes

- [ ] Update `TargetFramework` (or `TargetFrameworks`) in project files.
- [ ] Run `dotnet restore` to restore packages with the new framework.
- [ ] Build the project and address any errors or warnings.
- [ ] Run tests to ensure functionality is preserved.
- [ ] Update code to address any breaking changes.

### Gradual rollout

- [ ] Update non-critical projects first to identify issues.
- [ ] Test in a non-production environment before deploying.
- [ ] Update *global.json* and `AnalysisLevel` to allow newer SDK and analyzer versions gradually.
- [ ] Review and address new analyzer warnings over time.
- [ ] Update package versions incrementally to manage risk.

### CI/CD and deployment

- [ ] Update CI/CD pipelines with the new SDK version.
- [ ] Update Docker base images if using containers.
- [ ] Verify that the hosting environment supports the new runtime version.
- [ ] Test the deployment process in a staging environment.

## Workload-specific migration guides

Different .NET workloads might have specific upgrade considerations:

- **ASP.NET Core**: [Migrate from ASP.NET Core (version) to (version)](/aspnet/core/migration/)
- **Entity Framework Core**: [Upgrading from previous versions to EF Core (version)](/ef/core/what-is-new/ef-core-9.0/breaking-changes)
- **.NET MAUI**: [Upgrading .NET MAUI applications](https://github.com/dotnet/maui/wiki/Upgrading-.NET-MAUI-from-.NET-7-to-.NET-8)
- **Blazor**: Included in ASP.NET Core migration guides
- **Windows Forms and WPF**: [Upgrade a Windows desktop app to .NET](/dotnet/desktop/migration/)
- **.NET Upgrade Assistant**: [Overview of the .NET Upgrade Assistant](../porting/upgrade-assistant-overview.md)

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
