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

## Package your tool

The packaging process differs depending on whether you're using AOT compilation. To build a NuGet package, or *.nupkg* file from the project, run the [dotnet pack](dotnet/core/tools/dotnet-pack) command.

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

   You must run each RID-specific pack command on the matching platform because AOT compilation produces native binaries.

## Package structure

### Package types

RID-specific tool packages use two package types:

- **DotnetTool**: The top-level package that contains metadata.
- **DotnetToolRidPackage**: The RID-specific packages that contain the actual tool binaries.

### Package metadata

The top-level package includes metadata that signals it's a RID-specific tool and lists the RID-specific packages. When you run `dotnet tool install`, the CLI reads this metadata to determine which RID-specific package to install for the current platform.

## Publish your tool

Publish all packages to NuGet.org or your package feed by using [dotnet nuget push](/dotnet/core/tools/dotnet-nuget-push):

```dotnetcli
dotnet nuget push mytool.1.0.0.nupkg
dotnet nuget push mytool.win-x64.1.0.0.nupkg
dotnet nuget push mytool.linux-x64.1.0.0.nupkg
dotnet nuget push mytool.osx-arm64.1.0.0.nupkg
```

## Install a RID-specific tool

Users install RID-specific tools the same way as regular tools:

```dotnetcli
dotnet tool install -g mytool
```

The CLI automatically:

1. Downloads the top-level package.
1. Reads the RID-specific metadata.
1. Identifies the most appropriate package for the current platform.
1. Downloads and installs the RID-specific package.

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

1. Publish all packages to NuGet.org by using the [dotnet nuget push](/dotnet/core/tools/dotnet-nuget-push) command.

## See also

- [Tutorial: Create a .NET tool](global-tools-how-to-create.md)
- [.NET tools overview](global-tools.md)
- [dotnet pack command](dotnet-pack.md)
- [RID catalog](../rid-catalog.md)
- [Native AOT deployment](../deploying/native-aot/index.md)
