---
title: .NET Core CLI
titleSuffix: ""
description: An overview of the .NET Core CLI and its features.
ms.date: 08/14/2017
---
# .NET Core CLI overview

The .NET Core command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET Core applications.

The .NET Core CLI is included with the [.NET Core SDK](../sdk.md). To learn how to install the .NET Core SDK, see [Install the .NET Core SDK](../install/sdk.md).

## CLI commands

The following commands are installed by default:

<!-- markdownlint-disable MD025 -->

# [.NET Core 2.x](#tab/netcore2x)

**Basic commands**

- [new](dotnet-new.md)
- [restore](dotnet-restore.md)
- [build](dotnet-build.md)
- [publish](dotnet-publish.md)
- [run](dotnet-run.md)
- [test](dotnet-test.md)
- [vstest](dotnet-vstest.md)
- [pack](dotnet-pack.md)
- [migrate](dotnet-migrate.md)
- [clean](dotnet-clean.md)
- [sln](dotnet-sln.md)
- [help](dotnet-help.md)
- [store](dotnet-store.md)

**Project modification commands**

- [add package](dotnet-add-package.md)
- [add reference](dotnet-add-reference.md)
- [remove package](dotnet-remove-package.md)
- [remove reference](dotnet-remove-reference.md)
- [list reference](dotnet-list-reference.md)

**Advanced commands**

- [nuget delete](dotnet-nuget-delete.md)
- [nuget locals](dotnet-nuget-locals.md)
- [nuget push](dotnet-nuget-push.md)
- [msbuild](dotnet-msbuild.md)
- [dotnet install script](dotnet-install-script.md)

# [.NET Core 1.x](#tab/netcore1x)

**Basic commands**

- [new](dotnet-new.md)
- [restore](dotnet-restore.md)
- [build](dotnet-build.md)
- [publish](dotnet-publish.md)
- [run](dotnet-run.md)
- [test](dotnet-test.md)
- [vstest](dotnet-vstest.md)
- [pack](dotnet-pack.md)
- [migrate](dotnet-migrate.md)
- [clean](dotnet-clean.md)
- [sln](dotnet-sln.md)

**Project modification commands**

- [add package](dotnet-add-package.md)
- [add reference](dotnet-add-reference.md)
- [remove package](dotnet-remove-package.md)
- [remove reference](dotnet-remove-reference.md)
- [list reference](dotnet-list-reference.md)

**Advanced commands**

- [nuget delete](dotnet-nuget-delete.md)
- [nuget locals](dotnet-nuget-locals.md)
- [nuget push](dotnet-nuget-push.md)
- [msbuild](dotnet-msbuild.md)
- [dotnet install script](dotnet-install-script.md)

---

The CLI adopts an extensibility model that allows you to specify additional tools for your projects. For more information, see the [.NET Core CLI extensibility model](extensibility.md) topic.

## Command structure

CLI command structure consists of [the driver ("dotnet")](#driver), [the command](#command), and possibly command [arguments](#arguments) and [options](#options). You see this pattern in most CLI operations, such as creating a new console app and running it from the command line as the following commands show when executed from a directory named *my_app*:

# [.NET Core 2.x](#tab/netcore2x)

```dotnetcli
dotnet new console
dotnet build --output /build_output
dotnet /build_output/my_app.dll
```

# [.NET Core 1.x](#tab/netcore1x)

```dotnetcli
dotnet new console
dotnet restore
dotnet build --output /build_output
dotnet /build_output/my_app.dll
```

---

### Driver

The driver is named [dotnet](dotnet.md) and has two responsibilities, either running a [framework-dependent app](../deploying/index.md) or executing a command. 

To run a framework-dependent app, specify the app after the driver, for example, `dotnet /path/to/my_app.dll`. When executing the command from the folder where the app's DLL resides, simply execute `dotnet my_app.dll`. If you want to use a specific version of the .NET Core Runtime, use the `--fx-version <VERSION>` option (see the [dotnet command](dotnet.md) reference).

When you supply a command to the driver, `dotnet.exe` starts the CLI command execution process. For example:

```dotnetcli
dotnet build
```

First, the driver determines the version of the SDK to use. If there is no ['global.json'](global-json.md), the latest version of the SDK available is used. This might be either a preview or stable version, depending on what is latest on the machine.  Once the SDK version is determined, it executes the command.

### Command

The command performs an action. For example, `dotnet build` builds code. `dotnet publish` publishes code. The commands are implemented as a console application using a `dotnet {command}` convention.

### Arguments

The arguments you pass on the command line are the arguments to the command invoked. For example when you execute `dotnet publish my_app.csproj`, the `my_app.csproj` argument indicates the project to publish and is passed to the `publish` command.

### Options

The options you pass on the command line are the options to the command invoked. For example when you execute `dotnet publish --output /build_output`, the `--output` option and its value are passed to the `publish` command.

## Migration from project.json

If you used Preview 2 tooling to produce *project.json*-based projects, consult the [dotnet migrate](dotnet-migrate.md) topic for information on migrating your project to MSBuild/*.csproj* for use with release tooling. For .NET Core projects created prior to the release of Preview 2 tooling, either manually update the project following the guidance in [Migrating from DNX to .NET Core CLI (project.json)](../migration/from-dnx.md) and then use `dotnet migrate` or directly upgrade your projects.

## See also

- [dotnet/sdk GitHub repository](https://github.com/dotnet/sdk/)
- [.NET Core installation guide](https://aka.ms/dotnetcoregs)
