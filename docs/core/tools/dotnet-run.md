---
title: dotnet-run command | Microsoft Docs
description: The dotnet-run command provides a convenient option to run your application from the source code.
keywords: dotnet-run, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 40d4e60f-9900-4a48-b03c-0bae06792d91
---

#dotnet-run

## Name 

`dotnet-run` - Runs source code 'in-place' without any explicit compile or launch commands.

## Synopsis

```
dotnet run [-c|--configuration] [-f|--framework] [-p|--project] [[--] [application arguments]]
dotnet run [-h|--help]
```

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It is useful for fast iterative development in the command line. The command depends on [`dotnet build`](dotnet-build.md) command to build the code, so any requirements for the build, such as that the project has to be restored first, apply to `dotnet run` as well. 

Output files are written out into the default location which is `bin/<configuration>/<target>`. For example, if you have a `netcoreapp1.0` application and you run `dotnet run`, the output will be placed in `bin/Debug/netcoreapp1.0`. Files are overwritten as needed. Temporary files are placed in the `obj` directory. 

In case of a project with multiple specified frameworks, `dotnet run` will show an error unless `--framework` option is used to specify for which framework to run the application.

The `dotnet run` command must be used in the context of projects, not built assemblies. If you're trying to run a portable application DLL instead, you should use [dotnet](dotnet.md) without any command like in the following example:
 
`dotnet myapp.dll`

For more information about the `dotnet` driver, see the [.NET Core Command Line Tools (CLI)](index.md) topic.

In order to run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Given this, it is not recommended to use this command to run applications in production. Instead, you should [create a deployment](../deploying/index.md) using [`dotnet publish`](dotnet-publish.md) command and use that in production. 

## Options

`--`

Delimits arguments to `dotnet run` from arguments for the application being run. 
All arguments after this one will be passed to the application being run. 

`-h|--help`

Prints out a short help for the command.

`-c|--configuration {Debug|Release}`

Configuration to use for building the project. The default value is `Debug`.

`-f|--framework <FRAMEWORK_IDENTIFIER>`

Builds and runs the app using the specified framework. The framework has to be specified in the project file.

`-p|--project <PATH>`

Specifies the path to the project file to run. It can be a path to a [csproj](csproj.md) file or to a directory containing a [csproj](csproj.md) file. It defaults to
current directory if not specified. 

## Examples

Run the project in the current directory:

`dotnet run` 

Run the specified project:

`dotnet run --project /projects/proj1/proj1.csproj`

Run the project in the current directory (the `--help` argument in this example is passed to the application being run, since the `--` argument was used):

`dotnet run --configuration Release -- --help`