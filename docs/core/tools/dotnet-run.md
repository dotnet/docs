---
title: dotnet-run command - .NET Core CLI | Microsoft Docs
description: The dotnet-run command provides a convenient option to run your application from the source code.
keywords: dotnet-run, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/22/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 40d4e60f-9900-4a48-b03c-0bae06792d91
---

# dotnet-run

## Name 

`dotnet-run` - Runs source code without any explicit compile or launch commands.

## Synopsis

`dotnet run [-c|--configuration] [-f|--framework] [-p|--project] [[--] [application arguments]] [-h|--help]`

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build, such as that the project must be restored first, apply to `dotnet run` as well. 

Output files are written into the default location, which is `bin/<configuration>/<target>`. For example if you have a `netcoreapp1.0` application and you run `dotnet run`, the output is placed in `bin/Debug/netcoreapp1.0`. Files are overwritten as needed. Temporary files are placed in the `obj` directory. 

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use [dotnet](dotnet.md) without a command. For example, to run `myapp.dll`, use:
 
```
dotnet myapp.dll
```

For more information on the `dotnet` driver, see the [.NET Core Command Line Tools (CLI)](index.md) topic.

In order to run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` to run applications in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output. 

## Options

`--`

Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this one are passed to the application run. 

`-h|--help`

Prints out a short help for the command.

`-c|--configuration <CONFIGURATION>`

Configuration to use for building the project. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

`-p|--project <PATH/PROJECT.csproj>`

Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.

> [!NOTE]
> Use the path and name of the project file with the `-p|--project` option. A regression in the CLI prevents providing a folder path at this time. For more information and to track this issue, see [dotnet run -p, can not start a project (dotnet/cli #5992)](https://github.com/dotnet/cli/issues/5992).

## Examples

Run the project in the current directory:

`dotnet run` 

Run the specified project:

`dotnet run --project /projects/proj1/proj1.csproj`

Run the project in the current directory (the `--help` argument in this example is passed to the application, since the `--` argument is used):

`dotnet run --configuration Release -- --help`
