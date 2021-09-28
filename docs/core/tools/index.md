---
title: .NET CLI
titleSuffix: ""
description: An overview of the .NET CLI and its features.
ms.topic: overview
ms.date: 02/13/2020
---
# .NET CLI overview

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications.

The .NET CLI is included with the [.NET SDK](../sdk.md). To learn how to install the .NET SDK, see [Install .NET Core](../install/windows.md).

## CLI commands

The following commands are installed by default:

### Basic commands

- [`new`](dotnet-new.md)
- [`restore`](dotnet-restore.md)
- [`build`](dotnet-build.md)
- [`publish`](dotnet-publish.md)
- [`run`](dotnet-run.md)
- [`test`](dotnet-test.md)
- [`vstest`](dotnet-vstest.md)
- [`pack`](dotnet-pack.md)
- [`migrate`](dotnet-migrate.md)
- [`clean`](dotnet-clean.md)
- [`sln`](dotnet-sln.md)
- [`help`](dotnet-help.md)
- [`store`](dotnet-store.md)

### Project modification commands

- [`add package`](dotnet-add-package.md)
- [`add reference`](dotnet-add-reference.md)
- [`remove package`](dotnet-remove-package.md)
- [`remove reference`](dotnet-remove-reference.md)
- [`list reference`](dotnet-list-reference.md)

### Advanced commands

- [`nuget delete`](dotnet-nuget-delete.md)
- [`nuget locals`](dotnet-nuget-locals.md)
- [`nuget push`](dotnet-nuget-push.md)
- [`msbuild`](dotnet-msbuild.md)
- [`dotnet install script`](dotnet-install-script.md)

### Tool management commands

- [`tool install`](dotnet-tool-install.md)
- [`tool list`](dotnet-tool-list.md)
- [`tool update`](dotnet-tool-update.md)
- [`tool restore`](global-tools.md#install-a-local-tool) Available since .NET Core SDK 3.0.
- [`tool run`](global-tools.md#invoke-a-local-tool) Available since .NET Core SDK 3.0.
- [`tool uninstall`](dotnet-tool-uninstall.md)

Tools are console applications that are installed from NuGet packages and are invoked from the command prompt. You can write tools yourself or install tools written by third parties. Tools are also known as global tools, tool-path tools, and local tools. For more information, see [.NET tools overview](global-tools.md).

## Command structure

CLI command structure consists of [the driver ("dotnet")](#driver), [the command](#command), and possibly command [arguments](#arguments) and [options](#options). You see this pattern in most CLI operations, such as creating a new console app and running it from the command line as the following commands show when executed from a directory named *my_app*:

```dotnetcli
dotnet new console
dotnet build --output ./build_output
dotnet ./build_output/my_app.dll
```

### Driver

The driver is named [dotnet](dotnet.md) and has two responsibilities, either running a [framework-dependent app](../deploying/index.md) or executing a command.

To run a framework-dependent app, specify the app after the driver, for example, `dotnet /path/to/my_app.dll`. When executing the command from the folder where the app's DLL resides, simply execute `dotnet my_app.dll`. If you want to use a specific version of the .NET Runtime, use the `--fx-version <VERSION>` option (see the [dotnet command](dotnet.md) reference).

When you supply a command to the driver, `dotnet.exe` starts the CLI command execution process. For example:

```dotnetcli
dotnet build
```

First, the driver determines the version of the SDK to use. If there is no [global.json](global-json.md) file, the latest version of the SDK available is used. This might be either a preview or stable version, depending on what is latest on the machine.  Once the SDK version is determined, it executes the command.

### Command

The command performs an action. For example, `dotnet build` builds code. `dotnet publish` publishes code. The commands are implemented as a console application using a `dotnet {command}` convention.

### Arguments

The arguments you pass on the command line are the arguments to the command invoked. For example, when you execute `dotnet publish my_app.csproj`, the `my_app.csproj` argument indicates the project to publish and is passed to the `publish` command.

### Options

The options you pass on the command line are the options to the command invoked. For example, when you execute `dotnet publish --output /build_output`, the `--output` option and its value are passed to the `publish` command.

## See also

- [dotnet/sdk GitHub repository](https://github.com/dotnet/sdk/)
- [.NET installation guide](../install/windows.md)
