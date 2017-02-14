---
title: dotnet-run command | Microsoft Docs
description: The dotnet-run command provides a convenient option to run your application from the source code.
keywords: dotnet-run, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 40d4e60f-9900-4a48-b03c-0bae06792d91
---

#dotnet-run (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [dotnet-run](../../tools/dotnet-run.md) topic.

## Name 

dotnet-run -- Runs source code 'in-place' without any explicit compile or launch commands.

## Synopsis

`dotnet run [--help] [--framework] [--configuration]
    [--project] [[--] [application arguments]]`

## Description
The `dotnet run` command provides a convenient option to run your application from the source code with one command. 
It compiles source code, generates an output program and then runs that program. 
This command is useful for fast iterative development and can also be used to run a source-distributed program (for example, a website).

This command relies on [dotnet build](dotnet-build.md) to build source inputs to a .NET assembly, before launching the program. 
The requirements for this command and the handling of source inputs are all inherited from the build command. 
The documentation for the build command provides more information on those requirements.

Output files are written to the child *bin* folder, which will be created if it doesn't exist. 
Files will be overwritten as needed. 
Temporary files are written to the child *obj* folder.  

In case of a project with multiple specified frameworks, `dotnet run` will first select the .NET Core frameworks. If those do not exist, it will error out. To specify other frameworks, use the `--framework` argument.

The `dotnet run` command must be used in the context of projects, not built assemblies. If you're trying to run a portable application DLL instead, you should use [dotnet](dotnet.md) without any command like in the following example:
 
`dotnet myapp.dll`

For more information about the `dotnet` driver, see the [.NET Core Command Line Tools (CLI)](index.md) topic.

## Options

`--`

Delimits arguments to `dotnet run` from arguments for the application being run. 
All arguments after this one will be passed to the application being run. 

`-h|--help`

Prints out a short help for the command.

`-f`, `--framework <FRAMEWORK_IDENTIFIER>`

Runs the application for a given framework identifier (FID). 

`-c`, `--configuration <Debug|Release>`

Configuration to use when publishing. The default value is `Debug`.

`-p`, `--project [PATH]`

Specifies which project to run. 
It can be a path to a [csproj](csproj.md) file or to a directory containing a [csproj](csproj.md) file. It defaults to
current directory if not specified. 

## Examples

Run the project in the current directory:
`dotnet run` 

Run the specified project:

`dotnet run --project /projects/proj1/proj1.csproj`

Run the project in the current directory (the `--help` argument in this example is passed to the application being run, since the `--` argument was used):

`dotnet run --configuration Release -- --help`