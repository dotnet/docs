---
title: dotnet pack command
description: The dotnet pack command creates NuGet packages for your .NET project.
ms.date: 04/02/2026
ai-usage: ai-assisted
---
# dotnet pack

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet pack` - Packs the code into a NuGet package.

## Synopsis

```dotnetcli
dotnet pack [<PROJECT>|<SOLUTION>|<NUSPEC>|<FILE>]
    [--artifacts-path <ARTIFACTS_DIR>] [-c|--configuration <CONFIGURATION>]
    [--disable-build-servers] [--force] [--include-source] [--include-symbols]
    [--interactive] [--no-build] [--no-dependencies] [--no-restore] [--nologo]
    [-o|--output <OUTPUT_DIRECTORY>] [-p|--property:<PROPERTYNAME>=<VALUE>]
    [--runtime <RUNTIME_IDENTIFIER>]
    [-s|--serviceable] [--tl:[auto|on|off]] [-v|--verbosity <LEVEL>]
    [--version <VERSION>] [--version-suffix <VERSION_SUFFIX>]

dotnet pack -h|--help
```

## Description

The `dotnet pack` command builds the project and creates NuGet packages. The result of this command is a NuGet package (that is, a *.nupkg* file).

Starting with .NET 10, you can also pass a *.nuspec* file or a file-based app (*.cs* file) directly as the argument. When you pass a *.nuspec* file, `dotnet pack` creates the package from the *.nuspec* file without requiring a project file and without running MSBuild. When you pass a file-based app, `dotnet pack` packs it without a project file.

If you want to generate a package that contains the debug symbols, you have two options available:

- `--include-symbols` - it creates the symbols package.
- `--include-source` - it creates the symbols package with a `src` folder inside containing the source files.

NuGet dependencies of the packed project are added to the *.nuspec* file, so they're properly resolved when the package is installed. If the packed project has references to other projects, the other projects aren't included in the package. Currently, you must have a package per project if you have project-to-project dependencies.

By default, `dotnet pack` builds the project first. If you wish to avoid this behavior, pass the `--no-build` option. This option is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.

> [!NOTE]
> In some cases, the implicit build cannot be performed. This can occur when `GeneratePackageOnBuild` is set, to avoid a cyclic dependency between build and pack targets. The build can also fail if there is a locked file or other issue.

> [!NOTE]
> Web projects aren't packable.

### Implicit restore

[!INCLUDE[dotnet restore note + options](includes/dotnet-restore-note-options.md)]

[!INCLUDE [cli-advertising-manifests](includes/cli-advertising-manifests.md)]

## Arguments

`PROJECT | SOLUTION | NUSPEC | FILE`

  The project, solution, *.nuspec* file, or file-based app to pack.

- `PROJECT` is the path to a `.csproj`, `.vbproj`, or `.fsproj` file, or to a directory containing a project file.
- `SOLUTION` is the path to a solution file (`.sln` or `.slnx` extension), or to a directory containing a solution file.
- `NUSPEC` is the path to a `.nuspec` file. Available starting in .NET 10.
- `FILE` is the path to a file-based app (a C# file without a corresponding project file). Available starting in .NET 10. For more information, see [Build file-based C# apps](../../csharp/fundamentals/tutorials/file-based-programs.md).

  If not specified, the command searches the current directory for a project or solution file.

## Options

- [!INCLUDE [artifacts-path](includes/cli-artifacts-path.md)]

- [!INCLUDE [configuration](includes/cli-configuration-publish-pack.md)]

- [!INCLUDE [disable-build-servers](includes/cli-disable-build-servers.md)]

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

- **`--include-source`**

  Includes the debug symbols NuGet packages in addition to the regular NuGet packages in the output directory. The sources files are included in the `src` folder within the symbols package.

- **`--include-symbols`**

  Includes the debug symbols NuGet packages in addition to the regular NuGet packages in the output directory.

- [!INCLUDE [interactive](includes/cli-interactive.md)]

- **`--no-build`**

  Doesn't build the project before packing. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Ignores project-to-project references and only restores the root project.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Places the built packages in the directory specified.

  - .NET 7.0.200 SDK

    In the 7.0.200 SDK, if you specify the `--output` option when running this command on a solution, the CLI will emit an error. This is a regression and was fixed in 7.0.201 and later versions of the .NET SDK.

- **`-p|--property:<PROPERTYNAME>=<VALUE>`**

  Sets one or more MSBuild properties. When packing a *.nuspec* file directly, the properties are used for token replacement in the *.nuspec* file rather than as MSBuild properties. Specify multiple properties delimited by semicolons or by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1>;<NAME2>=<VALUE2>
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  For more information, see [NuGet pack target properties](/nuget/reference/msbuild-targets#pack-target) and [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).

- **`--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

- **`-s|--serviceable`**

  Sets the serviceable flag in the package. For more information, see [.NET Blog: .NET Framework 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries](https://aka.ms/nupkgservicing).

- [!INCLUDE [tl](includes/cli-tl.md)]

- [!INCLUDE [verbosity](includes/cli-verbosity.md)]

- **`--version <VERSION>`**

  The version of the package to create. When packing a *.nuspec* file, overrides the version number in the *.nuspec* file.

  > [!NOTE]
  > Available starting in .NET 10.

- **`--version-suffix <VERSION_SUFFIX>`**

  Defines the value for the `VersionSuffix` MSBuild property. The effect of this property on the package version depends on the values of the `Version` and `VersionPrefix` properties, as shown in the following table:

  | Properties with values              | Package version                     |
  |-------------------------------------|-------------------------------------|
  | None                                | `1.0.0`                             |
  | `Version`                           | `$(Version)`                        |
  | `VersionPrefix` only                | `$(VersionPrefix)`                  |
  | `VersionSuffix` only                | `1.0.0-$(VersionSuffix)`            |
  | `VersionPrefix` and `VersionSuffix` | `$(VersionPrefix)-$(VersionSuffix)` |

  If you want to use `--version-suffix`, specify `VersionPrefix` and not `Version` in the project file. For example, if `VersionPrefix` is `0.1.2` and you pass `--version-suffix rc.1` to `dotnet pack`, the package version will be `0.1.2-rc.1`.

  If `Version` has a value and you pass `--version-suffix` to `dotnet pack`, the value specified for `--version-suffix` is ignored.

- [!INCLUDE [help](includes/cli-help.md)]

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

- Pack the project and use a specific runtime (Windows) for the restore operation:

  ```dotnetcli
  dotnet pack --runtime win-x64
  ```

- Pack the project using a *.nuspec* file (MSBuild project-based approach):

  ```dotnetcli
  dotnet pack ~/projects/app1/project.csproj -p:NuspecFile=~/projects/app1/project.nuspec -p:NuspecBasePath=~/projects/app1/nuget
  ```

  For information about how to use `NuspecFile`, `NuspecBasePath`, and `NuspecProperties`, see the following resources:

  - [Packing using a .nuspec](/nuget/reference/msbuild-targets#packing-using-a-nuspec)
  - [Advanced extension points to create customized package](/nuget/reference/msbuild-targets#advanced-extension-points-to-create-customized-package)
  - [Global properties](/visualstudio/msbuild/msbuild-properties#global-properties)

- Pack a *.nuspec* file directly, without a project file (.NET 10 and later):

  ```dotnetcli
  dotnet pack MyPackage.nuspec --output ./artifacts

  ```dotnetcli
  dotnet pack MyPackage.nuspec --version 1.2.3 --output ./artifacts
  ```

- Pack a *.nuspec* file directly and use token replacement (.NET 10 and later):

  ```dotnetcli
  dotnet pack MyPackage.nuspec --property:Version=1.2.3 --property:Configuration=Release --output ./artifacts
  ```
