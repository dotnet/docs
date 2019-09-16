---
title: dotnet list package command
description: The 'dotnet list package' command provides a convenient option to list the package references for a project or solution.
ms.date: 06/26/2019
---
# dotnet list package

[!INCLUDE [topic-appliesto-net-core-22plus](../../../includes/topic-appliesto-net-core-22plus.md)]

## Name

`dotnet list package` - Lists the package references for a project or solution.

## Synopsis

```console
dotnet list [<PROJECT>|<SOLUTION>] package [--config] [--framework] [--highest-minor] [--highest-patch] 
   [--include-prerelease] [--include-transitive] [--interactive] [--outdated] [--source]
dotnet list package [-h|--help]
```

## Description

The `dotnet list package` command provides a convenient option to list all NuGet package references for a specific project or a solution. You first need to build the project in order to have the assets needed for this command to process. The following example shows the output of the `dotnet list package` command for the [SentimentAnalysis](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/SentimentAnalysis) project:

```output
Project 'SentimentAnalysis' has the following package references
   [netcoreapp2.1]:
   Top-level Package               Requested   Resolved
   > Microsoft.ML                  0.11.0      0.11.0
   > Microsoft.NETCore.App   (A)   [2.1.0, )   2.1.0

(A) : Auto-referenced package.
```

The **Requested** column refers to the package version specified in the project file and can be a range. The **Resolved** column lists the version that the project is currently using and is always a single value. The packages displaying an `(A)` right next to their names represent [implicit package references](csproj.md#implicit-package-references) that are inferred from your project settings (`Sdk` type, `<TargetFramework>` or `<TargetFrameworks>` property, etc.)

Use the `--outdated` option to find out if there are newer versions available of the packages you're using in your projects. By default, `--outdated` lists the latest stable packages unless the resolved version is also a prerelease version. To include prerelease versions when listing newer versions, also specify the `--include-prerelease` option. The following examples shows the output of the `dotnet list package --outdated --include-prerelease` command for the same project as the previous example:

```output
The following sources were used:
   https://api.nuget.org/v3/index.json

Project `SentimentAnalysis` has the following updates to its packages
   [netcoreapp2.1]:
   Top-level Package      Requested   Resolved   Latest
   > Microsoft.ML         0.11.0      0.11.0     1.0.0-preview
```

If you need to find out whether your project has transitive dependencies, use the `--include-transitive` option. Transitive dependencies occur when you add a package to your project that in turn relies on another package. The following example shows the output from running the `dotnet list package --include-transitive` command for the [HelloPlugin](https://github.com/dotnet/samples/tree/master/core/extensions/AppWithPlugin/HelloPlugin) project, which displays top-level packages and the packages they depend on:

```output
Project 'HelloPlugin' has the following package references
   [netcoreapp3.0]:
   Top-level Package                      Requested                    Resolved
   > Microsoft.NETCore.Platforms    (A)   [3.0.0-preview3.19128.7, )   3.0.0-preview3.19128.7
   > Microsoft.WindowsDesktop.App   (A)   [3.0.0-preview3-27504-2, )   3.0.0-preview3-27504-2

   Transitive Package               Resolved
   > Microsoft.NETCore.Targets      2.0.0
   > PluginBase                     1.0.0

(A) : Auto-referenced package.
```

## Arguments

`PROJECT | SOLUTION`

The project or solution file to operate on. If not specified, the command searches the current directory for one. If more than one solution or project is found, an error is thrown.

## Options

* **`--config <SOURCE>`**

  The NuGet sources to use when searching for newer packages. Requires the `--outdated` option.

* **`--framework <FRAMEWORK>`**

  Displays only the packages applicable for the specified [target framework](../../standard/frameworks.md). To specify multiple frameworks, repeat the option multiple times. For example: `--framework netcoreapp2.2 --framework netstandard2.0`.

* **`-h|--help`**

  Prints out a short help for the command.

* **`--highest-minor`**

  Considers only the packages with a matching major version number when searching for newer packages. Requires the `--outdated` option.

* **`--highest-patch`**

  Considers only the packages with a matching major and minor version numbers when searching for newer packages. Requires the `--outdated` option.

* **`--include-prerelease`**

  Considers packages with prerelease versions when searching for newer packages. Requires the `--outdated` option.

* **`--include-transitive`**

  Lists transitive packages, in addition to the top-level packages. When specifying this option, you get a list of packages that the top-level packages depend on.

* **`--interactive`**

  Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK.

* **`--outdated`**

  Lists packages that have newer versions available.

* **`-s|--source <SOURCE>`**

  The NuGet sources to use when searching for newer packages. Requires the `--outdated` option.

## Examples

* List package references of a specific project:

  ```console
  dotnet list SentimentAnalysis.csproj package
  ```

* List package references that have newer versions available, including prerelease versions:

  ```console
  dotnet list package --outdated --include-prerelease
  ```

* List package references for a specific target framework:

  ```console
  dotnet list package --framework netcoreapp3.0
  ```
