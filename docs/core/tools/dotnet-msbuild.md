---
title: dotnet msbuild command
description: The dotnet msbuild command provides access to the MSBuild command line.
ms.date: 02/14/2020
---
# dotnet msbuild

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet msbuild` - Builds a project and all of its dependencies. Note: A solution or project file may need to be specified if there are multiple.

## Synopsis

```dotnetcli
dotnet msbuild <MSBUILD_ARGUMENTS>

dotnet msbuild -h
```

## Description

The `dotnet msbuild` command allows access to a fully functional MSBuild.

The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style projects only. The options are all the same. For more information about the available options, see the [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).

The [dotnet build](dotnet-build.md) command is equivalent to `dotnet msbuild -restore`. When you don't want to build the project and you have a specific target you want to run, use `dotnet build` or `dotnet msbuild` and specify the target.

## Examples

- Build a project and its dependencies:

  ```dotnetcli
  dotnet msbuild
  ```

- Build a project and its dependencies using Release configuration:

  ```dotnetcli
  dotnet msbuild -property:Configuration=Release
  ```

- Run the publish target and publish for the `osx-x64` RID:

  ```dotnetcli
  dotnet msbuild -target:Publish -property:RuntimeIdentifiers=osx-x64
  ```

- See the whole project with all targets included by the SDK:

  ```dotnetcli
  dotnet msbuild -preprocess
  dotnet msbuild -preprocess:<fileName>.xml
  ```
