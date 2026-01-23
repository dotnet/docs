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
  </PropertyGroup>
</Project>
```

Use a semicolon-delimited list of RID values. For a list of Runtime Identifiers, see the [RID catalog](../rid-catalog.md).

### When to use `RuntimeIdentifiers` vs `ToolPackageRuntimeIdentifiers`

Both `RuntimeIdentifiers` and `ToolPackageRuntimeIdentifiers` opt your tool into RID-specific packaging, but they serve slightly different purposes:

- Use **`RuntimeIdentifiers`** when:
  - You want the project to **build and publish RID-specific apps in general** (not just as a tool).
  - You are primarily targeting **CoreCLR** (non-AOT) or you want the standard SDK behavior where a single `dotnet pack` can produce RID-specific packages.
  - You may conditionalize `PublishAot` for a subset of RIDs, but you still want a CoreCLR-based package for every RID in `RuntimeIdentifiers`.

- Use **`ToolPackageRuntimeIdentifiers`** when:
  - You want to define **RID-specific behavior only for the tool packaging**, without changing how the project builds for other deployment scenarios.
  - You're using **Native AOT** and plan to **manually build** AOT binaries per RID with `dotnet pack -r <RID>`.
  - You want a **hybrid model** where some RIDs get Native AOT and others fall back to a portable CoreCLR implementation.

In all cases where `PublishAot` is **not** set, the set of RIDs in `ToolPackageRuntimeIdentifiers` should be equal to or a subset of the RIDs in `RuntimeIdentifiers`. When `PublishAot` is enabled, RID-specific packages are generated only when you build for a specific RID (for example, `dotnet pack -r linux-x64`).

The top-level pointer package is informed by `ToolPackageRuntimeIdentifiers` or `RuntimeIdentifiers`, in that precedence order: if `ToolPackageRuntimeIdentifiers` is specified, it determines the tool RIDs; otherwise, `RuntimeIdentifiers` is used.

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

For tools with AOT compilation (`<PublishAot>true</PublishAot>`), you must pack separately for each platform:

- Pack the top-level package once (on any platform):

   ```dotnetcli
   dotnet pack
   ```

- Pack for each specific RID on the corresponding platform:

   ```dotnetcli
   dotnet pack -r win-x64
   dotnet pack -r linux-x64
   dotnet pack -r osx-arm64
   ```

   You must run each RID-specific pack command on the matching platform because AOT compilation produces native binaries. For more information about the prerequisites for Native AOT compilation, see [Native AOT deployment](../deploying/native-aot/index.md).

When you set `<PublishAot>true</PublishAot>`, the packing behavior changes:

- A regular `dotnet pack` with `PublishAot=true`:
  - Produces the **top-level pointer package** (package type `DotnetTool`).
  - Does **not** automatically produce RID-specific packages, because Native AOT requires building on (or for) a specific platform.

- RID-specific AOT packages are produced only when you explicitly pass `-r <RID>`:
  - `dotnet pack -r linux-x64`
  - `dotnet pack -r osx-arm64`
  - and so on.

With `PublishAot=true`:

- `RuntimeIdentifiers` or `ToolPackageRuntimeIdentifiers` describe the set of RIDs your tool intends to support.
- You are responsible for invoking `dotnet pack -r <RID>` for each of those RIDs on the appropriate build environment (for example, on Windows for `win-x64`).

### Hybrid AOT + CoreCLR packaging pattern (example)

Some tools want the best of both worlds:

- **Native AOT** for a subset of high-priority platforms (for example, Linux and macOS).
- A **portable CoreCLR fallback** that works on any platform, including those without an AOT build (for example, Windows when no AOT build is produced).

You can achieve this "hybrid" model with the following pattern:

1. **Configure the tool for Native AOT and tool-specific RIDs**

   In your project file, use `ToolPackageRuntimeIdentifiers` and enable `PublishAot`:

   ```xml
   <ToolPackageRuntimeIdentifiers>osx-arm64;linux-arm64;linux-x64;any</ToolPackageRuntimeIdentifiers>
   <PublishAot>true</PublishAot>
   ```

2. **Create the pointer package**

   Run `dotnet pack` once (on any platform) to build the top-level package that points to the RID-specific packages:

   ```dotnetcli
   dotnet pack
   ```

3. **Build Native AOT packages for selected RIDs**

   For each AOT-enabled RID, run `dotnet pack -r <RID>` on a suitable build environment. For example:

   ```dotnetcli
   dotnet pack -r osx-arm64      # on macOS
   dotnet pack -r linux-arm64    # on Linux ARM64
   dotnet pack -r linux-x64      # on Linux x64
   ```

4. **Build a CoreCLR fallback package**

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

The <a href="https://github.com/richlander/dotnet10-hybrid-tool">`dotnet10-hybrid-tool` repository</a> demonstrates this hybrid packaging pattern:

- Native AOT packages for:
  - `osx-arm64`
  - `linux-arm64`
  - `linux-x64`
- A CoreCLR fallback package for the `any` RID (used, for example, on Windows when no AOT build is available).

You can install and try the tool yourself:

```dotnetcli
dotnet tool install -g dotnet10-hybrid-tool
dotnet10-hybrid-tool
```

The tool reports:

- Runtime framework description
- Runtime identifier (RID)
- Compilation mode (Native AOT or CoreCLR)

This makes it a useful way to experiment with RID-specific, AOT-compiled tools and the CoreCLR fallback behavior.

## Package structure

### Package types

RID-specific tool packages use two package types:

- **DotnetTool**: The top-level package that contains metadata.
- **DotnetToolRidPackage**: The RID-specific packages that contain the actual tool binaries.

### Package metadata

The top-level package includes metadata that signals it's a RID-specific tool and lists the RID-specific packages. When you run `dotnet tool install`, the CLI reads this metadata to determine which RID-specific package to install for the current platform.

## Publish your tool

Publish all packages to NuGet.org or your package feed by using [dotnet nuget push](dotnet-nuget-push.md):

```dotnetcli
dotnet nuget push path/to/package/root/*.nupkg
```

## Run a RID-specific tool

Users can run RID-specific tools in multiple ways.

If the tool is installed globally and on the `PATH`, you can invoke it directly:

```dotnetcli
mytool
```

You can also use the `dnx` helper, which behaves similarly to `npx` in the Node.js ecosystem: it downloads and launches the tool in a single gesture if it isn't already present:

```dotnetcli
dnx mytool
```

In both cases, the .NET CLI automatically:

1. Downloads the top-level package.
1. Reads the RID-specific metadata.
1. Identifies the most appropriate package for the current platform.
1. Downloads and runs the RID-specific package.

## Example: Create an AOT tool

Here's a complete example of creating an AOT-compiled RID-specific tool:

1. Create a new console application:

   ```dotnetcli
   dotnet new console -n MyFastTool
   cd MyFastTool
   ```

1. Update the project file to enable AOT and RID-specific packaging:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">
     <PropertyGroup>
       <OutputType>Exe</OutputType>
       <TargetFramework>net10.0</TargetFramework>
       <PackAsTool>true</PackAsTool>
       <ToolCommandName>myfasttool</ToolCommandName>
       <RuntimeIdentifiers>win-x64;linux-x64;osx-arm64</RuntimeIdentifiers>
       <PublishAot>true</PublishAot>
       <PackageId>MyFastTool</PackageId>
       <Version>1.0.0</Version>
       <Authors>Your Name</Authors>
       <Description>A fast AOT-compiled tool</Description>
     </PropertyGroup>
   </Project>
   ```

1. Add your application code in `Program.cs`:

   ```csharp
   Console.WriteLine("Hello from MyFastTool!");
   Console.WriteLine($"Running on {Environment.OSVersion}");
   ```

1. Pack the top-level package:

   ```dotnetcli
   dotnet pack
   ```

1. Pack for each specific RID (on the corresponding platform):

   On Windows:

   ```dotnetcli
   dotnet pack -r win-x64
   ```

   On Linux:

   ```dotnetcli
   dotnet pack -r linux-x64
   ```

   On macOS:

   ```dotnetcli
   dotnet pack -r osx-arm64
   ```

1. Publish all packages to NuGet.org by using the [dotnet nuget push](dotnet-nuget-push.md) command.

## See also

- [Tutorial: Create a .NET tool](global-tools-how-to-create.md)
- [.NET tools overview](global-tools.md)
- [dotnet pack command](dotnet-pack.md)
- [RID catalog](../rid-catalog.md)
- [Native AOT deployment](../deploying/native-aot/index.md)
