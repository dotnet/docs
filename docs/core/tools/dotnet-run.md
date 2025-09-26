---
title: dotnet run command
description: The dotnet run command provides a convenient option to run your application from the source code.
ms.date: 09/24/2025
---
# dotnet run

**This article applies to:** ✔️ .NET 6 and later versions

## Name

`dotnet run` - Runs source code without any explicit compile or launch commands.

## Synopsis

```dotnetcli
dotnet run [<applicationArguments>] [-a|--arch <ARCHITECTURE>] [--artifacts-path <ARTIFACTS_DIR>] [-c|--configuration <CONFIGURATION>] [--disable-build-servers]
    [-e|--environment <KEY=VALUE>] [--file <FILE_PATH>]
    [-f|--framework <FRAMEWORK>] [--force] [--interactive]
    [--launch-profile <NAME>] [--no-build] [--no-cache]
    [--no-dependencies] [--no-launch-profile] [--no-restore] [--no-self-contained]
    [--os <OS>] [--project <PATH>] [-r|--runtime <RUNTIME_IDENTIFIER>] [-sc|--self-contained]
    [--property:<NAME>=<VALUE>]
    [--tl:[auto|on|off]] [-v|--verbosity <LEVEL>]
    [[--] [application arguments]]

dotnet run -h|--help
```

## Description

The `dotnet run` command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the [`dotnet build`](dotnet-build.md) command to build the code. Any requirements for the build apply to `dotnet run` as well.

> [!NOTE]
> `dotnet run` doesn't respect arguments like `/property:property=value`, which are respected by `dotnet build`.

Output files are written into the default location, which is `bin/<configuration>/<target>`. For example if you have a `netcoreapp2.1` application and you run `dotnet run`, the output is placed in `bin/Debug/netcoreapp2.1`. Files are overwritten as needed. Temporary files are placed in the `obj` directory.

If the project specifies multiple frameworks, executing `dotnet run` results in an error unless the `-f|--framework <FRAMEWORK>` option is used to specify the framework.

The `dotnet run` command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use [dotnet](dotnet.md) without a command. For example, to run `myapp.dll`, use:

```dotnetcli
dotnet myapp.dll
```

For more information on the `dotnet` driver, see [.NET CLI overview](index.md).

To run the application, the `dotnet run` command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use `dotnet run` to run applications in production. Instead, [create a deployment](../deploying/index.md) using the [`dotnet publish`](dotnet-publish.md) command and deploy the published output.

### Implicit restore

[!INCLUDE[dotnet restore note + options](~/includes/dotnet-restore-note-options.md)]

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

  `<applicationArguments>`
  
  Arguments passed to the application that is being run.
  
  Any arguments that aren't recognized by `dotnet run` are passed to the application. To separate arguments for `dotnet run` from arguments for the application, use the `--` option.

## Options

- **`--`**

  Delimits arguments to `dotnet run` from arguments for the application being run. All arguments after this delimiter are passed to the application run.

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [artifacts-path](../../../includes/cli-artifacts-path.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

[!INCLUDE [disable-build-servers](../../../includes/cli-disable-build-servers.md)]

- **`-e|--environment <KEY=VALUE>`**

  Sets the specified environment variable in the process that will be run by the command. The specified environment variable is *not* applied to the `dotnet run` process.

  Environment variables passed through this option take precedence over ambient environment variables, System.CommandLine `env` directives, and `environmentVariables` from the chosen launch profile. For more information, see [Environment variables](#environment-variables).

  (This option was added in .NET SDK 9.0.200.)

- **`-f|--framework <FRAMEWORK>`**

  Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

- **`--file <FILE_PATH>`**

  The path to the file-based app to run. If a path isn't specified, the current directory is used to find and run the file. For more information on file-based apps, see [Build file-based C# apps](/dotnet/csharp/fundamentals/tutorials/file-based-programs).
  
  On Unix, you can run file-based apps directly, using the source file name on the command line instead of `dotnet run`. First, ensure the file has execute permissions. Then, add a shebang line `#!` as the first line of the file, for example:
  
  ```csharp
  #!/usr/bin/env dotnet run
  ```
  
  Then you can run the file directly from the command line:
  
  ```bash
  ./ConsoleApp.cs
  ```

  Introduced in .NET SDK 10.0.100.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`--launch-profile <NAME>`**

  The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the *launchSettings.json* file and are typically called `Development`, `Staging`, and `Production`. For more information, see [Working with multiple environments](/aspnet/core/fundamentals/environments).

- **`--no-build`**

  Doesn't build the project before running. It also implicitly sets the `--no-restore` flag.

- **`--no-cache`**

  Skip up to date checks and always build the program before running.

- **`--no-dependencies`**

  When restoring a project with project-to-project (P2P) references, restores the root project and not the references.

- **`--no-launch-profile`**

  Doesn't try to use *launchSettings.json* to configure the application.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`--no-self-contained`**

  Publish your application as a framework dependent application. A compatible .NET runtime must be installed on 
  the target machine to run your application.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`--project <PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

  The [`-p` abbreviation for `--project` is deprecated](../compatibility/sdk/6.0/deprecate-p-option-dotnet-run.md) starting in .NET 6 SDK. For a limited time starting in .NET 6 RC1 SDK, `-p` can still be used for `--project` despite the deprecation warning. If the argument provided for the option doesn't contain `=`, the command accepts `-p` as short for `--project`. Otherwise, the command assumes that `-p` is short for `--property`. This flexible use of `-p` for `--project` will be phased out in .NET 7.

- **`--property:<NAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties delimited by semicolons or by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1>;<NAME2>=<VALUE2>
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  The short form `-p` can be used for `--property`. If the argument provided for the option contains `=`, `-p` is accepted as short for `--property`. Otherwise, the command assumes that `-p` is short for `--project`.

  To pass `--property` to the application rather than set an MSBuild property, provide the option after the `--` syntax separator, for example:

  ```dotnetcli
  dotnet run -- --property name=value
  ```

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

- **`-sc|--self-contained`**

  Publishes the .NET runtime with your application so the runtime doesn't need to be installed on the target system. The default is `false`.  However, when targeting .NET 7 or lower, the default is `true` if a runtime identifier is specified.

[!INCLUDE [tl](../../../includes/cli-tl.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Environment variables

There are four mechanisms by which environment variables can be applied to the launched application:

1. Ambient environment variables from the operating system when the command is run.
1. System.CommandLine `env` directives, like `[env:key=value]`. These apply to the entire `dotnet run` process, not just the project being run by `dotnet run`.
1. `environmentVariables` from the chosen launch profile (`-lp`) in the project's [launchSettings.json file](/aspnet/core/fundamentals/environments#lsj), if any. These apply to the project being run by `dotnet run`.
1. `-e|--environment` CLI option values (added in .NET SDK version 9.0.200). These apply to the project being run by `dotnet run`.

The environment is constructed in the same order as this list, so the `-e|--environment` option has the highest precedence.

## Examples

- Run the project in the current directory:

  ```dotnetcli
  dotnet run
  ```

- Run the specified file-based app in the current directory:

  ```dotnetcli
  dotnet run --file ConsoleApp.cs
  ```

  File-based app support was added in .NET SDK 10.0.100.

- Run the specified project:

  ```dotnetcli
  dotnet run --project ./projects/proj1/proj1.csproj
  ```

- Run the project in the current directory, specifying Release configuration:

  ```dotnetcli
  dotnet run --property:Configuration=Release
  ```

- Run the project in the current directory (the `--help` argument in this example is passed to the application, since the blank `--` option is used):

  ```dotnetcli
  dotnet run --configuration Release -- --help
  ```

- Restore dependencies and tools for the project in the current directory only showing minimal output and then run the project:

  ```dotnetcli
  dotnet run --verbosity m
  ```

- Run the project in the current directory using the specified framework and pass arguments to the application:

  ```dotnetcli
  dotnet run -f net6.0 -- arg1 arg2
  ```

  In the following example, three arguments are passed to the application. One argument is passed using `-`, and two arguments are passed after `--`:

  ```dotnetcli
  dotnet run -f net6.0 -arg1 -- arg2 arg3
  ```
  