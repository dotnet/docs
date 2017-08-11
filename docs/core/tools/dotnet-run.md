---
title: dotnet run command
description: The 'dotnet run' command provides a convenient option to run your app from its source code.
keywords: dotnet run, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 40d4e60f-9900-4a48-b03c-0bae06792d91
---
# dotnet run

## Name 

`dotnet run` - Runs source code without explicit compile or launch commands.

## Synopsis

`dotnet run [-c|--configuration] [-f|--framework] [-h|--help] [--launch-profile] [--no-build] [--no-launch-profile] [-p|--project] [[--] [application arguments]]`

## Description

The `dotnet run` command runs your app from source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build, such as that the project must be restored first, apply to `dotnet run`. 

Output files are written into the default location, which is *bin/<configuration>/<target>*. For example if you have a `netcoreapp2.0` app and you run `dotnet run`, the output is placed in *bin/Debug/netcoreapp2.0*. Files are overwritten as needed. Temporary files are placed in the *obj* directory. 

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent app DLL instead, use [dotnet](dotnet.md) without a command. For example to run `myapp.dll`, use `dotnet myapp.dll`.

In order to run the app, the `dotnet run` command resolves the dependencies of the app that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` for apps in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output.

For more information on the `dotnet` driver, see the [.NET Core CLI Tools](index.md) topic.

## Options

`--`

Separates arguments to `dotnet run` from arguments for the app. The arguments after the `--` argument are passed to the app. 

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

`-h|--help`

Shows help information.

`--launch-profile <PROFILE>`

The name of the launch profile to use when launching the app.

`--no-build`

Skips building the project prior to running. By default, the project is built.

`--no-launch-profile`

Avoids using *launchSettings.json* to configure the app.

`-p|--project <PATH/PROJECT.csproj>`

Specifies the path and name of the project file. If this option isn't specified, the path defaults to the current directory.

## Examples

Run the project in the current directory:

`dotnet run` 

Run the specified project:

`dotnet run --project /projects/proj1/proj1.csproj`

Run the project in the current directory with a Release configuarion (the `--help` argument in this example is passed to the app, since `--help` is placed after the `--` argument):

`dotnet run --configuration Release -- --help`
