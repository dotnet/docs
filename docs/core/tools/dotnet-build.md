---
title: dotnet build command - .NET Core CLI
description: The dotnet build command builds a project and all of its dependencies.
author: mairaw
ms.author: mairaw
ms.date: 03/10/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet-build

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet build` - Builds a project and all of its dependencies.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)
```
dotnet build [<PROJECT>] [-c|--configuration] [-f|--framework] [--force] [--no-dependencies] [--no-incremental]
    [--no-restore] [-o|--output] [-r|--runtime] [-v|--verbosity] [--version-suffix]
dotnet build [-h|--help]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet build [<PROJECT>] [-c|--configuration] [-f|--framework] [--no-dependencies] [--no-incremental] [-o|--output]
    [-r|--runtime] [-v|--verbosity] [--version-suffix]
dotnet build [-h|--help]
```
---

## Description

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a *.dll* extension and symbol files used for debugging with a *.pdb* extension. A dependencies JSON file (*\*.deps.json*) is produced that lists the dependencies of the application. A *\*.runtimeconfig.json* file is produced, which specifies the shared runtime and its version for the application.

If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of `dotnet build` isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you need to use the [dotnet publish](dotnet-publish.md) command. For more information, see [.NET Core Application Deployment](../deploying/index.md).

Building requires the *project.assets.json* file, which lists the dependencies of your application. The file is created when [`dotnet restore`](dotnet-restore.md) is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which results in errors. With .NET Core 1.x SDK, you needed to explicitily run the `dotnet restore` before running `dotnet build`. Starting with .NET Core 2.0 SDK, `dotnet restore` runs implicitily when you run `dotnet build`. If you want to disable implicit restore when running the build command, you can pass the `--no-restore` option.

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

`dotnet build` uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to [Incremental Builds](/visualstudio/msbuild/incremental-builds) for more information.

In addition to its options, the `dotnet build` command accepts MSBuild options, such as `/p` for setting properties or `/l` to define a logger. Learn more about these options in the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference). 

Whether the project is executable or not is determined by the `<OutputType>` property in the project file. The following example shows a project that will produce executable code:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

In order to produce a library, omit the `<OutputType>` property. The main difference in built output is that the IL DLL for a library doesn't contain entry points and can't be executed. 

## Arguments

`PROJECT`

The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

## Options

# [.NET Core 2.x](#tab/netcore2x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](csproj.md).

`--force`

 Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the *project.assets.json* file.

`-h|--help`

Prints out a short help for the command.

`--no-dependencies`

Ignores project-to-project (P2P) references and only builds the root project specified to build.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

`--no-restore`

Doesn't perform an implicit restore during build.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to place the built binaries. You also need to define `--framework` when you specify this option.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix for an asterisk (`*`) in the version field of the project file. The format follows NuGet's version guidelines.

# [.NET Core 1.x](#tab/netcore1x)

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Compiles for a specific [framework](../../standard/frameworks.md). The framework must be defined in the [project file](csproj.md).

`-h|--help`

Prints out a short help for the command.

`--no-dependencies`

Ignores project-to-project (P2P) references and only builds the root project specified to build.

`--no-incremental`

Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to place the built binaries. You also need to define `--framework` when you specify this option.

`-r|--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`--version-suffix <VERSION_SUFFIX>`

Defines the version suffix for an asterisk (`*`) in the version field of the project file. The format follows NuGet's version guidelines.

---

## Examples

Build a project and its dependencies:

`dotnet build`

Build a project and its dependencies using Release configuration:

`dotnet build --configuration Release`

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

`dotnet build --runtime ubuntu.16.04-x64`

Build the project and use the specified NuGet package source during the restore operation (.NET Core SDK 2.0 and later versions):

`dotnet build --source c:\packages\mypackages`