---
title: dotnet command
description: Learn about the dotnet command (the generic driver for the .NET Core CLI tools) and its usage.  
keywords: dotnet, CLI, CLI commands, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 256e468e-eaaa-4715-b5fb-8cbddcf80e69
---

# dotnet command

## Name

`dotnet` - General driver for running the command-line commands.

## Synopsis

`dotnet [command] [arguments] [--additional-deps] [--additionalprobingpath] [-d|--diagnostics] [--depsfile] [--fx-version] [-h|--help] [--info] [--roll-forward-on-no-candidate-fx] [--runtimeconfig] [-v|--verbose] [--version]`

## Description

`dotnet` is a generic driver for the Command-Line Interface (CLI) toolchain. Invoked on its own, it provides usage instructions.

Each feature is implemented as a command. In order to use a feature, the command is specified after `dotnet`. For example, you build a .NET Core project with the *build* feature by executing [`dotnet build`](dotnet-build.md) at a command prompt.

The only time `dotnet` is used as a command on its own is to run [framework-dependent apps](../deploying/index.md). Specify an app DLL after `dotnet` to execute the app (for example, `dotnet myapp.dll`).

## Options

`--additional-deps <PATH>`

Path to an additonal *\<assembly_name>.deps.json* file.

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`-d|--diagnostics`

Enables diagnostic output.

`--depsfile <PATH>`

Path to the *\<assembly_name>.deps.json* file.

`--fx-version <VERSION>`

Specifies the version of the installed shared framework used to run the app.

`-h|--help`

Shows help information. If using with `dotnet`, it shows a list of the available commands.

`--info`

Shows detailed information about the CLI tooling and the environment, such as the current operating system and the commit SHA for the version.

`--roll-forward-on-no-candidate-fx`

Specifies roll forward behavior when no candidate shared framework is enabled.

`--runtimeconfig <PATH>`

Path to the *\<assembly_name>.runtimeconfig.json* file.

`-v|--verbose`

Enables verbose output.

`--version`

Shows the version of the CLI tooling.

## dotnet commands

### General

| Command                             | Function                                                            |
| ----------------------------------- | ------------------------------------------------------------------- |
| [dotnet build](dotnet-build.md)     | Builds a .NET Core app.                                             |
| [dotnet clean](dotnet-clean.md)     | Cleans build outputs.                                               |
| [dotnet migrate](dotnet-migrate.md) | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.  |
| [dotnet msbuild](dotnet-msbuild.md) | Provides access to the MSBuild command line.                        |
| [dotnet new](dotnet-new.md)         | Initializes a C# or F# project for a given template.                |
| [dotnet pack](dotnet-pack.md)       | Creates a NuGet package of your code.                               |
| [dotnet publish](dotnet-publish.md) | Publishes a .NET framework-dependent or self-contained deployment.  |
| [dotnet restore](dotnet-restore.md) | Restores the dependencies of an app.                                |
| [dotnet run](dotnet-run.md)         | Runs an app from source code.                                       |
| [dotnet sln](dotnet-sln.md)         | Options to add, remove, and list projects in a solution file.       |
| [dotnet test](dotnet-test.md)       | Runs tests using a test runner.                                     |
| [dotnet vstest](dotnet-vstest.md)   | Runs tests from the specified files.                                |

### Project references

| Command                                               | Function                     |
| ----------------------------------------------------- | ---------------------------- |
| [dotnet add reference](dotnet-add-reference.md)       | Adds a project reference.    |
| [dotnet list reference](dotnet-list-reference.md)     | Lists project references.    |
| [dotnet remove reference](dotnet-remove-reference.md) | Removes a project reference. |

### NuGet packages

| Command                                           | Function                 |
| ------------------------------------------------- | ------------------------ |
| [dotnet add package](dotnet-add-package.md)       | Adds a NuGet package.    |
| [dotnet remove package](dotnet-remove-package.md) | Removes a NuGet package. |

### NuGet commands

| Command                                       | Function |
| --------------------------------------------- | -------- |
| [dotnet nuget delete](dotnet-nuget-delete.md) | Deletes or unlists a package from the server. |
| [dotnet nuget locals](dotnet-nuget-locals.md) | Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder. |
| [dotnet nuget push](dotnet-nuget-push.md)     | Pushes a package to the server and publishes it. |

## Examples

Initialize a sample .NET Core console app:

`dotnet new console`

Restore dependencies for an app:

`dotnet restore`

Build a project and its dependencies:

`dotnet build`

Run a framework-dependent app named *myapp.dll*:

`dotnet myapp.dll`

## Environment variables

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to *$HOME/.nuget/packages* on Unix or *%HOME%\NuGet\Packages* on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (valid values: `true`, `1`, or `yes`). Set to `false` to opt-in to the telemetry features (valid values: `false`, `0`, or `no`). If not set, the default is `false`, and the telemetry feature is active.
