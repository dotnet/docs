---
title: Create RID-specific, self-contained, and AOT .NET tools
description: Learn how to create and package RID-specific, self-contained, and AOT .NET tools for platform-specific distribution.
ms.topic: how-to
ms.date: 11/12/2025
ai-usage: ai-assisted
---

# Create RID-specific, self-contained, and AOT .NET tools

**This article applies to:** ✔️ .NET SDK 10 and later versions

Package .NET tools for specific platforms and architectures so you can distribute native, fast, and trimmed applications. This capability makes it easier to distribute native, fast, trimmed .NET applications for command-line tools like MCP servers or other platform-specific utilities.

## Overview

Starting with .NET SDK 10, you can create .NET tools that target specific Runtime Identifiers (RIDs). These tools can be:

- **RID-specific**: Compiled for particular operating systems and architectures.
- **Self-contained**: Include the .NET runtime and don't require a separate .NET installation.
- **Native AOT**: Use Ahead-of-Time compilation for faster startup and smaller memory footprint.

When users install a RID-specific tool, the .NET CLI automatically selects and installs the appropriate package for their platform.

## Opt in to RID-specific packaging

To create a RID-specific tool, configure your project with one of the following MSBuild properties:

### RuntimeIdentifiers property

Use `RuntimeIdentifiers` to specify the platforms your tool supports:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <PackAsTool>true</PackAsTool>
    <ToolCommandName>mytool</ToolCommandName>
    <RuntimeIdentifiers>win-x64;linux-x64;osx-arm64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

### ToolPackageRuntimeIdentifiers property

Alternatively, use `ToolPackageRuntimeIdentifiers` for tool-specific RID configuration:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <PackAsTool>true</PackAsTool>
    <ToolCommandName>mytool</ToolCommandName>
    <ToolPackageRuntimeIdentifiers>win-x64;linux-x64;osx-arm64</ToolPackageRuntimeIdentifiers>
    <PublishAot>true</PublishAot>
  </PropertyGroup>
</Project>
```

Use a semicolon-delimited list of RID values. For a list of Runtime Identifiers, see the [RID catalog](../rid-catalog.md).

### When to use `RuntimeIdentifiers` vs `ToolPackageRuntimeIdentifiers`

Both `RuntimeIdentifiers` and `ToolPackageRuntimeIdentifiers` opt your tool into RID-specific packaging, but they serve slightly different purposes:

Use **`RuntimeIdentifiers`** when:

- You want the project to **build and publish RID-specific apps in general** (not just as a tool).
- You're primarily targeting **CoreCLR** (non-AOT) or you want the standard SDK behavior where a single `dotnet pack` can produce RID-specific packages.
- You may conditionalize `PublishAot` for a subset of RIDs, but you still want a CoreCLR-based package for every RID in `RuntimeIdentifiers`.

Use **`ToolPackageRuntimeIdentifiers`** when:

- You want to define **RID-specific behavior only for the tool packaging**, without changing how the project builds for other deployment scenarios.
- You're using **Native AOT** and plan to **manually build** AOT binaries per RID with `dotnet pack -r <RID>`.
- You want a **hybrid model** where some RIDs get Native AOT and others fall back to a portable CoreCLR implementation.

When you don't enable `PublishAot`, the set of RIDs in `ToolPackageRuntimeIdentifiers` should be equal to or a subset of the RIDs in `RuntimeIdentifiers`. When you enable `PublishAot`, RID-specific packages are generated only when you build for a specific RID (for example, `dotnet pack -r linux-x64`).

The top-level pointer package is informed by `ToolPackageRuntimeIdentifiers` or `RuntimeIdentifiers`, in that precedence order: if you specify `ToolPackageRuntimeIdentifiers`, it determines the tool RIDs; otherwise, `RuntimeIdentifiers` is used.

## Package your tool

The packaging process differs depending on whether you're using AOT compilation. To build a NuGet package, or *.nupkg* file from the project, run the [dotnet pack](dotnet-pack.md) command.

### RID-specific and self-contained tools

For tools without AOT compilation, run `dotnet pack` once:

```dotnetcli
dotnet pack
```

This command creates multiple NuGet packages:

- One package for each RID: `<packageName>.<RID>.<packageVersion>.nupkg`
  - Example: `mytool.win-x64.1.0.0.nupkg`
  - Example: `mytool.linux-x64.1.0.0.nupkg`
  - Example: `mytool.osx-arm64.1.0.0.nupkg`
- One RID-agnostic pointer package: `<packageName>.<packageVersion>.nupkg`
  - Example: `mytool.1.0.0.nupkg`

### AOT tools

For tools with AOT compilation (`<PublishAot>true</PublishAot>`), you must pack separately for each platform.

#### Platform requirements for Native AOT

Native AOT compilation requires the operating system (OS) part of the SDK RID to match the target RID's OS. The SDK can cross-compile for different architectures (for example, x64 to ARM64) but not across operating systems (for example, Windows to Linux).

This means you have several options for building Native AOT packages:

- **Build only for your development machine**: Support Native AOT only for the OS you're developing on.
- **Use containers for Linux builds**: If you're on macOS or Windows, use containers to cross-compile for Linux. For example, use `mcr.microsoft.com/dotnet/sdk:10.0-noble-aot` container images.
- **Federate your build across machines**: Use CI/CD systems like GitHub Actions or Azure DevOps Pipelines to build on different operating systems.

You don't need to build all RID-specific packages on the same machine or at the same time. You just need to build and publish them before you publish the top-level package.

#### Packing Native AOT tools

Pack the top-level package once (on any platform):

```dotnetcli
dotnet pack
```

Pack for each specific RID on the corresponding platform, for example:

```dotnetcli
dotnet pack -r linux-x64
```

You must run each RID-specific pack command on a platform where the OS matches the target RID's OS. For more information about the prerequisites for Native AOT compilation, see [Native AOT deployment](../deploying/native-aot/index.md).

When you set `PublishAot` to `true`, the packing behavior changes:

- A regular `dotnet pack` with `PublishAot=true`:
  - Produces the **top-level pointer package** (package type `DotnetTool`).
  - Does **not** automatically produce RID-specific packages, because Native AOT requires building on (or for) a specific platform.

- RID-specific AOT packages are produced only when you explicitly pass `-r <RID>`, for example, `dotnet pack -r linux-x64` or `dotnet pack -r osx-arm64`.

With `PublishAot=true`:

- `RuntimeIdentifiers` or `ToolPackageRuntimeIdentifiers` describe the set of RIDs your tool intends to support.
- You're responsible for invoking `dotnet pack -r <RID>` for each of those RIDs on the appropriate build environment (for example, on Windows for `win-x64`).

### Hybrid AOT + CoreCLR packaging pattern (example)

Some tools want the best of both worlds:

- **Native AOT** for a subset of high-priority platforms (for example, Linux and macOS).
- A **portable CoreCLR fallback** that works on platforms not targeted by the Native AOT builds.

You can achieve this "hybrid" model with the following pattern:

1. **Configure the tool for Native AOT and tool-specific RIDs.**

   In your project file, use `ToolPackageRuntimeIdentifiers` and enable `PublishAot`:

   ```xml
   <ToolPackageRuntimeIdentifiers>osx-arm64;linux-arm64;linux-x64;any</ToolPackageRuntimeIdentifiers>
   <PublishAot>true</PublishAot>
   ```

1. **Create the pointer package.**

   Run `dotnet pack` once (on any platform) to build the top-level package that points to the RID-specific packages:

   ```dotnetcli
   dotnet pack
   ```

1. **Build Native AOT packages for selected RIDs.**

   Native AOT compilation requires building on the target platform. Build each AOT-enabled RID package on the matching platform using `dotnet pack -r <RID>`:

   - On Windows x64: `dotnet pack -r win-x64`
   - On Linux ARM64: `dotnet pack -r linux-arm64`
   - On macOS ARM64: `dotnet pack -r osx-arm64`

1. **Build a CoreCLR fallback package.**

   To provide a universal fallback, pack the `any` RID without AOT:

   ```dotnetcli
   dotnet pack -r any -p:PublishAot=false
   ```

   This produces a portable CoreCLR package (for example, `yourtool.any.<version>.nupkg`) that can run on platforms that don't have a dedicated AOT build.

> [!NOTE]
> You can also use the `.NET SDK 10.0-noble-aot` container images to build and package Linux Native AOT tools from any host that supports Linux containers. For example:
>
> - `mcr.microsoft.com/dotnet/sdk:10.0-noble-aot`
>
> This is useful when your development machine isn't running Linux natively.

In this hybrid setup:

- The pointer package (`yourtool.<version>.nupkg`) references both:
  - RID-specific Native AOT packages (for example, `yourtool.osx-arm64`, `yourtool.linux-x64`).
  - The `any` CoreCLR package as a fallback.
- The .NET CLI automatically picks the most appropriate package for the user's platform when they run `dotnet tool install`.

#### Example: `dotnet10-hybrid-tool`

The [`dotnet10-hybrid-tool` repository](https://github.com/richlander/dotnet10-hybrid-tool) demonstrates this hybrid packaging pattern with Native AOT packages for `osx-arm64`, `linux-arm64`, and `linux-x64`, plus a CoreCLR fallback package for the `any` RID (used, for example, on Windows when no AOT build is available).

You can install and try the tool yourself:

```dotnetcli
dotnet tool install -g dotnet10-hybrid-tool
dotnet10-hybrid-tool
```

The tool reports its runtime framework description, runtime identifier (RID), and compilation mode (Native AOT or CoreCLR).

Example output on a platform with Native AOT:

```output
Hi, I'm a 'DotNetCliTool v2' tool!
Yes, I'm quite fancy.

Version: .NET 10.0.2
RID: osx-arm64
Mode: Native AOT
```

Example output on a platform using the CoreCLR fallback:

```output
Hi, I'm a 'DotNetCliTool v2' tool!
Yes, I'm quite fancy.

Version: .NET 10.0.2
RID: win-x64
Mode: CoreCLR
```

This makes it a useful way to experiment with RID-specific, AOT-compiled tools and the CoreCLR fallback behavior.

## Package structure

When you create a RID-specific tool, the packaging process generates multiple NuGet packages:

- **Top-level package** (`yourtool.1.0.0.nupkg`): Contains metadata that identifies the tool as RID-specific and lists which RID-specific packages are available. This package has the type `DotnetTool`.
- **RID-specific packages** (for example, `yourtool.linux-x64.1.0.0.nupkg`, `yourtool.osx-arm64.1.0.0.nupkg`): Contain the actual tool binaries for each platform. These packages have the type `DotnetToolRidPackage`.

When you run `dotnet tool install`, the CLI:

1. Downloads the top-level package.
1. Reads the metadata to see which RID-specific packages are available.
1. Determines which RID-specific package matches the current platform.
1. Downloads and installs the appropriate RID-specific package.

## Publish your tool

When publishing RID-specific tool packages, the .NET CLI uses the version number of the top-level package to select the matching RID-specific packages. This means:

- All RID-specific packages must have the exact same version as the top-level package.
- All packages must be published to your feed before the top-level package becomes available.

To ensure a smooth publishing process:

1. Publish all RID-specific packages first:

   ```dotnetcli
   dotnet nuget push yourtool.win-x64.1.0.0.nupkg
   dotnet nuget push yourtool.linux-x64.1.0.0.nupkg
   dotnet nuget push yourtool.osx-arm64.1.0.0.nupkg
   dotnet nuget push yourtool.any.1.0.0.nupkg
   ```

1. Publish the top-level package last:

   ```dotnetcli
   dotnet nuget push yourtool.1.0.0.nupkg
   ```

Publishing the top-level package last ensures that all referenced RID-specific packages are available when users install your tool. If a user installs your tool before all RID packages are published, the installation will fail.

## Install and run tools

Whether a tool uses RID-specific packaging is an implementation detail that's transparent to users. You install and run tools the same way, regardless of whether the tool developer opted into RID-specific packaging.

To install a tool globally:

```dotnetcli
dotnet tool install -g mytool
```

Once installed, you can invoke it directly:

```dotnetcli
mytool
```

You can also use the `dnx` helper, which behaves similarly to `npx` in the Node.js ecosystem: it downloads and launches a tool in a single gesture if it isn't already present:

```dotnetcli
dnx mytool
```

When a tool uses RID-specific packaging, the .NET CLI automatically selects the correct package for your platform. You don't need to specify a RID—the CLI infers it from your system and downloads the appropriate RID-specific package.

## See also

- [Tutorial: Create a .NET tool](global-tools-how-to-create.md)
- [.NET tools overview](global-tools.md)
- [dotnet pack command](dotnet-pack.md)
- [RID catalog](../rid-catalog.md)
- [Native AOT deployment](../deploying/native-aot/index.md)
