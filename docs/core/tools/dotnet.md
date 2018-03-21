---
title: dotnet command - .NET Core CLI
description: Learn about the dotnet command (the generic driver for the .NET Core CLI tools) and its usage.
author: mairaw
ms.author: mairaw
ms.date: 03/20/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet command

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet` - General driver for running the command-line commands.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)
```
dotnet [command] [arguments] [--additional-deps] [--additionalprobingpath] [-d|--diagnostics]
    [--fx-version] [-h|--help] [--info] [--roll-forward-on-no-candidate-fx] [-v|--verbosity] [--version]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet [command] [arguments] [--additionalprobingpath] [-d|--diagnostics] [--fx-version]
    [-h|--help] [--info] [-v|--verbosity] [--version]
```
---

## Description

`dotnet` is a generic driver for the Command Line Interface (CLI) toolchain. Invoked on its own, it provides brief usage instructions.

Each specific feature is implemented as a command. In order to use the feature, the command is specified after `dotnet`, such as [`dotnet build`](dotnet-build.md). All of the arguments following the command are its own arguments.

The only time `dotnet` is used as a command on its own is to run [framework-dependent apps](../deploying/index.md). Specify an application DLL after the `dotnet` verb to execute the application (for example, `dotnet myapp.dll`).

## Options

# [.NET Core 2.x](#tab/netcore2x)

`--additional-deps <PATH>`

Path to additional *deps.json* file.

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`-d|--diagnostics`

Enables diagnostic output.

`--fx-version <VERSION>`

Version of the installed .NET Core runtime to use to run the application.

`-h|--help`

Prints out a short help for the command. If using with `dotnet`, it also prints a list of the available commands.

`--info`

Prints out detailed information about the CLI tooling and the environment, such as the current operating system, commit SHA for the version, and other information.

`--roll-forward-on-no-candidate-fx`

 Rolls forward on no candidate shared framework.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Not supported in every command; see specific command page to determine if this option is available.

`--version`

Prints out the version of the .NET Core SDK in use.

# [.NET Core 1.x](#tab/netcore1x)

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`-d|--diagnostics`

Enables diagnostic output.

`--fx-version <VERSION>`

Version of the installed .NET Core runtime to use to run the application.

`-h|--help`

Prints out a short help for the command. If using with `dotnet`, it also prints a list of the available commands.

`--info`

Prints out detailed information about the CLI tooling and the environment, such as the current operating system, commit SHA for the version, and other information.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Not supported in every command; see specific command page to determine if this option is available.

`--version`

Prints out the version of the .NET Core SDK in use.

---

## dotnet commands

### General

# [.NET Core 2.x](#tab/netcore2x)

| Command                             | Function                                                            |
| ----------------------------------- | ------------------------------------------------------------------- |
| [dotnet build](dotnet-build.md)     | Builds a .NET Core application.                                     |
| [dotnet clean](dotnet-clean.md)     | Clean build outputs.                                              |
| [dotnet help](dotnet-help.md)       | Shows more detailed documentation online for the command.           |
| [dotnet migrate](dotnet-migrate.md) | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.  |
| [dotnet msbuild](dotnet-msbuild.md) | Provides access to the MSBuild command line.                        |
| [dotnet new](dotnet-new.md)         | Initializes a C# or F# project for a given template.                |
| [dotnet pack](dotnet-pack.md)       | Creates a NuGet package of your code.                               |
| [dotnet publish](dotnet-publish.md) | Publishes a .NET framework-dependent or self-contained application. |
| [dotnet restore](dotnet-restore.md) | Restores the dependencies for a given application.                  |
| [dotnet run](dotnet-run.md)         | Runs the application from source.                                   |
| [dotnet sln](dotnet-sln.md)         | Options to add, remove, and list projects in a solution file.       |
| [dotnet store](dotnet-store.md)     | Stores assemblies in the runtime package store.                     |
| [dotnet test](dotnet-test.md)       | Runs tests using a test runner.                                     |

# [.NET Core 1.x](#tab/netcore1x)

| Command                             | Function                                                            |
| ----------------------------------- | ------------------------------------------------------------------- |
| [dotnet build](dotnet-build.md)     | Builds a .NET Core application.                                     |
| [dotnet clean](dotnet-clean.md)     | Clean build outputs.                                              |
| [dotnet migrate](dotnet-migrate.md) | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.  |
| [dotnet msbuild](dotnet-msbuild.md) | Provides access to the MSBuild command line.                        |
| [dotnet new](dotnet-new.md)         | Initializes a C# or F# project for a given template.                |
| [dotnet pack](dotnet-pack.md)       | Creates a NuGet package of your code.                               |
| [dotnet publish](dotnet-publish.md) | Publishes a .NET framework-dependent or self-contained application. |
| [dotnet restore](dotnet-restore.md) | Restores the dependencies for a given application.                  |
| [dotnet run](dotnet-run.md)         | Runs the application from source.                                   |
| [dotnet sln](dotnet-sln.md)         | Options to add, remove, and list projects in a solution file.       |
| [dotnet test](dotnet-test.md)       | Runs tests using a test runner.                                     |

---

### Project references

Command | Function
--- | ---
[dotnet add reference](dotnet-add-reference.md) | Add a project reference.
[dotnet list reference](dotnet-list-reference.md) | List project references.
[dotnet remove reference](dotnet-remove-reference.md) | Remove a project reference.

### NuGet packages

Command | Function
--- | ---
[dotnet add package](dotnet-add-package.md) | Add a NuGet package.
[dotnet remove package](dotnet-remove-package.md) | Remove a NuGet package.

### NuGet commands

Command | Function
--- | ---
[dotnet nuget delete](dotnet-nuget-delete.md) | Deletes or unlists a package from the server.
[dotnet nuget locals](dotnet-nuget-locals.md) | Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.
[dotnet nuget push](dotnet-nuget-push.md) | Pushes a package to the server and publishes it.

## Examples

Initialize a sample .NET Core console application that can be compiled and run:

`dotnet new console`

Restore dependencies for a given application:

`dotnet restore`

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

Build a project and its dependencies in a given directory:

`dotnet build`

Run a framework-dependent app named `myapp.dll`:

`dotnet myapp.dll`

## Environment variables

# [.NET Core 2.x](#tab/netcore2x)

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted); otherwise, set to `false` to opt-in to the telemetry features (values `false`, `0`, or `no` accepted). If not set, the defaults is `false`, and the telemetry feature is active.

`DOTNET_MULTILEVEL_LOOKUP`

Specifies whether .NET Core runtime, shared framework or SDK are resolved from the global location. If not set, it defaults to `true`. Set to `false` to not resolve from the global location and have isolated .NET Core installations (values `0` or `false` are accepted). For more information about multi-level lookup, see [Multi-level SharedFX Lookup](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/multilevel-sharedfx-lookup.md).

# [.NET Core 1.x](#tab/netcore1x)

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted); otherwise, set to `false` to opt-in to the telemetry features (values `false`, `0`, or `no` accepted). If not set, the defaults is `false`, and the telemetry feature is active.

---
