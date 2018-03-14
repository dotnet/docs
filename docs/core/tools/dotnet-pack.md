---
title: dotnet pack command - .NET Core CLI
description: The dotnet pack command creates NuGet packages for your .NET Core project.
author: mairaw
ms.author: mairaw
ms.date: 03/10/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet pack

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet pack` - Packs the code into a NuGet package.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)

```
dotnet pack [<PROJECT>] [-c|--configuration] [--force] [--include-source] [--include-symbols] [--no-build] [--no-dependencies]
    [--no-restore] [-o|--output] [--runtime] [-s|--serviceable] [-v|--verbosity] [--version-suffix]
dotnet pack [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)
```
dotnet pack [<PROJECT>] [-c|--configuration] [--include-source] [--include-symbols] [--no-build] [-o|--output] [-s|--serviceable] [-v|--verbosity] [--version-suffix]
dotnet pack [-h|--help]
```
---

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the `--include-symbols` option is present, another package containing the debug symbols is created.

NuGet dependencies of the packed project are added to the *.nuspec* file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.

By default, `dotnet pack` builds the project first. If you wish to avoid this behavior, pass the `--no-build` option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.

You can provide MSBuild properties to the `dotnet pack` command for the packing process. For more information, see [NuGet metadata properties](csproj.md#nuget-metadata-properties) and the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). The [Examples](#examples) section shows how to use the MSBuild /p switch for a couple of different scenarios.

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

## Arguments

`PROJECT`

The project to pack. It's either a path to a [csproj file](csproj.md) or to a directory. If omitted, it defaults to the current directory.

## Options

# [.NET Core 2.x](#tab/netcore2x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`--force`
Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the *project.assets.json* file.

`-h|--help`

Prints out a short help for the command.

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the `src` folder within the `nupkg`.

`--include-symbols`

Generates the symbols `nupkg`.

`--no-build`

Doesn't build the project before packing.

`--no-dependencies`

Ignores project-to-project references and only restores the root project.

`--no-restore`

Doesn't perform an implicit restore when running the command.

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

`-s|--serviceable`

Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

`--version-suffix <VERSION_SUFFIX>`

Defines the value for the `$(VersionSuffix)` MSBuild property in the project.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

# [.NET Core 1.x](#tab/netcore1x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-h|--help`

Prints out a short help for the command.

`--include-source`

Includes the source files in the NuGet package. The sources files are included in the `src` folder within the `nupkg`.

`--include-symbols`

Generates the symbols `nupkg`.

`--no-build`

Doesn't build the project before packing.

`-o|--output <OUTPUT_DIRECTORY>`

Places the built packages in the directory specified.

`-s|--serviceable`

Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

`--version-suffix <VERSION_SUFFIX>`

Defines the value for the `$(VersionSuffix)` MSBuild property in the project.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

---

## Examples

Pack the project in the current directory:

`dotnet pack`

Pack the `app1` project:

`dotnet pack ~/projects/app1/project.csproj`

Pack the project in the current directory and place the resulting packages into the `nupkgs` folder:

`dotnet pack --output nupkgs`

Pack the project in the current directory into the `nupkgs` folder and skip the build step:

`dotnet pack --no-build --output nupkgs`

With the project's version suffix configured as `<VersionSuffix>$(VersionSuffix)</VersionSuffix>` in the *.csproj* file, pack the current project and update the resulting package version with the given suffix:

`dotnet pack --version-suffix "ci-1234"`

Set the package version to `2.1.0` with the `PackageVersion` MSBuild property:

`dotnet pack /p:PackageVersion=2.1.0`

Pack the project for a specific [target framework](../../standard/frameworks.md):

`dotnet pack /p:TargetFrameworks=net45`

Pack the project and use a specific runtime (Windows 10) for the restore operation (.NET Core SDK 2.0 and later versions):

`dotnet pack --runtime win10-x64`