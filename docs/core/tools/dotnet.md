---
title: dotnet command - .NET Core CLI | Microsoft Docs
description: Learn about the dotnet command (the generic driver for the .NET Core CLI tools) and its usage.  
keywords: dotnet, CLI, CLI commands, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/20/2017
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

`dotnet [command] [arguments] [--version] [--info] [-d|--diagnostics] [-v|--verbose] [--fx-version] [--additionalprobingpath] [-h|--help]`

## Description

`dotnet` is a generic driver for the Command Line Interface (CLI) toolchain. Invoked on its own, it provides brief usage instructions.

Each specific feature is implemented as a command. In order to use the feature, the command is specified after `dotnet`, such as [`dotnet build`](dotnet-build.md). All of the arguments following the command are its own arguments.

The only time `dotnet` is used as a command on its own is to run [framework-dependent apps](../deploying/index.md). Specify an application DLL after the `dotnet` verb to execute the application (for example, `dotnet myapp.dll`).

## Options

`-v|--verbose`

Enables verbose output.

`-d|--diagnostics`

Enables diagnostic output.

`--fx-version <VERSION>`

Version of the installed Shared Framework to use to run the application.

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`--version`

Prints out the version of the CLI tooling.

`--info`

Prints out detailed information about the CLI tooling and the environment, such as the current operating system, commit SHA for the version, and other information.

`-h|--help`

Prints out a short help for the command. If using with `dotnet`, it also prints a list of the available commands.

## dotnet commands

### General

Command | Function
--- | ---
[dotnet-build](dotnet-build.md) | Builds a .NET Core application.
[dotnet-clean](dotnet-clean.md) | Clean build output(s).
[dotnet-migrate](dotnet-migrate.md) | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.
[dotnet-msbuild](dotnet-msbuild.md) | Provides access to the MSBuild command line.
[dotnet-new](dotnet-new.md) | Initializes a C# or F# project for a given template.
[dotnet-pack](dotnet-pack.md) | Creates a NuGet package of your code.
[dotnet-publish](dotnet-publish.md) | Publishes a .NET framework-dependent or self-contained application.
[dotnet-restore](dotnet-restore.md) | Restores the dependencies for a given application.
[dotnet-run](dotnet-run.md) | Runs the application from source.
[dotnet-sln](dotnet-sln.md) | Options to add, remove, and list projects in a solution file.
[dotnet-test](dotnet-test.md) | Runs tests using a test runner.

### Project references

Command | Function
--- | ---
[dotnet-add reference](dotnet-add-reference.md) | Add a project reference.
[dotnet-list reference](dotnet-list-reference.md) | List project references.
[dotnet-remove reference](dotnet-remove-reference.md) | Remove a project reference.

### NuGet packages

Command | Function
--- | ---
[dotnet-add package](dotnet-add-package.md) | Add a NuGet package.
[dotnet-remove package](dotnet-remove-package.md) | Remove a NuGet package.

### NuGet commands

Command | Function
--- | ---
[dotnet-nuget delete](dotnet-nuget-delete.md) | Deletes or unlists a package from the server.
[dotnet-nuget locals](dotnet-nuget-locals.md) | Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.
[dotnet-nuget push](dotnet-nuget-push.md) | Pushes a package to the server and publishes it.

## Examples

Initialize a sample .NET Core console application that can be compiled and run:

`dotnet new console`

Restore dependencies for a given application:

`dotnet restore`

Build a project and its dependencies in a given directory:

`dotnet build`

Run a framework-dependent app named `myapp.dll`:

`dotnet myapp.dll`

## Environment variables

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted); otherwise, set to `false` to opt-in to the telemetry features (values `false`, `0`, or `no` accepted). If not set, the defaults is `false`, and the telemetry feature is active.
