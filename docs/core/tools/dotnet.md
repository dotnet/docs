---
title: dotnet command
description: Learn about the dotnet command (the generic driver for the .NET CLI) and its usage.
ms.date: 05/06/2022
---
# dotnet command

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet` - The generic driver for the .NET CLI.

## Synopsis

To get information about the available commands and the environment:

```dotnetcli
dotnet [--version] [--info] [--list-runtimes] [--list-sdks]

dotnet -h|--help
```

To run a command (requires SDK installation):

```dotnetcli
dotnet <COMMAND> [-d|--diagnostics] [-h|--help] [--verbosity <LEVEL>]
    [command-options] [arguments]
```

To run an application:

```dotnetcli
dotnet [--additionalprobingpath <PATH>] [--additional-deps <PATH>]
    [--fx-version <VERSION>]  [--roll-forward <SETTING>]
    <PATH_TO_APPLICATION> [arguments]

dotnet exec [--additionalprobingpath <PATH>] [--additional-deps <PATH>]
    [--depsfile <PATH>]
    [--fx-version <VERSION>]  [--roll-forward <SETTING>]
    [--runtimeconfig <PATH>]
    <PATH_TO_APPLICATION> [arguments]
```

## Description

The `dotnet` command has two functions:

- It provides commands for working with .NET projects.

  For example, [`dotnet build`](dotnet-build.md) builds a project. Each command defines its own options and arguments. All commands support the `--help` option for printing out brief documentation about how to use the command.

- It runs .NET applications.

  You specify the path to an application `.dll` file to run the application.  To run the application means to find and execute the entry point, which in the case of console apps is the `Main` method. For example, `dotnet myapp.dll` runs the `myapp` application. See [.NET application deployment](../deploying/index.md) to learn about deployment options.

## Options

Different options are available for:

* Displaying information about the environment.
* Running a command.
* Running an application.

### Options for displaying environment information and available commands

The following options are available when `dotnet` is used by itself, without specifying a command or an application to run. For example, `dotnet --info` or `dotnet --version`. They print out information about the environment.

- **`--info`**

  Prints out detailed information about a .NET installation and the machine environment, such as the current operating system, and commit SHA of the .NET version.

- **`--version`**

Prints out the version of the .NET SDK used by `dotnet` commands, which may be affected by a *global.json* file. Available only when the SDK is installed.

- **`--list-runtimes`**

  Prints out a list of the installed .NET runtimes. An x86 version of the SDK lists only x86 runtimes, and an x64 version of the SDK lists only x64 runtimes.

- **`--list-sdks`**

  Prints out a list of the installed .NET SDKs.

- **`-?|-h|--help`**

  Prints out a list of available commands.

### Options for running a command

The following options are for `dotnet` with a command. For example, `dotnet build --help` or `dotnet build --verbosity diagnostic`.

- **`-d|--diagnostics`**

  Enables diagnostic output.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. Not supported in every command. See specific command page to determine if this option is available.

- **`-?|-h|--help`**

  Prints out documentation for a given command. For example, `dotnet build --help` displays help for the `build` command.

- **`command options`**

  Each command defines options specific to that command. See specific command page for a list of available options.

### Options for running an application

The following options are available when `dotnet` runs an application. For example, `dotnet --roll-forward Major myapp.dll`.

<a name="additionalprobingpath"></a>

- **`--additionalprobingpath <PATH>`**

  Path containing probing policy and assemblies to probe. Repeat the option to specify multiple paths.

- **`--additional-deps <PATH>`**

  Path to an additional *.deps.json* file. A *deps.json* file contains a list of dependencies, compilation dependencies, and version information used to address assembly conflicts. For more information, see [Runtime Configuration Files](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md) on GitHub.

<a name="rollforward"></a>

- **`--roll-forward <SETTING>`**

  Controls how roll forward is applied to the app. The `SETTING` can be one of the following values. If not specified, `Minor` is the default.

  - `LatestPatch` - Roll forward to the highest patch version. This disables minor version roll forward.
  - `Minor` - Roll forward to the lowest higher minor version, if requested minor version is missing. If the requested minor version is present, then the LatestPatch policy is used.
  - `Major` - Roll forward to lowest higher major version, and lowest minor version, if requested major version is missing. If the requested major version is present, then the Minor policy is used.
  - `LatestMinor` - Roll forward to highest minor version, even if requested minor version is present. Intended for component hosting scenarios.
  - `LatestMajor` - Roll forward to highest major and highest minor version, even if requested major is present. Intended for component hosting scenarios.
  - `Disable` - Don't roll forward. Only bind to specified version. This policy isn't recommended for general use because it disables the ability to roll forward to the latest patches. This value is only recommended for testing.

  With the exception of `Disable`, all settings will use the highest available patch version.

  Roll forward behavior can also be configured in a project file property, a runtime configuration file property, and an environment variable. For more information, see [Major-version runtime roll forward](../whats-new/dotnet-core-3-0.md#major-version-runtime-roll-forward).

- **`--fx-version <VERSION>`**

  Version of the .NET runtime to use to run the application.

  This option overrides the version of the first framework reference in the application's `.runtimeconfig.json` file. This means it only works as expected if there's just one framework reference. If the application has more than one framework reference, using this option may cause errors.

### Options for running an application with the `exec` command

The following options are available only when `dotnet` runs an application by using the `exec` command. For example, `dotnet exec --runtimeconfig myapp.runtimeconfig.json myapp.dll`.

- **`--depsfile <PATH>`**

  Path to a *deps.json* file. A *deps.json* file is a configuration file that contains information about dependencies necessary to run the application. This file is generated by the .NET SDK.

- **`--runtimeconfig <PATH>`**

  Path to a *runtimeconfig.json* file. A *runtimeconfig.json* file contains run-time settings and is typically named *\<applicationname>.runtimeconfig.json*. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

## dotnet commands

### General

| Command                                            | Function                                                            |
|----------------------------------------------------|---------------------------------------------------------------------|
| [dotnet build](dotnet-build.md)                    | Builds a .NET application.                                          |
| [dotnet build-server](dotnet-build-server.md)      | Interacts with servers started by a build.                          |
| [dotnet clean](dotnet-clean.md)                    | Clean build outputs.                                                |
| [dotnet exec](#options-for-running-an-application) | Runs a .NET application.                                            |
| [dotnet help](dotnet-help.md)                      | Shows more detailed documentation online for the command.           |
| [dotnet migrate](dotnet-migrate.md)                | Migrates a valid Preview 2 project to a .NET Core SDK 1.0 project.  |
| [dotnet msbuild](dotnet-msbuild.md)                | Provides access to the MSBuild command line.                        |
| [dotnet new](dotnet-new.md)                        | Initializes a C# or F# project for a given template.                |
| [dotnet pack](dotnet-pack.md)                      | Creates a NuGet package of your code.                               |
| [dotnet publish](dotnet-publish.md)                | Publishes a .NET framework-dependent or self-contained application. |
| [dotnet restore](dotnet-restore.md)                | Restores the dependencies for a given application.                  |
| [dotnet run](dotnet-run.md)                        | Runs the application from source.                                   |
| [dotnet sdk check](dotnet-sdk-check.md)            | Shows up-to-date status of installed SDK and Runtime versions.      |
| [dotnet sln](dotnet-sln.md)                        | Options to add, remove, and list projects in a solution file.       |
| [dotnet store](dotnet-store.md)                    | Stores assemblies in the runtime package store.                     |
| [dotnet test](dotnet-test.md)                      | Runs tests using a test runner.                                     |

### Project references

| Command                                               | Function                     |
|-------------------------------------------------------|------------------------------|
| [dotnet add reference](dotnet-add-reference.md)       | Adds a project reference.    |
| [dotnet list reference](dotnet-list-reference.md)     | Lists project references.    |
| [dotnet remove reference](dotnet-remove-reference.md) | Removes a project reference. |

### NuGet packages

| Command                                           | Function                 |
|---------------------------------------------------|--------------------------|
| [dotnet add package](dotnet-add-package.md)       | Adds a NuGet package.    |
| [dotnet remove package](dotnet-remove-package.md) | Removes a NuGet package. |

### NuGet commands

| Command                                       | Function                                         |
|-----------------------------------------------|--------------------------------------------------|
| [dotnet nuget delete](dotnet-nuget-delete.md) | Deletes or unlists a package from the server.    |
| [dotnet nuget push](dotnet-nuget-push.md)     | Pushes a package to the server and publishes it. |
| [dotnet nuget locals](dotnet-nuget-locals.md) | Clears or lists local NuGet resources such as http-request cache, temporary cache, or machine-wide global packages folder. |
| [dotnet nuget add source](dotnet-nuget-add-source.md) | Adds a NuGet source. |
| [dotnet nuget disable source](dotnet-nuget-disable-source.md) | Disables a NuGet source. |
| [dotnet nuget enable source](dotnet-nuget-enable-source.md) | Enables a NuGet source. |
| [dotnet nuget list source](dotnet-nuget-list-source.md) | Lists all configured NuGet sources. |
| [dotnet nuget remove source](dotnet-nuget-remove-source.md) | Removes a NuGet source. |
| [dotnet nuget update source](dotnet-nuget-update-source.md) | Updates a NuGet source. |

### Workload commands

| Command                                                 | Function                                            |
|---------------------------------------------------------|-----------------------------------------------------|
| [dotnet workload install](dotnet-workload-install.md)   | Installs an optional workload.                      |
| [dotnet workload list](dotnet-workload-list.md)         | Lists all installed workloads.                      |
| [dotnet workload repair](dotnet-workload-repair.md)     | Repairs all installed workloads.                    |
| [dotnet workload search](dotnet-workload-search.md)     | List selected workloads or all available workloads. |
| [dotnet workload uninstall](dotnet-workload-install.md) | Uninstalls a workload.                              |
| [dotnet workload update](dotnet-workload-update.md)     | Reinstalls all installed workloads.                 |

### Global, tool-path, and local tools commands

Tools are console applications that are installed from NuGet packages and are invoked from the command prompt. You can write tools yourself or install tools written by third parties. Tools are also known as global tools, tool-path tools, and local tools. For more information, see [.NET tools overview](global-tools.md).

| Command                                       | Function                         |
|-----------------------------------------------|----------------------------------|
| [dotnet tool install](dotnet-tool-install.md) | Installs a tool on your machine. |
| [dotnet tool list](dotnet-tool-list.md) | Lists all global, tool-path, or local tools currently installed on your machine. |
| [dotnet tool search](dotnet-tool-search.md) | Searches NuGet.org for tools that have the specified search term in their name or metadata. |
| [dotnet tool uninstall](dotnet-tool-uninstall.md) | Uninstalls a tool from your machine. |
| [dotnet tool update](dotnet-tool-update.md) | Updates a tool that is installed on your machine. |

### Additional tools

The following additional tools are available as part of the .NET SDK:

| Tool                                              | Function                                                     |
| ------------------------------------------------- | ------------------------------------------------------------ |
| [dev-certs](dotnet-dev-certs.md)                  | Creates and manages development certificates.                |
| [ef](/ef/core/miscellaneous/cli/dotnet)           | Entity Framework Core command-line tools.                    |
| [user-secrets](/aspnet/core/security/app-secrets) | Manages development user secrets.                            |
| [watch](dotnet-watch.md)                          | A file watcher that restarts or hot reloads an application when it detects changes in the source code. |

For more information about each tool, type `dotnet <tool-name> --help`.

## Examples

Create a new .NET console application:

```dotnetcli
dotnet new console
```

Build a project and its dependencies in a given directory:

```dotnetcli
dotnet build
```

Run an application:

```dotnetcli
dotnet exec myapp.dll
```

```dotnetcli
dotnet myapp.dll
```

## See also

- [Environment variables used by .NET SDK, .NET CLI, and .NET runtime](dotnet-environment-variables.md)
- [Runtime Configuration Files](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md)
- [.NET runtime configuration settings](../runtime-config/index.md)
