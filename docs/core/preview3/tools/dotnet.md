---
title: dotnet command | Microsoft Docs
description: Learn about the dotnet command (the generic driver for the .NET Core CLI tools) and its usage.  
keywords: dotnet, CLI, CLI commands, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 256e468e-eaaa-4715-b5fb-8cbddcf80e69
---
# dotnet command

## Name

`dotnet` - General driver for running the command-line commands

## Synopsis

```
dotnet [command] [arguments] [--version] [--info] [-d|--diagnostics] [-v|--verbose]
dotnet [-h|--help]
```

## Description

`dotnet` is a generic driver for the Command Line Interface (CLI) toolchain. Invoked on its own, it will give out brief usage instructions.

Each specific feature is implemented as a command. In order to use the feature, the command is specified after `dotnet`, such as [`dotnet build`](dotnet-build.md). All of the arguments following the command are its own arguments.

The only time `dotnet` is used as a command on its own is to run portable apps. Just specify a portable application DLL after the `dotnet` verb to execute the application.

## Options

`-v|--verbose`

Enables verbose output.

`-d|--diagnostics`

Enables diagnostic output.

`--version`

Prints out the version of the CLI tooling.

`--info`

Prints out more detailed information about the CLI tooling, such as the current operating system, commit SHA for the version, etc.

`-h|--help`

Prints out a short help for the command. If using with `dotnet` only, it also prints a list of the available commands.

## dotnet commands

The following commands exist for dotnet:

* [dotnet-new](dotnet-new.md)
  * Initializes a C# or F# project for a given template.
* [dotnet-restore](dotnet-restore.md)
  * Restores the dependencies for a given application.
* [dotnet-build](dotnet-build.md)
  * Builds a .NET Core application.
* [dotnet-publish](dotnet-publish.md)
  * Publishes a .NET portable or self-contained application.
* [dotnet-run](dotnet-run.md)
  * Runs the application from source.
* [dotnet-test](dotnet-test.md)
  * Runs tests using a test runner specified in the project.json.
* [dotnet-pack](dotnet-pack.md)
  * Creates a NuGet package of your code.
* [dotnet-migrate](dotnet-migrate.md)
  * Migrates a valid Preview 2 project to a .NET Core SDK 1.0.0 project.
* [dotnet-msbuild](dotnet-msbuild.md)
  * Provides access to the MSBuild command line.
* [dotnet-clean](dotnet-clean.md)
  * Clean build output(s).
* [dotnet-sln](dotnet-sln.md)
  * Options to add, remove, and list projects in a solution file.
* Project modification commands
  * References - add, remove, and list project to project references.
    * [dotnet-add reference](dotnet-add-reference.md)
    * [dotnet-remove reference](dotnet-remove-reference.md)
    * [dotnet-list reference](dotnet-list-reference.md)
  * Packages - add and remove NuGet packages on a project.
    * [dotnet-add package](dotnet-add-package.md)
    * [dotnet-remove package](dotnet-remove-package.md)

## Examples

Initialize a sample .NET Core console application that can be compiled and run:

`dotnet new console`

Restore dependencies for a given application:

`dotnet restore`

Build a project and its dependencies in a given directory:

`dotnet build`

Run a portable app named `myapp.dll`:
`dotnet myapp.dll`

## Environment

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to $HOME/.nuget/packages on Unix or %HOME%\NuGet\Packages on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. `true` to opt-out of the telemetry feature (values true, 1 or yes accepted); otherwise, `false` (values false, 0 or no accepted). If not set, it defaults to `false`, that is, the telemetry feature is on.
