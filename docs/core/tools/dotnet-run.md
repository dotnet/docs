---
title: dotnet run command
description: The dotnet run command provides a convenient option to run your application from the source code.
ms.date: 02/19/2020
---
# dotnet run

**This article applies to:** ✔️ .NET Core 2.x SDK and later versions

## Name

`dotnet run` - Runs source code without any explicit compile or launch commands.

## Synopsis

```dotnetcli
dotnet run [-c|--configuration <CONFIGURATION>] [-f|--framework <FRAMEWORK>]
    [--force] [--interactive] [--launch-profile <NAME>] [--no-build]
    [--no-dependencies] [--no-launch-profile] [--no-restore]
    [-p|--project <PATH>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [-v|--verbosity <LEVEL>] [[--] [application arguments]]

dotnet run -h|--help
```

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build, such as that the project must be restored first, apply to `dotnet run` as well.

Output files are written into the default location, which is `bin/<configuration>/<target>`. For example if you have a `netcoreapp2.1` application and you run `dotnet run`, the output is placed in `bin/Debug/netcoreapp2.1`. Files are overwritten as needed. Temporary files are placed in the `obj` directory.

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use [dotnet](dotnet.md) without a command. For example, to run `myapp.dll`, use:

```dotnetcli
dotnet myapp.dll
```

For more information on the `dotnet` driver, see the [.NET Core Command Line Tools (CLI)](index.md) topic.

To run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` to run applications in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output.

### Implicit restore

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

## Options

- **`--`**

  Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this delimiter are passed to the application run.

- **`-c|--configuration <CONFIGURATION>`**

  Defines the build configuration. The default for most projects is `Debug`, but you can override the build configuration settings in your project.

- **`-f|--framework <FRAMEWORK>`**

  Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

- **`-h|--help`**

  Prints out a short help for the command.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example, to complete authentication). Available since .NET Core 3.0 SDK.

- **`--launch-profile <NAME>`**

  The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the *launchSettings.json* file and are typically called `Development`, `Staging`, and `Production`. For more information, see [Working with multiple environments](/aspnet/core/fundamentals/environments).

- **`--no-build`**

  Doesn't build the project before running. It also implicit sets the `--no-restore` flag.

- **`--no-dependencies`**

  When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

- **`--no-launch-profile`**

  Doesn't try to use *launchSettings.json* to configure the application.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-p|--project <PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). `-r` short option available since .NET Core 3.0 SDK.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `m`. Available since .NET Core 2.1 SDK.

## Examples

- Run the project in the current directory:

  ```dotnetcli
  dotnet run
  ```

- Run the specified project:

  ```dotnetcli
  dotnet run --project ./projects/proj1/proj1.csproj
  ```

- Run the project in the current directory (the `--help` argument in this example is passed to the application, since the blank `--` option is used):

  ```dotnetcli
  dotnet run --configuration Release -- --help
  ```

- Restore dependencies and tools for the project in the current directory only showing minimal output and then run the project:
 (.NET Core SDK 2.0 and later versions):

  ```dotnetcli
  dotnet run --verbosity m
  ```
