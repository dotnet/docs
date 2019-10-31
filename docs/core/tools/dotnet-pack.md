---
title: dotnet pack command
description: The dotnet pack command creates NuGet packages for your .NET Core project.
ms.date: 08/08/2019
---
# dotnet pack

**This topic applies to: ✓** .NET Core 1.x SDK and later versions

<!-- todo: uncomment when all CLI commands are reviewed
[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]
-->

## Name

`dotnet pack` - Packs the code into a NuGet package.

## Synopsis

```dotnetcli
dotnet pack [<PROJECT>|<SOLUTION>] [-c|--configuration] [--force] [--include-source] [--include-symbols] [--interactive] 
    [--no-build] [--no-dependencies] [--no-restore] [--nologo] [-o|--output] [--runtime] [-s|--serviceable] 
    [-v|--verbosity] [--version-suffix]
dotnet pack [-h|--help]
```

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package (that is, a *.nupkg* file). 

If you want to generate a package that contains the debug symbols, you have two options available:

- `--include-symbols` - it creates the symbols package.
- `--include-source` - it creates the symbols package with a `src` folder inside containing the source files.

NuGet dependencies of the packed project are added to the *.nuspec* file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.

By default, `dotnet pack` builds the project first. If you wish to avoid this behavior, pass the `--no-build` option. This option is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.

You can provide MSBuild properties to the `dotnet pack` command for the packing process. For more information, see [NuGet metadata properties](csproj.md#nuget-metadata-properties) and the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). The [Examples](#examples) section shows how to use the MSBuild -p switch for a couple of different scenarios.

Web projects aren't packable by default. To override the default behavior, add the following property to your *.csproj* file:

```xml
<PropertyGroup>
   <IsPackable>true</IsPackable>
</PropertyGroup>
```

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

## Arguments

`PROJECT | SOLUTION`

  The project or solution to pack. It's either a path to a [csproj file](csproj.md), a solution file, or to a directory. If not specified, the command searches the current directory for a project or solution file.

## Options

- **`-c|--configuration {Debug|Release}`**

  Defines the build configuration. The default value is `Debug`.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file. Option available since .NET Core 2.0 SDK.

- **`-h|--help`**

  Prints out a short help for the command.

- **`--include-source`**

  Includes the debug symbols NuGet packages in addition to the regular NuGet packages in the output directory. The sources files are included in the `src` folder within the symbols package.

- **`--include-symbols`**

  Includes the debug symbols NuGet packages in addition to the regular NuGet packages in the output directory.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example, to complete authentication). Available since .NET Core 3.0 SDK.

- **`--no-build`**

  Doesn't build the project before packing. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Ignores project-to-project references and only restores the root project. Option available since .NET Core 2.0 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command. Option available since .NET Core 2.0 SDK.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Places the built packages in the directory specified.

- **`--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). Option available since .NET Core 2.0 SDK.

- **`-s|--serviceable`**

  Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

- **`--version-suffix <VERSION_SUFFIX>`**

  Defines the value for the `$(VersionSuffix)` MSBuild property in the project.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

- Pack the project in the current directory:

  ```dotnetcli
  dotnet pack
  ```

- Pack the `app1` project:

  ```dotnetcli
  dotnet pack ~/projects/app1/project.csproj
  ```

- Pack the project in the current directory and place the resulting packages into the `nupkgs` folder:

  ```dotnetcli
  dotnet pack --output nupkgs
  ```

- Pack the project in the current directory into the `nupkgs` folder and skip the build step:

  ```dotnetcli
  dotnet pack --no-build --output nupkgs
  ```

- With the project's version suffix configured as `<VersionSuffix>$(VersionSuffix)</VersionSuffix>` in the *.csproj* file, pack the current project and update the resulting package version with the given suffix:

  ```dotnetcli
  dotnet pack --version-suffix "ci-1234"
  ```

- Set the package version to `2.1.0` with the `PackageVersion` MSBuild property:

  ```dotnetcli
  dotnet pack -p:PackageVersion=2.1.0
  ```

- Pack the project for a specific [target framework](../../standard/frameworks.md):

  ```dotnetcli
  dotnet pack -p:TargetFrameworks=net45
  ```

- Pack the project and use a specific runtime (Windows 10) for the restore operation (.NET Core SDK 2.0 and later versions):

  ```dotnetcli
  dotnet pack --runtime win10-x64
  ```

- Pack the project using a [.nuspec file](https://docs.microsoft.com/nuget/reference/msbuild-targets#packing-using-a-nuspec):

  ```dotnetcli
  dotnet pack ~/projects/app1/project.csproj -p:NuspecFile=~/projects/app1/project.nuspec -p:NuspecBasePath=~/projects/app1/nuget
  ```
