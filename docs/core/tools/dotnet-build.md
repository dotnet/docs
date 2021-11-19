---
title: dotnet build command
description: The dotnet build command builds a project and all of its dependencies.
ms.date: 08/12/2021
---
# dotnet build

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet build` - Builds a project and all of its dependencies.

## Synopsis

```dotnetcli
dotnet build [<PROJECT>|<SOLUTION>] [-a|--arch <ARCHITECTURE>]
    [-c|--configuration <CONFIGURATION>] [-f|--framework <FRAMEWORK>]
    [--force] [--interactive] [--no-dependencies] [--no-incremental]
    [--no-restore] [--nologo] [--no-self-contained] [--os <OS>]
    [-o|--output <OUTPUT_DIRECTORY>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--self-contained [true|false]] [--source <SOURCE>]
    [-v|--verbosity <LEVEL>] [--version-suffix <VERSION_SUFFIX>]

dotnet build -h|--help
```

## Description

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a *.dll* extension.  Depending on the project type and settings, other files may be included, such as:

- An executable that can be used to run the application, if the project type is an executable targeting .NET Core 3.0 or later.
- Symbol files used for debugging with a *.pdb* extension.
- A *.deps.json* file, which lists the dependencies of the application or library.
- A *.runtimeconfig.json* file, which specifies the shared runtime and its version for an application.
- Other libraries that the project depends on (via project references or NuGet package references).

For executable projects targeting versions earlier than .NET Core 3.0, library dependencies from NuGet are typically NOT copied to the output folder.  They're resolved from the NuGet global packages folder at run time. With that in mind, the product of `dotnet build` isn't ready to be transferred to another machine to run. To create a version of the application that can be deployed, you need to publish it (for example, with the [dotnet publish](dotnet-publish.md) command). For more information, see [.NET Application Deployment](../deploying/index.md).

For executable projects targeting .NET Core 3.0 and later, library dependencies are copied to the output folder. This means that if there isn't any other publish-specific logic (such as Web projects have), the build output should be deployable.

### Implicit restore

Building requires the *project.assets.json* file, which lists the dependencies of your application. The file is created when [`dotnet restore`](dotnet-restore.md) is executed. Without the assets file in place, the tooling can't resolve reference assemblies, which results in errors.

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

### Executable or library output

Whether the project is executable or not is determined by the `<OutputType>` property in the project file. The following example shows a project that produces executable code:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

To produce a library, omit the `<OutputType>` property or change its value to `Library`. The IL DLL for a library doesn't contain entry points and can't be executed.

### MSBuild

`dotnet build` uses MSBuild to build the project, so it supports both parallel and incremental builds. For more information, see [Incremental Builds](/visualstudio/msbuild/incremental-builds).

In addition to its options, the `dotnet build` command accepts MSBuild options, such as `-p` for setting properties or `-l` to define a logger. For more information about these options, see the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). Or you can also use the [dotnet msbuild](dotnet-msbuild.md) command.

> [!NOTE]
> When `dotnet build` is run automatically by `dotnet run`, arguments like `-property:property=value` aren't respected.

Running `dotnet build` is equivalent to running `dotnet msbuild -restore`; however, the default verbosity of the output is different.

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

`PROJECT | SOLUTION`

The project or solution file to build. If a project or solution file isn't specified, MSBuild searches the current working directory for a file that has a file extension that ends in either *proj* or *sln* and uses that file.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](../project-sdk/overview.md).

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`--no-dependencies`**

  Ignores project-to-project (P2P) references and only builds the specified root project.

- **`--no-incremental`**

  Marks the build as unsafe for incremental build. This flag turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

- **`--no-restore`**

  Doesn't execute an implicit restore during build.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.

- **`--no-self-contained`**

  Publishes the application as a framework dependent application. A compatible .NET runtime must be installed on the target machine to run the application. Available since .NET 6 SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Directory in which to place the built binaries. If not specified, the default path is `./bin/<configuration>/<framework>/`.  For projects with multiple target frameworks (via the `TargetFrameworks` property), you also need to define `--framework` when you specify this option.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). If you use this option with .NET 6 SDK, use `--self-contained` or `--no-self-contained` also.

- **`--self-contained [true|false]`**

  Publishes the .NET runtime with the application so the runtime doesn't need to be installed on the target machine. The default is `true` if a runtime identifier is specified.  Available since .NET 6 SDK.

- **`--source <SOURCE>`**

  The URI of the NuGet package source to use during the restore operation.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

- **`--version-suffix <VERSION_SUFFIX>`**

  Sets the value of the `$(VersionSuffix)` property to use when building the project. This only works if the `$(Version)` property isn't set. Then, `$(Version)` is set to the `$(VersionPrefix)` combined with the `$(VersionSuffix)`, separated by a dash.

## Examples

- Build a project and its dependencies:

  ```dotnetcli
  dotnet build
  ```

- Build a project and its dependencies using Release configuration:

  ```dotnetcli
  dotnet build --configuration Release
  ```

- Build a project and its dependencies for a specific runtime (in this example, Ubuntu 18.04):

  ```dotnetcli
  dotnet build --runtime ubuntu.18.04-x64
  ```

- Build the project and use the specified NuGet package source during the restore operation:

  ```dotnetcli
  dotnet build --source c:\packages\mypackages
  ```

- Build the project and set version 1.2.3.4 as a build parameter using the `-p` [MSBuild option](#msbuild):

  ```dotnetcli
  dotnet build -p:Version=1.2.3.4
  ```
