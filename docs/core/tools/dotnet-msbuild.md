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

The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style project only. The options are all the same. For more information about the available options, see the [MSBuild Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference).

The [dotnet build](dotnet-build.md) command is equivalent to `dotnet msbuild -restore -target:Build`. `dotnet build` is more commonly used for building projects, but `dotnet msbuild` gives you more control. For example, if you have a specific target you want to run (without running the build target), you probably want to use `dotnet msbuild`.

## Examples

* Build a project and its dependencies:

  ```dotnetcli
  dotnet msbuild
  ```

* Build a project and its dependencies using Release configuration:

  ```dotnetcli
  dotnet msbuild -p:Configuration=Release
  ```

* Run the publish target and publish for the `osx.10.11-x64` RID:

  ```dotnetcli
  dotnet msbuild -t:Publish -p:RuntimeIdentifiers=osx.10.11-x64
  ```

* See the whole project with all targets included by the SDK:

  ```dotnetcli
  dotnet msbuild -pp
  ```
