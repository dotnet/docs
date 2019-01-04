---
title: dotnet command
description: Learn about the dotnet command (the generic driver for the .NET Core CLI tools) and its usage.
ms.date: 06/04/2018
---
# dotnet command

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet` - A tool for managing .NET source code and binaries.

## Synopsis

# [.NET Core 2.1](#tab/netcore21)
```
dotnet [command] [arguments] [--additional-deps] [--additionalprobingpath] [-d|--diagnostics] [--fx-version]
    [-h|--help] [--info] [--list-runtimes] [--list-sdks] [--roll-forward-on-no-candidate-fx] [-v|--verbosity] [--version]
```
# [.NET Core 2.0](#tab/netcore20)
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

`dotnet` is a tool for managing .NET source code and binaries. It exposes commands that perform specific tasks, such as [`dotnet build`](dotnet-build.md) and [`dotnet run`](dotnet-run.md). Each command defines its own arguments. Type `--help` after each command to access brief help documentation.

`dotnet` can be used to run applications, by specifying an application DLL, such as `dotnet myapp.dll`. See [.NET Core application deployment](../deploying/index.md) for to learn about deployment options.

## Options

# [.NET Core 2.1](#tab/netcore21)

`--additional-deps <PATH>`

Path to additional *deps.json* file.

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`-d|--diagnostics`

Enables diagnostic output.

`--fx-version <VERSION>`

Version of the .NET Core runtime to use to run the application.

`-h|--help`

Prints out documentation for a given command, such as `dotnet build --help`. `dotnet --help` prints a list of available commands.

`--info`

Prints out detailed information about a .NET Core installation and the machine environment, such as the current operating system, and commit SHA of the .NET Core version.

`--list-runtimes`

Displays the installed .NET Core runtimes.

`--list-sdks`

Displays the installed .NET Core SDKs.

`--roll-forward-on-no-candidate-fx`

 Disables minor version roll forward, if set to `0`. For more information, see [Roll forward](../whats-new/dotnet-core-2-1.md#roll-forward).

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Not supported in every command; see specific command page to determine if this option is available.

`--version`

Prints out the version of the .NET Core SDK in use.

# [.NET Core 2.0](#tab/netcore20)

`--additional-deps <PATH>`

Path to additional *deps.json* file.

`--additionalprobingpath <PATH>`

Path containing probing policy and assemblies to probe.

`-d|--diagnostics`

Enables diagnostic output.

`--fx-version <VERSION>`

Version of the .NET Core runtime to use to run the application.

`-h|--help`

Prints out documentation for a given command, such as `dotnet build --help`. `dotnet --help` prints a list of available commands.

`--info`

Prints out detailed information about a .NET Core installation and the machine environment, such as the current operating system, and commit SHA of the .NET Core version.

`--roll-forward-on-no-candidate-fx`

 Disables minor version roll forward, if set to `0`. For more information, see [Roll forward](../whats-new/dotnet-core-2-1.md#roll-forward).

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

Version of the .NET Core runtime to use to run the application.

`-h|--help`

Prints out documentation for a given command, such as `dotnet build --help`. `dotnet --help` prints a list of available commands.

`--info`

Prints out detailed information about a .NET Core installation and the machine environment, such as the current operating system, and commit SHA of the .NET Core version.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Not supported in every command; see specific command page to determine if this option is available.

`--version`

Prints out the version of the .NET Core SDK in use.

---

## dotnet commands

### General

# [.NET Core 2.1](#tab/netcore21)

| Command                                       | Function                                                            |
| --------------------------------------------- | ------------------------------------------------------------------- |
| [dotnet build](dotnet-build.md)               | Builds a .NET Core application.                                     |
| [dotnet build-server](dotnet-build-server.md) | Interacts with servers started by a build.                          |
| [dotnet clean](dotnet-clean.md)               | Clean build outputs.                                                |
| [dotnet help](dotnet-help.md)                 | Shows more detailed documentation online for the command.           |
| [dotnet migrate](dotnet-migrate.md)           | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.  |
| [dotnet msbuild](dotnet-msbuild.md)           | Provides access to the MSBuild command line.                        |
| [dotnet new](dotnet-new.md)                   | Initializes a C# or F# project for a given template.                |
| [dotnet pack](dotnet-pack.md)                 | Creates a NuGet package of your code.                               |
| [dotnet publish](dotnet-publish.md)           | Publishes a .NET framework-dependent or self-contained application. |
| [dotnet restore](dotnet-restore.md)           | Restores the dependencies for a given application.                  |
| [dotnet run](dotnet-run.md)                   | Runs the application from source.                                   |
| [dotnet sln](dotnet-sln.md)                   | Options to add, remove, and list projects in a solution file.       |
| [dotnet store](dotnet-store.md)               | Stores assemblies in the runtime package store.                     |
| [dotnet test](dotnet-test.md)                 | Runs tests using a test runner.                                     |

# [.NET Core 2.0](#tab/netcore20)

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
[dotnet add reference](dotnet-add-reference.md) | Adds a project reference.
[dotnet list reference](dotnet-list-reference.md) | Lists project references.
[dotnet remove reference](dotnet-remove-reference.md) | Removes a project reference.

### NuGet packages

Command | Function
--- | ---
[dotnet add package](dotnet-add-package.md) | Adds a NuGet package.
[dotnet remove package](dotnet-remove-package.md) | Removes a NuGet package.

### NuGet commands

Command | Function
--- | ---
[dotnet nuget delete](dotnet-nuget-delete.md) | Deletes or unlists a package from the server.
[dotnet nuget locals](dotnet-nuget-locals.md) | Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder.
[dotnet nuget push](dotnet-nuget-push.md) | Pushes a package to the server and publishes it.

### Global Tools commands

[.NET Core Global Tools](global-tools.md) are available starting with .NET Core SDK 2.1.300:

Command | Function
--- | ---
[dotnet tool install](dotnet-tool-install.md) | Installs a Global Tool on your machine.
[dotnet tool list](dotnet-tool-list.md) | Lists all Global Tools currently installed in the default directory on your machine or in the specified path.
[dotnet tool uninstall](dotnet-tool-uninstall.md) | Uninstalls a Global Tool from your machine.
[dotnet tool update](dotnet-tool-update.md) | Updates a Global Tool on your machine.

### Additional tools

Starting with .NET Core SDK 2.1.300, a number of tools that were available only on a per project basis using `DotnetCliToolReference` are now available as part of the .NET Core SDK. These tools are listed in the following table:

| Tool                                              | Function                                                     |
| ------------------------------------------------- | ------------------------------------------------------------ |
| dev-certs                                         | Creates and manages development certificates.                |
| [ef](/ef/core/miscellaneous/cli/dotnet)           | Entity Framework Core command-line tools.                    |
| sql-cache                                         | SQL Server cache command-line tools.                         |
| [user-secrets](/aspnet/core/security/app-secrets) | Manages development user secrets.                            |
| [watch](/aspnet/core/tutorials/dotnet-watch)      | Starts a file watcher that runs a command when files change. |

For more information about each tool, type `dotnet <tool-name> --help`.

## Examples

Creates a new .NET Core console application:

`dotnet new console`

Restore dependencies for a given application:

`dotnet restore`

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

Build a project and its dependencies in a given directory:

`dotnet build`

Run an application DLL, such as `myapp.dll`:

`dotnet myapp.dll`

## Environment variables

# [.NET Core 2.1](#tab/netcore21)

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted). Otherwise, set to `false` to opt into the telemetry features (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the telemetry feature is active.

`DOTNET_MULTILEVEL_LOOKUP`

Specifies whether .NET Core runtime, shared framework, or SDK are resolved from the global location. If not set, it defaults to `true`. Set to `false` to not resolve from the global location and have isolated .NET Core installations (values `0` or `false` are accepted). For more information about multi-level lookup, see [Multi-level SharedFX Lookup](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/multilevel-sharedfx-lookup.md).

`DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX`

Disables minor version roll forward, if set to `0`. For more information, see [Roll forward](../whats-new/dotnet-core-2-1.md#roll-forward).

# [.NET Core 2.0](#tab/netcore20)

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted). Otherwise, set to `false` to opt into the telemetry features (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the telemetry feature is active.

`DOTNET_MULTILEVEL_LOOKUP`

Specifies whether .NET Core runtime, shared framework, or SDK are resolved from the global location. If not set, it defaults to `true`. Set to `false` to not resolve from the global location and have isolated .NET Core installations (values `0` or `false` are accepted). For more information about multi-level lookup, see [Multi-level SharedFX Lookup](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/multilevel-sharedfx-lookup.md).

# [.NET Core 1.x](#tab/netcore1x)

`DOTNET_PACKAGES`

The primary package cache. If not set, it defaults to `$HOME/.nuget/packages` on Unix or `%HOME%\NuGet\Packages` on Windows.

`DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

`DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET Core tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted). Otherwise, set to `false` to opt into the telemetry features (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the telemetry feature is active.

---
