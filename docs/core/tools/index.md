---
title: .NET Core Command-Line Interface (CLI) Tools
description: An overview of the .NET Core Command-Line Interface (CLI) tools and features.
author: mairaw
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# .NET Core command-line interface (CLI) tools

The .NET Core command-line interface (CLI) is a new cross-platform toolchain for developing .NET applications. The CLI is a foundation upon which higher-level tools, such as Integrated Development Environments (IDEs), editors, and build orchestrators, can rest.

## Installation

Either use the native installers or use the installation shell scripts:

* The native installers are primarily used on developer's machines and use each supported platform's native install mechanism, for instance, DEB packages on Ubuntu or MSI bundles on Windows. These installers install and configure the environment for immediate use by the developer but require administrative privileges on the machine. You can view the installation instructions in the [.NET Core installation guide](https://aka.ms/dotnetcoregs).
* Shell scripts are primarily used for setting up build servers or when you wish to install the tools without administrative privileges. Install scripts don't install prerequisites on the machine, which must be installed manually. For more information, see the [install script reference topic](dotnet-install-script.md). For information on how to set up CLI on your continuous integration (CI) build server, see [Using .NET Core SDK and tools in Continuous Integration (CI)](using-ci-with-cli.md).

By default, the CLI installs in a side-by-side (SxS) manner, so multiple versions of the CLI tools can coexist on a single machine. Determining which version is used on a machine where multiple versions are installed is explained in more detail in the [Driver](#driver) section.

## CLI commands

The following commands are installed by default:

# [.NET Core 2.x](#tab/netcore2x)

**Basic commands**

* [new](dotnet-new.md)
* [restore](dotnet-restore.md)
* [build](dotnet-build.md)
* [publish](dotnet-publish.md)
* [run](dotnet-run.md)
* [test](dotnet-test.md)
* [vstest](dotnet-vstest.md)
* [pack](dotnet-pack.md)
* [migrate](dotnet-migrate.md)
* [clean](dotnet-clean.md)
* [sln](dotnet-sln.md)
* [help](dotnet-help.md)
* [store](dotnet-store.md)

**Project modification commands**

* [add package](dotnet-add-package.md)
* [add reference](dotnet-add-reference.md)
* [remove package](dotnet-remove-package.md)
* [remove reference](dotnet-remove-reference.md)
* [list reference](dotnet-list-reference.md)

**Advanced commands**

* [nuget delete](dotnet-nuget-delete.md)
* [nuget locals](dotnet-nuget-locals.md)
* [nuget push](dotnet-nuget-push.md)
* [msbuild](dotnet-msbuild.md)
* [dotnet install script](dotnet-install-script.md)

# [.NET Core 1.x](#tab/netcore1x)

**Basic commands**

* [new](dotnet-new.md)
* [restore](dotnet-restore.md)
* [build](dotnet-build.md)
* [publish](dotnet-publish.md)
* [run](dotnet-run.md)
* [test](dotnet-test.md)
* [vstest](dotnet-vstest.md)
* [pack](dotnet-pack.md)
* [migrate](dotnet-migrate.md)
* [clean](dotnet-clean.md)
* [sln](dotnet-sln.md)

**Project modification commands**

* [add package](dotnet-add-package.md)
* [add reference](dotnet-add-reference.md)
* [remove package](dotnet-remove-package.md)
* [remove reference](dotnet-remove-reference.md)
* [list reference](dotnet-list-reference.md)

**Advanced commands**

* [nuget delete](dotnet-nuget-delete.md)
* [nuget locals](dotnet-nuget-locals.md)
* [nuget push](dotnet-nuget-push.md)
* [msbuild](dotnet-msbuild.md)
* [dotnet install script](dotnet-install-script.md)

---

The CLI adopts an extensibility model that allows you to specify additional tools for your projects. For more information, see the [.NET Core CLI extensibility model](extensibility.md) topic.

## Command structure

CLI command structure consists of [the driver ("dotnet")](#driver), [the command (or "verb")](#command-verb), and possibly command [arguments](#arguments) and [options](#options). You see this pattern in most CLI operations, such as creating a new console app and running it from the command line as the following commands show when executed from a directory named *my_app*:

# [.NET Core 2.x](#tab/netcore2x)

```console
dotnet new console
dotnet build --output /build_output
dotnet /build_output/my_app.dll
```

# [.NET Core 1.x](#tab/netcore1x)

```console
dotnet new console
dotnet restore
dotnet build --output /build_output
dotnet /build_output/my_app.dll
```


---

### Driver

The driver is named [dotnet](dotnet.md) and has two responsibilities, either running a [framework-dependent app](../deploying/index.md) or executing a command. The only time `dotnet` is used without a command is when it's used to start an application.

To run a framework-dependent app, specify the app after the driver, for example, `dotnet /path/to/my_app.dll`. When executing the command from the folder where the app's DLL resides, simply execute `dotnet my_app.dll`.

When you supply a command to the driver, `dotnet.exe` starts the CLI command execution process. First, the driver determines the version of the SDK to use. If the version isn't specified in the command options, the driver uses the latest version available. To specify a version other than the latest installed version, use the `--fx-version <VERSION>` option (see the [dotnet command](dotnet.md) reference). Once the SDK version is determined, the driver executes the command.

### Command ("verb")

The command (or "verb") is simply a command that performs an action. For example, `dotnet build` builds your code. `dotnet publish` publishes your code. The commands are implemented as a console application using a `dotnet {verb}` convention.

### Arguments

The arguments you pass on the command line are the arguments to the command invoked. For example when you execute `dotnet publish my_app.csproj`, the `my_app.csproj` argument indicates the project to publish and is passed to the `publish` command.

### Options

The options you pass on the command line are the options to the command invoked. For example when you execute `dotnet publish --output /build_output`, the `--output` option and its value are passed to the `publish` command. 

## Migration from project.json

If you used Preview 2 tooling to produce *project.json*-based projects, consult the [dotnet migrate](dotnet-migrate.md) topic for information on migrating your project to MSBuild/*.csproj* for use with release tooling. For .NET Core projects created prior to the release of Preview 2 tooling, either manually update the project following the guidance in [Migrating from DNX to .NET Core CLI (project.json)](../migration/from-dnx.md) and then use `dotnet migrate` or directly upgrade your projects.

## See also

 [dotnet/CLI GitHub Repository](https://github.com/dotnet/cli/)  
 [.NET Core installation guide](https://aka.ms/dotnetcoregs)  
