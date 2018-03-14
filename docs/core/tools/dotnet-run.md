---
title: dotnet run command - .NET Core CLI
description: The dotnet run command provides a convenient option to run your application from the source code.
author: mairaw
ms.author: mairaw
ms.date: 03/10/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet run

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet run` - Runs source code without any explicit compile or launch commands.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)

```
dotnet run [-c|--configuration] [-f|--framework] [--force] [--launch-profile] [--no-build] [--no-dependencies] [--no-launch-profile] [--no-restore] [-p|--project] [--runtime] [[--] [application arguments]]
dotnet run [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)

```
dotnet run [-c|--configuration] [-f|--framework] [-p|--project] [[--] [application arguments]]
dotnet run [-h|--help]
```

---

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

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

## Options

# [.NET Core 2.x](#tab/netcore2x)

`--`

Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this one are passed to the application run.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

`--force`

Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting *project.assets.json*.

`-h|--help`

Prints out a short help for the command.

`--launch-profile <NAME>`

The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the *launchSettings.json* file and are typically called `Development`,
`Staging` and `Production`. For more information, see [Working with multiple environments](/aspnet/core/fundamentals/environments).

`--no-build`

Doesn't build the project before running.

`--no-dependencies`

When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

`--no-launch-profile`

Doesn't attempt to use *launchSettings.json* to configure the application.

`--no-restore`

Doesn't perform an implicit restore when running the command.

`-p|--project <PATH>`

Specifies the path of the project file to run (folder name or full path). It defaults to the current directory if not specified.

`--runtime <RUNTIME_IDENTIFIER>`

Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

# [.NET Core 1.x](#tab/netcore1x)

`--`

Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this one are passed to the application run.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-f|--framework <FRAMEWORK>`

Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

`-h|--help`

Prints out a short help for the command.

`-p|--project <PATH/PROJECT.csproj>`

Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.

> [!NOTE]
> Use the path and name of the project file with the `-p|--project` option. A regression in the CLI prevents providing a folder path with .NET Core SDK 1.x. For more information about this issue, see [dotnet run -p, can not start a project (dotnet/cli #5992)](https://github.com/dotnet/cli/issues/5992).

---

## Examples

Run the project in the current directory:

`dotnet run`

Run the specified project:

`dotnet run --project /projects/proj1/proj1.csproj`

Run the project in the current directory (the `--help` argument in this example is passed to the application, since the `--` argument is used):

`dotnet run --configuration Release -- --help`

Restore dependencies and tools for the project in the current directory only showing minimal output and then run the project:
 (.NET Core SDK 2.0 and later versions):

`dotnet run --verbosity m`