---
title: dotnet msbuild command
description: The dotnet msbuild command provides access to the MSBuild command line.
ms.date: 12/03/2018
---
# dotnet msbuild

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet msbuild` - Builds a project and all of its dependencies.

## Synopsis

`dotnet msbuild <msbuild_arguments> [-h]`

## Description

The `dotnet msbuild` command allows access to a fully functional MSBuild.

The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style projects only. The options are all the same. For more information about the available options, see the [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).

The [dotnet build](dotnet-build.md) command is equivalent to `dotnet msbuild -restore -target:Build`. [dotnet build](dotnet-build.md) is more commonly used for building projects, but because it always runs the build target, you can use `dotnet msbuild` when you don't want to build the project. For example, if you have a specific target you want to run without building the project, use `dotnet msbuild` and specify the target.

## Examples

* Build a project and its dependencies:

  ```dotnetcli
  dotnet msbuild
  ```

* Build a project and its dependencies using Release configuration:

  ```dotnetcli
  dotnet msbuild -property:Configuration=Release
  ```

* Run the publish target and publish for the `osx.10.11-x64` RID:

  ```dotnetcli
  dotnet msbuild -target:Publish -property:RuntimeIdentifiers=osx.10.11-x64
  ```

* See the whole project with all targets included by the SDK:

  ```dotnetcli
  dotnet msbuild -preprocess
  ```
